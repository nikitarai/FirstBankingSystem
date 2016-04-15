﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BankingSystem1
{
    class Program
    {
        static void Main(string[] args)
        {
            //instantiate new object from client class

            Clients user = new Clients("John Smith");

            //instantiate new object from accounts class
            user.Accounts = new Accounts(user.Name);           


            //calling menu method, passing client and account through
            Menu(user.Accounts, user);
            
        }

        static void Menu(Accounts test, Clients user)
        {
            //display bank menu options
            Console.WriteLine("The First Bank");
            Console.WriteLine("Account Menu");
            Spacer();
            Console.WriteLine("1 | View Client Information");
            Console.WriteLine("2 | View Account Balance");
            Console.WriteLine("3 | Deposit Funds");
            Console.WriteLine("4 | Withdraw Funds");
            Console.WriteLine("5 | Exit");


            //do while loop to give user ability to keep accessing above menu
            string loop = "Y";
            do
            {
                // get user input and use input in switch case
                Console.WriteLine( );
                Console.Write("Enter a Menu Option: ");
                int options = int.Parse(Console.ReadLine());
                Spacer();


                
                switch (options)
                {
                    case 1:
                        user.Info();
                        break;
                    case 2:
                        user.Balance();
                        break;
                    case 3:
                        Console.Write("Enter Amount to Deposit: ");
                        decimal depositAmount = decimal.Parse(Console.ReadLine());

                        test.Deposit(depositAmount);
                        break;
                    case 4:
                        Console.Write("Enter Amount to Withdraw: ");
                        decimal withdrawAmount = decimal.Parse(Console.ReadLine());

                        test.Withdraw(withdrawAmount);
                        break;
                    case 5:
                        loop = "N";
                        
                        Console.WriteLine("Thank you for banking at The First Bank \nWhere we always put you first.");
                        break;
                    default:
                        break;

                }
            }
            while (loop == "Y");

        }

        static void Spacer()
        {
            Console.WriteLine();
        }
    }
}
