using CodeBenchmark.Model;

namespace CodeBenchmark.Configuration
{
    internal enum CodeBenchmarkConfSource
    {
        Memory = 0,
        XML = 1
    }
    
    internal class ConfiguratorContext : IConfigurator
    {
        #region Properties

        private IConfigurator _ctx;

        #endregion

        #region C...tor
        public ConfiguratorContext(CodeBenchmarkConfSource source)
        {
            switch (source)
            {
                case CodeBenchmarkConfSource.Memory:
                    _ctx = new MemoryConfiguration();
                    break;
                case CodeBenchmarkConfSource.XML:
                    _ctx = new XMLConfigurator();
                    break;
            }
        }

        #endregion

        #region IConfigurator
        public CodeBenchmarkConfig Configure<T>(T objConfig)
        {
            return _ctx.Configure(objConfig);
        }
        #endregion

        
    }
}
