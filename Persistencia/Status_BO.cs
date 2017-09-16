//
// <copyright file="Status_BO.cs" company="Valeverde Turismo">
//     Copyright (c) Valeverde Turismo 2017. All rights reserved.
// </copyright>
// <author>Cândido</author>
// <date>11/08/2017</date>//
using System;
using System.Collections.Generic;

namespace Persistencia.crm
{
public class Status_BO
{
public List<Status_TO> SearchAll(Status_TO pTO)
{
string condicao = "";

try
{
// implementa a condição de procura
condicao += "";
return new Status_DAO().SearchAll(condicao);
}
catch (Exception)
{
throw;
}
}

public Status_TO GetByCode(Status_TO pTO)
{
try
{
return new Status_DAO().GetByCode(pTO);
}
catch (Exception)
{
throw;
}
}

public bool Save(bool pOpcao, Status_TO pTO)
{
bool retorno = false;

try
{
if (pOpcao)
{
retorno = new Status_DAO().Save(pTO);
}
else
{
retorno = new Status_DAO().Update(pTO);}
}
catch (Exception)
{
throw;
}
return retorno;
}

public bool Delete(Status_TO pTO)
{
bool retorno = false;

try
{
retorno = new Status_DAO().Delete(pTO);
}
catch (Exception)
{
throw;
}
return retorno;
}

}
}
