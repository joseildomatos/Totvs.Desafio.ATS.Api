using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Totvs.Desafio.ATS.Aplicacao.CasosDeUso.Candidato.ConsultasCandidatos;
using Totvs.Desafio.ATS.Dominio.Interfaces;

namespace Totvs.Desafio.ATS.Aplicacao.CasosDeUso.Candidato.ConsultarCandidatos
{
    public class ObterTodosCandidatosHandler(ICandidatoLeituraRepositorios repositorio) : IRequestHandler<ObterTodosCandidatosQuery, IEnumerable<Dominio.Entidades.Candidato>>
    {
        private readonly ICandidatoLeituraRepositorios _repositorio = repositorio;

        public async Task<IEnumerable<Dominio.Entidades.Candidato>> Handle(ObterTodosCandidatosQuery candidatos, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(_repositorio);
            ArgumentNullException.ThrowIfNull(candidatos);

            return await _repositorio.ObterTodosCandidatos();
        }
    }
}