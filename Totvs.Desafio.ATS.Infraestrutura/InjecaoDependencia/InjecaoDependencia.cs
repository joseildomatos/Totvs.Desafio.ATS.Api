using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Totvs.Desafio.ATS.Dominio.Interfaces;
using Totvs.Desafio.ATS.Infraestrutura.Repositories;
using Totvs.Desafio.ATS.Repository.Repositorios.VagaRepositorios;
using Totvs.Desafio.ATS.Repository.Repositorios.CandidatoRepositorios;


namespace Totvs.Desafio.ATS.Infraestrutura;

public static class InjecaoDependencia
{
    public static IServiceCollection RegistrarInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IVagaEscritaRepositorios, VagaEscritaRepositorios>();
        services.AddScoped<IVagaLeituraRepositorios, VagaLeituraRepositorios>();

        services.AddScoped<ICandidatoLeituraRepositorios, CandidatoLeituraRepositorios>();
        services.AddScoped<ICandidatoEscritaRepositorios, CandidatoEscritaRepositorios>();

        return services;
    }
}