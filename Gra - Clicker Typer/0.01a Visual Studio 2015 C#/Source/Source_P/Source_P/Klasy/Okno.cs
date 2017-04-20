using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Text;
using System.IO;

namespace Source_P.Klasy
{
    class Okno : Form
    {
        char PoziomTrudnosci = '1';

        private int Opinia = 10;
        private int Budzet = 0;
        private int Mnoznik_NormaPlus = 2;
        private int Mnoznik_NormaMinus = 1;

        private int IleZrobionoMinigier = 1;
        private int RogFormatki = 20;
        private int Kolor = 0;
        private Color[] TColors = new Color[8];     //main, second, tlo, czcionka1, czcionka2, itemback+, itemback-, itemback/
        private string[] Kolumny_Proj = new string[] { "Nazwa", "Wynagrodzenie", "Deadline", "Norma", "Opinia" }, Kolumny_Prac = new string[] { "Nazwisko", "Imię", "Wynagrodzenie", "Norma"};

        Label Stat = new Label();
        Font oF = new Font(new FontFamily("Calibri"), 14, GraphicsUnit.Pixel);

        FixedTabControl Rynek_oTB = new FixedTabControl();
        FixedTabControl Zasoby_oTB = new FixedTabControl();
        FixedTabControl Statys_oTB = new FixedTabControl();
        FixedTabControl Minigry_oTB = new FixedTabControl();

        Projekty Rynek_oPR, Zasoby_oPR;

        Minigra oMG;

        Szczegoly oS;

        Czas oC;
                                 
        Pracownicy Zasoby_oPracow,Rynek_oPracow;

        ClickerTajper_00_Console_P.Baza oBaza = new ClickerTajper_00_Console_P.Baza();

        public delegate void ZainicjalizujOkno(Form F);
        //ZainicjalizujOkno StworzKontrolki;
        public delegate void Dopasuj(Form F, int GruboscRamki);
        //Dopasuj DopasujKontrolki;                                       

        private delegate void DelTemp(Size S, FontFamily F);
        DelTemp DT;

        private delegate void this_MinalDzien();
        this_MinalDzien tMD;



                                  


        public Okno()
        {
            Inicjalizacja(0);
        }
        public Okno(int X, int Y)
        {
            Inicjalizacja(Settings.ResolutionToID(X.ToString() + "x" + Y.ToString()));
            this.Size = new System.Drawing.Size(X, Y);
        }
        public Okno(System.Drawing.Size Rozmiar)
        {
            Inicjalizacja(Settings.ResolutionToID(Rozmiar.Width.ToString() + "x" + Rozmiar.Height.ToString()));
            this.Size = Rozmiar;
        }
        public Okno(int IDRezolucji, bool CzyFullscreen, int IDColor)
        {
            Console.WriteLine("Konstruktor okna //");
            this.Size = new Size(10, 10);
            Kolor = IDColor;
            Inicjalizacja(IDRezolucji);

            if (CzyFullscreen)
            {
                FormBorderStyle = FormBorderStyle.None;
                //WindowState = FormWindowState.Maximized;
            }
            Console.WriteLine("// Koniec konstrukcji okna");

            Ustawienia_PoziomTrudnosci();
        }
        ~Okno()
        { }

