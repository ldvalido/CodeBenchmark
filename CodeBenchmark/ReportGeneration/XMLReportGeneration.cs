using System.Collections.Generic;
using System.IO;
using CodeBenchmark.Model;
using CodeBenchmark.Utils;

namespace CodeBenchmark.ReportGeneration
{
    internal class XMLReportGeneration : IReportGeneration
    {
        public void GenerateReport(CodeBenchmarkReportConfig cbRptCfg, List<CodeBenchmarkReportInfo> lstInfo)
        {
            if (cbRptCfg != null)
            {
                var fileName = cbRptCfg.FileName;
                
                FileSystemHelper.SafePath(fileName);
                
                File.WriteAllText(fileName, SerializationHelper.Serialize(lstInfo));
            }
        }
    }
}
