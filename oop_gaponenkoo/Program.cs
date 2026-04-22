using System;
using System.Collections.Generic;

namespace oop_gaponenkoo
{
    internal class Program
    {
        static Koolihaldus kool = new Koolihaldus();

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            bool tooks = true;
            while (tooks)
            {
                Console.WriteLine("\nKOOLIHALDUSE SUSTEEM");
                Console.WriteLine("1. Lisa opetaja");
                Console.WriteLine("2. Lisa direktor");
                Console.WriteLine("3. Lisa opilane");
                Console.WriteLine("4. Lisa yliopilane");
                Console.WriteLine("5. Kuva koik isikud");
                Console.WriteLine("6. Otsi (nimi / aasta / roll)");
                Console.WriteLine("8. Kuva opetaja palk");
                Console.WriteLine("9. Opetaja hindab opilast");
                Console.WriteLine("10. Kuva kokku registreeritud isikuid");
                Console.WriteLine("11. Kuva ainult opilased");
                Console.WriteLine("12. Salvesta nimekiri faili");
                Console.WriteLine("13. Kuva kursuse info (demo)");
                Console.WriteLine("14. Kuva koik valjamaksed (palgad + toetused)");
                Console.WriteLine("15. Genereeri juhuslikud opilased (demo)");
                Console.WriteLine("0. Valju");
                Console.Write("Vali: ");

                string valik = Console.ReadLine();

                switch (valik)
                {
                    case "1": LisaOpetaja(); break;
                    case "2": LisaDirektor(); break;
                    case "3": LisaOpilane(); break;
                    case "4": LisaYliopilane(); break;
                    case "5": kool.KuvaKoik(); break;
                    case "6": OtsiNutikas(); break;
                    case "8": KuvaPalk(); break;
                    case "9": HindaOpilast(); break;
                    case "10":
                        Console.WriteLine($"\nKokku registreeritud: {Isik.InimesteKoguarv} isikut.");
                        break;
                    case "11":
                        kool.KuvaAinultOpilased();
                        break;
                    case "12":
                        SalvestaFaili();
                        break;
                    case "13":
                        KuvaKursusDemo();
                        break;
                    case "14":
                        KuvaKoikValjamaksed();
                        break;
                    case "15":
                        GenereeriJuhuslikudOpilased();
                        break;
                    case "0":
                        tooks = false;
                        Console.WriteLine("Nagemiseni!");
                        break;
                    default:
                        Console.WriteLine("Vigane valik! Proovi uuesti.");
                        break;
                }
            }
        }

        static string LoeString(string kysimus)
        {
            while (true)
            {
                Console.Write(kysimus);
                string v = Console.ReadLine()?.Trim();
                if (!string.IsNullOrEmpty(v)) return v;
                Console.WriteLine("  Vali ei tohi olla tyhi!");
            }
        }

        static int LoeInt(string kysimus, int min, int max)
        {
            while (true)
            {
                Console.Write(kysimus);
                if (int.TryParse(Console.ReadLine(), out int v) && v >= min && v <= max)
                    return v;
                Console.WriteLine($"  Vigane sisestus! Sisesta arv vahemikus {min}-{max}.");
            }
        }

        static double LoeDouble(string kysimus, double min)
        {
            while (true)
            {
                Console.Write(kysimus);
                string raw = Console.ReadLine()?.Replace(',', '.');
                if (double.TryParse(raw, System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture, out double v) && v >= min)
                    return v;
                Console.WriteLine($"  Vigane sisestus! Sisesta positiivne arv (min {min}).");
            }
        }

        static Oppevorm LoeOppevorm()
        {
            Console.WriteLine("Oppevorm:");
            Console.WriteLine("1 - Paevane");
            Console.WriteLine("2 - Kaugope");
            Console.WriteLine("3 - Ekstern");
            Console.WriteLine("4 - Akadeemiline puhkus");
            int v = LoeInt("  Vali (1-4): ", 1, 4);
            return (Oppevorm)(v - 1);
        }

