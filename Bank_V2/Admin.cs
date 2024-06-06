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
            Console.WriteLine("Hello Admin!");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Quit this job");
            Console.WriteLine("9. Log Out");
            Console.WriteLine("0. Exit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    isExit = true;
                    Console.WriteLine("ЫДи НахУЙ");
                    break;
                case "9":
                    isExit = true;
                    // Method LogOut()
                    break;
                case "0":
                    isExit = true;
                    break;
            }

        }
    }


}
