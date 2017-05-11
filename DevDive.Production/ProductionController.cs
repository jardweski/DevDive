using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using DevDive.Common;

namespace DevDive.Production
{
    public class ProductionController
    {
        public readonly SqlConnection _getData;
        public readonly SqlConnection _getIgdData;

        public ProductionController(SqlConnection getData, SqlConnection getIgdData)
        {
            _getData = getData;
            _getIgdData = getIgdData;
        }

        public BindingList<ProductionOrder> GetList()
        {
            try
            {
                _getIgdData.Open();

                var returnList = new BindingList<ProductionOrder>();

                using (
                    var myCommand =
                        new SqlCommand(
                            @"SELECT  tblordemproducao.Id ,
                                    tblordemproducao.DataLancamento ,
                                    tblpedidodevenda.DataEntrega,
                                    CASE WHEN tblordemdeproducaostatus.Status IS NULL
                                         THEN CASE WHEN tblordemproducao.Situacao = 1 THEN 2
                                                   ELSE tblordemproducao.Situacao
                                              END
                                         ELSE tblordemdeproducaostatus.Status
                                    END AS Situacao ,
                                    tblprodutos.Descricao,
                                    tblprodutosmovimento.Quantidade,
                                    tblordemproducao.DataConfirmacao ,
                                    tblordemproducao.Observacao,
                                    [tblpedidodevenda].[Id] AS IdPedido
                            FROM    tblordemproducao
		                            INNER JOIN dbo.tblordemproducaoprodutos ON tblordemproducaoprodutos.IdOP = tblordemproducao.Id
		                            INNER JOIN dbo.tblprodutosmovimento ON tblprodutosmovimento.Id = tblordemproducaoprodutos.IdProdutoMovimento
		                            INNER JOIN dbo.tblprodutos on tblprodutos.Id = tblprodutosmovimento.IdProduto
                                    LEFT JOIN dbo.tblordemproducaopedidos ON tblordemproducaopedidos.IdOrdemProducao = tblordemproducao.Id
                                    LEFT JOIN tblpedidodevenda ON tblpedidodevenda.Id = tblordemproducaopedidos.IdPedidoVenda
                                    LEFT JOIN [DevDive.Yerbalatina].dbo.tblordemdeproducaostatus ON tblordemdeproducaostatus.IdOrdemProducao = tblordemproducao.Id
                            WHERE [tblprodutosmovimento].[Quantidade]>0
                            ORDER BY tblordemproducao.DataLancamento DESC"
                            , _getIgdData)
                )
                {
                    var myReader = myCommand.ExecuteReader();

                    while (myReader.Read())
                        returnList.Add(new ProductionOrder
                        {
                            Id = Convert.ToInt32(myReader["Id"]),
                            DataLancamento = Convert.ToDateTime(myReader["DataLancamento"]),
                            DataEntrega = myReader["DataEntrega"] as DateTime?,
                            Situacao = Convert.ToInt32(myReader["Situacao"]),
                            DataConfirmacao = myReader["DataConfirmacao"] as DateTime?,
                            Observacao = myReader["Observacao"]?.ToString(),
                            Descricao = myReader["Descricao"].ToString(),
                            Quantidade = Convert.ToDecimal(myReader["Quantidade"])
                        });
                }

                return returnList;
            }
            catch (Exception ex)
            {
                _getIgdData.Close();
            }
            finally
            {
                _getIgdData.Close();
            }
            return null;
        }


