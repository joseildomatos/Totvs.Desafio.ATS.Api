using System;

using FluentValidation;
using Totvs.Desafio.ATS.Aplicacao.CasosDeUso.Candidato.AlterarCandidato.Comandos;
using Totvs.Desafio.ATS.Aplicacao.CasosDeUso.Candidato.SalvarCandidato.Comandos;

namespace Totvs.Desafio.ATS.Aplicacao.CasosDeUso.Candidato.AlterarCandidato.Comandos;

public class AlterarCandidatoComandoValidacao : AbstractValidator<SalvarCandidatoComando>
{
    public AlterarCandidatoComandoValidacao()
    {       
        RuleFor(u => u.Nome)
               .NotEmpty().WithMessage("O Nome do Candidato é obrigatório")
               .MaximumLength(50).WithMessage("O tamanho tem que ser no máximo 50 caracteres");
    }
}
