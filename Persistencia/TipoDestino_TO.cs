//
// <copyright file="TipoDestino_TO.cs" company="Valeverde Turismo">
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
public class TipoDestino_TO
{
public int tde_codigo { get; set; }
public string tde_nome { get; set; }
public string tde_descricao { get; set; }
public int tde_e_cidade { get; set; }
public List<Destino_TO> ListDestinoTO { get; set; }
}
}
