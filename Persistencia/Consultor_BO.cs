//
// <copyright file="Consultor_BO.cs" company="Valeverde Turismo">
//     Copyright (c) Valeverde Turismo 2017. All rights reserved.
// </copyright>
// <author>Cândido</author>
// <date>11/08/2017</date>//
using System;
using System.Collections.Generic;

namespace Persistencia.crm
{
public class Consultor_BO
{
public List<Consultor_TO> SearchAll(Consultor_TO pTO)
{
string condicao = "";

try
{
// implementa a condição de procura
condicao += "";
return new Consultor_DAO().SearchAll(condicao);
}
catch (Exception)
{
throw;
}
}

public Consultor_TO GetByCode(Consultor_TO pTO)
{
try
{
return new Consultor_DAO().GetByCode(pTO);
}
catch (Exception)
{
throw;
}
}

public bool Save(bool pOpcao, Consultor_TO pTO)
{
bool retorno = false;

try
{
if (pOpcao)
{
retorno = new Consultor_DAO().Save(pTO);
}
else
{
retorno = new Consultor_DAO().Update(pTO);}
}
catch (Exception)
{
throw;
}
return retorno;
}

public bool Delete(Consultor_TO pTO)
{
bool retorno = false;

try
{
retorno = new Consultor_DAO().Delete(pTO);
}
catch (Exception)
{
throw;
}
return retorno;
}

}
}
