namespace Bank_V2;

class Bank
{

    public static void MainMenu()
    {
        bool isExit = false;
        while (!isExit)
        {
            Console.Clear();

            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1. Log In");
            Console.WriteLine("2. Sign up");
            Console.WriteLine("3. Change Password");
            Console.WriteLine("0. Quit");

            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    LogIn();
                    break;

                case "2":
                    // CreateAccount();
                    break;

                case "3":
                    // ChangePassword();
                    break;

                case "0":
                    isExit = true;
                    break;
            }
        }
    }


    private static void LogIn()
    {
        Account account = new Account(Credentials.GetUsername(), Credentials.GetPassword());

        if (BankDB.isExist(account))
            if (BankDB.isCorrect(account))
                if (BankDB.IsAdmin)
                {
                    Admin admin = new(account.Username, account.Password);
                    admin.MainMenu();
                }
                else
                {
                    User user = new(account.Username, account.Password, );
                    user.MainMenu();
                }
            else
                Console.WriteLine("Username or Password is Incorrect");

        else
            Console.WriteLine("This Account Doesn't Exist");

    }

    private static void CreateAccount(string username, string password)
    {
        int index = BankDB.FindEmptyAccount();
        BankDB.accounts[index].Username = username;
        BankDB.accounts[index].Password = password;
    }


}
