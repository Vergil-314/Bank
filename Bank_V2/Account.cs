namespace Bank_V2;

class Account
{

    public string Username { get; set; }

    public string Password { get; set; }

    public Account(string username, string password)
    {
        Username = username;
        Password = password;
    }

    protected void ChangePassword()
    {
        Password = Credentials.GetPassword("Enter new Password: ");
        Console.Clear();
        BankDB.PrintFile();
    }


}
