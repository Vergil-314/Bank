namespace Bank_V2;

class User : Account
{

    private Card userCard;
    public Card Card { get => userCard; }

    public User(string username, string password, Card card) : base(username, password)
    {
        userCard = card;
    }

    public void MainMenu()
    {
        bool isExit = false;
        while (!isExit)
        {
            Console.WriteLine("Hello " + Username + " !");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Get Salary");
            Console.WriteLine("2. Transfer Money");
            Console.WriteLine("9. Log Out");
            Console.WriteLine("0. Exit");

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
