using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;

namespace Source_P.Klasy
{
    class Czas : Timer
    {
        //public Timer oT = new Timer();

        public Label Zegar_Label = new Label();

        public Button Button_1 = new Button();
        public Button Button_3600 = new Button();
        public Button Button_86400 = new Button();
        public Button Button_2595000 = new Button();

        public delegate void MinalDzien();
        public MinalDzien MD;

        private int imSek = DateTime.Now.Millisecond, iSek = DateTime.Now.Second, iMin = DateTime.Now.Minute, iGod = DateTime.Now.Hour, iDzi = DateTime.Now.Day, iMie = DateTime.Now.Month, iRok = DateTime.Now.Year;
        public int MineloDni = 0, MilisekundNaTick = 1, OpoznienieTicku = 1;

        public Czas(Color CzcionkaGlowna)
        {

            DomyslnyLabel(Zegar_Label, "", new Point(710, 10), new Size(150, 65));
            Zegar_Label.Font = new Font("MV Boli", 14f, FontStyle.Bold);
            Zegar_Label.ForeColor =CzcionkaGlowna;
            DomyslnyZegar();
              
            DomyslnaRegulacja();
        }
        ~Czas()
        {
            ;
        }
        private void DomyslnaRegulacja()
        {
            DomyslnyButton(ref Button_1, new Point(700, 80), new Size(50, 50), "Szybkosc1");
            DomyslnyButton(ref Button_3600, new Point(725, 80), new Size(50, 50), "Szybkosc2");
            DomyslnyButton(ref Button_86400, new Point(750, 80), new Size(50, 50), "Szybkosc3");
            DomyslnyButton(ref Button_2595000, new Point(775, 80), new Size(50, 50), "Szybkosc4");
        }
        private void DomyslnyButton(ref Button C, Point Lokalizacja, Size Rozmiar, string NazwaObrazka)
        {
            C.Location = Lokalizacja;
            C.Size = Rozmiar;

            if (NazwaObrazka != "")
            {
                C.BackgroundImage = Image.FromFile("Obrazki/" + NazwaObrazka + ".png");
            }
        }
        public void PrzeliczCzas()
        {
            imSek += MilisekundNaTick;

            while (imSek > 59)
            {
                imSek -= 60;
                iSek += 1;
                if (iSek > 59)
                {
                    iSek -= 60;
                    iMin += 1;
                    if (iMin > 59)
                    {
                        iMin -= 60;
                        iGod += 1;
                        if (iGod > 23)
                        {
                            iGod -= 24;
                            iDzi += 1;
                            MineloDni += 1;
                            //MD();     
                            if (MD != null)
                            {
                                MD();
                            }
                            Random r = new Random();
                            Console.Beep(r.Next(150, 600), 100);
                            //Console.Beep(200, 20);
                            if (CzyMoznaDodacMies())
                            {
                                iDzi -= iDzi - 1;
                                iMie += 1;
                                if (iMie > 12)
                                {
                                    iMie -= iMie - 1;
                                    iRok += 1;
                                }
                            }
                        }
                    }
                }
            }
        }
        public void WypiszDate()
        {
            Zegar_Label.Text = imSek.ToString("D2") + ":" + iSek.ToString("D2") + ":" + iMin.ToString("D2") + ":" + iGod.ToString("D2") + '\n' + iRok.ToString("D2") + ":" + iMie.ToString("D2") + ":" + iDzi.ToString("D2") + '\n' + '\n' + "Dzien : " + MineloDni.ToString() + '\n' + "ms * " + MilisekundNaTick;
        }
        private bool CzyMoznaDodacMies()
        {
            bool bZwracany = false;

            switch (iDzi)
            {
                case 29:
                    {
                        if (iRok % 4 != 0 && iMie == 2)
                        {
                            bZwracany = true;
                        }
                        break;
                    }
                case 30:
                    {
                        if (iMie == 2)
                        {
                            bZwracany = true;
                        }
                        break;
                    }
                case 31:
                    {
                        if (iMie == 4 || iMie == 6 || iMie == 9 || iMie == 11)
                        {
                            bZwracany = true;
                        }
                        break;
                    }
                case 32:
                    {
                        bZwracany = true;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            return bZwracany;
        }
        private void DomyslnyLabel(Label oLa, string Txt, Point Lokalizacja, Size Rozmiar)
        {
            oLa.Text = Txt;
            oLa.Location = Lokalizacja;
            oLa.Size = Rozmiar;
            oLa.BackColor = Color.Transparent;
        }
        private void DomyslnyZegar()
        {
            Interval = OpoznienieTicku;
            Start();
        }       
        public void Zegar_Tick(object sender, EventArgs e)
        {
            PrzeliczCzas();
            WypiszDate();
        }
        public void Btn1_Click(object sender, EventArgs e)
        {
            MilisekundNaTick = 1;
        }
        public void Btn3600_Click(object sender, EventArgs e)
        {
            MilisekundNaTick = 3600;
        }
        public void Btn86400_Click(object sender, EventArgs e)
        {
            MilisekundNaTick = 86400;
        }
        public void Btn2595000_Click(object sender, EventArgs e)
        {
            MilisekundNaTick = 2595000;
        }
    }
}
