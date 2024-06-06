namespace Bank_V2;

class User : Account
{

    public Card Card { get; set; }

    public User(string username, string password, Card card) : base(username, password)
    {
        Card = card;
    }

    public void MainMenu()
    {
        bool isExit = false;
        while (!isExit)
        {
            Console.Clear();

            Console.WriteLine("Hello " + Username + "!");
            Console.WriteLine("What would you like to do?\n");
            Console.WriteLine("1. Get Salary");
            Console.WriteLine("2. Transfer Money");
            Console.WriteLine("0. Log Out");
            Console.WriteLine("-----------------------------");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // Method GetSalary()
                    break;

                case "2":
                    // Method TransferMoney()
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
