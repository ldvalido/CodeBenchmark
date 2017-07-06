using System;
using System.Collections.Generic;
using System.Linq;
using CodeBenchmark.Configuration;
using CodeBenchmark.Model;
using CodeBenchmark.ReportGeneration;
using CodeBenchmark.Utils;

namespace CodeBenchmark
{
    public class CodeBenchmarkManager
    {
        #region Properties
        private Guid _benchMarkSession;
        private CodeBenchmarkConfig _config;
        readonly List<CodeBenchmarkMark> _lstMarkes = new List<CodeBenchmarkMark>();
        #endregion
        
        #region C..tor
        public CodeBenchmarkManager()
        {
            InitializeGuid();
            _lstMarkes = new List<CodeBenchmarkMark>();
        }

        public CodeBenchmarkManager(CodeBenchmarkConfig configureInfo)
        {
            Config(configureInfo);
        }
        #endregion

        #region Private Methods
        private void InitializeGuid()
        {
            _benchMarkSession = Guid.Empty;
            
        }
        private void InitilizeMarks()
        {
            _lstMarkes.Clear();
        }
        static List<CodeBenchmarkReportInfo> HandleResult(IList<CodeBenchmarkMark> markList)
        {
            const string dateFormat = "yyyy.hh.MM hh.mm.ss.ffff";

            var lstInfo = (from x in markList
                           select new CodeBenchmarkReportInfo
                           {
                               Step = markList.IndexOf(x) + 1,
                               Description = x.Description,
                               Comments = x.Comments,
                               Start = x.DateMark.ToString(dateFormat),
                               SubTotal = x.DateMark.Subtract(markList[0].DateMark).TotalSeconds,
                               Partial = markList.GetPrevious(x) != null ? x.DateMark.Subtract(markList.GetPrevious(x).DateMark).TotalSeconds : 0,
                               Finish = markList.GetNext(x) != null ? markList.GetNext(x).DateMark.ToString(dateFormat) : String.Empty,
                           }).ToList();
            return lstInfo;
        }
        #endregion
        
        #region Public Methods
        public void Config(CodeBenchmarkConfig configureInfo)
        {
            if (configureInfo != null)
            {
                var cfgCtx = new ConfiguratorContext(CodeBenchmarkConfSource.Memory);
                _config = cfgCtx.Configure(configureInfo);
            }
        }

        public void ConfigXML(string fileName)
        {
            if (fileName != null)
            {
                var cfgCtx = new ConfiguratorContext(CodeBenchmarkConfSource.XML);
                _config = cfgCtx.Configure(fileName);
            }
        }
        
        public void SaveConfig(string fileName)
        {
            if (_config != null)
            {
                SerializationHelper.SerializeToFile(_config,fileName);
            }
        }

        public void StartBenchMarck()
        {
            if (_benchMarkSession == Guid.Empty)
            {
                InitializeGuid();
            }
            InitilizeMarks();
        }

        public void EndBenchMarck()
        {
            InitializeGuid();
            //InitilizeMarks();
        }
        
        public void AddMark()
        {
            AddMark(String.Empty);
        }

        public void AddMark(string description)
        {
            AddMark(description, String.Empty);
        }

        public void AddMark(string description, string comments)
        {
            var markTime = DateTime.Now;
            var cbMark = new CodeBenchmarkMark
            {
                DateMark = markTime,
                Description = description,
                Comments = comments,
                Session = _benchMarkSession
            };
            _lstMarkes.Add(cbMark);
        }
        public void GenerateReport()
        {
            if (_config != null && _config.ReportConfigs.Count > 0)
            {
                foreach (var cfgRpt in _config.ReportConfigs)
                {
                    var reportCtx = new ReportGenerationContext(cfgRpt.Format);
                    var lstInfo = HandleResult(_lstMarkes);
                    reportCtx.GenerateReport(cfgRpt, lstInfo);    
                }
                
            }
        }
        #endregion

    }
}
