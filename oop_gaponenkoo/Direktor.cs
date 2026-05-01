namespace oop_gaponenkoo
{
    public class Direktor : Opetaja
    {
        public double Lisatasu { get; set; }

        public Direktor() : base() { }

        public Direktor(string nimi, string aine, double tunnitasu, int tunnidKuus, double lisatasu)
            : base(nimi, aine, tunnitasu, tunnidKuus)
        {
            Lisatasu = lisatasu;
        }

        public override string Kirjelda()
        {
            return $"Mina olen direktor {Nimi}. Vanus: {Vanus}.";
        }

        public override double ArvutaPalk()
        {
            return base.ArvutaPalk() + Lisatasu;
        }
    }
}
