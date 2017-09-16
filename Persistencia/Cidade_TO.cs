//
// <copyright file="Cidade_TO.cs" company="Valeverde Turismo">
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
public class Cidade_TO
{
public int cid_codigo { get; set; }
public string cid_nome { get; set; }
public string cid_estado { get; set; }
public int cid_ddd { get; set; }
public Pais_TO PaisTO { get; set; }
public List<Cliente_TO> ListClienteTO { get; set; }
public List<Destino_TO> ListDestinoTO { get; set; }
}
}
