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

        public T[] Table { get { return table; } }

        public Stock(int size)
        {
            table = new T[size];
        }

        public void Add(T element)
        {
            for (int i=0; i<table.Length; i++)
            {
                if (table[i].Equals(default(T)))
                {
                    table[i] = element;
                    break;
                }
            }
        }

        public void Remove(T element)
        {
            for (int i = table.Length - 1; i >= 0; i--)
            {
                if (table[i].Equals(element))
                {
                    table[i] = default(T);
                    break;
                }
            }
        }

        public T Find(int index)
        {
            if (table[index] != null ) return table[index];

            return default(T);
        }
    }
}
