using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows;
using System.Xml.Linq;

namespace nuttyv1
{
   public class oppo
    {
        public static void operatorcontroller()
        {
            string path1 = "sales.csv";


            Console.Write("would you like to \n 1.Add transaction  \nType the option number:  ");

            string opt = Console.ReadLine();
            switch (opt)
            {
                case "1":                               //Add transaction
                    {
                        string path = "sales.csv";
                        salesmodel.addtrans(6, path);
                        break;
                    }
             
            }
        }
    }
}
