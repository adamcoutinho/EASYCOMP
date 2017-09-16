//
// <copyright file="Destino_BO.cs" company="Valeverde Turismo">
//     Copyright (c) Valeverde Turismo 2017. All rights reserved.
// </copyright>
// <author>Cândido</author>
// <date>11/08/2017</date>//
using System;
using System.Collections.Generic;

namespace Persistencia.crm
{
public class Destino_BO
{
public List<Destino_TO> SearchAll(Destino_TO pTO)
{
string condicao = "";

try
{
// implementa a condição de procura
condicao += "";
return new Destino_DAO().SearchAll(condicao);
}
catch (Exception)
{
throw;
}
}

public Destino_TO GetByCode(Destino_TO pTO)
{
try
{
return new Destino_DAO().GetByCode(pTO);
}
catch (Exception)
{
throw;
}
}

public bool Save(bool pOpcao, Destino_TO pTO)
{
bool retorno = false;

try
{
if (pOpcao)
{
retorno = new Destino_DAO().Save(pTO);
}
else
{
retorno = new Destino_DAO().Update(pTO);}
}
catch (Exception)
{
throw;
}
return retorno;
}

public bool Delete(Destino_TO pTO)
{
bool retorno = false;

try
{
retorno = new Destino_DAO().Delete(pTO);
}
catch (Exception)
{
throw;
}
return retorno;
}

}
}
