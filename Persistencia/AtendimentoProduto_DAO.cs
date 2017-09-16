//
// <copyright file="AtendimentoProduto_TO.cs" company="Valeverde Turismo">
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
internal class AtendimentoProduto_DAO
{
internal List<AtendimentoProduto_TO> SearchAll(string pCondicao)
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

string sql = " SELECT * FROM vcrm_atendimento_produto ";

List<AtendimentoProduto_TO> collection = new List<AtendimentoProduto_TO>();
try
{
command = new SqlCommand(sql, connection);
reader = command.ExecuteReader();

while (reader.Read())
{
AtendimentoProduto_TO AtendimentoProdutoTO = new AtendimentoProduto_TO();
AtendimentoProdutoTO.atp_codigo = Convert.ToInt32(reader["atp_codigo"]);
AtendimentoProdutoTO.AtendimentoTO = new Atendimento_TO();
AtendimentoProdutoTO.AtendimentoTO.atd_codigo = Convert.ToInt32(reader["atd_codigo"]);
AtendimentoProdutoTO.ProdutoTO = new Produto_TO();
AtendimentoProdutoTO.ProdutoTO.pro_codigo = Convert.ToInt32(reader["pro_codigo"]);
AtendimentoProdutoTO.atp_valor = Convert.ToDecimal(reader["atp_valor"]);
AtendimentoProdutoTO.DestinoTO = new Destino_TO();
AtendimentoProdutoTO.DestinoTO.des_codigo = Convert.ToInt32(reader["des_codigo"]);
collection.Add(AtendimentoProdutoTO);}
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

internal AtendimentoProduto_TO GetByCode(AtendimentoProduto_TO pTO){
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

string sql = " SELECT * FROM vcrm_atendimento_produto ";
"WHERE  atp_codigo = @atp_codigo ";
try
{
command = new SqlCommand(sql, connection);

command.Parameters.AddWithValue("@atp_codigo", pTO.atp_codigo);
reader = command.ExecuteReader();

if (reader.Read())
{
pTO.atp_codigo = Convert.ToInt32(reader["atp_codigo"]);
pTO.AtendimentoTO = new Atendimento_TO();
pTO.AtendimentoTO.atd_codigo = Convert.ToInt32(reader["atd_codigo"]);
pTO.ProdutoTO = new Produto_TO();
pTO.ProdutoTO.pro_codigo = Convert.ToInt32(reader["pro_codigo"]);
pTO.atp_valor = Convert.ToDecimal(reader["atp_valor"]);
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

internal bool Save(AtendimentoProduto_TO pTO)
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

string sql = "INSERT INTO vcrm_atendimento_produto" +
" ( atp_codigo " +
", atd_codigo " +
", pro_codigo " +
", atp_valor " +
", des_codigo) " +
"VALUES " +
"( @atp_codigo " +
" , @atd_codigo " +
" , @pro_codigo " +
" , @atp_valor " +
" , @des_codigo ) ";

try
{
command = new SqlCommand(sql, connection);
command.Parameters.AddWithValue("@atp_codigo", pTO.atp_codigo);
command.Parameters.AddWithValue("@atd_codigo", pTO.AtendimentoTO.atd_codigo);
command.Parameters.AddWithValue("@pro_codigo", pTO.ProdutoTO.pro_codigo);
command.Parameters.AddWithValue("@atp_valor", pTO.atp_valor);
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

internal bool Update(AtendimentoProduto_TO pTO)
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

string sql = "UPDATE vcrm_atendimento_produto" +
" SET atp_codigo = @atp_codigo " +
" , atd_codigo = @atd_codigo " +
" , pro_codigo = @pro_codigo " +
" , atp_valor = @atp_valor " +
" , des_codigo = @des_codigo " +
"WHERE  atp_codigo = @atp_codigo ";
try
{
command = new SqlCommand(sql, connection);
command.Parameters.AddWithValue("@atp_codigo", pTO.atp_codigo);
command.Parameters.AddWithValue("@atd_codigo", pTO.AtendimentoTO.atd_codigo);
command.Parameters.AddWithValue("@pro_codigo", pTO.ProdutoTO.pro_codigo);
command.Parameters.AddWithValue("@atp_valor", pTO.atp_valor);
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

internal bool Delete(AtendimentoProduto_TO pTO)
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

string sql = "DELETE FROM vcrm_atendimento_produto" +
"WHERE  atp_codigo = @atp_codigo ";
try
{
command = new SqlCommand(sql, connection);
command.Parameters.AddWithValue("@atp_codigo", pTO.atp_codigo);
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
