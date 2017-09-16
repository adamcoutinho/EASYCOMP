//
// <copyright file="AtendimentoVenda_TO.cs" company="Valeverde Turismo">
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
internal class AtendimentoVenda_DAO
{
internal List<AtendimentoVenda_TO> SearchAll(string pCondicao)
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

string sql = " SELECT * FROM vcrm_atendimento_venda ";

List<AtendimentoVenda_TO> collection = new List<AtendimentoVenda_TO>();
try
{
command = new SqlCommand(sql, connection);
reader = command.ExecuteReader();

while (reader.Read())
{
AtendimentoVenda_TO AtendimentoVendaTO = new AtendimentoVenda_TO();
AtendimentoVendaTO.atv_codigo = Convert.ToInt32(reader["atv_codigo"]);
AtendimentoVendaTO.AtendimentoTO = new Atendimento_TO();
AtendimentoVendaTO.AtendimentoTO.atd_codigo = Convert.ToInt32(reader["atd_codigo"]);
AtendimentoVendaTO.ProdutoTO = new Produto_TO();
AtendimentoVendaTO.ProdutoTO.pro_codigo = Convert.ToInt32(reader["pro_codigo"]);
AtendimentoVendaTO.atv_sistema = (reader["atv_sistema"]);
AtendimentoVendaTO.atv_venda = Convert.ToInt32(reader["atv_venda"]);
AtendimentoVendaTO.atv_valor = Convert.ToDecimal(reader["atv_valor"]);
AtendimentoVendaTO.atv_receita = Convert.ToDecimal(reader["atv_receita"]);
AtendimentoVendaTO.DestinoTO = new Destino_TO();
AtendimentoVendaTO.DestinoTO.des_codigo = Convert.ToInt32(reader["des_codigo"]);
collection.Add(AtendimentoVendaTO);}
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

internal AtendimentoVenda_TO GetByCode(AtendimentoVenda_TO pTO){
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

string sql = " SELECT * FROM vcrm_atendimento_venda ";
try
{
command = new SqlCommand(sql, connection);

reader = command.ExecuteReader();

if (reader.Read())
{
pTO.atv_codigo = Convert.ToInt32(reader["atv_codigo"]);
pTO.AtendimentoTO = new Atendimento_TO();
pTO.AtendimentoTO.atd_codigo = Convert.ToInt32(reader["atd_codigo"]);
pTO.ProdutoTO = new Produto_TO();
pTO.ProdutoTO.pro_codigo = Convert.ToInt32(reader["pro_codigo"]);
pTO.atv_sistema = (reader["atv_sistema"]);
pTO.atv_venda = Convert.ToInt32(reader["atv_venda"]);
pTO.atv_valor = Convert.ToDecimal(reader["atv_valor"]);
pTO.atv_receita = Convert.ToDecimal(reader["atv_receita"]);
pTO.DestinoTO = new Destino_TO();
pTO.DestinoTO.des_codigo = Convert.ToInt32(reader["des_codigo"]);
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

internal bool Save(AtendimentoVenda_TO pTO)
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

string sql = "INSERT INTO vcrm_atendimento_venda" +
" ( atv_codigo " +
", atd_codigo " +
", pro_codigo " +
", atv_sistema " +
", atv_venda " +
", atv_valor " +
", atv_receita " +
", des_codigo) " +
"VALUES " +
"( @atv_codigo " +
" , @atd_codigo " +
" , @pro_codigo " +
" , @atv_sistema " +
" , @atv_venda " +
" , @atv_valor " +
" , @atv_receita " +
" , @des_codigo ) ";

try
{
command = new SqlCommand(sql, connection);
command.Parameters.AddWithValue("@atv_codigo", pTO.atv_codigo);
command.Parameters.AddWithValue("@atd_codigo", pTO.AtendimentoTO.atd_codigo);
command.Parameters.AddWithValue("@pro_codigo", pTO.ProdutoTO.pro_codigo);
command.Parameters.AddWithValue("@atv_sistema", pTO.atv_sistema);
command.Parameters.AddWithValue("@atv_venda", pTO.atv_venda);
command.Parameters.AddWithValue("@atv_valor", pTO.atv_valor);
command.Parameters.AddWithValue("@atv_receita", pTO.atv_receita);
command.Parameters.AddWithValue("@des_codigo", pTO.DestinoTO.des_codigo);
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

internal bool Update(AtendimentoVenda_TO pTO)
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

string sql = "UPDATE vcrm_atendimento_venda" +
" SET atv_codigo = @atv_codigo " +
" , atd_codigo = @atd_codigo " +
" , pro_codigo = @pro_codigo " +
" , atv_sistema = @atv_sistema " +
" , atv_venda = @atv_venda " +
" , atv_valor = @atv_valor " +
" , atv_receita = @atv_receita " +
" , des_codigo = @des_codigo " +
"WHERE ... ";
try
{
command = new SqlCommand(sql, connection);
command.Parameters.AddWithValue("@atv_codigo", pTO.atv_codigo);
command.Parameters.AddWithValue("@atd_codigo", pTO.AtendimentoTO.atd_codigo);
command.Parameters.AddWithValue("@pro_codigo", pTO.ProdutoTO.pro_codigo);
command.Parameters.AddWithValue("@atv_sistema", pTO.atv_sistema);
command.Parameters.AddWithValue("@atv_venda", pTO.atv_venda);
command.Parameters.AddWithValue("@atv_valor", pTO.atv_valor);
command.Parameters.AddWithValue("@atv_receita", pTO.atv_receita);
command.Parameters.AddWithValue("@des_codigo", pTO.DestinoTO.des_codigo);
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

internal bool Delete(AtendimentoVenda_TO pTO)
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

string sql = "DELETE FROM vcrm_atendimento_venda" +
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
