namespace Bank_V2;

class Admin : Account
{
    
    public Admin(string username, string password) : base (username, password)
    {

    }


    public void MainMenu()
    {
        bool isExit = false;
        while (!isExit)
        {
            Console.Clear();

            Console.WriteLine("Hello Admin!");
            Console.WriteLine("What would you like to do?\n");
            Console.WriteLine("1. Quit this job");
            Console.WriteLine("2. Create a New Admin Account");
            Console.WriteLine("3. Create a New User Account");
            Console.WriteLine("0. Log Out");
            Console.WriteLine("-----------------------------");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("ЫДи НахУЙ");
                    break;

                case "2":


                case "0":
                    isExit = true;
                    break;
            }

        }
    }


}
