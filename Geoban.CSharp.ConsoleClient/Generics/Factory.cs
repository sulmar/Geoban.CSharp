using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geoban.CSharp.ConsoleClient.Generics
{
    public class Factory
    {
        public static TItem Create<TItem>()
            where TItem : new()
        {
            return new TItem();
        }
    }
}
