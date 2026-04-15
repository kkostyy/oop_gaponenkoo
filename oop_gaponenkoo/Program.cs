namespace oop_gaponenkoo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== KOOLIHALDUSE SUSTEEM ===\n");

            Opetaja opetaja1 = new Opetaja("Marina", 1995, "Programmeerimine", 15.0, 20);
            Opetaja opetaja2 = new Opetaja("Jaan", 1980, "Matemaatika", 12.0, 25);
            Direktor direktor1 = new Direktor("Peeter", 1970, "Ajalugu", 18.0, 10, 500.0);
            Opilane opilane1 = new Opilane("Yaroslav", 2008, "TTHK", 1, Oppevorm.Paevane);
            Opilane opilane2 = new Opilane("Mari", 2007, "TTHK", 2, Oppevorm.Kaugope);
            Yliopilane yliopilane1 = new Yliopilane("Andrei", 2003, "TalTech", 3, Oppevorm.Paevane, "Tarkvaraarendus");

            Console.WriteLine("-- Kirjelda() meetod --");
            opetaja1.Kirjelda();
            opetaja2.Kirjelda();
            direktor1.Kirjelda();
            opilane1.Kirjelda();
            opilane2.Kirjelda();
            yliopilane1.Kirjelda();

            Console.WriteLine("\n-- Tervita() meetod --");
            opetaja1.Tervita();
            opilane1.Tervita();

            Console.WriteLine("\n-- Palgad --");
            Console.WriteLine($"{opetaja1.Nimi} palk: {opetaja1.ArvutaPalk()} eurot");
            Console.WriteLine($"{direktor1.Nimi} palk (koos lisatasuga): {direktor1.ArvutaPalk()} eurot");

            Console.WriteLine("\n-- Hindamine --");
            opetaja1.Hinda("5");
            opetaja2.Hinda("3");

            Console.WriteLine($"\nKokku loodi {Isik.InimesteKoguarv} isikut susteemis.");

            Console.WriteLine("\n-- Koolihaldus --");
            Koolihaldus minuKool = new Koolihaldus();

            minuKool.LisaInimene(opetaja1);
            minuKool.LisaInimene(direktor1);
            minuKool.LisaInimene(opilane1);
            minuKool.LisaInimene(opilane2);
            minuKool.LisaInimene(yliopilane1);

            List<Isik> lisaNimekiri = new List<Isik> { opetaja2 };
            minuKool.LisaInimene(lisaNimekiri);

            minuKool.KuvaKoik();

            Console.WriteLine("\n-- Otsing --");
            minuKool.Otsi("Mari");
            minuKool.Otsi(2008);
        }
    }
}
