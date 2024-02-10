using System.Collections.Generic;
using MediatR;

namespace Totvs.Desafio.ATS.Aplicacao.CasosDeUso.Candidato.ConsultasCandidatos
{
    public class ObterTodosCandidatosQuery : IRequest<IEnumerable<Dominio.Entidades.Candidato>>
    {
    }
}