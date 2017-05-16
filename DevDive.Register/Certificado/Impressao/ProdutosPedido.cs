using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevDive.Register.Certificado.Impressao
{
    public class ProdutosPedido
    {
        public int? IdOrdemProducao { get; set; }
        public int? IdPedido { get; set; }
        public int? IdProduto { get; set; }
        public string ProdutoCodigo { get; set; }
        public string ProdutoDescricao { get; set; }
        public int? IdSerie { get; set; }
        public string Serie { get; set; }
    }
}
