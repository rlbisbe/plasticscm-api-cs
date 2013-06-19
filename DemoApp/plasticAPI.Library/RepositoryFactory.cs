using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PlasticAPI.Library
{
    class RepositoryFactory
    {
        public static Repository RepositoryFromString(string line)
        {
            Regex regex = new Regex(@"(\S*) (\S*) (\S*)");
            Match match = regex.Match(line);
            Repository repository = new Repository();
            repository.Id = match.Groups[2].Value;
            repository.Name = match.Groups[3].Value;
            repository.Server = match.Groups[4].Value;
            return repository;
        }
    }
}
