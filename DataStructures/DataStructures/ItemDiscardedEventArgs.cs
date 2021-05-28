using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class ItemDiscardedEventArgs<T> : EventArgs
    {
        public T ItemDiscarded { get; set; }
        public T NewItem { get; set; }

        public ItemDiscardedEventArgs(T discard, T newitem)
        {
            ItemDiscarded = discard;
            NewItem = newitem;
        }
    }
}
