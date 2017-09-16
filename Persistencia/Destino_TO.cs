//
// <copyright file="Destino_TO.cs" company="Valeverde Turismo">
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
public class Destino_TO
{
public int des_codigo { get; set; }
public string des_nome { get; set; }
public TipoDestino_TO TipoDestinoTO { get; set; }
public Cidade_TO CidadeTO { get; set; }
public List<AtendimentoProduto_TO> ListAtendimentoProdutoTO { get; set; }
public List<AtendimentoVenda_TO> ListAtendimentoVendaTO { get; set; }
}
}
