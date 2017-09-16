//
// <copyright file="Canal_BO.cs" company="Valeverde Turismo">
//     Copyright (c) Valeverde Turismo 2017. All rights reserved.
// </copyright>
// <author>Cândido</author>
// <date>11/08/2017</date>//
using System;
using System.Collections.Generic;

namespace Persistencia.crm
{
public class Canal_BO
{
public List<Canal_TO> SearchAll(Canal_TO pTO)
{
string condicao = "";

try
{
// implementa a condição de procura
condicao += "";
return new Canal_DAO().SearchAll(condicao);
}
catch (Exception)
{
throw;
}
}

public Canal_TO GetByCode(Canal_TO pTO)
{
try
{
return new Canal_DAO().GetByCode(pTO);
}
catch (Exception)
{
throw;
}
}

public bool Save(bool pOpcao, Canal_TO pTO)
{
bool retorno = false;

try
{
if (pOpcao)
{
retorno = new Canal_DAO().Save(pTO);
}
else
{
retorno = new Canal_DAO().Update(pTO);}
}
catch (Exception)
{
throw;
}
return retorno;
}

public bool Delete(Canal_TO pTO)
{
bool retorno = false;

try
{
retorno = new Canal_DAO().Delete(pTO);
}
catch (Exception)
{
throw;
}
return retorno;
}

}
}
