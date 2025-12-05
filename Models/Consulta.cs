using System.ComponentModel.DataAnnotations;

namespace NanoCuidado.Models
{
    public class Consulta
    {
        public int ConsultaId { get; set; }

        [Required(ErrorMessage = "O Campo Paciente é obrigatório.")]
        [Display(Name = "Paciente")]
        public int? PacienteId { get; set; }
        public Paciente? Paciente { get; set; }

        [Required(ErrorMessage = "O Campo Data e Hora é obrigatório.")]
        [Display(Name = "Data e Hora")]
        [DataType(DataType.Date)]
        public DateTime? DataHora { get; set; }

        [Required(ErrorMessage = "O Campo Tratamento é obrigatório.")]
        [Display(Name = "Tratamento")]
        public int? TratamentoId { get; set; }

        public Tratamento? Tratamento { get; set; }

        [Required(ErrorMessage = "O Campo Exame é obrigatório.")]
        [Display(Name = "Exame")]

        public int? ExameId { get; set; }
        public Exame? Exame { get; set; }



        [Required(ErrorMessage = "O Campo Observações é obrigatório.")]
        [Display(Name = "Observações")]
        public required string Observacoes { get; set; }
    }
}

