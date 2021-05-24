using System.ComponentModel.DataAnnotations;

namespace ApiCliente.Models
{
    public class Endereco
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(50, ErrorMessage = "Este campo deve ter no máximo 50 caracteres")]
        public string logradouro{ get; set; }
        public string complemento { get; set; }

        [MaxLength(40, ErrorMessage = "Este campo deve ter no máximo 40 caracteres")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string bairro { get; set; }

        [MaxLength(40, ErrorMessage = "Este campo deve ter no máximo 40 caracteres")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string cidade { get; set; }

        [MaxLength(40, ErrorMessage = "Este campo deve ter no máximo 40 caracteres")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string estado { get; set; }

    }
}