        private void Inicjalizacja(int ResolutionID)
        {
            oS = null;

            Init_TablicaKolorow();
            Init_Czas();
            Init_Form(ResolutionID);
            Init_Rynek();
            Init_Zasoby();
            Init_Minigra();
            Init_Statys();       
            AddjustControlSizeAndLocation();    
            oC.Tick += new EventHandler(Update);        
            Stat.Font = oF;
            Stat.ForeColor = TColors[3];
            Stat.Size = new Size(250, 200);
            Stat.Font = new Font(new FontFamily("MV Boli"), (this.Height - 5 * RogFormatki) / 30, GraphicsUnit.Pixel);
            Controls.Add(Stat);

        }
        private void Init_Czas()
        {
            oC = new Czas(TColors[3]);
            Controls.Add(oC.Zegar_Label);
            Controls.Add(oC.Button_1);
            Controls.Add(oC.Button_3600);
            Controls.Add(oC.Button_86400);
            Controls.Add(oC.Button_2595000);
            oC.Tick += new EventHandler(oC.Zegar_Tick);
            oC.Tick += new EventHandler(OdswiezDzien_CzasProjekt);
            oC.Tick += new EventHandler(OdswiezDzien_CzasPracownik);
            oC.Button_1.Click += new EventHandler(oC.Btn1_Click);
            oC.Button_3600.Click += new EventHandler(oC.Btn3600_Click);
            oC.Button_86400.Click += new EventHandler(oC.Btn86400_Click);
            oC.Button_2595000.Click += new EventHandler(oC.Btn2595000_Click);
            oC.MD = MinalDzien;
        }
        private void Init_TablicaKolorow()
        {
            TColors[0] = IDToColor(Kolor, "main");
            TColors[1] = IDToColor(Kolor, "secondary");
            TColors[2] = IDToColor(Kolor, "tlo");
            TColors[3] = IDToColor(Kolor, "font1");
            TColors[4] = IDToColor(Kolor, "font2");
            TColors[5] = IDToColor(Kolor, "itemback+");
            TColors[6] = IDToColor(Kolor, "itemback-");
            TColors[7] = IDToColor(Kolor, "itemback/");
        }
        private void Init_Form(int ResolutionID)
        {
            this.ClientSizeChanged += new EventHandler(ZmienionoRozmiar);

            this.SuspendLayout();

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "Okno";
            this.Text = "Okno";
            this.Load += new System.EventHandler(this.Okno_Load);
            this.ResumeLayout(false);
            this.ClientSize = IDToResolution(ResolutionID);

            this.BackColor = IDToColor(Kolor, "tlo");
        }
        private void Init_Rynek()
        {
            Rynek_oTB.Font = oF;
            Rynek_oTB.SelectedIndexChanged += new EventHandler(ZaznaczonoTabPage_Rynek);

            Rynek_oTB.SizeMode = TabSizeMode.Fixed;
            Controls.Add(Rynek_oTB);

            Rynek_oTB.TabPages.Add("Projekty");
            Rynek_oTB.TabPages[0].BackColor = TColors[0];
            Rynek_oTB.TabPages[0].ForeColor = TColors[3];
            Rynek_oTB.TabPages.Add("Pracownicy");
            Rynek_oTB.TabPages[1].BackColor = TColors[1];
            Rynek_oTB.TabPages[1].ForeColor = TColors[3];

            Rynek_oPR = new Projekty(new int[] { 0, 0, 200, 200 }, new Color[] { TColors[1], TColors[3], TColors[4] }, Kolumny_Proj);
            Rynek_oPR.dWylosujWyraz = oBaza.WylosujWyraz;
            Rynek_oPR.ItemSelectionChanged += new ListViewItemSelectionChangedEventHandler(SworzSzczegoly_Projekty);
            Rynek_oPR.View = View.LargeIcon;

            Rynek_oTB.TabPages[0].Controls.Add(Rynek_oPR);



            Rynek_oPracow = new Pracownicy(new int[] { 0, 0, 200, 200 }, new Color[] { TColors[1], TColors[3], TColors[4] }, Kolumny_Prac);   
            Rynek_oPracow.dWylosujWyraz = oBaza.WylosujWyraz;
            Rynek_oPracow.ItemSelectionChanged += new ListViewItemSelectionChangedEventHandler(SworzSzczegoly_Pracownicy);
            Rynek_oTB.TabPages[1].Controls.Add(Rynek_oPracow);
            Rynek_oPracow.View = View.Details;
        }
        private void Init_Minigra()
        {
            Controls.Add(Minigry_oTB);
            Minigry_oTB.SelectedIndexChanged += new EventHandler(ZaznaczonoTabPage_MiniGra);
        }
        private void Init_Zasoby()
        {

            Zasoby_oTB.Font = oF;
            Zasoby_oTB.SelectedIndexChanged += new EventHandler(ZaznaczonoTabPage_Zasoby);

            Zasoby_oTB.TabPages.Add("Przyjęte Projekty");
            Zasoby_oTB.TabPages[0].BackColor = TColors[0];
            Zasoby_oTB.TabPages[0].ForeColor = TColors[3];
            Zasoby_oTB.TabPages.Add("Zatrudnieni Pracownicy");
            Zasoby_oTB.TabPages[1].BackColor = TColors[1];
            Zasoby_oTB.TabPages[1].ForeColor = TColors[3];


            Controls.Add(Zasoby_oTB);


            Zasoby_oPR = new Projekty(new int[] { 0, 0, 200, 200 }, new Color[] { TColors[1], TColors[3], TColors[4] }, Kolumny_Proj);
            Zasoby_oPR.ItemSelectionChanged += new ListViewItemSelectionChangedEventHandler
                (StworzMiniGre);
            Zasoby_oPR.View = View.Details;

            Zasoby_oTB.TabPages[0].Controls.Add(Zasoby_oPR);



            Zasoby_oPracow = new Pracownicy(new int[] { 0, 0, 200, 200 }, new Color[] { TColors[1], TColors[3], TColors[4] }, Kolumny_Prac);
            Zasoby_oPracow.dWylosujWyraz = oBaza.WylosujWyraz;
            Zasoby_oPracow.ItemSelectionChanged += new ListViewItemSelectionChangedEventHandler(SworzSzczegoly_Pracownicy_Zasoby);
            Zasoby_oPracow.View = View.LargeIcon;

            Zasoby_oPracow.Columns.Add("Pracuje nad");

            Zasoby_oTB.TabPages[1].Controls.Add(Zasoby_oPracow);

            //Zasoby_oPracow.View = View.Details;                        
        }
        private void Init_Statys()
        {

            Statys_oTB.Font = oF;                             

            Controls.Add(Statys_oTB);
        }
        private void Okno_Load(object sender, EventArgs e)
        {
        }

