using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Totvs.Desafio.ATS.Aplicacao.Mapeadores;
using Totvs.Desafio.ATS.Dominio.Interfaces;

namespace Totvs.Desafio.ATS.Aplicacao.CasosDeUso.Candidato.SalvarCandidato.Comandos;

public class SalvarCandidatoHandler(ICandidatoEscritaRepositorios repositorio) : IRequestHandler<SalvarCandidatoComando, bool>
{      
    private readonly ICandidatoEscritaRepositorios _repositorio = repositorio;

    public async Task<bool> Handle(SalvarCandidatoComando Candidato, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(_repositorio);
        ArgumentNullException.ThrowIfNull(Candidato);

        var CandidatoConvertida = CandidatoMapeador.ConverteParaEntidadeSalvar(Candidato);
        return await _repositorio.SalvarCandidatoAsync(CandidatoConvertida, cancellationToken);
    }
}