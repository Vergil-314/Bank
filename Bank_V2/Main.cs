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
                    CreateUserAccount(Credentials.GetUsername(), Credentials.GetPassword());
                    break;

                case "3":
                    // ChangePassword();
                    break;

                case "0":
                    isExit = true;
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
                    Admin admin = new(account.Username, account.Password);
                    admin.MainMenu();
                }
                else
                {
                    User user = new(account.Username, account.Password, new Card());
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
            Console.WriteLine("2. Go Back");
            Console.WriteLine("-----------------------------");


            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    isValid = true;
                    CreateUserAccount(username, password);
                    break;
                case "2":
                    isValid = true;
                    MainMenu();
                    break;

            }
        }
    }


    public static void CreateUserAccount(string username, string password)
    {
        if (BankDB.isExist(username))
        {
            Console.Clear();
            Console.WriteLine("Account with such a Username and a Password already Exist\n");
            return;
        }

        int index = BankDB.FindEmptySpaceForUserAccount();

        User user = new(username, password, new Card());
        Console.Clear();

        try
        {
            BankDB.userAccounts[index] = user;
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("There no avaliable space for this account");
        }

        BankDB.PrintFile();
        Console.WriteLine("Account has been Created Succesfully\n");

    }

    public static void CreateAdminAccount(string username, string password)
    {
        int index = BankDB.FindEmptySpaceForAdminAccount();

        Admin admin = new(username, password);
        Console.Clear();

        try
        {
            BankDB.adminAccounts[index] = admin;
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("There no avaliable space for this account");
        }

        BankDB.PrintFile();
        Console.WriteLine("Account has been Created Succesfully\n");
    }
}
