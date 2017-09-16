//
// <copyright file="Canal_TO.cs" company="Valeverde Turismo">
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
internal class Canal_DAO
{
internal List<Canal_TO> SearchAll(string pCondicao)
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

string sql = " SELECT * FROM vcrm_canal ";

List<Canal_TO> collection = new List<Canal_TO>();
try
{
command = new SqlCommand(sql, connection);
reader = command.ExecuteReader();

while (reader.Read())
{
Canal_TO CanalTO = new Canal_TO();
CanalTO.can_codigo = Convert.ToInt32(reader["can_codigo"]);
CanalTO.can_nome = Convert.ToString(reader["can_nome"]);
CanalTO.can_virtual = Convert.ToInt32(reader["can_virtual"]);
CanalTO.can_facebook = Convert.ToInt32(reader["can_facebook"]);
CanalTO.can_gmail = Convert.ToInt32(reader["can_gmail"]);
collection.Add(CanalTO);}
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

internal Canal_TO GetByCode(Canal_TO pTO){
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

string sql = " SELECT * FROM vcrm_canal ";
try
{
command = new SqlCommand(sql, connection);

reader = command.ExecuteReader();

if (reader.Read())
{
pTO.can_codigo = Convert.ToInt32(reader["can_codigo"]);
pTO.can_nome = Convert.ToString(reader["can_nome"]);
pTO.can_virtual = Convert.ToInt32(reader["can_virtual"]);
pTO.can_facebook = Convert.ToInt32(reader["can_facebook"]);
pTO.can_gmail = Convert.ToInt32(reader["can_gmail"]);
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

internal bool Save(Canal_TO pTO)
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

string sql = "INSERT INTO vcrm_canal" +
" ( can_codigo " +
", can_nome " +
", can_virtual " +
", can_facebook " +
", can_gmail) " +
"VALUES " +
"( @can_codigo " +
" , @can_nome " +
" , @can_virtual " +
" , @can_facebook " +
" , @can_gmail ) ";

try
{
command = new SqlCommand(sql, connection);
command.Parameters.AddWithValue("@can_codigo", pTO.can_codigo);
command.Parameters.AddWithValue("@can_nome", pTO.can_nome);
command.Parameters.AddWithValue("@can_virtual", pTO.can_virtual);
command.Parameters.AddWithValue("@can_facebook", pTO.can_facebook);
command.Parameters.AddWithValue("@can_gmail", pTO.can_gmail);
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

internal bool Update(Canal_TO pTO)
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

string sql = "UPDATE vcrm_canal" +
" SET can_codigo = @can_codigo " +
" , can_nome = @can_nome " +
" , can_virtual = @can_virtual " +
" , can_facebook = @can_facebook " +
" , can_gmail = @can_gmail " +
"WHERE ... ";
try
{
command = new SqlCommand(sql, connection);
command.Parameters.AddWithValue("@can_codigo", pTO.can_codigo);
command.Parameters.AddWithValue("@can_nome", pTO.can_nome);
command.Parameters.AddWithValue("@can_virtual", pTO.can_virtual);
command.Parameters.AddWithValue("@can_facebook", pTO.can_facebook);
command.Parameters.AddWithValue("@can_gmail", pTO.can_gmail);
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

internal bool Delete(Canal_TO pTO)
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

string sql = "DELETE FROM vcrm_canal" +
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
