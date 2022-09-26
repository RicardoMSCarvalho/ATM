using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using ProjetoFinal.Movimentos;
using System.Runtime.CompilerServices;

namespace ProjetoFinal{
    class DepositoNum : Movimento {     
        public DepositoNum(Conta conta, double valor) 
            : base(conta, TipoMovimento.DepositoNum, valor, "DEP_NUM"){
        }

        public override bool Operacao(){
            conta.Depositar(this.Valor);
            Saldo = conta.Saldo;
            Console.WriteLine(Saldo);

            Descricao = String.Format("Deposito em numerário");
            try{
               /////////////////////////////////    Regista no Depositos    //////////////////////////
                string dados = String.Format("{0};{1};{2};{3};{4};{5}", TipoMovimento.DepositoNum, Saldo, Valor, Data, "DEP-Num", conta.Iban);
                StreamWriter sw = File.AppendText("Depositos.csv");
                sw.WriteLine(dados);
                sw.Close();
                /////////////////////////////////////////////////////////////////////////////////////
                /////////////////////////////////    Regista na conta    //////////////////////////

                Conta.DadosConta(conta);

                string data = String.Format("{0};{1};{2};{3};{4}",conta.Nome, conta.Iban, conta.Nib, conta.Swift, 
                    Saldo);

                StreamWriter sw1 = new StreamWriter("Conta.csv");
                sw1.WriteLine(data);
                sw1.Close();
                Console.WriteLine("ENTER para continuar");
                Console.ReadKey();

            }
            catch (Exception){
                Console.WriteLine("ERRO");
            }
            return true;
        }

        public static void MostrarNumerario(string[] campos){
            double Saldo = double.Parse(campos[1]);
            string Sigla = campos[4];
            string Valor = campos[2];
            DateTime Data = DateTime.Parse(campos[3]);
            string Tipo = campos[0];

            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("|");
            Console.WriteLine("| " + Tipo);
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("| Data: {0}", campos[3]);
            Console.WriteLine("|");
            Console.WriteLine("| {0}  Valor: {1}                                 ", Sigla, Valor);
            Console.WriteLine("|");
            Console.WriteLine("| Saldo após operação: {0}                       ", Saldo);
            Console.WriteLine("|");
            Console.WriteLine("*******************************************************");
        }
    }
}