        static void LisaOpetaja()
        {
            Console.WriteLine("\nLisa opetaja");
            string nimi = LoeString("  Nimi: ");
            int aasta = LoeInt("  Sunniaaasta: ", 1900, DateTime.Now.Year - 18);
            string aine = LoeString("  Aine: ");
            double tasu = LoeDouble("  Tunnitasu (EUR): ", 0.01);
            int tunnid = LoeInt("  Tunde nadalas: ", 1, 40);
            int uletunnid = LoeInt("  Ületunnid sel kuul (tundides): ", 0, 500);

            var op = new Opetaja(nimi, aasta, aine, tasu, tunnid);
            op.UletunnidKuus = uletunnid;

            double kogupalk = op.ArvutaPalk(uletunnid);
            Console.WriteLine($"  Kogupalk koos ületundidega: {kogupalk:F2} EUR.");

            kool.LisaInimene(op);
        }

        static void LisaDirektor()
        {
            Console.WriteLine("\nLisa direktor");
            string nimi = LoeString("  Nimi: ");
            int aasta = LoeInt("  Sunniaaasta: ", 1900, DateTime.Now.Year - 18);
            string aine = LoeString("  Aine: ");
            double tasu = LoeDouble("  Tunnitasu (EUR): ", 0.01);
            int tunnid = LoeInt("  Tunde nadalas: ", 1, 40);
            double lisa = LoeDouble("  Lisatasu (EUR): ", 0);
            int uletunnid = LoeInt("  Ületunnid sel kuul (tundides): ", 0, 500);

            var dir = new Direktor(nimi, aasta, aine, tasu, tunnid, lisa);
            dir.UletunnidKuus = uletunnid;

            double kogupalk = dir.ArvutaPalk(uletunnid);
            Console.WriteLine($"  Kogupalk koos ületundidega: {kogupalk:F2} EUR.");

            kool.LisaInimene(dir);
        }

        static void LisaOpilane()
        {
            Console.WriteLine("\nLisa õpilane");
            string nimi = LoeString("  Nimi: ");

            // Harjutus 8: try-catch – Isik konstruktor viskab ArgumentException vigase aasta puhul
            int aasta;
            while (true)
            {
                try
                {
                    aasta = LoeInt("  Sünniaasta: ", 1900, DateTime.Now.Year);
                    // Testime juba siin – konstruktor viskab ka, aga nii näeme try-catch tööd
                    if (aasta <= 1900 || aasta > DateTime.Now.Year)
                        throw new ArgumentException($"Vigane sünniaasta: {aasta}.");
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"  VIGA: {ex.Message} Proovi uuesti.");
                }
            }

            string koolNimi = LoeString("  Kooli nimi: ");
            int klass = LoeInt("  Klass (1-12): ", 1, 12);
            Oppevorm vorm = LoeOppevorm();

            double hinne = LoeDouble("  Keskmine hinne (0-5): ", 0);
            int puudumised = LoeInt("  Puudumiste arv: ", 0, 500);

