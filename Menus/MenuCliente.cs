using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.NetworkInformation;
using System.Text;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace ProjetoFinal{
    class MenuCliente{
        private int opcao;
        private Cliente cliente;

        public MenuCliente(Cliente c1){
                    opcao = 0;
                    this.cliente = c1;
        }
        private void DesenharTitulo(){
            Console.Clear();
            Console.WriteLine("+--------------------------------------+");
            Console.WriteLine("|         Gestão do Cliente            |");
            Console.WriteLine("+--------------------------------------+");
        }

        private void ImprimirOpcoes(){
            Console.WriteLine("1- Adicionar Cliente");
            Console.WriteLine("2- Ver Cliente");
            Console.WriteLine("3- Alterar Dados do Cliente");
            Console.WriteLine("4- Gerar Relatorio");
            Console.WriteLine("5- Voltar");
        }

        private void LerOpcao(){
            Console.Write("Insira a opção:");
            opcao = int.Parse(Console.ReadLine());
        }

        public void Add(){
            Console.Write("Nome Completo: ");
            cliente.NomeC = Console.ReadLine();
            Console.Write("Nome Abreviado: ");
            cliente.NomeAbre = Console.ReadLine();
            Console.Write("Titulo: ");
            cliente.Titulo = Console.ReadLine();
            cliente.Genero = Funcoes.LerGen();
            cliente.TipoId = Funcoes.LerDoc();
            Console.Write("Nº Doc.Identificação: ");
            cliente.NDocIden = Console.ReadLine();
            Console.Write("Nacionalidade: ");
            cliente.Nacionalidade = Console.ReadLine();
            Console.Write("Naturalidade: ");
            cliente.Naturalidade = Console.ReadLine();
            Console.Write("Distrito: ");
            cliente.Distrito = Console.ReadLine();
            Console.Write("Concelho: ");
            cliente.Concelho = Console.ReadLine();
            Console.Write("Freguesia: ");
            cliente.Freguesia = Console.ReadLine();
            Console.Write("Data de Nascimento: ");
            cliente.DataNasc = Console.ReadLine();
            cliente.Nif = Funcoes.LerNIF();
            Console.Write("Validade: ");
            cliente.Validade = Console.ReadLine();
            Console.WriteLine("Registado com sucesso");
            Console.ReadKey();
        }
        public void Edit(){
            Console.Clear();
            Console.WriteLine("+--------------------------------------+");
            Console.WriteLine("|    Editar Dados do Cliente " + cliente.NomeAbre + "    |");
            Console.WriteLine("+--------------------------------------+");

            Console.Write("Nome Completo: ");
            string nm = Console.ReadLine();
            cliente.NomeC = nm;
            Console.Write("Nome Abreviado: ");
            string sm = Console.ReadLine();
            cliente.NomeAbre = sm;
            Console.Write("Titulo: ");
            string tit = Console.ReadLine();
            cliente.Titulo = tit;
            Console.Write("Género: ");
            string gn = Console.ReadLine();
            cliente.Genero = Funcoes.LerGen();
            cliente.Nif = Funcoes.LerNIF();
            cliente.TipoId = Funcoes.LerDoc();
            Console.Write("Nº Doc.Identificação: ");
            string ndociden = Console.ReadLine();
            cliente.NDocIden = ndociden;
            Console.Write("Validade: ");
            string vale = Console.ReadLine();
            cliente.Validade = vale;
            Console.Write("Data de nascimento: ");
            string dn = Console.ReadLine();
            cliente.DataNasc = dn;
            Console.Write("Nacionalidade: ");
            string nac = Console.ReadLine();
            cliente.Nacionalidade = nac;
            Console.Write("Naturalidade: ");
            string nat = Console.ReadLine();
            cliente.Naturalidade = nat;
            Console.Write("Distrito: ");
            string dis = Console.ReadLine();
            cliente.Distrito = dis;
            Console.Write("Concelho: ");
            string con = Console.ReadLine();
            cliente.Concelho = con;
            Console.Write("Freguesia: ");
            string freg = Console.ReadLine();
            cliente.Freguesia = freg;
            Console.WriteLine("Atualizado com sucesso, ENTER para continuar");
            Console.ReadKey();
        }

        public void Print()
        {
            if (!File.Exists("Cliente.csv")){
                Console.Clear();
                Console.WriteLine("+--------------------------------------+");
                Console.WriteLine("|    Ver Dados do Cliente      |");
                Console.WriteLine("+--------------------------------------+");

                Console.WriteLine("{0}", ToString());
                Console.WriteLine("ENTER para continuar");
                Console.ReadKey();

            }else{
                StreamReader sr = new StreamReader("Cliente.csv");
                string dados = sr.ReadLine();
                sr.Close();

                string[] campos = dados.Split(";");
                if (campos.Length != 14)
                    Console.WriteLine("Ficheiro corrompido");

                cliente.NomeC = campos[0];
                cliente.NomeAbre = campos[1];
                cliente.Titulo = campos[2];
                cliente.Genero = campos[3];
                cliente.Nif = campos[4];
                cliente.TipoId = campos[5];
                cliente.NDocIden = campos[6];
                cliente.Validade = campos[7];
                cliente.DataNasc = campos[8];
                cliente.Nacionalidade = campos[9];
                cliente.Naturalidade = campos[10];
                cliente.Distrito = campos[11];
                cliente.Concelho = campos[12];
                cliente.Freguesia = campos[13];
                Console.Clear();
                Console.WriteLine("Dados de: {0}\n", cliente.NomeAbre);
                Console.WriteLine("");
                Console.WriteLine("Nome Comp.: {0}, Titulo: {1}", cliente.NomeC, cliente.Titulo);
                Console.WriteLine("Genero.: {0}, Tipo Id.: {1}", cliente.Genero, cliente.TipoId);
                Console.WriteLine("Nº Doc.Ident.: {0}, Nacionalidade: {1}", cliente.NDocIden, cliente.Nacionalidade);
                Console.WriteLine("Naturalidade: {0}, Distrito: {1}", cliente.Naturalidade, cliente.Distrito);
                Console.WriteLine("Concelho: {0}, Freguesia.: {1}", cliente.Concelho, cliente.Freguesia);
                Console.WriteLine("D.Nasc.: {0}, NIF.: {1}, Validade: {2}", cliente.DataNasc, cliente.Nif, cliente.Validade);
                Console.WriteLine("ENTER para continuar");
                Console.ReadKey();

            }
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
                    cliente.SaveFile();
                    break;
                case 5:
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