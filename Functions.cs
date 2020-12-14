using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoolHelper
{
    class Functions
    {
        
        #region Properties
        public int FirstParam
        { get; set; }

        public int SecondParam
        { get; set; }

        public string Command
        { get; set; }

        public bool IsExit
        { get; set; }
        #endregion




        #region Doers
        public string Transbin (string a)
        {
            string s = string.Empty;
            int y;

            if (int.TryParse(a, out int x))
            {
                while (x > 0)
                {
                    y = x % 2;
                    s = y.ToString() + s;
                    x = Div(x, 2);
                }
            }
            while (s.Length < 5)
            {
                s = "0" + s;
            }

            return s;
        }
        public string Transbin(int a)
        {
            string s = string.Empty;
            int y;

            
            while (a > 0)
            {
                y = a % 2;
                s = y.ToString() + s;
                a = Div(a, 2);
            }
            while (s.Length < 5)
            {
                s = "0" + s;
            }


            return s;
        }

        public int Div (int a, int b)
        {
            int k = 0;
            while (a >= b)
            {
                a -= b;
                k++;
            }
            return k;
        }

        public int Transdec (string a)
        {
            int x = 0;
            for (int y = 0; y < a.Length; y++)
            {
                if (a[a.Length - 1 - y] == '1')
                {
                    x += (int)Math.Pow(2, y);
                }
            }
            return x;
        }

        public string[] FoundNear(string binch)
        {
            string[] s = new string[binch.Length];
            string t = string.Empty;

            for (int i = 0; i < binch.Length; i++)
            {
                for (int x = 0; x < i; x++)
                {
                    t += binch[x];
                }
                switch (binch[i])
                {
                    case '1':
                        t += '0';
                        break;

                    case '0':
                        t += '1';
                        break;
                }
                for (int y = i+1; y < binch.Length; y++)
                {
                    t += binch[y];
                }
                s[i] = t;
                t = string.Empty;
            }

            return s;
        }

        public string[] Sort (string[] a)
        {
            string[] b = new string[a.Length];
            int[] bins = new int[a.Length];
            int m;
            for (int i = 0; i < a.Length; i++)
            {
                bins[i] = Transdec(a[i]);
            }
            for (int i = 0; i < a.Length; i++)
            {
                m = bins.Min();
                b[i] = Transbin(m);
                bins[Array.IndexOf(bins, m)] = int.MaxValue;
            }
            return b;
        }

        public void Detector (string a)
        {
            string c = string.Empty;
            string fs = string.Empty;
            string ss = string.Empty;
            bool endcomm = false;
            bool endfirst = false;
            bool endsecond = false;
            int i = 0;
            foreach (char r in a)
            {
                switch (r)
                {
                    case '[':
                        endcomm = true;
                        break;
                    case ',':
                        endfirst = true;
                        break;
                    case ']':
                        endfirst = true;
                        endsecond = true;
                        break;
                }
                if (!endcomm)
                {
                    c += r;
                }
                if(endcomm && !endfirst && r != '[')
                {
                    fs += r;
                }
                if (endcomm && endfirst && !endsecond && r != ',')
                {
                    ss += r;
                }
            }
            switch (c)
            {
                case "1":
                    Command = "One";
                    break;

                case "help":
                    Command = "Help";
                    break;

                case "exit":
                    Command = "Exit";
                    break;
            }
            if (int.TryParse(fs, out int f))
            {
                FirstParam = f;
            }

            if(int.TryParse(ss, out int s))
            {
                SecondParam = s;
            }

        }

        public void Selector()
        {
            switch (Command)
            {
                case "One":
                    One(Transbin(FirstParam));
                    break;

                case "Help":
                    Help();
                    break;

                case "Exit":
                    Exit();
                    break;
            }
        }

        #endregion

        #region OutWriters

        public void Help ()
        {
            Console.WriteLine("Список команд, исполняемых программой:\n" +
                "\t1[число] - Найти все соседние склейки числа;\n" +
                "\texit - Выйти из программы");
        }

        public void One(string a)
        {
            string[] outp = Sort(FoundNear(a));
            Console.Write("\nНайдены склейки:\n" +
                "\t" + a + " = " + Transdec(a) + " [Заданное число]\n");
            Console.Write("\t");
            foreach (char i in a)
            {
                Console.Write('_');
            }
            Console.Write("\n");
            foreach (string s in outp)
            {
                Console.Write("\t" + s + " = " + Transdec(s) + "\n");
            }
            Console.Write("Вывод завершён.");
        }

        public void Exit()
        {
            IsExit = true;
        }

        #endregion
    }
}
