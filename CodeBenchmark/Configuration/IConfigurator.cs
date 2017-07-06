using CodeBenchmark.Model;

namespace CodeBenchmark.Configuration
{
    interface IConfigurator
    {
        CodeBenchmarkConfig Configure<T>(T objConfig);
    }
}
