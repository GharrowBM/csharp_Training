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
        public event Action Event;

        public Stock(int size)
        {
            table = new T[size];
        }

        public void Add(T element)
        {
            for (int i = 0; i < table.Length; i++)
            {
                if (table[i].Equals(default(T)))
                {
                    table[i] = element;
                    break;
                }
            }
        }

        public T this[int index] { get { return table[index]; } }


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
            if (table[index] != null) return table[index];

            return default(T);
        }

        public void FullStockEvent()
        {
            if (Event != null)
            {
                Event();
            }
        }
    }
}
