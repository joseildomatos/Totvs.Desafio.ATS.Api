using System.Collections.Generic;
using MediatR;

namespace Totvs.Desafio.ATS.Aplicacao.CasosDeUso.Vaga.ConsultasVagas
{
    public class ObterTodosVagaQuery : IRequest<IEnumerable<Dominio.Entidades.Vaga>>
    {
    }
}