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
                    GetSalary(Card.Salary);
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
        Console.Clear();

        if (salary == 0)
        {
            bool isValid = false;
            while (!isValid)
            {
                Console.Clear();

                Console.Write("Enter Your Salary: ");
                try
                {
                    int.TryParse(Console.ReadLine(), out salary);
                    isValid = true;
                    Card.Salary = salary;
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }
        
        Card.Balance += salary;
    }


}
