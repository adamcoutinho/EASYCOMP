//
// <copyright file="Curso_TO.cs" company="Valeverde Turismo">
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
    public class Curso_TO
    {
        public int cur_codigo { get; set; }
        public string cur_nome { get; set; }
        public string cur_descricao { get; set; }
        public int cur_duracao { get; set; }
        public List<Turma_TO> ListTurmaTO { get; set; }
    }
}
