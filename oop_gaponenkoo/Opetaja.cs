using System;
using System.Collections.Generic;
using System.Text;

namespace oop_gaponenkoo
{
    public class Opetaja : Isik, ITooline, IHindaja
    {
        public string Aine { get; set; }
        public double Tunnitasu { get; set; }
        public int TunnidNadalas { get; set; }

        public Opetaja(string nimi, int aasta, string aine, double tunnitasu, int tunnidNadalas) : base(nimi, aasta)
        {
            Aine = aine;
            Tunnitasu = tunnitasu;
            TunnidNadalas = tunnidNadalas;
        }

        public override void Kirjelda()
        {
            Console.WriteLine($"Mina olen õpetaja {Nimi}, õpetan: {Aine}. Vanus: {Vanus}");
        }

        public virtual double ArvutaPalk(int uletunnid)
        {
            return (Tunnitasu * TunnidNadalas * 4) + (uletunnid * Tunnitasu);
        }

        public double ArvutaPalk() => ArvutaPalk(0);

        public void Hinda(string hinne)
        {
            Console.WriteLine($"Õpetaja {Nimi} pani hinde: {hinne}");
        }
    }

    public class Direktor : Opetaja
    {
        public double Lisatasu { get; set; } 

        public Direktor(string nimi, int aasta, string aine, double tunnitasu, int tunnidNadalas, double lisatasu)
            : base(nimi, aasta, aine, tunnitasu, tunnidNadalas)
        {
            Lisatasu = lisatasu;
        }

        public override void Kirjelda()
        {
            Console.WriteLine($"Mina olen direktor {Nimi}. Vanus: {Vanus}");
        }

        public virtual double ArvutaPalk(int uletunnid) 
        {
            double põhipalk = Tunnitasu * TunnidNadalas * 4;
            double lisatasu = uletunnid * Tunnitasu; 
            return põhipalk + lisatasu;
        }
    }
}
