namespace JworgApi.Models
{
    public class Bairro
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Status { get; set; } // "verde", "amarelo", "vermelho"
        public double Lat { get; set; }
        public double Lng { get; set; }
    }
}