//
// <copyright file="Pais_BO.cs" company="Valeverde Turismo">
//     Copyright (c) Valeverde Turismo 2017. All rights reserved.
// </copyright>
// <author>Cândido</author>
// <date>11/08/2017</date>//
using System;
using System.Collections.Generic;

namespace Persistencia.crm
{
public class Pais_BO
{
public List<Pais_TO> SearchAll(Pais_TO pTO)
{
string condicao = "";

try
{
// implementa a condição de procura
condicao += "";
return new Pais_DAO().SearchAll(condicao);
}
catch (Exception)
{
throw;
}
}

public Pais_TO GetByCode(Pais_TO pTO)
{
try
{
return new Pais_DAO().GetByCode(pTO);
}
catch (Exception)
{
throw;
}
}

public bool Save(bool pOpcao, Pais_TO pTO)
{
bool retorno = false;

try
{
if (pOpcao)
{
retorno = new Pais_DAO().Save(pTO);
}
else
{
retorno = new Pais_DAO().Update(pTO);}
}
catch (Exception)
{
throw;
}
return retorno;
}

public bool Delete(Pais_TO pTO)
{
bool retorno = false;

try
{
retorno = new Pais_DAO().Delete(pTO);
}
catch (Exception)
{
throw;
}
return retorno;
}

}
}
