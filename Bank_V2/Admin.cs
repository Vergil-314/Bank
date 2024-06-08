namespace Bank_V2;

class Admin
{
    private readonly Account account;

    public Admin(Account account)
    {
        this.account = account;
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
                    Create.Account(Credentials.GetUsername("Enter Username: "), Credentials.GetPassword("Enter Password: "), true);
                    break;

                case "4":
                    Create.Account(Credentials.GetUsername("Enter Username: "), Credentials.GetPassword("Enter Password: "), false);
                    break;

                case "5":
                    DeleteAccount(Credentials.GetUsername("Enter Username of Account that You want to Delete: "));
                    break;

                case "0":
                    isExit = true;
                    Console.Clear();
                    break;
            }

        }
    }


}
