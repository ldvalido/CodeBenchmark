using System.Collections.Generic;
using CodeBenchmark.Model;

namespace CodeBenchmark.ReportGeneration
{
    internal class ReportGenerationContext : IReportGeneration
    {
        #region Properties
        private readonly IReportGeneration _reportGeneration;
        #endregion

        #region C.tor
        internal ReportGenerationContext(CodeBenchmarkReportFormat reportFormat)
        {
            switch (reportFormat)
            {
                case CodeBenchmarkReportFormat.CSV:
                    _reportGeneration = new CSVReportGeneration();
                    break;
                case CodeBenchmarkReportFormat.XML:
                    _reportGeneration = new XMLReportGeneration();
                    break;
            }
        }
        #endregion

        #region iReport Generation Members
        public void GenerateReport(CodeBenchmarkReportConfig cbRptCfg, List<CodeBenchmarkReportInfo> lstInfo)
        {
            _reportGeneration.GenerateReport(cbRptCfg, lstInfo);
        }
        #endregion
        
    }
}
