//
// <copyright file="Etapa_BO.cs" company="Valeverde Turismo">
//     Copyright (c) Valeverde Turismo 2017. All rights reserved.
// </copyright>
// <author>Cândido</author>
// <date>11/08/2017</date>//
using System;
using System.Collections.Generic;

namespace Persistencia.crm
{
public class Etapa_BO
{
public List<Etapa_TO> SearchAll(Etapa_TO pTO)
{
string condicao = "";

try
{
// implementa a condição de procura
condicao += "";
return new Etapa_DAO().SearchAll(condicao);
}
catch (Exception)
{
throw;
}
}

public Etapa_TO GetByCode(Etapa_TO pTO)
{
try
{
return new Etapa_DAO().GetByCode(pTO);
}
catch (Exception)
{
throw;
}
}

public bool Save(bool pOpcao, Etapa_TO pTO)
{
bool retorno = false;

try
{
if (pOpcao)
{
retorno = new Etapa_DAO().Save(pTO);
}
else
{
retorno = new Etapa_DAO().Update(pTO);}
}
catch (Exception)
{
throw;
}
return retorno;
}

public bool Delete(Etapa_TO pTO)
{
bool retorno = false;

try
{
retorno = new Etapa_DAO().Delete(pTO);
}
catch (Exception)
{
throw;
}
return retorno;
}

}
}
