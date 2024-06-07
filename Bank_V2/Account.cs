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

    protected string ChangePassword() => Credentials.GetPassword("Enter new Password: ");


}
