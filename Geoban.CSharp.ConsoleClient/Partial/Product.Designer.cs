using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geoban.CSharp.ConsoleClient.Partial
{
    public partial class Product
    {
        public string Color { get; set; }

        partial void OnValidating()
        {
            // ...
        }

        public void DoWork()
        {
			
        }

    }
}
