using MapGeneration.Logic;
using System;

namespace MapGeneration
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Map generator");

            IMapGenerator generator = new MapGenerator();
            var length = 40;
            var width = 40;

            var map = generator.Create(length, width);

            for (int i = 0; i < map.Length; i++)
            {
                for (int j = 0; j < map[i].Length; j++)
                {
                    Console.Write((char)map[i][j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
