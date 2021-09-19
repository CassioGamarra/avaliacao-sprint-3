using System;
using System.Collections.Generic;
namespace CardapioDigital
{
    public class Pedido
    {
        public double ValorTotal { get; set; }
        public List<Produto> ListaDeProdutos { get; set; }

        public Pedido()
        { 
        }
    }
}
