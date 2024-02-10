using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using Totvs.Desafio.ATS.Dominio.Entidades;
using Totvs.Desafio.ATS.Dominio.Interfaces;

namespace Totvs.Desafio.ATS.Infraestrutura.Repositories
{
    public class VagaLeituraRepositorios(IMongoDatabase database) : IVagaLeituraRepositorios
    {
        private readonly IMongoCollection<Vaga> _dbColecao = database.GetCollection<Vaga>("Vaga");
        private readonly FilterDefinitionBuilder<Vaga> _filtro = Builders<Vaga>.Filter;

        public async Task<IReadOnlyCollection<Vaga>> ObterTodasAsVagas()
        {
            return await _dbColecao.Find(_filtro.Empty).ToListAsync();
        }
    }
}