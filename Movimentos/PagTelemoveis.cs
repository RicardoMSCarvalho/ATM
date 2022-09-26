using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.IO;
using System.ComponentModel.Design.Serialization;
using ProjetoFinal.Movimentos;
using System.Net;

namespace ProjetoFinal.Movimentos
{
    class PagTelemoveis : Movimento{
        string operadora;
        string nome;
        string nif;
        string referencia;

        public PagTelemoveis(Conta conta, double valor, string operadora, string referencia,string nome, string nif)
            : base(conta, TipoMovimento.PagServiços, valor, "Pag-Tel"){
            this.operadora = operadora;
            this.nome = nome;
            this.nif = nif;
            this.nome = nome;
        }
        public override bool Operacao(){
            conta.Levantar(this.Valor);
            Saldo = conta.Saldo;
            try{
                string dados = String.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8}", TipoMovimento.PagTelemoveis, Saldo, Valor, Data, "PAG-Tel", nif, nome, referencia, operadora);
                StreamWriter sw = File.AppendText("Depositos.csv");
                sw.WriteLine(dados);
                sw.Close();

                /////////////////////////////////////////////////////////////////////////////////////
                /////////////////////////////////    Regista na conta    //////////////////////////

                Conta.DadosConta(conta);
                string data = String.Format("{0};{1};{2};{3};{4}", conta.Nome, conta.Iban, conta.Nib,
                    conta.Swift, Saldo);

                StreamWriter sw1 = new StreamWriter("Conta.csv");
                sw1.WriteLine(data);
                sw1.Close();

                Console.WriteLine("Saldo atual: " + Saldo);
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: {0}", e.Message);
            }
            return Convert.ToBoolean(Saldo);
        }
        public static void MostrarNumerario(string[] campos)
        {
            string Tipo = campos[0];
            double Saldo = double.Parse(campos[1]);
            string Valor = campos[2];
            DateTime Data = DateTime.Parse(campos[3]);
            string Sigla = campos[4];
            string referencia = campos[5];
            string nif = campos[6];
            string operadora = campos[7];

            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("|");
            Console.WriteLine("| " + Tipo);
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("| Data: {0}", Data);
            Console.WriteLine("|");
            Console.WriteLine("| {0}                                 ", Sigla);
            Console.WriteLine("|");
            Console.WriteLine("| Operadora: {0}  Contacto: {1}    NIF: {2}                             ", operadora, referencia, nif);
            Console.WriteLine("|");
            Console.WriteLine("| Valor: {0}                                 ", Valor);
            Console.WriteLine("|");
            Console.WriteLine("| Saldo após operação: {0}                       ", Saldo);
            Console.WriteLine("|");
            Console.WriteLine("*******************************************************");
        }

    }
}