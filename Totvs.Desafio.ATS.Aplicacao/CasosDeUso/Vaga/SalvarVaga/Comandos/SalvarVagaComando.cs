using System;
using MediatR;

namespace Totvs.Desafio.ATS.Aplicacao.CasosDeUso.Vaga.SalvarVaga.Comandos;

public class SalvarVagaComando(string descricao) : IRequest<bool>
{
    public string Descricao { get; set; } = descricao;
}