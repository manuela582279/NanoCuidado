using System.ComponentModel.DataAnnotations;

namespace NanoCuidado.Models
{
    public class Tratamento
    {
        public int TratamentoId { get; set; }

        [Display(Name = "Descrição")]
        [DataType(DataType.MultilineText)]
        public string Descricao { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Preço")]
        public decimal Preco { get; set; }

        [Display(Name = "Exame")]
        public int? ExameId { get; set; }
        public Exame? Exame { get; set; }

        [Display(Name = "Paciente")]
        public int? PacienteId { get; set; }
        public Paciente? Paciente { get; set; }
    }
}
