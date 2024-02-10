using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Totvs.Desafio.ATS.Dominio.Entidades;

namespace Totvs.Desafio.ATS.Dominio.Interfaces;

public interface IVagaEscritaRepositorios
{
    Task<bool> SalvarVagaAsync(Vaga vaga, CancellationToken cancellationToken);
    Task<bool> DeletarVagaAsync(string id, CancellationToken cancellationToken);
    Task<bool> AlterarVagaAsync(Vaga vaga, CancellationToken cancellationToken);

    Task<Vaga> ObterVagaPorIdAsync(string id);
    Task<IReadOnlyCollection<Vaga>> ObterTodasAsVagas();

}
