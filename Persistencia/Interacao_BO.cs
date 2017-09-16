//
// <copyright file="Interacao_BO.cs" company="Valeverde Turismo">
//     Copyright (c) Valeverde Turismo 2017. All rights reserved.
// </copyright>
// <author>Cândido</author>
// <date>11/08/2017</date>//
using System;
using System.Collections.Generic;

namespace Persistencia.crm
{
public class Interacao_BO
{
public List<Interacao_TO> SearchAll(Interacao_TO pTO)
{
string condicao = "";

try
{
// implementa a condição de procura
condicao += "";
return new Interacao_DAO().SearchAll(condicao);
}
catch (Exception)
{
throw;
}
}

public Interacao_TO GetByCode(Interacao_TO pTO)
{
try
{
return new Interacao_DAO().GetByCode(pTO);
}
catch (Exception)
{
throw;
}
}

public bool Save(bool pOpcao, Interacao_TO pTO)
{
bool retorno = false;

try
{
if (pOpcao)
{
retorno = new Interacao_DAO().Save(pTO);
}
else
{
retorno = new Interacao_DAO().Update(pTO);}
}
catch (Exception)
{
throw;
}
return retorno;
}

public bool Delete(Interacao_TO pTO)
{
bool retorno = false;

try
{
retorno = new Interacao_DAO().Delete(pTO);
}
catch (Exception)
{
throw;
}
return retorno;
}

}
}
