namespace DevDive.Production
{
    public class ReportModuleProduction
    {
        //MP.Reporting.WinForms.ReportControl _reportControl;

        public const string MODULE = "Production";

        public string Module { get { return MODULE; } }

        public ReportModuleProduction()
        {

            ReportParameter = new MP.Reporting.Core.ReportParameter(MODULE);

            ReportParameter.AddStiVariables("IdOP", typeof(int));

        }

        public static ReportModuleProduction GetInstance()
        {
            return new ReportModuleProduction();
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