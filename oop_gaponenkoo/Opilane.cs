using System;

namespace oop_gaponenkoo
{
    public class Opilane : Isik, ITooline
    {
        public string Kool { get; set; }
        public int Klass { get; set; }
        public Oppevorm Staatus { get; set; }
        public double KeskmineHinne { get; set; }
        public int Puudumised { get; set; }

        // Õpetaja lahendusest: sotsiaalne tõend annab lisatoetust
        public bool KasOnSotsTõend { get; set; } = false;

        // ITooline: õpilase puhul on väljamakse tüüp alati Toetus
        public ValjamakseTyyp ValjamakseTyyp { get; set; } = ValjamakseTyyp.Toetus;

        public Opilane(string nimi, int aasta, string kool, int klass, Oppevorm staatus, double hinne, int puudumised)
            : base(nimi, aasta)
        {
            Kool = kool;
            Klass = klass;
            Staatus = staatus;
            KeskmineHinne = hinne;
            Puudumised = puudumised;
        }

        // ITooline liidese meetod: põhitoetus 60€ (hinne >= 3.8 ja puudumised <= 30)
        // + eritoetus 120€ sotstõendi korral (õpetaja lahendusest)
        public double ArvutaPalk()
        {
            double pohitoetus = (KeskmineHinne >= 3.8 && Puudumised <= 30) ? 60.0 : 0;
            double eritoetus = KasOnSotsTõend ? 120.0 : 0;
            return pohitoetus + eritoetus;
        }

        // Säilitame ka vana nime mugavuse jaoks
        public double ArvutaToetus() => ArvutaPalk();

        public override void Kirjelda()
        {
            Console.WriteLine($"Mina olen õpilane {Nimi}, käin {Kool} {Klass}. klassis.");
            Console.WriteLine($"  Hinne: {KeskmineHinne}, Puudumised: {Puudumised}, SotsTõend: {KasOnSotsTõend}. Toetus: {ArvutaPalk()} EUR");
        }
    }

    public class Yliopilane : Opilane
    {
        public string Eriala { get; set; }

        public Yliopilane(string nimi, int aasta, string kool, int klass, Oppevorm staatus, string eriala, double hinne, int puudumised)
            : base(nimi, aasta, kool, klass, staatus, hinne, puudumised)
        {
            Eriala = eriala;
        }

        public override void Kirjelda()
        {
            Console.WriteLine($"Mina olen üliõpilane {Nimi}, eriala: {Eriala}.");
            Console.WriteLine($"  Hinne: {KeskmineHinne}, Puudumised: {Puudumised}, SotsTõend: {KasOnSotsTõend}. Toetus: {ArvutaPalk()} EUR");
        }
    }
}
