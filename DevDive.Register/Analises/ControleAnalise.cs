using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using DevDive.Common;

namespace DevDive.Register.Analises
{
    public class ControleAnalise
    {
        private readonly SqlConnection _conn;

        public ControleAnalise(SqlConnection getData)
        {
            _conn = getData;
        }

        public DevDiveReturn Save(Analise analise)
        {
            _conn.Open();
            var tran = _conn.BeginTransaction();
            try
            {
                if (analise.Id == null)
                {
                    var myCommand = new SqlCommand(@"INSERT INTO tblAnalises (Descricao ,
                                                                              Tipo ,
                                                                              Especificacao ,
                                                                              Metodo) 
                                     Values (@Descricao,@Tipo,@Especificacao,@Metodo)", _conn, tran);

                    var pDescricao = new SqlParameter("@Descricao", SqlDbType.Text)
                    {
                        Value = analise.Descricao
                    };
                    var pTipo = new SqlParameter("@Tipo", SqlDbType.Int) {Value = (int) analise.Tipo};
                    var pEspecificacao = new SqlParameter("@Especificacao", SqlDbType.Text) {Value = analise.Especificacao};
                    var pMetodo = new SqlParameter("@Metodo", SqlDbType.Int) {Value = (int) analise.Metodo};

                    myCommand.Parameters.Add(pDescricao);
                    myCommand.Parameters.Add(pTipo);
                    myCommand.Parameters.Add(pEspecificacao);
                    myCommand.Parameters.Add(pMetodo);

                    myCommand.ExecuteNonQuery();

                    tran.Commit();
                }
                else
                {
                    var myCommand =
                        new SqlCommand(@"UPDATE tblAnalises SET Descricao=@Descricao, 
                                                                Tipo=@Tipo,
                                                                Especificacao=@Especificacao,
                                                                Metodo=@Metodo
                                                                WHERE Id=@Id", _conn,
                            tran);

                    var pDescricao = new SqlParameter("@Descricao", SqlDbType.Text)
                    {
                        Value = analise.Descricao
                    };
                    var pTipo = new SqlParameter("@Tipo", SqlDbType.Int) {Value = (int) analise.Tipo};
                    var pEspecificacao = new SqlParameter("@Especificacao", SqlDbType.Text) {Value = analise.Especificacao};
                    var pMetodo = new SqlParameter("@Metodo", SqlDbType.Int) {Value = (int) analise.Metodo};
                    var pId = new SqlParameter("@Id", SqlDbType.Int) {Value = analise.Id};

                    myCommand.Parameters.Add(pDescricao);
                    myCommand.Parameters.Add(pTipo);
                    myCommand.Parameters.Add(pEspecificacao);
                    myCommand.Parameters.Add(pMetodo);
                    myCommand.Parameters.Add(pId);

                    myCommand.ExecuteNonQuery();

                    tran.Commit();
                }

                return new DevDiveReturn {Message = "Análise salva com sucesso!"};
            }
            catch (Exception ex)
            {
                tran.Rollback();

                return new DevDiveReturn
                {
                    Errors = new List<string> {ex.Message + "\r\n" + ex.InnerException},
                    Message = "Falha ao salvar Análise!"
                };
            }
            finally
            {
                _conn?.Close();
            }
        }

        public DevDiveReturn Delete(Analise analise)
        {
            _conn.Open();
            var tran = _conn.BeginTransaction();
            try
            {
                if (analise.Id == null)
                {
                    return new DevDiveReturn
                    {
                        Message = "Falha ao excluir Analise!",
                        Errors = new List<string> {"Analise.Id==null"}
                    };
                }
                else
                {
                    var myCommand = new SqlCommand(@"UPDATE tblAnalises SET Excluido=1 WHERE Id=@Id", _conn, tran);

                    var pId = new SqlParameter("@Id", SqlDbType.Int) {Value = analise.Id};

                    myCommand.Parameters.Add(pId);

                    myCommand.ExecuteNonQuery();

                    tran.Commit();
                }

                return new DevDiveReturn {Message = "Analise excluído com sucesso!"};
            }
            catch (Exception ex)
            {
                tran.Rollback();

                return new DevDiveReturn
                {
                    Errors = new List<string> {ex.Message + "\r\n" + ex.InnerException},
                    Message = "Falha ao excluir Analise!"
                };
            }
            finally
            {
                _conn?.Close();
            }
        }

        public BindingList<Analise> GetList()
        {
            try
            {
                _conn.Open();

                var returnList = new BindingList<Analise>();

                using (
                    var myCommand = new SqlCommand("SELECT * FROM tblAnalises WHERE Excluido IS NULL OR Excluido=0",
                        _conn)
                )
                {
                    var myReader = myCommand.ExecuteReader();

                    while (myReader.Read())
                        returnList.Add(new Analise
                        {
                            Id = Convert.ToInt32(myReader["Id"]),
                            Descricao = myReader["Descricao"].ToString(),
                            Especificacao = myReader["Especificacao"].ToString(),
                            Tipo = (ETipoAnalise) Convert.ToInt32(myReader["Tipo"]),
                            Metodo = (EMetodoAnalise) Convert.ToInt32(myReader["Metodo"])
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
    }
}