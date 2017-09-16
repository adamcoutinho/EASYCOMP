//
// <copyright file="Curso_BO.cs" company="Valeverde Turismo">
//     Copyright (c) Valeverde Turismo 2017. All rights reserved.
// </copyright>
// <author>Wilson Montelo</author>
// <date>09/08/2017</date>//
using System;
using System.Collections.Generic;

namespace Persistencia
{
    public class Curso_BO
    {
        /// <summary>
        /// Captura uma lista de objetos Curso_TO
        /// </summary>
        /// <param name="pTO">Objeto Curso_TO</param>
        /// <returns>lista de objetos Curso_TO</returns>
        public List<Curso_TO> SearchAll(Curso_TO pTO)
        {
            string condicao = "";

            try
            {
                // implementa a condição de procura
                condicao += "";
                return new Curso_DAO().SearchAll(condicao);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Captura um registro pelo código
        /// </summary>
        /// <param name="pTO">Objeto Curso_TO</param>
        /// <returns>Objeto Curso_TO</returns>
        public Curso_TO GetByCode(Curso_TO pTO)
        {
            try
            {
                return new Curso_DAO().GetByCode(pTO);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Save(Curso_TO pTO, bool novo)
        {
            bool retorno = false;

            try
            {
                if (novo)
                {
                    retorno = new Curso_DAO().Save(pTO);
                }
                else
                {
                    retorno = new Curso_DAO().Update(pTO);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return retorno;
        }

        public bool Delete(Curso_TO pTO)
        {
            bool retorno = false;

            try
            {
                retorno = new Curso_DAO().Delete(pTO);
            }
            catch (Exception)
            {
                throw;
            }
            return retorno;
        }

    }
}
