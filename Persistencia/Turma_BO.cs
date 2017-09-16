//
// <copyright file="Turma_BO.cs" company="Valeverde Turismo">
//     Copyright (c) Valeverde Turismo 2017. All rights reserved.
// </copyright>
// <author>Wilson Montelo</author>
// <date>09/08/2017</date>//
using System;
using System.Collections.Generic;

namespace Persistencia
{
    public class Turma_BO
    {
        public List<Turma_TO> SearchAll(Turma_TO pTO)
        {
            string condicao = "";

            try
            {
                // implementa a condição de procura
                if (pTO.CursoTO != null)
                    condicao += " AND curso.cur_codigo = " + pTO.CursoTO.cur_codigo;

                return new Turma_DAO().SearchAll(condicao);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Turma_TO GetByCode(Turma_TO pTO)
        {
            try
            {
                return new Turma_DAO().GetByCode(pTO);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Save(Turma_TO pTO, bool save)
        {
            bool retorno = false;

            try
            {
                if (save)
                {
                    retorno = new Turma_DAO().Save(pTO);
                }
                else
                {
                    retorno = new Turma_DAO().Update(pTO);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return retorno;
        }

        public bool Delete(Turma_TO pTO)
        {
            bool retorno = false;

            try
            {
                retorno = new Turma_DAO().Delete(pTO);
            }
            catch (Exception)
            {
                throw;
            }
            return retorno;
        }

    }
}
