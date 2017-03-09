SELECT  tblprodutos.Id ,
        tblprodutos.Codigo ,
        tblprodutos.Descricao
FROM    tblprodutos
        INNER JOIN tblprodutoscomposicaomp ON tblprodutoscomposicaomp.IdProduto = tblprodutos.Id
GROUP BY tblprodutos.Id ,
        tblprodutos.Codigo ,
        tblprodutos.Descricao
ORDER BY tblprodutos.Descricao;