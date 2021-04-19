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

            NuGetPackagesContainer.EachProject += OnEachProject;
            NuGetPackagesContainer.EachPackage += OnEachPackage;

            var operations = NuGetPackageOperations.Scan();
            operations.Iterate();
            Console.ReadLine();
        }

        private static void OnEachProject(string projectName)
        {
            Console.WriteLine(projectName);
        }

        private static void OnEachPackage(PackageReference sender)
        {
            Console.WriteLine($"\t{sender.Include}, {sender.Version}");
        }
    }
}

