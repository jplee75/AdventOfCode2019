using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Part1
{
    class Program
    {
        public struct ModuleLaunch
        {
            public int weight;
            public int cost;

            public ModuleLaunch(int Weight,int Cost)
            {
                weight=Weight;
                cost=Cost;
            }
        }
        static void Main(string[] args)
        {
            var modules = GetInput();
            int totalFule = modules.Sum(i=>i.cost);
            Console.WriteLine(totalFule);
        }
        static int FuelCalculation(int mass)
        {
            int fuel = 0;
            if(mass/3 > 2)
            {
                fuel = (mass/3-2)+FuelCalculation(mass/3-2);
            }
            
            return fuel;
        }
        static List<ModuleLaunch> GetInput()
        {
            List<ModuleLaunch> returnMe = new List<ModuleLaunch>();
            var lines =  File.ReadLines("input.txt").ToList();
            foreach(string line in lines)
            {
                int moduleWeight = Convert.ToInt32(line);
                returnMe.Add(new ModuleLaunch(moduleWeight,FuelCalculation(moduleWeight)));
            }

            return returnMe;
        }
    }

    


}
