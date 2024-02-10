using AutoMapper;
using Moq;
using Totvs.Desafio.ATS.Aplicacao.CasosDeUso.Candidato.AlterarCandidato.Comandos;
using Totvs.Desafio.ATS.Aplicacao.CasosDeUso.Candidato.SalvarCandidato.Comandos;
using Totvs.Desafio.ATS.Dominio.Interfaces;
using Totvs.Desafio.ATS.Repository.Repositorios.CandidatoRepositorios;

namespace Totvs.Desafio.ATS.Testes.Candidato;

public class SalvarCandidatoComandoTestes

{
    [Fact]
    public async Task Command_Salvar_Validido_Executado_Successo()
    {
        var candidato = new Dominio.Entidades.Candidato() { Nome = "Joseildo Matos dos Santos" };
        var candidatoEscritaRepositorios = new Mock<ICandidatoEscritaRepositorios>();
        var salvarCandidatoComando = new SalvarCandidatoComando(candidato.Nome);

        candidatoEscritaRepositorios.Setup(pr => pr.SalvarCandidatoAsync(It.IsAny<Dominio.Entidades.Candidato>(), new CancellationToken())).Returns(Task.FromResult(true));
        var salvarCandidatoHandler = new SalvarCandidatoHandler(candidatoEscritaRepositorios.Object);

        bool candidatoResult = await salvarCandidatoHandler.Handle(salvarCandidatoComando, new CancellationToken());

        // Assert
        candidatoEscritaRepositorios.Verify(pr => pr.SalvarCandidatoAsync(It.IsAny<Dominio.Entidades.Candidato>(), new CancellationToken()), Times.Once);
        Assert.NotNull(candidatoResult);
        Assert.Equal(true, candidatoResult);
    }
}
