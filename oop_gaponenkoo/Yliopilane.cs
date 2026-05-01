namespace oop_gaponenkoo
{
    public class Yliopilane : Opilane
    {
        public string Eriala { get; set; }
        public string Kursus { get; set; }

        public Yliopilane() : base() { }

        public Yliopilane(string nimi, string kool, string kursus, Oppevorm staatus, string eriala)
            : base(nimi, kool, 0, staatus)
        {
            Kursus = kursus;
            Eriala = eriala;
        }

        public override string Kirjelda()
        {
            return $"Üliõpilane {Nimi} õpib {Kursus}. kursusel. Eriala: {Eriala}. Vorm: {Staatus}.";
        }
    }
}
