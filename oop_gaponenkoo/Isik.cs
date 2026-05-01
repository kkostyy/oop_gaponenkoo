using System;

namespace oop_gaponenkoo
{
    public abstract class Isik
    {
        private int sünniaasta;

        public string Nimi { get; set; }

        public static int InimesteKoguarv = 0;

        public Isik()
        {
            InimesteKoguarv++;
        }

        public Isik(string nimi)
        {
            Nimi = nimi;
            InimesteKoguarv++;
        }

        public int Sünniaasta
        {
            get { return sünniaasta; }
            set
            {
                if (value > 1900 && value <= DateTime.Now.Year)
                    sünniaasta = value;
                else
                    throw new ArgumentException($"Vigane sünniaasta: {value}. Aasta peab olema vahemikus 1901–{DateTime.Now.Year}.");
            }
        }

        public int Vanus => sünniaasta == 0 ? 0 : DateTime.Now.Year - sünniaasta;

        public void Tervita()
        {
            Console.WriteLine($"Tere! Mina olen {Nimi} ja ma olen {Vanus} aastat vana.");
        }

        public abstract string Kirjelda();
    }
}
