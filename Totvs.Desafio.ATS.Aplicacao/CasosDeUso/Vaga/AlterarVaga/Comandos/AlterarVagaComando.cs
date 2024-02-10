using MediatR;

namespace Totvs.Desafio.ATS.Aplicacao.CasosDeUso.Vaga.AlterarVaga.Comandos;

public class AlterarVagaComando : IRequest<bool>
{ 
    public string Id { get; set; }
    public string Descricao { get; set; }
}