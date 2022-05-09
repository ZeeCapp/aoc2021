using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace _3_1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string gammaString = string.Empty, epsilonString = string.Empty;
            int bitAverage = 0, result = 0;
            string[] inputBits;

            inputBits = (await File.ReadAllLinesAsync("./input.txt"));

            for(int x = 0; x < inputBits[0].Length; x++){
                //find most often bit
                for(int y = 0; y < inputBits.Length; y++){
                    if((inputBits[y])[x] == '0'){
                        bitAverage--;
                    }
                    else{
                        bitAverage++;
                    }
                }

                //if 1 is more often
                if(bitAverage > 0){
                    gammaString += "1";
                    epsilonString += "0";
                }
                //if 0 is more often
                else{
                    gammaString += "0";
                    epsilonString += "1";
                }
                bitAverage = 0;
            }
            result = Convert.ToInt32(gammaString, 2) * Convert.ToInt32(epsilonString, 2);
            Console.WriteLine($"Submarine power consumption: {result}");
        }
    }
}
