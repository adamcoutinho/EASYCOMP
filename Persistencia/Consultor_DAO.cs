//
// <copyright file="Consultor_TO.cs" company="Valeverde Turismo">
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
internal class Consultor_DAO
{
internal List<Consultor_TO> SearchAll(string pCondicao)
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

string sql = " SELECT * FROM vcrm_consultor ";

List<Consultor_TO> collection = new List<Consultor_TO>();
try
{
command = new SqlCommand(sql, connection);
reader = command.ExecuteReader();

while (reader.Read())
{
Consultor_TO ConsultorTO = new Consultor_TO();
ConsultorTO.con_codigo = Convert.ToInt32(reader["con_codigo"]);
ConsultorTO.con_codstur = Convert.ToInt32(reader["con_codstur"]);
ConsultorTO.con_nome = Convert.ToString(reader["con_nome"]);
ConsultorTO.con_virtual = Convert.ToInt32(reader["con_virtual"]);
collection.Add(ConsultorTO);}
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

internal Consultor_TO GetByCode(Consultor_TO pTO){
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

string sql = " SELECT * FROM vcrm_consultor ";
try
{
command = new SqlCommand(sql, connection);

reader = command.ExecuteReader();

if (reader.Read())
{
pTO.con_codigo = Convert.ToInt32(reader["con_codigo"]);
pTO.con_codstur = Convert.ToInt32(reader["con_codstur"]);
pTO.con_nome = Convert.ToString(reader["con_nome"]);
pTO.con_virtual = Convert.ToInt32(reader["con_virtual"]);
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

internal bool Save(Consultor_TO pTO)
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

string sql = "INSERT INTO vcrm_consultor" +
" ( con_codigo " +
", con_codstur " +
", con_nome " +
", con_virtual) " +
"VALUES " +
"( @con_codigo " +
" , @con_codstur " +
" , @con_nome " +
" , @con_virtual ) ";

try
{
command = new SqlCommand(sql, connection);
command.Parameters.AddWithValue("@con_codigo", pTO.con_codigo);
command.Parameters.AddWithValue("@con_codstur", pTO.con_codstur);
command.Parameters.AddWithValue("@con_nome", pTO.con_nome);
command.Parameters.AddWithValue("@con_virtual", pTO.con_virtual);
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

internal bool Update(Consultor_TO pTO)
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

string sql = "UPDATE vcrm_consultor" +
" SET con_codigo = @con_codigo " +
" , con_codstur = @con_codstur " +
" , con_nome = @con_nome " +
" , con_virtual = @con_virtual " +
"WHERE ... ";
try
{
command = new SqlCommand(sql, connection);
command.Parameters.AddWithValue("@con_codigo", pTO.con_codigo);
command.Parameters.AddWithValue("@con_codstur", pTO.con_codstur);
command.Parameters.AddWithValue("@con_nome", pTO.con_nome);
command.Parameters.AddWithValue("@con_virtual", pTO.con_virtual);
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

internal bool Delete(Consultor_TO pTO)
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

string sql = "DELETE FROM vcrm_consultor" +
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
