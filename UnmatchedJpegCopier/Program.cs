using System;
using System.IO;

namespace UnmatchedJpegCopier
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourceDir = Directory.GetCurrentDirectory();
            if(args.Length == 1)
            {
                sourceDir = args[0];
            }
            Console.WriteLine("Finding jpegs without RAWs in {0}", sourceDir);

            string targetDirectory = Path.Combine(sourceDir, "lr-export");

            if(!Directory.Exists(targetDirectory))
            {
                Console.WriteLine("Target directory does not exist");
                return;
            }

            var sourceDirectory = new DirectoryInfo(sourceDir);
            foreach (var file in sourceDirectory.EnumerateFiles("*.jpg", new EnumerationOptions { MatchCasing = MatchCasing.CaseInsensitive }))
            {
               
                if(File.Exists(file.FullName.Substring(0, file.FullName.Length - 3) + "nef"))
                {
                    continue;
                }

                string targetFilename = Path.Combine(targetDirectory, file.Name);
                if (File.Exists(targetFilename))
                {
                    Console.WriteLine("Skipping {0} because it already exists at target directory", file.Name);
                    continue;
                }

                // Console.WriteLine("Copying {0} to {1}", file.FullName, targetFilename);
                File.Copy(file.FullName, targetFilename);
            }
        }
    }
}
