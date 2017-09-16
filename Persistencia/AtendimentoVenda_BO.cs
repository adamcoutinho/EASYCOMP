//
// <copyright file="AtendimentoVenda_BO.cs" company="Valeverde Turismo">
//     Copyright (c) Valeverde Turismo 2017. All rights reserved.
// </copyright>
// <author>Cândido</author>
// <date>11/08/2017</date>//
using System;
using System.Collections.Generic;

namespace Persistencia.crm
{
public class AtendimentoVenda_BO
{
public List<AtendimentoVenda_TO> SearchAll(AtendimentoVenda_TO pTO)
{
string condicao = "";

try
{
// implementa a condição de procura
condicao += "";
return new AtendimentoVenda_DAO().SearchAll(condicao);
}
catch (Exception)
{
throw;
}
}

public AtendimentoVenda_TO GetByCode(AtendimentoVenda_TO pTO)
{
try
{
return new AtendimentoVenda_DAO().GetByCode(pTO);
}
catch (Exception)
{
throw;
}
}

public bool Save(bool pOpcao, AtendimentoVenda_TO pTO)
{
bool retorno = false;

try
{
if (pOpcao)
{
retorno = new AtendimentoVenda_DAO().Save(pTO);
}
else
{
retorno = new AtendimentoVenda_DAO().Update(pTO);}
}
catch (Exception)
{
throw;
}
return retorno;
}

public bool Delete(AtendimentoVenda_TO pTO)
{
bool retorno = false;

try
{
retorno = new AtendimentoVenda_DAO().Delete(pTO);
}
catch (Exception)
{
throw;
}
return retorno;
}

}
}
