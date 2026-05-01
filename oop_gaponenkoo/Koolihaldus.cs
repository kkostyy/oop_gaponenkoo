using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace oop_gaponenkoo
{
    public class Koolihaldus
    {
        private List<Isik> inimesed = new List<Isik>();

        public void LisaInimene(Isik isik)
        {
            inimesed.Add(isik);
        }

        public void LisaInimene(List<Isik> uuedInimesed)
        {
            inimesed.AddRange(uuedInimesed);
            foreach (var isik in uuedInimesed)
                Console.WriteLine($"Lisati {isik.Nimi} uue inimene.");
        }

        public void KuvaKoik()
        {
            foreach (var isik in inimesed)
                Console.WriteLine(isik.Kirjelda());
        }

        public void Otsi(string otsitavNimi)
        {
            Console.WriteLine($"OTSINGU TULEMUSED (päring: {otsitavNimi})");
            bool leitud = false;
            foreach (var isik in inimesed)
            {
                if (isik.Nimi.Contains(otsitavNimi, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(isik.Kirjelda());
                    Console.WriteLine("--------");
                    leitud = true;
                }
            }
            if (!leitud) Console.WriteLine("Ei leitud mitte keegi.");
        }

        public void Otsi(int sünniaasta)
        {
            Console.WriteLine($"\nOtsime kedagi, kes on sündinud aastal: {sünniaasta}");
            bool leitud = false;
            foreach (var isik in inimesed)
            {
                if (isik.Sünniaasta == sünniaasta)
                {
                    Console.WriteLine(isik.Kirjelda());
                    Console.WriteLine("--------");
                    leitud = true;
                }
            }
            if (!leitud) Console.WriteLine("Ei leitud mitte keegi.");
        }

        public void KuvaAinultOpilased()
        {
            var opilased = inimesed.OfType<Opilane>().ToList();
            foreach (var isik in opilased)
                Console.WriteLine(isik.Kirjelda());
        }

        public void SalvestaFaili(string failinimi)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(failinimi, false, Encoding.UTF8))
                {
                    sw.WriteLine($"--- Kooli nimekiri (Salvestatud: {DateTime.Now}) ---");
                    foreach (var isik in inimesed)
                        sw.WriteLine(isik.Kirjelda());
                    sw.WriteLine($"Kokku: {inimesed.Count} isikut.");
                }
                Console.WriteLine($"Andmed on salvestatud faili: {failinimi}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Viga salvestamisel: {e.Message}");
            }
        }
    }
}
