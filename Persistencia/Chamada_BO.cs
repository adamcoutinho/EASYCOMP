//
// <copyright file="Chamada_BO.cs" company="Valeverde Turismo">
//     Copyright (c) Valeverde Turismo 2017. All rights reserved.
// </copyright>
// <author>Wilson Montelo</author>
// <date>09/08/2017</date>//
using System;
using System.Collections.Generic;

namespace Persistencia
{
    public class Chamada_BO
    {
        public List<Chamada_TO> SearchAll(Chamada_TO pTO)
        {
            string condicao = "";

            try
            {
                // implementa a condição de procura
                condicao += "";
                return new Chamada_DAO().SearchAll(condicao, pTO);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Chamada_TO GetByCode(Chamada_TO pTO)
        {
            try
            {
                return new Chamada_DAO().GetByCode(pTO);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(Chamada_TO pTO)
        {
            bool retorno = false;

            try
            {
                retorno = new Chamada_DAO().Update(pTO);
            }
            catch (Exception)
            {
                throw;
            }
            return retorno;
        }

        public bool Delete(Chamada_TO pTO)
        {
            bool retorno = false;

            try
            {
                retorno = new Chamada_DAO().Delete(pTO);
            }
            catch (Exception)
            {
                throw;
            }
            return retorno;
        }

    }
}
