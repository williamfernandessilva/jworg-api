using System.ComponentModel.DataAnnotations.Schema;

namespace JworgApi.Models
{
    [Table("usuarios")] // Força o C# a procurar a tabela 'usuarios' em minúsculo
    public class Usuario
    {
        [Column("id")]
public string Id { get; set; }

        [Column("nome")]
        public string Nome { get; set; } = string.Empty;

        [Column("email")]
        public string Email { get; set; } = string.Empty;

        [Column("senha")]
        public string Senha { get; set; } = string.Empty;
        
       [Column("id")]
public string Id { get; set; } = string.Empty;
    }
}