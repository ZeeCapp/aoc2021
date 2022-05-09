using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace _2_2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string[] input;
            List<(string, int)> submarineCommands = new List<(string, int)>();
            int posX = 0, depth = 0, aim = 0;

            //read input
            input = (await File.ReadAllLinesAsync("./input.txt"));

            foreach(string command in input){
                string[] splitCommand = command.Split(' ');
                submarineCommands.Add(new (splitCommand[0], int.Parse(splitCommand[1])));               
            }

            foreach((string, int) command in submarineCommands){
                switch(command.Item1){
                    case "forward":
                        posX += command.Item2;
                        depth += command.Item2 * aim;
                    break;

                    case "down":
                        aim += command.Item2;
                    break;

                    case "up":
                        aim -= command.Item2;
                    break;
                }
            }


            Console.WriteLine($"Depth: {depth}   Position X: {posX}");
            Console.WriteLine($"Result: {depth * posX}");
        }
    }
}
