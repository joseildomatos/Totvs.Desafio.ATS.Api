using MediatR;
using MongoDB.Bson;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Totvs.Desafio.ATS.Aplicacao.Mapeadores;
using Totvs.Desafio.ATS.Dominio.Interfaces;

namespace Totvs.Desafio.ATS.Aplicacao.CasosDeUso.Candidato.DeletarCandidato.Comandos;

public class DeletarCandidatoHandler(ICandidatoEscritaRepositorios repositorio) : IRequestHandler<DeletarCandidatoComando, bool>
{
    private readonly ICandidatoEscritaRepositorios _repositorio = repositorio;

    public async Task<bool> Handle(DeletarCandidatoComando Candidato, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(_repositorio);
        ArgumentNullException.ThrowIfNull(Candidato);

        return await _repositorio.DeletarCandidatoAsync(Candidato.Id, cancellationToken);
    }
}