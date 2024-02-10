using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Totvs.Desafio.ATS.Dominio.Entidades;
using Totvs.Desafio.ATS.Dominio.Interfaces;

namespace Totvs.Desafio.ATS.Repository.Repositorios.VagaRepositorios
{
    public class VagaEscritaRepositorios(IMongoDatabase database) : IVagaEscritaRepositorios
    {
        private readonly IMongoCollection<Vaga> _dbColecao = database.GetCollection<Vaga>("Vaga");
        private readonly FilterDefinitionBuilder<Vaga> _filtro = Builders<Vaga>.Filter;

        public Task<bool> SalvarVagaAsync(Vaga vaga, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(database);

            _dbColecao.InsertOneAsync(vaga, null, cancellationToken);
            return Task.FromResult(true);
        }

        public async Task<bool> DeletarVagaAsync(string id, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(database);

            var filter = _filtro.Eq(vaga => vaga.Id, id);
            var result = await _dbColecao.DeleteOneAsync(filter, cancellationToken);
            return (result.DeletedCount != 0);            
        }

        public async Task<bool> AlterarVagaAsync(Vaga vaga, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(database);

            var result = await _dbColecao.ReplaceOneAsync(v => v.Id == vaga.Id, vaga, cancellationToken: cancellationToken);
            return (result.ModifiedCount !=0);
        }

        // Consultas
        public async Task<Vaga> ObterVagaPorIdAsync(string id)
        {
            try
            {
                var filter = _filtro.Eq(vaga => vaga.Id, id);
                return await _dbColecao.Find(filter).FirstOrDefaultAsync();
            }
            catch (Exception)
            {
                return null;
                ;
            }
        }

        public async Task<IReadOnlyCollection<Vaga>> ObterTodasAsVagas()
        {
            return await _dbColecao.Find(_filtro.Empty).ToListAsync();
        }
    }
}