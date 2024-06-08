namespace Bank;

static class BankDB
{
    private const int maxUserAccounts = 7;
    private const int maxAdminAccounts = 3;

    private const int maxAccounts = maxUserAccounts + maxAdminAccounts;

    public static List<Account> accounts = new List<Account>();

    private const string fileName = "Data.txt";


    
    static BankDB()
    {
        // !!!ATTENTION!!!  Change This Directory to Yours
        Directory.SetCurrentDirectory("C:\\Users\\User\\source\\repos\\Bank_V2\\Bank_V2\\Data");

        ReadFile();
    }

    public static void PrintFile()
    {
        using StreamWriter file = new(fileName);

        foreach (var account in accounts)
            if (account != null)
            {
                file.Write(account.Username + " ");
                file.Write(account.Password + " ");

                if (!account.IsAdmin)
                {
                    //file.Write(account.Card.ID + " ");
                    //file.Write(account.Card.Balance + " ");
                    //file.Write(account.Card.Salary);
                }
                file.WriteLine();
            }
        }

    private static void ReadFile()
    {
        using StreamReader file = new(fileName);

        for (int i = 0; i < maxAccounts; i++) // Read Admin's Data
        {
            string str = file.ReadLine() ?? " ";
            string[] data = str.Split(' ');

            try 
            {
                if (i < maxAdminAccounts)
                {
                    Account account = new(data[0], data[1]);
                    accounts.Add(new Admin(account));
                }

                else
                {
                    Account account = new(data[0], data[1]);
                    accounts.Add( new User 
                        (
                        account: account,
                        card: new Card 
                        (
                            id: data[2],
                            balance: decimal.Parse(data[3] ?? "0"),
                            salary: int.Parse(data[4] ?? "0")
                            )
                        ));
                }
            }
            catch (Exception) { }
        }
    }

    private static void SetIsAdmin()
    {
        for (int i = 0; i < maxAccounts; i++)
        {
            if (i >= maxAdminAccounts)
                accounts[i].IsAdmin = false;
            else
                accounts[i].IsAdmin = true;
        }
    }


    public static void AddAccount(string username, string password)
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
                    Create.Account(username, password, false);
                    break;
                case "0":
                    isValid = true;
                    Console.Clear();
                    break;

            }
        }
    }

    public static Account FindAccount(string username)
    {

        foreach (Account account in accounts)
        {
            if (account == null)
                return null;

            if (account.Username == username)
                return account;
        }

        return null;
    }

    public static int FindEmptySpaceForAccount(bool isAdmin) // Need to change the name
    {
        for (int i = 0; i < maxAccounts; i++)
            if (accounts[i] == null)
                return i;

        return -1;
    }

    public static bool isExist(string username)
    {
        if(FindAccount(username) != null)
            return true;

        return false;
    }

    public static bool isCorrect(Account userAccount)
    {
        Account account = FindAccount(userAccount.Username);
        if (account != null && (account.Username == userAccount.Username && account.Password == userAccount.Password))
            return true;

        return false;
    }
    
}
