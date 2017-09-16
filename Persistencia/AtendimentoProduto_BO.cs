//
// <copyright file="AtendimentoProduto_BO.cs" company="Valeverde Turismo">
//     Copyright (c) Valeverde Turismo 2017. All rights reserved.
// </copyright>
// <author>Cândido</author>
// <date>11/08/2017</date>//
using System;
using System.Collections.Generic;

namespace Persistencia.crm
{
public class AtendimentoProduto_BO
{
public List<AtendimentoProduto_TO> SearchAll(AtendimentoProduto_TO pTO)
{
string condicao = "";

try
{
// implementa a condição de procura
condicao += "";
return new AtendimentoProduto_DAO().SearchAll(condicao);
}
catch (Exception)
{
throw;
}
}

public AtendimentoProduto_TO GetByCode(AtendimentoProduto_TO pTO)
{
try
{
return new AtendimentoProduto_DAO().GetByCode(pTO);
}
catch (Exception)
{
throw;
}
}

public bool Save(bool pOpcao, AtendimentoProduto_TO pTO)
{
bool retorno = false;

try
{
if (pOpcao)
{
retorno = new AtendimentoProduto_DAO().Save(pTO);
}
else
{
retorno = new AtendimentoProduto_DAO().Update(pTO);}
}
catch (Exception)
{
throw;
}
return retorno;
}

public bool Delete(AtendimentoProduto_TO pTO)
{
bool retorno = false;

try
{
retorno = new AtendimentoProduto_DAO().Delete(pTO);
}
catch (Exception)
{
throw;
}
return retorno;
}

}
}
