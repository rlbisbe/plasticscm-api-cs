using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlasticAPI.Library
{
    public class PlasticProgram
    {
        /// <summary>
        /// Lists all repositories on the current machine
        /// TODO: Extend to ask for other servers
        /// </summary>
        /// <returns>List of repositories</returns>
        public static List<Repository> ListRepositories()
        {
            Process p = new Process();
            p.StartInfo.FileName = "cm";
            p.StartInfo.Arguments = "lrep";
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.UseShellExecute = false;
            p.Start();

            List<Repository> repositories = new List<Repository>();
            while (!p.StandardOutput.EndOfStream)
            {
                string line = p.StandardOutput.ReadLine();
                repositories
                    .Add(RepositoryFactory.RepositoryFromString(line));
            }

            return repositories;
        }

        /// <summary>
        /// Creates a new repository with the specified information
        /// </summary>
        /// <param name="rep">Repository to create</param>
        public static void CreateRepository(Repository rep)
        {
            if (string.IsNullOrEmpty(rep.Server))
                throw new ArgumentException("Repository server cannot be null");

            if (string.IsNullOrEmpty(rep.Name))
                throw new ArgumentException("Repository name cannot be null");
                
            Process p = GetCmProcess();
            p.StartInfo.Arguments = "mkrep " + rep.Server + " " + rep.Name;
            p.Start();
        }

        private static Process GetCmProcess()
        {
            Process p = new Process();
            p.StartInfo.FileName = "cm";
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.UseShellExecute = false;
            return p;
        }
    }
}