            var op = new Opilane(nimi, aasta, koolNimi, klass, vorm, hinne, puudumised);
            op.KasOnSotsTõend = LoeInt("  Sotsiaalne tõend? (0=ei, 1=jah): ", 0, 1) == 1;
            kool.LisaInimene(op);
        }

        static void LisaYliopilane()
        {
            Console.WriteLine("\nLisa üliõpilane");
            string nimi = LoeString("  Nimi: ");
            int aasta = LoeInt("  Sünniaasta: ", 1900, DateTime.Now.Year - 17);
            string koolNimi = LoeString("  Ülikooli nimi: ");
            int kursus = LoeInt("  Kursus (1-6): ", 1, 6);
            Oppevorm vorm = LoeOppevorm();
            string eriala = LoeString("  Eriala: ");

            double hinne = LoeDouble("  Keskmine hinne: ", 0);
            int puudumised = LoeInt("  Puudumiste arv: ", 0, 500);

            var yl = new Yliopilane(nimi, aasta, koolNimi, kursus, vorm, eriala, hinne, puudumised);
            yl.KasOnSotsTõend = LoeInt("  Sotsiaalne tõend? (0=ei, 1=jah): ", 0, 1) == 1;
            kool.LisaInimene(yl);
        }

        static void OtsiNutikas()
        {
            Console.WriteLine("\nSisesta otsing (nimi, aasta, 'opetaja', 'direktor', 'opilane', 'yliopilane'):");
            Console.Write("  > ");
            string sisend = Console.ReadLine()?.Trim();
            if (string.IsNullOrEmpty(sisend)) return;

            kool.OtsiNutikas(sisend);
        }

        static void KuvaPalk()
        {
            string nimi = LoeString("\nSisesta nimi, kelle palka vaadata: ");
            bool leitud = false;

            foreach (var isik in kool.Inimesed)
            {
                if (isik.Nimi.Contains(nimi, StringComparison.OrdinalIgnoreCase))
                {
                    if (isik is Opetaja opetaja)
                    {
                        double palk = opetaja.ArvutaPalk(opetaja.UletunnidKuus);
                        Console.WriteLine($"{isik.Nimi} kogupalk (ületunnid: {opetaja.UletunnidKuus}h): {palk:F2} EUR.");
                        leitud = true;
                    }
                }
            }
            if (!leitud) Console.WriteLine("Isikut ei leitud.");
        }

        static void HindaOpilast()
        {
            string opetajaNimi = LoeString("\nOpetaja nimi: ");
            int hinne = LoeInt("Hinne (1-5): ", 1, 5);
            kool.HindaOpilast(opetajaNimi, hinne.ToString());
        }

        // Harjutus (õpetaja lahendusest): üks tsükkel, kaks tüüpi väljamakset – polümorfism!
        static void KuvaKoikValjamaksed()
        {
            Console.WriteLine("\n--- VÄLJAMAKSED (palgad + toetused) ---");
            bool leitud = false;
            foreach (var isik in kool.Inimesed)
            {
                if (isik is ITooline tooline)
                {
                    string tyyp = tooline.ValjamakseTyyp.ToString();
                    double summa = tooline.ArvutaPalk();
                    Console.WriteLine($"  [{tyyp}] {isik.Nimi}: {summa:F2} EUR");
                    leitud = true;
                }
            }
            if (!leitud) Console.WriteLine("  Ühtegi palgalist isikut ei leitud.");
        }

        // Õpetaja lahendusest: Random + Enum.GetValues – genereerime 5 juhuslikku õpilast
        static void GenereeriJuhuslikudOpilased()
        {
            Random rnd = new Random();
            string[] nimed = { "Maria", "Kati", "Juhan", "Anna", "Siim", "Toomas", "Liis", "Peeter" };
            Oppevorm[] vormid = (Oppevorm[])Enum.GetValues(typeof(Oppevorm));
            string[] koolid = { "TTHK", "Tallinna Polütehnikum", "Haapsalu Kutsehariduskeskus" };

            Console.WriteLine("\nGenereeritakse 5 juhuslikku õpilast...");
            var uued = new System.Collections.Generic.List<Isik>();

            for (int i = 0; i < 5; i++)
            {
                int aasta = rnd.Next(2000, 2009);
                double hinne = Math.Round(rnd.NextDouble() * 5, 1);
                int puudumised = rnd.Next(0, 60);
                bool sots = rnd.Next(0, 2) == 1;

                var op = new Opilane(
                    nimed[rnd.Next(nimed.Length)],
                    aasta,
                    koolid[rnd.Next(koolid.Length)],
                    rnd.Next(1, 13),
                    vormid[rnd.Next(vormid.Length)],
                    hinne,
                    puudumised
                );
                op.KasOnSotsTõend = sots;
                uued.Add(op);
            }

            kool.LisaInimene(uued);
            Console.WriteLine("Lisatud! Kasuta 'Kuva kõik' et näha nimekirja.");
        }

        //7: salvestus faili
        static void SalvestaFaili()
        {
            string failinimi = LoeString("\nSisesta failinimi (nt nimekiri.txt): ");
            kool.SalvestaFaili(failinimi);
        }

        //10: Kursus demo
        static void KuvaKursusDemo()
        {
            // Leiame esimese õpetaja nimekirjast
            Opetaja leitudOpetaja = null;
            foreach (var isik in kool.Inimesed)
            {
                if (isik is Opetaja op)
                {
                    leitudOpetaja = op;
                    break;
                }
            }

            if (leitudOpetaja == null)
            {
                Console.WriteLine("\nEi leitud ühtegi õpetajat. Lisa esmalt õpetaja.");
                return;
            }

            string kursusNimi = LoeString("\nKursuse nimi: ");
            Kursus kursus = new Kursus(kursusNimi, leitudOpetaja);
            Console.WriteLine();
            kursus.KuvaInfo();
        }
    }
}
