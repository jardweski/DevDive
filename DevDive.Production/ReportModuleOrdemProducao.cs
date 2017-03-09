using System.Collections.Generic;

namespace DevDive.Production
{
    public class ReportModuleOrdemProducao
    {
        public const string MODULE = "DevDive.OrdemProducao";

        public string Module { get { return MODULE; } }

        public ReportModuleOrdemProducao()
        {

            ReportParameter = new MP.Reporting.Core.ReportParameter(MODULE);

            ReportParameter.AddStiVariables("IdOP", typeof(int));
        }

        public static ReportModuleOrdemProducao GetInstance()
        {
            return new ReportModuleOrdemProducao();
        }

        public static List<MP.Reporting.Core.Report> Reports()
        {

            var reportControl = new MP.Reporting.WinForms.ReportControl();
            var reports = reportControl.GetReportList(MP.Reporting.Core.EReportType.Reserved, MODULE);

            return reports;

        }

        public MP.Reporting.Core.ReportParameter ReportParameter { get; private set; }
    }
}