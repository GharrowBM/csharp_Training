using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test01.Classes
{
    internal static class Extensions
    {
        public static List<T> ReduceList<T>(this List<T> source, Func<T, bool> predicate)
        {
            List<T> result = new List<T>();

            foreach (var item in source)
            {
                if (predicate(item))
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public static T GetFirst<T>(List<T> source)
        {
            return source[0];
        }
    }
}
