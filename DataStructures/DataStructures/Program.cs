using System;

namespace DataStructures
{
    class Program
    {


        static void Main(string[] args)
        {
            var buffer = new CircularBuffer<double>(capacity:3);
            buffer.ItemDiscardedEventHandler += ItemDiscarded;

            ProcessInput(buffer);

           // Converter<double, DateTime> converter = d => new DateTime(2010, 1, 1).AddDays(d);
            var asDates = buffer.Map(d => new DateTime(2010, 1, 1).AddDays(d));
            foreach (var date in asDates)
            {
                Console.WriteLine(date);
            }

            buffer.Dump(d => Console.WriteLine(d));

            ProcessBuffer(buffer);
        }

        private static void ItemDiscarded(object sender, ItemDiscardedEventArgs<double> e)
        {
            Console.WriteLine();
        }

        private static void ProcessInput(IBuffer<double> buffer)
        {
            while (true)
            {
                var value = 0.0;
                var input = Console.ReadLine();

                if (double.TryParse(input, out value))
                {
                    buffer.Write(value);
                    continue;
                }
                break;
            }
        }

        private static void ProcessBuffer(IBuffer<double> buffer)
        {
            var sum = 0.0;

            Console.WriteLine("Buffer: ");
            while (!buffer.IsEmpty)
            {
                sum += buffer.Read();
            }
            Console.WriteLine(sum);
        }
    }
}
