using System;

namespace CodeBenchmark.Configuration
{
    internal class MemoryConfiguration:IConfigurator
    {
        #region IConfigurator

        public Model.CodeBenchmarkConfig Configure<T>(T objConfig)
        {
            Model.CodeBenchmarkConfig returnValue = null;
            var obj = (Model.CodeBenchmarkConfig) Convert.ChangeType(objConfig, typeof (T));
            if (objConfig != null)
            {
                returnValue = obj;
            }
            return returnValue;
        }

        #endregion

    }
}
