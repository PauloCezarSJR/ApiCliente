using System;
using System.ComponentModel.DataAnnotations;

namespace ApiCliente.Models
{
    public class Cliente
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(30, ErrorMessage = "Este campo deve ter no máximo 30 caracteres")]
        public string nome { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public DateTime dataNascimento { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string cpf { get; set; }
        public int idade { get; set; }
        private int Enderecoid { get; set; }
        public Endereco Endereco { get; set; }


    }
}
