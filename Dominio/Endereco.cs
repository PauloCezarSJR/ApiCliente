using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCliente.Dominio
{
    public class Endereco
    {
        public int id { get; set; }
        public string logradouro { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
        public bool Validate()
        {
            if(this == null)
            {
                return true;
            }
            else
            {
                if(string.IsNullOrEmpty(logradouro))
                {
                    throw new InvalidOperationException("O campo Logradouro é obrigatório") { Source = "Logradouro" };
                }
                if (logradouro.Trim().Length >= 50)
                {
                    throw new InvalidOperationException("O campo Logradouro deve ter no máximo 50 caracteres") { Source = "Logradouro" };
                }
                if (string.IsNullOrEmpty(bairro))
                {
                    throw new InvalidOperationException("O campo Bairro é obrigatório") { Source = "Bairro" };
                }
                if (bairro.Trim().Length >= 40)
                {
                    throw new InvalidOperationException("O campo Bairro deve ter no máximo 40 caracteres") { Source = "Bairro" };
                }
                if (string.IsNullOrEmpty(cidade))
                {
                    throw new InvalidOperationException("O campo Cidade é obrigatório") { Source = "Cidade" };
                }
                if (cidade.Trim().Length >= 40)
                {
                    throw new InvalidOperationException("O campo Cidade deve ter no máximo 40 caracteres") { Source = "Cidade" };
                }
                if (string.IsNullOrEmpty(estado))
                {
                    throw new InvalidOperationException("O campo Estado é obrigatório") { Source = "Estado" };
                }
                if (estado.Trim().Length >= 40)
                {
                    throw new InvalidOperationException("O campo Estado deve ter no máximo 40 caracteres") { Source = "Estado" };
                }
            }

            return true;
        }
    }
}
