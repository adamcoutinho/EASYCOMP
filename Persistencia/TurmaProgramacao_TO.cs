//
// <copyright file="TurmaProgramacao_TO.cs" company="Valeverde Turismo">
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
    public class TurmaProgramacao_TO
    {
        public int tpr_codigo { get; set; }
        public DateTime tpr_data_aula { get; set; }
        public string tpr_horas_inicial { get; set; }
        public string tpr_horas_final { get; set; }
        public Turma_TO TurmaTO { get; set; }
        public List<Chamada_TO> ListChamadaTO { get; set; }
    }
}
