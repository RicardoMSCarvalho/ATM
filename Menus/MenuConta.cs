using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
using System.IO;

namespace ProjetoFinal
{
    class MenuConta{
        private int opcao;
        private Conta conta;
       
        public MenuConta(Conta conta){
            this.conta = conta;
            opcao = 0;
        }

        private void DesenharTitulo(){
            Console.Clear();
            Console.WriteLine("+--------------------------------------+");
            Console.WriteLine("|         Gestão de Conta            |");
            Console.WriteLine("+--------------------------------------+");
        }

        private void ImprimirOpcoes(){
            Console.WriteLine("1- Criar Conta");
            Console.WriteLine("2- Ver conta");
            Console.WriteLine("3- Alterar Dados de Conta");
            Console.WriteLine("4- Gerar relatorio");
            Console.WriteLine("5- Voltar");
        }

        private void LerOpcao(){
            Console.Write("Insira a opção:");
            opcao = int.Parse(Console.ReadLine());
        }
        private void Add(){
            Console.Write("Nome : ");
            conta.Nome = Console.ReadLine();
            conta.Iban = Funcoes.LerIBAN();
            conta.Nib = Funcoes.LerNIB();
            conta.Swift = Funcoes.LerSWIFT();
            Console.WriteLine("Registado com sucesso, ENTER para continuar");
            Console.ReadKey();
        }

        private void Print(){
            if (!File.Exists("Conta.csv")){
                Console.Clear();
                Console.WriteLine("+--------------------------------------+");
                Console.WriteLine("|    Ver Dados detalhes conta          |");
                Console.WriteLine("+--------------------------------------+");

                Console.WriteLine("{0}", ToString());
                Console.WriteLine("ENTER para continuar");
                Console.ReadKey();

            }else{
                StreamReader sr = new StreamReader("Conta.csv");
                string dados = sr.ReadLine();
                sr.Close();

                string[] campos = dados.Split(";");
                if (campos.Length != 4)
                    Console.WriteLine("Ficheiro corrompido");

                conta.Nome = campos[0];
                conta.Iban = campos[1];
                conta.Nib = campos[2];
                conta.Swift = campos[3];

                Console.WriteLine("Nome: {0}, IBan: {1} ", conta.Nome, conta.Iban);
                Console.WriteLine("Nib: {0}, SWIFT: {1} ", conta.Nib, conta.Swift);
                Console.WriteLine("ENTER para continuar");
                Console.ReadKey();
            }

        }
        private void Edit(){
            Console.Clear();
            Console.WriteLine("+--------------------------------------+");
            Console.WriteLine("|    Editar Dados da Conta de " + conta.Nome + "    |");
            Console.WriteLine("+--------------------------------------+");

            Console.Write("Nome : ");
            string nm = Console.ReadLine();
            conta.Nome = nm;
            conta.Iban = Funcoes.LerIBAN();
            conta.Nib = Funcoes.LerNIB();
            conta.Swift = Funcoes.LerSWIFT();
        }


        private void ProcessarOpcao(){
            switch (opcao){
                case 1:
                    Add();
                    break;
                case 2:
                    Print();
                    break;

                case 3:
                    Edit();
                    break;

                case 4:
                    conta.SaveFile();
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

            } while (opcao != 5);
        }
}
}
