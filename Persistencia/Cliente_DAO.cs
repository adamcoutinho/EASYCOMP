//
// <copyright file="Cliente_TO.cs" company="Valeverde Turismo">
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
internal class Cliente_DAO
{
internal List<Cliente_TO> SearchAll(string pCondicao)
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

string sql = " SELECT * FROM vcrm_cliente ";

List<Cliente_TO> collection = new List<Cliente_TO>();
try
{
command = new SqlCommand(sql, connection);
reader = command.ExecuteReader();

while (reader.Read())
{
Cliente_TO ClienteTO = new Cliente_TO();
ClienteTO.cli_codigo = Convert.ToInt32(reader["cli_codigo"]);
ClienteTO.cli_nome = Convert.ToString(reader["cli_nome"]);
ClienteTO.cli_email = Convert.ToString(reader["cli_email"]);
ClienteTO.cli_celular = Convert.ToString(reader["cli_celular"]);
ClienteTO.cli_lead = Convert.ToInt32(reader["cli_lead"]);
ClienteTO.cli_logradouro = Convert.ToString(reader["cli_logradouro"]);
ClienteTO.cli_numero = Convert.ToInt32(reader["cli_numero"]);
ClienteTO.CidadeTO = new Cidade_TO();
ClienteTO.CidadeTO.cid_codigo = Convert.ToInt32(reader["cid_codigo"]);
ClienteTO.cli_codstur = Convert.ToInt32(reader["cli_codstur"]);
ClienteTO.cli_telefone = Convert.ToString(reader["cli_telefone"]);
collection.Add(ClienteTO);}
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

internal Cliente_TO GetByCode(Cliente_TO pTO){
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

string sql = " SELECT * FROM vcrm_cliente ";
try
{
command = new SqlCommand(sql, connection);

reader = command.ExecuteReader();

if (reader.Read())
{
pTO.cli_codigo = Convert.ToInt32(reader["cli_codigo"]);
pTO.cli_nome = Convert.ToString(reader["cli_nome"]);
pTO.cli_email = Convert.ToString(reader["cli_email"]);
pTO.cli_celular = Convert.ToString(reader["cli_celular"]);
pTO.cli_lead = Convert.ToInt32(reader["cli_lead"]);
pTO.cli_logradouro = Convert.ToString(reader["cli_logradouro"]);
pTO.cli_numero = Convert.ToInt32(reader["cli_numero"]);
pTO.CidadeTO = new Cidade_TO();
pTO.CidadeTO.cid_codigo = Convert.ToInt32(reader["cid_codigo"]);
pTO.cli_codstur = Convert.ToInt32(reader["cli_codstur"]);
pTO.cli_telefone = Convert.ToString(reader["cli_telefone"]);
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

internal bool Save(Cliente_TO pTO)
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

string sql = "INSERT INTO vcrm_cliente" +
" ( cli_codigo " +
", cli_nome " +
", cli_email " +
", cli_celular " +
", cli_lead " +
", cli_logradouro " +
", cli_numero " +
", cid_codigo " +
", cli_codstur " +
", cli_telefone) " +
"VALUES " +
"( @cli_codigo " +
" , @cli_nome " +
" , @cli_email " +
" , @cli_celular " +
" , @cli_lead " +
" , @cli_logradouro " +
" , @cli_numero " +
" , @cid_codigo " +
" , @cli_codstur " +
" , @cli_telefone ) ";

try
{
command = new SqlCommand(sql, connection);
command.Parameters.AddWithValue("@cli_codigo", pTO.cli_codigo);
command.Parameters.AddWithValue("@cli_nome", pTO.cli_nome);
command.Parameters.AddWithValue("@cli_email", pTO.cli_email);
command.Parameters.AddWithValue("@cli_celular", pTO.cli_celular);
command.Parameters.AddWithValue("@cli_lead", pTO.cli_lead);
command.Parameters.AddWithValue("@cli_logradouro", pTO.cli_logradouro);
command.Parameters.AddWithValue("@cli_numero", pTO.cli_numero);
command.Parameters.AddWithValue("@cid_codigo", pTO.CidadeTO.cid_codigo);
command.Parameters.AddWithValue("@cli_codstur", pTO.cli_codstur);
command.Parameters.AddWithValue("@cli_telefone", pTO.cli_telefone);
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

internal bool Update(Cliente_TO pTO)
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

string sql = "UPDATE vcrm_cliente" +
" SET cli_codigo = @cli_codigo " +
" , cli_nome = @cli_nome " +
" , cli_email = @cli_email " +
" , cli_celular = @cli_celular " +
" , cli_lead = @cli_lead " +
" , cli_logradouro = @cli_logradouro " +
" , cli_numero = @cli_numero " +
" , cid_codigo = @cid_codigo " +
" , cli_codstur = @cli_codstur " +
" , cli_telefone = @cli_telefone " +
"WHERE ... ";
try
{
command = new SqlCommand(sql, connection);
command.Parameters.AddWithValue("@cli_codigo", pTO.cli_codigo);
command.Parameters.AddWithValue("@cli_nome", pTO.cli_nome);
command.Parameters.AddWithValue("@cli_email", pTO.cli_email);
command.Parameters.AddWithValue("@cli_celular", pTO.cli_celular);
command.Parameters.AddWithValue("@cli_lead", pTO.cli_lead);
command.Parameters.AddWithValue("@cli_logradouro", pTO.cli_logradouro);
command.Parameters.AddWithValue("@cli_numero", pTO.cli_numero);
command.Parameters.AddWithValue("@cid_codigo", pTO.CidadeTO.cid_codigo);
command.Parameters.AddWithValue("@cli_codstur", pTO.cli_codstur);
command.Parameters.AddWithValue("@cli_telefone", pTO.cli_telefone);
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

internal bool Delete(Cliente_TO pTO)
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

string sql = "DELETE FROM vcrm_cliente" +
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
