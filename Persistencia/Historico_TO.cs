//
// <copyright file="Historico_TO.cs" company="Valeverde Turismo">
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
public class Historico_TO
{
public int his_codigo { get; set; }
public Atendimento_TO AtendimentoTO { get; set; }
public int his_sequencial { get; set; }
public Etapa_TO EtapaTO { get; set; }
public Status_TO StatusTO { get; set; }
public DateTime his_data { get; set; }
public time his_hora { get; set; }
public Consultor_TO ConsultorTO { get; set; }
public int his_mudouconsultor { get; set; }
public Produto_TO ProdutoTO { get; set; }
public int his_mudouproduto { get; set; }
public Canal_TO CanalTO { get; set; }
public int his_mudoucanal { get; set; }
public int his_usuario { get; set; }
}
}
