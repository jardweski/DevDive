using System;

namespace DevDive.Production
{
    public class ProductionOrder
    {
        public int Id { get; set; }

        public DateTime DataLancamento { get; set; }

        public DateTime? DataEntrega { get; set; }

        public int Situacao { get; set; }

        public string SituacaoDescricao
        {
            get
            {
                switch (Situacao)
                {
                    case 0:
                        return "Aberto";
                    case 1:
                        return "Iniciado";
                    case 2:
                        return "Encerrado";
                }
                return "Aberto";
            }
        }

        public string Descricao { get; set; }

        public decimal Quantidade { get; set; }

        public DateTime? DataConfirmacao { get; set; }

        public string Observacao { get; set; }

        public int? IdPedido { get; set; }
    }
}