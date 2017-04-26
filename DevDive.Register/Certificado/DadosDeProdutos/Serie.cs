﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevDive.Register.Certificado.DadosDeProdutos
{
    public class Serie
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

        public DateTime Data { get; set; }

        public decimal Estoque { get; set; }
    }
}
