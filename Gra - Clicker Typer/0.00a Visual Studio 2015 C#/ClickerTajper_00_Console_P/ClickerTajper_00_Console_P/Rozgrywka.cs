using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wisielec_P;
using System.Drawing;

namespace ClickerTajper_00_Console_P
{
    class Rozgrywka : Form
    {
        private PrintPreviewDialog printPreviewDialog1;
        /////////////////////////////Oficjalne
        Baza oBaza ;
        Zasoby oZas ;
        Czas oCzas ;
        Projekt oProj ;
        Pracownik oPrac ;
        Tlo oTlo;
        MiniGra oMG;
        ////////////////////////////Robocze


        public Rozgrywka()
        {
            Console.WriteLine("    _______");
            Console.Write("    "+(char)1);
            oBaza = new Baza();
            Console.Write((char)1);
            oZas = new Zasoby(15, 3000, new System.Drawing.Point(0, 425), 50, 200, oBaza.WylosujWyraz("slowo"));
            Console.Write((char)1);
            oCzas = new Czas();
            Console.Write((char)1);
            oProj = new Projekt();
            oPrac = new Pracownik();
            Console.Write((char)1);
            oTlo = new Tlo();
            Console.Write((char)1);
            Inizjalizacja();
            Console.WriteLine((char)1+"\n\r");
        }



        private void Rozgrywka_Load(object sender, EventArgs e)
        {
        }
        private void Inizjalizacja()
        {
            this.SuspendLayout();

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 600);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Rozgrywka_Load);
            this.ResumeLayout(false);
            this.BackgroundImage = Image.FromFile("Obrazki/Form_Tlo.png");

            /////////////////////////////////////////////////////////////////////Zasoby
            oZas.OdswiezLabel();
            oTlo.Pola.TabPages[0].Controls.Add(oZas.Lejbel);
            oTlo.Pola.TabPages[1].Controls.Add(oZas.Pracownicy);
            oTlo.Pola.TabPages[1].Controls.Add(oZas.Projekty);
            //oTlo.Pola.TabPages[1].Controls.Add(oZas.Slowo_Label);
            //oTlo.Pola.TabPages[1].Controls.Add(oZas.Slowo_TextBox);
            oTlo.Pola.TabPages[1].Controls.Add(oZas.KtoCo_CheckBox);
            oTlo.Pola.TabPages[1].Controls.Add(oZas.KtoCo_ComboBox);
            oZas.Slowo_TextBox.TextChanged += new EventHandler(KtosPiszeSlowo_Text);
            oZas.Projekty.SelectedIndexChanged += new EventHandler(oZas.ZaladujComboBoxa);
            oZas.Projekty.SelectedIndexChanged += new EventHandler(oZas.ProjektyIdSelectChanged);
            oZas.KtoCo_ComboBox.SelectedValueChanged += new EventHandler(oZas.ComboBoxIdChanged);
            oZas.Pracownicy.SelectedIndexChanged += new EventHandler(oZas.PracownicyIdSelectChanged);
            //oMG.ZwrocProjekt = oZas.ZwrocProjekt;
            oZas.NowaGra = NowaMiniGra;
            oZas.StaraGra = UsunStaraGre;
            //oCzas.Zegar.Tick += oMG.Update;

            ///////////////////////////////////////////////Tlo
            this.Controls.Add(oTlo.Pola);
            oTlo.Pola.SelectedIndexChanged += new EventHandler(ZmienilSieTab);

