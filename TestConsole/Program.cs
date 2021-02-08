using DataStructure.DoubleLinkedLists;
using System;
using System.IO;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            var list = new ListRandom();
            for(int i = 0; i < 20; i++)
            {
                list.Add(random.Next(0,100));
            }
            Console.WriteLine(list.ToJSON());
            using (FileStream fs = File.Open("list.txt", FileMode.OpenOrCreate))
            {
                list.Serialize(fs);
            }
            using (FileStream fs = File.Open("list.txt", FileMode.OpenOrCreate))
            {
                list.Deserialize(fs);
            }

            Console.WriteLine(list.ToJSON());
        }
    }
}
