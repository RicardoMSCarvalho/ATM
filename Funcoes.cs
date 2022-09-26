using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;

namespace ProjetoFinal
{
    public static class Funcoes{
        
        public static string LerString(string x){
            Console.Write("Introduza o {0}: ", x);
            return Console.ReadLine();
        }

        public static string LerNIF() {
            int conta = 0;
            string Nif;
            do {
                Console.Write("NIF: ");
                Nif = Console.ReadLine();

                foreach (char c in Nif) 
                    if (char.IsNumber(c)) {
                        conta++;
                    } else {
                        Console.WriteLine("Apenas números são permitidos");
                        break;
                    }
                    if (conta != 9) {
                        conta = 0;
                    }
                } while (conta != 9) ;
                return Nif;
            
}               
        public static string LerIBAN(){
            int contadorLetras ;
            int contadorNum ;
            string iban;

            do{
                contadorNum = 0;
                contadorLetras = 0;
                Console.Write("IBAN: ");
                iban = Console.ReadLine();
    
                for (int i = 0; i < 2; i++){
                    if (char.IsLetter(iban[i])){
                        contadorLetras++;
                    }else{
                        break;
                    }
                }
                for (int j = 2; j < iban.Length; j++){
                    if (char.IsNumber(iban[j])){
                        contadorNum++;
                    }else{
                        break;
                    }
                }
           }while (contadorLetras != 2 || contadorNum != 23 || iban.Length!=25);
               
            return iban;
        }
        

        public static string LerNIB(){
            int caracteres;
            string Nib;
            do{
                caracteres = 0;
                Console.Write("NIB: ");
                Nib = Console.ReadLine();
                for (int i = 0; i < Nib.Length; i++){
                    if (char.IsNumber(Nib[i])){
                        caracteres++;
                    }
                }
            } while (caracteres != 21 ||Nib.Length!=21);
            return Nib ;
            }

        public static string LerSWIFT(){
            int contador;
            string swift;
            do{
                contador = 0;
                Console.Write("Swift: ");
                swift = Console.ReadLine();

                for (int i = 0; i < swift.Length; i++){
                    if (char.IsLetter(swift[i])){
                        contador++;
                    }
                }
            } while (contador != swift.Length || contador<8|| contador > 11);
            return swift;
        }
        
        public static string LerDoc(){
            string tipoId;

            do{
                Console.Write("Documento de Identificação <BI ou CC> :");
                tipoId = Console.ReadLine();
            } while (tipoId != "BI" && tipoId != "CC");
            return tipoId;
        }

        public static string LerGen(){
           string genero;
                do{
                Console.WriteLine("Género < M, F> ");
                genero = Console.ReadLine();

                } while (genero != "M" && genero != "F");
            return genero;

        }
    }
}
