namespace Algo_Hazi
{

    internal struct TombElem
    {
        public int Elo;
        public int Kulcs;
        public int Kov;
    }

    internal class TombosLista
    {
        public TombosLista(int kapacitas) 
        {
            A = new TombElem[kapacitas + 1];
            Fej = 0;
        }

        public TombElem[] A;
        public int Fej;


        public int Elemszam()
        {
            int db = 0;
            int p = Fej;
            while (p != 0)
            {
                db++;
                p = A[p].Kov;
            }
            return db;
        }

        public void Kiir()
        {
            int p = Fej;
            while(p != 0)
            {
                Console.WriteLine(A[p].Kulcs);
                p = A[p].Kov;
            }
        }

        public int Keres(int kulcs)
        {
            int p = Fej;
            while (p != 0)
            {
                if (A[p].Kulcs == kulcs)
                    return p;
                p = A[p].Kov;
            }
            return 0;
        }


        public void BeszurElejere(int hely,  int kulcs)
        {
            A[hely].Kulcs = kulcs;
            A[hely].Elo = 0;
            A[hely].Kov = Fej;

            if (Fej != 0)
                A[Fej].Elo = hely;

            Fej = hely;
        }

        public void BeszurVegere(int hely, int kulcs)
        {
            if (Fej == 0)
            {
                A[hely].Kulcs = kulcs;
                A[hely].Elo = 0;
                A[hely].Kov = 0;
                Fej = hely;
            }
            else
            {
                int p = Fej;
                while (A[p].Kov != 0)
                {
                    p = A[p].Kov;
                }
                A[hely].Kulcs = kulcs;
                A[hely].Elo = p;
                A[hely].Kov = 0;
                A[p].Kov = hely;
            }
        }

        public void BeszurUtan(int elozo, int hely, int kulcs)
        {
            int kov = A[elozo].Kov;

            A[hely].Kulcs = kulcs;
            A[hely].Elo = elozo;
            A[hely].Kov = kov;

            A[elozo].Kov = hely;
            if (kov != 0)
                A[kov].Elo = hely;
        }

        public void TorolKozepso(int hely)
        {
            int elo = A[hely].Elo;
            int kov = A[hely].Kov;

            A[elo].Kov = kov;
            A[kov].Elo = elo;
        }

        public void TorolElso()
        {
            int uj = A[Fej].Kov;
            if (uj != 0)
                A[uj].Elo = 0;
            Fej = uj;
        }

        public void TorolUtolso()
        {
            int p = Fej;
            while (A[p].Kov != 0)
            {
                p = A[p].Kov;
            }

            int elo = A[p].Elo;
            if (elo == 0)
                Fej = 0;
            else
                A[elo].Kov = 0;
        }

        public bool TorolKulcs(int kulcs)
        {
            int p = Keres(kulcs);
            if (p == 0)
                return false;

            if (A[p].Elo == 0)
                TorolElso();
            else if (A[p].Kov == 0)
                TorolUtolso();
            else
                TorolKozepso(p);

            return true;

        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            #region Üres lista
            TombosLista empty = new TombosLista(10);
            Console.WriteLine(empty.Fej);
            Console.WriteLine(empty.Elemszam());
            Console.WriteLine(empty.Keres(500));
            empty.Kiir();

            Console.ReadKey();
            Console.Clear();
            #endregion

            #region Egy tagú lista
            TombosLista one = new TombosLista(10);
            one.A[4].Kulcs = 500;
            one.A[4].Elo = 0;
            one.A[4].Kov = 0;
            one.Fej = 4;

            Console.WriteLine(one.Elemszam());
            Console.WriteLine(one.Keres(500));
            Console.WriteLine(one.Keres(999));
            one.Kiir();

            Console.ReadKey();
            Console.Clear();
            #endregion

        }
    }
}
