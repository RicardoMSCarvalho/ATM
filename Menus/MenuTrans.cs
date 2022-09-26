using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.IO;
using System.ComponentModel.Design.Serialization;

namespace ProjetoFinal{
    class MenuTrans{
        private Conta conta;
        private int opcao;
        string Sigla;

        public MenuTrans(Conta conta){
            opcao = 0;
            this.conta = conta;
        }

        private void DesenharTitulo(){
            Console.Clear();
            Console.WriteLine("+--------------------------------------+");
            Console.WriteLine("|          Transferência               |");
            Console.WriteLine("+--------------------------------------+");
        }

        private void ImprimirOpcoes(){
            Console.WriteLine("1 - Bancária");
            Console.WriteLine("2 - MBWay");
            Console.WriteLine("3 - Voltar");
        }

        private void LerOpcao(){
            Console.Write("Insira a opção:");
            opcao = int.Parse(Console.ReadLine());
        }
        private void AdicionarDepositoNum(){
            double valor = 0;
            Console.Clear();
            Console.WriteLine("+--------------------------------------+");
            Console.WriteLine("|    Transferencia de numerário        |");
            Console.WriteLine("+--------------------------------------+");

            Conta.DadosConta(conta);

            // verificar se o valor é <= 0
            Console.WriteLine("Saldo atual: " +conta.Saldo);
            while (valor <= 0 || valor>conta.Saldo){
                Console.Write("Valor a depositar:");
                valor = double.Parse(Console.ReadLine());
            }

            string iba = Funcoes.LerIBAN();
            string nome = Funcoes.LerString("Nome do destinatário");

            Movimento TraNum = new TransNum(conta, valor, iba, nome);
            TraNum.Operacao();
        }
        private void AdicionarMBWay(){
            double valor = 0;
            Console.Clear();
            Console.WriteLine("+--------------------------------------+");
            Console.WriteLine("|    Transferencia para MBWay        |");
            Console.WriteLine("+--------------------------------------+");

            Conta.DadosConta(conta);

            // verificar se o valor é <= 0
            Console.WriteLine("Saldo atual: " + conta.Saldo);
            while (valor <= 0 || valor > conta.Saldo)
            {
                Console.Write("Valor a depositar:");
                valor = double.Parse(Console.ReadLine());
            }

            Movimento Tramb = new TransMB(conta, valor);
            Tramb.Operacao();
        }


        private void ProcessarOpcao(){
            switch (opcao){
                case 1:
                    AdicionarDepositoNum();
                    break;
                case 2:
                    AdicionarMBWay();

                    break;
                case 3:
                    break;

                default:
                    Console.WriteLine("Erro: opção inválida!");
                    break;
            }
        }


        public void Print(){
            if (!File.Exists("Depositos.csv")){
                Console.WriteLine("ERRRO: Ficheiro não existe");
                Console.ReadKey();
            }else{
                try{
                    StreamReader sr = new StreamReader("Depositos.csv");
                    string[] tamanho = File.ReadAllLines("Depositos.csv");
                    sr.Close();

                    for (int i = 0; i < tamanho.Length; i++){
                        string[] campos = tamanho[i].Split(";");
                        Sigla = campos[4];

                        if (Sigla == "DEP-Num"){
                            DepositoNum.MostrarNumerario(campos);

                        }
                        else if (Sigla == "DEP-Trans"){
                            DepositoTrans.MostrarTransf(campos);
                        }
                    }
                    Console.ReadKey();
                }
                catch (Exception e){
                    Console.WriteLine("Erro: {0}", e.Message);
                }

            }
        }

        public void Executar(){
            do{
                DesenharTitulo();

                ImprimirOpcoes();

                LerOpcao();

                ProcessarOpcao();
            } while (opcao != 3);
        }
    }
}