using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using CodeBenchmark.Model;
using NUnit.Framework;

namespace CodeBenchmark.Testing
{
    [TestFixture]
    public class CodeBenchmarkingTest
    {
        #region Properties
        private CodeBenchmarkManager _cbManager;
        #endregion

        #region Setup
        [SetUp]
        public void SetUp()
        {
            _cbManager = new CodeBenchmarkManager();
        }
        #endregion

        #region Test Methods
        [Test]
        public void TestCreation()
        {
            Assert.IsNotNull(_cbManager);
        }

        [Test]
        public void TestConfigureCreation()
        {
            var cbConfInfo = new CodeBenchmarkConfig();
            _cbManager.Config(cbConfInfo);
        }

        [Test]
        public void TestConfigureCreationCtor()
        {
            var cbConfInfo = new CodeBenchmarkConfig();
            var cbManager = new CodeBenchmarkManager(cbConfInfo);
            Assert.IsNotNull(cbManager);
        }

        [Test]
        public void TestSessionLifeCycle()
        {
            _cbManager.StartBenchMarck();
            _cbManager.EndBenchMarck();
        }

        [Test]
        public void TestMarkingBenchmark()
        {
            _cbManager.StartBenchMarck();
            _cbManager.AddMark();
            _cbManager.EndBenchMarck();
        }

        [Test]
        public void TestMarkingBenchmarkDescription()
        {
            _cbManager.StartBenchMarck();
            _cbManager.AddMark("Testing Proyect");
            _cbManager.EndBenchMarck();
        }

        [Test]
        public void TestMarkingTestSave()
        {
            _cbManager.Config(new CodeBenchmarkConfig
                                     {
                                         ReportConfigs = new List<CodeBenchmarkReportConfig>
                                         {
                                             new CodeBenchmarkReportConfig
                                             {
                                                 Format = CodeBenchmarkReportFormat.CSV,
                                                 FileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Reports\TestReport.csv"),
                                                 IncludeHeaders = true
                                             }
                                         }
                                     }
                                     );
            _cbManager.StartBenchMarck();
            _cbManager.AddMark("Testing Proyect");
            _cbManager.EndBenchMarck();
            _cbManager.GenerateReport();
        }

        [Test]
        public void TestMarkingTestSaveVariousSteps()
        {
            _cbManager.Config(
                new CodeBenchmarkConfig
                    {
                        ReportConfigs = new List<CodeBenchmarkReportConfig>
                                            {
                                                new CodeBenchmarkReportConfig
                                                    {
                                                        Format = CodeBenchmarkReportFormat.CSV,
                                                        FileName =
                                                            Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                                                                         @"Reports\TestReportMultipleSteps.csv"),
                                                        IncludeHeaders = true
                                                    }
                                            }
                    }
                    );
            _cbManager.StartBenchMarck();
            _cbManager.AddMark("Testing Proyect");
            _cbManager.AddMark("Testing Proyect2");
            _cbManager.AddMark("Testing Proyect3");
            Thread.Sleep(150);
            _cbManager.AddMark("Testing Proyect4");
            _cbManager.EndBenchMarck();
            _cbManager.GenerateReport();
        }

        [Test]
        public void TestGenerateXML()
        {
            _cbManager.Config(
                new CodeBenchmarkConfig
                    {
                        ReportConfigs = new List<CodeBenchmarkReportConfig>
                                            {
                                                new CodeBenchmarkReportConfig
                                                    {
                                                            Format = CodeBenchmarkReportFormat.XML,
                FileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Reports\TestReportMultipleSteps.xml"),
                IncludeHeaders = true
                                                    }
                                            }
                    }
                );
            _cbManager.StartBenchMarck();
            _cbManager.AddMark("Testing Proyect");
            _cbManager.AddMark("Testing Proyect2");
            _cbManager.AddMark("Testing Proyect3");
            _cbManager.EndBenchMarck();
            _cbManager.GenerateReport();
        }

        [Test]
        public void TestGenerateXMLandCSV()
        {


            var rpts = new List<CodeBenchmarkReportConfig>
                           {
                               new CodeBenchmarkReportConfig
                                   {
                                       Format = CodeBenchmarkReportFormat.XML,
                                       FileName =
                                           Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                                                        @"Reports\TestReportMultipleStepsMix.xml"),
                                       IncludeHeaders = true
                                   },
                               new CodeBenchmarkReportConfig
                                   {
                                       Format = CodeBenchmarkReportFormat.CSV,
                                       FileName =
                                           Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                                                        @"Reports\TestReportMultipleStepsMix.csv"),
                                       IncludeHeaders = true
                                   }
                           };

            _cbManager.Config(
                new CodeBenchmarkConfig
                {
                    ReportConfigs = rpts
                }
                );
            _cbManager.StartBenchMarck();
            _cbManager.AddMark("Testing Proyect");
            _cbManager.AddMark("Testing Proyect2");
            _cbManager.AddMark("Testing Proyect3","Associated Data");
            _cbManager.EndBenchMarck();
            _cbManager.GenerateReport();
        }

        [Test]
        public void TestSaveConfig()
        {


            var rpts = new List<CodeBenchmarkReportConfig>
                           {
                               new CodeBenchmarkReportConfig
                                   {
                                       Format = CodeBenchmarkReportFormat.XML,
                                       FileName =
                                           Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                                                        @"Reports\TestReportMultipleStepsMix.xml"),
                                       IncludeHeaders = true
                                   },
                               new CodeBenchmarkReportConfig
                                   {
                                       Format = CodeBenchmarkReportFormat.CSV,
                                       FileName =
                                           Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                                                        @"Reports\TestReportMultipleStepsMix.csv"),
                                       IncludeHeaders = true
                                   }
                           };

            _cbManager.Config(
                new CodeBenchmarkConfig
                {
                    ReportConfigs = rpts
                }
                );
            _cbManager.StartBenchMarck();
            _cbManager.AddMark("Testing Proyect");
            _cbManager.AddMark("Testing Proyect2");
            _cbManager.AddMark("Testing Proyect3");
            _cbManager.EndBenchMarck();
            _cbManager.SaveConfig(
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@"Config.xml"));

        }
        
        [Test]
        public void TestConfigXML()
        {
            var fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"ExampleConfig\Config.xml");
            _cbManager.ConfigXML(fileName);
        }
        #endregion
    }
}
