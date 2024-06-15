namespace Bank;

class User : Account
{
    private int year;

    public int Year
    {
        get => year;
        set
        {
            if (value < 0)
                throw new ArgumentException("Years can't be less than zero");

            year = value;
        }
    }

    public Card Card { get; private set; }

    public User(string? username = null, string? password = null, Card? card = null, int year = 0) : base (username, password)
    {
        Card = card ?? new Card();
        Year = year;
        IsAdmin = false;
    }

    public void MainMenu()
    {
        bool isExit = false;
        while (!isExit)
        {

            Console.WriteLine("Wellcum " + Username + "!");

            Console.Write("Your Card Number is: "); Card.DisplayID();
            Console.WriteLine("Your Balance is: " + Card.Balance);
            Console.WriteLine("Your Salary is: " + Card.Salary);

            Console.WriteLine("What would you like to do?\n");

            Console.WriteLine("1. Get Salary");
            Console.WriteLine("2. Transfer Money");
            Console.WriteLine("3. Make Deposit");
            Console.WriteLine("4. Change Password");
            Console.WriteLine("5. Delete Account");
            Console.WriteLine("0. Log Out");
            Console.WriteLine("-----------------------------");

            string choice = Console.ReadLine();
            Console.Clear();

            switch (choice)
            {
                case "1":
                    Card.GetSalary();
                    break;

                case "2":
                    Card.TransferMoney();
                    break;

                case "3":
                    Card.MakeDeposit();
                    break;

                case "4":
                    ChangePassword();
                    break;

                case "5":
                    DeleteAccount(Username);
                    isExit = true;
                    break;
                    
                case "0":
                    isExit = true;
                    Console.Clear();
                    break;
            }

        }
    }
}
