using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.IO;
using System.Reflection.Metadata.Ecma335;

namespace ProjetoFinal
{
    class MenuDeposito {
        int opcao = 0;
        private Conta conta;

        public MenuDeposito(Conta conta){
            opcao = 0;
            this.conta = conta;
        }

        private void DesenharTitulo(){
            Console.Clear();
            Console.WriteLine("+--------------------------------------+");
            Console.WriteLine("|         Depositos                    |");
            Console.WriteLine("+--------------------------------------+");

        }
        private void ImprimirOpcoes(){
            Console.WriteLine("1- Numerário");
            Console.WriteLine("2- por Transferencia");
            Console.WriteLine("3- MBWAY");
            Console.WriteLine("4- Voltar");
        }
        private void LerOpcao(){
            Console.Write("Insira a opção:");
            opcao = int.Parse(Console.ReadLine());
        }

        private void AdicionarDepositoNum(){
            double valor=0;
            Console.Clear();
            Console.WriteLine("+--------------------------------------+");
            Console.WriteLine("|       Deposito em Numerário          |");
            Console.WriteLine("+--------------------------------------+");

            Conta.DadosConta(conta);

            // verificar se o valor é <= 0
            while (valor<=0){
                Console.Write("Valor a depositar:");
                valor = double.Parse(Console.ReadLine());
            }

            Movimento dpNum = new DepositoNum(conta, valor);
            dpNum.Operacao();
        }

        private void AdicionarDepositoTrans(){
            double valor=0;
            Console.Clear();
            Console.WriteLine("+--------------------------------------+");
            Console.WriteLine("|       Deposito Transferência         |");
            Console.WriteLine("+--------------------------------------+");

            Conta.DadosConta(conta);
            while (valor <= 0 || valor>conta.Saldo){
                Console.Write("Valor a depositar:");
                valor = double.Parse(Console.ReadLine());
            }
            string nome = Funcoes.LerString("Nome do destinatário?");

            string iban = Funcoes.LerIBAN();

            Movimento transf = new DepositoTrans(conta, valor, nome, iban);
            transf.Operacao();
        }

        private void AdicionarDepositoMB(){
            double valor=0;
            Console.Clear();
            Console.WriteLine("+--------------------------------------+");
            Console.WriteLine("|            Deposito MBWAY            |");
            Console.WriteLine("+--------------------------------------+");

            Conta.DadosConta(conta);

            // verificar se o valor é <= 0
            while (valor <= 0 || valor>conta.Saldo){
                Console.Write("Valor a depositar:");
                valor = double.Parse(Console.ReadLine());
            }

            Movimento mb = new DepositoMB(conta, valor);
            mb.Operacao();
        }


        private void ProcessarOpcao(){
            // 4. Processa a opcao do menu
            switch (opcao){
                case 1:
                    AdicionarDepositoNum();
                    break;
                case 2:
                    AdicionarDepositoTrans();
                    break;
                case 3:
                    AdicionarDepositoMB();
                    break;
                case 4:
                    break;
                default:
                    Console.WriteLine("Erro: opção inválida!");
                    break;
            }
        }
        public void Executar(){
            do{
                DesenharTitulo();

                ImprimirOpcoes();

                LerOpcao();

                ProcessarOpcao();

            } while (opcao != 4);
}
}
}