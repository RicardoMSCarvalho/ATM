using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.IO;

namespace ProjetoFinal{
    class Conta{
        public string Nome { get; set; }
        public string Iban { get; set; }
        public string Nib { get; set; }
        public string Swift { get; set; }
        public double Saldo { get; private set; }
               
        public Conta(){
            this.Saldo = 0;
        }

        public Conta(string nome, string iban, string nib, string swift, double saldo){
            this.Nome = nome;
            this.Iban = iban;
            this.Nib = nib;
            this.Swift = swift;
            this.Saldo = saldo;
        }


        public void getSaldo(double saldo){
            this.Saldo = saldo;
        }
        public void Depositar(double valor){
            this.Saldo += valor;
        }

        public bool Levantar(double valor){
            if (Saldo - valor > 0){
                this.Saldo -= valor;
                return true;
            }
            return false;
        }

        public override string ToString(){
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Nome: {0}\n", Nome);
            sb.AppendFormat("IBAN: {0}\n", Iban);
            sb.AppendFormat("Nib: {0}\n", Nib);
            sb.AppendFormat("Swift: {0}\n", Swift);
            return sb.ToString();
        }
        public bool SaveFile(){
            try { 
            string dados = String.Format("{0};{1};{2};{3}", Nome, Iban, Nib, Swift);

            StreamWriter sw = new StreamWriter("Conta.csv");
            sw.WriteLine(dados);
            sw.Close();
            Console.WriteLine("Relatório gerado com sucesso");
            Console.ReadKey();
            }catch (FileNotFoundException e){
                Console.WriteLine($"Erro, ficheiro não encontrado: '{e}'");
            }
            return true;
        }

        public static void DadosConta(Conta conta) {
            StreamReader sr = new StreamReader("Conta.csv");
            string dados = sr.ReadLine();
            sr.Close();

            string[] campos = dados.Split(";");
            if (campos.Length != 5)
                Console.WriteLine("Ficheiro corrompido");

            conta.Nome = campos[0];
            conta.Iban = campos[1];
            conta.Nib = campos[2];
            conta.Swift = campos[3];
            conta.getSaldo(double.Parse(campos[4]));
        }
    }
}
