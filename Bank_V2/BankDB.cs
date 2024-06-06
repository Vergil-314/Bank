namespace Bank_V2;

class BankDB
{
    private const int maxAccountCount = 10;
    private const int adminAccountCount = maxAccountCount / 2;
    public static Account[] accounts = new Account[maxAccountCount];

    public static bool isExist(Account userAccount)
    {
        foreach (Account account in accounts)
            if (account.Username == userAccount.Username)
                return true;

        return false;
    }


}
