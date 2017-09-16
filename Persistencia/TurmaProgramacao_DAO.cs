//
// <copyright file="TurmaProgramacao_TO.cs" company="Valeverde Turismo">
//     Copyright (c) Valeverde Turismo 2017. All rights reserved.
// </copyright>
// <author>Wilson Montelo</author>
// <date>09/08/2017</date>
//
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Persistencia
{
    internal class TurmaProgramacao_DAO
    {
        internal List<TurmaProgramacao_TO> SearchAll(string pCondicao)
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(ConfigurationSettings.AppSettings["conn_bdvveasycomp"]);
                connection.Open();
            }
            catch (Exception)
            {
                throw;
            }

            SqlCommand command = null;
            SqlDataReader reader = null;

            string sql = "SELECT tpr_codigo " +
	                     "    ,tpr_data_aula " +
	                     "    ,tpr_horas_inicial " +
	                     "    ,tpr_horas_final " +
	                     "    ,tur_nome " +
	                     "    ,cur_nome " +
                        "FROM  turma_programacao " + 
                        "INNER JOIN turma ON turma.tur_codigo = turma_programacao.tur_codigo " + 
                        "INNER JOIN curso ON curso.cur_codigo = turma.cur_codigo ";

            List<TurmaProgramacao_TO> collection = new List<TurmaProgramacao_TO>();
            try
            {
                command = new SqlCommand(sql, connection);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    TurmaProgramacao_TO TurmaProgramacaoTO = new TurmaProgramacao_TO();
                    TurmaProgramacaoTO.tpr_codigo = Convert.ToInt32(reader["tpr_codigo"]);
                    TurmaProgramacaoTO.tpr_data_aula = Convert.ToDateTime(reader["tpr_data_aula"]);
                    TurmaProgramacaoTO.tpr_horas_inicial = Convert.ToString(reader["tpr_horas_inicial"]);
                    TurmaProgramacaoTO.tpr_horas_final = Convert.ToString(reader["tpr_horas_final"]);
                    TurmaProgramacaoTO.TurmaTO = new Turma_TO();
                    //TurmaProgramacaoTO.TurmaTO.tur_codigo = Convert.ToInt32(reader["tur_codigo"]);
                    TurmaProgramacaoTO.TurmaTO.tur_nome = Convert.ToString(reader["tur_nome"]);
                    TurmaProgramacaoTO.TurmaTO.CursoTO = new Curso_TO();
                    TurmaProgramacaoTO.TurmaTO.CursoTO.cur_nome = Convert.ToString(reader["cur_nome"]);
                    collection.Add(TurmaProgramacaoTO);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                reader.Close();
                command.Dispose();
                connection.Close();
                connection.Dispose();
            }
            return collection;
        }

        internal TurmaProgramacao_TO GetByCode(TurmaProgramacao_TO pTO)
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(ConfigurationSettings.AppSettings["conn_bdvveasycomp"]);
                connection.Open();
            }
            catch (Exception)
            {
                throw;
            }
            SqlCommand command = null;
            SqlDataReader reader = null;

            string sql = " SELECT * FROM turma_programacao " +
            "WHERE  tpr_codigo = @tpr_codigo ";
            try
            {
                command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@tpr_codigo", pTO.tpr_codigo);
                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    pTO.tpr_codigo = Convert.ToInt32(reader["tpr_codigo"]);
                    pTO.tpr_data_aula = Convert.ToDateTime(reader["tpr_data_aula"]);
                    pTO.tpr_horas_inicial = Convert.ToString(reader["tpr_horas_inicial"]);
                    pTO.tpr_horas_final = Convert.ToString(reader["tpr_horas_final"]);
                    pTO.TurmaTO = new Turma_TO();
                    pTO.TurmaTO.tur_codigo = Convert.ToInt32(reader["tur_codigo"]);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                reader.Close();
                command.Dispose();
                connection.Close();
                connection.Dispose();
            }

            return pTO;
        }

        internal bool Save(TurmaProgramacao_TO pTO)
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(ConfigurationSettings.AppSettings["conn_bdvveasycomp"]);
                connection.Open();
            }
            catch (Exception)
            {
                throw;
            }

            SqlCommand command = null;
            SqlDataReader reader = null;
            bool retorno = false;

            string sql = "INSERT INTO turma_programacao" +
            "( tpr_data_aula " +
            ", tpr_horas_inicial " +
            ", tpr_horas_final " +
            ", tur_codigo) " +
            "VALUES " +
            "(  @tpr_data_aula " +
            " , @tpr_horas_inicial " +
            " , @tpr_horas_final " +
            " , @tur_codigo ) " +
            "SELECT @@IDENTITY AS tpr_codigo";

            try
            {
                command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@tpr_data_aula", pTO.tpr_data_aula);
                //command.Parameters.AddWithValue("@tpr_codigo", pTO.tpr_codigo);
                command.Parameters.AddWithValue("@tpr_horas_inicial", pTO.tpr_horas_inicial);
                command.Parameters.AddWithValue("@tpr_horas_final", pTO.tpr_horas_final);
                command.Parameters.AddWithValue("@tur_codigo", pTO.TurmaTO.tur_codigo);
                
                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    pTO.tpr_codigo = Convert.ToInt32(reader["tpr_codigo"]);
                    retorno = true;   
                }                
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                command.Dispose();
                connection.Close();
                connection.Dispose();
            }

            return retorno;
        }

        internal bool Update(TurmaProgramacao_TO pTO)
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(ConfigurationSettings.AppSettings["conn_bdvveasycomp"]);
                connection.Open();
            }
            catch (Exception)
            {
                throw;
            }

            SqlCommand command = null;
            bool retorno = false;

            string sql = "UPDATE turma_programacao" +
            " SET tpr_data_aula = @tpr_data_aula " +
            " , tpr_horas_inicial = @tpr_horas_inicial " +
            " , tpr_horas_final = @tpr_horas_final " +
            " , tur_codigo = @tur_codigo " +
            "WHERE  tpr_codigo = @tpr_codigo ";
            try
            {
                command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@tpr_codigo", pTO.tpr_codigo);
                command.Parameters.AddWithValue("@tpr_data_aula", pTO.tpr_data_aula);
                command.Parameters.AddWithValue("@tpr_horas_inicial", pTO.tpr_horas_inicial);
                command.Parameters.AddWithValue("@tpr_horas_final", pTO.tpr_horas_final);
                command.Parameters.AddWithValue("@tur_codigo", pTO.TurmaTO.tur_codigo);
                command.ExecuteNonQuery();
                retorno = true;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                command.Dispose();
                connection.Close();
                connection.Dispose();
            }

            return retorno;
        }

        internal bool Delete(TurmaProgramacao_TO pTO)
        {
            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection(ConfigurationSettings.AppSettings["conn_bdvveasycomp"]);
                connection.Open();
            }
            catch (Exception)
            {
                throw;
            }

            SqlCommand command = null;
            bool retorno = false;

            string sql = "DELETE FROM turma_programacao WHERE tpr_codigo = @tpr_codigo ";
            try
            {
                command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@tpr_codigo", pTO.tpr_codigo);
                command.ExecuteNonQuery();
                retorno = true;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                command.Dispose();
                connection.Close();
                connection.Dispose();
            }

            return retorno;
        }

    }
}
