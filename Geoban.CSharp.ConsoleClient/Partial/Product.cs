using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Geoban.CSharp.ConsoleClient.Partial
{
    public abstract class Base : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propname = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propname));
        }
    }



    public partial class Product : Base
    {

        partial void OnValidating();

        partial void OnValidated();

        private int id;

        public int Id
        {
            get { return id; }
            set {

                OnValidating();

                id = value;

                OnValidated();
            }
        }


        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }


    }
}
