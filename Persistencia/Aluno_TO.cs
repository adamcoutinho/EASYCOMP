//
// <copyright file="Aluno_TO.cs" company="Valeverde Turismo">
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
    public class Aluno_TO
    {
        public int alu_codigo { get; set; }
        public string alu_nome { get; set; }
        public int alu_telefone { get; set; }
        public string alu_email { get; set; }
        public DateTime alu_data_nascimento { get; set; }
        public string alu_endereco { get; set; }
        public string alu_bairro { get; set; }
        public string alu_cpf { get; set; }
        public List<Matricula_TO> ListMatriculaTO { get; set; }
    }
}
