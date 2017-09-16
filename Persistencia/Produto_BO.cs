//
// <copyright file="Produto_BO.cs" company="Valeverde Turismo">
//     Copyright (c) Valeverde Turismo 2017. All rights reserved.
// </copyright>
// <author>Cândido</author>
// <date>11/08/2017</date>//
using System;
using System.Collections.Generic;

namespace Persistencia.crm
{
public class Produto_BO
{
public List<Produto_TO> SearchAll(Produto_TO pTO)
{
string condicao = "";

try
{
// implementa a condição de procura
condicao += "";
return new Produto_DAO().SearchAll(condicao);
}
catch (Exception)
{
throw;
}
}

public Produto_TO GetByCode(Produto_TO pTO)
{
try
{
return new Produto_DAO().GetByCode(pTO);
}
catch (Exception)
{
throw;
}
}

public bool Save(bool pOpcao, Produto_TO pTO)
{
bool retorno = false;

try
{
if (pOpcao)
{
retorno = new Produto_DAO().Save(pTO);
}
else
{
retorno = new Produto_DAO().Update(pTO);}
}
catch (Exception)
{
throw;
}
return retorno;
}

public bool Delete(Produto_TO pTO)
{
bool retorno = false;

try
{
retorno = new Produto_DAO().Delete(pTO);
}
catch (Exception)
{
throw;
}
return retorno;
}

}
}