        public void ResizeWindow(System.Drawing.Size NowyRozmiar)
        {
            this.Size = NowyRozmiar;
        }

        public static System.Drawing.Size IDToResolution(int ID)
        {
            System.Drawing.Size Zwracany;
            switch (ID)
            {
                case 0:
                    {
                        Zwracany = new System.Drawing.Size(800, 600);
                        break;
                    }
                case 1:
                    {
                        Zwracany = new System.Drawing.Size(1280, 720);
                        break;
                    }
                case 2:
                    {
                        Zwracany = new System.Drawing.Size(1920, 1080);
                        break;
                    }
                default:
                    {
                        Zwracany = new System.Drawing.Size(800, 600);
                        break;
                    }
            }
            return Zwracany;
        }
        public Color PorownajPokoloruj(int Zasob, int Cena)
        {
            Color Zwracany = Color.AliceBlue;
            if (Zasob > Cena)
            {
                Zwracany = TColors[5];
            }
            if (Zasob < Cena)
            {
                Zwracany = TColors[6];
            }
            if (Zasob == Cena)
            {
                Zwracany = TColors[7];
            }
            return Zwracany;
        }
        public static Color IDToColor(int ID, string Kontrolka)    //0. Jasne; 1. Ciemne
        {
            Color Zwracany = Color.Red;
            switch (Kontrolka)
            {
                case "main":
                    {
                        switch (ID)
                        {
                            case 0:
                                {
                                    Zwracany = Color.LightGray;
                                    break;
                                }
                            case 1:
                                {
                                    Zwracany = Color.Black;
                                    break;
                                }
                            default:
                                {
                                    break;
                                }

                        }
                        break;
                    }
                case "secondary":
                    {
                        switch (ID)
                        {
                            case 0:
                                {
                                    Zwracany = Color.Gray;
                                    break;
                                }
                            case 1:
                                {
                                    Zwracany = Color.Black;
                                    //Zwracany = Color.FromArgb(100, 50, 50, 50);
                                    break;
                                }
                            default:
                                {
                                    break;
                                }

                        }
                        break;
                    }
                case "tlo":
                    {
                        switch (ID)
                        {
                            case 0:
                                {
                                    Zwracany = Color.LightSlateGray;
                                    break;
                                }
                            case 1:
                                {
                                    Zwracany = Color.DarkSlateGray;
                                    break;
                                }
                            default:
                                {
                                    break;
                                }

                        }
                        break;
                    }
                case "font1":
                    {
                        switch (ID)
                        {
                            case 0:
                                {
                                    Zwracany = Color.Black;
                                    break;
                                }
                            case 1:
                                {
                                    Zwracany = Color.White;
                                    break;
                                }
                            default:
                                {
                                    break;
                                }

                        }
                        break;
                    }
                case "font2":
                    {
                        switch (ID)
                        {
                            case 0:
                                {
                                    Zwracany = Color.Yellow;
                                    break;
                                }
                            case 1:
                                {
                                    Zwracany = Color.Green;
                                    break;
                                }
                            default:
                                {
                                    break;
                                }

                        }
                        break;
                    }
                case "itemback+":
                    {
                        switch (ID)
                        {
                            case 0:
                                {
                                    Zwracany = Color.Green;
                                    break;
                                }
                            case 1:
                                {
                                    Zwracany = Color.LightGreen;
                                    break;
                                }
                            default:
                                {
                                    break;
                                }

                        }
                        break;
                    }
                case "itemback-":
                    {
                        switch (ID)
                        {
                            case 0:
                                {
                                    Zwracany = Color.DarkRed;
                                    break;
                                }
                            case 1:
                                {
                                    Zwracany = Color.IndianRed;
                                    break;
                                }
                            default:
                                {
                                    break;
                                }

                        }
                        break;
                    }
                case "itemback/":
                    {
                        switch (ID)
                        {
                            case 0:
                                {
                                    Zwracany = Color.Gold;
                                    break;
                                }
                            case 1:
                                {
                                    Zwracany = Color.Yellow;
                                    break;
                                }
                            default:
                                {
                                    break;
                                }

                        }
                        break;
                    }
                default:
                    {

                        break;
                    }
            }
            return Zwracany;
        }
        /// <summary>
        /// Metoda Wykonywana podczas zmiany rozmiaru okna
        /// </summary>                          
        public void ZmienionoRozmiar(object sender, EventArgs e)
        {
            AddjustControlSizeAndLocation();
        }
        /// <summary>
        /// Dopasowuje rozmiar i lokalizacje wszystkich kontrolek
        /// </summary>                        
        private void AddjustControlSizeAndLocation()
        {
            int Width_1l2 = this.Width / 2 - RogFormatki;
            int Height_1l2 = (this.Height - 5 * RogFormatki) / 2;


            Dopasuj_Zasoby(Width_1l2, Height_1l2);
            Dopasuj_Rynek(Height_1l2);
            Dopasuj_MiniGry(Width_1l2);
            Dopasuj_Stat(Width_1l2, Height_1l2);
            Dopasuj_Czas();                         
        }     
        /// <summary>
        /// Dopasowuje okno przyjetych projektow na podstawie rozmiaru glownego okna
        /// </summary>
        /// <param name="Width_1l2"></param>
        /// <param name="Height_1l2"></param>
        private void Dopasuj_Zasoby(int Width_1l2, int Height_1l2)
        {
            Zasoby_oTB.Location = new System.Drawing.Point(RogFormatki, RogFormatki);
            Zasoby_oTB.Size = new System.Drawing.Size(Width_1l2 - RogFormatki / 2, Height_1l2 - RogFormatki / 2);
            Zasoby_oTB.ItemSize = new Size(Width_1l2 / 5, Height_1l2 / 5);
            Zasoby_oTB.Font = new Font(oF.FontFamily, Height_1l2 / 18, GraphicsUnit.Pixel);

            if (Zasoby_oPR != null && Zasoby_oTB.Width != 0)
            {
                Zasoby_oPR.DopasujRozmiarDoOkna(Zasoby_oTB.Size);
            }
            if (Zasoby_oPracow != null && Zasoby_oPracow.Width != 0)
            {
                Zasoby_oPracow.DopasujRozmiarDoOkna(Zasoby_oTB.Size);
            }
        }
        /// <summary>
        /// Dopasowuje okno rynku na podstawie rozmiaru glownego okna
        /// </summary>
        /// <param name="Height_1l2"></param>
        private void Dopasuj_Rynek(int Height_1l2)
        {
            Rynek_oTB.Location = new System.Drawing.Point(RogFormatki, Height_1l2 + RogFormatki);
            Rynek_oTB.Size = Zasoby_oTB.Size;
            Rynek_oTB.ItemSize = Zasoby_oTB.ItemSize;
            Rynek_oTB.Font = new Font(oF.FontFamily, Height_1l2 / 18, GraphicsUnit.Pixel);

            if (Rynek_oPR != null && Rynek_oTB.Width != 0)
            {
                Rynek_oPR.DopasujRozmiarDoOkna(Rynek_oTB.Size);
            }
            if (Rynek_oPracow != null && Rynek_oPracow.Width != 0)
            {
                Rynek_oPracow.DopasujRozmiarDoOkna(Rynek_oTB.Size);
            }
        }
        /// <summary>
        /// Dopasowuje okna Minigier na podstawie rozmiaru glownego okna
        /// </summary>
        /// <param name="Width_1l2"></param>
        private void Dopasuj_MiniGry(int Width_1l2)
        {
            Minigry_oTB.Location = new System.Drawing.Point(RogFormatki + Width_1l2, RogFormatki);
            Minigry_oTB.Size = Zasoby_oTB.Size;

            if (oMG != null)
            {
                oMG.DopasujKontrolki(Size);
            }
        }
        /// <summary>
        /// Dopasowuje okno statystyk na podstawie rozmiaru glownego okna
        /// </summary>
        /// <param name="Width_1l2"></param>
        /// <param name="Height_1l2"></param>
        private void Dopasuj_Stat(int Width_1l2, int Height_1l2)
        {
            Statys_oTB.Location = new System.Drawing.Point(RogFormatki + Width_1l2, Height_1l2 + RogFormatki);
            Statys_oTB.Size = Zasoby_oTB.Size;

            Stat.Font = new Font(new FontFamily("MV Boli"), Height_1l2 / 15, GraphicsUnit.Pixel);
            Stat.Location = new Point(oC.Button_2595000.Left + 100, oC.Zegar_Label.Top);

            if (DT != null)
            {
                DT(Size, oF.FontFamily);
            }
        }
        /// <summary>
        /// Dopasowuje Wszystkie Kontrolki Zwiazane z Czasem
        /// </summary>
        private void Dopasuj_Czas()
        {
            oC.Zegar_Label.Location = new Point(RogFormatki, this.Height - 90);
            oC.Button_1.Location = new Point(RogFormatki + 150, this.Height - 85);
            oC.Button_3600.Location = new Point(RogFormatki + 200, this.Height - 85);
            oC.Button_86400.Location = new Point(RogFormatki + 250, this.Height - 85);
            oC.Button_2595000.Location = new Point(RogFormatki + 300, this.Height - 85);
        }

