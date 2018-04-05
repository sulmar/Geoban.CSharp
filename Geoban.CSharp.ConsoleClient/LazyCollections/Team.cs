using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geoban.CSharp.ConsoleClient.LazyCollections
{
    public class Team : IEnumerable
    {
        private IList<string> members = new List<string>();

        public void Add(string name)
        {
            members.Add(name);
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < members.Count - 1; i++)
            {
                yield return members[i];
            }    
        }
    }
}
