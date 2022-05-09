using System;
using System.IO;
using System.Threading.Tasks;

namespace _1_2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            int[] input;
            int lastAvg, currentAvg, count = 0;

            //read input
            input = Array.ConvertAll(await File.ReadAllLinesAsync("./input.txt"), int.Parse);


            for(int index = 0; index < input.Length - 3; index++){
                lastAvg = input[index] + input[index+1] + input[index+2];
                currentAvg = input[index+1] + input[index+2] + input[index+3];

                if(lastAvg < currentAvg){
                    count++;
                }
            }

            Console.WriteLine(count);
        }
    }
}
