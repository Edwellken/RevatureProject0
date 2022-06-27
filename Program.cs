using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Bankapp
{
    class Program
    {
        public static int choice = 0;
        public static bool asAdmin = false;

        public static void SetasAdmin(bool p)
        {
            asAdmin = p;
        }

        public static bool GetasAdmin()
        {
            return asAdmin;
        }

        public static void SetChoice(int p)
        {
            choice = p;
        }

        public static int GetChoice()
        {
            return choice;
        }
        public static void LoginAttempt()
        {
            //string adminuName = "Edmin";
            //string adminPassword = "apass";
            //string customeruName = "Edward";
            //string customerPassword = "1234";
            bool attemptLogin = true;
            while (attemptLogin == true)
            {
                //Console.WriteLine("Please Log in");
                //Console.WriteLine("1. Admin");
                //Console.WriteLine("2. Customer");
                //Console.WriteLine("3. Cancel");

                Console.Clear();
                if (attemptLogin == true)
                {
                    Console.WriteLine("Enter username");
                    string uNameInput = Console.ReadLine();
                    Actor LoginActor = new Actor("Server=LAPTOP-V6CGBR6G\\EDWARDINSTANCE;Database=Bankdb;integrated security=True;", uNameInput);
                    if (LoginActor.GetId() == 0)
                    {
                        Console.WriteLine("Invalid username.");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Enter password");
                        string pWordInput = Console.ReadLine();
                        if (LoginActor.GetPass() == pWordInput)
                        {
                            if (LoginActor.GetIsAdmin() == true)
                            {
                                Console.WriteLine("Admin login success.");
                                attemptLogin = false;
                                Program.SetasAdmin(true);
                                Console.ReadKey();
                                Menu();
                            }
                            else
                            {
                                Console.WriteLine("Customer login success.");
                                attemptLogin = false;
                                Program.SetasAdmin(false);
                                Console.ReadKey();
                                Menu();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid password.");
                            Console.ReadKey();
                        }
                    }

                }

            }

        }

        public static void  Menu()
        {
            Console.Clear();
            if (asAdmin == true)
            {
                Console.WriteLine("Admin Menu:");
                Console.WriteLine("1. Create new account");
                Console.WriteLine("2. View all account details");
                Console.WriteLine("3. Perform a Withdrawal");
                Console.WriteLine("4. Perform a Deposit");
                Console.WriteLine("5. Perform a Transfer");
                Console.WriteLine("6. Disable an account");
                Console.WriteLine("7. Activate blocked account");
                Console.WriteLine("8. Log out");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Customer Menu:");
                Console.WriteLine("1. Check Balance");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Deposit");
                Console.WriteLine("4. Transfer");
                Console.WriteLine("5. View last 10 transactions");
                Console.WriteLine("6. Change password");
                Console.WriteLine("7. Log out");
                Console.ReadKey();
            }
            
        }
        static void Main(string[] args)
        {
            string connectionString = "Server=LAPTOP-V6CGBR6G\\EDWARDINSTANCE;Database=Bankdb;integrated security=True;";

            //Console.ReadKey();


            bool outerMenu = true;
            while (outerMenu == true)
            {
                Console.Clear();
                Console.WriteLine("1: Login");
                Console.WriteLine("2: Exit");
                Program.SetChoice(Convert.ToInt32(Console.ReadLine()));
                switch (Program.GetChoice())
                {
                    case 1:
                        LoginAttempt();
                        break;
                    case 2:
                        outerMenu = false;
                        break;
                    default:
                        Console.WriteLine("Invalid selection.");
                        break;
                }
            }
            //string uNTest = "Edmin";
            //Actor AdminTest = new Actor(connectionString, uNTest);

        }
    }
}
