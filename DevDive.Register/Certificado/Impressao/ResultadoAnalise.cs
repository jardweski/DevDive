using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevDive.Register.Certificado.Impressao
{
    public class ResultadoAnalise
    {
        public int? Id { get; set; }

        public int IdPedido { get; set; }

        public int IdSerie { get; set; }

        public int IdAnalise { get; set; }

        public string Analise { get; set; }

        public string Resultado { get; set; }
    }
}

