using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Totvs.Desafio.ATS.Dominio.Entidades;
using Totvs.Desafio.ATS.Dominio.Interfaces;

namespace Totvs.Desafio.ATS.Repository.Repositorios.CandidatoRepositorios
{
    public class CandidatoEscritaRepositorios(IMongoDatabase database) : ICandidatoEscritaRepositorios
    {
        private readonly IMongoCollection<Candidato> _dbColecao = database.GetCollection<Candidato>("Candidato");
        private readonly FilterDefinitionBuilder<Candidato> _filtro = Builders<Candidato>.Filter;

        public Task<bool> SalvarCandidatoAsync(Candidato Candidato, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(database);

            _dbColecao.InsertOneAsync(Candidato, null, cancellationToken);
            return Task.FromResult(true);
        }

        public async Task<bool> DeletarCandidatoAsync(string id, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(database);

            var filter = _filtro.Eq(Candidato => Candidato.Id, id);
            var result = await _dbColecao.DeleteOneAsync(filter, cancellationToken);
            return (result.DeletedCount != 0);            
        }

        public async Task<bool> AlterarCandidatoAsync(Candidato Candidato, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(database);

            var result = await _dbColecao.ReplaceOneAsync(v => v.Id == Candidato.Id, Candidato, cancellationToken: cancellationToken);
            return (result.ModifiedCount !=0);
        }

        // Consultas
        public async Task<Candidato> ObterCandidatoPorIdAsync(string id)
        {
            try
            {
                var filter = _filtro.Eq(Candidato => Candidato.Id, id);
                return await _dbColecao.Find(filter).FirstOrDefaultAsync();
            }
            catch (Exception)
            {
                return null;               
            }
        }

        public async Task<IReadOnlyCollection<Candidato>> ObterTodosOsCandidatos()
        {
            return await _dbColecao.Find(_filtro.Empty).ToListAsync();
        }
    }
}