            //////////////////////////////////////////////Czas
            oCzas.Zegar.Tick += new System.EventHandler(oCzas.Zegar_Tick);
            oCzas.Zegar.Tick += new System.EventHandler(Updejt);
            this.Controls.Add(oCzas.Zegar_Label);
            oCzas.Zegar.Start();
            ////////////////////////////////////////////////////////////////////////////////////////regulacja
            //oCzas.HScrollBar_1_1M.ValueChanged += new System.EventHandler(oCzas.VC_1_1M);
            //oCzas.HScrollBar_1M_100M.ValueChanged += new System.EventHandler(oCzas.VC_1M_100M);
            //this.Controls.Add(oCzas.HScrollBar_1_1M);
            //this.Controls.Add(oCzas.HScrollBar_1M_100M);                 
            oCzas.Button_1.Click += new EventHandler(oCzas.Btn1_Click);
            oCzas.Button_3600.Click += new EventHandler(oCzas.Btn3600_Click);
            oCzas.Button_86400.Click += new EventHandler(oCzas.Btn86400_Click);
            oCzas.Button_2595000.Click += new EventHandler(oCzas.Btn2595000_Click);
            this.Controls.Add(oCzas.Button_1);
            this.Controls.Add(oCzas.Button_3600);
            this.Controls.Add(oCzas.Button_86400);
            this.Controls.Add(oCzas.Button_2595000);

            ////////////////////////////////////////////////Projekt     
            oCzas.Zegar.Tick += new System.EventHandler(oProj.RegularnieDodawajProjekty);
            oProj.MineloDni = oCzas.MineloDni;
            oTlo.Pola.TabPages[0].Controls.Add(oProj.Projekty);
            oTlo.Pola.TabPages[0].Controls.Add(oProj.Widok_Button);
            oTlo.Pola.TabPages[0].Controls.Add(oProj.Zaplac_Button);
            oProj.Projekty.SelectedIndexChanged += new EventHandler(oProj.Projekty_SelectionChanged);
            oProj.Widok_Button.Click += new EventHandler(oProj.ZmienWidokProj);
            oProj.Zaplac_Button.Click += new EventHandler(PrzyjmijProjekt);
            oProj.Zasoby_Opinia = oZas.Opinia;
            oProj.Losowanie = oBaza.WylosujWyraz;

