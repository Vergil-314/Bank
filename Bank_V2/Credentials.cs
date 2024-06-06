namespace Bank_V2;

class Credentials
{
    private static string username;
    private static string password;

    private const int usernameMinLength = 4;
    private const int passwordMinLength = 4;

    public static string Username
    {
        get => username;
        set
        {
            if (Username == null)
                throw new ArgumentNullException("Password Can't Be Empty");

            if (Username.Length < usernameMinLength)
                throw new ArgumentException("Password Can't Be Less Than " + usernameMinLength + " Digits");

            Username = value;
        }
    }

    public static string Password
    {
        get => password;
        set
        {
            if (password == null)
                throw new ArgumentNullException("Password Can't Be Empty");

            if (password.Length < passwordMinLength)
                throw new ArgumentException("Password Can't Be Less Than " + passwordMinLength + " Digits");

            password = value;

        }
    }


    public static string GetUsername()
    {
        bool isValid = false;
        while (!isValid)
        {
            Console.Write("Enter Your Username: ");

            try
            {
                username = Console.ReadLine();
                isValid = true;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

        }
        return username;
    }

    public static string GetPassword()
    {
        bool isValid = false;
        while (!isValid)
        {
            Console.Write("Enter Your Password: ");

            try
            {
                password = Console.ReadLine();
                isValid = true;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

        }
        return password;
    }




}
