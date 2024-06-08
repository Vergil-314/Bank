namespace Bank;

class Credentials
{
    


    public static string GetUsername(string text = "Enter Your Username: ")
    {
        Console.Clear();

        string Username = string.Empty;

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
        //Console.WriteLine("Username: " + Username);
        string Password = string.Empty;

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
                //Console.WriteLine("Username: " + Username);
            }

        }
        return Password;
    }




}
