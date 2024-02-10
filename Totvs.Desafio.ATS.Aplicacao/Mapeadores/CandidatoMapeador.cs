using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Totvs.Desafio.ATS.Aplicacao.CasosDeUso.Candidato.AlterarCandidato.Comandos;
using Totvs.Desafio.ATS.Aplicacao.CasosDeUso.Candidato.SalvarCandidato.Comandos;
using Totvs.Desafio.ATS.Dominio.Entidades;

namespace Totvs.Desafio.ATS.Aplicacao.Mapeadores
{
    public static class CandidatoMapeador
    {
        public static Candidato ConverteParaEntidadeSalvar(SalvarCandidatoComando request)
        {
            return new Candidato()
            {
                Id = ObjectId.GenerateNewId().ToString(),
                Nome = request.Nome,
                DataCadastro = DateTime.Now
            };
        }

        public static Candidato ConverteParaEntidadeAlterar(Candidato candidatoFiltrada, AlterarCandidatoComando CandidatoNovosDados)
        {
            candidatoFiltrada.Nome = CandidatoNovosDados.Nome;
            return candidatoFiltrada;
        }
    }
}
