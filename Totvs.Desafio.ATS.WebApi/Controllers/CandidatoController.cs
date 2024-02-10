using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Totvs.Desafio.ATS.Aplicacao.CasosDeUso.Candidato.AlterarCandidato.Comandos;
using Totvs.Desafio.ATS.Aplicacao.CasosDeUso.Candidato.ConsultarCandidatos;
using Totvs.Desafio.ATS.Aplicacao.CasosDeUso.Candidato.ConsultasCandidatos;
using Totvs.Desafio.ATS.Aplicacao.CasosDeUso.Candidato.DeletarCandidato.Comandos;
using Totvs.Desafio.ATS.Aplicacao.CasosDeUso.Candidato.SalvarCandidato.Comandos;
using Totvs.Desafio.ATS.WebApi.Constantes;

namespace Totvs.Desafio.ATS.WebApi.Controllers
{
    /// <summary>
    /// Contém as rotas relacionadas aos endpoints para manutenção dsd Candidatos de trabalho.
    /// </summary>
    [ApiController]
    [Route("api/candidato")]
    [Produces(MediaTypeNames.Application.Json)]
    public class CandidatoController(IMediator mediator) : Controller
    {
        private readonly IMediator _mediator = mediator;

        /// <summary>
        /// Cadastra um novo Candidato.
        /// </summary>
        /// <param name="candidato">A requisição que contém os dados a serem cadastrais.</param>
        /// <param name="cancellationToken">Token de cancelamento da operação.</param>
        /// <returns>Os dados do Candidato cadastrado, se bem sucedido, ou o detalhe do erro, caso contrário.</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<ActionResult<string>> SalvarCandidatoAsync([FromBody] SalvarCandidatoComando candidato, CancellationToken cancellationToken)
        {
            var retorno = await _mediator.Send(candidato, cancellationToken); 
            return retorno ? CandidatoConstantes.CandidatoCriadoComSucesso: CandidatoConstantes.FalhaCriacaoCandidato;
        }

        /// <summary>
        /// Altera um Candidato.
        /// </summary>
        /// <param name="id">Id do candidato.</param>
        /// <param name="novosDadosCandidato">A requisição que contém os dados a serem alterados</param>
        /// <param name="cancellationToken">Token de cancelamento da operação.</param>
        /// <returns>Os dados da Alteracao do Candidato, se bem sucedido, ou o detalhe do erro, caso contrário.</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut("{id}")]
        public async Task<ActionResult<string>> AltetarCandidatoAsync(string id, AlterarCandidatoDtoDadosParciais novosDadosCandidato, CancellationToken cancellationToken)
        {
            var retorno = await _mediator.Send(new AlterarCandidatoComando() { Id = id, Nome = novosDadosCandidato.Nome }, cancellationToken);
            return retorno ? CandidatoConstantes.CandidatoAlteradoComSucesso : CandidatoConstantes.FalhaAlteracaoCandidato;
        }


        /// <summary>
        /// Remove um Candidato.
        /// </summary>
        /// <param name="id">id do candidato.</param>
        /// <param name="cancellationToken">Token de cancelamento da operação.</param>
        /// <returns>Os dados da remoção do Candidato, se bem sucedido, ou o detalhe do erro, caso contrário.</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeletarCandidatoAsync(string id, CancellationToken cancellationToken)
        {
            var retorno = await _mediator.Send(new DeletarCandidatoComando() { Id = id }, cancellationToken);
            return retorno ? CandidatoConstantes.CandidatoDeletadoComSucesso : CandidatoConstantes.FalhaDelecaoCandidato;
        }


        /// <summary>
        /// Lista todas as Candidatos.
        /// </summary>
        /// <param name="cancellationToken">Token de cancelamento da operação.</param>
        /// <returns>Os dados da Candidato cadastrada, se bem sucedido, ou o detalhe do erro, caso contrário.</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dominio.Entidades.Candidato>>> ListarTodasCandidatos(CancellationToken cancellationToken)
        {
            var retorno = await _mediator.Send(new ObterTodosCandidatosQuery(), cancellationToken);
            if (retorno != null)
            {
                return Ok(retorno);
            }
            return NotFound();           
        }
    }
}