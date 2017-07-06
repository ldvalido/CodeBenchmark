using System.Collections.Generic;
using CodeBenchmark.Model;
using CodeBenchmark.Utils;


namespace CodeBenchmark.ReportGeneration
{
    internal class CSVReportGeneration : IReportGeneration
    {
        public void GenerateReport(CodeBenchmarkReportConfig cbRptCfg, List<CodeBenchmarkReportInfo> lstInfo)
        {

            if (cbRptCfg != null)
            {
                var fileName = cbRptCfg.FileName;
                
                FileSystemHelper.SafePath(fileName);

                var csvRender = new CSVRenderFile<CodeBenchmarkReportInfo>
                                    {
                                        Delimiter = ";",
                                        IncludeHeaders = true
                                    };
                csvRender.Render(fileName,lstInfo);

            }
        }

        
    }
}
