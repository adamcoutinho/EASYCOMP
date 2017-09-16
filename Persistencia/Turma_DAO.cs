//
// <copyright file="Turma_TO.cs" company="Valeverde Turismo">
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
    internal class Turma_DAO
    {
        internal List<Turma_TO> SearchAll(string pCondicao)
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

            string sql = " SELECT tur_codigo " +
                         ", tur_turno " +
                         ", tur_data_inicio " +
                         ", curso.cur_codigo " +
                         ", cur_nome " +
                         ", instrutor.ins_codigo " +
                         ", ins_nome " +
                         ", tur_vagas " +
                         ", tur_nome " +
                        " FROM turma inner join " + 
	                       " curso ON curso.cur_codigo = turma.cur_codigo " + 
                        " inner join " +
	                       " instrutor ON instrutor.ins_codigo = turma.ins_codigo " +
                        " WHERE tur_codigo > 0 " + pCondicao;

            List<Turma_TO> collection = new List<Turma_TO>();
            try
            {
                command = new SqlCommand(sql, connection);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Turma_TO TurmaTO = new Turma_TO();
                    TurmaTO.tur_codigo = Convert.ToInt32(reader["tur_codigo"]);
                    TurmaTO.tur_turno = Convert.ToString(reader["tur_turno"]);
                    TurmaTO.tur_data_inicio = Convert.ToDateTime(reader["tur_data_inicio"]);
                    //Objeto dentro de outro objeto
                    TurmaTO.CursoTO = new Curso_TO();
                    TurmaTO.CursoTO.cur_codigo = Convert.ToInt32(reader["cur_codigo"]);
                    TurmaTO.CursoTO.cur_nome = Convert.ToString(reader["cur_nome"]);
                    //Objeto dentro de outro objeto
                    TurmaTO.InstrutorTO = new Instrutor_TO();
                    TurmaTO.InstrutorTO.ins_codigo = Convert.ToInt32(reader["ins_codigo"]);
                    TurmaTO.InstrutorTO.ins_nome = Convert.ToString(reader["ins_nome"]);
                    TurmaTO.tur_vagas = Convert.ToInt32(reader["tur_vagas"]);
                    TurmaTO.tur_nome = Convert.ToString(reader["tur_nome"]);
                    collection.Add(TurmaTO);
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

        internal Turma_TO GetByCode(Turma_TO pTO)
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

            string sql = " SELECT * FROM turma " +
            "WHERE  tur_codigo = @tur_codigo ";
            try
            {
                command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@tur_codigo", pTO.tur_codigo);
                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    pTO.tur_codigo = Convert.ToInt32(reader["tur_codigo"]);
                    pTO.tur_turno = Convert.ToString(reader["tur_turno"]);
                    pTO.tur_data_inicio = Convert.ToDateTime(reader["tur_data_inicio"]);
                    pTO.CursoTO = new Curso_TO();
                    pTO.CursoTO.cur_codigo = Convert.ToInt32(reader["cur_codigo"]);
                    pTO.InstrutorTO = new Instrutor_TO();
                    pTO.InstrutorTO.ins_codigo = Convert.ToInt32(reader["ins_codigo"]);
                    pTO.tur_vagas = Convert.ToInt32(reader["tur_vagas"]);
                    pTO.tur_nome = Convert.ToString(reader["tur_nome"]);
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

        internal bool Save(Turma_TO pTO)
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

            string sql = "INSERT INTO turma" +
            "( tur_turno " +
            ", tur_data_inicio " +
            ", cur_codigo " +
            ", ins_codigo " +
            ", tur_vagas " +
            ", tur_nome )" +
            "VALUES " +
            " ( @tur_turno " +
            " , @tur_data_inicio " +
            " , @cur_codigo " +
            " , @ins_codigo " +
            " , @tur_vagas " +
            " , @tur_nome )";

            try
            {
                command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@tur_turno", pTO.tur_turno);
                command.Parameters.AddWithValue("@tur_data_inicio", pTO.tur_data_inicio);
                command.Parameters.AddWithValue("@cur_codigo", pTO.CursoTO.cur_codigo);
                command.Parameters.AddWithValue("@ins_codigo", pTO.InstrutorTO.ins_codigo);
                command.Parameters.AddWithValue("@tur_vagas", pTO.tur_vagas);
                command.Parameters.AddWithValue("@tur_nome", pTO.tur_nome);
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

        internal bool Update(Turma_TO pTO)
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

            string sql = "UPDATE turma" +
            " SET tur_turno = @tur_turno " +
            " , tur_data_inicio = @tur_data_inicio " +
            " , cur_codigo = @cur_codigo " +
            " , ins_codigo = @ins_codigo " +
            " , tur_vagas = @tur_vagas " +
            " , tur_nome = @tur_nome " +
            "WHERE  tur_codigo = @tur_codigo ";
            try
            {
                command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@tur_codigo", pTO.tur_codigo);
                command.Parameters.AddWithValue("@tur_turno", pTO.tur_turno);
                command.Parameters.AddWithValue("@tur_data_inicio", pTO.tur_data_inicio);
                command.Parameters.AddWithValue("@cur_codigo", pTO.CursoTO.cur_codigo);
                command.Parameters.AddWithValue("@ins_codigo", pTO.InstrutorTO.ins_codigo);
                command.Parameters.AddWithValue("@tur_vagas", pTO.tur_vagas);
                command.Parameters.AddWithValue("@tur_nome", pTO.tur_nome);
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

        internal bool Delete(Turma_TO pTO)
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

            string sql = "DELETE FROM turma WHERE  tur_codigo = @tur_codigo ";
            
            try
            {       
                command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@tur_codigo", pTO.tur_codigo);
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
