using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Totvs.Desafio.ATS.Aplicacao.Mapeadores;
using Totvs.Desafio.ATS.Dominio.Interfaces;

namespace Totvs.Desafio.ATS.Aplicacao.CasosDeUso.Vaga.SalvarVaga.Comandos;

public class SalvarVagaHandler(IVagaEscritaRepositorios repositorio) : IRequestHandler<SalvarVagaComando, bool>
{      
    private readonly IVagaEscritaRepositorios _repositorio = repositorio;

    public async Task<bool> Handle(SalvarVagaComando vaga, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(_repositorio);
        ArgumentNullException.ThrowIfNull(vaga);

        var vagaConvertida = VagaMapeador.ConverteParaEntidadeSalvar(vaga);
        return await _repositorio.SalvarVagaAsync(vagaConvertida, cancellationToken);
    }
}