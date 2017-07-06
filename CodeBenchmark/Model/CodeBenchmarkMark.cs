using System;

namespace CodeBenchmark.Model
{
    internal class CodeBenchmarkMark
    {
        internal Guid Session { get; set; }
        internal string Description { get; set; }
        internal string Comments { get; set; }
        internal DateTime DateMark { get; set; }
    }
}
