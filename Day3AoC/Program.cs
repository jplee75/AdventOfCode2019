using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day3AoC
{
    class Program
    {
        public struct WireTrace
        {
            public int wireNumber;
            public char direction;
            public int distance;

            public WireTrace(string instruction, int wire)
            {
                direction = instruction[0];
                distance = Convert.ToInt32(instruction.Substring(1));
                wireNumber= wire;
            }

            
        }
        static void Main(string[] args)
        {
            var wireTraces = GetInput();
            Console.WriteLine(wireTraces.Count);

        }

        static List<WireTrace> GetInput()
        {
            List<WireTrace> returnMe = new List<WireTrace>();
            var lines =  File.ReadLines("C:/Code/AdventOfCode2019/Day3AoC/input.txt").ToList();
            int i = 1;
            foreach(string line in lines)
            {
                foreach(string cmd in line.Split(","))
                {
                    returnMe.Add(new WireTrace(cmd,i));
                }

                ++i;

            }

            return returnMe;
        }
    }
}
