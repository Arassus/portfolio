using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ClickerTajper_00_Console_P
{
    class Baza
    {
        private string[] Slownik = File.ReadAllLines("Tekst/slowa.txt");
        private string[] Nazwiska = File.ReadAllLines("Tekst/nazwiska.txt");
        private string[] Imiona = File.ReadAllLines("Tekst/imiona.txt");

        public string WylosujWyraz(string Co)
        {
            Random R = new Random();
            int ID;

            string Zwracany;

            switch (Co)
            {
                case "slowo":
                    {
                        ID = R.Next(0, 2734052);
                        Zwracany = Slownik[ID];                             
                        break;
                    }
                case "nazwisko":
                    {
                        ID = R.Next(0, 399531);
                        Zwracany = Nazwiska[ID];                              
                        break;
                    }
                case "imie":
                    {
                        ID = R.Next(0, 1203);
                        Zwracany = Imiona[ID];                              
                        //Zwracany = Imiona[R.Next(0, 1203)];
                        break;
                    }
                default:
                    {
                        Zwracany = "ERROR";
                        break;
                    }
            }

            return Zwracany;
        }
    }
}
