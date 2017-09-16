//
// <copyright file="Status_TO.cs" company="Valeverde Turismo">
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
public class Status_TO
{
public int sta_codigo { get; set; }
public string sta_nome { get; set; }
public int sta_final { get; set; }
public List<Atendimento_TO> ListAtendimentoTO { get; set; }
public List<Historico_TO> ListHistoricoTO { get; set; }
}
}
