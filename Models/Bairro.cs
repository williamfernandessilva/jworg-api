using System;
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

        // Note que aqui usamos "lat" e "lng" para bater com sua imagem
        [Column("lat")]
        public double Lat { get; set; }

        [Column("lng")]
        public double Lng { get; set; }

        [Column("status")]
        public string? Status { get; set; }

        [Column("trabalhadoPor")]
        public string? TrabalhadoPor { get; set; }

        [Column("dataConclusao")]
        public DateTime? DataConclusao { get; set; }
    }
}