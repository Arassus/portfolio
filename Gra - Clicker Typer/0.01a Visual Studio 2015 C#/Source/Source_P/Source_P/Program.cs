using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using Source_P.Klasy;

namespace Source_P
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("POCZATEK PROGRAMU");

            Console.WriteLine("Utworzenie ustawien");
            Settings oS = new Settings();
            Application.Run(oS);
            Application.EnableVisualStyles();

            Console.WriteLine("Utworzenie okna glownego");
            Okno oO = new Okno(oS.Resolution_CoB.SelectedIndex,oS.Fullscreen_CB.Checked, oS.Background_CoB.SelectedIndex);
            oS.Dispose();

            Application.Run(oO);
            Application.EnableVisualStyles();


            Console.WriteLine("KONIEC PROGRAMU");
            Console.ReadKey();
        }
    }
}
