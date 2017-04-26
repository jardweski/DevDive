namespace DevDive.Register.ProdutosAnalises
{
    public class ProdutoAnalise
    {
        public ProdutoAnalise(int idProduto)
        {
            IdProduto = idProduto;   
        }
        
        public int? Id { get; set; }

        public int IdProduto { get; set; }

        public int IdAnalise { get; set; }

        public string DescricaoAnalise { get; set; }

        public ETipoAnalise Tipo { get; set; }

        public string Especificacao { get; set; }

        public EMetodoAnalise Metodo { get; set; }

    }
}