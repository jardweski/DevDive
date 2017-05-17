namespace DevDive.Register.Certificado.Impressao
{
    public class ReportModuleCertificado
    {
        //MP.Reporting.WinForms.ReportControl _reportControl;

        public const string MODULE = "Certificado";

        public string Module { get { return MODULE; } }

        public ReportModuleCertificado()
        {

            ReportParameter = new MP.Reporting.Core.ReportParameter(MODULE);

            ReportParameter.AddStiVariables("IdsResultados", typeof(string));

        }

        public static ReportModuleCertificado GetInstance()
        {
            return new ReportModuleCertificado();
        }

        public static System.Collections.Generic.List<MP.Reporting.Core.Report> Reports()
        {

            var reportControl = new MP.Reporting.WinForms.ReportControl();
            var reports = reportControl.GetReportList(MP.Reporting.Core.EReportType.Reserved, MODULE);

            return reports;

        }

        public MP.Reporting.Core.ReportParameter ReportParameter { get; private set; }


    }
}