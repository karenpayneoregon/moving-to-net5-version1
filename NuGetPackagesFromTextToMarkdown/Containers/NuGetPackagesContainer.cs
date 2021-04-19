using System;
using System.Collections.Generic;
using System.Linq;

namespace NuGetPackagesFromTextToMarkdown.Containers
{
    public class NuGetPackagesContainer
    {


        public delegate void OnEachPackage(PackageReference sender);
        /// <summary>
        /// Fires for each package under a project
        /// </summary>
        public static event OnEachPackage EachPackage;

        public delegate void OnEachProject(string projectName);
        /// <summary>
        /// Fires for each project iteration
        /// </summary>
        public static event OnEachProject EachProject ;

        /// <summary>
        /// Package list for a project
        /// </summary>
        public List<List<ProjectNuGetPackages>> PackagesList { get; set; }
        
        public NuGetPackagesContainer()
        {
            PackagesList = new List<List<ProjectNuGetPackages>>();
        }
        
        /// <summary>
        /// Method for iterating packages in a Visual Studio solution
        /// </summary>
        public void Iterate()
        {
            foreach (var nuGetPackage in PackagesList)
            {
                EachProject?.Invoke(nuGetPackage.FirstOrDefault().ProjectName);
                foreach (ProjectNuGetPackages item in nuGetPackage)
                {
                    item.PackageReferences.ForEach(p => EachPackage?.Invoke(p));
                }
            }
        }
    }
    
    /// <summary>
    /// Represents packages for a single project
    /// </summary>
    public class ProjectNuGetPackages
    {
        public ProjectNuGetPackages() => PackageReferences = new List<PackageReference>();
        public string ProjectName { get; set; }
        public List<PackageReference> PackageReferences { get; set; }
        public int Count => PackageReferences.Count;

        public PackageReference ListPackages()
        {
            var sorted = PackageReferences.OrderBy(x => x.Include).ToList();
            foreach (PackageReference packageReference in sorted)
            {
                //Console.WriteLine($"\t{packageReference}");
                return packageReference;
            }

            return null;
        }
        
    }
    
    /// <summary>
    /// A single package for a project
    /// </summary>
    public class PackageReference
    {
        /// <summary>
        /// Package name
        /// </summary>
        public string Include { get; set; }
        /// <summary>
        /// Package version
        /// </summary>
        public Version Version { get; set; }
        public override string ToString() => $"{Include},{Version}";

    }
}