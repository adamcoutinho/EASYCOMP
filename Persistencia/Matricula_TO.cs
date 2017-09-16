//
// <copyright file="Matricula_TO.cs" company="Valeverde Turismo">
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
    public class Matricula_TO
    {
        public int mat_codigo { get; set; }
        public Turma_TO TurmaTO { get; set; }
        public Aluno_TO AlunoTO { get; set; }
        public DateTime mat_data_matricula { get; set; }
        public List<Chamada_TO> ListChamadaTO { get; set; }
    }
}
