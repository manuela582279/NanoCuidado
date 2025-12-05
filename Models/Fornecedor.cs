using System.ComponentModel.DataAnnotations;

namespace NanoCuidado.Models
{
    public class Fornecedor
    {
        public int FornecedorId { get; set; }

        [Required(ErrorMessage = "O nome do fornecedor e obrigatório")]
        [StringLength(100, ErrorMessage = "O nome do fornecedor não pode ter mais de 100 caracteres")]
        [Display(Name = "Nome do Fornecedor")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O contato e obrigatório")]
        [StringLength(100, ErrorMessage = "O contato não pode ter mais de 100 caracteres")]
        [Display(Name = "O contato")]
        public string Contato { get; set; }

        [Required(ErrorMessage = "O  número de telefone é obrigatório")]
        [StringLength(100, ErrorMessage = "O número de telefone  não pode ter mais de 15 caracteres")]
        public string Telefone { get; set; }


        [StringLength(100, ErrorMessage = "O email não pode ter mais de 100 caracteres")]
        public string Email { get; set; }
    }
}