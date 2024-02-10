using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Totvs.Desafio.ATS.Dominio.Entidades;

public class Candidato
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string Nome { get; set; }
    public DateTime DataCadastro { get; set; }
   
}