//
// <copyright file="Historico_TO.cs" company="Valeverde Turismo">
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
internal class Historico_DAO
{
internal List<Historico_TO> SearchAll(string pCondicao)
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

string sql = " SELECT * FROM vcrm_historico ";

List<Historico_TO> collection = new List<Historico_TO>();
try
{
command = new SqlCommand(sql, connection);
reader = command.ExecuteReader();

while (reader.Read())
{
Historico_TO HistoricoTO = new Historico_TO();
HistoricoTO.his_codigo = Convert.ToInt32(reader["his_codigo"]);
HistoricoTO.AtendimentoTO = new Atendimento_TO();
HistoricoTO.AtendimentoTO.atd_codigo = Convert.ToInt32(reader["atd_codigo"]);
HistoricoTO.his_sequencial = Convert.ToInt32(reader["his_sequencial"]);
HistoricoTO.EtapaTO = new Etapa_TO();
HistoricoTO.EtapaTO.eta_codigo = Convert.ToInt32(reader["eta_codigo"]);
HistoricoTO.StatusTO = new Status_TO();
HistoricoTO.StatusTO.sta_codigo = Convert.ToInt32(reader["sta_codigo"]);
HistoricoTO.his_data = Convert.ToDateTime(reader["his_data"]);
HistoricoTO.his_hora = (reader["his_hora"]);
HistoricoTO.ConsultorTO = new Consultor_TO();
HistoricoTO.ConsultorTO.con_codigo = Convert.ToInt32(reader["con_codigo"]);
HistoricoTO.his_mudouconsultor = Convert.ToInt32(reader["his_mudouconsultor"]);
HistoricoTO.ProdutoTO = new Produto_TO();
HistoricoTO.ProdutoTO.pro_codigo = Convert.ToInt32(reader["pro_codigo"]);
HistoricoTO.his_mudouproduto = Convert.ToInt32(reader["his_mudouproduto"]);
HistoricoTO.CanalTO = new Canal_TO();
HistoricoTO.CanalTO.can_codigo = Convert.ToInt32(reader["can_codigo"]);
HistoricoTO.his_mudoucanal = Convert.ToInt32(reader["his_mudoucanal"]);
HistoricoTO.his_usuario = Convert.ToInt32(reader["his_usuario"]);
collection.Add(HistoricoTO);}
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

internal Historico_TO GetByCode(Historico_TO pTO){
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

string sql = " SELECT * FROM vcrm_historico ";
try
{
command = new SqlCommand(sql, connection);

reader = command.ExecuteReader();

if (reader.Read())
{
pTO.his_codigo = Convert.ToInt32(reader["his_codigo"]);
pTO.AtendimentoTO = new Atendimento_TO();
pTO.AtendimentoTO.atd_codigo = Convert.ToInt32(reader["atd_codigo"]);
pTO.his_sequencial = Convert.ToInt32(reader["his_sequencial"]);
pTO.EtapaTO = new Etapa_TO();
pTO.EtapaTO.eta_codigo = Convert.ToInt32(reader["eta_codigo"]);
pTO.StatusTO = new Status_TO();
pTO.StatusTO.sta_codigo = Convert.ToInt32(reader["sta_codigo"]);
pTO.his_data = Convert.ToDateTime(reader["his_data"]);
pTO.his_hora = (reader["his_hora"]);
pTO.ConsultorTO = new Consultor_TO();
pTO.ConsultorTO.con_codigo = Convert.ToInt32(reader["con_codigo"]);
pTO.his_mudouconsultor = Convert.ToInt32(reader["his_mudouconsultor"]);
pTO.ProdutoTO = new Produto_TO();
pTO.ProdutoTO.pro_codigo = Convert.ToInt32(reader["pro_codigo"]);
pTO.his_mudouproduto = Convert.ToInt32(reader["his_mudouproduto"]);
pTO.CanalTO = new Canal_TO();
pTO.CanalTO.can_codigo = Convert.ToInt32(reader["can_codigo"]);
pTO.his_mudoucanal = Convert.ToInt32(reader["his_mudoucanal"]);
pTO.his_usuario = Convert.ToInt32(reader["his_usuario"]);
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

internal bool Save(Historico_TO pTO)
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

string sql = "INSERT INTO vcrm_historico" +
" ( his_codigo " +
", atd_codigo " +
", his_sequencial " +
", eta_codigo " +
", sta_codigo " +
", his_data " +
", his_hora " +
", con_codigo " +
", his_mudouconsultor " +
", pro_codigo " +
", his_mudouproduto " +
", can_codigo " +
", his_mudoucanal " +
", his_usuario) " +
"VALUES " +
"( @his_codigo " +
" , @atd_codigo " +
" , @his_sequencial " +
" , @eta_codigo " +
" , @sta_codigo " +
" , @his_data " +
" , @his_hora " +
" , @con_codigo " +
" , @his_mudouconsultor " +
" , @pro_codigo " +
" , @his_mudouproduto " +
" , @can_codigo " +
" , @his_mudoucanal " +
" , @his_usuario ) ";

try
{
command = new SqlCommand(sql, connection);
command.Parameters.AddWithValue("@his_codigo", pTO.his_codigo);
command.Parameters.AddWithValue("@atd_codigo", pTO.AtendimentoTO.atd_codigo);
command.Parameters.AddWithValue("@his_sequencial", pTO.his_sequencial);
command.Parameters.AddWithValue("@eta_codigo", pTO.EtapaTO.eta_codigo);
command.Parameters.AddWithValue("@sta_codigo", pTO.StatusTO.sta_codigo);
command.Parameters.AddWithValue("@his_data", pTO.his_data);
command.Parameters.AddWithValue("@his_hora", pTO.his_hora);
command.Parameters.AddWithValue("@con_codigo", pTO.ConsultorTO.con_codigo);
command.Parameters.AddWithValue("@his_mudouconsultor", pTO.his_mudouconsultor);
command.Parameters.AddWithValue("@pro_codigo", pTO.ProdutoTO.pro_codigo);
command.Parameters.AddWithValue("@his_mudouproduto", pTO.his_mudouproduto);
command.Parameters.AddWithValue("@can_codigo", pTO.CanalTO.can_codigo);
command.Parameters.AddWithValue("@his_mudoucanal", pTO.his_mudoucanal);
command.Parameters.AddWithValue("@his_usuario", pTO.his_usuario);
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

internal bool Update(Historico_TO pTO)
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

string sql = "UPDATE vcrm_historico" +
" SET his_codigo = @his_codigo " +
" , atd_codigo = @atd_codigo " +
" , his_sequencial = @his_sequencial " +
" , eta_codigo = @eta_codigo " +
" , sta_codigo = @sta_codigo " +
" , his_data = @his_data " +
" , his_hora = @his_hora " +
" , con_codigo = @con_codigo " +
" , his_mudouconsultor = @his_mudouconsultor " +
" , pro_codigo = @pro_codigo " +
" , his_mudouproduto = @his_mudouproduto " +
" , can_codigo = @can_codigo " +
" , his_mudoucanal = @his_mudoucanal " +
" , his_usuario = @his_usuario " +
"WHERE ... ";
try
{
command = new SqlCommand(sql, connection);
command.Parameters.AddWithValue("@his_codigo", pTO.his_codigo);
command.Parameters.AddWithValue("@atd_codigo", pTO.AtendimentoTO.atd_codigo);
command.Parameters.AddWithValue("@his_sequencial", pTO.his_sequencial);
command.Parameters.AddWithValue("@eta_codigo", pTO.EtapaTO.eta_codigo);
command.Parameters.AddWithValue("@sta_codigo", pTO.StatusTO.sta_codigo);
command.Parameters.AddWithValue("@his_data", pTO.his_data);
command.Parameters.AddWithValue("@his_hora", pTO.his_hora);
command.Parameters.AddWithValue("@con_codigo", pTO.ConsultorTO.con_codigo);
command.Parameters.AddWithValue("@his_mudouconsultor", pTO.his_mudouconsultor);
command.Parameters.AddWithValue("@pro_codigo", pTO.ProdutoTO.pro_codigo);
command.Parameters.AddWithValue("@his_mudouproduto", pTO.his_mudouproduto);
command.Parameters.AddWithValue("@can_codigo", pTO.CanalTO.can_codigo);
command.Parameters.AddWithValue("@his_mudoucanal", pTO.his_mudoucanal);
command.Parameters.AddWithValue("@his_usuario", pTO.his_usuario);
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

internal bool Delete(Historico_TO pTO)
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

string sql = "DELETE FROM vcrm_historico" +
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
