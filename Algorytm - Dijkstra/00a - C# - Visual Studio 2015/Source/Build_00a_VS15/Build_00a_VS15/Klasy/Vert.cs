using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Build_00a_VS15.Klasy
{
    class Vert
    {
        private int _x, _y;//, _tag;
        private string _nazwa;

        public Point Location = new Point(0, 0);

        public int X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }
        public int Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }/*
        public int Tag
        {
            get
            {
                return _tag;
            }
            set
            {
                _tag = value;
            }
        }*/
        public string Nazwa
        {
            get
            {
                return _nazwa;
            }
            set
            {
                _nazwa = value;
            }
        }

        public Vert(int Pozycja_X, int Pozycja_Y, string nazwa)
        {
            X = Pozycja_X;
            Y = Pozycja_Y;
            Nazwa = nazwa;
            Location = new Point(X, Y);
        }
        public Vert(int Pozycja_X, int Pozycja_Y, int Etykieta, string nazwa)
        {
            X = Pozycja_X;
            Y = Pozycja_Y;
            Nazwa = nazwa;
            Location = new Point(X, Y);
        }
    }
}
