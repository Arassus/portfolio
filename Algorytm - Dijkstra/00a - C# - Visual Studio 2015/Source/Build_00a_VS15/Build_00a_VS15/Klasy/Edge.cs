using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Build_00a_VS15.Klasy
{
    class Edge
    {
        public bool jednokierunkowy;
        public Vert V1, V2;
        public int Dlugosc;


                                               
        public Edge(Vert v1, Vert v2, bool CzyJednokierunkowy, int dlugosc)
        {
            V1 = v1;
            V2 = v2;

            jednokierunkowy = CzyJednokierunkowy;

            Dlugosc = dlugosc;
        }
    }
}
