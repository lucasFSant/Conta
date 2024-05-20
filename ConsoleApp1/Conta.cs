using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto
{
    public class Conta
    {
        protected string numero;
        protected double saldo;
        protected bool status;
        protected double limite;
        protected List<Transacao>
            Transacoes;
        public string Numero
        {
            get => this.numero;
            set
            {
                if ("" != value)
                    this.numero = value;
            }
        }
        
        public double Saldo
        {
            get => this.saldo;
        }
        public double Limite
        {
            get => this.limite;
            set
            {
                if(value>=0)
                    this.limite = value;
            }
        }
        public bool Status
        {
            get => this.status;
            set => this.status = value;
        }
        public List<Transacao> Transacoes1
        {
            get => this.Transacoes;
        }
        public Conta()
        {
            this.saldo = 0;
            this.status = true;
            Transacoes = new List<Transacao>();
        }
        public Conta(string numero) : this()
        {
            this.limite = limite;
            this.numero = numero;
        }
        public bool Sacar(double valor)
        {
            if (saldo - valor > -limite)
            {
                saldo -= valor;
                Transacoes.Add(new Transacao(valor, 'S', this));
                return true;
            }
            return false;
        }
        public bool Depositar(double valor)
        {
            if (valor > 0)
            {
                saldo += valor;
                Transacoes.Add(new Transacao(valor, 'D', this));
                return true;
            }
            return false;
        }

        public bool Transferir(Conta destino, double valor)
        {
            if (destino.status && Sacar(valor) && destino.Depositar(valor))
            {
                Transacoes[Transacoes.Count - 1].Duplicata = destino.Transacoes[destino.Transacoes.Count - 1];
                destino.Transacoes[destino.Transacoes.Count - 1].Duplicata = Transacoes[Transacoes.Count - 1];
                return true;
            }
            return false;
        }

    }
}