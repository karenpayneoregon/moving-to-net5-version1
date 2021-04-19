using System;
using System.Collections.Generic;
using System.Linq;

namespace NuGetPackagesFromTextToMarkdown.Containers
{
    public class ProjectNuGetPackages
    {
        public delegate void OnEachPackage(string sender);
        public static event OnEachPackage EachPackage;
        
        public ProjectNuGetPackages() => PackageReferences = new List<PackageReference>();
        public string ProjectName { get; set; }
        public List<PackageReference> PackageReferences { get; set; }
        public int Count => PackageReferences.Count;

        public void ListPackages()
        {
            var sorted = PackageReferences.OrderBy(x => x.Include).ToList();
            foreach (var packageReference in sorted)
            {
                Console.WriteLine($"\t{packageReference}");
            }
            
        }
        
    }
    public class PackageReference
    {
        public string Include { get; set; }
        public Version Version { get; set; }
        public override string ToString() => $"{Include},{Version}";

    }
}