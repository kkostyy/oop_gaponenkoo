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
            Console.WriteLine($"Mina olen opetaja {Nimi} ja ma opetan: {Aine}. Vanus: {Vanus}");
        }

        public void Opeta()
        {
            Console.WriteLine($"{Nimi} opetab ainet: {Aine}.");
        }

        public virtual double ArvutaPalk()
        {
            return Tunnitasu * TunnidNadalas * 4;
        }

        public void Hinda(string hinne)
        {
            Console.WriteLine($"Opetaja {Nimi} pani hinde: {hinne}");
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
            Console.WriteLine($"Mina olen direktor {Nimi}. Opetan: {Aine}. Vanus: {Vanus}");
        }

        public override double ArvutaPalk()
        {
            return base.ArvutaPalk() + Lisatasu;
        }
    }
}
