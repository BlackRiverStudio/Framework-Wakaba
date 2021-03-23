using System.Collections.Generic;
namespace Wakaba.Utils.Extensions
{
    public static class SearchingExtention
    {
        /// <summary></summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_list"></param>
        /// <param name="_value"></param>
        /// <param name="_comparer"></param>
        /// <returns></returns>
        public static int SearchBinary<T>(this List<T> _list, T _value, IComparer<T> _comparer)
        {
            int index = -1;

            int min = 0;
            int max = _list.Count;

            for (int i = 0; i < _list.Count; i++)
            {
                int mean = (min + max) / 2;
                
                int compared = _comparer.Compare(_list[mean], _value);

                if (compared > 0) { min = mean; continue; }
                if (compared < 0) { max = mean; continue; }
                if (compared == 0) { index = mean; break; }
            }

            return index;
        }
    }
}