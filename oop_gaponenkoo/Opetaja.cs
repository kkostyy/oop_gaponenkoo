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
        public int UletunnidKuus { get; set; } = 0;

        public Opetaja(string nimi, int aasta, string aine, double tunnitasu, int tunnidNadalas) : base(nimi, aasta)
        {
            Aine = aine;
            Tunnitasu = tunnitasu;
            TunnidNadalas = tunnidNadalas;
        }

        public override void Kirjelda()
        {
            double palk = ArvutaPalk(UletunnidKuus);
            Console.WriteLine($"Mina olen õpetaja {Nimi}, õpetan: {Aine}. Vanus: {Vanus}. " +
                              $"Ületunnid: {UletunnidKuus}h. Kogupalk: {palk:F2} EUR.");
        }

        public virtual double ArvutaPalk(int uletunnid)
        {
            return (Tunnitasu * TunnidNadalas * 4) + (uletunnid * Tunnitasu);
        }

        public double ArvutaPalk() => ArvutaPalk(UletunnidKuus);

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
            double palk = ArvutaPalk(UletunnidKuus);
            Console.WriteLine($"Mina olen direktor {Nimi}. Vanus: {Vanus}. " +
                              $"Ületunnid: {UletunnidKuus}h. Kogupalk: {palk:F2} EUR.");
        }

        public override double ArvutaPalk(int uletunnid)
        {
            double pohipalk = Tunnitasu * TunnidNadalas * 4;
            double uletasuRaha = uletunnid * Tunnitasu;
            return pohipalk + uletasuRaha + Lisatasu;
        }
    }
}
