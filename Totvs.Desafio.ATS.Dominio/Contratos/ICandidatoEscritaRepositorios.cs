using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Totvs.Desafio.ATS.Dominio.Entidades;

namespace Totvs.Desafio.ATS.Dominio.Interfaces;

public interface ICandidatoEscritaRepositorios
{
    Task<bool> SalvarCandidatoAsync(Candidato candidato, CancellationToken cancellationToken);
    Task<bool> DeletarCandidatoAsync(string id, CancellationToken cancellationToken);
    Task<bool> AlterarCandidatoAsync(Candidato candidato, CancellationToken cancellationToken);

    Task<Candidato> ObterCandidatoPorIdAsync(string id);
    Task<IReadOnlyCollection<Candidato>> ObterTodosOsCandidatos();
}
