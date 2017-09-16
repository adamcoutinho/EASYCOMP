//
// <copyright file="Destino_TO.cs" company="Valeverde Turismo">
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
internal class Destino_DAO
{
internal List<Destino_TO> SearchAll(string pCondicao)
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

string sql = " SELECT * FROM vcrm_destino ";

List<Destino_TO> collection = new List<Destino_TO>();
try
{
command = new SqlCommand(sql, connection);
reader = command.ExecuteReader();

while (reader.Read())
{
Destino_TO DestinoTO = new Destino_TO();
DestinoTO.des_codigo = Convert.ToInt32(reader["des_codigo"]);
DestinoTO.des_nome = Convert.ToString(reader["des_nome"]);
DestinoTO.TipoDestinoTO = new TipoDestino_TO();
DestinoTO.TipoDestinoTO.tde_codigo = Convert.ToInt32(reader["tde_codigo"]);
DestinoTO.CidadeTO = new Cidade_TO();
DestinoTO.CidadeTO.cid_codigo = Convert.ToInt32(reader["cid_codigo"]);
collection.Add(DestinoTO);}
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

internal Destino_TO GetByCode(Destino_TO pTO){
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

string sql = " SELECT * FROM vcrm_destino ";
try
{
command = new SqlCommand(sql, connection);

reader = command.ExecuteReader();

if (reader.Read())
{
pTO.des_codigo = Convert.ToInt32(reader["des_codigo"]);
pTO.des_nome = Convert.ToString(reader["des_nome"]);
pTO.TipoDestinoTO = new TipoDestino_TO();
pTO.TipoDestinoTO.tde_codigo = Convert.ToInt32(reader["tde_codigo"]);
pTO.CidadeTO = new Cidade_TO();
pTO.CidadeTO.cid_codigo = Convert.ToInt32(reader["cid_codigo"]);
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

internal bool Save(Destino_TO pTO)
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

string sql = "INSERT INTO vcrm_destino" +
" ( des_codigo " +
", des_nome " +
", tde_codigo " +
", cid_codigo) " +
"VALUES " +
"( @des_codigo " +
" , @des_nome " +
" , @tde_codigo " +
" , @cid_codigo ) ";

try
{
command = new SqlCommand(sql, connection);
command.Parameters.AddWithValue("@des_codigo", pTO.des_codigo);
command.Parameters.AddWithValue("@des_nome", pTO.des_nome);
command.Parameters.AddWithValue("@tde_codigo", pTO.TipoDestinoTO.tde_codigo);
command.Parameters.AddWithValue("@cid_codigo", pTO.CidadeTO.cid_codigo);
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

internal bool Update(Destino_TO pTO)
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

string sql = "UPDATE vcrm_destino" +
" SET des_codigo = @des_codigo " +
" , des_nome = @des_nome " +
" , tde_codigo = @tde_codigo " +
" , cid_codigo = @cid_codigo " +
"WHERE ... ";
try
{
command = new SqlCommand(sql, connection);
command.Parameters.AddWithValue("@des_codigo", pTO.des_codigo);
command.Parameters.AddWithValue("@des_nome", pTO.des_nome);
command.Parameters.AddWithValue("@tde_codigo", pTO.TipoDestinoTO.tde_codigo);
command.Parameters.AddWithValue("@cid_codigo", pTO.CidadeTO.cid_codigo);
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

internal bool Delete(Destino_TO pTO)
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

string sql = "DELETE FROM vcrm_destino" +
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
