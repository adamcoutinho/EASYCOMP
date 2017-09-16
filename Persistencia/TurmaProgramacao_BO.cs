//
// <copyright file="TurmaProgramacao_BO.cs" company="Valeverde Turismo">
//     Copyright (c) Valeverde Turismo 2017. All rights reserved.
// </copyright>
// <author>Wilson Montelo</author>
// <date>09/08/2017</date>//
using System;
using System.Collections.Generic;
using System.Transactions;
using Persistencia;

namespace Persistencia
{
    public class TurmaProgramacao_BO
    {
        public List<TurmaProgramacao_TO> SearchAll(TurmaProgramacao_TO pTO)
        {
            string condicao = "";

            try
            {
                // implementa a condição de procura
                condicao += "";
                return new TurmaProgramacao_DAO().SearchAll(condicao);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TurmaProgramacao_TO GetByCode(TurmaProgramacao_TO pTO)
        {
            try
            {
                return new TurmaProgramacao_DAO().GetByCode(pTO);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Save(TurmaProgramacao_TO pTO, bool novo)
        {
            bool retorno = false;

            try
            {
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    if (novo)
                    {
                        if (new TurmaProgramacao_DAO().Save(pTO))
                        {
                            string condicao = string.Format(" AND turma.tur_codigo = {0}", pTO.TurmaTO.tur_codigo);

                            List<Matricula_TO> ListMatriculaTO = new Matricula_DAO().SearchAll(condicao);

                            foreach (Matricula_TO mat in ListMatriculaTO)
                            {
                                Chamada_TO ChamadaTO = new Chamada_TO();
                                ChamadaTO.MatriculaTO = mat;
                                ChamadaTO.TurmaProgramacaoTO = pTO;

                                retorno = new Chamada_DAO().Save(ChamadaTO);
                            }                            
                        }
                    }
                    else
                    {
                        retorno = new TurmaProgramacao_DAO().Update(pTO);
                    }

                    if (retorno)
                        ts.Complete();
                    else
                        ts.Dispose();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return retorno;
        }

        public bool Delete(TurmaProgramacao_TO pTO)
        {
            bool retorno = false;
            try
            {
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {                   
                    if (new Chamada_DAO().Delete(pTO))
                    {
                        retorno = new TurmaProgramacao_DAO().Delete(pTO);
                    }
                    if (retorno)
                        ts.Complete();
                    else
                        ts.Dispose();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return retorno;
        }

    }
}