        public void ZaznaczonoTabPage_Rynek(object sender, EventArgs e)
        {
            if (Rynek_oTB.SelectedIndex == 1)       //zaznaczono Pracownikow
            {
                OdznaczWszystkoW(ref Rynek_oPR);
                OdznaczWszystkoW(ref Zasoby_oPR);
                OdznaczWszystkoW(ref Zasoby_oPracow);
                Rynek_oTB.TabPages[1].BackColor = TColors[0];
                Rynek_oTB.TabPages[1].ForeColor = TColors[3];

                Rynek_oTB.TabPages[0].BackColor = TColors[1];
                Rynek_oTB.TabPages[0].ForeColor = TColors[3];
            }
            else
            {
                OdznaczWszystkoW(ref Rynek_oPracow);
                Rynek_oTB.TabPages[1].BackColor = TColors[1];
                Rynek_oTB.TabPages[1].ForeColor = TColors[3];

                Rynek_oTB.TabPages[0].BackColor = TColors[0];
                Rynek_oTB.TabPages[0].ForeColor = TColors[3];
            }
            /*for (int i = 0; i < Rynek_oTB.TabPages.Count; i++)
            {
                if (Rynek_oTB.SelectedIndex == i)
                {
                    Rynek_oTB.TabPages[i].BackColor = TColors[0];
                    Rynek_oTB.TabPages[i].ForeColor = TColors[3];
                }
                else
                {
                    Rynek_oTB.TabPages[i].BackColor = TColors[1];
                    Rynek_oTB.TabPages[i].ForeColor = TColors[3];
                }
            }*/
        }
        public void ZaznaczonoTabPage_Zasoby(object sender, EventArgs e)
        {
            //OdznaczWszystkoW(ref Zasoby_oPR);      
            /*for (int i = 0; i < Zasoby_oTB.TabPages.Count; i++)
            {
                if (Zasoby_oTB.SelectedIndex == i)
                {
                    Zasoby_oTB.TabPages[i].BackColor = TColors[0];
                    Zasoby_oTB.TabPages[i].ForeColor = TColors[3];
                }
                else
                {
                    Zasoby_oTB.TabPages[i].BackColor = TColors[1];
                    Zasoby_oTB.TabPages[i].ForeColor = TColors[3];
                }
            }*/
            if (Zasoby_oTB.SelectedIndex == 1)       //zaznaczono Pracownikow
            {
                OdznaczWszystkoW(ref Zasoby_oPR);
                OdznaczWszystkoW(ref Rynek_oPR);
                OdznaczWszystkoW(ref Rynek_oPracow);
                Zasoby_oTB.TabPages[1].BackColor = TColors[0];
                Zasoby_oTB.TabPages[1].ForeColor = TColors[3];

                Zasoby_oTB.TabPages[0].BackColor = TColors[1];
                Zasoby_oTB.TabPages[0].ForeColor = TColors[3];
            }
            else
            {
                OdznaczWszystkoW(ref Zasoby_oPracow);
                OdznaczWszystkoW(ref Rynek_oPR);
                OdznaczWszystkoW(ref Rynek_oPracow);
                Zasoby_oTB.TabPages[1].BackColor = TColors[1];
                Zasoby_oTB.TabPages[1].ForeColor = TColors[3];

                Zasoby_oTB.TabPages[0].BackColor = TColors[0];
                Zasoby_oTB.TabPages[0].ForeColor = TColors[3];
            }
        }
        public void ZaznaczonoTabPage_MiniGra(object sender, EventArgs e)
        {
            for (int i = 0; i < Minigry_oTB.TabPages.Count; i++)
            {
                if (Minigry_oTB.SelectedIndex == i)
                {
                    Minigry_oTB.TabPages[i].BackColor = TColors[0];
                    Minigry_oTB.TabPages[i].ForeColor = TColors[3];
                }
                else
                {
                    Minigry_oTB.TabPages[i].BackColor = TColors[1];
                    Minigry_oTB.TabPages[i].ForeColor = TColors[3];
                }
            }
        }

