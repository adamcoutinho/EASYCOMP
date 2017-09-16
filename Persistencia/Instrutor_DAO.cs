//
// <copyright file="Instrutor_TO.cs" company="Valeverde Turismo">
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
    internal class Instrutor_DAO
    {
        internal List<Instrutor_TO> SearchAll(string pCondicao)
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

            string sql = " SELECT * FROM instrutor ";

            List<Instrutor_TO> collection = new List<Instrutor_TO>();
            try
            {
                command = new SqlCommand(sql, connection);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Instrutor_TO InstrutorTO = new Instrutor_TO();
                    InstrutorTO.ins_codigo = Convert.ToInt32(reader["ins_codigo"]);
                    InstrutorTO.ins_rg = Convert.ToInt32(reader["ins_rg"]);
                    InstrutorTO.ins_nome = Convert.ToString(reader["ins_nome"]);
                    InstrutorTO.ins_descricao = Convert.ToString(reader["ins_descricao"]);
                    InstrutorTO.ins_data_nascimento = Convert.ToDateTime(reader["ins_data_nascimento"]);
                    InstrutorTO.ins_email = Convert.ToString(reader["ins_email"]);
                    InstrutorTO.ins_telefone = Convert.ToInt32(reader["ins_telefone"]);
                    collection.Add(InstrutorTO);
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

        internal Instrutor_TO GetByCode(Instrutor_TO pTO)
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

            string sql = " SELECT * FROM instrutor " +
            "WHERE  ins_codigo = @ins_codigo ";
            try
            {
                command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@ins_codigo", pTO.ins_codigo);
                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    pTO.ins_codigo = Convert.ToInt32(reader["ins_codigo"]);
                    pTO.ins_rg = Convert.ToInt32(reader["ins_rg"]);
                    pTO.ins_nome = Convert.ToString(reader["ins_nome"]);
                    pTO.ins_descricao = Convert.ToString(reader["ins_descricao"]);
                    pTO.ins_data_nascimento = Convert.ToDateTime(reader["ins_data_nascimento"]);
                    pTO.ins_email = Convert.ToString(reader["ins_email"]);
                    pTO.ins_telefone = Convert.ToInt32(reader["ins_telefone"]);
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

        internal bool Save(Instrutor_TO pTO)
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

            string sql = "INSERT INTO instrutor" +
            "( ins_rg " +
            ", ins_nome " +
            ", ins_descricao " +
            ", ins_data_nascimento " +
            ", ins_email " +
            ", ins_telefone) " +
            "VALUES " +
            "(  @ins_rg " +
            " , @ins_nome " +
            " , @ins_descricao " +
            " , @ins_data_nascimento " +
            " , @ins_email " +
            " , @ins_telefone ) ";

            try
            {
                command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@ins_rg", pTO.ins_rg);
                command.Parameters.AddWithValue("@ins_nome", pTO.ins_nome);
                command.Parameters.AddWithValue("@ins_descricao", pTO.ins_descricao);
                command.Parameters.AddWithValue("@ins_data_nascimento", pTO.ins_data_nascimento);
                command.Parameters.AddWithValue("@ins_email", pTO.ins_email);
                command.Parameters.AddWithValue("@ins_telefone", pTO.ins_telefone);
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

        internal bool Update(Instrutor_TO pTO)
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

            string sql = "UPDATE instrutor" +
            " SET ins_rg = @ins_rg " +
              " , ins_nome = @ins_nome " +
              " , ins_descricao = @ins_descricao " +
              " , ins_data_nascimento = @ins_data_nascimento " +
              " , ins_email = @ins_email " +
              " , ins_telefone = @ins_telefone " +
            " WHERE  ins_codigo = @ins_codigo ";
            try
            {
                command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@ins_codigo", pTO.ins_codigo);
                command.Parameters.AddWithValue("@ins_rg", pTO.ins_rg);
                command.Parameters.AddWithValue("@ins_nome", pTO.ins_nome);
                command.Parameters.AddWithValue("@ins_descricao", pTO.ins_descricao);
                command.Parameters.AddWithValue("@ins_data_nascimento", pTO.ins_data_nascimento);
                command.Parameters.AddWithValue("@ins_email", pTO.ins_email);
                command.Parameters.AddWithValue("@ins_telefone", pTO.ins_telefone);
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

        internal bool Delete(Instrutor_TO pTO)
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

            string sql = "DELETE FROM instrutor WHERE ins_codigo = @ins_codigo ";
            try
            {
                command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@ins_codigo", pTO.ins_codigo);
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
