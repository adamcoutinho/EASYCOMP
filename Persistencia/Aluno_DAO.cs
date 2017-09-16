/
// <copyright file="Aluno_TO.cs" company="Valeverde Turismo">
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
    internal class Aluno_DAO
    {
        internal List<Aluno_TO> SearchAll(string pCondicao)
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

            string sql = " SELECT * FROM aluno ";

            List<Aluno_TO> collection = new List<Aluno_TO>();
            try
            {
                command = new SqlCommand(sql, connection);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Aluno_TO AlunoTO = new Aluno_TO();
                    AlunoTO.alu_codigo = Convert.ToInt32(reader["alu_codigo"]);
                    AlunoTO.alu_nome = Convert.ToString(reader["alu_nome"]);
                    AlunoTO.alu_telefone = Convert.ToInt32(reader["alu_telefone"]);
                    AlunoTO.alu_email = Convert.ToString(reader["alu_email"]);
                    AlunoTO.alu_data_nascimento = Convert.ToDateTime(reader["alu_data_nascimento"]);
                    AlunoTO.alu_endereco = Convert.ToString(reader["alu_endereco"]);
                    AlunoTO.alu_bairro = Convert.ToString(reader["alu_bairro"]);
                    AlunoTO.alu_cpf = Convert.ToString(reader["alu_cpf"]);
                    collection.Add(AlunoTO);
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

        internal Aluno_TO GetByCode(Aluno_TO pTO)
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

            string sql = " SELECT * FROM aluno " +
            "WHERE  alu_codigo = @alu_codigo ";
            try
            {
                command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@alu_codigo", pTO.alu_codigo);
                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    pTO.alu_codigo = Convert.ToInt32(reader["alu_codigo"]);
                    pTO.alu_nome = Convert.ToString(reader["alu_nome"]);
                    pTO.alu_telefone = Convert.ToInt32(reader["alu_telefone"]);
                    pTO.alu_email = Convert.ToString(reader["alu_email"]);
                    pTO.alu_data_nascimento = Convert.ToDateTime(reader["alu_data_nascimento"]);
                    pTO.alu_endereco = Convert.ToString(reader["alu_endereco"]);
                    pTO.alu_bairro = Convert.ToString(reader["alu_bairro"]);
                    pTO.alu_cpf = Convert.ToString(reader["alu_cpf"]);
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

        internal bool Save(Aluno_TO pTO)
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

            string sql = "INSERT INTO aluno" +
            "( alu_nome " +
            ", alu_telefone " +
            ", alu_email " +
            ", alu_data_nascimento " +
            ", alu_endereco " +
            ", alu_bairro " +
            ", alu_cpf) " +
            "VALUES " +
            "( @alu_nome " +
            " , @alu_telefone " +
            " , @alu_email " +
            " , @alu_data_nascimento " +
            " , @alu_endereco " +
            " , @alu_bairro " +
            " , @alu_cpf ) ";

            try
            {
                command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@alu_nome", pTO.alu_nome);
                command.Parameters.AddWithValue("@alu_telefone", pTO.alu_telefone);
                command.Parameters.AddWithValue("@alu_email", pTO.alu_email);
                command.Parameters.AddWithValue("@alu_data_nascimento", pTO.alu_data_nascimento);
                command.Parameters.AddWithValue("@alu_endereco", pTO.alu_endereco);
                command.Parameters.AddWithValue("@alu_bairro", pTO.alu_bairro);
                command.Parameters.AddWithValue("@alu_cpf", pTO.alu_cpf);
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

        internal bool Update(Aluno_TO pTO)
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

            string sql = "UPDATE aluno" +
            " SET alu_nome = @alu_nome " +
            " , alu_telefone = @alu_telefone " +
            " , alu_email = @alu_email " +
            " , alu_data_nascimento = @alu_data_nascimento " +
            " , alu_endereco = @alu_endereco " +
            " , alu_bairro = @alu_bairro " +
            " , alu_cpf = @alu_cpf " +
            "WHERE  alu_codigo = @alu_codigo ";
            try
            {
                command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@alu_codigo", pTO.alu_codigo);
                command.Parameters.AddWithValue("@alu_nome", pTO.alu_nome);
                command.Parameters.AddWithValue("@alu_telefone", pTO.alu_telefone);
                command.Parameters.AddWithValue("@alu_email", pTO.alu_email);
                command.Parameters.AddWithValue("@alu_data_nascimento", pTO.alu_data_nascimento);
                command.Parameters.AddWithValue("@alu_endereco", pTO.alu_endereco);
                command.Parameters.AddWithValue("@alu_bairro", pTO.alu_bairro);
                command.Parameters.AddWithValue("@alu_cpf", pTO.alu_cpf);
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

        internal bool Delete(Aluno_TO pTO)
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

            string sql = "DELETE FROM aluno WHERE alu_codigo = @alu_codigo ";
            try
            {
                command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@alu_codigo", pTO.alu_codigo);
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
