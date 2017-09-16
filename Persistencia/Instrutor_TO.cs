//
// <copyright file="Instrutor_TO.cs" company="Valeverde Turismo">
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
    public class Instrutor_TO
    {
        public int ins_codigo { get; set; }
        public int ins_rg { get; set; }
        public string ins_nome { get; set; }
        public string ins_descricao { get; set; }
        public DateTime ins_data_nascimento { get; set; }
        public string ins_email { get; set; }
        public int ins_telefone { get; set; }
        public List<Turma_TO> ListTurmaTO { get; set; }
    }
}
