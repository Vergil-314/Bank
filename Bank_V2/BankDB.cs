namespace Bank_V2;

class BankDB
{
    private const int maxAccountCount = 10;
    public static Account[] accounts = new Account[maxAccountCount];

    private const string fileName = "Data.txt";

    static BankDB()
    {
        Directory.SetCurrentDirectory("C:\\Users\\User\\source\\repos\\Bank_V2\\Bank_V2\\Data");
    }

    private static void PrintFile()
    {
        using StreamWriter file = new(fileName);

        foreach (Account account in accounts)
            Console.WriteLine(account.Username + " " + account.Password);
    }

    private static void ReadFile()
    {
        using StreamReader file = new(fileName);

        for (int i = 0; i < maxAccountCount; i++)
        {
            string str = file.ReadLine();
            string[] credentials = str.Split(' ');

            try
            {
                accounts[i] = new Account(credentials[0], credentials[1]);
            }
            catch (Exception) { }

        }

    }

    public static bool IsAdmin { get; set; }

    public static bool isExist(Account userAccount)
    {
        IsAdmin = true;
        for (int i = 0; i < maxAccountCount; i++)
            if (accounts[i].Username == userAccount.Username)
            {
                if (i > adminAccountCount)
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




}
