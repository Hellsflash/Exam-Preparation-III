using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Files
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var filesByRoot = new Dictionary<string, Dictionary<string, long>>();
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var rootParams = Console.ReadLine().Split('\\');
                var root = rootParams[0];
                var fileWhitSize = rootParams[rootParams.Length - 1].Split(';');

                var fileNameWhitExt = fileWhitSize[0];
                var fileSize = long.Parse(fileWhitSize[1]);

                if (!filesByRoot.ContainsKey(root))
                {
                    filesByRoot.Add(root, new Dictionary<string, long>());
                }

                if (!filesByRoot[root].ContainsKey(fileNameWhitExt))
                {
                    filesByRoot[root].Add(fileNameWhitExt, fileSize);
                }
                else
                {
                    filesByRoot[root][fileNameWhitExt] = fileSize;
                }

            }
            var queryParams = Console.ReadLine().Split();

            var queryExt = queryParams[0];
            var queryRoot = queryParams[2];

            if (filesByRoot.ContainsKey(queryRoot))
            {

                Dictionary<string, long> foundFiles = filesByRoot[queryRoot];

                foreach (var file in foundFiles.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    if (file.Key.EndsWith(queryExt))
                    {
                        Console.WriteLine("{0} - {1} KB", file.Key, file.Value);
                    }
                  
                }
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
