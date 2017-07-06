using System.Collections.Generic;

namespace CodeBenchmark.Model
{
    public class CodeBenchmarkConfig
    {
        public List<CodeBenchmarkReportConfig> ReportConfigs { get; set; }
        
        public CodeBenchmarkConfig()
        {
            ReportConfigs=new List<CodeBenchmarkReportConfig>();
        }
    }
}
