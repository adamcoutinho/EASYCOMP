//
// <copyright file="Instrutor_BO.cs" company="Valeverde Turismo">
//     Copyright (c) Valeverde Turismo 2017. All rights reserved.
// </copyright>
// <author>Wilson Montelo</author>
// <date>09/08/2017</date>//
using System;
using System.Collections.Generic;

namespace Persistencia
{
    public class Instrutor_BO
    {
        public List<Instrutor_TO> SearchAll(Instrutor_TO pTO)
        {
            string condicao = "";

            try
            {
                // implementa a condição de procura
                condicao += "";
                return new Instrutor_DAO().SearchAll(condicao);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Instrutor_TO GetByCode(Instrutor_TO pTO)
        {
            try
            {
                return new Instrutor_DAO().GetByCode(pTO);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Save(Instrutor_TO pTO, bool novo)
        {
            bool retorno = false;

            try
            {
                if (novo)
                {
                    retorno = new Instrutor_DAO().Save(pTO);
                }
                else
                {
                    retorno = new Instrutor_DAO().Update(pTO);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return retorno;
        }

        public bool Delete(Instrutor_TO pTO)
        {
            bool retorno = false;

            try
            {
                retorno = new Instrutor_DAO().Delete(pTO);
            }
            catch (Exception)
            {
                throw;
            }
            return retorno;
        }

    }
}
