using System;

namespace oop_gaponenkoo
{
    public class Kursus
    {
        public string Nimi { get; set; }
        public Opetaja VastutavOpetaja { get; set; }

        public Kursus(string nimi, Opetaja vastutavOpetaja)
        {
            Nimi = nimi;
            VastutavOpetaja = vastutavOpetaja;
        }

        public void KuvaInfo()
        {
            Console.WriteLine($"Kursus: {Nimi}");
            if (VastutavOpetaja != null)
                Console.WriteLine($"Vastutav õpetaja: {VastutavOpetaja.Nimi}");
        }
    }
}
