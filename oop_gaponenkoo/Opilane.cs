using System;

namespace oop_gaponenkoo
{
    public class Opilane : Isik
    {
        public string Kool { get; set; }
        public int Klass { get; set; }
        public Oppevorm Staatus { get; set; }
        public double KeskmineHinne { get; set; }
        public int Puudumised { get; set; }

        public Opilane(string nimi, int aasta, string kool, int klass, Oppevorm staatus, double hinne, int puudumised)
            : base(nimi, aasta)
        {
            Kool = kool;
            Klass = klass;
            Staatus = staatus;
            KeskmineHinne = hinne;
            Puudumised = puudumised;
        }

        public double ArvutaToetus()
        {
            if (Puudumised > 30 && KeskmineHinne < 3.7)
            {
                return 0;
            }
            return 60.0;
        }

        public override void Kirjelda()
        {
            Console.WriteLine($"Mina olen õpilane {Nimi}, käin {Kool} {Klass}. klassis.");
            Console.WriteLine($"  Hinne: {KeskmineHinne}, Puudumised: {Puudumised}. Toetus: {ArvutaToetus()} EUR");
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
            Console.WriteLine($"  Hinne: {KeskmineHinne}, Puudumised: {Puudumised}. Toetus: {ArvutaToetus()} EUR");
        }
    }
}