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
