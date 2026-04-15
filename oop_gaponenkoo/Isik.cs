using System;
using System.Collections.Generic;
using System.Text;

namespace oop_gaponenkoo
{
    public abstract class Isik
    {
        private int sünniaasta;

        public string Nimi { get; set; }

        public int Sünniaasta
        {
            get { return sünniaasta; }
            set
            {
                if (value > 1900 && value <= DateTime.Now.Year)
                    sünniaasta = value;
                else
                    Console.WriteLine("Vigane sünniaasta!");
            }
        }

        public int Vanus => sünniaasta == 0 ? 0 : DateTime.Now.Year - sünniaasta;

        public static int InimesteKoguarv = 0;

        public Isik(string nimi, int aasta)
        {
            Nimi = nimi;
            Sünniaasta = aasta;
            InimesteKoguarv++;
        }

        public void Tervita()
        {
            Console.WriteLine($"Tere! Mina olen {Nimi} ja ma olen {Vanus} aastat vana.");
        }

        public abstract void Kirjelda();
    }

    public enum Oppevorm
    {
        Paevane,
        Kaugope,
        Ekstern,
        AkadeemilinePuhkus
    }

    public interface ITooline
    {
        double ArvutaPalk();
    }

    public interface IHindaja
    {
        void Hinda(string hinne);
    }

    public class Koolihaldus
    {
        private List<Isik> inimesed = new List<Isik>();

        public void LisaInimene(Isik isik)
        {
            inimesed.Add(isik);
            Console.WriteLine($"{isik.Nimi} lisati nimekirja.");
        }

        public void LisaInimene(List<Isik> uuedInimesed)
        {
            inimesed.AddRange(uuedInimesed);
            Console.WriteLine($"Lisati {uuedInimesed.Count} uut inimest.");
        }

        public void KuvaKoik()
        {
            Console.WriteLine("\nKOOLI NIMEKIRI");
            foreach (var isik in inimesed)
            {
                isik.Kirjelda();
            }
        }

        public void Otsi(string otsitavNimi)
        {
            Console.WriteLine($"\nOtsime nime jargi: {otsitavNimi}");
            bool leitud = false;
            foreach (var isik in inimesed)
            {
                if (isik.Nimi.Contains(otsitavNimi, StringComparison.OrdinalIgnoreCase))
                {
                    isik.Kirjelda();
                    leitud = true;
                }
            }
            if (!leitud) Console.WriteLine("  Kedagi ei leitud.");
        }

        public void Otsi(int sünniaasta)
        {
            Console.WriteLine($"\nOtsime sunniaaasta jargi: {sünniaasta}");
            bool leitud = false;
            foreach (var isik in inimesed)
            {
                if (isik.Sünniaasta == sünniaasta)
                {
                    isik.Kirjelda();
                    leitud = true;
                }
            }
            if (!leitud) Console.WriteLine("  Kedagi ei leitud.");
        }

        public void KuvaPalk(string nimi)
        {
            bool leitud = false;
            foreach (var isik in inimesed)
            {
                if (isik.Nimi.Contains(nimi, StringComparison.OrdinalIgnoreCase))
                {
                    if (isik is ITooline tooline)
                    {
                        Console.WriteLine($"\n{isik.Nimi} palk: {tooline.ArvutaPalk():F2} EUR kuus.");
                        leitud = true;
                    }
                    else
                    {
                        Console.WriteLine($"\n{isik.Nimi} ei ole palgaline tooline.");
                        leitud = true;
                    }
                }
            }
            if (!leitud) Console.WriteLine("  Isikut nimega '{nimi}' ei leitud.");
        }

        public void HindaOpilast(string opetajaNimi, string hinne)
        {
            bool leitud = false;
            foreach (var isik in inimesed)
            {
                if (isik.Nimi.Contains(opetajaNimi, StringComparison.OrdinalIgnoreCase) && isik is IHindaja hindaja)
                {
                    hindaja.Hinda(hinne);
                    leitud = true;
                }
            }
            if (!leitud) Console.WriteLine($"  Opetajat nimega '{opetajaNimi}' ei leitud.");
        }
    }
}
