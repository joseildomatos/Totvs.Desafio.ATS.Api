using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Totvs.Desafio.ATS.Aplicacao.Validacoes;

public class ValidacoesExcecoes : Exception
{
    public ValidacoesExcecoes() : base("Uma ou mais exceções ocorreram")
    {
        Errors = new Dictionary<string, string[]>();
    }

    public ValidacoesExcecoes(IEnumerable<ValidationFailure> failures) : this()
    {
        Errors = failures
            .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
            .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
    }

    public IDictionary<string, string[]> Errors { get; }
}
