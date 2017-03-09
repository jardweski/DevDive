using System;

namespace DevDive.Production
{
    public class Requisitions
    {
        public bool Checked { get; set; }

        public string Tipo { get; set; }

        public int Id { get; set; }

        public DateTime Data { get; set; }

        public string Usuario { get; set; }

        public string Observacao { get; set; }
    }
}