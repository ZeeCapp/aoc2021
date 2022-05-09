using System;
using System.IO;
using System.Threading.Tasks;

namespace _1_1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            int[] input;
            int lastvalue, count = 0;

            //read input
            input = Array.ConvertAll(await File.ReadAllLinesAsync("./input.txt"), int.Parse);

            lastvalue = input[0];
            foreach(int value in input){
                if(value > lastvalue){
                    count++;
                }
                lastvalue = value;
            }

            Console.WriteLine(count);
        }
    }
}
