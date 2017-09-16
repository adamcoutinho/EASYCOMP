//
// <copyright file="Chamada_TO.cs" company="Valeverde Turismo">
//     Copyright (c) Valeverde Turismo 2017. All rights reserved.
// </copyright>
// <author>Wilson Montelo</author>
// <date>09/08/2017</date>
//
using System;
using System.Collections.Generic;

namespace Persistencia
{
    [Serializable]
    public class Chamada_TO
    {
        public Matricula_TO MatriculaTO { get; set; }
        public TurmaProgramacao_TO TurmaProgramacaoTO { get; set; }
        public int cha_presenca { get; set; }
    }
}
