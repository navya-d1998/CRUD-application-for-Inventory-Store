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
    class Program
    {
        static void admin1()
        {
            controller("u");
        }
        static void Op()
        {
            controller("o");
        }
        static void controller(string opt)
        {
            string path = "user.csv";
            bool status = false;
            try
            {
                status = getdata(opt);
                if (status == true)
                {
                    Console.Write("successfully logged in\n");
                    switch (opt)
                    {
                        case "u":
                            {
                                admin.admincontroller();

                            }
                            break;

                        case "o":
                            {
                                oppo.operatorcontroller();
                            }
                            break;
                    }
                }
                else
                {
                    Console.Write("limit exceeded");
                }
            }
            catch (Exception e)
            {
                //admin.admincontroller();
                Console.WriteLine(e);
                Console.Write("file not found  55");
            }
        }
        static string[] input()
        {
            string[] input = new string[2];
            Console.Write("enter username: ");
            input[0] = Console.ReadLine();
            Console.Write("enter password: ");
            input[1] = Console.ReadLine();

            return input;
        }
        static bool getdata(string opt)
        {
            bool status = false;
            int count = 0;
            status = validate.loginvalidate(input(), opt);
            count++;
            while (count < 3 && status == false)
            {
                Console.Write("\ninvalid credentials type again\n");
                status = validate.loginvalidate(input(), opt);
                count++;
            }

            return status;

        }
        static void Main(string[] args)
        {

            string opt;
            do
            {
                Console.Write(" login as \n 1.Admin\n 2.operator \nType the option number:  ");
                opt = Console.ReadLine();
                switch (opt)
                {
                    case "1":
                        {
                            admin1();
                            break;
                        }
                    case "2":
                        {
                            Op();
                            break;
                        }
                    default:
                        Console.WriteLine("\n invalid option");
                        break;
                }
                Console.WriteLine("\n press ENTER to continue or 0 to Exit ");
            } while (Console.ReadLine() != "0");
            Console.ReadLine();
        }
    }
}
