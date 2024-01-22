using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nuttyv1
{
    class salesmodel
    {
        public static void addtrans(int len, string path)
        {
            string[] tran = new string[] { "enter date(DD/MM/YYYY)", "enter item id", "enter the quantity:", "description", "price for retail/wholsale", "total price is" };
            string[] content = new string[3];
            Console.WriteLine("enter for which type of sales you want to add options: \n1.retails  \n2.wholesale\n");
            string opt = Console.ReadLine();
            string[] sale = new string[len];
            string id = "";
            int i = 0;
            do
            {
                content = tranoperating(i, len, id);

                sale[i] = content[0];
                id = sale[1];                            // storing item id and sending to check the stock 
                Console.WriteLine(id);
                i++;
            } while (content[1] == "true" && i < sale.Length - 3);

            if (content[1] == "true")
            {
                string path1 = "inventory.csv";

                string[] p = admin.returndate(path1, id, 0, 3);

                string[] d = admin.returndate(path1, id, 0, 4);

                float price = Convert.ToInt32(p[0]);
                float discount = Convert.ToInt32(d[0]);

                string[] ds = admin.returndate(path1, sale[2], 0, 1);

                sale[3] = ds[0];                                // description

                float qq = Convert.ToInt32(sale[2]);
                float yy = price * qq;
                switch (opt)
                {
                    case "1":
                        {
                            sale[4] = p[0];
                            Console.WriteLine("price for 1kg is:{0}", sale[4]);
                            sale[5] = Convert.ToString(yy);
                            Console.WriteLine("total price is:{0}", sale[5]);
                            break;
                        }
                    case "2":
                        {
                            float tt = (price - ((price * discount) / 100));
                            yy = tt * qq;
                            sale[4] = Convert.ToString(tt);
                            Console.WriteLine("price for 1kg is:{0}", sale[4]);
                            sale[5] = Convert.ToString(yy);
                            Console.WriteLine("total price is:{0}", sale[5]);
                            break;
                        }
                }
            }
            switch (content[1])
            {
                case "true":
                    {
                       
                        admin.appendtofile(sale, path);
                        Console.Write($"data is  successfully added to the file {path}");
                        break;
                    }
                case "false":
                    {
                        Console.Write("limit exceeded");
                        break;
                    }
               
                default:
                    break;
            }
        }

        public static string[] tranoperating(int ii, int len, string id)
        {
            string[] content = new string[3];

            content[1] = "false";
            int count = 0;
            int special = 0;
            content = validate.transactionvalid(viewer.input(ii, len), ii, id);

            special = Convert.ToInt32(content[2]);

            count = count + 1 + special;

            while (count < 3 && content[1] == "false")
            {
                Console.WriteLine("invalid data type again\n");
                content = validate.transactionvalid(viewer.input(ii, len), ii, id);
                count++;
            }

            return content;
        }


    }
}
