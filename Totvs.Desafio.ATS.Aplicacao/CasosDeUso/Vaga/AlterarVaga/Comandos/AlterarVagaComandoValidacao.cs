using System;

using FluentValidation;
using Totvs.Desafio.ATS.Aplicacao.CasosDeUso.Vaga.AlterarVaga.Comandos;

namespace Totvs.Desafio.ATS.Aplicacao.CasosDeUso.Vaga.SalvarVaga.Comandos;

public class AlterarVagaComandoValidacao : AbstractValidator<AlterarVagaDtoDadosParciais>
{
    public AlterarVagaComandoValidacao()
    {       
        RuleFor(u => u.Descricao)
               .NotEmpty().WithMessage("A descrição da vaga é obrigatória")
               .MaximumLength(50).WithMessage("O tamanho tem que ser no máximo 50 caracteres");
    }
}
