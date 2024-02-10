using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Totvs.Desafio.ATS.Aplicacao.CasosDeUso.Vaga.AlterarVaga.Comandos;
using Totvs.Desafio.ATS.Aplicacao.CasosDeUso.Vaga.ConsultarVagas;
using Totvs.Desafio.ATS.Aplicacao.CasosDeUso.Vaga.ConsultasVagas;
using Totvs.Desafio.ATS.Aplicacao.CasosDeUso.Vaga.DeletarVaga.Comandos;
using Totvs.Desafio.ATS.Aplicacao.CasosDeUso.Vaga.SalvarVaga.Comandos;
using Totvs.Desafio.ATS.WebApi.Constantes;

namespace Totvs.Desafio.ATS.WebApi.Controllers
{
    /// <summary>
    /// Cont�m as rotas relacionadas aos endpoints para manuten��o dsd Vagas de trabalho.
    /// </summary>
    [ApiController]
    [Route("api/vaga")]
    [Produces(MediaTypeNames.Application.Json)]
    public class VagaController(IMediator mediator) : Controller
    {
        private readonly IMediator _mediator = mediator;
        
        /// <summary>
        /// Cadastra uma novo Vaga de trabalho.
        /// </summary>
        /// <param name="vaga">A requisi��o que cont�m os dados a serem cadastrais.</param>
        /// <param name="cancellationToken">Token de cancelamento da opera��o.</param>
        /// <returns>Os dados da Vaga cadastrada, se bem sucedido, ou o detalhe do erro, caso contr�rio.</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<ActionResult<string>> SalvarVagaAsync([FromBody] SalvarVagaComando vaga, CancellationToken cancellationToken)
        {
            var retorno = await _mediator.Send(vaga, cancellationToken); 
            return retorno ? VagaConstantes.VagaCriadaComSucesso: VagaConstantes.FalhaCriacaoVaga;
        }

        /// <summary>
        /// Altera uma Vaga de trabalho.
        /// </summary>
        /// <param name="id">Requisi��o que cont�m o retorno da remo��o.</param>
        /// <param name="novosDadosVaga">A requisi��o que cont�m os dados a serem alterados</param>
        /// <param name="cancellationToken">Token de cancelamento da opera��o.</param>
        /// <returns>Os dados da Alteracao da Vaga, se bem sucedido, ou o detalhe do erro, caso contr�rio.</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut("{id}")]
        public async Task<ActionResult<string>> AltetarVagaAsync(string id, AlterarVagaDtoDadosParciais novosDadosVaga, CancellationToken cancellationToken)
        {
            var retorno = await _mediator.Send(new AlterarVagaComando() { Id = id, Descricao = novosDadosVaga.Descricao }, cancellationToken);
            return retorno ? VagaConstantes.VagaAlteradaComSucesso : VagaConstantes.FalhaAlteracaoVaga;
        }


        /// <summary>
        /// Remove uma Vaga de trabalho.
        /// </summary>
        /// <param name="id">id da vaga.</param>
        /// <param name="cancellationToken">Token de cancelamento da opera��o.</param>
        /// <returns>Os dados da remo��o da Vaga, se bem sucedido, ou o detalhe do erro, caso contr�rio.</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeletarVagaAsync(string id, CancellationToken cancellationToken)
        {
            var retorno = await _mediator.Send(new DeletarVagaComando() { Id = id }, cancellationToken);
            return retorno ? VagaConstantes.VagaDeletadaComSucesso : VagaConstantes.FalhaDelecaoVaga;
        }


        /// <summary>
        /// Lista todas as vagas.
        /// </summary>
        /// <param name="cancellationToken">Token de cancelamento da opera��o.</param>
        /// <returns>Os dados da Vaga cadastrada, se bem sucedido, ou o detalhe do erro, caso contr�rio.</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dominio.Entidades.Vaga>>> ListarTodasVagas(CancellationToken cancellationToken)
        {
            var retorno = await _mediator.Send(new ObterTodosVagaQuery(), cancellationToken);
            if (retorno != null)
            {
                return Ok(retorno);
            }
            return NotFound();           
        }
    }
}