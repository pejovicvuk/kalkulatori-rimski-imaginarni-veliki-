using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;

namespace kalkulatori__rimski__imaginarni__veliki_
{
    public partial class FormVeliki : Form
    {
        public FormVeliki()
        {
            InitializeComponent();
        }

        public struct BigDecimal
        {
            public BigInteger Integer { get; set; }
            public BigInteger Scale { get; set; }

            public BigDecimal(BigInteger integer, BigInteger scale) : this()
            {
                Integer = integer;
                Scale = scale;
                while (Scale > 0 && Integer % 10 == 0)
                {
                    Integer /= 10;
                    Scale -= 1;
                }
            }

            public static implicit operator BigDecimal(decimal a)
            {
                BigInteger integer = (BigInteger)a;
                BigInteger scale = 0;
                decimal scaleFactor = 1m;
                while ((decimal)integer != a * scaleFactor)
                {
                    scale += 1;
                    scaleFactor *= 10;
                    integer = (BigInteger)(a * scaleFactor);
                }
                return new BigDecimal(integer, scale);
            }

            public static BigDecimal operator *(BigDecimal a, BigDecimal b)
            {
                return new BigDecimal(a.Integer * b.Integer, a.Scale + b.Scale);
            }

            public override string ToString()
            {
                string s = Integer.ToString();
                if (Scale != 0)
                {
                    if (Scale > Int32.MaxValue) return "ne moze";
                    int decimalPos = s.Length - (int)Scale;
                    s = s.Insert(decimalPos, decimalPos == 0 ? "0." : ".");
                }
                return s;
            }
        }

        static List<int>[] IstiNapred(List<int> A,
                                      List<int> B)
        {
            int n = A.Count;
            int m = B.Count;
            int diff = Math.Abs(n - m);

            if (n < m)
            {
                for (var i = 0; i < diff; i++)
                {
                    A.Insert(0, 0);
                }
            }
            else
            {
                for (var i = 0; i < diff; i++)
                {
                    B.Insert(0, 0);
                }
            }

            return new[] { A, B };
        }

        static List<int>[] IstiNazad(List<int> A,
                                           List<int> B)
        {
            int n = A.Count;
            int m = B.Count;
            int diff = Math.Abs(n - m);

            if (n < m)
            {
                for (var i = 0; i < diff; i++)
                {
                    A.Add(0);
                }
            }
            else
            {
                for (var i = 0; i < diff; i++)
                {
                    B.Add(0);
                }
            }

            return new[] { A, B };
        }
        static string VeciBroj(string a, string b)
        {
            if (a.Length > b.Length)
            {
                return a;
            }
            else if (a.Length < b.Length)
            {
                return b;
            }
            else
            {
                for (int i = a.Length - 1; i >= 0; i--)
                {
                    if (Convert.ToInt32(a[i]) > Convert.ToInt32(b[i]))
                    {
                        return a;
                    }
                    else if (Convert.ToInt32(a[i]) < Convert.ToInt32(b[i]))
                    {
                        return b;
                    }
                }
                return a;
            }
        }

        static string Zbir(string s1, string s2)
        {
            //sklanjanje minusa
            int index = s1.IndexOf('-');
            string cleanPath = (index < 0)
                ? s1
                : s1.Remove(index, s1.Length);

            int index2 = s2.IndexOf('-');
            string cleanPath2 = (index2 < 0)
                ? s2
                : s2.Remove(index2, s2.Length);

            int i;

            List<int> Celi1 = new List<int>();
            List<int> Celi2 = new List<int>();
            List<int> Deci1 = new List<int>();
            List<int> Deci2 = new List<int>();

            for (i = s1.Length - 1; i > -1; i--)
            {

                if (s1[i] == '.')
                {
                    break;
                }
                Deci1.Add(s1[i] - '0');
            }

            i--;
            for (; i > -1; i--)
            {
                Celi1.Add(s1[i] - '0');
            }

            for (i = s2.Length - 1; i > -1; i--)
            {

                if (s2[i] == '.')
                {
                    break;
                }
                Deci2.Add(s2[i] - '0');
            }

            i--;
            for (; i > -1; i--)
            {
                Celi2.Add(s2[i] - '0');
            }

            List<int>[] res1 = IstiNapred(Deci1, Deci2);
            List<int>[] res2 = IstiNazad(Celi1, Celi2);
            Deci1 = res1[0];
            Deci2 = res1[1];
            Celi1 = res2[0];
            Celi2 = res2[1];

            int n = Deci1.Count;
            int m = Deci2.Count;
            i = 0;
            int ostatak = 0;

            while (i < n && i < m)
            {

                int sum = Deci1[i] + Deci2[i] + ostatak;

                Deci1[i] = sum % 10;
                ostatak = (sum >= 10) ? 1 : 0;
                i++;
            }

            int N = Celi1.Count;
            int M = Celi2.Count;
            i = 0;


            while (i < N && i < M)
            {
                int sum = Celi1[i] + Celi2[i] + ostatak;
                Celi1[i] = sum % 10;
                ostatak = (sum >= 10) ? 1 : 0;
                i++;
            }

            if (ostatak != 0)
                Celi1.Add(ostatak);

            Celi1.Reverse();
            Deci1.Reverse();

            string celi = string.Join(string.Empty, Celi1);
            string decimalni = string.Join(string.Empty, Deci1);
            return celi + '.' + decimalni;
        }

