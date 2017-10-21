using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    // typy generyczne
    public class Singleton2<T> where T : class, new()
    {
        //prywante pole, ktore zawiera instancje swojej klasy, domyslnie na null
        private static T instance_variable = null;

        // blokada przed dostepem wielu watkow, tworzy obiekt dopiero jak jest potrzebny
        private static readonly object pad_lock = new object();

        protected int suma = 0;
        //publiczna statyczna wlasnosc ktora zwraca obiekt swojej klasy
        public static T GetInstance()
        {
            lock (pad_lock)
            {
                if (instance_variable == null)
                {
                    instance_variable = new T();
                }
                return instance_variable;
            }
        }

        public void Dodaj_liczby()
        {
            this.suma = this.suma + 5;
            Console.WriteLine("Suma dwoch liczb " + this.suma);
        }

    }

    public class Dzialania : Singleton2<Dzialania>
    {
        public void Dodaj()
        {
            Console.WriteLine("Dziedziczenie " + suma);
        }
    }

    class Program2
    {
        static void Main(string[] args)
        {
            Singleton2<Dzialania> obiekt = Dzialania.GetInstance();
            obiekt.Dodaj_liczby();
            obiekt = Dzialania.GetInstance();
            obiekt.Dodaj_liczby();

            Dzialania dzialania = new Dzialania();
            dzialania.Dodaj();

            obiekt = Dzialania.GetInstance();
            obiekt.Dodaj_liczby();

            Console.ReadKey();
        }
    }
}
