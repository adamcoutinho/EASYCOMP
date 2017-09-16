//
// <copyright file="Atendimento_BO.cs" company="Valeverde Turismo">
//     Copyright (c) Valeverde Turismo 2017. All rights reserved.
// </copyright>
// <author>Cândido</author>
// <date>11/08/2017</date>//
using System;
using System.Collections.Generic;

namespace Persistencia.crm
{
public class Atendimento_BO
{
public List<Atendimento_TO> SearchAll(Atendimento_TO pTO)
{
string condicao = "";

try
{
// implementa a condição de procura
condicao += "";
return new Atendimento_DAO().SearchAll(condicao);
}
catch (Exception)
{
throw;
}
}

public Atendimento_TO GetByCode(Atendimento_TO pTO)
{
try
{
return new Atendimento_DAO().GetByCode(pTO);
}
catch (Exception)
{
throw;
}
}

public bool Save(bool pOpcao, Atendimento_TO pTO)
{
bool retorno = false;

try
{
if (pOpcao)
{
retorno = new Atendimento_DAO().Save(pTO);
}
else
{
retorno = new Atendimento_DAO().Update(pTO);}
}
catch (Exception)
{
throw;
}
return retorno;
}

public bool Delete(Atendimento_TO pTO)
{
bool retorno = false;

try
{
retorno = new Atendimento_DAO().Delete(pTO);
}
catch (Exception)
{
throw;
}
return retorno;
}

}
}