        public BindingList<Product> GetFinalProducts(int idOrder)
        {
            try
            {
                _getIgdData.Open();

                var returnList = new BindingList<Product>();

                using (
                    var myCommand =
                        new SqlCommand(
                            @"SELECT  tblprodutos.Id,
                                        tblprodutos.Codigo ,
                                        tblprodutos.Descricao ,
                                        tblprodutosmovimento.Quantidade
                                FROM    dbo.tblordemproducaoprodutos
                                        INNER JOIN dbo.tblprodutosmovimento ON tblprodutosmovimento.Id = tblordemproducaoprodutos.IdProdutoMovimento
                                        INNER JOIN tblprodutos ON tblprodutos.Id = tblprodutosmovimento.IdProduto
                                WHERE tblordemproducaoprodutos.IdOP=@IdOrdem", _getIgdData)
                )
                {
                    var pIdOrder = new SqlParameter("@IdOrdem", SqlDbType.Int)
                    {
                        Value = idOrder
                    };

                    myCommand.Parameters.Add(pIdOrder);

                    var myReader = myCommand.ExecuteReader();

                    while (myReader.Read())
                        returnList.Add(new Product
                        {
                            Id = Convert.ToInt32(myReader["Id"]),
                            Codigo = myReader["Codigo"]?.ToString(),
                            Descricao = myReader["Descricao"]?.ToString(),
                            Quantidade = Convert.ToDecimal(myReader["Quantidade"]?.ToString())
                        });
                }

                return returnList;
            }
            catch (Exception ex)
            {
                _getIgdData.Close();
            }
            finally
            {
                _getIgdData.Close();
            }
            return null;
        }

        public object GetCompositions(int idOrdem, Product produtoFinal)
        {
            try
            {
                _getIgdData.Open();

                var returnList = new BindingList<Product>();

                using (
                    var myCommand =
                        new SqlCommand(
                            @"SELECT  tblprodutos.Id,
                                        tblprodutos.Codigo ,
                                        tblprodutos.Descricao ,
                                        tblprodutoscomposicaomp.Quantidade
                                FROM    dbo.tblordemproducaoprodutos
                                        INNER JOIN dbo.tblprodutosmovimento ON tblprodutosmovimento.Id = tblordemproducaoprodutos.IdProdutoMovimento
                                        INNER JOIN dbo.tblprodutoscomposicaomp ON tblprodutoscomposicaomp.IdProduto = tblprodutosmovimento.IdProduto
                                        INNER JOIN dbo.tblprodutos ON tblprodutos.Id = tblprodutoscomposicaomp.IdProdutoCompoe
                                        WHERE tblordemproducaoprodutos.IdOP=@IdOrdem AND tblprodutoscomposicaomp.IdProduto=@IdProduto",
                            _getIgdData)
                )
                {
                    var pIdProduto = new SqlParameter("@IdProduto", SqlDbType.Int)
                    {
                        Value = produtoFinal.Id
                    };
                    var pIdOrdem = new SqlParameter("@IdOrdem", SqlDbType.Int)
                    {
                        Value = idOrdem
                    };

                    myCommand.Parameters.Add(pIdProduto);
                    myCommand.Parameters.Add(pIdOrdem);

                    var myReader = myCommand.ExecuteReader();

                    while (myReader.Read())
                        returnList.Add(new Product
                        {
                            Id = Convert.ToInt32(myReader["Id"]),
                            Codigo = myReader["Codigo"]?.ToString(),
                            Descricao = myReader["Descricao"]?.ToString(),
                            Quantidade = Convert.ToDecimal(myReader["Quantidade"]?.ToString()) * produtoFinal.Quantidade
                        });
                }

                return returnList;
            }
            catch (Exception ex)
            {
                _getIgdData.Close();
            }
            finally
            {
                _getIgdData.Close();
            }
            return null;
        }

        public BindingList<ProcessProduction> GetProcessProduct(Product produto, int IdOrdemProducao)
        {
            try
            {
                _getData.Open();

                var returnList = new BindingList<ProcessProduction>();

                using (
                    var myCommand =
                        new SqlCommand(
                            @"SELECT  tblprodutosprocessos.Id ,
                                    tblprodutosprocessos.Ordem ,
                                    tblprocessos.Descricao ,
                                    tblprodutosprocessos.Tempo ,
                                    tblordemproducaoprocessos.Tempo AS TempoUtilizado ,
                                    tblprodutosprocessos.Quantidade,
                                    tblprocessos.Id as IdProcesso
                            FROM    dbo.tblprodutosprocessos
                                    INNER JOIN dbo.tblprocessos ON tblprocessos.Id = tblprodutosprocessos.IdProcesso
                                    LEFT JOIN dbo.tblordemproducaoprocessos ON tblordemproducaoprocessos.IdProcesso = tblprodutosprocessos.Id
                                                   AND tblordemproducaoprocessos.IdOP = @IdOp
                            WHERE   tblprodutosprocessos.IdProduto = @IdProduto", _getData)
                )
                {
                    var pIdProduto = new SqlParameter("@IdProduto", SqlDbType.Int)
                    {
                        Value = produto.Id
                    };
                    var pIdOrdemProducao = new SqlParameter("@IdOp", SqlDbType.Int)
                    {
                        Value = IdOrdemProducao
                    };

                    myCommand.Parameters.Add(pIdProduto);
                    myCommand.Parameters.Add(pIdOrdemProducao);

                    var myReader = myCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        var tempo = Convert.ToDecimal(myReader["Tempo"]?.ToString());
                        var quantidade = Convert.ToDecimal(myReader["Quantidade"]?.ToString());

                        returnList.Add(new ProcessProduction
                        {
                            Id = Convert.ToInt32(myReader["IdProcesso"]),
                            Ordem = Convert.ToInt32(myReader["Ordem"]),
                            Descricao = myReader["Descricao"]?.ToString(),
                            Tempo = produto.Quantidade * tempo / (quantidade == 0 ? 1 : quantidade),
                            TempoUtilizado = myReader["TempoUtilizado"] as decimal?,
                            Quantidade = produto.Quantidade // Convert.ToDecimal(myReader["Quantidade"]?.ToString())
                        });
                    }
                }

                return returnList;
            }
            catch (Exception ex)
            {
                _getData.Close();
            }
            finally
            {
                _getData.Close();
            }
            return null;
        }

        public bool OrderHasStarted(int idOrdem)
        {
            try
            {
                _getData.Open();


                using (
                    var myCommand =
                        new SqlCommand(
                            @"SELECT  Status
                                FROM    dbo.tblordemdeproducaostatus
                                WHERE   tblordemdeproducaostatus.IdOrdemProducao = @IdOrdem", _getData)
                )
                {
                    var pIdOrdem = new SqlParameter("@IdProduto", SqlDbType.Int)
                    {
                        Value = idOrdem
                    };

                    myCommand.Parameters.Add(pIdOrdem);

                    var result = myCommand.ExecuteScalar();

                    return result != DBNull.Value;
                }
            }
            catch (Exception ex)
            {
                _getData.Close();
            }
            finally
            {
                _getData.Close();
            }
            return false;
        }

        public DevDiveReturn StartOrder(int idOrdem)
        {
            _getData.Open();
            var tran = _getData.BeginTransaction();
            try
            {
                var myCommand = new SqlCommand(
                    @"INSERT INTO dbo.tblordemdeproducaostatus
                                ( IdOrdemProducao, Status )
                        VALUES  ( @IdOrdem,@Status)", _getData, tran);

                var pIdOrdem = new SqlParameter("@IdOrdem", SqlDbType.Int)
                {
                    Value = idOrdem
                };
                // 1= Iniciado
                // 2 = Concluido
                var pStatus = new SqlParameter("@Status", SqlDbType.Int) {Value = 1};

                myCommand.Parameters.Add(pIdOrdem);
                myCommand.Parameters.Add(pStatus);

                myCommand.ExecuteNonQuery();

                tran.Commit();


                return new DevDiveReturn {Message = "Ordem iniciada com sucesso!"};
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
                _getData?.Close();
            }
        }

        public DevDiveReturn FinishOrder(int idOrdem, int idProduto, decimal quantidade,
            BindingList<ProcessProduction> processos)
        {
            _getData.Open();
            _getIgdData.Open();
            var tran = _getData.BeginTransaction();
            var tranIgd = _getIgdData.BeginTransaction();
            try
            {
                var myCommand = new SqlCommand(
                    @"UPDATE dbo.tblordemdeproducaostatus
                                SET Status=2
                        WHERE IdOrdemProducao=@IdOrdem", _getData, tran);


                var myCommandIgd = new SqlCommand(
                    @"UPDATE  dbo.tblordemproducao
                        SET     tblordemproducao.Situacao = 1 ,
                                tblordemproducao.DataConfirmacao = GETDATE()
                        WHERE   tblordemproducao.Id = @IdOrdem", _getIgdData, tranIgd);

                var serie =  "OP" + idOrdem + "-" + DateTime.Now.Date.ToString("dd/MM/yyyy");
                var mySerieCommand = new SqlCommand(
                    @"INSERT  INTO dbo.tblprodutosserie
                                ( Inativo ,
                                    IdProduto ,
                                    Empresa ,
                                    Serie ,
                                    Estoque ,
                                    EstoqueTransito 
                                )
                        VALUES  ( 0 , -- Inativo - bit
                                    @IdProduto , -- IdProduto - int
                                    1 , -- Empresa - int
                                    @Serie , -- Serie - varchar(30)
                                    @Estoque , -- Estoque - numeric
                                    0  -- EstoqueTransito - numeric
                                );", _getIgdData, tranIgd);
                
                var pSerie = new SqlParameter("@Serie", SqlDbType.VarChar)
                {
                    Value = serie
                };

                var pIdProduto = new SqlParameter("@IdProduto", SqlDbType.Int)
                {
                    Value = idProduto
                };

                var pEstoque = new SqlParameter("@Estoque", SqlDbType.Decimal)
                {
                    Value = quantidade
                };

                mySerieCommand.Parameters.Add(pSerie);
                mySerieCommand.Parameters.Add(pIdProduto);
                mySerieCommand.Parameters.Add(pEstoque);
                mySerieCommand.ExecuteNonQuery();

                var serieCommand = new SqlCommand($@"SELECT [tblprodutosserie].[Id] 
                                            FROM tblprodutosserie 
                                            WHERE [tblprodutosserie].[IdProduto]= {idProduto}
                                                    AND [tblprodutosserie].[Serie]='{serie}'", _getIgdData, tranIgd);
                var idSerie = Convert.ToInt32(serieCommand.ExecuteScalar());
                var idProdutoMovimento = Convert.ToInt32(
                    new SqlCommand($@"SELECT  [tblordemproducaoprodutos].[IdProdutoMovimento]
                                                        FROM    [dbo].[tblordemproducaoprodutos]
                                                        WHERE   [tblordemproducaoprodutos].[IdOP] = {idOrdem}",
                            _getIgdData, tranIgd)
                        .ExecuteScalar());

                var query = $@"INSERT  INTO [dbo].[tblprodutosmovimentoserie]
                                        ( [IdProdutoMovimento] ,
                                            [IdSerie] ,
                                            [Quantidade]
                                        )
                                VALUES  ( {idProdutoMovimento} ,
                                            {idSerie} ,
                                            @Quantidade 
                                        )";

                var produtoMovimentoSerieCommand = new SqlCommand(query, _getIgdData, tranIgd);
                produtoMovimentoSerieCommand.Parameters.AddWithValue("@Quantidade", quantidade);

                produtoMovimentoSerieCommand.ExecuteNonQuery();


                var myEstoqueCommand = new SqlCommand(
                    @"UPDATE  dbo.tblprodutosestoque
                    SET     tblprodutosestoque.Estoque = tblprodutosestoque.Estoque + @Estoque
                    WHERE   tblprodutosestoque.Empresa = 1
                            AND tblprodutosestoque.IdProduto = @IdProduto", _getIgdData, tranIgd);


                var myComandProces = new SqlCommand(@"INSERT  INTO dbo.tblordemproducaoprocessos
                                                            ( IdOP, IdProcesso, Tempo )
                                                    VALUES  ( @IdOP, @IdProcesso, @Tempo )", _getData, tran);

                
                var pIdProduto2 = new SqlParameter("@IdProduto", SqlDbType.Int)
                {
                    Value = idProduto
                };
                
                var pEstoque2 = new SqlParameter("@Estoque", SqlDbType.Decimal)
                {
                    Value = quantidade
                };
                var pIdOrdem = new SqlParameter("@IdOrdem", SqlDbType.Int)
                {
                    Value = idOrdem
                };
                var pIdOrdem2 = new SqlParameter("@IdOrdem", SqlDbType.Int)
                {
                    Value = idOrdem
                };


                var pIdOrdem4 = new SqlParameter("@IdOP", SqlDbType.Int)
                {
                    Value = idOrdem
                };


                myCommand.Parameters.Add(pIdOrdem);
                myCommandIgd.Parameters.Add(pIdOrdem2);
                
                myEstoqueCommand.Parameters.Add(pIdProduto2);
                myEstoqueCommand.Parameters.Add(pEstoque2);


                foreach (var processProduction in processos)
                {
                    var pIdProcesso = new SqlParameter("@IdProcesso", SqlDbType.Int)
                    {
                        Value = processProduction.Id
                    };
                    var pTempoProcesso = new SqlParameter("@Tempo", SqlDbType.Int)
                    {
                        Value = processProduction.TempoUtilizado
                    };

                    myComandProces.Parameters.Add(pIdOrdem4);
                    myComandProces.Parameters.Add(pIdProcesso);
                    myComandProces.Parameters.Add(pTempoProcesso);

                    myComandProces.ExecuteNonQuery();

                    myComandProces.Parameters.RemoveAt(2);
                    myComandProces.Parameters.RemoveAt(1);
                    myComandProces.Parameters.RemoveAt(0);
                }

                myCommand.ExecuteNonQuery();
                myCommandIgd.ExecuteNonQuery();
                
                myEstoqueCommand.ExecuteNonQuery();

                tran.Commit();
                tranIgd.Commit();

                return new DevDiveReturn {Message = "Ordem encerrada com sucesso!"};
            }
            catch (Exception ex)
            {
                tran.Rollback();
                tranIgd.Rollback();

                return new DevDiveReturn
                {
                    Errors = new List<string> {ex.Message + "\r\n" + ex.InnerException},
                    Message = "Falha ao salvar processo!"
                };
            }
            finally
            {
                _getData?.Close();
                _getIgdData?.Close();
            }
        }

        public BindingList<Requisitions> GetRequisitions()
        {
            try
            {
                _getIgdData.Open();

                var returnList = new BindingList<Requisitions>();

                using (
                    var myCommand =
                        new SqlCommand(
                            @"SELECT  tblrequisicaodemateriais.Id ,
                                    CASE WHEN tblrequisicaodemateriais.Devolucao = 1 THEN 'Devolução'
                                            ELSE 'Requisição'
                                    END AS Tipo ,
                                    tblrequisicaodemateriais.Data ,
                                    tblpessoas.Nome ,
                                    tblrequisicaodemateriais.Observacao
                            FROM    dbo.tblrequisicaodemateriais
                                    INNER JOIN tblpessoas ON tblpessoas.Id = tblrequisicaodemateriais.IdFuncionario
                            WHERE   tblrequisicaodemateriais.Situacao = 9", _getIgdData)
                )
                {
                    var myReader = myCommand.ExecuteReader();

                    while (myReader.Read())
                        returnList.Add(new Requisitions
                        {
                            Id = Convert.ToInt32(myReader["Id"]),
                            Data = Convert.ToDateTime(myReader["Data"]),
                            Usuario = myReader["Nome"].ToString(),
                            Observacao = myReader["Observacao"].ToString(),
                            Tipo = myReader["Tipo"].ToString()
                        });
                }

                return returnList;
            }
            catch (Exception ex)
            {
                _getIgdData.Close();
            }
            finally
            {
                _getIgdData.Close();
            }
            return null;
        }

        public IEnumerable<Product> getProductsRequisition(int idRequisicao)
        {
            try
            {
                _getIgdData.Open();

                var returnList = new BindingList<Product>();

                using (
                    var myCommand =
                        new SqlCommand(
                            @"SELECT  tblprodutos.Id ,
                                        tblprodutos.Codigo ,
                                        tblprodutos.Descricao ,
                                        CASE WHEN tblrequisicaodemateriais.Devolucao=1 then tblprodutosmovimento.Quantidade*-1
                                        ELSE tblprodutosmovimento.Quantidade END AS Quantidade
                                FROM    dbo.tblrequisicaodemateriaisprodutos
		                                INNER JOIN dbo.tblrequisicaodemateriais ON tblrequisicaodemateriais.Id = tblrequisicaodemateriaisprodutos.IdRequisicao
                                        INNER JOIN dbo.tblprodutosmovimento ON tblprodutosmovimento.Id = tblrequisicaodemateriaisprodutos.IdProdutoMovimento
                                        INNER JOIN tblprodutos ON tblprodutos.Id = tblprodutosmovimento.IdProduto
                                WHERE   tblrequisicaodemateriaisprodutos.IdRequisicao =@IdProduto", _getIgdData)
                )
                {
                    var pIdProduto = new SqlParameter("@IdProduto", SqlDbType.Int)
                    {
                        Value = idRequisicao
                    };

                    myCommand.Parameters.Add(pIdProduto);

                    var myReader = myCommand.ExecuteReader();

                    while (myReader.Read())
                        returnList.Add(new Product
                        {
                            Id = Convert.ToInt32(myReader["Id"]),
                            Codigo = myReader["Codigo"].ToString(),
                            Descricao = myReader["Descricao"].ToString(),
                            Quantidade = Convert.ToDecimal(myReader["Quantidade"])
                        });
                }

                return returnList;
            }
            catch (Exception ex)
            {
                _getIgdData.Close();
            }
            finally
            {
                _getIgdData.Close();
            }
            return null;
        }

        public BindingList<Product> GetProductsRequisitionsOrder(int ordemProducao,
            out BindingList<int> requisicoesSelecionadas)
        {
            requisicoesSelecionadas = new BindingList<int>();
            try
            {
                _getIgdData.Open();

                var returnList = new BindingList<Product>();

                using (
                    var myCommand =
                        new SqlCommand(
                            @"SELECT  tblprodutos.Id,
                                    tblprodutos.Codigo ,
                                    tblprodutos.Descricao ,
                                    CASE WHEN tblrequisicaodemateriais.Devolucao = 1
                                         THEN tblprodutosmovimento.Quantidade * -1
                                         ELSE tblprodutosmovimento.Quantidade
                                    END AS Quantidade,
                                    tblrequisicaodemateriais.Id AS IdRequisicao
                            FROM    dbo.tblordemproducao
                                    INNER JOIN [DevDive.Yerbalatina].dbo.tblordemdeproducaorequisicoes ON tblordemdeproducaorequisicoes.IdOrdemProducao = tblordemproducao.Id
                                    INNER JOIN dbo.tblrequisicaodemateriais ON tblrequisicaodemateriais.Id = tblordemdeproducaorequisicoes.IdRequisicaoDeMateriais
                                    INNER JOIN dbo.tblrequisicaodemateriaisprodutos ON tblrequisicaodemateriaisprodutos.IdRequisicao = tblrequisicaodemateriais.Id
                                    INNER JOIN dbo.tblprodutosmovimento ON tblprodutosmovimento.Id = tblrequisicaodemateriaisprodutos.IdProdutoMovimento
                                    INNER JOIN dbo.tblprodutos ON tblprodutos.Id = tblprodutosmovimento.IdProduto
                            WHERE   tblordemproducao.Id =@OrdemProducao", _getIgdData)
                )
                {
                    var pIdProduto = new SqlParameter("@OrdemProducao", SqlDbType.Int)
                    {
                        Value = ordemProducao
                    };

                    myCommand.Parameters.Add(pIdProduto);

                    var myReader = myCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        returnList.Add(new Product
                        {
                            Id = Convert.ToInt32(myReader["Id"]),
                            Codigo = myReader["Codigo"].ToString(),
                            Descricao = myReader["Descricao"].ToString(),
                            Quantidade = Convert.ToDecimal(myReader["Quantidade"])
                        });

                        var idRequisicao = Convert.ToInt32(myReader["IdRequisicao"]);

                        if (requisicoesSelecionadas.All(p => p != idRequisicao))
                            requisicoesSelecionadas.Add(idRequisicao);
                    }
                }

                return returnList;
            }
            catch (Exception ex)
            {
                _getIgdData.Close();
            }
            finally
            {
                _getIgdData.Close();
            }

            return null;
        }

        public DevDiveReturn CreateProductionOrder(int idPedido)
        {
            try
            {
                _getData.Open();


                using (
                    var myCommand =
                        new SqlCommand(
                            @"EXEC procedure_CreateOrderProduction @IdPedido", _getData)
                )
                {
                    var pIdProduto = new SqlParameter("@IdPedido", SqlDbType.Int)
                    {
                        Value = idPedido
                    };

                    myCommand.Parameters.Add(pIdProduto);

                    myCommand.ExecuteReader();
                }

                return new DevDiveReturn {Message = "Ordem de produção criada com sucesso !"};
            }
            catch (Exception ex)
            {
                _getData.Close();
            }
            finally
            {
                _getData.Close();
            }
            return null;
        }

        public BindingList<Orders> GetListOrders()
        {
            try
            {
                _getIgdData.Open();

                var returnList = new BindingList<Orders>();

                using (
                    var myCommand =
                        new SqlCommand(
                            @"SELECT TOP 50 tblpedidodevenda.Id AS IdPedido ,
                                tblpedidodevenda.DataEntrega ,
                                tblprodutos.Codigo ,
                                tblprodutos.Descricao ,
                                tblordemproducaopedidos.IdOrdemProducao,
		                        tblnotasfiscais.Numero AS NumeroNF,
		                        tblnotasfiscais.Situacao
                        FROM    dbo.tblpedidodevenda
                                INNER JOIN dbo.tblpedidodevendaprodutos ON tblpedidodevendaprodutos.IdPedidoVenda = tblpedidodevenda.Id
                                INNER JOIN dbo.tblprodutosmovimento ON tblprodutosmovimento.Id = tblpedidodevendaprodutos.IdProdutoMovimento
                                INNER JOIN dbo.tblprodutos ON tblprodutos.Id = tblprodutosmovimento.IdProduto
                                LEFT JOIN dbo.tblordemproducaopedidos ON tblordemproducaopedidos.IdPedidoVenda = tblpedidodevenda.Id
		                        LEFT JOIN dbo.tblnotasfiscaispedidos ON tblnotasfiscaispedidos.IdPedido = tblpedidodevenda.Id
		                        LEFT JOIN dbo.tblnotasfiscais ON tblnotasfiscais.Id = tblnotasfiscaispedidos.IdNF
                        ORDER BY IdPedido DESC", _getIgdData)
                )
                {
                    var myReader = myCommand.ExecuteReader();

                    while (myReader.Read())
                        returnList.Add(new Orders
                        {
                            IdPedido = Convert.ToInt32(myReader["IdPedido"]),
                            Codigo = myReader["Codigo"].ToString(),
                            Descricao = myReader["Descricao"].ToString(),
                            DataEntrega = Convert.ToDateTime(myReader["DataEntrega"]),
                            IdOrdemProducao = myReader["IdOrdemProducao"] as int?,
                            NumeroNF = myReader["NumeroNF"].ToString(),
                            Situacao = myReader["Situacao"].ToString()
                        });
                }

                return returnList;
            }
            catch (Exception ex)
            {
                _getIgdData.Close();
            }
            finally
            {
                _getIgdData.Close();
            }
            return null;
        }

        public DevDiveReturn SaveOrder(int idOrdem, BindingList<int> requisicoesSelecionadas,
            BindingList<ProcessProduction> processos)
        {
            _getData.Open();
            var tran = _getData.BeginTransaction();
            try
            {
                var myDelReq = new SqlCommand(
                    @"DELETE  FROM dbo.tblordemdeproducaorequisicoes
                        WHERE   tblordemdeproducaorequisicoes.IdOrdemProducao = @IdOrdem", _getData, tran);

                var pIdOrdem2 = new SqlParameter("@IdOrdem", SqlDbType.Int)
                {
                    Value = idOrdem
                };

                myDelReq.Parameters.Add(pIdOrdem2);

                myDelReq.ExecuteNonQuery();

                var myReqCommand = new SqlCommand(
                    @"INSERT  INTO [DevDive.Yerbalatina].[dbo].[tblordemdeproducaorequisicoes]
                            ( [IdOrdemProducao] ,
                              [IdRequisicaoDeMateriais]
                            )
                    VALUES  ( @IdOrdem ,
                              @IdRequisicao
                            );", _getData, tran);

                var pIdOrdem3 = new SqlParameter("@IdOrdem", SqlDbType.Int)
                {
                    Value = idOrdem
                };


                foreach (var requisicao in requisicoesSelecionadas)
                {
                    var pIdRequisicao = new SqlParameter("@IdRequisicao", SqlDbType.Int)
                    {
                        Value = requisicao
                    };

                    myReqCommand.Parameters.Add(pIdOrdem3);
                    myReqCommand.Parameters.Add(pIdRequisicao);

                    myReqCommand.ExecuteNonQuery();

                    myReqCommand.Parameters.RemoveAt(1);

                    myReqCommand.Parameters.RemoveAt(0);
                }

                var myDelprocess = new SqlCommand(
                    @"DELETE  FROM dbo.tblordemproducaoprocessos
                        WHERE   tblordemproducaoprocessos.IdOP = @IdOrdem", _getData, tran);

                var pIdOrdem4 = new SqlParameter("@IdOrdem", SqlDbType.Int)
                {
                    Value = idOrdem
                };

                myDelprocess.Parameters.Add(pIdOrdem4);

                myDelprocess.ExecuteNonQuery();

                var myProcessCommand = new SqlCommand(
                    @"INSERT INTO dbo.tblordemproducaoprocessos
                            ( IdOP, IdProcesso, Tempo )
                    VALUES  ( @IdOrdem,
                              @IdProcesso,
                              @TempoProcesso)", _getData, tran);

                var pIdOrdem5 = new SqlParameter("@IdOrdem", SqlDbType.Int)
                {
                    Value = idOrdem
                };

                foreach (var processo in processos)
                {
                    var pIdProcesso = new SqlParameter("@IdProcesso", SqlDbType.Int)
                    {
                        Value = processo.Id
                    };

                    var pTempoProcesso = new SqlParameter("@TempoProcesso", SqlDbType.Decimal)
                    {
                        Value = processo.TempoUtilizado ?? 0
                    };

                    myProcessCommand.Parameters.Add(pIdOrdem5);
                    myProcessCommand.Parameters.Add(pIdProcesso);
                    myProcessCommand.Parameters.Add(pTempoProcesso);

                    myProcessCommand.ExecuteNonQuery();

                    myProcessCommand.Parameters.RemoveAt(2);
                    myProcessCommand.Parameters.RemoveAt(1);
                    myProcessCommand.Parameters.RemoveAt(0);
                }


                tran.Commit();


                return new DevDiveReturn {Message = "Ordem salva com sucesso!"};
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
                _getData?.Close();
            }
        }
    }
}