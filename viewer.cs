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
    public class viewer
    {
        public virtual void adminmodel(int len, string path)
        {
            //int len = 0;
            int i = 1;


            string[] item = new string[len];
            item[0] = DateTime.Now.ToString("MMddyyyymmssff");

            string[] content = new string[2];
            content[1] = "false";

            do
            {
                content = operating(i, len);

                item[i] = content[0];
                i++;
            } while (content[1] == "true" && i < item.Length);

            switch (content[1])
            {
                case "true":
                    {
                        admin.appendtofile(item, path);
                        Console.Write($"data is  successfully added to the file {path}");
                        break;
                    }
                case "false":
                    {
                        Console.Write("limit exceeded");
                        break;
                    }
            }
        }
        public static string input(int i, int len)                // reused
        {

            string[] item = new string[len];
            switch (len)
            {
                case 5:                     // item
                    {
                        item = new string[] { "Id", "item Name", "stock(in kgs)", "price(per 1kg)", "discount" };
                        break;
                    }
                
                case 6:                     //trans
                    {
                        item = new string[] { "date(DD/MM/YYYY)",  "enter item id", "enter the quantity", "description:", "price for retail/wholsale", "total price is" };
                        break;
                    }
             
            }
            string input;
            Console.WriteLine("Enter the  " + item[i] + ":");
            input = Console.ReadLine();

            return input;
        }
        public virtual string[] operating(int ii, int len)
        {
            string[] content = new string[2];

            content[1] = "false";
            int count = 0;

            content = validate.itemvalid(input(ii, len), ii);


            count++;

            while (count < 3 && content[1] == "false")
            {

                Console.Write("invalid data type again");
                content = validate.itemvalid(input(ii, len), ii);

                count++;
            }
            return content;
        }

    }

}

