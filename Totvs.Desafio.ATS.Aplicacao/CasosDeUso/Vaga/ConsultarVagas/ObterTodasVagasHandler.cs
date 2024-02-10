using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Totvs.Desafio.ATS.Aplicacao.CasosDeUso.Vaga.ConsultasVagas;
using Totvs.Desafio.ATS.Dominio.Entidades;
using Totvs.Desafio.ATS.Dominio.Interfaces;

namespace Totvs.Desafio.ATS.Aplicacao.CasosDeUso.Vaga.ConsultarVagas
{
    public class ObterTodosVagaHandler(IVagaLeituraRepositorios repositorio) : IRequestHandler<ObterTodosVagaQuery, IEnumerable<Dominio.Entidades.Vaga>>
    {
        private readonly IVagaLeituraRepositorios _repositorio = repositorio;

        public async Task<IEnumerable<Dominio.Entidades.Vaga>> Handle(ObterTodosVagaQuery vagas, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(_repositorio);
            ArgumentNullException.ThrowIfNull(vagas);

            return await _repositorio.ObterTodasAsVagas();
        }
    }
}