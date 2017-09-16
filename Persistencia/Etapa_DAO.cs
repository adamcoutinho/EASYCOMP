//
// <copyright file="Etapa_TO.cs" company="Valeverde Turismo">
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
internal class Etapa_DAO
{
internal List<Etapa_TO> SearchAll(string pCondicao)
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

string sql = " SELECT * FROM vcrm_etapa ";

List<Etapa_TO> collection = new List<Etapa_TO>();
try
{
command = new SqlCommand(sql, connection);
reader = command.ExecuteReader();

while (reader.Read())
{
Etapa_TO EtapaTO = new Etapa_TO();
EtapaTO.eta_codigo = Convert.ToInt32(reader["eta_codigo"]);
EtapaTO.eta_nome = Convert.ToString(reader["eta_nome"]);
EtapaTO.eta_final = Convert.ToInt32(reader["eta_final"]);
collection.Add(EtapaTO);}
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

internal Etapa_TO GetByCode(Etapa_TO pTO){
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

string sql = " SELECT * FROM vcrm_etapa ";
try
{
command = new SqlCommand(sql, connection);

reader = command.ExecuteReader();

if (reader.Read())
{
pTO.eta_codigo = Convert.ToInt32(reader["eta_codigo"]);
pTO.eta_nome = Convert.ToString(reader["eta_nome"]);
pTO.eta_final = Convert.ToInt32(reader["eta_final"]);
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

internal bool Save(Etapa_TO pTO)
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

string sql = "INSERT INTO vcrm_etapa" +
" ( eta_codigo " +
", eta_nome " +
", eta_final) " +
"VALUES " +
"( @eta_codigo " +
" , @eta_nome " +
" , @eta_final ) ";

try
{
command = new SqlCommand(sql, connection);
command.Parameters.AddWithValue("@eta_codigo", pTO.eta_codigo);
command.Parameters.AddWithValue("@eta_nome", pTO.eta_nome);
command.Parameters.AddWithValue("@eta_final", pTO.eta_final);
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

internal bool Update(Etapa_TO pTO)
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

string sql = "UPDATE vcrm_etapa" +
" SET eta_codigo = @eta_codigo " +
" , eta_nome = @eta_nome " +
" , eta_final = @eta_final " +
"WHERE ... ";
try
{
command = new SqlCommand(sql, connection);
command.Parameters.AddWithValue("@eta_codigo", pTO.eta_codigo);
command.Parameters.AddWithValue("@eta_nome", pTO.eta_nome);
command.Parameters.AddWithValue("@eta_final", pTO.eta_final);
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

internal bool Delete(Etapa_TO pTO)
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

string sql = "DELETE FROM vcrm_etapa" +
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
