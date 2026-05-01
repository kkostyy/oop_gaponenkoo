using System;
using System.Collections.Generic;

namespace oop_gaponenkoo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Koolihaldus minuKool = new Koolihaldus();
            List<ITooline> palgasaajad = new List<ITooline>();

            Random rnd = new Random();

            ITooline[] toolised = new ITooline[3]
            {
                new Opilane(),
                new Opetaja(),
                new Yliopilane()
            };

            // Andmed
            string[] opetajaNimed   = { "Marina", "Aleksei", "Katrin", "Dmitri", "Liisa" };
            int[]    opetajaSynniaastad = { 1975, 1982, 1990, 1995, 1985 };
            string[] ained          = { "programmeerimine", "matemaatika", "füüsika", "keemia", "eesti keel" };
            double[] tunnitasud     = { 13.8, 15.0, 12.5, 14.2, 16.0 };
            int[]    tunnidKuus     = { 120, 130, 140, 150, 160 };
            string[] hinned         = { "1", "2", "3", "4", "5" };
            string[] kursused       = { "IKTpv_1", "TITpv23", "IKTpv_2", "LOGITpe23", "ROOpv24" };
            double[] lisatasud      = { 100, 200, 300, 400, 500 };

            string[] opilasNimed    = { "Yaroslav", "Anna", "Peeter", "Maria", "Ivan" };
            int[]    opilasSynniaastad = { 2005, 2006, 2007, 2008, 2009 };
            string[] koolid         = { "TTHK", "Gustav Adolfi Gümnaasium", "Tallinna Reaalkool" };
            int[]    klassid        = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            int[]    puudumised     = { 0, 5, 10, 13, 20 };
            string[] erialad        = { "IT", "Majandus", "Õigus", "Meditsiin", "Disain" };

            Oppevorm[] vormid = (Oppevorm[])Enum.GetValues(typeof(Oppevorm));

            // Direktor
            Console.WriteLine("=================DIREKTOR==================");
            Direktor direktor = new Direktor();
            direktor.Nimi       = opetajaNimed[rnd.Next(opetajaNimed.Length)];
            direktor.Sünniaasta = opetajaSynniaastad[rnd.Next(opetajaSynniaastad.Length)];
            direktor.Aine       = ained[rnd.Next(ained.Length)];
            direktor.Tunnitasu  = tunnitasud[rnd.Next(tunnitasud.Length)];
            direktor.TunnidKuus = tunnidKuus[rnd.Next(tunnidKuus.Length)];
            direktor.Lisatasu   = lisatasud[rnd.Next(lisatasud.Length)];
            Console.WriteLine(direktor.Kirjelda());
            Console.WriteLine($"Direktori palk: {direktor.ArvutaPalk()} EUR");
            palgasaajad.Add(direktor);

            // 20 juhuslikku isikut
            for (int i = 0; i < 20; i++)
            {
                var tooline = toolised[rnd.Next(0, 3)];
                switch (tooline)
                {
                    case Yliopilane:
                        Console.WriteLine("=================ÜLIÕPILANE==================");
                        Yliopilane yl = new Yliopilane();
                        yl.Nimi          = opilasNimed[rnd.Next(opilasNimed.Length)];
                        yl.Sünniaasta    = opilasSynniaastad[rnd.Next(opilasSynniaastad.Length)];
                        yl.Kool          = koolid[rnd.Next(koolid.Length)];
                        yl.Kursus        = (rnd.Next(1, 6)).ToString();
                        yl.Eriala        = erialad[rnd.Next(erialad.Length)];
                        yl.KeskmineHinne = Math.Round(rnd.NextDouble() * 5, 1);
                        yl.Puudumised    = puudumised[rnd.Next(puudumised.Length)];
                        yl.KasOnSotsTõend = rnd.Next(2) == 0;
                        yl.Staatus       = vormid[rnd.Next(vormid.Length)];
                        Console.WriteLine(yl.Kirjelda());
                        yl.Opi();
                        Console.WriteLine($"Toetus: {yl.ArvutaPalk()} EUR");
                        palgasaajad.Add(yl);
                        minuKool.LisaInimene(yl);
                        break;

                    case Opilane:
                        Console.WriteLine("=================ÕPILANE==================");
                        Opilane op = new Opilane();
                        op.Nimi          = opilasNimed[rnd.Next(opilasNimed.Length)];
                        op.Sünniaasta    = opilasSynniaastad[rnd.Next(opilasSynniaastad.Length)];
                        op.Kool          = koolid[rnd.Next(koolid.Length)];
                        op.Klass         = klassid[rnd.Next(klassid.Length)];
                        op.KeskmineHinne = Math.Round(rnd.NextDouble() * 5, 1);
                        op.Puudumised    = puudumised[rnd.Next(puudumised.Length)];
                        op.KasOnSotsTõend = rnd.Next(2) == 0;
                        op.Staatus       = vormid[rnd.Next(vormid.Length)];
                        Console.WriteLine(op.Kirjelda());
                        op.Opi();
                        Console.WriteLine($"Toetus: {op.ArvutaPalk()} EUR");
                        palgasaajad.Add(op);
                        minuKool.LisaInimene(op);
                        break;

                    case Opetaja:
                        Console.WriteLine("=================ÕPETAJA==================");
                        Opetaja opetaja = new Opetaja();
                        opetaja.Nimi       = opetajaNimed[rnd.Next(opetajaNimed.Length)];
                        opetaja.Sünniaasta = opetajaSynniaastad[rnd.Next(opetajaSynniaastad.Length)];
                        opetaja.Aine       = ained[rnd.Next(ained.Length)];
                        opetaja.Tunnitasu  = tunnitasud[rnd.Next(tunnitasud.Length)];
                        opetaja.TunnidKuus = tunnidKuus[rnd.Next(tunnidKuus.Length)];
                        Kursus kursus = new Kursus(kursused[rnd.Next(kursused.Length)], opetaja);
                        kursus.KuvaInfo();
                        Console.WriteLine(opetaja.Kirjelda());
                        opetaja.Opeta();
                        opetaja.Hinda(hinned[rnd.Next(hinned.Length)]);
                        Console.WriteLine($"Palk: {opetaja.ArvutaPalk()} EUR");
                        palgasaajad.Add(opetaja);
                        minuKool.LisaInimene(opetaja);
                        break;
                }
            }

            // Konstruktoriga õpilane
            Console.WriteLine("===================KONSTRUKTORIGA======================");
            Opilane opilane1 = new Opilane(
                opilasNimed[rnd.Next(opilasNimed.Length)],
                koolid[rnd.Next(koolid.Length)],
                klassid[rnd.Next(klassid.Length)],
                vormid[rnd.Next(vormid.Length)]
            );
            Console.WriteLine(opilane1.Kirjelda());
            Console.WriteLine("=======================================================");

            // Väljamaksed
            Console.WriteLine("---VÄLJAMAKSED---");
            foreach (ITooline t in palgasaajad)
            {
                string tyyp = t.ValjamakseTyyp.ToString();
                Console.WriteLine($"[{tyyp}] {((Isik)t).Nimi}: {t.ArvutaPalk():F2} EUR");
            }

            // Massiiviga LisaInimene
            List<Isik> uuedInimesed = new List<Isik>();
            int uuteArv = rnd.Next(3, 8);
            Console.WriteLine($"\nVõetakse vastu {uuteArv} uut õpilast:");
            for (int i = 0; i < uuteArv; i++)
            {
                Opilane u = new Opilane();
                u.Nimi          = opilasNimed[rnd.Next(opilasNimed.Length)];
                u.Sünniaasta    = opilasSynniaastad[rnd.Next(opilasSynniaastad.Length)];
                u.Kool          = koolid[rnd.Next(koolid.Length)];
                u.Klass         = klassid[rnd.Next(klassid.Length)];
                u.KeskmineHinne = Math.Round(rnd.NextDouble() * 5, 1);
                u.Puudumised    = puudumised[rnd.Next(puudumised.Length)];
                u.KasOnSotsTõend = rnd.Next(2) == 0;
                u.Staatus       = vormid[rnd.Next(vormid.Length)];
                uuedInimesed.Add(u);
            }
            minuKool.LisaInimene(uuedInimesed);

            // Kooli nimekiri
            Console.WriteLine("\n================MINU KOOL==================");
            Console.WriteLine($"Koolis on registreeritud {Isik.InimesteKoguarv} isikut.");
            minuKool.KuvaKoik();

            Console.WriteLine("\n=============AINULT ÕPILASED===============");
            minuKool.KuvaAinultOpilased();

            // Otsing
            Console.Write("\nKas sa tahad otsida kedagi? (jah/ei): ");
            string valik = Console.ReadLine();
            if (valik?.ToLower() == "jah")
            {
                Console.Write("Sisesta nimi või sünniaasta: ");
                string andmed = Console.ReadLine();
                if (int.TryParse(andmed, out int aasta))
                    minuKool.Otsi(aasta);
                else
                    minuKool.Otsi(andmed);
            }

            // Salvesta faili
            Console.Write("\nKuhu salvestada kooli nimekiri (nt nimekiri.txt): ");
            string failinimi = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(failinimi))
                minuKool.SalvestaFaili(failinimi);
        }
    }
}
