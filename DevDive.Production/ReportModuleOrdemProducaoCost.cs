using System;
using System.Collections.Generic;

namespace DevDive.Production
{
    public class ReportModuleOrdemProducaoCost
    {
        public const string MODULE = "DevDive.OrdemProducao";

        public string Module { get { return MODULE; } }

        public ReportModuleOrdemProducaoCost()
        {

            ReportParameter = new MP.Reporting.Core.ReportParameter(MODULE);

            ReportParameter.AddStiVariables("DataInicial", typeof(DateTime));
            ReportParameter.AddStiVariables("DataFinal", typeof(DateTime));
        }

        public static ReportModuleOrdemProducaoCost GetInstance()
        {
            return new ReportModuleOrdemProducaoCost();
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