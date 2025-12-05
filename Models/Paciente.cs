using System.ComponentModel.DataAnnotations;

namespace NanoCuidado.Models
{
    public class Paciente
    {
        public int PacienteId { get; set; }

        [Required(ErrorMessage = "O nome e obrigatório")]
        [StringLength(100, ErrorMessage = "O nome  não pode ter mais de 100 caracteres")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.DateTime)]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O  número de telefone é obrigatório")]
        [StringLength(100, ErrorMessage = "O número de telefone  não pode ter mais de 15 caracteres")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Digite um email válido")]
        [StringLength(100, ErrorMessage = "O email não pode ter mais de 100 caracteres")]
        public string Email { get; set; }
    }
}
