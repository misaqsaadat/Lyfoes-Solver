using System;

namespace LyfoesSolver
{
    /// <summary>
    /// a custom sorted list. add and remove and equals method implemented. faster than using list or sroted list or ...
    /// </summary>
    public class CustomSortedList
    {
        int[] values = new int[30];
        int count = 0;
        public void Add(int value)
        {
            var index = FindIndex(value);
            Array.Copy(values, index, values, index + 1, count - index);
            values[index] = value;
            count++;
        }

        public void Remove(int value)
        {
            var index = FindIndex(value);
            Array.Copy(values, index + 1, values, index, count - index);
             count--;
        }

        public int Count => count;

        public int FindIndex(int value)
        {
            var pos = 0;
            var last = count;
            while (last - pos > 1)
            {
                var mid = (last + pos) / 2;
                var currentVal = values[mid];
                if (value < currentVal)
                    last = mid;
                else
                    pos = mid;
            }
            if (value > values[pos])
                pos = last;
            return pos;
        }

        public override string ToString()
        {
            return string.Join("-", values);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is CustomSortedList sortedList))
                return false;
            for (int i = 0; i < count; i++)
                if (values[i] != sortedList.values[i])
                    return false;
            return true;
        }

        internal CustomSortedList Clone()
        {
            var lst = new CustomSortedList();
            lst.count = count;
            for (int i = 0; i < count; i++)
                lst.values[i] = values[i];
            return lst;
        }
    }
}
