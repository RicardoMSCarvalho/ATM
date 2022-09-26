using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using ProjetoFinal.Movimentos;

namespace ProjetoFinal{
    class DepositoTrans : Movimento{
        string Nome;
        string iban ;

        public DepositoTrans(Conta conta, double valor, string nome, string iba)
          : base(conta, TipoMovimento.DepositoTransf, valor, "DEP-Trans"){
            this.Nome = nome;
            this.iban = iba;
        }
 
        public override bool Operacao(){
            conta.Levantar(this.Valor);
            Saldo = conta.Saldo;

            try{
                Descricao = String.Format("Deposito por transferencia");
                string dados = String.Format("{0};{1};{2};{3};{4};{5};{6}", TipoMovimento.DepositoTransf, Saldo, Valor, Data, "DEP-Trans", iban, Nome);
                StreamWriter sw = File.AppendText("Depositos.csv");
                sw.WriteLine(dados);
                sw.Close();

                /////////////////////////////////////////////////////////////////////////////////////
                /////////////////////////////////    Regista na conta    //////////////////////////

                Conta.DadosConta(conta);

                string data = String.Format("{0};{1};{2};{3};{4}", conta.Nome, conta.Iban, conta.Nib, 
                    conta.Swift,Saldo);

                StreamWriter sw1 = new StreamWriter("Conta.csv");
                sw1.WriteLine(data);
                sw1.Close();

                
                Console.WriteLine("Saldo atual " + Saldo);


                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: {0}", e.Message);
            }
            return Convert.ToBoolean(Saldo);
        }
        
        public static void MostrarTransf(string[] campos){
            string Saldo = campos[1];
            double Valor = int.Parse(campos[2]);
            DateTime Data = DateTime.Parse(campos[3]);
            string Sigla = campos[4];
            string Tipo = campos[0];
            string Nome = campos[5];
            string Receptor = campos[6];
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("| " + Tipo);
            Console.WriteLine("|------------------------------------------------------");
            Console.WriteLine("| Data: {0}", campos[3]);
            Console.WriteLine("|");
            Console.WriteLine("| {0}  Valor: {1}                                 ", Sigla, Valor);
            Console.WriteLine("|");
            Console.WriteLine("| Destinatário: {0}  Iban: {1}               ", Nome, Receptor);
            Console.WriteLine("|");
            Console.WriteLine("| Saldo após operação: {0}                       ", Saldo);
            Console.WriteLine("*******************************************************");

        }


    }
}
