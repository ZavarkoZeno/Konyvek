using System;
using System.Collections.Generic;
using System.Text;

namespace Konyvek
{
    public class Konyv
    {
        public string Cim { get; set; }
        public string Szerzo { get; set; }
        public int Oldalszam { get; set; }
        public string Mufaj { get; set; }
        public bool Elerheto { get; set; }

        public Konyv(string cim, string szerzo, int oldalszam, string mufaj, bool elerheto)
        {
            Cim = cim;
            Szerzo = szerzo;
            Oldalszam = oldalszam;
            Mufaj = mufaj;
            Elerheto = elerheto;
        }

        public class KonyvCim
        {
            public string Cim { get; set; }
            public KonyvCim(string cim)
            {
                Cim = cim;
            }
        }
    }
}
