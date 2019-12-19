using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day2AoC
{
    class Program
    {
        static void Main(string[] args)
        {
            var ogInput = GetInput();
            //input[1] = 12;
            //input[2] = 2;
            Boolean stop = false;
            var input = new List<int>(ogInput);

            for (int noun = 0; noun<=99;noun++)
            //for (int noun = 12; noun < 13;noun++)
            {
                for (int verb = 0; verb<=99;verb++)
                //for (int verb = 2; verb<=2;verb++)
                {
                    input = new List<int>(ogInput);
                    
                    input[1] = noun;
                    input[2] = verb;

                    Console.WriteLine ("Noun: " + noun + " Verb: " + verb);


                    for (int i=0; i< input.Count; i+=4)
                    {
                        int addressP1 = input[i+1];
                        int addressP2 = input[i+2];
                        int addressP3 = input[i+3];
                        if(addressP1 < input.Count && addressP2 < input.Count && addressP3 < input.Count)
                        {
                            stop = false;
                            int computevalue = 0;
                            switch(input[i])
                            {
                                // 1 is add
                                case 1:
                                    computevalue = input[addressP1] + input[addressP2];
                                    break;
                                // 2 is multiply
                                case 2:
                                    computevalue = input[addressP1] * input[addressP2];
                                    break;
                                //99 is halt
                                case 99:
                                    Console.WriteLine("Opcode 99 Halting");
                                    stop = true;
                                    break;
                                //everything else is junk
                                default:
                                    Console.WriteLine("Unknown Opcode Halting");
                                    stop = true;
                                    break;
                            }

                            if (input[0] == 19690720)
                            {
                                Console.WriteLine("Found Verb Noun Pair");
                                Console.WriteLine(noun);
                                Console.WriteLine(verb);
                                Console.WriteLine(100*noun+verb);
                                var blah = Console.Read();

                                stop=true;
                            }else
                            {
                                input[addressP3] = computevalue;
                            }

                            if(stop)
                            {
                                Console.WriteLine(input[0]);
                                break;
                            }

                        }else
                        {
                            Console.WriteLine("Address Out of Range");
                            break;
                        }
                    }

                }
            }
        }


        static List<int> GetInput()
        {
            List<int> returnMe = new List<int>();
            var lines =  File.ReadLines("C:/Code/AdventOfCode2019/Day2/Day2AoC/input.txt").ToList();
            foreach(string line in lines)
            {
                returnMe = line.Split(',').Select(Int32.Parse).ToList();
            }

            return returnMe;
        }
    }
}

