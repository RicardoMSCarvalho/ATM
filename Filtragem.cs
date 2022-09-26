using ProjetoFinal.Movimentos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProjetoFinal
{
    class Filtragem{
        static char a;
        static string sigla;
        static string valor;
        static bool validacao;
        static int contador;
        static string montante;
        
        public static void Executa(){

            int vid;                   
            Console.Write("Montante a procurar: ");
            montante = Console.ReadLine();
            validacao = int.TryParse(montante, out vid);

            string[] tamanho = File.ReadAllLines("Depositos.csv");
                for (int i = 0; i < tamanho.Length; i++){
                    string[] campos = tamanho[i].Split(";");
                    
                    sigla = campos[4];
                    valor = campos[2];
                if (valor == montante){ 
                        contador++;
                    if (sigla=="DEP-Trans"){
                        DepositoTrans.MostrarTransf(campos);
                        }else if (sigla=="DEP-Num"){
                            DepositoNum.MostrarNumerario(campos);
                        }else if (sigla == "DEP-MBWay"){
                            DepositoMB.MostrarTransf(campos);
                        }else if (sigla == "TRA-Num"){
                            TransNum.MostrarNumerario(campos);
                        }else if (sigla == "TRA-MBWay"){
                            TransMB.MostrarNumerario(campos);
                        }else if (sigla == "PAG-Serv"){
                            PagServicos.MostrarNumerario(campos);
                        }else if (sigla == "PAG-Est"){
                            PagEstado.MostrarNumerario(campos);
                        }else if (sigla == "PAG-Tel"){
                            PagTelemoveis.MostrarNumerario(campos);
                        }
                    }

                }

                if (contador == 0){
                    Console.WriteLine("Não foram encontrados dados, ENTER para continuar");
                }
                Console.ReadKey();

                validacao = false;
            }

        }
    }