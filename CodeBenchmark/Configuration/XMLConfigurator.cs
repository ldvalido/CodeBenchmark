using System.IO;
using CodeBenchmark.Model;
using CodeBenchmark.Utils;

namespace CodeBenchmark.Configuration
{
    internal class XMLConfigurator : IConfigurator
    {
        #region IConfigurator

        public CodeBenchmarkConfig Configure<T>(T objConfig)
        {
            CodeBenchmarkConfig returnValue = null;
            var fileName = objConfig.ToString();
            if (File.Exists(fileName))
            {
                returnValue = SerializationHelper.Deserealize<CodeBenchmarkConfig>(fileName);
            }
            return returnValue;
        }

        #endregion

        
    }
}
