namespace JworgApi.Models
{
    public class Bairro
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Status { get; set; } = "verde"; // Padrão para o mapa
    }
}