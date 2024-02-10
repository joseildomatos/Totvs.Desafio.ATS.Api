using System;
using MediatR;

namespace Totvs.Desafio.ATS.Aplicacao.CasosDeUso.Candidato.SalvarCandidato.Comandos;

public class SalvarCandidatoComando(string nome) : IRequest<bool>
{
    public string Nome { get; set; } = nome;
}
