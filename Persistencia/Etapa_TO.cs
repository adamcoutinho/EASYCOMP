//
// <copyright file="Etapa_TO.cs" company="Valeverde Turismo">
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
public class Etapa_TO
{
public int eta_codigo { get; set; }
public string eta_nome { get; set; }
public int eta_final { get; set; }
public List<Atendimento_TO> ListAtendimentoTO { get; set; }
public List<Historico_TO> ListHistoricoTO { get; set; }
}
}
