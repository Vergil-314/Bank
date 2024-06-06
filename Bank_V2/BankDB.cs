namespace Bank_V2;

class BankDB
{
    private const int maxAccountCount = 10;
    private const int maxAdminAccountCount = 3;
    public static Account[] accounts = new Account[maxAccountCount];

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

        foreach (Account account in accounts)
            file.WriteLine(account.Username + " " + account.Password);
    }

    private static void ReadFile()
    {
        using StreamReader file = new(fileName);

        for (int i = 0; i < maxAccountCount; i++)
        {
            string str = file.ReadLine() ?? " ";

            try 
            {
                string[] credentials = str.Split(' ');

                accounts[i] = new Account(credentials[0], credentials[1]);
            }
            catch (Exception) { }

        }

    }


    public static bool isExist(Account userAccount)
    {
        IsAdmin = true;
        for (int i = 0; i < maxAccountCount; i++)
            if (accounts[i].Username == userAccount.Username)
            {
                if (i > maxAccountCount / 2)
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

    public static int FindEmptyAccount()
    {
        for (int i = 0; i < maxAccountCount; i++)
            if (accounts[i].Username == "")
                return i;
        return -1;
    }


}
