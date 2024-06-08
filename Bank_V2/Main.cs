﻿namespace Bank;

class Main
{

    public static void MainMenu()
    {
        bool isExit = false;
        while (!isExit)
        {

            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1. Log In");
            Console.WriteLine("2. Sign up");
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
                    Create.Account(Credentials.GetUsername(), Credentials.GetPassword(), false);
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
            {
                Console.Clear();

                try
                {
                    Admin admin = (Admin)BankDB.FindAccount(username);
                    admin.MainMenu();
                }
                catch (Exception) 
                {
                    User user = (User)BankDB.FindAccount(username);
                    user.MainMenu();
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Username or Password is Incorrect\n");
            }

        else
            BankDB.AddAccount(username, password);
    }

}
