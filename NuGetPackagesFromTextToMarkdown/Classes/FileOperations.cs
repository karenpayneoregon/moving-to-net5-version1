using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;
using NuGetPackagesFromTextToMarkdown.Containers;

namespace NuGetPackagesFromTextToMarkdown.Classes
{
    public class FileOperations
    {
        public static int IdStartIndex { get; set; }
        public static int VersionsStartIndex { get; set; }
        public static int ProjectNameStartIndex { get; set; }

        public static void ProcessFile()
        {
            List<NuGetPackage> packages = new();
            var lines = File.ReadAllLines("input.txt").Where(line => !string.IsNullOrWhiteSpace(line)).ToList();

            var headerLine = lines.FirstOrDefault();

            IdStartIndex = headerLine.IndexOf("Id");
            VersionsStartIndex = headerLine.IndexOf("Versions") +1;
            ProjectNameStartIndex = headerLine.IndexOf("ProjectName") +1;
            
            lines.RemoveRange(0,2);

            var sb = new StringBuilder();
            sb.AppendLine("# Solution name");
            sb.AppendLine(" ");
            sb.AppendLine($"### {Path.GetFileNameWithoutExtension(Helpers.SolutionName())}");
            sb.AppendLine(" ");

            
            sb.AppendLine("|Id | Versions  | ProjectName |");
            sb.AppendLine("| :---         |  :---  | :---  |");


            foreach (var line in lines)
            {
                var package = new NuGetPackage();
                
                package.Id = line.Substring(0, VersionsStartIndex -1).RemoveWhitespace();
                package.Versions = line.Substring(VersionsStartIndex -1, ProjectNameStartIndex - VersionsStartIndex).RemoveWhitespace();
                package.ProjectName = line.Substring(ProjectNameStartIndex - 1).RemoveWhitespace();
                packages.Add(package);
                sb.AppendLine(package.Line);
            }

            File.WriteAllText("out.md",sb.ToString());

        }

        public static List<ProjectNuGetPackages> ProcessProjectFile(string fileName)
        {
            List<ProjectNuGetPackages> projectNuGetPackages = new();

            if (fileName.Contains("BasicRead"))
            {
                Console.WriteLine();
            }

            var content = File.ReadAllText(fileName);
            var document = XDocument.Parse(content);
            
            var packageReferences = document.XPathSelectElements("//PackageReference")
                .Select(element => new PackageReference
                {
                    Include = element.Attribute("Include").Value,
                    Version = new Version(element.Attribute("Version").Value)
                });

            ProjectNuGetPackages pnp = new ProjectNuGetPackages() {ProjectName = Path.GetFileName(fileName) };
            
            //Console.WriteLine($"Project file {Path.GetFileName(fileName)} contains {packageReferences.Count()} package references:");
            
            foreach (var packageReference in packageReferences)
            {
                //Console.WriteLine($"{packageReference.Include}, version {packageReference.Version}");
                pnp.PackageReferences.Add(new PackageReference()
                {
                    Include = packageReference.Include, 
                    Version = packageReference.Version
                });

                projectNuGetPackages.Add(pnp);
            }

            

            return projectNuGetPackages;
            
        }
        
    }
}
