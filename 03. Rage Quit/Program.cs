using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _03.Rage_Quit
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string pattern = @"(\D+)(\d+)";
            Regex regex = new Regex(pattern);

            var input = Console.ReadLine().ToUpper();

            MatchCollection matches = regex.Matches(input);

            

            StringBuilder result = new StringBuilder();

            foreach (Match match in matches)
            {
                string message = match.Groups[1].Value;
                int repeat = int.Parse(match.Groups[2].Value);

                    for (int i = 0; i < repeat; i++)
                    {
                        result.Append(message);

                    }
                }

                Console.WriteLine("Unique symbols used: {0}", result.ToString().Distinct().Count());
                Console.WriteLine(result);
            }
        }
    }
