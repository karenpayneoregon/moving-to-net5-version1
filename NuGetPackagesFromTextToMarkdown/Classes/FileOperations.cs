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
            
            var lines = File.ReadAllLines("input.txt")
                .Where(line => !string.IsNullOrWhiteSpace(line)).ToList();

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
        /// <summary>
        /// Get NuGet package references from project file
        /// </summary>
        /// <param name="projectFileName">Path and file name of a project in the solution</param>
        /// <returns></returns>
        public static List<ProjectNuGetPackages> ProcessProjectFile(string projectFileName)
        {
            List<ProjectNuGetPackages> projectNuGetPackages = new();

            var content = File.ReadAllText(projectFileName);
            var document = XDocument.Parse(content);
            
            var packageReferences = document
                .XPathSelectElements("//PackageReference")
                .Select(element => new PackageReference
                {
                    Include = element.Attribute("Include").Value,
                    Version = new Version(element.Attribute("Version").Value)
                });

            var pnp = new ProjectNuGetPackages() {ProjectName = Path.GetFileName(projectFileName) };
            
            foreach (var packageReference in packageReferences)
            {

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