        static string Razlika(string s1, string s2)
        {
            //sklanjanje minusa
            int index = s1.IndexOf('-');
            string cleanPath = (index < 0)
                ? s1
                : s1.Remove(index, s1.Length);

            int index2 = s2.IndexOf('-');
            string cleanPath2 = (index2 < 0)
                ? s2
                : s2.Remove(index2, s2.Length);

            int i;

            List<int> Celi1 = new List<int>();
            List<int> Celi2 = new List<int>();
            List<int> Deci1 = new List<int>();
            List<int> Deci2 = new List<int>();

            for (i = s1.Length - 1; i > -1; i--)
            {

                if (s1[i] == '.')
                {
                    break;
                }
                Deci1.Add(s1[i] - '0');
            }

            i--;
            for (; i > -1; i--)
            {
                Celi1.Add(s1[i] - '0');
            }

            for (i = s2.Length - 1; i > -1; i--)
            {

                if (s2[i] == '.')
                {
                    break;
                }
                Deci2.Add(s2[i] - '0');
            }

            i--;
            for (; i > -1; i--)
            {
                Celi2.Add(s2[i] - '0');
            }

            List<int>[] res1 = IstiNapred(Deci1, Deci2);
            List<int>[] res2 = IstiNazad(Celi1, Celi2);
            Deci1 = res1[0];
            Deci2 = res1[1];
            Celi1 = res2[0];
            Celi2 = res2[1];

            int n = Deci1.Count;
            int m = Deci2.Count;
            i = 0;
            int ostatak = 0;
            if (VeciBroj(s1, s2) == s1)
            {
                while (i < n && i < m)
                {
                    if ((Deci1[i] - Deci2[i] + ostatak) < 0)
                    {
                        Deci1[i] = 10 + (Deci1[i] - Deci2[i] + ostatak);
                        ostatak = -1;
                    }
                    else
                    {
                        Deci1[i] = (Deci1[i] - Deci2[i]) + ostatak;
                        ostatak = 0;
                    }
                    i++;
                }
            }
            else
            {
                while (i < n && i < m)
                {
                    if ((Deci2[i] - Deci1[i] + ostatak) < 0)
                    {
                        Deci1[i] = 10 + (Deci2[i] - Deci1[i] + ostatak);
                        ostatak = -1;
                    }
                    else
                    {
                        Deci1[i] = (Deci2[i] - Deci1[i]) + ostatak;
                        ostatak = 0;
                    }
                    i++;
                }
            }

            //ostatak = 0;
            string celi;
            string decimalni;

            int N = Celi1.Count;
            int M = Celi2.Count;
            i = 0;
            if (VeciBroj(s1, s2) == s1)
            {
                while (i < N && i < M)
                {
                    if ((Celi1[i] - Celi2[i] + ostatak) < 0)
                    {
                        Celi1[i] = 10 + (Celi1[i] - Celi2[i] + ostatak);
                        ostatak = -1;
                    }
                    else
                    {
                        Celi1[i] = (Celi1[i] - Celi2[i]) + ostatak;
                        ostatak = 0;
                    }
                    i++;
                }
                Celi1.Reverse();
                Deci1.Reverse();

                celi = string.Join(string.Empty, Celi1);
                decimalni = string.Join(string.Empty, Deci1);
                return celi + '.' + decimalni;
            }
            else
            {
                while (i < N && i < M)
                {
                    if ((Celi2[i] - Celi1[i] + ostatak) < 0)
                    {
                        Celi1[i] = 10 + (Celi2[i] - Celi1[i] + ostatak);
                        ostatak = -1;
                    }
                    else
                    {
                        Celi1[i] = (Celi2[i] - Celi1[i]) + ostatak;
                        ostatak = 0;
                    }
                    i++;
                }
                Celi1.Reverse();
                Deci1.Reverse();

                celi = string.Join(string.Empty, Celi1);
                decimalni = string.Join(string.Empty, Deci1);
                return '-' + celi + '.' + decimalni;
            }
        }
        static string Kolicnik(string s1, string s2)
        {
            BigInteger x = new BigInteger(Convert.ToDouble(s1));
            BigInteger y = new BigInteger(Convert.ToDouble(s2));
            return Math.Exp(BigInteger.Log(x) - BigInteger.Log(y)).ToString();

        }
        static string Proizvod(string s1, string s2)
        {
            decimal d1 = Convert.ToDecimal(s1);
            decimal d2 = Convert.ToDecimal(s2);
            // MessageBox.Show((d1 * d2).ToString()); // OverflowException
            BigDecimal bd1 = d1;
            BigDecimal bd2 = d2;
            return ((bd1 * bd2).ToString()); // 252602734305022989458258125319270.5452949161059356
        }



        //izbacuje mi 6 i 7 kad pokusam da radim sa -
        private void buttonPlus_Click(object sender, EventArgs e)
        {
            textBoxRezultat.Text = Zbir(textBoxPrvi.Text, textBoxDrugi.Text);
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            textBoxRezultat.Text = Razlika(textBoxPrvi.Text, textBoxDrugi.Text);
        }

        private void buttonDeljenje_Click(object sender, EventArgs e)
        {
            textBoxRezultat.Text = Kolicnik(textBoxPrvi.Text, textBoxDrugi.Text);
        }
        private void buttonMnozenje_Click(object sender, EventArgs e)
        {
            textBoxRezultat.Text = Proizvod(textBoxPrvi.Text, textBoxDrugi.Text);
        }

    }
}
