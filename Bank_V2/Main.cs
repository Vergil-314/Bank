namespace Bank;

class Main
{

    public static void MainMenu()
    {
        bool isExit = false;
        while (!isExit)
        {

            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1. Log In");
            Console.WriteLine("2. Sign up");
            Console.WriteLine("0. Quit");
            Console.WriteLine("-----------------------------");


            string option = Console.ReadLine();

            Console.Clear();

            switch (option)
            {
                case "1":
                    LogIn();
                    break;

                case "2":
                    BankDB.CreateAccount(Credentials.GetUsername(), Credentials.GetPassword(), false);
                    break;

                case "0":
                    isExit = true;
                    BankDB.PrintFile();
                    break;
            }
        }
    }

    private static void LogIn()
    {
        string username = Credentials.GetUsername();
        string password = Credentials.GetPassword();

        Account account = new(username, password);

        if (BankDB.isExist(username))

            if (BankDB.isCorrect(account))
            {
                Console.Clear();
                account.MainMenu();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Username or Password is Incorrect\n");
            }

        else
            AddAccount(username, password);
    }

    public static void AddAccount(string username, string password)
    {
        bool isValid = false;
        while (!isValid)
        {
            Console.Clear();
            Console.WriteLine("This Account Doesn't Exist\n");
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1. Create a New Account");
            Console.WriteLine("0. Go Back");
            Console.WriteLine("-----------------------------");


            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    isValid = true;
                    BankDB.CreateAccount(username, password, false);
                    break;
                case "0":
                    isValid = true;
                    Console.Clear();
                    break;

            }
        }
    }


}
