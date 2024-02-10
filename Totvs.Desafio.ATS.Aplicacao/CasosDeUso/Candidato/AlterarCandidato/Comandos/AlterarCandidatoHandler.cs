using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Totvs.Desafio.ATS.Aplicacao.CasosDeUso.Candidato.AlterarCandidato.Comandos;
using Totvs.Desafio.ATS.Aplicacao.Mapeadores;
using Totvs.Desafio.ATS.Dominio.Entidades;
using Totvs.Desafio.ATS.Dominio.Interfaces;

namespace Totvs.Desafio.ATS.Aplicacao.CasosDeUso.Candidato.AlterarCandidato.Comandos;

public class AlterarCandidatoHandler(ICandidatoEscritaRepositorios repositorio) : IRequestHandler<AlterarCandidatoComando, bool>
{
    private readonly ICandidatoEscritaRepositorios _repositorio = repositorio;

    public async Task<bool> Handle(AlterarCandidatoComando candidato, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(_repositorio);
        ArgumentNullException.ThrowIfNull(candidato);

        var candidatoFiltrado = await _repositorio.ObterCandidatoPorIdAsync(candidato.Id) ?? throw new Exception("Não foi localizar pelo Id informado");

        var candidatoConvertido = CandidatoMapeador.ConverteParaEntidadeAlterar(candidatoFiltrado, candidato);
        return await _repositorio.AlterarCandidatoAsync(candidatoConvertido, cancellationToken);
    }
}