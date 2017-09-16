//
// <copyright file="Consultor_TO.cs" company="Valeverde Turismo">
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
public class Consultor_TO
{
public int con_codigo { get; set; }
public int con_codstur { get; set; }
public string con_nome { get; set; }
public int con_virtual { get; set; }
public List<Atendimento_TO> ListAtendimentoTO { get; set; }
public List<Historico_TO> ListHistoricoTO { get; set; }
public List<Interacao_TO> ListInteracaoTO { get; set; }
}
}
