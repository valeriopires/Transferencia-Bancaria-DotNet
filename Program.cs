
/*
* Construindo uma aplicação simples para transferências bancárias com .NET
*/

using System;
using System.Collections.Generic;

namespace TransferenciaBancaria
{
    class Program
    {
        static List<Conta> listaDeContas = new List<Conta>();

        static void Main(string[] args)
        {
            string opcaoDoUsuario =  ObterOpcaoUsuario();

            while (opcaoDoUsuario.ToUpper() != "X")
            {
                switch (opcaoDoUsuario)
                {
                    case "1":
                        ListarConta();
                        break;        
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                    throw new ArgumentOutOfRangeException();
                }
                opcaoDoUsuario =  ObterOpcaoUsuario();
            }
         
            Console.WriteLine("Obrigado por utilizar os nosso serviços.");
            Console.ReadLine();
        }

        private static void Depositar()
        {
            Console.Write("Digite o número da conta: ");
            int numeroConta = int.Parse(Console.ReadLine());
            
            Console.Write("Digite o valor para o Deposito: ");
            
            double valorDeposito = double.Parse(Console.ReadLine()); 

           for (int i = 0; i < listaDeContas.Count; i++)
           {
               if(listaDeContas[i].ConsultarNumeroDaConta() == numeroConta){
                    listaDeContas[i].Despositar(valorDeposito);
                    return;
                } 
           }
           Console.Write("Operação não realizada. Informe um Número de conta válido!");
        }

        private static void Transferir()
        {
            Console.Write("Digite o número da conta de Origem: ");
            int numeroContaOrigem = int.Parse(Console.ReadLine());
            
            Console.Write("Digite o valor para o Transferencia: ");    
            double valorTransferencia = double.Parse(Console.ReadLine()); 

            Console.Write("Digite o número da conta de Destino: ");
            int numeroContaDestino = int.Parse(Console.ReadLine());

            int indiceContaOrigem = 0, indiceContaDestino = 0;
            bool achouContaOrigem = false, achouContaDestino = false;
            for (int i = 0; i < listaDeContas.Count; i++)
            {
                if(listaDeContas[i].ConsultarNumeroDaConta() == numeroContaOrigem){
                   indiceContaOrigem = i;
                   achouContaOrigem = true;
                }
                else if (listaDeContas[i].ConsultarNumeroDaConta() == numeroContaDestino){
                   indiceContaDestino = i;
                   achouContaDestino = true;
                }

                if(achouContaOrigem && achouContaDestino){
                    listaDeContas[indiceContaOrigem].Transferir(valorTransferencia, listaDeContas[indiceContaDestino]);
                    return;
                }      
            }
         
           Console.WriteLine("Operação não realizada. Informe um Número de conta válido!");
        }

        private static void ListarConta()
        {
            Console.WriteLine("********************Informações da Conta Bancária******************");
          
            if(listaDeContas.Count == 0){
                Console.WriteLine("Não existem contas a serem listadas!");
                return;
            } else {
                for (int i = 0; i < listaDeContas.Count; i++)
                {
                     Conta conta = listaDeContas[i];
                     Console.Write("#{0} - ", i);
                     Console.WriteLine(conta);
                }
            }
            Console.WriteLine();
        }

        private static void Sacar()
        {
            Console.Write("Digite o número da conta: ");
            int numeroConta = int.Parse(Console.ReadLine());
            
            Console.Write("Digite o valor para o Saque: ");
            double valorSaque = double.Parse(Console.ReadLine()); 

           for (int i = 0; i < listaDeContas.Count; i++)
           {
               if(listaDeContas[i].ConsultarNumeroDaConta() == numeroConta){
                    listaDeContas[i].Sacar(valorSaque);
                    return;
                } 
           }
           Console.WriteLine("Operação não realizada. Informe um Número de conta válido!");
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir uma Nova Conta");
            Console.Write("Digite o número da conta: ");
            int numeroConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o CPF do Titular: ");
            string cpfTitular = Console.ReadLine();

            Console.Write("Digite o nome do Titular: ");
            string nomeTitular = Console.ReadLine();

            Console.Write("Digite o RG do Titular: ");
            string rgTitular = Console.ReadLine();

            Console.Write("Digite o Endereço do Titular: ");
            string enderecoTitular = Console.ReadLine();

            Console.Write("Digite o Limite da conta: ");
            int limiteConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o Saldo Incial da conta: ");
            double saldoConta = double.Parse(Console.ReadLine());  

            Console.Write("Tipo da conta - Digite 1 para Conta Pessoa Física ou 2 para Conta Pessoa Jurídica: ");
            int tpConta = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Conta novaConta = new Conta(numeroConta, new Titular(nomeTitular, cpfTitular, rgTitular, enderecoTitular), 
                                      limiteConta, saldoConta, (TipoConta)tpConta);

            listaDeContas.Add(novaConta);
        }

        private static string ObterOpcaoUsuario(){
            Console.WriteLine("\nInforme a opção desejada:");

            Console.WriteLine("1 - Listar Contas");
            Console.WriteLine("2 - Inserir Nova Conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoEscolhida = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoEscolhida;
        }


    }
}
