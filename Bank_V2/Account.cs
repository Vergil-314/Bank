namespace Bank_V2;

class Account
{
    private int accountCount = 0;

    protected string username;
    protected string password;

    private const int usernameMinLength = 4;
    private const int passwordMinLength = 4;

    public string Username
    {
        get => username;
        set
        {
            if (value == "")
                throw new ArgumentException("Username Can't Be Empty");

            if (value.Length < usernameMinLength)
                throw new ArgumentException("Username Can't Be Less Than " + usernameMinLength + " Digits");

            if (value.Contains(' '))
                throw new ArgumentException("Username Can't Contain Spaces");

            username = value;
        }
    }

    public string Password
    {
        get => password;
        set
        {
            if (value == "")
                throw new ArgumentException("Password Can't Be Empty");

            if (value.Length < passwordMinLength)
                throw new ArgumentException("Password Can't Be Less Than " + passwordMinLength + " Digits");

            if (value.Contains(' '))
                throw new ArgumentException("Password Can't Contain Spaces");

            password = value;

        }
    }

    protected object isAdmin;
    public bool IsAdmin
    {
        get
        {
            if (isAdmin is User)
                return true;
            return false;
        }
    }


    public Account(string username, string password)
    {
        accountCount += 1;
        this.username = username ?? ("Undefined" + accountCount);
        this.password = password ?? ("Undefined" + accountCount);

    }

    protected void ChangePassword()
    {
        Password = Credentials.GetPassword("Enter new Password: ");
        Console.Clear();
        BankDB.PrintFile();
    }


    protected void DeleteAccount(string username)
    {
        Console.Clear();

        for (int i = 0; i < BankDB.accounts.Count; i++)
            if (BankDB.accounts[i].Username == username)
            {
                BankDB.accounts[i] = null;
                Console.Clear();
                Console.WriteLine("Account has been Deleted\n");
                BankDB.PrintFile();
                return;
            }
    }


}
