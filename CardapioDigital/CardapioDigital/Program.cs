using System;
using System.Collections.Generic;
using System.Globalization;

namespace CardapioDigital
{
    class Program
    {

        public static int[] mesasAceitas = { 1, 2, 3, 4 };
        public static Cardapio cardapio = new Cardapio();
        public static List<Produto> listaProdutos = cardapio.GerarCardapio();

        static void Main(string[] args)
        {
            bool exibirMenu = true;

            while (exibirMenu)
            {
                exibirMenu = Menu();
            }
        }

        private static bool Menu()
        {
            Console.Clear();
            Console.Write("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒ PEDIDOS ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("╔═════════════════MENU DE OPÇÕES════════════════╗    ");
            Console.WriteLine("║ 1 EFETUAR PEDIDO                              ║    ");
            Console.WriteLine("║ 2 SAIR                                        ║    ");
            Console.WriteLine("╚═══════════════════════════════════════════════╝    ");

            Console.WriteLine(" ");
            Console.Write("DIGITE UMA OPÇÃO : ");

            switch (Console.ReadLine())
            {
                case "1":
                    RealizarPedido();
                    return true;
                case "2":
                    return false;
                default:
                    return true;
            }
        }

        private static void RealizarPedido()
        {
            Console.Clear();  
            bool isValid = true;
            string numeroMesa;
            string msgValidacaoMesa;
            do
            {
                msgValidacaoMesa = isValid ? "Qual o numero da mesa?: " : "Mesa invalida! Digite novamente o numero da mesa: "; 
                Console.WriteLine("Pedido");
                Console.Write(msgValidacaoMesa);
                numeroMesa = Console.ReadLine();
                isValid = false;
                foreach (int mesa in mesasAceitas)
                {
                    if (mesa.ToString() == numeroMesa)
                    {
                        isValid = true;
                    }
                }
                if (!isValid)
                {
                    Console.Clear();
                }
            } while (!isValid);
             
            Console.WriteLine("Código  Produto               Preço Unitário (R$)");
            foreach (Produto produto in listaProdutos)
            {
                Console.WriteLine(produto.Codigo.ToString().PadRight(7, ' ') + produto.Descricao.PadRight(20, ' ') + "R$ " + produto.ValorUnitario.ToString("0.00").Replace('.', ',').PadLeft(5, ' '));
            }
            Console.WriteLine("999    Encerra pedido");

            Pedido pedido = new Pedido();
            pedido.ListaDeProdutos = new List<Produto>();
            string codigo = "";
            int quantidade;
            while (codigo != "999")
            {
                Console.Write("Informe o Codigo: ");
                codigo = Console.ReadLine();
                isValid = false;
                foreach (Produto produto in listaProdutos)
                {
                    if (codigo == produto.Codigo.ToString())
                    { 
                        Console.Write("Informe a Quantidade: ");
                        bool isQtdValid = int.TryParse(Console.ReadLine(), out quantidade);
                        if (isQtdValid)
                        {
                            pedido.ListaDeProdutos.Add(produto);
                            pedido.ValorTotal += produto.ValorUnitario * quantidade; 
                        }
                        else
                        {
                            Console.WriteLine("Quantidade invalida!");
                        }
                        isValid = true; //Para validação do código
                    } 
                }
                if (!isValid)
                {
                    Console.WriteLine("Codigo invalido!");
                }
            }
            Console.Clear();
            Console.WriteLine("A mesa " + numeroMesa + " pediu os seguintes itens:"); 
            for(int i = 0; i < pedido.ListaDeProdutos.Count; i++)
            {
                Console.WriteLine((i+1) + " - " + pedido.ListaDeProdutos[i].Descricao);
            }
            Console.WriteLine("Com o valor total de R$: " + pedido.ValorTotal.ToString("0.00").Replace('.', ','));
            Console.Write("Pressione uma tecla para continuar...");
            Console.ReadKey();
        }  
    }
}