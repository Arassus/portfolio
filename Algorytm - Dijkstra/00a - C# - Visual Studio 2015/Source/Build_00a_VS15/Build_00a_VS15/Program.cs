using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using Build_00a_VS15.Klasy;

namespace Build_00a_VS15
{
    class Program
    {
        static void Main(string[] args)
        {
            Okno _okno = new Okno();

            Application.Run(_okno);
            Application.EnableVisualStyles();
        }
    }
}
