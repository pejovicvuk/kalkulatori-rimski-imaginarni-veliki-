﻿using System;
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

        // Function to make Integral part
        // with equal digits
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
            if(VeciBroj(s1, s2) == s1)
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
        


        //izbacuje mi 6 i 7 kad pokusam da radim sa -
        private void buttonPlus_Click(object sender, EventArgs e)
        {
            textBoxRezultat.Text = Zbir(textBoxPrvi.Text, textBoxDrugi.Text);
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            textBoxRezultat.Text = Razlika(textBoxPrvi.Text, textBoxDrugi.Text);
        }
    }
}
