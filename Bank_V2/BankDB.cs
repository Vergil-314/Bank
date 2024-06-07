namespace Bank_V2;

static class BankDB
{
    private const int maxAccountCount = maxUserAccountsCount + maxAdminAccountsCount;
    private const int maxUserAccountsCount = 7;
    private const int maxAdminAccountsCount = 3;

    public static User[] userAccounts = new User[maxUserAccountsCount];
    public static Admin[] adminAccounts = new Admin[maxAdminAccountsCount];

    private const string fileName = "Data.txt";

    static BankDB()
    {
        Directory.SetCurrentDirectory("C:\\Users\\User\\source\\repos\\Bank_V2\\Bank_V2\\Data");

        ReadFile();
    }

    public static bool IsAdmin { get; set; }

    public static void PrintFile()
    {
        using StreamWriter file = new(fileName);

        for (int i = 0; i < maxAdminAccountsCount; i++) // Write Admin Data
            file.WriteLine(adminAccounts[i].Username + " " + adminAccounts[i].Password);

        for (int i = 0; i < maxUserAccountsCount; i++) // Write User Data
        {
            if (userAccounts[i] != null)
            {    
                file.Write(userAccounts[i].Username + " ");
                file.Write(userAccounts[i].Password + " ");
                file.Write(userAccounts[i].Card.ID  + " " + userAccounts[i].Card.Balance);
                file.WriteLine();
            }
        }

    }

    private static void ReadFile()
    {
        using StreamReader file = new(fileName);

        for (int i = 0; i < maxAdminAccountsCount; i++) // Read Admin's Data
        {
            string str = file.ReadLine() ?? " ";
            string[] data = str.Split(' ');

            try 
            {
                adminAccounts[i] = new Admin(data[0], data[1]);
            }
            catch (Exception) { }
        }

        for (int i = 0; i < maxUserAccountsCount; i++) // Read User's Data
        {
            string str = file.ReadLine() ?? "    ";
            string[] data = str.Split(' ');

            try
            {
                userAccounts[i] = new User(data[0], data[1],
                    new Card(data[2], decimal.Parse(data[3])));
            }
            catch (Exception) { }
        }



    }


    public static bool isExist(string username)
    {
        IsAdmin = true;
        foreach (Admin admin in adminAccounts)
            if ((admin.Username) == username)
                return true;

        IsAdmin = false;
        foreach (User user in userAccounts)
            if (user != null)
                if (user.Username == username)
                    return true;

        return false;
    }

    public static bool isCorrect(Account account)
    {
        foreach (Admin admin in adminAccounts)
            if (admin.Username == account.Username && admin.Password == account.Password)
                return true;

        foreach (User user in userAccounts)
            if (user != null)
                if (user.Username == account.Username && user.Password == account.Password)
                    return true;

        return false;
    }

    public static int FindEmptySpaceForUserAccount() // Need to change the name
    {
        for (int i = 0; i < maxUserAccountsCount; i++)
            try
            {
                if (userAccounts[i] == null)
                    return i;
            }
            catch (Exception) { }

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
