namespace Bank;

class Account
{

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

    public bool IsAdmin { get; set; }

    /*private Card card;
    public Card Card
    {
        get
        {
            if (BankDB.FindAccount(Username).IsAdmin == true)
                return null;
            return card;
        }
        set
        {
            card = value;
        }
    }*/

    public Account(string? username = null, string? password = null)
    {
        this.username = username ?? "Undefined";
        this.password = password ?? "Undefined";
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

        for (int i = 0; i < BankDB.accounts.Capacity; i++)
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
