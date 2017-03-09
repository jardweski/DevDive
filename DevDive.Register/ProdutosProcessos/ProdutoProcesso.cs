using DevDive.Register.Produtos;

namespace DevDive.Register.ProdutosProcessos
{
    public class ProdutoProcesso
    {
        public ProdutoProcesso(int idProduto, ProdutoControle produtoControl)
        {
            IdProduto = idProduto;
            Unidade = produtoControl.GetUnitProduct(idProduto);
        }

        public int Ordem { get; set; }

        public int? Id { get; set; }

        public int IdProduto { get; set; }

        public int IdProcesso { get; set; }

        public string DescricaoProcesso { get; set; }

        public decimal CustoProcesso { get; set; }

        public decimal Tempo { get; set; }

        public decimal Quantidade { get; set; }

        public string Unidade { get; }
    }
}