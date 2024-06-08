﻿namespace Bank;

static class Create
{

    public static void Account(string username, string password, bool isAdmin)
    {
        Console.Clear();

        if (BankDB.isExist(username))
        {
            Console.WriteLine("Account with this Username already exist\n");
            return;
        }

        int index;

        Account account;

        if (isAdmin)
        {
            index = BankDB.FindEmptySpaceForAccount(true);
            account = new(username, password);
            Admin admin = new(account);
        }

        else
        {
            index = BankDB.FindEmptySpaceForAccount(false);
            account = new(username, password);
            User user = new User(account, new Card());
        }
        


        try
        {
            BankDB.accounts[index] = account;
        }
        catch (Exception)
        {
            Console.WriteLine("There no avaliable space for this account\n");
            return;
        }

        BankDB.PrintFile();
        Console.WriteLine("Account has been Created Succesfully\n");
    }
}