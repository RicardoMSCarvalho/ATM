using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.IO;
using System.ComponentModel.Design.Serialization;
using ProjetoFinal.Movimentos;

namespace ProjetoFinal.Menus{
    class MenuPag{
        private int opcao;
        string entidade;
        string referencia;
        int contador = 0;
        private Conta conta;

        public MenuPag(Conta conta){
            opcao = 0;
            this.conta = conta;
        }

        private void DesenharTitulo(){
            Console.Clear();
            Console.WriteLine("+--------------------------------------+");
            Console.WriteLine("|            Pagamentos                |");
            Console.WriteLine("+--------------------------------------+");
        }

        private void ImprimirOpcoes()
        {
            Console.WriteLine("1 - Serviços");
            Console.WriteLine("2 - Estado");
            Console.WriteLine("3 - Telemoveis");
            Console.WriteLine("4 - Voltar");
        }
        public void AdicionarPagServ(){
            double valor = 0;
            Console.Clear();
            Console.WriteLine("+--------------------------------------+");
            Console.WriteLine("|      Pagamento de Serviços           |");
            Console.WriteLine("+--------------------------------------+");

            Conta.DadosConta(conta);

            // verificar se o valor é <= 0
            Console.WriteLine("Saldo atual: {0}\n", conta.Saldo);

            while ( contador  != 5){
                entidade = Funcoes.LerString("Entidade: ");
                foreach (char c in entidade){
                    contador++;
                }
                if (contador!=5){
                    contador = 0;
                }
            }
            contador = 0;
            while (contador != 9){
                referencia = Funcoes.LerString("Referencia: ");
                foreach (char c in referencia){
                    contador++;
                }
                if (contador!=9){
                    contador = 0;
                }
            }
            while (valor <= 0 || valor > conta.Saldo){
                Console.Write("Valor :");
                valor = double.Parse(Console.ReadLine());
            }

            Movimento PServ = new PagServicos(conta, valor, entidade, referencia);
            PServ.Operacao();
        }
        public void AdicionarPagEst(){
            double valor = 0;
            Console.Clear();
            Console.WriteLine("+--------------------------------------+");
            Console.WriteLine("|      Pagamentos ao Estado           |");
            Console.WriteLine("+--------------------------------------+");

            Conta.DadosConta(conta);


            // verificar se o valor é <= 0
            Console.WriteLine("Saldo atual: {0}\n", conta.Saldo);

            while (contador != 12){
                contador = 0;
                referencia = Funcoes.LerString("Referencia: ");
                foreach (char c in referencia){
                    contador++;
                }
            }
            contador = 0;

            while (valor <= 0 || valor > conta.Saldo){
                Console.Write("Valor :");
                valor = double.Parse(Console.ReadLine());
            }

            Movimento PEst= new PagEstado(conta, valor, referencia);
            PEst.Operacao();
        }
        public void CarregarTelem(){
            double valor = 0;
            Console.Clear();
            Console.WriteLine("+--------------------------------------+");
            Console.WriteLine("|      Carregamento Telemovel           |");
            Console.WriteLine("+--------------------------------------+");

            Conta.DadosConta(conta);

            // verificar se o valor é <= 0
            Console.WriteLine("Saldo atual: {0}\n", conta.Saldo);

            string operadora = Funcoes.LerString("nome da Operadora: ");
            string nome = Funcoes.LerString("Nome: ");
            string nCont = Funcoes.LerNIF();

            while (contador != 9)
            {
                contador = 0;
                referencia = Funcoes.LerString("Contacto: ");
                foreach (char c in referencia)
                {
                    contador++;
                }
            }
            contador = 0;

            while (valor <= 0 || valor > conta.Saldo)
            {
                Console.Write("Valor :");
                valor = double.Parse(Console.ReadLine());
            }
            Movimento PTel = new PagTelemoveis(conta, valor, operadora, nome, nCont, referencia);
            PTel.Operacao();
        }


        private void LerOpcao()
        {
            Console.Write("Insira a opção:");
            opcao = int.Parse(Console.ReadLine());
        }

        private void ProcessarOpcao()
        {
            switch (opcao)
            {
                case 1:
                    AdicionarPagServ();
                    break;
                case 2:
                    AdicionarPagEst();
                    break;
                case 3:
                    CarregarTelem();
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