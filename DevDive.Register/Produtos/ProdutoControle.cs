using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using DevDive.Common;
using DevDive.Register.ProdutosProcessos;

namespace DevDive.Register.Produtos
{
    public class ProdutoControle
    {
        private readonly SqlConnection _conn;
        private readonly SqlConnection _connIgd;

        public ProdutoControle(SqlConnection getData, SqlConnection getIgdData)
        {
            _conn = getData;
            _connIgd = getIgdData;
        }

        public IEnumerable<ProdutoComposicao> GetListProductCompound()
        {
            try
            {
                _connIgd.Open();

                var returnList = new List<ProdutoComposicao>();

                using (
                    var myCommand = new SqlCommand(
                        @"SELECT  tblprodutos.Id ,
                                tblprodutos.Codigo ,
                                tblprodutos.Descricao
                        FROM    tblprodutos
                                INNER JOIN tblprodutoscomposicaomp ON tblprodutoscomposicaomp.IdProduto = tblprodutos.Id
                        GROUP BY tblprodutos.Id ,
                                tblprodutos.Codigo ,
                                tblprodutos.Descricao
                        ORDER BY tblprodutos.Descricao", _connIgd)
                    )
                {
                    var myReader = myCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        returnList.Add(new ProdutoComposicao
                        {
                            Id = Convert.ToInt32(myReader["Id"]),
                            Codigo = myReader["Codigo"].ToString(),
                            Descricao = myReader["Descricao"].ToString()
                        });
                    }
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

        public IEnumerable<ProdutoComposto> GetListCompound(int idProduto)
        {
            try
            {
                _connIgd.Open();

                var returnList = new List<ProdutoComposto>();

                using (
                    var myCommand = new SqlCommand(
                        @"SELECT tblprodutos.Id ,
                                tblprodutos.Codigo ,
                                tblprodutos.Descricao ,
                                tblprodutoscomposicaomp.Quantidade ,
                                tblprodutos.Unidade,
                                tblprodutoscomposicaomp.Quebra
                        FROM    tblprodutos
                                INNER JOIN tblprodutoscomposicaomp ON tblprodutoscomposicaomp.IdProdutoCompoe = tblprodutos.Id
                        WHERE tblprodutoscomposicaomp.IdProduto = @IdProduto
                        GROUP BY tblprodutos.Id ,
                                tblprodutos.Codigo ,
                                tblprodutos.Descricao ,
                                tblprodutoscomposicaomp.Quantidade ,
                                tblprodutos.Unidade,
                                tblprodutoscomposicaomp.Quebra
                        ORDER BY tblprodutos.Descricao", _connIgd)
                    )
                {
                    var pIdProduto = new SqlParameter("@IdProduto", SqlDbType.Int) {Value = idProduto};
                    myCommand.Parameters.Add(pIdProduto);

                    var myReader = myCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        returnList.Add(new ProdutoComposto
                        {
                            Id = Convert.ToInt32(myReader["Id"]),
                            Codigo = myReader["Codigo"].ToString(),
                            Descricao = myReader["Descricao"].ToString(),
                            Quantidade = Convert.ToDecimal(myReader["Quantidade"]),
                            Quebra = Convert.ToDecimal(myReader["Quebra"]),
                            Unidade = myReader["Unidade"].ToString()
                        });
                    }
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

        public IEnumerable<ProdutoProcesso> GetProcessProduct(int idProdutoComposto)
        {
            try
            {
                _conn.Open();

                var returnList = new List<ProdutoProcesso>();

                using (
                    var myCommand = new SqlCommand(
                        @"SELECT  tblprodutosprocessos.Id ,
                                    tblprodutosprocessos.IdProduto ,
                                    tblprodutosprocessos.IdProcesso ,
                                    tblprodutosprocessos.Ordem,
                                    tblprodutosprocessos.Tempo ,
                                    tblprodutosprocessos.Quantidade
                            FROM    dbo.tblprodutosprocessos
                            WHERE   tblprodutosprocessos.IdProduto = @IdProduto
                            ORDER BY tblprodutosprocessos.Ordem", _conn)
                    )
                {
                    var pIdProduto = new SqlParameter("@IdProduto", SqlDbType.Int) {Value = idProdutoComposto};
                    myCommand.Parameters.Add(pIdProduto);

                    var myReader = myCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        returnList.Add(new ProdutoProcesso(Convert.ToInt32(myReader["IdProduto"]), this)
                        {
                            Id = Convert.ToInt32(myReader["Id"]),
                            Ordem = Convert.ToInt32(myReader["Ordem"]),
                            IdProcesso = Convert.ToInt32(myReader["IdProcesso"]),
                            Tempo = Convert.ToDecimal(myReader["Tempo"]),
                            Quantidade = Convert.ToDecimal(myReader["Quantidade"])
                        });
                    }
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

        public DevDiveReturn SaveProcessProduct(int IdProdutoComposto, BindingList<ProdutoProcesso> produtosProcessos)
        {
            _conn.Open();
            var tran = _conn.BeginTransaction();
            try
            {
                var myCommand =
                    new SqlCommand(
                        @"DELETE FROM dbo.tblprodutosprocessos WHERE tblprodutosprocessos.IdProduto=@IdProduto", _conn,
                        tran);

                var pDescricao = new SqlParameter("@IdProduto", SqlDbType.Int)
                {
                    Value = IdProdutoComposto
                };

                myCommand.Parameters.Add(pDescricao);

                myCommand.ExecuteNonQuery();

                foreach (var produtoProcesso in produtosProcessos)
                {
                    myCommand =
                        new SqlCommand(@"INSERT  INTO dbo.tblprodutosprocessos
                                                ( IdProduto ,
                                                  IdProcesso ,
                                                  Ordem ,
                                                  Tempo ,
                                                  Quantidade
                                                )
                                        VALUES  ( @IdProduto , -- IdProduto - int
                                                  @IdProcesso , -- IdProcesso - int
                                                  @Ordem ,  -- Ordem - int
                                                  ( SELECT  CONVERT(DECIMAL(6, 2), @Tempo)
                                                  ) , -- Tempo - numeric
                                                  ( SELECT  CONVERT(DECIMAL(6, 2), @Quantidade)
                                                  )  -- Quantidade - numeric
                                                )", _conn, tran);

                    pDescricao = new SqlParameter("@IdProduto", SqlDbType.Int)
                    {
                        Value = produtoProcesso.IdProduto
                    };
                    var pIdProcesso = new SqlParameter("@IdProcesso", SqlDbType.Int)
                    {
                        Value = produtoProcesso.IdProcesso
                    };
                    var pOrdem = new SqlParameter("@Ordem", SqlDbType.Int) {Value = produtoProcesso.Ordem};

                    var pTempo = new SqlParameter("@Tempo", SqlDbType.Decimal)
                    {
                        Value = Convert.ToDecimal(produtoProcesso.Tempo)
                    };
                    var pQuantidade = new SqlParameter("@Quantidade", SqlDbType.Decimal)
                    {
                        Value = Convert.ToDecimal(produtoProcesso.Quantidade)
                    };

                    myCommand.Parameters.Add(pDescricao);
                    myCommand.Parameters.Add(pIdProcesso);
                    myCommand.Parameters.Add(pOrdem);
                    myCommand.Parameters.Add(pTempo);
                    myCommand.Parameters.Add(pQuantidade);

                    myCommand.ExecuteNonQuery();
                }


                tran.Commit();


                return new DevDiveReturn {Message = "Processos salvos com sucesso!"};
            }
            catch (Exception ex)
            {
                tran.Rollback();

                return new DevDiveReturn
                {
                    Errors = new List<string> {ex.Message + "\r\n" + ex.InnerException},
                    Message = "Falha ao salvar processo!"
                };
            }
            finally
            {
                _conn?.Close();
            }
        }

        public string GetUnitProduct(int idProduto)
        {
            _connIgd.Open();
            var tran = _connIgd.BeginTransaction();
            try
            {
                var myCommand =
                    new SqlCommand(
                        @"SELECT  tblprodutos.Unidade
                        FROM    tblprodutos WITH ( NOLOCK )
                        WHERE   tblprodutos.Id = @IdProduto;", _connIgd,
                        tran);

                var pIdProduto = new SqlParameter("@IdProduto", SqlDbType.Int)
                {
                    Value = idProduto
                };

                myCommand.Parameters.Add(pIdProduto);

                var unidade = myCommand.ExecuteScalar().ToString();

                tran.Commit();

                return unidade;
            }
            catch (Exception ex)
            {
                tran.Rollback();

                return null;
            }
            finally
            {
                _connIgd?.Close();
            }
        }
    }
}