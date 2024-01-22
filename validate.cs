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
    class validate
    {

        public static bool loginvalidate(string[] input, string opt)
        {

            bool status = false;
            var lines = File.ReadAllLines("user.csv");
            foreach (var el in lines)
            {
                var values1 = el.Split(',');
                if (values1[0] == opt && values1[1] == input[0] && values1[2] == input[1])
                {
                    File.WriteAllText("status.csv", "true");
                    status = true;
                    break;
                }
            }
            return status;
        }
       
        public static string[] itemvalid(string input, int i)
        {
            string[] content = new string[2];

            bool status = false;
            switch (i)
            {
                case 1:                                                             //description validation
                    {
                        if (input.Length != 0)
                        { status = true; }
                        break;
                    }
                case 2:
                    {       // stock in kgs
                        try
                        {
                            int q = Convert.ToInt32(input);
                            if (q > 0 && input.Length != 0)
                            {
                                status = true;
                            }
                        }
                        catch
                        {
                            status = false;
                        }
                        break;
                    }
                case 3:         // price per kg
                    {
                        try
                        {
                            int q = Convert.ToInt32(input);
                            if (q > 0 && input.Length != 0)
                            {
                                status = true;
                            }
                        }
                        catch
                        {
                            status = false;
                        }
                        break;
                    }
                case 4:         // discount
                    {
                        try
                        {
                            int q = Convert.ToInt32(input);
                            if (q > 0 && input.Length != 0)
                            {
                                status = true;
                            }
                        }
                        catch
                        {
                            status = false;
                        }
                        break;
                    }
            }

            content[0] = input;
            content[1] = Convert.ToString(status).ToLower();

            return content;
        }
        public static string[] transactionvalid(string str, int i, string id)
        {

            string[] content = new string[3];
            content[2] = "0";
            string status = "false";
            switch (i)
            {
                case 0:
                    {
                        CultureInfo enUS = new CultureInfo("en-US");
                        DateTime DayOfBirth;
                        try
                        {
                            DateTime.TryParseExact(str, "dd/MM/yyyy", enUS, DateTimeStyles.None, out DayOfBirth);

                            int totalDays = Convert.ToInt32((DateTime.UtcNow.Date - DayOfBirth.Date).TotalDays);

                            if ((totalDays < 30) && ((DayOfBirth != DateTime.Today.AddDays(1))))
                            {
                                status = "true";
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Invalid date");
                        }
                        break;
                    }
               
                case 1:                                             //item id
                    {
                        string path = "inventory.csv";
                        string[] trandate = admin.returndate(path, str, 0, 1);
                        switch (trandate[1])
                        {
                            case "true":                    // if item is there 
                                {
                                    Console.WriteLine("item description is: " + trandate[0]);
                                    status = "true";
                                    break;
                                }
                            case "false":
                                {
                                    Console.WriteLine("item not found");
                                    break;
                                }
                        }

                        break;
                    }
                case 2:                                             //quantity
                    {
                        string path = "inventory.csv";
                        string[] trandate = admin.returndate(path, id, 0, 2);
                        switch (trandate[1])
                        {
                            case "true":                    // if item there
                                {
                                    try
                                    {
                                        int q = Convert.ToInt32(str);
                                        int st = Convert.ToInt32(trandate[0]);
                                        if (q < st)
                                        {
                                            status = "true";
                                        }
                                        else
                                        {
                                            Console.WriteLine("only {0} are present", st);
                                        }
                                    }
                                    catch
                                    {
                                        status = "false";
                                    }
                                    break;
                                }
                            case "false":
                                {
                                    Console.WriteLine("item not found");
                                    break;
                                }
                        }
                        break;
                    }
            }
            content[0] = str;
            content[1] = status.ToLower();
            return content;
        }




    }
}
