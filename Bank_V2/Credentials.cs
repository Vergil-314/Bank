namespace Bank;

class Credentials
{
    private static string username;
    private static string Username
    {
        get
        {
            return username;
        }
        set
        {
            new Account().Username = value;
            username = value;
        }
    }


    private static string password;
    private static string Password
    {
        get
        {
            return password;
        }
        set
        {
            new Account().Password = value;
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
                Console.WriteLine(exception.Message + "\n");
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
