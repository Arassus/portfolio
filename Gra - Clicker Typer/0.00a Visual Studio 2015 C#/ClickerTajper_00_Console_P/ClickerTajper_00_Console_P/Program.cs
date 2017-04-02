using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClickerTajper_00_Console_P
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("UTWORZENIE FOREMKI(Rozgrywka)");
            Rozgrywka oRoz = new Rozgrywka();
            Console.WriteLine("STWORZONO FOREMKE(Rozgrywka)\n\n");

            Console.WriteLine("ODBLOKOWANIE STYLOW WIZUALNYCH\n\n");
            Application.EnableVisualStyles();                  

            Console.WriteLine("ODPALENIE FOREMKI\n\n");
            Application.Run(oRoz); Application.EnableVisualStyles();
        }
    }
}
