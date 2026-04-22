using System;
using System.Collections.Generic;
using System.IO;
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
                    throw new ArgumentException($"Vigane sünniaasta: {value}. Aasta peab olema vahemikus 1901–{DateTime.Now.Year}.");
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

    // Õpetajal on Palk, õpilasel Toetus – üks liides, kaks tüüpi väljamakset
    public enum ValjamakseTyyp
    {
        Palk,
        Toetus
    }

    public interface ITooline
    {
        ValjamakseTyyp ValjamakseTyyp { get; set; }
        double ArvutaPalk();
    }

    public interface IHindaja
    {
        void Hinda(string hinne);
    }

    public class Koolihaldus
    {
        private List<Isik> inimesed = new List<Isik>();

        public List<Isik> Inimesed => inimesed;

        public void LisaInimene(Isik isik)
        {
            inimesed.Add(isik);
            Console.WriteLine($"{isik.Nimi} lisati nimekirja.");
        }

        public void LisaInimene(List<Isik> uuedInimesed)
        {
            // Näitame mis oli enne (vanaInimesed)
            Console.WriteLine($"\nNimekiri ENNE lisamist ({inimesed.Count} isikut):");
            if (inimesed.Count == 0)
                Console.WriteLine("  (nimekiri on tühi)");
            else
                foreach (var isik in inimesed)
                    Console.WriteLine($"  - {isik.Nimi}");

            inimesed.AddRange(uuedInimesed);

            // Näitame mis lisati (uuedInimesed)
            Console.WriteLine($"\nLisati {uuedInimesed.Count} uut isikut:");
            foreach (var isik in uuedInimesed)
                Console.WriteLine($"  + {isik.Nimi}");

            Console.WriteLine($"\nNimekiri PÄRAST lisamist ({inimesed.Count} isikut kokku).");
        }

        public void KuvaKoik()
        {
            Console.WriteLine("\nKOOLI NIMEKIRI");
            foreach (var isik in inimesed)
            {
                isik.Kirjelda();
            }
        }

        public void OtsiNutikas(string sisend)
        {
            bool leitud = false;

            // 1. Kui 4-kohaline number → otsime sünniaasta järgi
            if (int.TryParse(sisend, out int aasta) && sisend.Length == 4)
            {
                Console.WriteLine($"\nOtsime sünniaasta järgi: {aasta}");
                foreach (var isik in inimesed)
                {
                    if (isik.Sünniaasta == aasta)
                    {
                        isik.Kirjelda();
                        leitud = true;
                    }
                }
            }
            // 2. Kui roll-sõna → otsime tüübi järgi
            else if (sisend.Equals("opetaja", StringComparison.OrdinalIgnoreCase) ||
                     sisend.Equals("õpetaja", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("\nKõik õpetajad:");
                foreach (var isik in inimesed)
                    if (isik is Opetaja && isik is not Direktor) { isik.Kirjelda(); leitud = true; }
            }
            else if (sisend.Equals("direktor", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("\nKõik direktorid:");
                foreach (var isik in inimesed)
                    if (isik is Direktor) { isik.Kirjelda(); leitud = true; }
            }
            else if (sisend.Equals("opilane", StringComparison.OrdinalIgnoreCase) ||
                     sisend.Equals("õpilane", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("\nKõik õpilased (v.a üliõpilased):");
                foreach (var isik in inimesed)
                    if (isik is Opilane && isik is not Yliopilane) { isik.Kirjelda(); leitud = true; }
            }
            else if (sisend.Equals("yliopilane", StringComparison.OrdinalIgnoreCase) ||
                     sisend.Equals("üliõpilane", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("\nKõik üliõpilased:");
                foreach (var isik in inimesed)
                    if (isik is Yliopilane) { isik.Kirjelda(); leitud = true; }
            }
            // 3. Muul juhul → otsime nime järgi
            else
            {
                Console.WriteLine($"\nOtsime nime järgi: {sisend}");
                foreach (var isik in inimesed)
                {
                    if (isik.Nimi.Contains(sisend, StringComparison.OrdinalIgnoreCase))
                    {
                        isik.Kirjelda();
                        leitud = true;
                    }
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

        //7: Salvesta nimekiri faili
        public void SalvestaFaili(string failinimi)
        {
            using (StreamWriter writer = new StreamWriter(failinimi, append: false, encoding: System.Text.Encoding.UTF8))
            {
                writer.WriteLine($"KOOLI NIMEKIRI ({DateTime.Now:dd.MM.yyyy HH:mm})");
                foreach (var isik in inimesed)
                {
                    // Suunab Kirjelda() väljundi faili
                    var old = Console.Out;
                    var sw = new System.IO.StringWriter();
                    Console.SetOut(sw);
                    isik.Kirjelda();
                    Console.SetOut(old);
                    writer.WriteLine(sw.ToString().TrimEnd());
                }
                writer.WriteLine($"Kokku: {inimesed.Count} isikut.");
            }
            Console.WriteLine($"Nimekiri salvestatud faili: {failinimi}");
        }

        //9: Kuva ainult õpilased
        public void KuvaAinultOpilased()
        {
            Console.WriteLine("\nAINULT ÕPILASED");
            bool leitud = false;
            foreach (var isik in inimesed)
            {
                if (isik is Opilane)
                {
                    isik.Kirjelda();
                    leitud = true;
                }
            }
            if (!leitud) Console.WriteLine("  Ühtegi õpilast ei ole registreeritud.");

            // Boonus: sama LINQ-iga
            // inimesed.OfType<Opilane>().ToList().ForEach(o => o.Kirjelda());
        }
    }

    //10: Kursus – seos objektide vahel
    public class Kursus
    {
        public string Nimi { get; set; }
        public Opetaja VastutavOpetaja { get; set; }

        public Kursus(string nimi, Opetaja opetaja)
        {
            Nimi = nimi;
            VastutavOpetaja = opetaja;
        }

        public void KuvaInfo()
        {
            Console.WriteLine($"Kursus: {Nimi} | Vastutav õpetaja: {VastutavOpetaja.Nimi} (aine: {VastutavOpetaja.Aine})");
        }
    }
}
