namespace Bank_V2;

class Delete
{

    public static void UserAccount(string username)
    {
        Console.Clear();

        for (int i = 0; i < BankDB.userAccounts.Length; i++)
            if (BankDB.userAccounts[i].Username == username)
            {
                BankDB.userAccounts[i] = null;
                Console.Clear();
                Console.WriteLine("Account has been Deleted\n");
                BankDB.PrintFile();
                return;
            }
    }

    public static void AdminAccount(string username)
    {
        for (int i = 0; i < BankDB.adminAccounts.Length; i++)
            if (BankDB.adminAccounts[i].Username == username)
            {
                BankDB.adminAccounts[i] = null;
                Console.Clear();
                Console.WriteLine("Account has been Deleted\n");
                BankDB.PrintFile();
                return;
            }
    }

}
