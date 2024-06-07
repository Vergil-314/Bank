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
            Console.Write("Your Card Number is: "); Card.DiplayID();

            Console.WriteLine("Your Balance is: " + Card.Balance);
            Console.WriteLine("What would you like to do?\n");
            Console.WriteLine("1. Get Salary");
            Console.WriteLine("2. Transfer Money");
            Console.WriteLine("0. Log Out");
            Console.WriteLine("-----------------------------");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    GetSalary();
                    break;

                case "2":
                    // Method TransferMoney()
                    break;
                    
                case "0":
                    isExit = true;
                    Console.Clear();
                    break;
            }

        }
    }


    private void GetSalary(int salary = 0)
    {
        if (salary == 0)
        {
            Console.Write("Enter Your Salary: ");
            int.TryParse(Console.ReadLine(), out salary);
        }

        Card.Balance += salary;
    }


}
