using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Channels;
using NuGetPackagesFromTextToMarkdown.Classes;
using NuGetPackagesFromTextToMarkdown.Containers;

namespace NuGetPackagesFromTextToMarkdown
{
    class Program
    {
        static void Main(string[] args)
        {
            FileOperations.ProcessFile();

            var names = SolutionHelper.ProjectFileNames(Helpers.SolutionName());
            foreach (var name in names)
            {

                List<ProjectNuGetPackages> projectNuGetPackages = FileOperations.ProcessProjectFile(name);

                
                if (!string.IsNullOrWhiteSpace(projectNuGetPackages.FirstOrDefault()?.ProjectName))
                {
                    Console.WriteLine(projectNuGetPackages.FirstOrDefault()?.ProjectName);
                    foreach (var package in projectNuGetPackages)
                    {
                        package.ListPackages();
                    }
                }
            }

            Console.ReadLine();
        }
    }
}
