namespace Domain.Model
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public List<string> Validacoes { get; set; }

        public void SetCpf(bool cpfValido,string cpfUsuario)
        {
            if (!cpfValido)
            {
                Validacoes.Add("CPF digitado não é válido");
            }
            else
            {
                Cpf = cpfUsuario;
            }
        }

        public void SetId(string id)
        {
            if (int.TryParse(id, out var idConvertido))
                Id = idConvertido;
            else
                Validacoes.Add("Identificador não é valido");
        }

    }
}
