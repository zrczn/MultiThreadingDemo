using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Wielowatkowosc
{
    public static class Class1
    {
        //public delegate string DelOb();
        //public delegate bool DelPO(bool isVisible);
        //public delegate void DelCP(System.Windows.Forms.TextBox txtBx);
        //public delegate (int, int, int) DelRGB();
        public static int fiboRzad { get; set; } 

        public static string Obliczenia()
        {
            fiboRzad++;

            Random rnd = new Random();
            Random rnd2 = new Random();

            int value = default;

            if (value % 2 == 0)
                value = rnd.Next(1, 10_000);
            else
                value = rnd2.Next(1, 10_000);

            Thread.Sleep(10);

            return $"{value}, ";

        }

        public static bool PokazOkno(bool isVisible)
        {

            if (isVisible)
                return false;

            if (!isVisible)
                return true;


            return false;
        }

        public static (int, int, int) RGB()
        {
            Random rnd = new Random();

            int r = rnd.Next(1, 255);
            int g = rnd.Next(1, 255);
            int b = rnd.Next(1, 255);

            Thread.Sleep(200);

            return (r, g, b);
        }
    }
}
