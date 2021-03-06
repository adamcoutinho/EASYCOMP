﻿//
// <copyright file="Historico_BO.cs" company="Valeverde Turismo">
//     Copyright (c) Valeverde Turismo 2017. All rights reserved.
// </copyright>
// <author>Cândido</author>
// <date>11/08/2017</date>//
using System;
using System.Collections.Generic;

namespace Persistencia.crm
{
public class Historico_BO
{
public List<Historico_TO> SearchAll(Historico_TO pTO)
{
string condicao = "";

try
{
// implementa a condição de procura
condicao += "";
return new Historico_DAO().SearchAll(condicao);
}
catch (Exception)
{
throw;
}
}

public Historico_TO GetByCode(Historico_TO pTO)
{
try
{
return new Historico_DAO().GetByCode(pTO);
}
catch (Exception)
{
throw;
}
}

public bool Save(bool pOpcao, Historico_TO pTO)
{
bool retorno = false;

try
{
if (pOpcao)
{
retorno = new Historico_DAO().Save(pTO);
}
else
{
retorno = new Historico_DAO().Update(pTO);}
}
catch (Exception)
{
throw;
}
return retorno;
}

public bool Delete(Historico_TO pTO)
{
bool retorno = false;

try
{
retorno = new Historico_DAO().Delete(pTO);
}
catch (Exception)
{
throw;
}
return retorno;
}

}
}
