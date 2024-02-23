using MathGamer;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace MathGame
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Menu menu = new Menu();



            string name = Helpers.GetName();
            menu.ShowMenu(name);
        }


      

        


       
    }
}



