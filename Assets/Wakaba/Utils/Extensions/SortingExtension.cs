using System;
using System.Collections.Generic;
namespace Wakaba.Utils.Extensions
{
    public static class SortingExtension
    {
        /// <summary></summary>
        /// <typeparam name="T">The type needs to have a comparator.</typeparam>
        /// <param name="_list"></param>
        public static void BubbleSort<T>(this List<T> _list) where T : IComparable
        {
            T temp;

            for (int j = 0; j <= _list.Count - 1; j++)
            {
                for (int i = 0; i <= _list.Count - 2; i++)
                {
                    IComparable first = _list[i];
                    IComparable second = _list[i + 1];

                    int comparison = first.CompareTo(second);
                    // First is after second.
                    if (comparison > 0)
                    {
                        temp = _list[i + 1];
                        _list[i + 1] = _list[i];
                        _list[i] = temp;
                    }
                }
            }
        }

        /// <summary></summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_list"></param>
        public static void InsertionSort<T>(this List<T> _list) where T : IComparable
        {
            for (int i = 1; i < _list.Count; i++)
            {
                T temp = _list[i];
                int h = i - 1;
                bool done = false;
                do
                {
                    if (_list[h].CompareTo(temp) > 0)
                    {
                        _list[h + 1] = _list[h];
                        h--;
                        if (h < 0) done = true;
                    }
                    else done = true;
                } while (!done);
                _list[h + 1] = temp;
            }
        }

        /// <summary></summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_list"></param>
        public static void SelectionSort<T>(this List<T> _list) where T : IComparable
        {
            int minIndex;
            for (int i = 0; i < _list.Count; i++)
            {
                minIndex = i;
                for (int j = i + 1; j < _list.Count; j++)
                {
                    IComparable currentItem = _list[j];
                    IComparable minItem = _list[minIndex];
                    // Check if the current item should be to the left of the minItem
                    if (currentItem.CompareTo(minItem) < 0) minIndex = j;
                }
                // Store the current item
                T temp = _list[i];
                // Swap the minIndex item and the current item
                _list[i] = _list[minIndex];
                _list[minIndex] = temp;
            }
        }
    }
}