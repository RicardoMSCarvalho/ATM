using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.IO;
using System.ComponentModel.Design.Serialization;
using ProjetoFinal.Menus;

namespace ProjetoFinal{
    class MenuMovimentos{
        private int opcao;
        private Conta conta;

        public MenuMovimentos(Conta conta){
            opcao = 0;
            this.conta = conta;
        }

        private void DesenharTitulo(){
            Console.Clear();
            Console.WriteLine("+--------------------------------------+");
            Console.WriteLine("|            Movimentos                |");
            Console.WriteLine("+--------------------------------------+");
        }

        private void ImprimirOpcoes(){
            Console.WriteLine("1 - Depósitos");
            Console.WriteLine("2 - Transferência");
            Console.WriteLine("3 - Pagamentos");
            Console.WriteLine("4 - Filtragem");
            Console.WriteLine("5 - Voltar");
        }

        private void LerOpcao(){
            Console.Write("Insira a opção:");
            opcao = int.Parse(Console.ReadLine());
        }

        private void ProcessarOpcao(){
            switch (opcao){
                case 1:
                    MenuDeposito md = new MenuDeposito(conta);
                    md.Executar();
                    break;
                case 2:
                    MenuTrans mt = new MenuTrans(conta);
                    mt.Executar();
                    break;
                case 3:
                    MenuPag mp = new MenuPag(conta);
                    mp.Executar();
                    break;
                case 4:
                    Filtragem.Executa();
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