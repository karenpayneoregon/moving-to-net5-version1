using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NuGetPackagesFromTextToMarkdown.Containers;

namespace NuGetPackagesFromTextToMarkdown.Classes
{
    public class NuGetPackageOperations
    {
        public static NuGetPackagesContainer Scan()
        {
            var names = SolutionHelper.ProjectFileNames(Helpers.SolutionName());


            NuGetPackagesContainer container = new NuGetPackagesContainer();
            foreach (var name in names)
            {
                List<ProjectNuGetPackages> projectNuGetPackages = FileOperations.ProcessProjectFile(name);
                if (projectNuGetPackages.Count > 0)
                {
                    container.PackagesList.Add(projectNuGetPackages);
                }

            }

            return container;
        }
    }
}
