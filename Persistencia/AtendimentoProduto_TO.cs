//
// <copyright file="AtendimentoProduto_TO.cs" company="Valeverde Turismo">
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
public class AtendimentoProduto_TO
{
public int atp_codigo { get; set; }
public Atendimento_TO AtendimentoTO { get; set; }
public Produto_TO ProdutoTO { get; set; }
public decimal atp_valor { get; set; }
public Destino_TO DestinoTO { get; set; }
}
}
