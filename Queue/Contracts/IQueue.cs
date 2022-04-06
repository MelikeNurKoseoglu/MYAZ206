using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Contracts
{
    public interface IQueue<T>:IEnumerable<T>
    {
        int Count { get; }
        void Enqueue(T value);
        T Dequeue();
        T Peek();
    }
}
