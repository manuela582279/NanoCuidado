namespace NanoCuidado.Models
{
    public class Exame
    {
        public int ExameId { get; set; }
        [Required(ErrorMessage = "Digite o Nome da Conta")]

        public string Descricao { get; set; }
        [Required(ErrorMessage = "Digite o Nome da Conta")]

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Preço de Custo")]
        public decimal Preco { get; set; }
        

        [Display(Name = "Paciente")]
        public int? PacienteId { get; set; }
        public Paciente? Paciente { get; set; }
    }
}
