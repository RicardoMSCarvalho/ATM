using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.IO;
using System.ComponentModel.Design.Serialization;
using ProjetoFinal.Movimentos;

namespace ProjetoFinal{
    abstract class Movimento{
        public TipoMovimento Tipo { get; protected set; }
        public double Saldo { get; protected set; }
        public double Valor { get; protected set; }
        public DateTime Data { get; protected set; }
        public string Sigla { get; protected set; }
        public string Descricao { get; protected set; }

        protected Conta conta;


        public Movimento(Conta conta, TipoMovimento tipo, double valor, string sigla){
            this.conta = conta;
            this.Tipo = tipo;
            this.Valor = Math.Round(valor, 2, MidpointRounding.AwayFromZero);
            this.Data = DateTime.Now;
            this.Sigla = sigla;
        }
        public abstract bool Operacao();
    }
}