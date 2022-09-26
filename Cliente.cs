using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace ProjetoFinal{
    class Cliente{
        public string NomeC { get; set; }  
        public string NomeAbre { get; set; }
        public string Titulo { get; set; }  
        public string Genero { get; set; }
        public string TipoId { get; set; }   
        public string Nacionalidade { get; set; }
        public string Naturalidade { get; set; } 
        public string Concelho { get; set; }
        public string Freguesia { get; set; } 
        public string DataNasc { get; set; }
        public string Nif { get; set; }  
        public string NDocIden { get; set; }
        public string Validade { get; set; }
        public string Distrito { get; set; }
      
        public Cliente(){
        }
        
        public Cliente(string nomeC, string freguesia, string nomeabre, string naturalidade, string nacionalidade, 
            string concelho, string datanasc, string nif, string ndociden, string val){
            this.NomeC = nomeC;
            this.Freguesia = freguesia;
            this.NomeAbre = nomeabre;
            this.Naturalidade = naturalidade;
            this.Nacionalidade = nacionalidade;
            this.Concelho = concelho;
            this.DataNasc = datanasc;
            this.Nif = nif;
            this.NDocIden = ndociden;
            this.Validade = val;
        }

        public override string ToString(){
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Bem-vindo {0}\n", NomeAbre);
            Console.WriteLine();
            sb.AppendFormat("Nome Completo: {0}\nTitulo: {1}\n", NomeC, Titulo);
            Console.WriteLine();
            sb.AppendFormat("Tipo de Identificação : {0}\nNacionalidade:{1}\n", TipoId, Nacionalidade);
            Console.WriteLine();
            sb.AppendFormat("Naturalidade: {0}\nDistrito: {1}\n", Naturalidade, Distrito);
            Console.WriteLine();
            sb.AppendFormat("Concelho : {0}\nFreguesia: {1}\n", Concelho, Freguesia);
            Console.WriteLine();
            sb.AppendFormat("Data de Nascimento : {0}\nNIF: {1}\n", DataNasc, Nif);
            Console.WriteLine();
            sb.AppendFormat("Género : {0}\n", Genero);
            Console.WriteLine();    
            sb.AppendFormat("Validade: {0}\nNº Doc. Ident: {1}\n", Validade, NDocIden);
           return sb.ToString();
     
        }


        public bool SaveFile() {
            try{
                string dados = String.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};{10};{11};{12};{13}",
                    NomeC, NomeAbre, Titulo, Genero, Nif, TipoId, NDocIden, Validade, DataNasc,
                    Nacionalidade, Naturalidade, Distrito, Concelho, Freguesia);

                StreamWriter sw = new StreamWriter("Cliente.csv");
                sw.WriteLine(dados);
                sw.Close();
                Console.WriteLine("Relatório gerado com sucesso");
                Console.ReadKey();
            }catch (FileNotFoundException e){
                Console.WriteLine($"Erro, ficheiro não encontrado: '{e}'");
            }
            return true;
        }
       


    }
}