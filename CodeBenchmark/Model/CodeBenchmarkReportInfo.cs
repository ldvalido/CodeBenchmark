namespace CodeBenchmark.Model
{
    public class CodeBenchmarkReportInfo
    {
        public int Step { get; set; }
        public string Description { get; set; }
        public string Comments { get; set; }
        public string Start { get; set; }
        public string Finish { get; set; }
        public double Partial { get; set; }
        public double SubTotal { get; set; }
    }
}
