using System;
using System.Collections.Generic;
using System.Text;

namespace Dna
{
    public static class ArrayExtensions
    {
        /// <summary>
        /// Append to given objects to the original source array
        /// </summary>
        /// <typeparam name="T">The Type of array</typeparam>
        /// <param name="source">The Original array of values</param>
        /// <param name="toAdd">The values to append to the source</param>
        /// <returns></returns>
        public static T[] Append<T>(this T[] source, params T[] toAdd)
        {
            var list = new List<T>(source);
            list.AddRange(toAdd);
            return list.ToArray();
        }

        /// <summary>
        /// Prepend to given objects to the original source array
        /// </summary>
        /// <typeparam name="T">The Type of array</typeparam>
        /// <param name="source">The Original array of values</param>
        /// <param name="toAdd">The values to prepend to the source</param>
        /// <returns></returns>
        public static T[] Prepend<T>(this T[] source, params T[] toAdd)
        {
            var list = new List<T>(toAdd);
            list.AddRange(source);
            return list.ToArray();
        }

    }
}
