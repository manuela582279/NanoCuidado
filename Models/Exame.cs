namespace NanoCuidado.Models
{
    public class Exame
    {
        public int ExameId { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }

        public int? PacienteId { get; set; }
        public Paciente? Paciente { get; set; }
    }
}
