using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Build_00a_VS15.Klasy
{
    class EI
    {

        public bool jednokierunkowy;
        public int V1_ID, V2_ID;
        public int Dlugosc;



        public EI(int v1, int v2, bool CzyJednokierunkowy, int dlugosc)
        {
            V1_ID = v1;
            V2_ID = v2;

            jednokierunkowy = CzyJednokierunkowy;

            Dlugosc = dlugosc;
        }
    }
}
