//
// <copyright file="Aluno_BO.cs" company="Valeverde Turismo">
//     Copyright (c) Valeverde Turismo 2017. All rights reserved.
// </copyright>
// <author>Wilson Montelo</author>
// <date>09/08/2017</date>//
using System;
using System.Collections.Generic;

namespace Persistencia
{
    public class Aluno_BO
    {
        public List<Aluno_TO> SearchAll(Aluno_TO pTO)
        {
            string condicao = "";
            List<Aluno_TO> collection = new List<Aluno_TO>();

            try
            {
                // implementa a condição de procura
                condicao = "";
                //return new Aluno_DAO().SearchAll(condicao);
                collection = new Aluno_DAO().SearchAll(condicao);
            }
            catch (Exception)
            {
                throw;
            }
            return collection;
        }

        public Aluno_TO GetByCode(Aluno_TO pTO)
        {
            try
            {
                return new Aluno_DAO().GetByCode(pTO);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Save(Aluno_TO pTO, bool save)
        {
            bool retorno = false;

            try
            {
                if (save)
                {
                    retorno = new Aluno_DAO().Save(pTO);
                }
                else
                {
                    retorno = new Aluno_DAO().Update(pTO);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return retorno;
        }

        public bool Delete(Aluno_TO pTO)
        {
            bool retorno = false;

            try
            {
                retorno = new Aluno_DAO().Delete(pTO);
            }
            catch (Exception)
            {
                throw;
            }
            return retorno;
        }
    }
}
