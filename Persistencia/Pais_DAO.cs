//
// <copyright file="Pais_TO.cs" company="Valeverde Turismo">
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
internal class Pais_DAO
{
internal List<Pais_TO> SearchAll(string pCondicao)
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

string sql = " SELECT * FROM vcrm_pais ";

List<Pais_TO> collection = new List<Pais_TO>();
try
{
command = new SqlCommand(sql, connection);
reader = command.ExecuteReader();

while (reader.Read())
{
Pais_TO PaisTO = new Pais_TO();
PaisTO.pai_codigo = Convert.ToInt32(reader["pai_codigo"]);
PaisTO.pai_nome = Convert.ToString(reader["pai_nome"]);
PaisTO.pai_continente = Convert.ToString(reader["pai_continente"]);
collection.Add(PaisTO);}
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

internal Pais_TO GetByCode(Pais_TO pTO){
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

string sql = " SELECT * FROM vcrm_pais ";
try
{
command = new SqlCommand(sql, connection);

reader = command.ExecuteReader();

if (reader.Read())
{
pTO.pai_codigo = Convert.ToInt32(reader["pai_codigo"]);
pTO.pai_nome = Convert.ToString(reader["pai_nome"]);
pTO.pai_continente = Convert.ToString(reader["pai_continente"]);
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

internal bool Save(Pais_TO pTO)
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

string sql = "INSERT INTO vcrm_pais" +
" ( pai_codigo " +
", pai_nome " +
", pai_continente) " +
"VALUES " +
"( @pai_codigo " +
" , @pai_nome " +
" , @pai_continente ) ";

try
{
command = new SqlCommand(sql, connection);
command.Parameters.AddWithValue("@pai_codigo", pTO.pai_codigo);
command.Parameters.AddWithValue("@pai_nome", pTO.pai_nome);
command.Parameters.AddWithValue("@pai_continente", pTO.pai_continente);
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

internal bool Update(Pais_TO pTO)
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

string sql = "UPDATE vcrm_pais" +
" SET pai_codigo = @pai_codigo " +
" , pai_nome = @pai_nome " +
" , pai_continente = @pai_continente " +
"WHERE ... ";
try
{
command = new SqlCommand(sql, connection);
command.Parameters.AddWithValue("@pai_codigo", pTO.pai_codigo);
command.Parameters.AddWithValue("@pai_nome", pTO.pai_nome);
command.Parameters.AddWithValue("@pai_continente", pTO.pai_continente);
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

internal bool Delete(Pais_TO pTO)
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

string sql = "DELETE FROM vcrm_pais" +
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
