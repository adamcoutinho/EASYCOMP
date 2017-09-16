//
// <copyright file="Cidade_TO.cs" company="Valeverde Turismo">
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
internal class Cidade_DAO
{
internal List<Cidade_TO> SearchAll(string pCondicao)
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

string sql = " SELECT * FROM vcrm_cidade ";

List<Cidade_TO> collection = new List<Cidade_TO>();
try
{
command = new SqlCommand(sql, connection);
reader = command.ExecuteReader();

while (reader.Read())
{
Cidade_TO CidadeTO = new Cidade_TO();
CidadeTO.cid_codigo = Convert.ToInt32(reader["cid_codigo"]);
CidadeTO.cid_nome = Convert.ToString(reader["cid_nome"]);
CidadeTO.cid_estado = Convert.ToString(reader["cid_estado"]);
CidadeTO.cid_ddd = Convert.ToInt32(reader["cid_ddd"]);
CidadeTO.PaisTO = new Pais_TO();
CidadeTO.PaisTO.pai_codigo = Convert.ToInt32(reader["pai_codigo"]);
collection.Add(CidadeTO);}
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

internal Cidade_TO GetByCode(Cidade_TO pTO){
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

string sql = " SELECT * FROM vcrm_cidade ";
try
{
command = new SqlCommand(sql, connection);

reader = command.ExecuteReader();

if (reader.Read())
{
pTO.cid_codigo = Convert.ToInt32(reader["cid_codigo"]);
pTO.cid_nome = Convert.ToString(reader["cid_nome"]);
pTO.cid_estado = Convert.ToString(reader["cid_estado"]);
pTO.cid_ddd = Convert.ToInt32(reader["cid_ddd"]);
pTO.PaisTO = new Pais_TO();
pTO.PaisTO.pai_codigo = Convert.ToInt32(reader["pai_codigo"]);
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

internal bool Save(Cidade_TO pTO)
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

string sql = "INSERT INTO vcrm_cidade" +
" ( cid_codigo " +
", cid_nome " +
", cid_estado " +
", cid_ddd " +
", pai_codigo) " +
"VALUES " +
"( @cid_codigo " +
" , @cid_nome " +
" , @cid_estado " +
" , @cid_ddd " +
" , @pai_codigo ) ";

try
{
command = new SqlCommand(sql, connection);
command.Parameters.AddWithValue("@cid_codigo", pTO.cid_codigo);
command.Parameters.AddWithValue("@cid_nome", pTO.cid_nome);
command.Parameters.AddWithValue("@cid_estado", pTO.cid_estado);
command.Parameters.AddWithValue("@cid_ddd", pTO.cid_ddd);
command.Parameters.AddWithValue("@pai_codigo", pTO.PaisTO.pai_codigo);
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

internal bool Update(Cidade_TO pTO)
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

string sql = "UPDATE vcrm_cidade" +
" SET cid_codigo = @cid_codigo " +
" , cid_nome = @cid_nome " +
" , cid_estado = @cid_estado " +
" , cid_ddd = @cid_ddd " +
" , pai_codigo = @pai_codigo " +
"WHERE ... ";
try
{
command = new SqlCommand(sql, connection);
command.Parameters.AddWithValue("@cid_codigo", pTO.cid_codigo);
command.Parameters.AddWithValue("@cid_nome", pTO.cid_nome);
command.Parameters.AddWithValue("@cid_estado", pTO.cid_estado);
command.Parameters.AddWithValue("@cid_ddd", pTO.cid_ddd);
command.Parameters.AddWithValue("@pai_codigo", pTO.PaisTO.pai_codigo);
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

internal bool Delete(Cidade_TO pTO)
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

string sql = "DELETE FROM vcrm_cidade" +
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
