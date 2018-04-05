using Geoban.CSharp.ConsoleClient.Delegates;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geoban.CSharp.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {

            var calculator = new Calculator();

            calculator.log += LogToConsole;
            calculator.log += LogToTrace;
            calculator.log += Console.WriteLine;

            calculator.Multiply = (x, y) => x * y;

            calculator.Multiply += delegate (decimal x, decimal y)
            {
                return x * y;
            };

            // metoda anonimowa
            calculator.log += delegate (string message)
            {
                Console.WriteLine("Db {0}", message);
            };

            calculator.log += message => Console.WriteLine("Lambda {0}", message);


            var amount = calculator.Calculate(100);

            calculator.log -= LogToTrace;

            amount = calculator.Calculate(50);

            calculator.log = null;


            amount = calculator.Calculate(99);


            // calculator.log += LogToDb;

            // calculator.log("Hello");


        }

        static void LogToTrace(string message)
        {
            Trace.WriteLine(message);
        }

        static void LogToConsole(string message)
        {
            Console.WriteLine(message);
        }

        static void LogToDb(string message, bool isOk)
        {
            Console.WriteLine(message);
        }

    }
}
