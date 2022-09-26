using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using ProjetoFinal.Movimentos;

namespace ProjetoFinal{
    class TransNum:Movimento   {
        string nome;
        string iban;

        public TransNum(Conta conta, double valor, string iban, string nome)
            : base(conta, TipoMovimento.DepositoNum, valor, "TRA-Num"){
            this.nome = nome;
            this.iban = iban;
        }

        public override bool Operacao(){
            conta.Levantar(this.Valor);
            Saldo = conta.Saldo;
            try{

                Descricao = String.Format("Transferencia monetaria");
                string dados = String.Format("{0};{1};{2};{3};{4};{5};{6}", TipoMovimento.TransNum, Saldo, Valor, Data, "TRA-Num",iban,nome );
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
        public static void MostrarNumerario(string[] campos){
            double Saldo = double.Parse(campos[1]);
            string Sigla = campos[4];
            string Valor = campos[2];
            string Nome = campos[6];
            string Iban = campos[5];
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
            Console.WriteLine("| Destinatário: {0}  Iban: {1}                                 ", Iban, Nome);
            Console.WriteLine("|");
            Console.WriteLine("| Saldo após operação: {0}                       ", Saldo);
            Console.WriteLine("|");
            Console.WriteLine("*******************************************************");
        }

    }
}