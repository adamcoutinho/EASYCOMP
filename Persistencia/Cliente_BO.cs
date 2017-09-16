//
// <copyright file="Cliente_BO.cs" company="Valeverde Turismo">
//     Copyright (c) Valeverde Turismo 2017. All rights reserved.
// </copyright>
// <author>Cândido</author>
// <date>11/08/2017</date>//
using System;
using System.Collections.Generic;

namespace Persistencia.crm
{
public class Cliente_BO
{
public List<Cliente_TO> SearchAll(Cliente_TO pTO)
{
string condicao = "";

try
{
// implementa a condição de procura
condicao += "";
return new Cliente_DAO().SearchAll(condicao);
}
catch (Exception)
{
throw;
}
}

public Cliente_TO GetByCode(Cliente_TO pTO)
{
try
{
return new Cliente_DAO().GetByCode(pTO);
}
catch (Exception)
{
throw;
}
}

public bool Save(bool pOpcao, Cliente_TO pTO)
{
bool retorno = false;

try
{
if (pOpcao)
{
retorno = new Cliente_DAO().Save(pTO);
}
else
{
retorno = new Cliente_DAO().Update(pTO);}
}
catch (Exception)
{
throw;
}
return retorno;
}

public bool Delete(Cliente_TO pTO)
{
bool retorno = false;

try
{
retorno = new Cliente_DAO().Delete(pTO);
}
catch (Exception)
{
throw;
}
return retorno;
}

}
}
