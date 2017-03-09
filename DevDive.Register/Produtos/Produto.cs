using System.Collections.Generic;
using DevDive.Register.Processos;

namespace DevDive.Register.Produtos
{
    public class Produto
    {
        public int Id { get; set; }

        public string Codigo { get; set; }

        public string Descricao { get; set; }

        public List<ProdutoComposicao> Composicao { get; set; }

        public List<Processo> Processos { get; set; }
    }
}