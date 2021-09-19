using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace CardapioDigital
{
    public class Pedido
    {
        [JsonProperty("ValorTotal")]
        public double ValorTotal { get; set; }
        [JsonProperty("Itens")]
        public List<Produto> ListaDeProdutos { get; set; }

        public Pedido()
        { 
        }
    }
}
