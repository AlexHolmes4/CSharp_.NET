using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
   
    public class CircularBuffer<T> : Buffer<T>
    {
        int _capacity;
        public CircularBuffer(int capacity = 10)
        {
            _capacity = capacity;
        }

        public event EventHandler<ItemDiscardedEventArgs<T>> ItemDiscardedEventHandler;

        public override void Write(T value)
        {
            base.Write(value);
            if(_queue.Count > _capacity)
            {
                var discard = _queue.Dequeue();
                OnItemDiscarded(discard, value);
            }
        }
        public void OnItemDiscarded(T discard, T value)
        {
            if (ItemDiscardedEventHandler != null)
            {
                var args = new ItemDiscardedEventArgs<T>(discard, value);
                ItemDiscardedEventHandler(this, args);
            }
        }

        public bool IsFull { get { return _queue.Count == _capacity; } }
    }
}
