//
// <copyright file="Cidade_BO.cs" company="Valeverde Turismo">
//     Copyright (c) Valeverde Turismo 2017. All rights reserved.
// </copyright>
// <author>Cândido</author>
// <date>11/08/2017</date>//
using System;
using System.Collections.Generic;

namespace Persistencia.crm
{
public class Cidade_BO
{
public List<Cidade_TO> SearchAll(Cidade_TO pTO)
{
string condicao = "";

try
{
// implementa a condição de procura
condicao += "";
return new Cidade_DAO().SearchAll(condicao);
}
catch (Exception)
{
throw;
}
}

public Cidade_TO GetByCode(Cidade_TO pTO)
{
try
{
return new Cidade_DAO().GetByCode(pTO);
}
catch (Exception)
{
throw;
}
}

public bool Save(bool pOpcao, Cidade_TO pTO)
{
bool retorno = false;

try
{
if (pOpcao)
{
retorno = new Cidade_DAO().Save(pTO);
}
else
{
retorno = new Cidade_DAO().Update(pTO);}
}
catch (Exception)
{
throw;
}
return retorno;
}

public bool Delete(Cidade_TO pTO)
{
bool retorno = false;

try
{
retorno = new Cidade_DAO().Delete(pTO);
}
catch (Exception)
{
throw;
}
return retorno;
}

}
}
