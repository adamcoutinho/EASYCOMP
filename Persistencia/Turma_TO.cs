//
// <copyright file="Turma_TO.cs" company="Valeverde Turismo">
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
    public class Turma_TO
    {
        public int tur_codigo { get; set; }
        public string tur_nome { get; set; }
        public string tur_turno { get; set; }
        public DateTime tur_data_inicio { get; set; }
        public Curso_TO CursoTO { get; set; }
        public Instrutor_TO InstrutorTO { get; set; }
        public int tur_vagas { get; set; }
        public List<Matricula_TO> ListMatriculaTO { get; set; }
        public List<TurmaProgramacao_TO> ListTurmaProgramacaoTO { get; set; }
    }
}
