using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geoban.CSharp.ConsoleClient.Delegates
{
    class Calculator
    {
        public Action<string> log;
        public Func<decimal, decimal, decimal> Multiply;
        public Predicate<decimal> isOverLimit;

        // ekwiwalent:
        // public delegate void Log(string message);
        // public Log log;


        public decimal Calculate(decimal amount)
        {
            // TODO: logowanie

            var invocations = log.GetInvocationList();

            log?.Invoke(String.Format("Calculating... {0}", amount));

            // ...
            if (log!=null)
                log(String.Format("Calculated... {0}", amount));


            amount = Multiply(10, 20);

            return amount;
        }

        //private void Log(string message)
        //{
        //    Console.WriteLine(message);
        //}
    }
}
