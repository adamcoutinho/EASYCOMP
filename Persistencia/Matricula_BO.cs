//
// <copyright file="Matricula_BO.cs" company="Valeverde Turismo">
//     Copyright (c) Valeverde Turismo 2017. All rights reserved.
// </copyright>
// <author>Wilson Montelo</author>
// <date>09/08/2017</date>//
using System;
using System.Collections.Generic;

namespace Persistencia
{
    public class Matricula_BO
    {
        public List<Matricula_TO> SearchAll(Matricula_TO pTO)
        {
            string condicao = "";

            try
            {
                // implementa a condição de procura
                condicao += "";
                return new Matricula_DAO().SearchAll(condicao);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Matricula_TO GetByCode(Matricula_TO pTO)
        {
            try
            {
                return new Matricula_DAO().GetByCode(pTO);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Save(Matricula_TO pTO, bool save)
        {
            bool retorno = false;

            try
            {
                if (save)
                {
                    retorno = new Matricula_DAO().Save(pTO);
                }
                else
                {
                    retorno = new Matricula_DAO().Update(pTO);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return retorno;
        }

        public bool Delete(Matricula_TO pTO)
        {
            bool retorno = false;

            try
            {
                retorno = new Matricula_DAO().Delete(pTO);
            }
            catch (Exception)
            {
                throw;
            }
            return retorno;
        }
    }
}
