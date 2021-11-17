using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heritage03.Models
{
    internal class Stock<T>
    {
        private T[] table;

        public Stock(int size)
        {
            table = new T[size];
        }

        public void Add(T element)
        {
            table[Array.FindIndex(table, x => x == null)] = element;
        }

        public void Remove(T element)
        {
            table[Array.FindIndex(table, x => x.Equals(element))] = default(T);
        }

        public T Find(int index)
        {
            if (table[index] != null ) return table[index];

            return default(T);
        }
    }
}
