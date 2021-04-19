using System;

namespace NuGetPackagesFromTextToMarkdown.Containers
{
    public class NuGetPackage
    {
        public string Id { get; set; }
        public string Versions { get; set; }
        public string ProjectName { get; set; }
        /// <summary>
        /// Used to add a package to a text file
        /// </summary>
        public string Line => $"|{Id} | {Versions} | {ProjectName} |";
        /// <summary>
        /// For debugging or informational coders
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"{Id},{Versions},{ProjectName}";

    }


}
