namespace Domain.Model
{
    public class Cliente : Pessoa
    {
        public float Saldo { get; set; }


       public void setSaldo(string saldo)
        {
            if (float.TryParse(saldo, out var saldoConvertido) && saldoConvertido > 0)
            {
                Saldo = saldoConvertido;
            }
            else
            {
                Validacoes.Add("Saldo não é válido");
            }
        }
    }
}
