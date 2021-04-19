using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BaseExceptionsLibrary;

namespace NuGetPackagesFromTextToMarkdown.Classes
{
    public class SolutionHelper : BaseExceptionProperties
    {
        /// <summary>
        /// Returns project names from a solution file
        /// </summary>
        /// <param name="solutionName"></param>
        /// <returns></returns>
        public static List<string> ProjectNames(string solutionName)
        {
            mHasException = false;
            var projectList = new List<string>();

            try
            {
                var content = File.ReadAllText(solutionName);
                var projReg = new Regex("Project\\(\"\\{[\\w-]*\\}\"\\) = \"([\\w _]*.*)\", \"(.*\\.(cs|vcx|vb)proj)\"", RegexOptions.Compiled);

                var matches = projReg.Matches(content).Cast<Match>();

                var projects = matches.Select(x => x.Groups[2].Value).ToList();
                for (var index = 0; index < projects.Count; ++index)
                {
                    if (!Path.IsPathRooted(projects[index]))
                    {
                        projects[index] = Path.Combine(path1: Path.GetDirectoryName(solutionName), path2: projects[index]);
                        //Console.WriteLine($"{index} : {Path.GetDirectoryName(solutionName)} -- {projects[index]}");
                    }

                    projects[index] = Path.GetFullPath(projects[index]);
                    projectList.Add(Path.GetFileNameWithoutExtension(projects[index]));
                }
            }
            catch (Exception ex)
            {
                mHasException = true;
                mLastException = ex;
            }

            return projectList;
        }
        public static List<string> ProjectFileNames(string solutionName)
        {
            mHasException = false;
            var projectList = new List<string>();

            try
            {
                var content = File.ReadAllText(solutionName);
                var projReg = new Regex("Project\\(\"\\{[\\w-]*\\}\"\\) = \"([\\w _]*.*)\", \"(.*\\.(cs|vcx|vb)proj)\"", RegexOptions.Compiled);

                var matches = projReg.Matches(content).Cast<Match>();

                var projects = matches.Select(x => x.Groups[2].Value).ToList();
                for (var index = 0; index < projects.Count; ++index)
                {
                    if (!Path.IsPathRooted(projects[index]))
                    {
                        projects[index] = Path.Combine(path1: Path.GetDirectoryName(solutionName), path2: projects[index]);
                    }


                    projectList.Add(projects[index]);
                }
            }
            catch (Exception ex)
            {
                mHasException = true;
                mLastException = ex;
            }

            return projectList;
        }
    }
}
