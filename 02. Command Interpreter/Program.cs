using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Command_Interpreter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var array = Console.ReadLine().Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            var commands = Console.ReadLine().Split().ToList();

            while (commands[0] != "end")
            {
                var command = commands[0];

                switch (command)
                {
                    case "reverse":
                        var RevIndex = int.Parse(commands[2]);
                        var RevCount = int.Parse(commands[4]);
                        if (IsValid(array, RevIndex, RevCount))
                        {
                            array.Reverse(RevIndex, RevCount);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input parameters.");
                        }
                        break;

                    case "sort":
                        var SortIndex = int.Parse(commands[2]);
                        var SortCount = int.Parse(commands[4]);
                        if (IsValid(array, SortIndex, SortCount))
                        {
                            array.Sort(SortIndex, SortCount, StringComparer.InvariantCulture);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input parameters.");
                        }
                        break;

                    case "rollLeft":

                        var rollLeftCount = int.Parse(commands[1]);
                        if (rollLeftCount >= 0)
                        {
                            RollLeft(array, rollLeftCount);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input parameters.");
                        }

                        break;

                    case "rollRight":
                        var rollRightCount = int.Parse(commands[1]);
                        if (rollRightCount >= 0)
                        {
                            RollRight(array, rollRightCount);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input parameters.");
                        }

                        break;

                }
                commands = Console.ReadLine().Split().ToList();
            }
            Console.WriteLine("[{0}]", string.Join(", ", array));
        }

        private static void RollRight(List<string> array, int rollRightCount)
        {
            rollRightCount = rollRightCount % array.Count;
            for (int i = 0; i < rollRightCount; i++)
            {
                array.Reverse();
                array.Add(array[0]);
                array.RemoveAt(0);
                array.Reverse();
            }
        }

        private static void RollLeft(List<string> array, int rollLeftCount)
        {
            rollLeftCount = rollLeftCount % array.Count;
            for (int i = 0; i < rollLeftCount; i++)
            {
                array.Add(array[0]);
                array.RemoveAt(0);

            }
        }

        private static bool IsValid(List<string> array, int revIndex, int revCount)
        {
            if (revIndex >= 0 && revIndex < array.Count && revCount >= 0 && (revIndex + revCount) <= array.Count)
            {
                return true;
            }
            return false;
        }
    }
}