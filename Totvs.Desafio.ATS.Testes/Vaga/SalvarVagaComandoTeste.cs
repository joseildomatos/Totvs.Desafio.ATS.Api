using AutoMapper;
using Moq;
using Totvs.Desafio.ATS.Aplicacao.CasosDeUso.Vaga.AlterarVaga.Comandos;
using Totvs.Desafio.ATS.Aplicacao.CasosDeUso.Vaga.SalvarVaga.Comandos;
using Totvs.Desafio.ATS.Dominio.Interfaces;
using Totvs.Desafio.ATS.Repository.Repositorios.VagaRepositorios;
using Totvs.Desafio.ATS.WebApi.Controllers;

namespace Totvs.Desafio.ATS.Testes.Vaga;

public class SalvarVagaComandoTestes

{
    [Fact]
    public async Task Command_Salvar_Validido_Executado_Successo()
    {
        var vaga = new Dominio.Entidades.Vaga() { Descricao = "Diretor de Sistemas" };
        var vagaEscritaRepositorios = new Mock<IVagaEscritaRepositorios>();
        var salvarVagaComando = new SalvarVagaComando(vaga.Descricao);

        vagaEscritaRepositorios.Setup(pr => pr.SalvarVagaAsync(It.IsAny<Dominio.Entidades.Vaga>(), new CancellationToken())).Returns(Task.FromResult(true));
        var salvarVagaHandler = new SalvarVagaHandler(vagaEscritaRepositorios.Object);

        bool vagaResult = await salvarVagaHandler.Handle(salvarVagaComando, new CancellationToken());

        // Assert
        vagaEscritaRepositorios.Verify(pr => pr.SalvarVagaAsync(It.IsAny<Dominio.Entidades.Vaga>(), new CancellationToken()), Times.Once);
        Assert.NotNull(vagaResult);
        Assert.Equal(true, vagaResult);
    }
}
