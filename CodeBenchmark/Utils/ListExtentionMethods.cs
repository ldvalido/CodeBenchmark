using System.Collections.Generic;

namespace CodeBenchmark.Utils
{
    internal static class ListExtentionMethods
    {
        internal static T GetNext<T>(this IList<T> list, T element)
        {
            T returnValue = default(T);
            var index = list.IndexOf(element);
            if (index >= 0 && index < list.Count - 1)
            {
                returnValue = list[index+1];
            }
            return returnValue;
        }

        internal static T GetPrevious<T>(this IList<T> list, T element)
        {
            var returnValue = default(T);
            var index = list.IndexOf(element);
            if (index >= 1)
            {
                returnValue = list[index -1];
            }
            return returnValue;
        }
    }
}
