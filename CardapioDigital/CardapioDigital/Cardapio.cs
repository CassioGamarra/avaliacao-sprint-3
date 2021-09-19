using System;
using System.Collections.Generic;
namespace CardapioDigital
{
    public class Cardapio
    { 
        public Cardapio()
        {

        }

        public List<Produto> GerarCardapio()
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
    }
}
