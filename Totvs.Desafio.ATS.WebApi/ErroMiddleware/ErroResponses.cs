using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Totvs.Desafio.ATS.WebApi.ErroMiddleware;

public class ErroResponses
{
    public ErroResponses()
    {
        TraceId = Guid.NewGuid().ToString();
        Erros = new List<ErroResponsesDetalhes>();
    }

    public ErroResponses(string logref, string message)
    {
        TraceId = Guid.NewGuid().ToString();
        Erros = new List<ErroResponsesDetalhes>();
        AdicionaErro(logref, message);
    }

    public string TraceId { get; private set; }
    public List<ErroResponsesDetalhes> Erros { get; private set; }

    public class ErroResponsesDetalhes
    {
        public ErroResponsesDetalhes(string logref, string message)
        {
            Logref = logref;
            Menssagem = message;
        }

        public string Logref { get; private set; }

        public string Menssagem { get; private set; }
    }

    public void AdicionaErro(string logref, string message)
    {
        Erros.Add(new ErroResponsesDetalhes(logref, message));
    }
}