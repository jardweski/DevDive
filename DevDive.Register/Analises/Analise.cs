namespace DevDive.Register.Analises
{
    public class Analise
    {
        public int? Id { get; set; }

        public string Descricao { get; set; }

        public ETipoAnalise Tipo { get; set; }

        public string Especificacao { get; set; }

        public EMetodoAnalise Metodo { get; set; }

        public decimal Resultado { get; set; }
    }
}