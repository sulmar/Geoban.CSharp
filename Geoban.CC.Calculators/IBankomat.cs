using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geoban.CC.Calculators
{
    interface IWyplata
    {
        void Wyplac(decimal amount);
    }

    interface IWplata
    {
        void Wplac(decimal amount);
    }

    interface ITransfer
    {
        void Przelej(decimal amount);
    }

    interface IStandardBankomat : IWyplata, IWplata
    {

    }

    class Santander : IStandardBankomat, ITransfer
    {
        public void Przelej(decimal amount)
        {
            throw new NotImplementedException();
        }

        public void Wplac(decimal amount)
        {
            throw new NotImplementedException();
        }

        public void Wyplac(decimal amount)
        {
            throw new NotImplementedException();
        }
    }


    interface IBankomat
    {
        void PokazReklamy();

        void Wyplac(decimal amount);

        void Wplac(decimal amount);

        void Doladuj(decimal amount);

        void Przelej(decimal amount);
    }

    class PKOBankomat : IBankomat
    {
        public void Doladuj(decimal amount)
        {
            // ...
        }

        public void PokazReklamy()
        {
            // ...
        }

        public void Przelej(decimal amount)
        {
            throw new NotSupportedException();
        }

        public void Wplac(decimal amount)
        {
            throw new NotSupportedException();
        }

        public void Wyplac(decimal amount)
        {
           // ...
        }
    }
}
