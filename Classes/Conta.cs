
using System;

namespace TransferenciaBancaria
{
    public class Conta
    {
        private int Numero { get; set; }
        private Titular Titular { get; set; }
        private double Limite { get; set; }
        private double Saldo { get; set; }
        private TipoConta TipoConta { get; set; }

        public Conta(int numero, Titular titular, double limite, double saldo, TipoConta tipoConta)
        {
            this.Numero = numero;
            this.Titular =  titular;
            this.Limite = limite;
            this.Saldo = saldo;
            this.TipoConta = tipoConta;
        }

        public int ConsultarNumeroDaConta(){
            return this.Numero;
        }

        public void Despositar(double valor){
            this.Saldo += valor;
            Console.WriteLine("O saldo atual da conta de {0} é {1}", this.Titular.Nome, this.Saldo);
        }

        public bool Sacar(double valor){
            if(valor <= (this.Saldo + this.Limite)){
                this.Saldo -= valor;
                Console.WriteLine("O saldo atual da conta de {0} é {1}", this.Titular.Nome, this.Saldo);
                return true;
            } else {
                Console.WriteLine("Não foi possível realizar o saque para o valor: {0}. Saldo insuficiente", valor);
                return false;
            } 
        }

        public void Transferir(double valor, Conta contaDestino){             
            if(this.Sacar(valor)){
               contaDestino.Despositar(valor);
            } else {
               Console.WriteLine("Não foi possível realizar a Transferência. O seu saldo atual é: {0}", this.Saldo);
            }
        }

        public override string ToString()
        {
            string retorno = string.Empty;
            retorno += "Número da Conta: " + this.Numero + " | ";
            retorno += "Tipo Conta: " + this.TipoConta +   " | ";
            retorno += "Nome do Titular: " +  this.Titular.Nome + " | ";
            retorno += "CPF do Titular: " +  this.Titular.Cpf +   " | ";
            retorno += "RG do Titular: " +  this.Titular.Rg +     " | ";
            retorno += "Endereço do Titular: " +  this.Titular.Endereco + " | ";
            retorno += "Saldo: " + this.Saldo + " | ";
            retorno += "Limite da conta: " + this.Limite;

            return retorno;
        }
    }
}
