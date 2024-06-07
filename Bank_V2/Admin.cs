namespace Bank_V2;

class Admin : Account
{
    
    public Admin(string username, string password) : base (username, password)
    {

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
            Console.WriteLine("5. Delete Admin Account");
            Console.WriteLine("6. Delete User Account");
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
                    Password = ChangePassword();
                    break;

                case "3":
                    Create.AdminAccount(Credentials.GetUsername("Enter Username: "), Credentials.GetPassword("Enter Password: "));
                    break;

                case "4":
                    Create.UserAccount(Credentials.GetUsername("Enter Username: "), Credentials.GetPassword("Enter Password: "));
                    break;

                case "5":
                    Delete.AdminAccount(Credentials.GetUsername("Enter Username of Account that You want to Delete: "));
                    break;

                case "6":
                    Delete.UserAccount(Credentials.GetUsername("Enter Username of Account that You want to Delete: "));
                    break;

                case "0":
                    isExit = true;
                    Console.Clear();
                    break;
            }

        }
    }


}
