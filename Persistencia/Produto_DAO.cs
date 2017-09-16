//
// <copyright file="Produto_TO.cs" company="Valeverde Turismo">
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
internal class Produto_DAO
{
internal List<Produto_TO> SearchAll(string pCondicao)
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

string sql = " SELECT * FROM vcrm_produto ";

List<Produto_TO> collection = new List<Produto_TO>();
try
{
command = new SqlCommand(sql, connection);
reader = command.ExecuteReader();

while (reader.Read())
{
Produto_TO ProdutoTO = new Produto_TO();
ProdutoTO.pro_codigo = Convert.ToInt32(reader["pro_codigo"]);
ProdutoTO.pro_nome = Convert.ToString(reader["pro_nome"]);
ProdutoTO.pro_ambito = (reader["pro_ambito"]);
ProdutoTO.pro_nome_longo = Convert.ToString(reader["pro_nome_longo"]);
ProdutoTO.pro_valor_minimo = Convert.ToDecimal(reader["pro_valor_minimo"]);
ProdutoTO.pro_valor_maximo = Convert.ToDecimal(reader["pro_valor_maximo"]);
ProdutoTO.pro_valor_medio = Convert.ToDecimal(reader["pro_valor_medio"]);
collection.Add(ProdutoTO);}
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

internal Produto_TO GetByCode(Produto_TO pTO){
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

string sql = " SELECT * FROM vcrm_produto ";
try
{
command = new SqlCommand(sql, connection);

reader = command.ExecuteReader();

if (reader.Read())
{
pTO.pro_codigo = Convert.ToInt32(reader["pro_codigo"]);
pTO.pro_nome = Convert.ToString(reader["pro_nome"]);
pTO.pro_ambito = (reader["pro_ambito"]);
pTO.pro_nome_longo = Convert.ToString(reader["pro_nome_longo"]);
pTO.pro_valor_minimo = Convert.ToDecimal(reader["pro_valor_minimo"]);
pTO.pro_valor_maximo = Convert.ToDecimal(reader["pro_valor_maximo"]);
pTO.pro_valor_medio = Convert.ToDecimal(reader["pro_valor_medio"]);
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

internal bool Save(Produto_TO pTO)
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

string sql = "INSERT INTO vcrm_produto" +
" ( pro_codigo " +
", pro_nome " +
", pro_ambito " +
", pro_nome_longo " +
", pro_valor_minimo " +
", pro_valor_maximo " +
", pro_valor_medio) " +
"VALUES " +
"( @pro_codigo " +
" , @pro_nome " +
" , @pro_ambito " +
" , @pro_nome_longo " +
" , @pro_valor_minimo " +
" , @pro_valor_maximo " +
" , @pro_valor_medio ) ";

try
{
command = new SqlCommand(sql, connection);
command.Parameters.AddWithValue("@pro_codigo", pTO.pro_codigo);
command.Parameters.AddWithValue("@pro_nome", pTO.pro_nome);
command.Parameters.AddWithValue("@pro_ambito", pTO.pro_ambito);
command.Parameters.AddWithValue("@pro_nome_longo", pTO.pro_nome_longo);
command.Parameters.AddWithValue("@pro_valor_minimo", pTO.pro_valor_minimo);
command.Parameters.AddWithValue("@pro_valor_maximo", pTO.pro_valor_maximo);
command.Parameters.AddWithValue("@pro_valor_medio", pTO.pro_valor_medio);
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

internal bool Update(Produto_TO pTO)
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

string sql = "UPDATE vcrm_produto" +
" SET pro_codigo = @pro_codigo " +
" , pro_nome = @pro_nome " +
" , pro_ambito = @pro_ambito " +
" , pro_nome_longo = @pro_nome_longo " +
" , pro_valor_minimo = @pro_valor_minimo " +
" , pro_valor_maximo = @pro_valor_maximo " +
" , pro_valor_medio = @pro_valor_medio " +
"WHERE ... ";
try
{
command = new SqlCommand(sql, connection);
command.Parameters.AddWithValue("@pro_codigo", pTO.pro_codigo);
command.Parameters.AddWithValue("@pro_nome", pTO.pro_nome);
command.Parameters.AddWithValue("@pro_ambito", pTO.pro_ambito);
command.Parameters.AddWithValue("@pro_nome_longo", pTO.pro_nome_longo);
command.Parameters.AddWithValue("@pro_valor_minimo", pTO.pro_valor_minimo);
command.Parameters.AddWithValue("@pro_valor_maximo", pTO.pro_valor_maximo);
command.Parameters.AddWithValue("@pro_valor_medio", pTO.pro_valor_medio);
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

internal bool Delete(Produto_TO pTO)
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

string sql = "DELETE FROM vcrm_produto" +
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
