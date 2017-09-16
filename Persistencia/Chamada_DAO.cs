//
// <copyright file="Chamada_TO.cs" company="Valeverde Turismo">
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
    internal class Chamada_DAO
    {
        internal List<Chamada_TO> SearchAll(string pCondicao, Chamada_TO pTO)
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

            string sql = " SELECT m.mat_codigo " +
                                " ,alu_nome " +
                                " ,tp.tpr_codigo " +
                                " ,cha_presenca " +
                         " FROM chamada c INNER JOIN " +
                                " matricula m on m.mat_codigo = c.mat_codigo INNER JOIN " +
                                " aluno a on a.alu_codigo = m.alu_codigo INNER JOIN " +
                                " turma_programacao tp on tp.tpr_codigo = c.tpr_codigo INNER JOIN " +
                                " turma t on t.tur_codigo = tp.tur_codigo " +
                         " WHERE tpr_data_aula = CONVERT(DATE, GETDATE()) AND t.tur_codigo = @turma_codigo";

            List<Chamada_TO> collection = new List<Chamada_TO>();
            try
            {
                command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@turma_codigo", pTO.MatriculaTO.TurmaTO.tur_codigo);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Chamada_TO ChamadaTO = new Chamada_TO();
                    ChamadaTO.MatriculaTO = new Matricula_TO();
                    ChamadaTO.MatriculaTO.AlunoTO = new Aluno_TO();
                    ChamadaTO.TurmaProgramacaoTO = new TurmaProgramacao_TO();
                    ChamadaTO.MatriculaTO.mat_codigo = Convert.ToInt32(reader["mat_codigo"]);
                    ChamadaTO.MatriculaTO.AlunoTO.alu_nome = Convert.ToString(reader["alu_nome"]);
                    ChamadaTO.cha_presenca = Convert.ToInt32(reader["cha_presenca"]);
                    ChamadaTO.TurmaProgramacaoTO.tpr_codigo = Convert.ToInt16(reader["tpr_codigo"]);
                    
                    collection.Add(ChamadaTO);
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

        internal Chamada_TO GetByCode(Chamada_TO pTO)
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conn_bdvveasycomp"].ConnectionString);
                connection.Open();
            }
            catch (Exception)
            {
                throw;
            }
            SqlCommand command = null;
            SqlDataReader reader = null;

            string sql = " SELECT * FROM chamada ";
            try
            {
                command = new SqlCommand(sql, connection);

                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    pTO.MatriculaTO = new Matricula_TO();
                    pTO.MatriculaTO.mat_codigo = Convert.ToInt32(reader["mat_codigo"]);
                    pTO.TurmaProgramacaoTO = new TurmaProgramacao_TO();
                    pTO.TurmaProgramacaoTO.tpr_codigo = Convert.ToInt32(reader["tpr_codigo"]);
                    pTO.cha_presenca = Convert.ToInt32(reader["cha_presenca"]);
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

        internal bool Save(Chamada_TO pTO)
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

            string sql = "INSERT INTO chamada" +
            " ( mat_codigo " +
            ", tpr_codigo " +
            ", cha_presenca) " +
            "VALUES " +
            "( @mat_codigo " +
            " , @tpr_codigo " +
            " , @cha_presenca ) ";

            try
            {
                command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@mat_codigo", pTO.MatriculaTO.mat_codigo);
                command.Parameters.AddWithValue("@tpr_codigo", pTO.TurmaProgramacaoTO.tpr_codigo);
                command.Parameters.AddWithValue("@cha_presenca", pTO.cha_presenca);
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

        internal bool Update(Chamada_TO pTO)
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

            string sql = " UPDATE chamada " +
                         "  SET cha_presenca = @cha_presenca " +
                         " WHERE mat_codigo = @mat_codigo " + 
                         " AND tpr_codigo = @tpr_codigo ";
            try
            {
                command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@cha_presenca", pTO.cha_presenca);
                command.Parameters.AddWithValue("@mat_codigo", pTO.MatriculaTO.mat_codigo);
                command.Parameters.AddWithValue("@tpr_codigo", pTO.TurmaProgramacaoTO.tpr_codigo);
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

        internal bool Delete(Chamada_TO pTO)
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conn_bdvveasycomp"].ConnectionString);
                connection.Open();
            }
            catch (Exception)
            {
                throw;
            }

            SqlCommand command = null;
            bool retorno = false;

            string sql = "DELETE FROM chamada" +
            "WHERE ... ";
            try
            {
                command = new SqlCommand(sql, connection);

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

            string sql = "DELETE FROM chamada WHERE tpr_codigo = @tpr_codigo";
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
