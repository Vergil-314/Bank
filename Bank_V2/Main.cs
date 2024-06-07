using Bank_V2;
using System;
using System.Reflection;

namespace Bank_V2;

class Main
{

    public static void MainMenu()
    {
        bool clearConsole = false;
        bool isExit = false;
        while (!isExit)
        {

            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1. Log In");
            Console.WriteLine("2. Sign up");
            Console.WriteLine("3. Change Password");
            Console.WriteLine("0. Quit");
            Console.WriteLine("-----------------------------");


            string option = Console.ReadLine();

            Console.Clear();

            switch (option)
            {
                case "1":
                    LogIn();
                    break;

                case "2":
                    Create.UserAccount(Credentials.GetUsername(), Credentials.GetPassword());
                    break;

                case "3":
                    // ChangePassword();
                    break;

                case "0":
                    isExit = true;
                    BankDB.PrintFile();
                    break;
            }
        }
    }

    private static void LogIn()
    {
        string username = Credentials.GetUsername();
        string password = Credentials.GetPassword();

        Account account = new(username, password);

        if (BankDB.isExist(username))

            if (BankDB.isCorrect(account))

                if (BankDB.IsAdmin)
                {
                    Admin admin = BankDB.FindAdminAccount(username);
                    Console.Clear();
                    admin.MainMenu();
                }
                else
                {
                    User user = BankDB.FindUserAccount(username);
                    Console.Clear();
                    user.MainMenu();
                }
            else
            {
                Console.Clear();
                Console.WriteLine("Username or Password is Incorrect\n");
            }

        else
            AddAccount(username, password);
    }


    private static void AddAccount(string username, string password)
    {
        bool isValid = false;
        while (!isValid)
        {
            Console.Clear();
            Console.WriteLine("This Account Doesn't Exist\n");
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1. Create a New Account");
            Console.WriteLine("0. Go Back");
            Console.WriteLine("-----------------------------");


            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    isValid = true;
                    Create.UserAccount(username, password);
                    break;
                case "0":
                    isValid = true;
                    Console.Clear();
                    break;

            }
        }
    }
    
    
}
