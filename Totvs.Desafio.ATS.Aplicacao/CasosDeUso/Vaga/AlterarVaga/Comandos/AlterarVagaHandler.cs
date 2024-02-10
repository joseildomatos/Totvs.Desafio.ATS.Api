using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Totvs.Desafio.ATS.Aplicacao.Mapeadores;
using Totvs.Desafio.ATS.Dominio.Interfaces;

namespace Totvs.Desafio.ATS.Aplicacao.CasosDeUso.Vaga.AlterarVaga.Comandos;

public class AlterarVagaHandler(IVagaEscritaRepositorios repositorio) : IRequestHandler<AlterarVagaComando, bool>
{
    private readonly IVagaEscritaRepositorios _repositorio = repositorio;

    public async Task<bool> Handle(AlterarVagaComando vaga, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(_repositorio);
        ArgumentNullException.ThrowIfNull(vaga);

        var vagaFiltrada = await _repositorio.ObterVagaPorIdAsync(vaga.Id) ?? throw new Exception("Não foi localizar pelo Id informado");

        var vagaConvertida = VagaMapeador.ConverteParaEntidadeAlterar(vagaFiltrada, vaga);
        return await _repositorio.AlterarVagaAsync(vagaConvertida, cancellationToken);
    }
}