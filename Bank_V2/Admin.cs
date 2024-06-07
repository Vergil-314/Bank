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
            Console.WriteLine("2. Create a New Admin Account");
            Console.WriteLine("3. Create a New User Account");
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
                    Create.AdminAccount(Credentials.GetUsername(), Credentials.GetPassword());
                    break;

                case "3":
                    Create.UserAccount(Credentials.GetUsername(), Credentials.GetPassword());
                    break;

                case "0":
                    isExit = true;
                    Console.Clear();
                    break;
            }

        }
    }


}
