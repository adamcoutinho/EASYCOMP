//
// <copyright file="TipoDestino_TO.cs" company="Valeverde Turismo">
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
internal class TipoDestino_DAO
{
internal List<TipoDestino_TO> SearchAll(string pCondicao)
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

string sql = " SELECT * FROM vcrm_tipo_destino ";

List<TipoDestino_TO> collection = new List<TipoDestino_TO>();
try
{
command = new SqlCommand(sql, connection);
reader = command.ExecuteReader();

while (reader.Read())
{
TipoDestino_TO TipoDestinoTO = new TipoDestino_TO();
TipoDestinoTO.tde_codigo = Convert.ToInt32(reader["tde_codigo"]);
TipoDestinoTO.tde_nome = Convert.ToString(reader["tde_nome"]);
TipoDestinoTO.tde_descricao = Convert.ToString(reader["tde_descricao"]);
TipoDestinoTO.tde_e_cidade = Convert.ToInt32(reader["tde_e_cidade"]);
collection.Add(TipoDestinoTO);}
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

internal TipoDestino_TO GetByCode(TipoDestino_TO pTO){
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

string sql = " SELECT * FROM vcrm_tipo_destino ";
try
{
command = new SqlCommand(sql, connection);

reader = command.ExecuteReader();

if (reader.Read())
{
pTO.tde_codigo = Convert.ToInt32(reader["tde_codigo"]);
pTO.tde_nome = Convert.ToString(reader["tde_nome"]);
pTO.tde_descricao = Convert.ToString(reader["tde_descricao"]);
pTO.tde_e_cidade = Convert.ToInt32(reader["tde_e_cidade"]);
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

internal bool Save(TipoDestino_TO pTO)
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

string sql = "INSERT INTO vcrm_tipo_destino" +
" ( tde_codigo " +
", tde_nome " +
", tde_descricao " +
", tde_e_cidade) " +
"VALUES " +
"( @tde_codigo " +
" , @tde_nome " +
" , @tde_descricao " +
" , @tde_e_cidade ) ";

try
{
command = new SqlCommand(sql, connection);
command.Parameters.AddWithValue("@tde_codigo", pTO.tde_codigo);
command.Parameters.AddWithValue("@tde_nome", pTO.tde_nome);
command.Parameters.AddWithValue("@tde_descricao", pTO.tde_descricao);
command.Parameters.AddWithValue("@tde_e_cidade", pTO.tde_e_cidade);
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

internal bool Update(TipoDestino_TO pTO)
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

string sql = "UPDATE vcrm_tipo_destino" +
" SET tde_codigo = @tde_codigo " +
" , tde_nome = @tde_nome " +
" , tde_descricao = @tde_descricao " +
" , tde_e_cidade = @tde_e_cidade " +
"WHERE ... ";
try
{
command = new SqlCommand(sql, connection);
command.Parameters.AddWithValue("@tde_codigo", pTO.tde_codigo);
command.Parameters.AddWithValue("@tde_nome", pTO.tde_nome);
command.Parameters.AddWithValue("@tde_descricao", pTO.tde_descricao);
command.Parameters.AddWithValue("@tde_e_cidade", pTO.tde_e_cidade);
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

internal bool Delete(TipoDestino_TO pTO)
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

string sql = "DELETE FROM vcrm_tipo_destino" +
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
