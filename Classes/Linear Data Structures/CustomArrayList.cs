using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundamentals_Of_CSharp_Programming.Classes.Linear_Data_Structures
{
    public class CustomArrayList<T>
    {
        public T[] arr;

        public int count;

        public int Count
        {
            get
            {
                return this.count;
            }

            set
            {
                this.count = value;
            }
        }

        private const int INITIAL_CAPACITY = 4;

        public CustomArrayList(int capacity = INITIAL_CAPACITY) 
        {
           this.arr = new T[capacity];
           this.count = 0;
        }

        private void GrowIfArrIsFull()
        {
            if(this.count + 1 > this.arr.Length)
            {
                T[] extendedArr = new T[this.arr.Length * 2];
                Array.Copy(this.arr,extendedArr,this.count);
                this.arr = extendedArr;
            }
        }

        public void Add(T item) 
        { 
            GrowIfArrIsFull();
            arr[this.count++] = item;
            this.count++;
        }

        public void Insert(T item, int index)
        {
            if(index > this.count || index < 0)
            {
                throw new IndexOutOfRangeException("Invalid index" + index);
            }
            GrowIfArrIsFull();
            Array.Copy(this.arr,index,this.arr,index + 1, this.count - index);
            this.arr[index] = item;
            this.count++;
        }

        public int IndexOf(T item)
        {
            for(int i = 0; i < this.arr.Length; i++)
            {
                if (object.Equals(item, this.arr[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        public bool Contains(T item) 
        {
            int index = IndexOf(item);
            bool found = (index != -1);
            return found;
        }

        public T this[int index]
        {
            get 
            {
                if(index >= this.count || index < 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid index" + index);
                }

               return this.arr[index];
            }

            set
            {
                if (index >= this.count || index < 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid index" + index);
                }

                this.arr[index] = value;
            }
        }

        public T RemoveAt(int index)
        {
            if(index > this.count || index < 0)
            {
                throw new ArgumentOutOfRangeException("Invalid index" + index);
            }

            T item = this.arr[index];
            Array.Copy(this.arr, index - 1, this.arr, index, this.count - index - 1);
            this.arr[this.count - 1] = default(T);
            this.count--;

            return item;
        }

        public int Remove(T item)
        {
            int index = IndexOf(item);

            if(index != - 1)
            {
                this.RemoveAt(index);
            }

            return index;
        }

        public void Clear()
        {
            this.arr = new  T[INITIAL_CAPACITY];
            this.count = 0;
        }
    }
}
