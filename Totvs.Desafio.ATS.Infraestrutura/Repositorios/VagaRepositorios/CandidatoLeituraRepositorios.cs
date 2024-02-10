using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using Totvs.Desafio.ATS.Dominio.Entidades;
using Totvs.Desafio.ATS.Dominio.Interfaces;

namespace Totvs.Desafio.ATS.Infraestrutura.Repositories
{
    public class CandidatoLeituraRepositorios(IMongoDatabase database) : ICandidatoLeituraRepositorios
    {
        private readonly IMongoCollection<Candidato> _dbColecao = database.GetCollection<Candidato>("Candidato");
        private readonly FilterDefinitionBuilder<Candidato> _filtro = Builders<Candidato>.Filter;

        public async Task<IReadOnlyCollection<Candidato>> ObterTodosCandidatos()
        {
            return await _dbColecao.Find(_filtro.Empty).ToListAsync();
        }
       
    }
}