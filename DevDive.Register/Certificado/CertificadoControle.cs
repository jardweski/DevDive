using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
