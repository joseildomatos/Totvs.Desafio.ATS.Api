using System;

using FluentValidation;
using Totvs.Desafio.ATS.Aplicacao.CasosDeUso.Candidato.AlterarCandidato.Comandos;

namespace Totvs.Desafio.ATS.Aplicacao.CasosDeUso.Candidato.SalvarCandidato.Comandos;

public class AlterarCandidatoComandoValidacao : AbstractValidator<AlterarCandidatoDtoDadosParciais>
{
    public AlterarCandidatoComandoValidacao()
    {       
        RuleFor(u => u.Nome)
               .NotEmpty().WithMessage("A NOme do candidato é obrigatório")
               .MaximumLength(50).WithMessage("O tamanho tem que ser no máximo 50 caracteres");
    }
}
