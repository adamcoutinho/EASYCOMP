//
// <copyright file="Cliente_TO.cs" company="Valeverde Turismo">
//     Copyright (c) Valeverde Turismo 2017. All rights reserved.
// </copyright>
// <author>Cândido</author>
// <date>11/08/2017</date>
//
using System;
using System.Collections.Generic;

namespace Persistencia.crm
{
[Serializable]
public class Cliente_TO
{
public int cli_codigo { get; set; }
public string cli_nome { get; set; }
public string cli_email { get; set; }
public string cli_celular { get; set; }
public int cli_lead { get; set; }
public string cli_logradouro { get; set; }
public int cli_numero { get; set; }
public Cidade_TO CidadeTO { get; set; }
public int cli_codstur { get; set; }
public string cli_telefone { get; set; }
public List<Atendimento_TO> ListAtendimentoTO { get; set; }
}
}
