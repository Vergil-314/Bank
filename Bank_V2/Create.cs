namespace Bank_V2;

class Create
{

    public static void UserAccount(string username, string password)
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
            Console.WriteLine("There no avaliable space for this account\n");
            return;
        }

        BankDB.PrintFile();
        Console.WriteLine("Account has been Created Succesfully\n");

    }

    public static void AdminAccount(string username, string password)
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
            Console.WriteLine("There no avaliable space for this account\n");
            return;
        }

        BankDB.PrintFile();
        Console.WriteLine("Account has been Created Succesfully\n");
    }

}
