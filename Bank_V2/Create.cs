namespace Bank_V2;

class Create
{

    public static void UserAccount(string username, string password)
    {
        Console.Clear();

        if (BankDB.isExist(username))
        {
            Console.WriteLine("Account with this Username already exist\n");
            return;
        }

        int index = BankDB.FindEmptySpaceForUserAccount();

        User user = new(username, password, new Card());

        try
        {
            BankDB.userAccounts[index] = user;
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("There no avaliable space for this account\n");
            return;
        }

        BankDB.PrintFile();
        Console.WriteLine("Account has been Created Succesfully\n");

    }

    public static void AdminAccount(string username, string password)
    {
        if(BankDB.isExist(username))
        {
            Console.Clear();
            Console.WriteLine("Account with this Username already exist\n");
            return;
        }

        int index = BankDB.FindEmptySpaceForAdminAccount();

        Admin admin = new(username, password);
        Console.Clear();

        try
        {
            BankDB.adminAccounts[index] = admin;
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("There no avaliable space for this account\n");
            return;
        }

        BankDB.PrintFile();
        Console.WriteLine("Account has been Created Succesfully\n");
    }

}
