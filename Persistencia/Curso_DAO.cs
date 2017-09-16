//
// <copyright file="Curso_TO.cs" company="Valeverde Turismo">
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
    internal class Curso_DAO
    {
        internal List<Curso_TO> SearchAll(string pCondicao)
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

            string sql = " SELECT * FROM curso ";

            List<Curso_TO> collection = new List<Curso_TO>();
            try
            {
                command = new SqlCommand(sql, connection);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Curso_TO CursoTO = new Curso_TO();
                    CursoTO.cur_codigo = Convert.ToInt32(reader["cur_codigo"]);
                    CursoTO.cur_nome = Convert.ToString(reader["cur_nome"]);
                    CursoTO.cur_descricao = Convert.ToString(reader["cur_descricao"]);
                    CursoTO.cur_duracao = Convert.ToInt32(reader["cur_duracao"]);
                    collection.Add(CursoTO);
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

        internal Curso_TO GetByCode(Curso_TO pTO)
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

            string sql = " SELECT * FROM curso " +
            "WHERE  cur_codigo = @cur_codigo ";
            try
            {
                command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@cur_codigo", pTO.cur_codigo);
                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    pTO.cur_codigo = Convert.ToInt32(reader["cur_codigo"]);
                    pTO.cur_nome = Convert.ToString(reader["cur_nome"]);
                    pTO.cur_descricao = Convert.ToString(reader["cur_descricao"]);
                    pTO.cur_duracao = Convert.ToInt32(reader["cur_duracao"]);
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

        internal bool Save(Curso_TO pTO)
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

            string sql = "INSERT INTO curso" +
            "( cur_nome " +
            ", cur_descricao " +
            ", cur_duracao) " +
            "VALUES " +
            "(  @cur_nome " +
            " , @cur_descricao " +
            " , @cur_duracao ) ";

            try
            {
                command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@cur_nome", pTO.cur_nome);
                command.Parameters.AddWithValue("@cur_descricao", pTO.cur_descricao);
                command.Parameters.AddWithValue("@cur_duracao", pTO.cur_duracao);
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

        internal bool Update(Curso_TO pTO)
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

            string sql = "UPDATE curso" +
            " SET cur_nome = @cur_nome " +
              " , cur_descricao = @cur_descricao " +
              " , cur_duracao = @cur_duracao " +
            "WHERE  cur_codigo = @cur_codigo ";
            try
            {
                command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@cur_codigo", pTO.cur_codigo);
                command.Parameters.AddWithValue("@cur_nome", pTO.cur_nome);
                command.Parameters.AddWithValue("@cur_descricao", pTO.cur_descricao);
                command.Parameters.AddWithValue("@cur_duracao", pTO.cur_duracao);
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

        internal bool Delete(Curso_TO pTO)
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

            string sql = "DELETE FROM curso WHERE  cur_codigo = @cur_codigo ";
            try
            {
                command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@cur_codigo", pTO.cur_codigo);
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
