//
// <copyright file="Interacao_TO.cs" company="Valeverde Turismo">
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
public class Interacao_TO
{
public int int_codigo { get; set; }
public DateTime int_data_hora { get; set; }
public Canal_TO CanalTO { get; set; }
public Consultor_TO ConsultorTO { get; set; }
public Atendimento_TO AtendimentoTO { get; set; }
public text int_conteudo { get; set; }
}
}
