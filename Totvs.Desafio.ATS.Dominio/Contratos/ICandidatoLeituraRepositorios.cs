using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Totvs.Desafio.ATS.Dominio.Entidades;

namespace Totvs.Desafio.ATS.Dominio.Interfaces;

public interface ICandidatoLeituraRepositorios
{
    //Task<Vaga> ObterPorIdAsync(string Id, CancellationToken cancellationToken);
    //Task<Vaga> ObterPorDescricaoAsync(string Descricao, CancellationToken cancellationToken);
    Task<IReadOnlyCollection<Candidato>> ObterTodosCandidatos();
}