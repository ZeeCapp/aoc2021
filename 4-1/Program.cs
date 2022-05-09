using System;
using System.IO;

namespace _4_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Bingo bingo = new Bingo();
            bingo.InitiateBingo(@"input.txt");

            Console.ReadKey();
        }
    }
}
