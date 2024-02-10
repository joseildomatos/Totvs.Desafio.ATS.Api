using MediatR;

namespace Totvs.Desafio.ATS.Aplicacao.CasosDeUso.Vaga.AlterarVaga.Comandos;

public record AlterarVagaDtoDadosParciais
{
    public string Descricao { get; set; }
}