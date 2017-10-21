using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    //jezeli damy sealed ,zablokujemy dziedziczenie klasy
    public class Singleton
    {
        //prywante pole, ktore zawiera instancje swojej klasy, domyslnie na null
        private static Singleton instance_variable = null;

        // blokada przed dostepem wielu watkow, tworzy obiekt dopiero jak jest potrzebny
        private static readonly object pad_lock = new object();

        private int suma = 0;
        
        //publiczna statyczna wlasnosc ktora zwraca obiekt swojej klasy
        public static Singleton Instance
        {
            get
            {
                lock (pad_lock)
                {
                    if (instance_variable == null)
                    {
                        instance_variable = new Singleton();
                    }
                    return instance_variable;
                }
            }
        }

        public void  Dodaj_liczby(int a, int b)
        {           
            suma = a + b;
            Console.WriteLine("Suma dwoch liczb "+ suma); 
        }

        //prywatny konstruktor, blokuje mozliwosc tworzenia obiektow normalna droga,tylko za pomoca statycznej wlasciwosci
        private Singleton()
        {
        }
    }

    public class Program
    {/*
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Iteracja {0}", i + 1);
                Singleton.Instance.Dodaj_liczby(i, i+2);
            }
            Console.ReadKey();
        }*/
    }

}

