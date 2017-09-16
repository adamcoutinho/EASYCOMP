//
// <copyright file="Atendimento_TO.cs" company="Valeverde Turismo">
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
public class Atendimento_TO
{
public int atd_codigo { get; set; }
public Cliente_TO ClienteTO { get; set; }
public Canal_TO CanalTO { get; set; }
public Consultor_TO ConsultorTO { get; set; }
public Etapa_TO EtapaTO { get; set; }
public Status_TO StatusTO { get; set; }
public DateTime atd_datainicio { get; set; }
public DateTime atd_datafim { get; set; }
public List<AtendimentoProduto_TO> ListAtendimentoProdutoTO { get; set; }
public List<AtendimentoVenda_TO> ListAtendimentoVendaTO { get; set; }
public List<Historico_TO> ListHistoricoTO { get; set; }
public List<Interacao_TO> ListInteracaoTO { get; set; }
}
}
