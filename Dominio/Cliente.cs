using System;

namespace ApiCliente.Dominio
{
    public class Cliente
    {
        public int id { get; set; }
        public string nome { get; set; }
        public DateTime dataNascimento { get; set; }
        public string cpf { get; set; }
        private string enderecoId { get; set; }
        public Endereco Endereco { get; set; }
        public int idade { get { return new DateTime(DateTime.Now.Subtract(dataNascimento).Ticks).Year - 1; }}
        public void Validate()
        {
            if(string.IsNullOrEmpty(nome))
            {
                throw new InvalidOperationException("O campo Nome é obrigatório") { Source = "Nome" };
            }
            if (nome.Trim().Length >= 30)
            {
                throw new InvalidOperationException("O campo Nome deve ter no máximo 30 caracteres") { Source = "Nome" };
            }
            if (string.IsNullOrEmpty(cpf))
            {
                throw new InvalidOperationException("O campo CPF é obrigatório") { Source = "CPF" };
            }
            if (dataNascimento == null || dataNascimento == DateTime.MinValue)
            {
                throw new InvalidOperationException("O campo Data de Nascimento é obrigatório") { Source = "CPF" };
            }
            if(!ValidaCPF(cpf))
            {
                throw new InvalidOperationException("O campo CPF é inválido") { Source = "CPF" };
            }
            if(Endereco != null)
            {
                Endereco.Validate();
            }
        }
        public bool ValidaCPF(string cpf)
        {
            if (cpf.Length > 11)
                return false;

            while (cpf.Length != 11)
                cpf = '0' + cpf;

            bool igual = true;
            for (int i = 1; i < 11 && igual; i++)
                if (cpf[i] != cpf[0])
                    igual = false;

            if (igual || cpf == "12345678909")
                return false;

            int[] numeros = new int[11];

            for (int i = 0; i < 11; i++)
                numeros[i] = int.Parse(cpf[i].ToString());

            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += (10 - i) * numeros[i];

            int resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0)
                    return false;
            }
            else if (numeros[9] != 11 - resultado)
                return false;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += (11 - i) * numeros[i];

            resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                    return false;
            }
            else
                if (numeros[10] != 11 - resultado)
                return false;

            return true;
        }
    }
}
