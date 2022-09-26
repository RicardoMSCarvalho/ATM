using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoFinal{
    class MenuPrincipal{
         
        Cliente cliente = new Cliente();
        Conta conta = new Conta();


        private int opcao;

        public MenuPrincipal(){
            opcao = 0;
        }

        private void DesenharTitulo(){
            Console.Clear();
            Console.WriteLine("+--------------------------------------+");
            Console.WriteLine("|           SISTEMA BÁNCARIO           |");
            Console.WriteLine("+--------------------------------------+");
        }

        private void ImprimirOpcoes(){
            Console.WriteLine("1- Cliente");
            Console.WriteLine("2- Conta");
            Console.WriteLine("3- Movimentos");
            Console.WriteLine("4- Sair");
        }

        private void LerOpcao(){
            Console.Write("Insira a opção:");
            opcao = int.Parse(Console.ReadLine());
        }

        private void ProcessarOpcao(){
            // 4. Processa a opcao do menu
            switch (opcao){
                case 1:
                    MenuCliente mcliente = new MenuCliente(cliente);
                    mcliente.Executar();
                    break;
                case 2:
                    MenuConta menuConta = new MenuConta(conta);
                    menuConta.Executar();
                    break;
                case 3:
                    MenuMovimentos menuMovimentos = new MenuMovimentos(conta);
                    menuMovimentos.Executar();

                    break;
                case 4:
                    Console.WriteLine("Muito obrigado por ter usado a aplicação.");
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