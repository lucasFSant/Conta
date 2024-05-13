using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto
{
    public class Conta
    {
        public string numero;
        public double saldo;
        public bool status;
        public double limite;
        public List<Transacao>
            Transacoes;

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

        public bool Transferir(CCorrente destino, double valor)
        {
            if (destino.status && Sacar(valor) && destino.Depositar(valor))
            {
                Transacoes[Transacoes.Count - 1].duplicata = destino.Transacoes[destino.Transacoes.Count - 1];
                destino.Transacoes[destino.Transacoes.Count - 1].duplicata = Transacoes[Transacoes.Count - 1];
                return true;
            }
            return false;
        }
        public bool Transferir(CPoupanca destino, double valor)
        {
            if (destino.status && Sacar(valor) && destino.Depositar(valor))
            {
                Transacoes[Transacoes.Count - 1].duplicata = destino.Transacoes[destino.Transacoes.Count - 1];
                destino.Transacoes[destino.Transacoes.Count - 1].duplicata = Transacoes[Transacoes.Count - 1];
                return true;
            }
            return false;
        }
    }
}