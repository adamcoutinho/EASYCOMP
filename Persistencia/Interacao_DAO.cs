//
// <copyright file="Interacao_TO.cs" company="Valeverde Turismo">
//     Copyright (c) Valeverde Turismo 2017. All rights reserved.
// </copyright>
// <author>Cândido</author>
// <date>11/08/2017</date>
//
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Persistencia.crm
{
internal class Interacao_DAO
{
internal List<Interacao_TO> SearchAll(string pCondicao)
{
SqlConnection connection = null;
try
{
connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConn"].ConnectionString);
connection.Open();
}
catch (Exception)
{
throw;
}

SqlCommand command = null;
SqlDataReader reader = null;

string sql = " SELECT * FROM vcrm_interacao ";

List<Interacao_TO> collection = new List<Interacao_TO>();
try
{
command = new SqlCommand(sql, connection);
reader = command.ExecuteReader();

while (reader.Read())
{
Interacao_TO InteracaoTO = new Interacao_TO();
InteracaoTO.int_codigo = Convert.ToInt32(reader["int_codigo"]);
InteracaoTO.int_data_hora = Convert.ToDateTime(reader["int_data_hora"]);
InteracaoTO.CanalTO = new Canal_TO();
InteracaoTO.CanalTO.can_codigo = Convert.ToInt32(reader["can_codigo"]);
InteracaoTO.ConsultorTO = new Consultor_TO();
InteracaoTO.ConsultorTO.con_codigo = Convert.ToInt32(reader["con_codigo"]);
InteracaoTO.AtendimentoTO = new Atendimento_TO();
InteracaoTO.AtendimentoTO.atd_codigo = Convert.ToInt32(reader["atd_codigo"]);
InteracaoTO.int_conteudo = (reader["int_conteudo"]);
collection.Add(InteracaoTO);}
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

internal Interacao_TO GetByCode(Interacao_TO pTO){
SqlConnection connection = null;
try
{
connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConn"].ConnectionString);
connection.Open();
}
catch (Exception)
{
throw;
}
SqlCommand command = null;
SqlDataReader reader = null;

string sql = " SELECT * FROM vcrm_interacao ";
try
{
command = new SqlCommand(sql, connection);

reader = command.ExecuteReader();

if (reader.Read())
{
pTO.int_codigo = Convert.ToInt32(reader["int_codigo"]);
pTO.int_data_hora = Convert.ToDateTime(reader["int_data_hora"]);
pTO.CanalTO = new Canal_TO();
pTO.CanalTO.can_codigo = Convert.ToInt32(reader["can_codigo"]);
pTO.ConsultorTO = new Consultor_TO();
pTO.ConsultorTO.con_codigo = Convert.ToInt32(reader["con_codigo"]);
pTO.AtendimentoTO = new Atendimento_TO();
pTO.AtendimentoTO.atd_codigo = Convert.ToInt32(reader["atd_codigo"]);
pTO.int_conteudo = (reader["int_conteudo"]);
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

internal bool Save(Interacao_TO pTO)
{
SqlConnection connection = null;
try
{
connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConn"].ConnectionString);
connection.Open();
}
catch (Exception)
{
throw;
}

SqlCommand command = null;
bool retorno = false;

string sql = "INSERT INTO vcrm_interacao" +
" ( int_codigo " +
", int_data_hora " +
", can_codigo " +
", con_codigo " +
", atd_codigo " +
", int_conteudo) " +
"VALUES " +
"( @int_codigo " +
" , @int_data_hora " +
" , @can_codigo " +
" , @con_codigo " +
" , @atd_codigo " +
" , @int_conteudo ) ";

try
{
command = new SqlCommand(sql, connection);
command.Parameters.AddWithValue("@int_codigo", pTO.int_codigo);
command.Parameters.AddWithValue("@int_data_hora", pTO.int_data_hora);
command.Parameters.AddWithValue("@can_codigo", pTO.CanalTO.can_codigo);
command.Parameters.AddWithValue("@con_codigo", pTO.ConsultorTO.con_codigo);
command.Parameters.AddWithValue("@atd_codigo", pTO.AtendimentoTO.atd_codigo);
command.Parameters.AddWithValue("@int_conteudo", pTO.int_conteudo);
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

internal bool Update(Interacao_TO pTO)
{
SqlConnection connection = null;
try
{
connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConn"].ConnectionString);
connection.Open();
}
catch (Exception)
{
throw;
}

SqlCommand command = null;
bool retorno = false;

string sql = "UPDATE vcrm_interacao" +
" SET int_codigo = @int_codigo " +
" , int_data_hora = @int_data_hora " +
" , can_codigo = @can_codigo " +
" , con_codigo = @con_codigo " +
" , atd_codigo = @atd_codigo " +
" , int_conteudo = @int_conteudo " +
"WHERE ... ";
try
{
command = new SqlCommand(sql, connection);
command.Parameters.AddWithValue("@int_codigo", pTO.int_codigo);
command.Parameters.AddWithValue("@int_data_hora", pTO.int_data_hora);
command.Parameters.AddWithValue("@can_codigo", pTO.CanalTO.can_codigo);
command.Parameters.AddWithValue("@con_codigo", pTO.ConsultorTO.con_codigo);
command.Parameters.AddWithValue("@atd_codigo", pTO.AtendimentoTO.atd_codigo);
command.Parameters.AddWithValue("@int_conteudo", pTO.int_conteudo);
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

internal bool Delete(Interacao_TO pTO)
{
SqlConnection connection = null;
try
{
connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConn"].ConnectionString);
connection.Open();
}
catch (Exception)
{
throw;
}

SqlCommand command = null;
bool retorno = false;

string sql = "DELETE FROM vcrm_interacao" +
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

}
}
