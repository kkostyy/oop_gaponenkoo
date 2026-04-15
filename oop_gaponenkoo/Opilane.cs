using System;
using System.Collections.Generic;
using System.Text;

namespace oop_gaponenkoo
{
    public class Opilane : Isik
    {
        public string Kool { get; set; }
        public int Klass { get; set; }
        public Oppevorm Staatus { get; set; }

        public Opilane(string nimi, int aasta, string kool, int klass, Oppevorm staatus) : base(nimi, aasta)
        {
            Kool = kool;
            Klass = klass;
            Staatus = staatus;
        }

        public override void Kirjelda()
        {
            Console.WriteLine($"Mina olen opilane {Nimi}, käin {Kool} {Klass}. klassis. Vorm: {Staatus}. Vanus: {Vanus}");
        }

        public void Opi()
        {
            Console.WriteLine($"{Nimi} opib {Kool} {Klass}. klassis.");
        }
    }

    public class Yliopilane : Opilane
    {
        public string Eriala { get; set; }

        public Yliopilane(string nimi, int aasta, string kool, int klass, Oppevorm staatus, string eriala)
            : base(nimi, aasta, kool, klass, staatus)
        {
            Eriala = eriala;
        }

        public override void Kirjelda()
        {
            Console.WriteLine($"Mina olen üliõpilane {Nimi}, {Klass}. kursusel. Eriala: {Eriala}. Vorm: {Staatus}. Vanus: {Vanus}");
        }
    }
}
