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
    class admin
    {
        public static void admincontroller()
        {
            Console.WriteLine("would you like to: \n1.Add Item \ntype an option: ");
            string opt = Console.ReadLine();
            switch (opt)
            {
                case "1":
                    {
                        string path = "inventory.csv";
                        viewer add = new viewer();
                        add.adminmodel(5, path);
                        break;
                    }
            
            }
        }

        public static void appendtofile(string[] arr, string path)
        {
            string total = "";

            for (int i = 0; i < arr.Length; i++)
            {
                total = total + arr[i];
                if (i != (arr.Length - 1))
                {
                    total = total + ",";
                }
            }
            File.AppendAllText(path, $"{total}\n");
            Console.Write($"data is  successfully added to the file {path}");
        }
        public static string[] returndate(string path, string id, int idpos, int outputpos)
        {

            var lines1 = File.ReadAllLines(path);
            // finding the transaction date of customerid
            string[] trandate = new string[2];

            trandate[1] = "false";
            trandate[0] = "";
            string[,] cus = filetoarray(path);

            for (int j = 0; j < lines1.Length; j++)
            {

                if (cus[j, idpos] == id)
                {

                    trandate[0] = cus[j, outputpos];
                    trandate[1] = "true";
                    //  Console.WriteLine(trandate[0]);
                    break;
                }
            }

            return trandate;
        }


        public static string[,] filetoarray(string path)           //storing
        {

            var lines = File.ReadAllLines(path);          // a method which stores the data into a string and itll return the array
            var count = lines[0].Split(',');
            string[,] arr = new string[lines.Length, count.Length];

            for (int j = 0; j < lines.Length; j++)
            {
                var values = lines[j].Split(',');
                for (int y = 0; y < values.Length; y++)
                {
                    arr[j, y] = values[y];
                }
            }
            return arr;
        }


    }
}
