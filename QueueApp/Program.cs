using Queue;
using System;

namespace QueueApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var _queue = new Queue<ToDo>(QueueType.ArrayQueue);

            _queue.Enqueue(new ToDo()
            {
                Time = 2,
                Describe = "Okula gidilecek."
            });
            _queue.Enqueue(new ToDo()
            {
                Time = 1,
                Describe = "Yemek yenilecek."
            });
            _queue.Enqueue(new ToDo
            {
                Time = 3,
                Describe = "Sınava girilecek."
            });

            var result = _queue.Dequeue();

            Console.WriteLine(result + " yapıldı.");

            Console.WriteLine(_queue.Count);
            foreach (var item in _queue)
            {
                Console.WriteLine(item);
            }


            Console.ReadKey();
        }
    }
}
