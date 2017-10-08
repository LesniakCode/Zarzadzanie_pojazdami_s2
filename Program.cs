using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zarzadzanie_pojazdami_s2
{
    class Program
    {
        static void Main(string[] args)
        {
            Woz Poj = new Woz();

            IPojLadWodWoj Amfibia = Poj;
            Amfibia.UstawAttr("Amfibia", 5, 8, 60, 20, 23.4);
            Amfibia.Melduj();
            IPojLadWoj Czolg = new Woz();
            Czolg.Melduj();
            Czolg.L_kol = 0;
            IPojWodWoj Niszczyciel = Poj;
            Niszczyciel.Kaliber = 70;
            IPojPowWoj Puszczyk = Poj;
            Puszczyk.V_pow = 100;
            IPojLad Ambulans = Poj;
            Ambulans.Kod = "Karetka";
            Ambulans.L_kol = 4;
            Ambulans.L_zaloga = 5;
            Ambulans.V_lad = 120;
            IPojWod Zaglowka = Poj;
            Zaglowka.Kod = "Zaglowka";
            Zaglowka.L_zaloga = 4;
            Zaglowka.V_wod = 30;
          
            Console.ReadKey();
        }
    }

    class Woz : IPoj, IPojLad, IPojPow, IPojWod, IPojWoj, IPojLadWoj, IPojWodWoj, IPojPowWoj, IPojLadWodWoj
    {
        #region Woz - pola
        private string kod;
        private int l_kol;
        private int l_zaloga;
        private double kaliber;
        private int v_lad;
        private int v_pow;
        private int v_wod;
        #endregion
        #region Woz - wlasciwosci
        public string Kod
        {
            get
            {
                return kod;
            }
            set
            {
                kod = value;
            }
        }
        public int L_kol
        {
            get
            {
                return l_kol;
            }
            set
            {
                l_kol = value;
            }
        }
        public int L_zaloga
        {
            get
            {
                return l_zaloga;
            }
            set
            {
                l_zaloga = value;
            }
        }
        public double Kaliber
        {
            get
            {
                return kaliber;
            }
            set
            {
                kaliber = value;
            }
        }
        public int V_lad
        {
            get
            {
                return v_lad;
            }
            set
            {
                v_lad = value;
            }
        }
        public int V_pow
        {
            get
            {
                return v_pow;
            }
            set
            {
                v_pow = value;
            }
        }
        public int V_wod
        {
            get
            {
                return v_wod;
            }
            set
            {
                v_wod = value;
            }
        }
        #endregion

        public Woz()
        {
            //empty
        }

        #region Woz - metody
        public IPojLadWodWoj UstawAttr(string nazwa,int zaloga, int kola, int maks_V_lad,int maks_V_wod, double Kaliber)
        {
            this.Kod = nazwa;
            this.L_zaloga = zaloga;
            this.L_zaloga = kola;
            this.V_lad = maks_V_lad;
            this.V_wod = maks_V_wod;
            this.Kaliber = Kaliber;
            return this;
        }
        public void Melduj()
        {
            Console.WriteLine("Melduje...\nKod: {0}\nLiczebnosc zalogi: {1}",this.Kod,this.L_zaloga);
           // Type type = typeof().GetInterface("IBar");
            if (this.GetType() is IPojLad)
            {
                Console.WriteLine("Liczba kol: {0}", L_kol);
                Console.WriteLine("Maks predkosc ladowa: {0} km/h", V_lad);
            }
            if(this.GetType() is IPojWod)
            {
                Console.WriteLine("Maks predkosc wodna: {0} km/h", V_wod); 
            }
            if(this.GetType()is IPojPow)
            {
                Console.WriteLine("Maks predkosc powietrzna: {0} km/h", V_pow);
            }
            if(this.GetType() is IPojLadWodWoj)
            {
                Console.WriteLine("Liczba kol: {0}", L_kol);
                Console.WriteLine("Maks predkosc ladowa: {0} km/h", V_lad);
                Console.WriteLine("Maks predkosc wodna: {0} km/h", V_wod);
            }
            if((this.GetType()is IPojLadWoj) || (this.GetType() is IPojPowWoj) || (this.GetType() is IPojWodWoj))
            {
                Console.WriteLine("Dzialo o kalibrze: {0} mm", Kaliber);
            }
            Console.WriteLine("\nKoniec meldunku\n\n");

        }
        void IPojLad.Jedz()
        {

        }
        void IPojPow.Lec()
        {

        }
        void IPojWod.Plyn()
        {

        }
        void IPojWoj.Ognia()
        {

        }
        void IPojWoj.Prezentuj()
        {

        }
        
        #endregion
    }
    #region Interfaces
    interface IPoj
    {
        string Kod { get; set; }
        int L_zaloga { get; set; }

        void Melduj();

    }

    interface IPojLad : IPoj
    {
        int L_kol { get; set; }
        int V_lad { get; set; }

        void Jedz();
    }

    interface IPojPow : IPoj
    {
        int V_pow { get; set; }

        void Lec();
    }

    interface IPojWod : IPoj
    {
        int V_wod { get; set; }

        void Plyn();
    }

    interface IPojWoj : IPoj
    {
        double Kaliber { get; set; }

        void Ognia();

        void Prezentuj();
    }
    interface IPojLadWoj : IPojLad, IPojWoj
    { }
    interface IPojPowWoj : IPojPow, IPojWoj
    { }
    interface IPojWodWoj : IPojWod, IPojWoj
    { }
    interface IPojLadWodWoj : IPojWod, IPojLad, IPojWoj
    { }
    #endregion
}
