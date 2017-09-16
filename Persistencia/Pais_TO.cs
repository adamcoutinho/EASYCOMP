//
// <copyright file="Pais_TO.cs" company="Valeverde Turismo">
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
public class Pais_TO
{
public int pai_codigo { get; set; }
public string pai_nome { get; set; }
public string pai_continente { get; set; }
public List<Cidade_TO> ListCidadeTO { get; set; }
}
}
