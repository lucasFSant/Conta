using Projeto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto
{
    public class CPoupanca : Conta
    {
        public CPoupanca() : base()
        {
            this.saldo = 0;
            this.status = true;
            Transacoes = new List<Transacao>();
            this.limite = 0;
        }
        public CPoupanca(string numero) : this()
        {
            this.numero = numero;
        }
    }
}