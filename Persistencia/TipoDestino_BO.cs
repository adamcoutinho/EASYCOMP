//
// <copyright file="TipoDestino_BO.cs" company="Valeverde Turismo">
//     Copyright (c) Valeverde Turismo 2017. All rights reserved.
// </copyright>
// <author>Cândido</author>
// <date>11/08/2017</date>//
using System;
using System.Collections.Generic;

namespace Persistencia.crm
{
public class TipoDestino_BO
{
public List<TipoDestino_TO> SearchAll(TipoDestino_TO pTO)
{
string condicao = "";

try
{
// implementa a condição de procura
condicao += "";
return new TipoDestino_DAO().SearchAll(condicao);
}
catch (Exception)
{
throw;
}
}

public TipoDestino_TO GetByCode(TipoDestino_TO pTO)
{
try
{
return new TipoDestino_DAO().GetByCode(pTO);
}
catch (Exception)
{
throw;
}
}

public bool Save(bool pOpcao, TipoDestino_TO pTO)
{
bool retorno = false;

try
{
if (pOpcao)
{
retorno = new TipoDestino_DAO().Save(pTO);
}
else
{
retorno = new TipoDestino_DAO().Update(pTO);}
}
catch (Exception)
{
throw;
}
return retorno;
}

public bool Delete(TipoDestino_TO pTO)
{
bool retorno = false;

try
{
retorno = new TipoDestino_DAO().Delete(pTO);
}
catch (Exception)
{
throw;
}
return retorno;
}

}
}
