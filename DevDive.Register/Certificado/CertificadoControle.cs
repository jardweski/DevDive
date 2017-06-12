using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
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
                        @"SELECT  
		                        [tblprodutos].[Id] AS IdProduto,
		                        [tblprodutosserie].[Id] AS IdSerie,
                                [tblprodutos].[Codigo] AS CodigoProduto,
		                        [tblprodutos].[Descricao] AS Produto,
		                        [tblprodutosserie].[Serie],
		                        [tblordemproducao].[Id] AS IdOrdemProducao,
		                        [tblpedidodevenda].[Id] AS IdPedidoDeVenda
                        FROM    [dbo].[tblprodutos]
                                INNER JOIN [dbo].[tblprodutosestoque] ON [tblprodutosestoque].[IdProduto] = [tblprodutos].[Id]
                                INNER JOIN [dbo].[tblprodutosserie] ON [tblprodutosserie].[IdProduto] = [tblprodutos].[Id]
                                                                        AND [tblprodutosserie].[Inativo] = 0
                                LEFT JOIN [DevDive.Yerbalatina].[dbo].[tblordemproducaoserie] ON [DevDive.Yerbalatina].[dbo].[tblordemproducaoserie].[IdSerie] = [tblprodutosserie].[Id]
                                LEFT JOIN [dbo].[tblordemproducao] ON [tblordemproducao].[Id] = [DevDive.Yerbalatina].[dbo].[tblordemproducaoserie].[IdOP]
                                LEFT JOIN [dbo].[tblordemproducaopedidos] ON [tblordemproducaopedidos].[IdOrdemProducao] = [tblordemproducao].[Id]
                                LEFT JOIN [dbo].[tblpedidodevenda] ON [tblpedidodevenda].[Id] = [tblordemproducaopedidos].[IdPedidoVenda]
                        WHERE   [tblprodutosestoque].[Inativo] = 0
                                AND [tblprodutosestoque].[Empresa] = 1
                        ORDER BY [tblpedidodevenda].[Id] DESC ,
                                [tblprodutos].[Descricao]", _connIgd)
                )
                {
                    var myReader = myCommand.ExecuteReader();

                    while (myReader.Read())
                        returnList.Add(new ProdutosPedido
                        {
                            IdOrdemProducao = myReader["IdOrdemProducao"] == DBNull.Value
                                ? (int?) null
                                : Convert.ToInt32(myReader["IdOrdemProducao"]),
                            IdPedido = myReader["IdPedidoDeVenda"] == DBNull.Value
                                ? (int?) null
                                : Convert.ToInt32(myReader["IdPedidoDeVenda"]),
                            IdProduto = Convert.ToInt32(myReader["IdProduto"]),
                            ProdutoCodigo = myReader["CodigoProduto"].ToString(),
                            ProdutoDescricao = myReader["Produto"].ToString(),
                            IdSerie = myReader["IdSerie"] == DBNull.Value
                                ? (int?) null
                                : Convert.ToInt32(myReader["IdSerie"]),
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

        public BindingList<ResultadoAnalise> GetAnaliseResult(int? idProduto, int? idSerie, int? idPedido)
        {
            try
            {
                _conn.Open();

                var returnList = new BindingList<ResultadoAnalise>();

                using (
                    var myCommand = new SqlCommand(
                        $@"SELECT  CASE WHEN SUM([resultados].[Id]) = 0 THEN NULL
                                     ELSE SUM([resultados].[Id])
                                END AS Id ,
                                [resultados].[IdAnalise] ,
                                [resultados].[Analise] ,
                                MAX([resultados].[Resultado]) AS Resultado
                        FROM    ( SELECT    '' AS Id ,
                                            [tblanalises].Id AS [IdAnalise] ,
                                            [tblanalises].[Descricao] AS Analise ,
                                            '' AS Resultado
                                  FROM      [dbo].[tblanalises]
                                  UNION
                                  SELECT    [tblcertificadoresultado].[Id] ,
                                            [tblanalises].Id AS [IdAnalise] ,
                                            [tblanalises].[Descricao] AS Analise ,
                                            [tblcertificadoresultado].[Resultado]
                                  FROM      [dbo].[tblanalises]
                                            LEFT JOIN [dbo].[tblcertificadoresultado] ON [tblcertificadoresultado].[IdAnalise] = [tblanalises].[Id]
                                  WHERE     [tblcertificadoresultado].[IdSerie] = {idSerie}
                                ) resultados
                        GROUP BY [resultados].[IdAnalise] ,
                                [resultados].[Analise]", _conn)
                )
                {
                    var myReader = myCommand.ExecuteReader();

                    while (myReader.Read())
                        returnList.Add(new ResultadoAnalise
                        {
                            Id = myReader["Id"] == DBNull.Value
                                ? null : (int?) myReader["Id"],
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

        public DevDiveReturn SaveResultado(ProdutosPedido produto, IEnumerable<ResultadoAnalise> resultados,
            IEnumerable<SerieCertificado> dados)
        {
            _conn.Open();
            var tran = _conn.BeginTransaction();
            try
            {
                foreach (var resultadoAnalise in resultados)
                    if (resultadoAnalise.Id == null)
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
                    else
                        new SqlCommand($@"UPDATE [dbo].[tblcertificadoresultado]
                                                SET [IdPedido]={resultadoAnalise.IdPedido},
                                                  [IdSerie]={resultadoAnalise.IdSerie} ,
                                                  [IdAnalise]={resultadoAnalise.IdAnalise} ,
                                                  [Resultado]='{resultadoAnalise.Resultado}'
                                               WHERE [tblcertificadoresultado].[Id]={resultadoAnalise.Id} ", _conn,
                            tran).ExecuteNonQuery();

                new SqlCommand(
                    $@"DELETE FROM [dbo].[tblseriecertificado] WHERE [tblseriecertificado].[IdSerie]={
                            produto.IdSerie
                        }",_conn,tran).ExecuteNonQuery();

                var query = $@"INSERT INTO [dbo].[tblseriecertificado]
                            ( [IdSerie] ,
                              [Code] ,
                              [Batch] ,
                              [BotanicalSource] ,
                              [Family] ,
                              [Origin] ,
                              [HarvestRegion] ,
                              [UsedPart] ,
                              [Preservative] ,
                              [Colorant] ,
                              [Solvent] ,
                              [Carrier] ,
                              [DryResidue] ,
                              [Ratio] ,
                              [Irradiation] ,
                              [GMO] ,
                              [BSE]
                            )
                    VALUES  (";

                foreach (var dado in dados)
                {
                    switch (dado.Info)
                    {
                        case "Id":
                            continue;
                        case "IdSerie":
                            query += produto.IdSerie.ToString();
                            break;
                        case "Batch":
                            query += "'" + produto.Serie +"'";
                            break;
                        default:
                            query += string.IsNullOrEmpty(dado.Value)? "NULL" : "'"+dado.Value+"'";
                            break;
                    }
                    query += ",";
                }

                query = query.Substring(0, query.Length - 1) + ")";

                new SqlCommand(query, _conn, tran).ExecuteNonQuery();

                tran.Commit();

                return new DevDiveReturn {Message = "Resultados salvos com sucesso!"};
            }
            catch (Exception ex)
            {
                tran.Rollback();

                return new DevDiveReturn
                {
                    Errors = new List<string> {ex.Message + "\r\n" + ex.InnerException},
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