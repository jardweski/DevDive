using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using DevDive.Common;
using DevDive.Register.Certificado.DadosDeProdutos;
using DevDive.Register.ProdutosAnalises;
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
                        returnList.Add(new ProdutoComposicao
                        {
                            Id = Convert.ToInt32(myReader["Id"]),
                            Codigo = myReader["Codigo"].ToString(),
                            Descricao = myReader["Descricao"].ToString()
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
                        returnList.Add(new ProdutoProcesso(Convert.ToInt32(myReader["IdProduto"]), this)
                        {
                            Id = Convert.ToInt32(myReader["Id"]),
                            Ordem = Convert.ToInt32(myReader["Ordem"]),
                            IdProcesso = Convert.ToInt32(myReader["IdProcesso"]),
                            Tempo = Convert.ToDecimal(myReader["Tempo"]),
                            Quantidade = Convert.ToDecimal(myReader["Quantidade"])
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

        public IEnumerable<ProdutoAnalise> GetAnalisysProduct(int idProduto)
        {
            try
            {
                _conn.Open();

                var returnList = new List<ProdutoAnalise>();

                using (
                    var myCommand = new SqlCommand(
                        @"SELECT  [tblprodutosanalises].[Id] ,
                                [tblprodutosanalises].[IdProduto] ,
                                [tblprodutosanalises].[IdAnalise],
                                [tblanalises].[Descricao]
                        FROM    [dbo].[tblprodutosanalises]
                                INNER JOIN dbo.[tblanalises] ON [tblanalises].[Id] = [tblprodutosanalises].IdAnalise
                        WHERE [tblprodutosanalises].[IdProduto]=@IdProduto", _conn)
                )
                {
                    var pIdProduto = new SqlParameter("@IdProduto", SqlDbType.Int) {Value = idProduto};
                    myCommand.Parameters.Add(pIdProduto);

                    var myReader = myCommand.ExecuteReader();

                    while (myReader.Read())
                        returnList.Add(new ProdutoAnalise(Convert.ToInt32(myReader["IdProduto"]))
                        {
                            Id = Convert.ToInt32(myReader["Id"]),
                            IdAnalise = Convert.ToInt32(myReader["IdAnalise"]),
                            DescricaoAnalise = myReader["Descricao"].ToString()
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

        public DevDiveReturn SaveProcessProduct(int idProdutoComposto, BindingList<ProdutoProcesso> produtosProcessos)
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
                    Value = idProdutoComposto
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

        public DevDiveReturn SaveAnalisysProduct(int idProdutoComposto, BindingList<ProdutoAnalise> produtoAnalise)
        {
            _conn.Open();
            var tran = _conn.BeginTransaction();
            try
            {
                var myCommand =
                    new SqlCommand(
                        @"DELETE FROM dbo.[tblprodutosanalises] WHERE [tblprodutosanalises].IdProduto=@IdProduto",
                        _conn,
                        tran);

                var pDescricao = new SqlParameter("@IdProduto", SqlDbType.Int)
                {
                    Value = idProdutoComposto
                };

                myCommand.Parameters.Add(pDescricao);

                myCommand.ExecuteNonQuery();

                foreach (var item in produtoAnalise)
                {
                    myCommand =
                        new SqlCommand(@"INSERT  INTO dbo.[tblprodutosanalises]
                                                ( IdProduto ,
                                                  [IdAnalise] 
                                                )
                                        VALUES  ( @IdProduto , -- IdProduto - int
                                                  @IdAnalise  -- IdProcesso - int
                                                )", _conn, tran);

                    pDescricao = new SqlParameter("@IdProduto", SqlDbType.Int)
                    {
                        Value = item.IdProduto
                    };
                    var pIdAnalise = new SqlParameter("@IdAnalise", SqlDbType.Int)
                    {
                        Value = item.IdAnalise
                    };

                    myCommand.Parameters.Add(pDescricao);
                    myCommand.Parameters.Add(pIdAnalise);

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


        public BindingList<Serie> GetSeriesProduct(int idProduto)
        {
            try
            {
                _connIgd.Open();

                var returnList = new BindingList<Serie>();

                using (
                    var myCommand = new SqlCommand(
                        @"SELECT  [tblprodutosserie].[Id] ,
                                        [tblprodutosserie].[Serie] ,
                                        [tblprodutosserie].[Data] ,
                                        [tblprodutosserie].[Estoque]
                                FROM    [dbo].[tblprodutosserie]
                            WHERE [tblprodutosserie].[IdProduto]=@IdProduto", _connIgd)
                )
                {
                    var pIdProduto = new SqlParameter("@IdProduto", SqlDbType.Int) {Value = idProduto};
                    myCommand.Parameters.Add(pIdProduto);

                    var myReader = myCommand.ExecuteReader();

                    while (myReader.Read())
                        returnList.Add(new Serie
                        {
                            Id = Convert.ToInt32(myReader["Id"]),
                            Data = Convert.ToDateTime(myReader["Data"]),
                            Descricao = myReader["Serie"].ToString(),
                            Estoque = Convert.ToDecimal(myReader["Estoque"])
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


        public SerieCertificado GetSeriesCertificate(int idSerie)
        {
            try
            {
                _conn.Open();

                var returnList = new List<SerieCertificado>();

                using (
                    var myCommand = new SqlCommand(
                        @"SELECT  [tblseriecertificado].[Id] ,
                                [tblseriecertificado].[IdSerie] ,
                                [tblseriecertificado].[Code] ,
                                [tblseriecertificado].[Batch] ,
                                [tblseriecertificado].[BotanicalSource] ,
                                [tblseriecertificado].[Family] ,
                                [tblseriecertificado].[Origin] ,
                                [tblseriecertificado].[HarvestRegion] ,
                                [tblseriecertificado].[UsedPart] ,
                                [tblseriecertificado].[Preservative] ,
                                [tblseriecertificado].[Colorant] ,
                                [tblseriecertificado].[Solvent] ,
                                [tblseriecertificado].[Carrier] ,
                                [tblseriecertificado].[DryResidue] ,
                                [tblseriecertificado].[Ratio] ,
                                [tblseriecertificado].[Irradiation] ,
                                [tblseriecertificado].[GMO] ,
                                [tblseriecertificado].[BSE]
                        FROM    [dbo].[tblseriecertificado]
                        WHERE   [tblseriecertificado].[IdSerie] = @IdSerie", _conn)
                )
                {
                    var pIdSerie = new SqlParameter("@IdSerie", SqlDbType.Int) {Value = idSerie};
                    myCommand.Parameters.Add(pIdSerie);

                    var myReader = myCommand.ExecuteReader();

                    while (myReader.Read())
                        returnList.Add(new SerieCertificado
                        {
                            Id = Convert.ToInt32(myReader["Id"]),
                            IdSerie = Convert.ToInt32(myReader["IdSerie"]),
                            Code = myReader["Code"].ToString(),
                            Batch = myReader["Batch"].ToString(),
                            BotanicalSource = myReader["BotanicalSource"].ToString(),
                            Family = myReader["Family"].ToString(),
                            Origin = myReader["Origin"].ToString(),
                            HarvestRegion = myReader["HarvestRegion"].ToString(),
                            UsedPart = myReader["UsedPart"].ToString(),
                            Preservative = myReader["Preservative"].ToString(),
                            Colorant = myReader["Colorant"].ToString(),
                            Solvent = myReader["Solvent"].ToString(),
                            Carrier = myReader["Carrier"].ToString(),
                            DryResidue = myReader["DryResidue"].ToString(),
                            Ratio = myReader["Ratio"].ToString(),
                            Irradiation = myReader["Irradiation"].ToString(),
                            GMO = myReader["GMO"].ToString(),
                            BSE = myReader["BSE"].ToString()
                        });
                }

                return returnList.Any() ? returnList.First() : new SerieCertificado();
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

        public DevDiveReturn SaveProductSerieCertificate(SerieCertificado serieCertificado)
        {
            _conn.Open();
            var tran = _conn.BeginTransaction();
            try
            {
                var myCommand =
                    new SqlCommand(
                        @"DELETE  FROM [dbo].[tblseriecertificado]
                        WHERE   [tblseriecertificado].[IdSerie] = @IdSerie", _conn,
                        tran);

                var pId = new SqlParameter("@IdSerie", SqlDbType.Int)
                {
                    Value = serieCertificado.IdSerie
                };

                myCommand.Parameters.Add(pId);

                myCommand.ExecuteNonQuery();

                myCommand = new SqlCommand(@"INSERT  INTO [dbo].[tblseriecertificado]
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
                                    VALUES  ( @IdSerie ,
                                              @Code ,
                                              @Batch ,
                                              @BotanicalSource ,
                                              @Family ,
                                              @Origin ,
                                              @HarvestRegion ,
                                              @UsedPart ,
                                              @Preservative ,
                                              @Colorant ,
                                              @Solvent ,
                                              @Carrier ,
                                              @DryResidue ,
                                              @Ratio ,
                                              @Irradiation ,
                                              @GMO ,
                                              @BSE
                                            )",_conn,tran);


                var idSerie = new SqlParameter("@IdSerie", SqlDbType.Int) {Value = serieCertificado.IdSerie};
                var code = new SqlParameter("@Code", SqlDbType.Text) {Value = serieCertificado.Code};
                var batch = new SqlParameter("@Batch", SqlDbType.Text) {Value = serieCertificado.Batch};
                var botanicalSource =
                    new SqlParameter("@BotanicalSource", SqlDbType.Text) {Value = serieCertificado.BotanicalSource};
                var family = new SqlParameter("@Family", SqlDbType.Text) {Value = serieCertificado.Family};
                var origin = new SqlParameter("@Origin", SqlDbType.Text) {Value = serieCertificado.Origin};
                var harvestRegion =
                    new SqlParameter("@HarvestRegion", SqlDbType.Text) {Value = serieCertificado.HarvestRegion};
                var usedPart = new SqlParameter("@UsedPart", SqlDbType.Text) {Value = serieCertificado.UsedPart};
                var preservative =
                    new SqlParameter("@Preservative", SqlDbType.Text) {Value = serieCertificado.Preservative};
                var colorant =
                    new SqlParameter("@Colorant", SqlDbType.Text) {Value = serieCertificado.Colorant};
                var solvent =
                    new SqlParameter("@Solvent", SqlDbType.Text) {Value = serieCertificado.Solvent};
                var carrier =
                    new SqlParameter("@Carrier", SqlDbType.Text) {Value = serieCertificado.Carrier};
                var dryResidue =
                    new SqlParameter("@DryResidue", SqlDbType.Text) {Value = serieCertificado.DryResidue};
                var ratio =
                    new SqlParameter("@Ratio", SqlDbType.Text) {Value = serieCertificado.Ratio};
                var irradiation =
                    new SqlParameter("@Irradiation", SqlDbType.Text) {Value = serieCertificado.Irradiation};
                var gmo =
                    new SqlParameter("@GMO", SqlDbType.Text) {Value = serieCertificado.GMO};
                var bse =
                    new SqlParameter("@BSE", SqlDbType.Text) {Value = serieCertificado.BSE};

                myCommand.Parameters.Add(idSerie);
                myCommand.Parameters.Add(code);
                myCommand.Parameters.Add(batch);
                myCommand.Parameters.Add(botanicalSource);
                myCommand.Parameters.Add(family);
                myCommand.Parameters.Add(origin);
                myCommand.Parameters.Add(harvestRegion);
                myCommand.Parameters.Add(usedPart);
                myCommand.Parameters.Add(preservative);
                myCommand.Parameters.Add(colorant);
                myCommand.Parameters.Add(solvent);
                myCommand.Parameters.Add(carrier);
                myCommand.Parameters.Add(dryResidue);
                myCommand.Parameters.Add(ratio);
                myCommand.Parameters.Add(irradiation);
                myCommand.Parameters.Add(gmo);
                myCommand.Parameters.Add(bse);

                myCommand.ExecuteNonQuery();


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
    }
}