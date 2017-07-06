using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using CodeBenchmark.Utils;

namespace CodeBenchmark.ReportGeneration
{
    internal class CSVRenderFile<T>
    {
        #region Properties
        internal bool IncludeHeaders { private get; set; }
        internal string Delimiter { private get; set; }
        #endregion

        #region C...tor
        internal CSVRenderFile()
        {
            IncludeHeaders = true;
        }
        #endregion

        #region Public Methods
        internal void Render(string fileName, IEnumerable<T> elements)
        {
            var fileContent = String.Empty;
            FileSystemHelper.SafePath(fileName);

            if (IncludeHeaders)
            {
                fileContent = String.Concat(fileContent, RenderHeaders(Delimiter));
            }
            
            fileContent = String.Concat(fileContent, RenderBody(elements, Delimiter));

            File.WriteAllText(fileName,fileContent,Encoding.Unicode);

        }
        #endregion

        #region Auxiliar Methods
        static string RenderHeaders(string delimiter)
        {
            var type = typeof(T);
            var members = type.GetMembers().Where(m => m.MemberType == MemberTypes.Property);
            var returnValue = String.Join(delimiter, (from x in members select x.Name).ToArray());
            returnValue = String.Concat(returnValue, Environment.NewLine);
            return returnValue;
        }

        static string RenderBody(IEnumerable<T> elements, string delimiter)
        {
            var returnValue = String.Empty;
            var type = typeof(T);
            var members = type.GetMembers().Where(m => m.MemberType == MemberTypes.Property).ToArray();
            foreach (var el in elements)
            {
                var recordValue = new List<object>(members.Count());
                recordValue.AddRange(members.Select(m => type.GetProperty(m.Name).GetValue(el, new object[] { })));
                recordValue.Add(Environment.NewLine);
                returnValue = String.Concat(
                    returnValue,
                    String.Join(delimiter, recordValue)
                    );
            }
            return returnValue;
        }

        #endregion

    }
}
