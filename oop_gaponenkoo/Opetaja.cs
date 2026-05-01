using System;

namespace oop_gaponenkoo
{
    public class Opetaja : Isik, ITooline, IHindaja
    {
        public string Aine { get; set; }
        public double Tunnitasu { get; set; }
        public int TunnidKuus { get; set; }
        public ValjamakseTyyp ValjamakseTyyp { get; set; } = ValjamakseTyyp.Palk;

        public Opetaja() : base() { }

        public Opetaja(string nimi, string aine, double tunnitasu, int tunnidKuus) : base(nimi)
        {
            Aine = aine;
            Tunnitasu = tunnitasu;
            TunnidKuus = tunnidKuus;
        }

        public override string Kirjelda()
        {
            return $"Mina olen õpetaja {Nimi} ja ma õpetan: {Aine}. Vanus: {Vanus}.";
        }

        public void Opeta()
        {
            Console.WriteLine($"{Nimi} õpetab ainet: {Aine}.");
        }

        public virtual double ArvutaPalk()
        {
            return Tunnitasu * TunnidKuus;
        }

        public void Hinda(string hinne)
        {
            Console.WriteLine($"Õpetaja {Nimi} pani hinde: {hinne}");
        }
    }
}
