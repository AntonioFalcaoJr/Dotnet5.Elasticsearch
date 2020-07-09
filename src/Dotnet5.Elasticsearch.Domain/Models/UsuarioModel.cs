using System;

namespace Dotnet5.Elasticsearch.Domain.Models
{
    public abstract class UsuarioModel
    {
        public bool Ativo { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
    }
}