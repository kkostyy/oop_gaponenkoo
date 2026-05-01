namespace oop_gaponenkoo
{
    public class Opilane : Isik, ITooline
    {
        public string Kool { get; set; }
        public int Klass { get; set; }
        public Oppevorm Staatus { get; set; } = Oppevorm.Paevane;
        public double KeskmineHinne { get; set; }
        public int Puudumised { get; set; } = 0;
        public bool KasOnSotsTõend { get; set; } = false;
        public ValjamakseTyyp ValjamakseTyyp { get; set; } = ValjamakseTyyp.Toetus;

        public Opilane() : base() { }

        public Opilane(string nimi, string kool, int klass, Oppevorm staatus) : base(nimi)
        {
            Kool = kool;
            Klass = klass;
            Staatus = staatus;
        }

        public override string Kirjelda()
        {
            return $"{Nimi} õpib {Klass}. klassis. Vorm: {Staatus}. Kool: {Kool}.";
        }

        public void Opi()
        {
            System.Console.WriteLine($"{Nimi} õpib {Kool} {Klass}. klassis.");
        }

        public double ArvutaPalk()
        {
            double pohitoetus = (KeskmineHinne >= 3.8 && Puudumised < 30) ? 60.0 : 0;
            double eritoetus = KasOnSotsTõend ? 120.0 : 0;
            return pohitoetus + eritoetus;
        }
    }
}
