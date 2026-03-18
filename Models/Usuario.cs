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
        
        [Column("isAdmin")] // Se no seu Railway estiver 'is_admin', mude aqui para "is_admin"
        public bool IsAdmin { get; set; }
    }
}