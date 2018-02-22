using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingCSharp.DataStructuresAlgorithms
{
    public class CollectionMy<T> : Collection<T>
    {
        public new void Add(T item)
        {
            Items.Add(item);
        }
        public new void Remove(T item)
        {
            Items.Remove(item);
        }
        public new void Clear()
        {
            Items.Clear();
        }
        public new int Count()
        {
            return Items.Count;
        }
    }
}
