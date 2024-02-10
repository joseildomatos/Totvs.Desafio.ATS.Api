using System;
using MediatR;
using MongoDB.Bson;

namespace Totvs.Desafio.ATS.Aplicacao.CasosDeUso.Candidato.DeletarCandidato.Comandos;

public class DeletarCandidatoComando : IRequest<bool>
{
    public string Id { get; set; }
}