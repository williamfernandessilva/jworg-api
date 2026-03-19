namespace JworgApi.Models
{
    public class Bairro
    {
        public int id { get; set; }
        public string? nome { get; set; }
        public string? status { get; set; } // "verde", "amarelo", "vermelho"
        public double lat { get; set; }
        public double lng { get; set; }
        public string? trabalhadoPor { get; set; }
        public DateTime? dataConclusao { get; set; }
    }
}