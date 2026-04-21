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
                Console.WriteLine("6. Otsi nime jargi");
                Console.WriteLine("7. Otsi sunniaaasta jargi");
                Console.WriteLine("8. Kuva opetaja palk");
                Console.WriteLine("9. Opetaja hindab opilast");
                Console.WriteLine("10. Kuva kokku registreeritud isikuid");
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
                    case "6": OtsiNime(); break;
                    case "7": OtsiSunniaasta(); break;
                    case "8": KuvaPalk(); break;
                    case "9": HindaOpilast(); break;
                    case "10":
                        Console.WriteLine($"\nKokku registreeritud: {Isik.InimesteKoguarv} isikut.");
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
            int aasta = LoeInt("  Sünniaasta: ", 1900, DateTime.Now.Year);
            string koolNimi = LoeString("  Kooli nimi: ");
            int klass = LoeInt("  Klass (1-12): ", 1, 12);
            Oppevorm vorm = LoeOppevorm();

            double hinne = LoeDouble("  Keskmine hinne (0-5): ", 0);
            int puudumised = LoeInt("  Puudumiste arv: ", 0, 500);

            var op = new Opilane(nimi, aasta, koolNimi, klass, vorm, hinne, puudumised);
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
            kool.LisaInimene(yl);
        }

        static void OtsiNime()
        {
            string nimi = LoeString("\nOtsitav nimi: ");
            kool.Otsi(nimi);
        }

        static void OtsiSunniaasta()
        {
            int aasta = LoeInt("\nSisesta sunniaaasta: ", 1900, DateTime.Now.Year);
            kool.Otsi(aasta);
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
    }
}
