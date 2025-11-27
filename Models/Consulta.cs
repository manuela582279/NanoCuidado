namespace NanoCuidado.Models
{
    public class Consulta
    {
        public int ConsultaId { get; set; }
        public int? PacienteId { get; set; }
        public Paciente? Paciente { get; set; }
        public DateTime DataHora { get; set; }
        public int? TratamentoId { get; set; }
        public Tratamento? Tratamento { get; set; }
        public int? ExameId { get; set; }
        public Exame? Exame { get; set; }
        public string Observacoes { get; set; }
    }
}
