namespace Bank_V2;

class BankDB
{
    private const int maxAccountCount = 10;
    private const int adminAccountCount = maxAccountCount / 2;
    public static Account[] accounts = new Account[maxAccountCount];

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
