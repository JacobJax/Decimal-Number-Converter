using System;
using System.Collections.Generic;

namespace DecimalNumConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                Console.WriteLine("\n Welcome to Decimal number converter\n");
                Console.WriteLine("Enter number: ");

                int number = set_Integer(Console.ReadLine());
                if (number < 1)
                {
                    number = 1;
                }

                show_menu();

                int option = set_Integer(Console.ReadLine());
                while(true)
                {
                    if(!check_scope(option))
                    {
                        switch (option)
                        {
                            case 1:
                                Console.WriteLine(number + " To Binary: " + convertToBinary(number));
                                break;
                            case 2:
                                Console.WriteLine(number + " To Hexadecimal: " + convertToHexa(number));
                                break;
                            case 3:
                                Console.WriteLine(number + " To Octal: " + convertToOctal(number));
                                break;
                            case 4:
                                Console.WriteLine(number + " Binary value: " + convertToBinary(number) +
                                "\n" + number + " Hexadecimal value: " + convertToHexa(number) +
                                "\n" + number + " Octal value: " + convertToOctal(number)
                                );
                                break;
                        }
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nChoice not within scope");
                        show_menu();
                        option = set_Integer(Console.ReadLine());
                    }
                }

                // Ask user to go again
                Console.WriteLine("\n\nDo you wish to continue");
                Console.WriteLine("Press \"n\" or type \"no\" to opt out");
                Console.WriteLine("Press any OTHER key to continue");
                string response = Console.ReadLine();
                string e_response = "no";
                if(string.Compare(response.ToLower().Substring(0, 1), e_response.Substring(0, 1)) == 0)
                {
                    Console.WriteLine("Thanks for stopping by, BYE!!");
                    break;
                }         
                else
                {
                    continue;
                } 
            }
        }

        static void show_menu() // Method to display the menu
        {
            Console.WriteLine("Chose an Operation");
            Console.WriteLine("1. Convert to Binary");
            Console.WriteLine("2. Convert to Hexadecimal");
            Console.WriteLine("3. Convert to Octal");
            Console.WriteLine("4. Convert to all");
        }

        static int set_Integer(string num) // Method to convert user's input into double
        {
            int convNum;
            while (true)
            {
                try
                {
                    convNum = Convert.ToInt32(num);
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Wrong Entry Try again");
                    num = Console.ReadLine();
                }
                
            }

            return convNum;
        }

        static bool check_scope(double num) // Check scope of an entry
        {
            return num < 1 || num > 4;
        }

        static string convertToBinary(int number)
        {
            List<string> conv_num = new List<string>();
            while(number > 0)
            {
                conv_num.Add((number % 2).ToString());
                number = Convert.ToInt32(number / 2);
            }
            return reverse(conv_num.ToArray());
        }

        static string convertToOctal(int number)
        {
            List<string> conv_num = new List<string>();
            while(number > 0)
            {
                conv_num.Add((number % 8).ToString());
                number = Convert.ToInt32(number / 8);
            }
            return reverse(conv_num.ToArray());
        }

        static string convertToHexa(int number)
        {
            string[] hex_map = {"0","1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F"};
            List<string> hex_value = new List<string>();

            List<int> conv_num = new List<int>();
            while(number > 0)
            {
                conv_num.Add(number % 16);
                number = Convert.ToInt32(number / 16);
            }

            for (int i = 0; i < conv_num.Count; i++)
            {
                hex_value.Add(hex_map[conv_num.ToArray()[i]]);
            }
            return reverse(hex_value.ToArray());
        }
        static string reverse(string[] anArr)
        {
            string reversedArr = "";
            for (int i = anArr.Length - 1; i >= 0; i--)
            {
                reversedArr += anArr[i];
            }
            return reversedArr;
        }
    }
}
