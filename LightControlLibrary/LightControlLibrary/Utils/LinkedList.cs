
using LightControlLibrary.Scheduler;

namespace LightControlLibrary.Utils
{
    internal class LinkedList<T> where T : notnull
    {
        protected class Node(T value)
        {
            public readonly T Value = value;
            public Node? Next;
        }

        private Node? _head = null;

        public void Add(T item)
        {
            _head!.Next = new(item)
            {
                Next = _head
            };
        }

        public void Remove(T item)
        {
            if (_head!.Value.Equals(item))
            {
                _head = _head.Next;
            }

            ref var origin = ref _head;
            var cursor = _head;

            while ((cursor != null)
                   && cursor.Next != null)
            {
                if (!cursor.Value.Equals(item))
                {
                    origin = cursor.Next;
                    break;
                }
                cursor = cursor.Next;
            }
        }

        public T? Get(Func<T, bool> filter)
        {
            if (_head == null) return default;

            var cursor = _head;

            while (cursor != null)
            {
                if (filter(cursor.Value))
                {
                    break;
                }
                cursor = cursor.Next;
            }

            return (cursor != null) ? cursor.Value : default;
        }
    }
}
