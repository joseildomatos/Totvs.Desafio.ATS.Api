using MediatR;

namespace Totvs.Desafio.ATS.Aplicacao.CasosDeUso.Candidato.AlterarCandidato.Comandos;

public class AlterarCandidatoComando : IRequest<bool>
{
    public string Id { get; set; }
    public string Nome { get; set; }
}