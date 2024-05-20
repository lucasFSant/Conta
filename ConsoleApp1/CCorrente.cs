using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Projeto
{
    public class CCorrente: Conta
    {
        private bool especial;
        public CCorrente(string numero, double limite) : base()
        {
            this.limite = limite;
            this.numero = numero;
        }
        public CCorrente() : base()
        {
            this.saldo = 0;
            this.status = true;
            Transacoes = new List<Transacao>();
        }

    }
}