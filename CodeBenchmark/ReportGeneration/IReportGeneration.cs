using System.Collections.Generic;
using CodeBenchmark.Model;

namespace CodeBenchmark.ReportGeneration
{
    interface IReportGeneration
    {
        void GenerateReport(CodeBenchmarkReportConfig cbRptCfg, List<CodeBenchmarkReportInfo> lstInfo);
    }
}
