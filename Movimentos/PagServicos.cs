using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using ProjetoFinal.Movimentos;

namespace ProjetoFinal.Movimentos
{
    class PagServicos:Movimento{
        string entidade;
        string referencia;

        public PagServicos(Conta conta, double valor, string entidade, string referencia)
            : base(conta, TipoMovimento.PagServiços, valor, "Pag-Serv") {
            this.entidade = entidade;
            this.referencia = referencia;
        }
        public override bool Operacao(){
            conta.Levantar(this.Valor);
            Saldo = conta.Saldo;
            try
            {

                string dados = String.Format("{0};{1};{2};{3};{4};{5};{6}", TipoMovimento.PagServiços, Saldo, Valor, Data, "PAG-Serv", entidade, referencia);
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
            string Tipo = campos[0];
            double Saldo = double.Parse(campos[1]);
            string Valor = campos[2];
            DateTime Data = DateTime.Parse(campos[3]);
            string Sigla = campos[4];
            string entidade = campos[5];
            string referencia = campos[6];
            
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("|");
            Console.WriteLine("| " + Tipo);
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("| Data: {0}", Data);
            Console.WriteLine("|");
            Console.WriteLine("| {0}                                 ", Sigla);
            Console.WriteLine("|");
            Console.WriteLine("| Destinatário: {0}  Iban: {1}                                 ", entidade, referencia);
            Console.WriteLine("|");
            Console.WriteLine("| Valor: {0}                                 ", Valor);
            Console.WriteLine("|");
            Console.WriteLine("| Saldo após operação: {0}                       ", Saldo);
            Console.WriteLine("|");
            Console.WriteLine("*******************************************************");
        }
    }
}
