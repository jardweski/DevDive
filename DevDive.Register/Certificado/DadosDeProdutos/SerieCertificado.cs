namespace DevDive.Register.Certificado.DadosDeProdutos
{
    public class SerieCertificado
    {
        public int? Id { get; set; }

        public int IdSerie { get; set; }

        public string Code { get; set; }
        public string Batch { get; set; }
        public string BotanicalSource { get; set; }
        public string Family { get; set; }
        public string Origin { get; set; }
        public string HarvestRegion { get; set; }
        public string UsedPart { get; set; }
        public string Preservative { get; set; }
        public string Colorant { get; set; }
        public string Solvent { get; set; }
        public string Carrier { get; set; }
        public string DryResidue { get; set; }
        public string Ratio { get; set; }
        public string Irradiation { get; set; }
        public string GMO { get; set; }
        public string BSE { get; set; }
    }
}