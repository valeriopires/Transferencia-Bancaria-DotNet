
namespace TransferenciaBancaria
{
    public class Titular
    {
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public string Rg { get; private set; }
        public string Endereco { get; private set; }
        
        public Titular(string Nome, string Cpf, string Rg, string Endereco)
        {
            this.Nome = Nome;
            this.Cpf = Cpf;
            this.Rg = Rg;
            this.Endereco = Endereco;
        }
    }
}