namespace Bank_V2;

static class BankDB
{
    private const int maxAccountCount = maxUserAccountsCount + maxAdminAccountsCount;
    private const int maxUserAccountsCount = 7;
    private const int maxAdminAccountsCount = 3;

    public static User[] userAccounts = new User[maxUserAccountsCount];
    public static Admin[] adminAccounts = new Admin[maxAdminAccountsCount];

    public static Account[] accounts = new Account[maxAccountCount];

    private const string fileName = "Data.txt";

    static BankDB()
    {
        Directory.SetCurrentDirectory("C:\\Users\\User\\source\\repos\\Bank_V2\\Bank_V2\\Data");

        //ReadFile();
    }

    public static bool IsAdmin { get; set; }

    public static void PrintFile()
    {
        using StreamWriter file = new(fileName);

        for (int i = 0; i < maxAccountCount; i++) // Write Admin Data
            file.WriteLine(adminAccounts[i].Username + " " + adminAccounts[i].Password);

        for (int i = 0; i < maxUserAccountsCount; i++) // Write User Data
        {
            file.Write(userAccounts[i].Username + " ");
            file.Write(userAccounts[i].Password + " ");
            file.Write(userAccounts[i].Card.ID  + " " + userAccounts[i].Card.Balance);
            file.WriteLine();
        }

    }

    private static void ReadFile()
    {
        using StreamReader file = new(fileName);

        for (int i = 0; i < maxAdminAccountsCount; i++) // Read Admin's Data
        {
            string str = file.ReadLine() ?? " ";
            string[] credentials = str.Split(' ');

            try 
            {
                adminAccounts[i] = new Admin(credentials[0], credentials[1]);
            }
            catch (Exception) { }
        }

        for (int i = 0; i < maxUserAccountsCount; i++)
        {
            string str = file.ReadLine() ?? " ";
            string[] credentials = str.Split(' ');

            try
            {
                userAccounts[i] = new User(credentials[0], credentials[1],
                    new Card(credentials[2], decimal.Parse(credentials[3])));
            }
            catch (Exception) { }
        }


    }


    public static bool isExist(string username)
    {
        IsAdmin = true;
        for (int i = 0; i < maxAccountCount; i++)
            if (accounts[i].Username == username)
            {
                if (i >= maxAdminAccountsCount)
                    IsAdmin = false;
                return true;
            }
        return false;
    }

    public static bool isCorrect(Account userAccount)
    {
        for (int i = 0; i < maxAccountCount; i++)

            if (accounts[i].Username == userAccount.Username && accounts[i].Password == userAccount.Password)
                return true;

        return false;
    }

    public static int FindEmptySpaceForUserAccount() // Need to change the name
    {
        for (int i = 0; i < maxUserAccountsCount; i++)
            if (userAccounts[i].Username == "")
                return i;

        return -1;
    }

    public static int FindEmptySpaceForAdminAccount() // Also need to change the name
    {
        for (int i = 0; i < maxAdminAccountsCount; i++)
            if (adminAccounts[i].Username == "")
                return i;

        return -1;
    }


}
