using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.API
{
    class PlasticProgram
    {
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
    }
}
