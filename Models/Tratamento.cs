namespace NanoCuidado.Models
{
    public class Tratamento
    {
        public int TratamentoId { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int? ExameId { get; set; }
        public Exame? Exame { get; set; }
        public int? PacienteId { get; set; }
        public Paciente? Paciente { get; set; }
    }
}
