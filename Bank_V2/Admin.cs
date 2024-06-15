namespace Bank;

class Admin : Account
{
    public Admin(string? username = null, string? password = null) : base (username, password)
    {
        IsAdmin = true;
    }


    public void MainMenu()
    {
        Console.Clear();
        bool isExit = false;
        while (!isExit)
        {
            Console.WriteLine("Hello Admin!");
            Console.WriteLine("What would you like to do?\n");

            Console.WriteLine("1. Quit this job");
            Console.WriteLine("2. Change Password");
            Console.WriteLine("3. Change Salary for User");
            Console.WriteLine("3. Create a New Admin Account");
            Console.WriteLine("4. Create a New User Account");
            Console.WriteLine("5. Delete Account");
            Console.WriteLine("0. Log Out");
            Console.WriteLine("-----------------------------");

            string choice = Console.ReadLine();

            Console.Clear();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("\t----ЫДи НахУЙ----\n");
                    break;

                case "2":
                    ChangePassword();
                    break;

                case "3":
                    ChangeSalary(Credentials.GetUsername("Enter Username: "));
                    break;

                case "4":
                    BankDB.CreateAccount(Credentials.GetUsername("Enter Username: "), Credentials.GetPassword("Enter Password: "), true);
                    break;

                case "5":
                    BankDB.CreateAccount(Credentials.GetUsername("Enter Username: "), Credentials.GetPassword("Enter Password: "), false);
                    break;

                case "6":
                    DeleteAccount(Credentials.GetUsername("Enter Username: "));
                    break;

                case "0":
                    isExit = true;
                    Console.Clear();
                    break;
            }

        }
    }

    private void ChangeSalary(string username)
    {
        Console.Clear();
        User user = (User)BankDB.FindAccount(username);

        if (user == null)
        {
            Console.WriteLine("Account is not found");
            return;
        }

        bool isExit = false;
        while (!isExit)
        {
            Console.Write("Set a new salary: ");
            Console.Clear();

            try
            {
                user.Card.Salary = decimal.Parse(Console.ReadLine());
                isExit = true;
            }
            catch (Exception exception)
            {
                Console.Clear();
                Console.WriteLine(exception.Message);
            }
        }
        BankDB.PrintFile();
    }


}
