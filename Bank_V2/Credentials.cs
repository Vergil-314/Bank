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
            if (value == "")
                throw new ArgumentNullException("Username Can't Be Empty");

            if (value.Length < usernameMinLength)
                throw new ArgumentException("Username Can't Be Less Than " + usernameMinLength + " Digits");
            
            if (value.Contains(' '))
                throw new ArgumentException("Username Can't Contain Spaces");

            username = value;
        }
    }

    public static string Password
    {
        get => password;
        set
        {
            if (value == "")
                throw new ArgumentNullException("Password Can't Be Empty");

            if (value.Length < passwordMinLength)
                throw new ArgumentException("Password Can't Be Less Than " + passwordMinLength + " Digits");

            if (value.Contains(' '))
                throw new ArgumentException("Password Can't Contain Spaces");

            password = value;

        }
    }


    public static string GetUsername(string text = "Enter Your Username: ")
    {
        Console.Clear();

        bool isValid = false;
        while (!isValid)
        {
            Console.Write(text);

            try
            {
                Username = Console.ReadLine();
                isValid = true;
            }
            catch (Exception exception)
            {
                Console.Clear();
                Console.WriteLine(exception.Message);
            }

        }
        return Username;
    }

    public static string GetPassword(string text = "Enter Your Password: ")
    {
        Console.Clear();
        Console.WriteLine("Username: " + Username);

        bool isValid = false;
        while (!isValid)
        {
            

            Console.Write(text);

            try
            {
                Password = Console.ReadLine();
                isValid = true;
            }
            catch (Exception exception)
            {
                Console.Clear();
                Console.WriteLine(exception.Message + "\n");
                Console.WriteLine("Username: " + Username);
            }

        }
        return Password;
    }




}
