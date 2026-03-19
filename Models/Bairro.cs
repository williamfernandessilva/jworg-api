using System.ComponentModel.DataAnnotations.Schema;

namespace JworgApi.Models
{
    [Table("bairros")] 
    public class Bairro
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("nome")]
        public string Nome { get; set; } = string.Empty;

        // Forçamos o tipo da coluna para decimal(18,10) ou double para não dar erro 500
        [Column("lat", TypeName = "double")]
        public double Lat { get; set; }

        [Column("lng", TypeName = "double")]
        public double Lng { get; set; }

        [Column("status")]
        public string? Status { get; set; } = "verde";

        [Column("trabalhadoPor")]
        public string? TrabalhadoPor { get; set; }

        [Column("dataConclusao")]
        public DateTime? DataConclusao { get; set; }
    }
}