//
// <copyright file="Matricula_TO.cs" company="Valeverde Turismo">
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
    internal class Matricula_DAO
    {
        internal List<Matricula_TO> SearchAll(string pCondicao)
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

            string sql = "SELECT mat_codigo " +
                             ",turma.tur_nome " + 
                             ",aluno.alu_nome " +
                             ",mat_data_matricula " +
                        "FROM matricula " +
                        "INNER JOIN aluno ON " + 
                             "aluno.alu_codigo = matricula.alu_codigo " +
                        "INNER JOIN turma ON " + 
                             "turma.tur_codigo = matricula.tur_codigo " +
                        "WHERE mat_codigo > 0 " + pCondicao;

            List<Matricula_TO> collection = new List<Matricula_TO>();
            try
            {
                command = new SqlCommand(sql, connection);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Matricula_TO MatriculaTO = new Matricula_TO();
                    MatriculaTO.mat_codigo = Convert.ToInt32(reader["mat_codigo"]);
                    MatriculaTO.TurmaTO = new Turma_TO();
                    MatriculaTO.TurmaTO.tur_nome = Convert.ToString(reader["tur_nome"]);
                    MatriculaTO.AlunoTO = new Aluno_TO();
                    MatriculaTO.AlunoTO.alu_nome = Convert.ToString(reader["alu_nome"]);
                    MatriculaTO.mat_data_matricula = Convert.ToDateTime(reader["mat_data_matricula"]);
                    collection.Add(MatriculaTO);
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

        internal Matricula_TO GetByCode(Matricula_TO pTO)
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

            string sql = "SELECT MAT_CODIGO " +
	                     "   , MAT_DATA_MATRICULA " +
	                     "   , TUR.TUR_CODIGO " +
	                     "   , TUR_NOME " +
	                     "   , ALU.ALU_CODIGO " +
	                     "   , ALU_NOME " +
	                     "   , CUR.CUR_CODIGO " +
	                     "   , CUR_NOME " +
                        "FROM MATRICULA MAT INNER JOIN " +
	                    "TURMA TUR ON TUR.TUR_CODIGO = MAT.TUR_CODIGO INNER JOIN " +
	                    "ALUNO ALU ON ALU.ALU_CODIGO = MAT.ALU_CODIGO INNER JOIN " +
	                    "CURSO CUR ON CUR.CUR_CODIGO = TUR.CUR_CODIGO ";
            try
            {
                command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@mat_codigo", pTO.mat_codigo);
                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    pTO.mat_codigo = Convert.ToInt32(reader["mat_codigo"]);
                    pTO.TurmaTO = new Turma_TO();
                    pTO.TurmaTO.tur_codigo = Convert.ToInt32(reader["tur_codigo"]);
                    pTO.AlunoTO = new Aluno_TO();
                    pTO.AlunoTO.alu_codigo = Convert.ToInt32(reader["alu_codigo"]);
                    pTO.TurmaTO.CursoTO = new Curso_TO();
                    pTO.TurmaTO.CursoTO.cur_codigo = Convert.ToInt32(reader["cur_codigo"]);
                    pTO.mat_data_matricula = Convert.ToDateTime(reader["mat_data_matricula"]);
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

        internal bool Save(Matricula_TO pTO)
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

            string sql = "INSERT INTO matricula" +
            "( tur_codigo " +
            ", alu_codigo " +
            ", mat_data_matricula) " +
            "VALUES " +
            "(  @tur_codigo " +
            " , @alu_codigo " +
            " , @mat_data_matricula ) ";

            try
            {
                command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@mat_codigo", pTO.mat_codigo);
                command.Parameters.AddWithValue("@tur_codigo", pTO.TurmaTO.tur_codigo);
                command.Parameters.AddWithValue("@alu_codigo", pTO.AlunoTO.alu_codigo);
                command.Parameters.AddWithValue("@mat_data_matricula", pTO.mat_data_matricula);
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

        internal bool Update(Matricula_TO pTO)
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

            string sql = "UPDATE matricula" +
            " SET tur_codigo = @tur_codigo " +
            " , alu_codigo = @alu_codigo " +
            " , mat_data_matricula = @mat_data_matricula " +
            "WHERE  mat_codigo = @mat_codigo ";
            try
            {
                command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@mat_codigo", pTO.mat_codigo);
                command.Parameters.AddWithValue("@tur_codigo", pTO.TurmaTO.tur_codigo);
                command.Parameters.AddWithValue("@alu_codigo", pTO.AlunoTO.alu_codigo);
                command.Parameters.AddWithValue("@mat_data_matricula", pTO.mat_data_matricula);
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

        internal bool Delete(Matricula_TO pTO)
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

            string sql = "DELETE FROM matricula WHERE  mat_codigo = @mat_codigo ";
            try
            {
                command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@mat_codigo", pTO.mat_codigo);
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