        public void OdswiezDzien_CzasProjekt(object sender, EventArgs e)
        {
            if (oC.MineloDni == Rynek_oPR.GetKtoryDzienProjekt())
            {
                if (Rynek_oPR.dWylosujWyraz != null)
                {
                    Rynek_oPR.WylosujProjekt(Opinia);
                    Rynek_oPR.KiedyNowyProjekt();

                }
            }

        }
        public void OdswiezDzien_CzasPracownik(object sender, EventArgs e)
        {
            if (oC.MineloDni == Rynek_oPracow.GetKtoryDzienPracownik())
            {                                                                                                                                 
                if (Rynek_oPracow.dWylosujWyraz != null)
                {
                    Rynek_oPracow.WylosujPracownika(Opinia);
                    Rynek_oPracow.KiedyNowyPracownik();

                }
            }

        }

        private void StworzMiniGre(object sender, EventArgs e)
        {
            if (Zasoby_oPR.SelectedItems.Count > 0)
            {
                switch (IleZrobionoMinigier)
                {
                    default:
                        {

                            oMG = new Przepis(PoziomTrudnosci, UdaloSie, NieUdaloSie, Minigry_oTB, TColors,oBaza.WylosujWyraz("slowo"));
                            oMG.DopasujKontrolki(Size);     
                            break;
                        }
                }
            }
            else
            {
                DisposeAll(ref Minigry_oTB);    
            }
        }
        private void SworzSzczegoly_Projekty(object sender, EventArgs e)
        {
            DisposeAll(ref Statys_oTB);
            Console.WriteLine("Stworzono szczegol Proj");
            if (Rynek_oPR.SelectedItems.Count > 0)
            {
                Random R = new Random();
                string[] Adresy = new string[] { "Obrazki/Avatar_"+R.Next(0,3).ToString()+".png", Rynek_oPR.SelectedItems[0].SubItems[0].Text };

                oS = new Szczegoly_Proj(Adresy, Statys_oTB.Size, Statys_oTB, TColors, Rynek_oPR.Items[Rynek_oPR.SelectedItems[0].Index]);
                oS.C[2].Click += new EventHandler(PrzyjmijProjekt);
            }
            else
            {
                ;
            }
        }
        private void SworzSzczegoly_Pracownicy(object sender, EventArgs e)
        {
            DisposeAll(ref Statys_oTB);
            Console.WriteLine("Stworzono szczegol Prac");
            if (Rynek_oPracow.SelectedItems.Count > 0)
            {
                //OdznaczWszystkoW(ref )                   
                Random R = new Random();
                string[] Adresy = new string[] { "Obrazki/Avatar_" + R.Next(0, 2).ToString() + ".png", Rynek_oPracow.SelectedItems[0].SubItems[0].Text, Rynek_oPracow.SelectedItems[0].SubItems[1].Text };

                oS = new Szczegoly_Prac(Adresy, Statys_oTB.Size, Statys_oTB, TColors, Rynek_oPracow.Items[Rynek_oPracow.SelectedItems[0].Index], false);
                oS.C[2].Click += new EventHandler(PrzyjmijPracownika);
            }
            else
            {
                ;
            }
        }
        private void SworzSzczegoly_Pracownicy_Zasoby(object sender, EventArgs e)
        {
            DisposeAll(ref Statys_oTB);
            Console.WriteLine("Stworzono szczegol Prac zasob");
            if (Zasoby_oPracow.SelectedItems.Count > 0)
            {
                Random R = new Random();
                Console.WriteLine(Zasoby_oPracow.SelectedItems[0].SubItems[0].Text +"   "+ Zasoby_oPracow.SelectedItems[0].SubItems[1].Text);
                string[] Adresy = new string[] { "Obrazki/Avatar_" + R.Next(0, 2).ToString() + ".png", Zasoby_oPracow.SelectedItems[0].SubItems[0].Text, Zasoby_oPracow.SelectedItems[0].SubItems[1].Text };

                //Zasoby_oTB.SelectedIndex = 0;
                oS = new Szczegoly_Prac(Adresy, Statys_oTB.Size, Statys_oTB, TColors, Zasoby_oPracow.Items[Zasoby_oPracow.SelectedItems[0].Index], true);
                WypelnijComboBox(ref oS.Zajecia, Zasoby_oPR.GetSubItemy(0));
                //oS.C[2].Click += new EventHandler(PrzyjmijPracownika);
                oS.Zajecia.SelectedIndexChanged += new EventHandler(ZaznaczonoZajecie);
            }
            else
            {
                ;
            }
        }
        public void WypelnijComboBox(ref ComboBox C, string[] Itemy)
        {
            if (C != null)
            {
                //C.Items.Add("Bez zajecia");
                for (int i = 0; i < Itemy.Length; i++)
                {
                    C.Items.Add(Itemy[i]);
                }
            }
        }
        private void ZaznaczonoZajecie(object sender, EventArgs e)
        {
            Zasoby_oPracow.SelectedItems[0].SubItems[4].Text = oS.Zajecia.Items[oS.Zajecia.SelectedIndex].ToString();
        }
        private void UdaloSie()
        {
            Minigry_oTB.TabPages[0].Dispose();
            DodajDoSubitemu(Zasoby_oPR.SelectedItems[0], 3, -Mnoznik_NormaPlus);
            ListViewItem Temp = Zasoby_oPR.SelectedItems[0];
            SprawdzCzyWykonanoProjekt(Zasoby_oPR.SelectedItems[0]);
            //OdznaczWszystkoW(ref Rynek_oPR);

            if (Zasoby_oPR.SelectedItems.Count>0)
            if (Zasoby_oPR.SelectedItems[0] == Temp)
            {
                oMG = new Przepis(PoziomTrudnosci, UdaloSie, NieUdaloSie, Minigry_oTB, TColors, oBaza.WylosujWyraz("slowo"));
                oMG.DopasujKontrolki(Size);
                oMG.Kontrolki[1].Select();
            }


            // oMG.Kontrolki[0].Hide();
            //oMG.Kontrolki[1].Hide();
        }
        private void NieUdaloSie()
        {
            Minigry_oTB.TabPages[0].Dispose();
            DodajDoSubitemu(Zasoby_oPR.SelectedItems[0], 3, Mnoznik_NormaMinus);
            OdznaczWszystkoW(ref Rynek_oPR);
            // oMG.Kontrolki[0].Hide();
            //oMG.Kontrolki[1].Hide();
        }
        private void Zakup()
        {
            Console.WriteLine("Zakup");
        }
        private void OdznaczWszystkoW(ref Projekty LV)
        {
            int ile = LV.SelectedItems.Count;
            for (int i = 0; i < ile; i++)
            {
                LV.SelectedItems[0].Selected = false;
            }
        }
        private void OdznaczWszystkoW(ref Pracownicy LV)
        {
            int ile = LV.SelectedItems.Count;
            for (int i = 0; i < ile; i++)
            {
                LV.SelectedItems[0].Selected = false;
            }
        }
        private void DisposeAll(ref FixedTabControl T)
        {
            int ile = T.TabPages.Count;
            for (int i = 0; i < ile; i++)
            {
                T.TabPages[0].Dispose();
            }
        }
        private void DodajDoSubitemu(ListViewItem oLVI, int IDSubItemu,int Dodawana) //1.wynagrodzenie  2.Deadline  3.Norma  4.Opinia
        {
            int Wynik = int.Parse(oLVI.SubItems[IDSubItemu].Text) + Dodawana;
            oLVI.SubItems[IDSubItemu].Text = Wynik.ToString();   
        }
        private void SprawdzCzyWykonanoProjekt(ListViewItem oLVI)
        {
            if (int.Parse(oLVI.SubItems[3].Text) <= 0)
            {
                oLVI.Selected = false;

                Budzet += int.Parse(oLVI.SubItems[1].Text);
                Opinia += 2 * int.Parse(oLVI.SubItems[4].Text);
                Console.Beep(200, 400);

                oLVI.Remove();
            }
        }
        private void Update(object sender, EventArgs e)
        {
            PokolorujItemy(Rynek_oPR,4,Opinia);
            PokolorujItemy(Rynek_oPracow,2,Budzet);
            PokolorujSzczegol(4, Rynek_oPR.SumaSubitemu(4, true));     
            WypelnijStaty();
        }     
        private void PokolorujItemy(ListView oL, int IDSubitemu, int DoCzego)
        {
            for (int i = 0; i < oL.Items.Count; i++)
            {                                                 
                int Op = int.Parse(oL.Items[i].SubItems[IDSubitemu].Text);
                oL.Items[i].BackColor = PorownajPokoloruj(DoCzego, Op);
            }                          
        }
        private void PokolorujSzczegol(int ID, int Suma)
        {
            if (oS != null)
            {
                oS.C[2].BackColor = PorownajPokoloruj(Opinia, Suma);
            }
        }
        private void WypelnijStaty()
        {
            Stat.Text = "OPINIA : " + Opinia.ToString() + "\nBUDZET : " + Budzet.ToString();
        }
        private void MinalDzien()
        {
            Console.WriteLine("Minal Dzien " + oC.MineloDni);



            DziennaNormaPracownikow();
            ZwrocWykonanePrzyjeteProjekty(ref Zasoby_oPR);

            ObnizDeadliny(ref Rynek_oPR);
            WywalProjektyByDeadline(ref Rynek_oPR);
            ObnizDeadliny(ref Zasoby_oPR);
            WywalProjektyByDeadline(ref Zasoby_oPR);

            if (oS != null)
            {            
                oS.MD();       
                //oS.DopasujKontrolkiDo(this.Size);
            }
        }
        private void DziennaNormaPracownikow()
        {
            Console.Write("Dzienna norma pracownikow");

            int ile = Zasoby_oPR.Items.Count;
            Console.WriteLine(ile.ToString());
            ////////////////////////////////////////////////////////////////////////
            for (int i = 0; i < ile; i++)
            {
                Console.WriteLine("Norma : " + Zasoby_oPracow.Items[i].SubItems[0].Text + " " + Zasoby_oPracow.Items[i].SubItems[1].Text + " " + Zasoby_oPracow.Items[i].SubItems[4].Text);
                PrzejrzyjPracownikow_By(Zasoby_oPR.Items[i].SubItems[0].Text,i);
            }

            Budzet -= Zasoby_oPracow.SumaSubitemu(3, false);// int.Parse(Zasoby_oPracow.Items[i].SubItems[2].Text);

        }
        private void PrzejrzyjPracownikow_By(string sProjekt, int IDProjektu)
        {
            int ileItemow = Zasoby_oPracow.Items.Count;
            int ileSubitemow = Zasoby_oPracow.Items[0].SubItems.Count;  
            ////////////////////////////////////////////////////////////////////////
            for (int i = 0; i < ileItemow; i++)
            {
                if (Zasoby_oPracow.Items[i].SubItems[ileSubitemow - 1].Text == sProjekt)
                {
                    int Temp = int.Parse(Zasoby_oPR.Items[IDProjektu].SubItems[3].Text);
                    Zasoby_oPR.Items[IDProjektu].SubItems[3].Text = (Temp - int.Parse(Zasoby_oPracow.Items[i].SubItems[3].Text)).ToString();

                }
            }
        }
        private void ObnizDeadliny(ref Projekty P)
        {                       
            for (int i = 0; i < P.Items.Count; i++)
            {
                P.Items[i].SubItems[2].Text = (int.Parse(P.Items[i].SubItems[2].Text) - 1).ToString();
            }
        }
        private void WywalProjektyByDeadline(ref Projekty P)
        {
            for (int i = 0; i < P.Items.Count; i++)
            {
                if (P.Items[i].SubItems[2].Text == "-1")
                {
                    P.Items[i].Selected = false;
                    P.Items[i].Remove();
                }
            }
        }
        private void ZwrocWykonanePrzyjeteProjekty(ref Projekty P)
        {
            for (int i = 0; i < P.Items.Count; i++)
            {
                SprawdzCzyWykonanoProjekt(P.Items[i]);
                /*if (int.Parse(P.Items[i].SubItems[3].Text) <1)
                {
                    //SprawdzCzyWykonanoProjekt
                    P.Items[i].Selected = false;
                    P.Items[i].Remove(); 
                }    */
            }
        }
        private void PrzeniesItem(ListView Skad, ListView Gdzie)
        {
            ListViewItem Temp = Skad.SelectedItems[0];
            Console.WriteLine(Temp.SubItems[0].Text + " " + (Temp.SubItems[1].Text));
            //Temp.SubItems.Add("");
            Skad.SelectedItems[0].Remove();
            //Temp.BackColor = Gdzie.BackColor;


            Gdzie.Items.Add(Temp);


            /*for (int i = 0; i < Temp.SubItems.Count; i++)
            {
                Gdzie.Items[Gdzie.Items.Count - 1].SubItems.Add(Temp.SubItems[i]);
            }   */

            Console.WriteLine("Nowy Item : " + Gdzie.Items[Gdzie.Items.Count - 1].SubItems[0].Text + " " + Gdzie.Items[Gdzie.Items.Count - 1].SubItems[1].Text + " " + Gdzie.Items[Gdzie.Items.Count - 1].SubItems[2].Text + " " + Gdzie.Items[Gdzie.Items.Count - 1].SubItems[3].Text + " " + Gdzie.Items[Gdzie.Items.Count - 1].SubItems[4].Text + " ");
            //Gdzie.Items.Add(Skad.SelectedItems[0]);

            //Console.WriteLine("Nowy Item : X" + Temp.SubItems[Temp.SubItems.Count-1].Text + "X");
        }
        private void PrzyjmijProjekt(object sender, EventArgs e)
        {
            int Suma = Rynek_oPR.SumaSubitemu(4, true);
            if (Suma > Opinia)
            {
            }
            else
            {
                PrzeniesItem(Rynek_oPR, Zasoby_oPR);  
                oS = null;
                Opinia -= Suma;
                OdznaczWszystkoW(ref Zasoby_oPR);
            }
        }
        private void PrzyjmijPracownika(object sender, EventArgs e)
        {
            int Suma = Rynek_oPracow.SumaSubitemu(2, true);
            if (Suma > Budzet)
            {
            }
            else
            {
                PrzeniesItem(Rynek_oPracow, Zasoby_oPracow);     
                oS = null;
                Budzet -= Suma; if(Zasoby_oPracow.Items.Count!=0)
                OdznaczWszystkoW(ref Zasoby_oPR);
            }
        }
        private void Ustawienia_PoziomTrudnosci()
        {
            switch (PoziomTrudnosci)
            {
                case '1':
                    {
                        Opinia = 10;
                        Budzet = 0;
                        Mnoznik_NormaPlus = 2;
                        Mnoznik_NormaMinus = 1;
                        break;
                    }
                default:
                    {
                        Opinia = 100000;
                        Budzet = 100000;
                        Mnoznik_NormaPlus = 10000;
                        Mnoznik_NormaMinus = 1000;
                        break;
                    }
            }
        }




    }
}
