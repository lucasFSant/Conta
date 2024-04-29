using Projeto;
using System;
using System.Collections.Generic;

namespace Projeto
{
    class Program
    {
        static void Main(string[] args)
        {
            List<CCorrente> contas = new List<CCorrente>();
            int op = 0;

            do
            {
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1. Acesso Administrativo");
                Console.WriteLine("2. Caixa Eletrônico");
                Console.WriteLine("3. Sair");
                Console.Write("Opção: ");
                op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 1:
                        MenuAdmin(contas);
                        break;
                    case 2:
                        MenuCaixaEletronico(contas);
                        break;
                    case 3:
                        Console.WriteLine("Saindo...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

            } while (op != 3);
        }

        static void MenuAdmin(List<CCorrente> contas)
        {
            int op = 0;

            do
            {
                Console.WriteLine("\nMenu Administrativo:");
                Console.WriteLine("1. Cadastrar Conta Corrente");
                Console.WriteLine("2. Mostrar Saldo de Todas as Contas");
                Console.WriteLine("3. Excluir Conta");
                Console.WriteLine("4. Voltar");
                Console.Write("Opção: ");
                op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 1:
                        CadastrarConta(contas);
                        break;
                    case 2:
                        MostrarSaldos(contas);
                        break;
                    case 3:
                        ExcluirConta(contas);
                        break;
                    case 4:
                        Console.WriteLine("Voltando ao menu anterior...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

            } while (op != 4);
        }

        static void CadastrarConta(List<CCorrente> contas)
        {
            Console.Write("Digite o número da conta: ");
            string numero = Console.ReadLine();

            Console.Write("Digite o limite da conta: ");
            double limite = double.Parse(Console.ReadLine());

            contas.Add(new CCorrente(numero, limite));
            Console.WriteLine("Conta cadastrada com sucesso!");
        }

        static void MostrarSaldos(List<CCorrente> contas)
        {
            Console.WriteLine("\nSaldos das Contas:");
            foreach (var conta in contas)
            {
                Console.WriteLine($"Conta {conta.numero}: Saldo = {conta.saldo}, Limite = {conta.limite}");
            }
        }

        static void ExcluirConta(List<CCorrente> contas)
        {
            Console.Write("Digite o número da conta a ser excluída: ");
            string numero = Console.ReadLine();

            CCorrente conta = contas.Find(c => c.numero == numero);
            if (conta != null)
            {
                conta.status = false;
                Console.WriteLine($"Conta {numero} excluída com sucesso!");
            }
            else
            {
                Console.WriteLine($"Conta {numero} não encontrada.");
            }
        }

        static void MenuCaixaEletronico(List<CCorrente> contas)
        {
            Console.Write("\nDigite o número da conta: ");
            string numero = Console.ReadLine();

            CCorrente conta = contas.Find(c => c.numero == numero);
            if (conta != null)
            {
                int op = 0;
                do
                {
                    Console.WriteLine("\nMenu Caixa Eletrônico:");
                    Console.WriteLine("1. Sacar");
                    Console.WriteLine("2. Depositar");
                    Console.WriteLine("3. Transferir");
                    Console.WriteLine("4. Voltar");
                    Console.Write("Opção: ");
                    op = int.Parse(Console.ReadLine());

                    switch (op)
                    {
                        case 1:
                            Console.Write("Digite o valor a sacar: ");
                            double valorSaque = double.Parse(Console.ReadLine());
                            if (conta.Sacar(valorSaque))
                                Console.WriteLine("Saque realizado com sucesso!");
                            else
                                Console.WriteLine("Saldo insuficiente ou limite excedido.");
                            break;
                        case 2:
                            Console.Write("Digite o valor a depositar: ");
                            double valorDeposito = double.Parse(Console.ReadLine());
                            if (conta.Depositar(valorDeposito))
                                Console.WriteLine("Depósito realizado com sucesso!");
                            else
                                Console.WriteLine("Valor inválido para depósito.");
                            break;
                        case 3:
                            Console.Write("Digite o número da conta de destino: ");
                            string destino = Console.ReadLine();
                            CCorrente contaDestino = contas.Find(c => c.numero == destino);
                            if (contaDestino != null)
                            {
                                Console.Write("Digite o valor a transferir: ");
                                double valorTransferencia = double.Parse(Console.ReadLine());
                                if (conta.Transferir(contaDestino, valorTransferencia))
                                    Console.WriteLine("Transferência realizada com sucesso!");
                                else
                                    Console.WriteLine("Transferência não realizada. Verifique as condições.");
                            }
                            else
                            {
                                Console.WriteLine("Conta de destino não encontrada.");
                            }
                            break;
                        case 4:
                            Console.WriteLine("Voltando ao menu anterior...");
                            break;
                        default:
                            Console.WriteLine("Opção inválida.");
                            break;
                    }

                } while (op != 4);
            }
            else
            {
                Console.WriteLine("Conta não encontrada.");
            }
        }
    }
}