using System;
using MediatR;
using MongoDB.Bson;

namespace Totvs.Desafio.ATS.Aplicacao.CasosDeUso.Vaga.DeletarVaga.Comandos;

public class DeletarVagaComando : IRequest<bool>
{
    public string Id { get; set; }
}