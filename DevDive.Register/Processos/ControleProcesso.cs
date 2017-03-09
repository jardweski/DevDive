using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using DevDive.Common;

namespace DevDive.Register.Processos
{
    public class ControleProcesso
    {
        private readonly SqlConnection _conn;

        public ControleProcesso(SqlConnection getData)
        {
            _conn = getData;
        }

        public DevDiveReturn Save(Processo processo)
        {
            _conn.Open();
            var tran = _conn.BeginTransaction();
            try
            {
                if (processo.Id == null)
                {
                    var myCommand = new SqlCommand(@"INSERT INTO tblprocessos (Descricao, Custo) 
                                     Values (@Descricao,@Custo)", _conn, tran);

                    var pDescricao = new SqlParameter("@Descricao", SqlDbType.Text)
                    {
                        Value = processo.Descricao
                    };
                    var pCusto = new SqlParameter("@Custo", SqlDbType.Decimal) {Value = processo.Custo};

                    myCommand.Parameters.Add(pDescricao);
                    myCommand.Parameters.Add(pCusto);

                    myCommand.ExecuteNonQuery();

                    tran.Commit();
                }
                else
                {
                    var myCommand =
                        new SqlCommand(@"UPDATE tblprocessos SET Descricao=@Descricao, Custo=@Custo WHERE Id=@Id", _conn,
                            tran);

                    var pDescricao = new SqlParameter("@Descricao", SqlDbType.Text)
                    {
                        Value = processo.Descricao
                    };
                    var pCusto = new SqlParameter("@Custo", SqlDbType.Decimal) {Value = processo.Custo};
                    var pId = new SqlParameter("@Id", SqlDbType.Int) {Value = processo.Id};

                    myCommand.Parameters.Add(pDescricao);
                    myCommand.Parameters.Add(pCusto);
                    myCommand.Parameters.Add(pId);

                    myCommand.ExecuteNonQuery();

                    tran.Commit();
                }

                return new DevDiveReturn {Message = "Processo salvo com sucesso!"};
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

        public DevDiveReturn Delete(Processo processo)
        {
            _conn.Open();
            var tran = _conn.BeginTransaction();
            try
            {
                if (processo.Id == null)
                {
                    return new DevDiveReturn
                    {
                        Message = "Falha ao excluir processo!",
                        Errors = new List<string> {"processo.Id==null"}
                    };
                }
                else
                {
                    var myCommand = new SqlCommand(@"UPDATE tblprocessos SET Excluido=1 WHERE Id=@Id", _conn, tran);

                    var pId = new SqlParameter("@Id", SqlDbType.Int) {Value = processo.Id};

                    myCommand.Parameters.Add(pId);

                    myCommand.ExecuteNonQuery();

                    tran.Commit();
                }

                return new DevDiveReturn {Message = "Processo excluído com sucesso!"};
            }
            catch (Exception ex)
            {
                tran.Rollback();

                return new DevDiveReturn
                {
                    Errors = new List<string> {ex.Message + "\r\n" + ex.InnerException},
                    Message = "Falha ao excluir processo!"
                };
            }
            finally
            {
                _conn?.Close();
            }
        }

        public BindingList<Processo> GetList()
        {
            try
            {
                _conn.Open();

                var returnList = new BindingList<Processo>();

                using (
                    var myCommand = new SqlCommand("SELECT * FROM tblprocessos WHERE Excluido IS NULL OR Excluido=0",
                        _conn)
                    )
                {
                    var myReader = myCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        returnList.Add(new Processo
                        {
                            Id = Convert.ToInt32(myReader["Id"]),
                            Descricao = myReader["Descricao"].ToString(),
                            Custo = Convert.ToDecimal(myReader["Custo"])
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
    }
}