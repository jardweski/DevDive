using System;

namespace DevDive.Production
{
    public class Orders
    {
        public int IdPedido { get; set; }

        public DateTime DataEntrega { get; set; }

        public string Codigo { get; set; }

        public string Descricao { get; set; }

        public int? IdOrdemProducao { get; set; }
        public string NumeroNF { get; set; }
        public string Situacao { get; set; }
    }
}