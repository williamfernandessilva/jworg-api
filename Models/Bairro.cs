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

    // Mudamos para string para parar de dar o erro de "Cast"
    [Column("lat")]
    public string Lat { get; set; } = "0";

    [Column("lng")]
    public string Lng { get; set; } = "0";

    [Column("status")]
    public string? Status { get; set; }

        [Column("trabalhadoPor")]
        public string? TrabalhadoPor { get; set; }

        [Column("dataConclusao")]
        public DateTime? DataConclusao { get; set; }
    }
}