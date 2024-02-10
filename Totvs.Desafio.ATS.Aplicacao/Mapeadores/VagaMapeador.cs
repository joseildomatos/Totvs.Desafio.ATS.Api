using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Totvs.Desafio.ATS.Aplicacao.CasosDeUso.Vaga.AlterarVaga.Comandos;
using Totvs.Desafio.ATS.Aplicacao.CasosDeUso.Vaga.SalvarVaga.Comandos;
using Totvs.Desafio.ATS.Dominio.Entidades;

namespace Totvs.Desafio.ATS.Aplicacao.Mapeadores
{
    public static class VagaMapeador
    {
        public static Vaga ConverteParaEntidadeSalvar(SalvarVagaComando request)
        {
            return new Vaga()
            {
                Id = ObjectId.GenerateNewId().ToString(),
                Descricao = request.Descricao,
                DataCadastro = DateTime.Now
            };
        }

        public static Vaga ConverteParaEntidadeAlterar(Vaga vagaFiltrada, AlterarVagaComando vagaNovosDados)
        {
            vagaFiltrada.Descricao = vagaNovosDados.Descricao;
            return vagaFiltrada;
        }
    }
}
