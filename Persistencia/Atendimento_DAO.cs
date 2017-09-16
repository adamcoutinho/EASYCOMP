//
// <copyright file="Atendimento_TO.cs" company="Valeverde Turismo">
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
internal class Atendimento_DAO
{
internal List<Atendimento_TO> SearchAll(string pCondicao)
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

string sql = " SELECT * FROM vcrm_atendimento ";

List<Atendimento_TO> collection = new List<Atendimento_TO>();
try
{
command = new SqlCommand(sql, connection);
reader = command.ExecuteReader();

while (reader.Read())
{
Atendimento_TO AtendimentoTO = new Atendimento_TO();
AtendimentoTO.atd_codigo = Convert.ToInt32(reader["atd_codigo"]);
AtendimentoTO.ClienteTO = new Cliente_TO();
AtendimentoTO.ClienteTO.cli_codigo = Convert.ToInt32(reader["cli_codigo"]);
AtendimentoTO.CanalTO = new Canal_TO();
AtendimentoTO.CanalTO.can_codigo = Convert.ToInt32(reader["can_codigo"]);
AtendimentoTO.ConsultorTO = new Consultor_TO();
AtendimentoTO.ConsultorTO.con_codigo = Convert.ToInt32(reader["con_codigo"]);
AtendimentoTO.EtapaTO = new Etapa_TO();
AtendimentoTO.EtapaTO.eta_codigo = Convert.ToInt32(reader["eta_codigo"]);
AtendimentoTO.StatusTO = new Status_TO();
AtendimentoTO.StatusTO.sta_codigo = Convert.ToInt32(reader["sta_codigo"]);
AtendimentoTO.atd_datainicio = Convert.ToDateTime(reader["atd_datainicio"]);
AtendimentoTO.atd_datafim = Convert.ToDateTime(reader["atd_datafim"]);
collection.Add(AtendimentoTO);}
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

internal Atendimento_TO GetByCode(Atendimento_TO pTO){
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

string sql = " SELECT * FROM vcrm_atendimento ";
try
{
command = new SqlCommand(sql, connection);

reader = command.ExecuteReader();

if (reader.Read())
{
pTO.atd_codigo = Convert.ToInt32(reader["atd_codigo"]);
pTO.ClienteTO = new Cliente_TO();
pTO.ClienteTO.cli_codigo = Convert.ToInt32(reader["cli_codigo"]);
pTO.CanalTO = new Canal_TO();
pTO.CanalTO.can_codigo = Convert.ToInt32(reader["can_codigo"]);
pTO.ConsultorTO = new Consultor_TO();
pTO.ConsultorTO.con_codigo = Convert.ToInt32(reader["con_codigo"]);
pTO.EtapaTO = new Etapa_TO();
pTO.EtapaTO.eta_codigo = Convert.ToInt32(reader["eta_codigo"]);
pTO.StatusTO = new Status_TO();
pTO.StatusTO.sta_codigo = Convert.ToInt32(reader["sta_codigo"]);
pTO.atd_datainicio = Convert.ToDateTime(reader["atd_datainicio"]);
pTO.atd_datafim = Convert.ToDateTime(reader["atd_datafim"]);
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

internal bool Save(Atendimento_TO pTO)
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

string sql = "INSERT INTO vcrm_atendimento" +
" ( atd_codigo " +
", cli_codigo " +
", can_codigo " +
", con_codigo " +
", eta_codigo " +
", sta_codigo " +
", atd_datainicio " +
", atd_datafim) " +
"VALUES " +
"( @atd_codigo " +
" , @cli_codigo " +
" , @can_codigo " +
" , @con_codigo " +
" , @eta_codigo " +
" , @sta_codigo " +
" , @atd_datainicio " +
" , @atd_datafim ) ";

try
{
command = new SqlCommand(sql, connection);
command.Parameters.AddWithValue("@atd_codigo", pTO.atd_codigo);
command.Parameters.AddWithValue("@cli_codigo", pTO.ClienteTO.cli_codigo);
command.Parameters.AddWithValue("@can_codigo", pTO.CanalTO.can_codigo);
command.Parameters.AddWithValue("@con_codigo", pTO.ConsultorTO.con_codigo);
command.Parameters.AddWithValue("@eta_codigo", pTO.EtapaTO.eta_codigo);
command.Parameters.AddWithValue("@sta_codigo", pTO.StatusTO.sta_codigo);
command.Parameters.AddWithValue("@atd_datainicio", pTO.atd_datainicio);
command.Parameters.AddWithValue("@atd_datafim", pTO.atd_datafim);
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

internal bool Update(Atendimento_TO pTO)
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

string sql = "UPDATE vcrm_atendimento" +
" SET atd_codigo = @atd_codigo " +
" , cli_codigo = @cli_codigo " +
" , can_codigo = @can_codigo " +
" , con_codigo = @con_codigo " +
" , eta_codigo = @eta_codigo " +
" , sta_codigo = @sta_codigo " +
" , atd_datainicio = @atd_datainicio " +
" , atd_datafim = @atd_datafim " +
"WHERE ... ";
try
{
command = new SqlCommand(sql, connection);
command.Parameters.AddWithValue("@atd_codigo", pTO.atd_codigo);
command.Parameters.AddWithValue("@cli_codigo", pTO.ClienteTO.cli_codigo);
command.Parameters.AddWithValue("@can_codigo", pTO.CanalTO.can_codigo);
command.Parameters.AddWithValue("@con_codigo", pTO.ConsultorTO.con_codigo);
command.Parameters.AddWithValue("@eta_codigo", pTO.EtapaTO.eta_codigo);
command.Parameters.AddWithValue("@sta_codigo", pTO.StatusTO.sta_codigo);
command.Parameters.AddWithValue("@atd_datainicio", pTO.atd_datainicio);
command.Parameters.AddWithValue("@atd_datafim", pTO.atd_datafim);
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

internal bool Delete(Atendimento_TO pTO)
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

string sql = "DELETE FROM vcrm_atendimento" +
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