            ////////////////////////////////////////////////Pracownicy       
            oCzas.Zegar.Tick += new System.EventHandler(oPrac.RegularnieDodawajProjekty);
            oPrac.MineloDni = oCzas.MineloDni;
            oTlo.Pola.TabPages[0].Controls.Add(oPrac.Projekty);
            oTlo.Pola.TabPages[0].Controls.Add(oPrac.Widok_Button);
            oTlo.Pola.TabPages[0].Controls.Add(oPrac.Zaplac_Button);
            oPrac.Projekty.SelectedIndexChanged += new EventHandler(oPrac.Projekty_SelectionChanged);
            oPrac.Widok_Button.Click += new EventHandler(oPrac.ZmienWidokProj);
            oPrac.Zaplac_Button.Click += new EventHandler(ZatrudnijPracownika);
            oPrac.Losowanie = oBaza.WylosujWyraz;
        }
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Rozgrywka));
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.SuspendLayout();
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // Rozgrywka
            // 
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Name = "Rozgrywka";
            this.ResumeLayout(false);

        }
        private void Updejt(object sender, EventArgs e)
        {
            if (oProj.MineloDni != oCzas.MineloDni)
            {
                oZas.PrzeliczNorme();

                OdswiezDeadLinyNaKontrolce(oCzas.MineloDni - oProj.MineloDni, ref oProj.Projekty,false);
                OdswiezDeadLinyNaKontrolce(oCzas.MineloDni - oProj.MineloDni, ref oZas.Projekty,true);
                oProj.MineloDni = oCzas.MineloDni;
            }
            if (oPrac.MineloDni != oCzas.MineloDni)
            {
                oPrac.MineloDni = oCzas.MineloDni;
            }
                                   

            if (oProj.Zasoby_Opinia != oZas.Opinia)
            {
                oProj.Zasoby_Opinia = oZas.Opinia;
            }
            if (oPrac.Zasoby_Budzet != oZas.Budzet)
            {
                oPrac.Zasoby_Budzet = oZas.Budzet;
            }                                                          
            
                     
        }
        private void PrzyjmijProjekt(object sender, EventArgs e)
        {
            if (oProj.MoznaKupic)
            {
                Console.Beep(2000, 100);
                oZas.TransjakcjaOdejmij(oProj.SumaWyrazowZListView(ref oProj.Projekty, 4), 0, 0);
                oZas.TransjakcjaDodaj(0, oProj.SumaWyrazowZListView(ref oProj.Projekty, 3) / 10, 0);

                int ile = oProj.Projekty.SelectedItems.Count;
                ListViewItem temp;
                for (int i = 0; i < ile; i++)
                {
                    temp = oProj.Projekty.SelectedItems[0];
                    oProj.Projekty.SelectedItems[0].Remove();
                    oZas.Projekty.Items.Add(temp);
                }

                oZas.OdswiezLabel();
            }
            else
            {
                Console.Beep(100, 100);
            }
        }
        private void ZatrudnijPracownika(object sender, EventArgs e)
        {
            if (oPrac.MoznaKupic)
            {
                Console.Beep(2000, 100);
                oZas.TransjakcjaOdejmij(0,oPrac.SumaWyrazowZListView(ref oPrac.Projekty, 2), 0);
                oZas.TransjakcjaDodaj(0, 0, 0);

                int ile = oPrac.Projekty.SelectedItems.Count;
                ListViewItem temp;
                for (int i = 0; i < ile; i++)
                {
                    temp = oPrac.Projekty.SelectedItems[0];
                    oPrac.Projekty.SelectedItems[0].Remove();
                    oZas.Pracownicy.Items.Add(temp);
                }

                oZas.OdswiezLabel();
            }
            else
            {
                Console.Beep(100, 100);
            }
        }
        private void OdswiezDeadLinyNaKontrolce(int IleDniMinelo, ref ListView K, bool CzyWplywaNaZasoby)
        {
            int[] Indexy = null;
            int temp2 = 0;    /////////1) ile dni minelo         2)ile projektow usunac
            string TeCoMniejszeNizZero = null;              //////adresy itemow kontrolki co trza usunac     
            DL_PobierzAdresy(ref K, ref temp2, ref TeCoMniejszeNizZero, ref IleDniMinelo);
                                                         
            DL_PullZaznaczoneId(ref K, ref Indexy);       
            DL_PullUsuwaneId(ref K, ref temp2, ref TeCoMniejszeNizZero);    
            DL_UsunUsuwane(ref K, ref Indexy, CzyWplywaNaZasoby);
                     
            DL_ZaznaczZaznaczone(ref K, ref Indexy);
        }
        private void DL_PobierzAdresy(ref ListView K, ref int temp2, ref string TeCoMniejszeNizZero, ref int IleDniMinelo)
        {
            int temp1;
            for (int i = 0, j = K.Items.Count; i < j; i++)
            {
                temp1 = int.Parse(K.Items[i].SubItems[1].Text);
                temp1 = temp1 - IleDniMinelo;
                if (temp1 >= 0)
                {
                    K.Items[i].SubItems[1].Text = (temp1).ToString();
                }
                else
                {
                    temp2 += 1;
                    TeCoMniejszeNizZero += i.ToString() + ";";
                }
            }
        }
        private void DL_PullZaznaczoneId(ref ListView K, ref int[] Indexy)
        {
            if (K.SelectedIndices.Count != 0)
            {
                Indexy = new int[K.SelectedIndices.Count];        ////ID zaznaczonych na kontrolce
                for (int i = 0, j = Indexy.Length; i < j; i++)          ///Pobranie ID
                {
                    Indexy[i] = K.SelectedIndices[i];
                }         
                K.SelectedItems.Clear();                               ///odznaczenie itemow kontrolki
            }
        }
        private void DL_PullUsuwaneId(ref ListView K, ref int temp2, ref string TeCoMniejszeNizZero)
        {
            for (int i = 0, j = temp2; i < j; i++)                 ////pobierz ID z tych co trza usunac
            {           
                int ID = int.Parse(Uniwersalne.WyciagnijWyraz(TeCoMniejszeNizZero, ';', i));
                K.Items[ID].Selected = true;
            }
        }
        private void DL_UsunUsuwane(ref ListView K, ref int[] Indexy, bool CzyWplywaNaZasoby)
        {
            for (int i = 0, j = K.SelectedItems.Count; i < j; i++)      ////usuniecie temow zaznaczonych (te co im deadliny mijaja)
            {
                if(CzyWplywaNaZasoby)
                DL_PrzeliczNorme(ref K, i);

                K.SelectedItems[0].Remove(); 
                if (K.Items.Count == 0)
                {
                    Indexy = null;
                }
            }
            K.SelectedItems.Clear();
        }
        private void DL_ZaznaczZaznaczone(ref ListView K, ref int[] Indexy)
        {
            if (Indexy != null)
            {
                Console.WriteLine("indexy : " + Indexy.Length);
                for (int i = 0; i < Indexy.Length; i++)
                {
                    K.Items[Indexy[i]].Selected = true;                                     /////(c.d.) Tu wysypie
                }
            }
        }
        private void DL_PrzeliczNorme(ref ListView K, int ID)
        {
            int Norma = int.Parse(K.Items[ID].SubItems[2].Text);
            if (Norma < 0)
            {
                Console.Beep(150, 200);          /////////////////////////////////////dzwiek 
                oZas.Opinia += int.Parse(K.Items[ID].SubItems[4].Text);
                oZas.Budzet += int.Parse(K.Items[ID].SubItems[3].Text);
            }
            else
            {
                Console.Beep(32767, 200);          /////////////////////////////////////dzwiek  
                oZas.Opinia -= int.Parse(K.Items[ID].SubItems[4].Text);
            }
            oZas.OdswiezLabel();
        }

        private void KtosPiszeSlowo_Text(object sender, EventArgs e)
        {
            if (oZas.Slowo_TextBox.Text == oZas.Slowo_Label.Text)
            {
                Console.Beep(2000, 100);          /////////////////////////////////////dzwiek     
                oZas.Slowo_TextBox.Text = "";
                oZas.Slowo_Label.Text = oBaza.WylosujWyraz("slowo");
                oZas.WpisanoSlowo();                
            }
        }
        private void ZmienilSieTab(object sender, EventArgs e)
        {                            

            Console.WriteLine("XXXXXXXXXXXXXXXXXXXX : " + oTlo.Pola.SelectedIndex);

            if (oTlo.Pola.SelectedIndex == 1)
            {
                oTlo.Pola.TabPages[1].Controls.Add(oZas.Lejbel); 
            }
            else
            {
                oTlo.Pola.TabPages[0].Controls.Add(oZas.Lejbel);


            }
        }
        private void NowaMiniGra()
        {
            UsunStaraGre();

            int RN;
            Random r = new Random();
            RN = r.Next();
            if (RN % 2 == 0)
            {
                oMG = new Wisielec(ref oZas.Opinia);
                oMG.Zainicjalizuj(oTlo.Pola.TabPages[1], ref oBaza);
                oMG.PunktZaWyraz = oZas.WpisanoSlowo;
                oMG.PunktZaBlad = oZas.SpieprzonoSprawe;
            }
            else
            {
                oMG = new Przepisz(ref oZas.Opinia);
                oMG.Zainicjalizuj(oTlo.Pola.TabPages[1], ref oBaza);
                oMG.PunktZaWyraz = oZas.WpisanoSlowo;
            }
        }
        private void UsunStaraGre()
        {
            if (oMG != null)
                oMG.Usun(oTlo.Pola.TabPages[1]);
            oMG = null;
        }
    }
}
