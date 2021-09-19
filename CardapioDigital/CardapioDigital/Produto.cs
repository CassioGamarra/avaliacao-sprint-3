using System;
namespace CardapioDigital
{
    public class Produto
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public double ValorUnitario { get; set; }

        public Produto(int codigo, string descricao, double valorUnitario)
        {
            Codigo = codigo;
            Descricao = descricao;
            ValorUnitario = valorUnitario; 
        } 
    }
}
