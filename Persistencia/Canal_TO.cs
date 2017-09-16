//
// <copyright file="Canal_TO.cs" company="Valeverde Turismo">
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
public class Canal_TO
{
public int can_codigo { get; set; }
public string can_nome { get; set; }
public int can_virtual { get; set; }
public int can_facebook { get; set; }
public int can_gmail { get; set; }
public List<Atendimento_TO> ListAtendimentoTO { get; set; }
public List<Historico_TO> ListHistoricoTO { get; set; }
public List<Interacao_TO> ListInteracaoTO { get; set; }
}
}
