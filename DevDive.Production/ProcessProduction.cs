using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevDive.Production
{
    public class ProcessProduction
    {
        public int Id { get; set; }

        public int Ordem { get; set; }

        public string Descricao { get; set; }

        public decimal Tempo { get; set; }

        public decimal? TempoUtilizado { get; set; }

        public decimal Quantidade { get; set; }
        
    }
}
