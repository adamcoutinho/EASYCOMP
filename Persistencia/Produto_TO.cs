//
// <copyright file="Produto_TO.cs" company="Valeverde Turismo">
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
public class Produto_TO
{
public int pro_codigo { get; set; }
public string pro_nome { get; set; }
public char pro_ambito { get; set; }
public string pro_nome_longo { get; set; }
public decimal pro_valor_minimo { get; set; }
public decimal pro_valor_maximo { get; set; }
public decimal pro_valor_medio { get; set; }
public List<AtendimentoProduto_TO> ListAtendimentoProdutoTO { get; set; }
public List<AtendimentoVenda_TO> ListAtendimentoVendaTO { get; set; }
public List<Historico_TO> ListHistoricoTO { get; set; }
}
}
