using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Geoban.CSharp.ConsoleClient.Reflections
{


    public interface IStrategy
    {
        void DoWork();    
    }

    public class HappyHoursStrategy : IStrategy
    {
        public HappyHoursStrategy(int x)
        {

        }

        public void DoWork()
        {
            throw new NotImplementedException();
        }
    }

    public class HappyDaysStrategy : IStrategy
    {
        private int x;

        public HappyDaysStrategy(int x)
        {
            this.x = x;
        }

        public void DoWork()
        {
            x++;
        }
    }


    public class Factory
    {
        //public static IStrategy Create(string name)
        //{
        //    switch(name)
        //    {
        //        case "HappyHours": return new HappyDaysStrategy();
        //        case "HappyDays": return new HappyDaysStrategy();

        //        default: throw new NotSupportedException();
        //    }
        //}

        public static IStrategy Create(string name)
        {
            string classname = String.Format("{0}.{1}{2}", "Geoban.CSharp.ConsoleClient.Reflections", name, "Strategy");

            var type = Type.GetType(classname);

            FieldInfo[] fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            Debug.WriteLine("{0} {1}", fields[0].Name);

            // fields[0].FieldType

            return (IStrategy)Activator.CreateInstance(type, 10);


        }
    }
}
