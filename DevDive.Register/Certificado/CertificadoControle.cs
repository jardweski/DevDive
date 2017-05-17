using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevDive.Common;
using DevDive.Register.Certificado.DadosDeProdutos;
using DevDive.Register.Certificado.Impressao;

namespace DevDive.Register.Certificado
{
	public class CertificadoControle
	{
		private readonly SqlConnection _conn;
		private readonly SqlConnection _connIgd;

		public CertificadoControle(SqlConnection getData, SqlConnection getIgdData)
		{
			_conn = getData;
			_connIgd = getIgdData;
		}

		public IEnumerable<ProdutosPedido> GetProdutosPedidos()
		{
			try
			{
				_connIgd.Open();

				var returnList = new List<ProdutosPedido>();

				using (
					var myCommand = new SqlCommand(
						@"SELECT  tblordemproducao.Id AS IdOrdemProducao ,
									[tblordemproducaopedidos].[IdPedidoVenda] AS IdPedido ,
									[tblprodutos].[Id] AS IdProduto ,
									[tblprodutos].[Codigo] AS ProdutoCodigo ,
									tblprodutos.Descricao AS ProdutoDescricao,
									[tblprodutosserie].[Id] AS IdSerie,
									[tblprodutosserie].[Serie]
							FROM    tblordemproducao
									INNER JOIN dbo.tblordemproducaoprodutos ON tblordemproducaoprodutos.IdOP = tblordemproducao.Id
									INNER JOIN dbo.tblprodutosmovimento ON tblprodutosmovimento.Id = tblordemproducaoprodutos.IdProdutoMovimento
									INNER JOIN dbo.tblprodutos ON tblprodutos.Id = tblprodutosmovimento.IdProduto
									LEFT JOIN dbo.tblordemproducaopedidos ON tblordemproducaopedidos.IdOrdemProducao = tblordemproducao.Id
									LEFT JOIN tblpedidodevenda ON tblpedidodevenda.Id = tblordemproducaopedidos.IdPedidoVenda
									LEFT JOIN [DevDive.Yerbalatina].dbo.tblordemdeproducaostatus ON tblordemdeproducaostatus.IdOrdemProducao = tblordemproducao.Id
									LEFT JOIN [dbo].[tblprodutosmovimentoserie] ON [tblprodutosmovimentoserie].[IdProdutoMovimento] = [tblprodutosmovimento].[Id]
									LEFT JOIN [dbo].[tblprodutosserie] ON [tblprodutosserie].[Id] = [tblprodutosmovimentoserie].[IdSerie]
							WHERE   CASE WHEN tblordemdeproducaostatus.Status IS NULL
										 THEN CASE WHEN tblordemproducao.Situacao = 1 THEN 2
												   ELSE tblordemproducao.Situacao
											  END
										 ELSE tblordemdeproducaostatus.Status
									END = 2
							ORDER BY tblordemproducao.DataLancamento DESC", _connIgd)
				)
				{
					var myReader = myCommand.ExecuteReader();

					while (myReader.Read())
						returnList.Add(new ProdutosPedido
						{
							IdOrdemProducao = Convert.ToInt32(myReader["IdOrdemProducao"]),
							IdPedido = myReader["IdPedido"] == DBNull.Value ? (int?)null : Convert.ToInt32(myReader["IdPedido"]),
							IdProduto = Convert.ToInt32(myReader["IdProduto"]),
							ProdutoCodigo = myReader["ProdutoCodigo"].ToString(),
							ProdutoDescricao = myReader["ProdutoDescricao"].ToString(),
							IdSerie = myReader["IdSerie"]==DBNull.Value?(int?)null: Convert.ToInt32(myReader["IdSerie"]),
							Serie = myReader["Serie"].ToString()
						});
				}

				return returnList;
			}
			catch (Exception ex)
			{
				_connIgd.Close();
			}
			finally
			{
				_connIgd.Close();
			}
			return null;
		}

		public BindingList<ResultadoAnalise> GetAnaliseResult(int? idProduto,int? idSerie,int? idPedido)
		{
			try
			{
				_conn.Open();

				var returnList = new BindingList<ResultadoAnalise>();

				using (
					var myCommand = new SqlCommand(
						$@"SELECT  [tblcertificadoresultado].[Id],
                                [tblprodutosanalises].[IdAnalise] ,
                                [tblanalises].[Descricao] AS Analise,
				                [tblcertificadoresultado].[Resultado]
                        FROM    [dbo].[tblprodutosanalises]
                                INNER JOIN [dbo].[tblanalises] ON [tblanalises].[Id] = [tblprodutosanalises].[IdAnalise]
                                LEFT JOIN [dbo].[tblcertificadoresultado] ON [tblcertificadoresultado].[IdAnalise] = [tblprodutosanalises].[IdAnalise]
                                                                             AND [tblcertificadoresultado].[IdSerie] = {idSerie}
                        WHERE   [tblprodutosanalises].[IdProduto] = {idProduto}", _conn)
				)
				{
					var myReader = myCommand.ExecuteReader();

					while (myReader.Read())
						returnList.Add(new ResultadoAnalise()
						{
                            Id = (int?)myReader["Id"],
							IdAnalise = Convert.ToInt32(myReader["IdAnalise"]),
							Analise = myReader["Analise"].ToString(),
							Resultado = myReader["Resultado"].ToString(),
                            IdSerie = Convert.ToInt32(idSerie),
                            IdPedido = Convert.ToInt32(idPedido)
						});
				}

				return returnList;
			}
			catch (Exception ex)
			{
				_conn.Close();
			}
			finally
			{
				_conn.Close();
			}
			return null;
		}

	    public DevDiveReturn SaveResultado(BindingList<ResultadoAnalise> resultados)
	    {
	        _conn.Open();
	        var tran = _conn.BeginTransaction();
	        try
	        {
                foreach (var resultadoAnalise in resultados)
	            {
	                if (resultadoAnalise.Id==null)
	                {
	                    new SqlCommand($@"INSERT INTO [dbo].[tblcertificadoresultado]
                                                ( [IdPedido] ,
                                                  [IdSerie] ,
                                                  [IdAnalise] ,
                                                  [Resultado]
                                                )
                                        VALUES  ( {resultadoAnalise.IdPedido} ,
                                                  {resultadoAnalise.IdSerie} ,
                                                  {resultadoAnalise.IdAnalise} ,
                                                  '{resultadoAnalise.Resultado}'
                                                )", _conn, tran).ExecuteNonQuery();
	                }else
	                {
	                    new SqlCommand($@"UPDATE [dbo].[tblcertificadoresultado]
                                                SET [IdPedido]={resultadoAnalise.IdPedido},
                                                  [IdSerie]={resultadoAnalise.IdSerie} ,
                                                  [IdAnalise]={resultadoAnalise.IdAnalise} ,
                                                  [Resultado]='{resultadoAnalise.Resultado}'
                                               WHERE [tblcertificadoresultado].[Id]={resultadoAnalise.Id} ", _conn, tran).ExecuteNonQuery();
                    }

	            }

	            tran.Commit();

	            return new DevDiveReturn { Message = "Resultados salvos com sucesso!" };
	        }
	        catch (Exception ex)
	        {
	            tran.Rollback();

	            return new DevDiveReturn
	            {
	                Errors = new List<string> { ex.Message + "\r\n" + ex.InnerException },
	                Message = "Falha ao salvar resultado!"
	            };
	        }
	        finally
	        {
	            _conn?.Close();
	        }

	    }
	}
}
