using MediatR;

namespace Totvs.Desafio.ATS.Aplicacao.CasosDeUso.Candidato.AlterarCandidato.Comandos;

public record AlterarCandidatoDtoDadosParciais
{
    public string Nome { get; set; }
}