namespace CodeBenchmark.Model
{
    public enum CodeBenchmarkReportFormat
    {
        CSV = 0,
        XML = 1
    }
    public class CodeBenchmarkReportConfig
    {
        public CodeBenchmarkReportFormat Format { get; set; }
        public string FileName { get; set; }
        public bool IncludeHeaders { get; set; }
    }
}
