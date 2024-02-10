using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Totvs.Desafio.ATS.Aplicacao.Validacoes;

namespace Totvs.Desafio.ATS.Aplicacao;

public static class InjecaoDependencia
{
    public static IServiceCollection RegistrarAplicacaoServices(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidacoesBehaviour<,>));
        return services;
    }
}