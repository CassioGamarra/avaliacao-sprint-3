using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;

namespace CardapioDigital
{
    class Program
    {

        public static int[] mesasAceitas = { 1, 2, 3, 4 };
        
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

        public static List<Produto> GerarCardapio()
        {
            List<Produto> listaDeProduto = new List<Produto>();

            listaDeProduto.Add(new Produto(100, "Cachorro quente", 5.7));
            listaDeProduto.Add(new Produto(101, "X Completo", 18.30));
            listaDeProduto.Add(new Produto(102, "X Salada", 16.50));
            listaDeProduto.Add(new Produto(103, "Hamburguer", 22.40));
            listaDeProduto.Add(new Produto(104, "Coca 2L", 10.00));
            listaDeProduto.Add(new Produto(105, "Refrigerante", 1.00));

            return listaDeProduto;
        }

        private static void RealizarPedido()
        {
            Console.Clear();  
            bool isValid = true;
            string numeroMesa;
            string msgValidacaoMesa;
            Cardapio cardapio = new Cardapio();
            cardapio.ListaDeProdutos = GerarCardapio();
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
            foreach (Produto produto in cardapio.ListaDeProdutos)
            {
                Console.WriteLine(produto.Codigo.ToString().PadRight(7, ' ') + produto.Descricao.PadRight(20, ' ') + "R$ " + produto.ValorUnitario.ToString("0.00").Replace('.', ',').PadLeft(5, ' '));
            }
            Console.WriteLine("999    Encerra pedido");

            Pedido pedido = new Pedido();
            pedido.ListaDeProdutos = new List<Produto>();
            Dictionary<String, int> listaPedidoAmigavel = new Dictionary<String, int>();
            string codigo = "";
            int quantidade;
            while (codigo != "999")
            {
                Console.Write("Informe o Codigo: ");
                codigo = Console.ReadLine();
                isValid = false;
                foreach (Produto produto in cardapio.ListaDeProdutos)
                {
                    if (codigo == produto.Codigo.ToString())
                    { 
                        Console.Write("Informe a Quantidade: ");
                        bool isQtdValid = int.TryParse(Console.ReadLine(), out quantidade);
                        if (isQtdValid)
                        {
                            pedido.ListaDeProdutos.Add(produto);  
                            pedido.ValorTotal += produto.ValorUnitario * quantidade;
                            //Adiciona na lista para exibir
                            if (!listaPedidoAmigavel.ContainsKey(produto.Descricao))
                            {
                                listaPedidoAmigavel.Add(produto.Descricao, quantidade);
                            }
                            else
                            {
                                listaPedidoAmigavel[produto.Descricao] += quantidade;
                            }
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
            pedido.ValorTotal = Math.Round(pedido.ValorTotal);
            Console.Clear();
            Console.WriteLine("A mesa " + numeroMesa + " pediu os seguintes itens:");

            foreach (KeyValuePair<String, int> kvp in listaPedidoAmigavel)
            {
                Console.WriteLine(kvp.Value + " - " + kvp.Key);
            }

            Console.WriteLine("Com o valor total de R$: " + pedido.ValorTotal.ToString("0.0").Replace('.', ','));
             
            Console.WriteLine(JsonConvert.SerializeObject(pedido.ListaDeProdutos.Distinct().ToList(), Formatting.Indented)); 

            Console.Write("Pressione uma tecla para continuar...");
            Console.ReadKey();
        }  
    }
}