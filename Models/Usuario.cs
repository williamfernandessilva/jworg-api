using System.ComponentModel.DataAnnotations.Schema;

namespace JworgApi.Models
{
    [Table("usuarios")] 
    public class Usuario
    {
        [Column("id")]
        public string Id { get; set; } = string.Empty; // DEIXE APENAS ESTE ID

        [Column("nome")]
        public string Nome { get; set; } = string.Empty;

        [Column("email")]
        public string Email { get; set; } = string.Empty;

        [Column("senha")]
        public string Senha { get; set; } = string.Empty;
        
        [Column("isAdmin")] 
        public bool IsAdmin { get; set; }
    }
}