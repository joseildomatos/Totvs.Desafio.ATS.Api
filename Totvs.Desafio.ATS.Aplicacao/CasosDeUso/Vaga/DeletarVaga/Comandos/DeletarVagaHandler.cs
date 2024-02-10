using MediatR;
using MongoDB.Bson;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Totvs.Desafio.ATS.Aplicacao.Mapeadores;
using Totvs.Desafio.ATS.Dominio.Interfaces;

namespace Totvs.Desafio.ATS.Aplicacao.CasosDeUso.Vaga.DeletarVaga.Comandos;

public class DeletarVagaHandler(IVagaEscritaRepositorios repositorio) : IRequestHandler<DeletarVagaComando, bool>
{
    private readonly IVagaEscritaRepositorios _repositorio = repositorio;

    public async Task<bool> Handle(DeletarVagaComando vaga, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(_repositorio);
        ArgumentNullException.ThrowIfNull(vaga);

        return await _repositorio.DeletarVagaAsync(vaga.Id, cancellationToken);
    }
}