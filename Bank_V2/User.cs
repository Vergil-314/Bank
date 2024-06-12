namespace Bank;

class User : Account
{
    public Card Card { get; private set; }

    public User(string username, string password, Card card) : base (username, password)
    {
        Card = card;
        IsAdmin = false;
    }

    public void MainMenu()
    {
        bool isExit = false;
        while (!isExit)
        {

            Console.WriteLine("Wellcum " + Username + "!");
            Console.Write("Your Card Number is: "); Card.DisplayData(Card.ID, 4, "-");
            Console.Write("Your Balance is: "); Card.DisplayData(Card.Balance, 3, "  ");

            if (Card.Salary != 0)
                Console.Write("Your Salary is: "); Card.DisplayData(Card.Salary, 3, "  ");

            Console.WriteLine("What would you like to do?\n");

            Console.WriteLine("1. Get Salary");
            Console.WriteLine("2. Transfer Money");
            Console.WriteLine("3. Change Salary");
            Console.WriteLine("4. Change Password");
            Console.WriteLine("5. Delete Account");
            Console.WriteLine("0. Log Out");
            Console.WriteLine("-----------------------------");

            string choice = Console.ReadLine();

            Console.Clear();

            switch (choice)
            {
                case "1":
                    GetSalary();
                    break;

                case "2":
                    TransferMoney();
                    break;

                case "3":
                    ChangeSalary();
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

    private void GetSalary()
    {
        Console.Clear();

        if (Card.Salary == 0)
            ChangeSalary();

        Card.Balance += Card.Salary;
        BankDB.PrintFile();
    }


    private void TransferMoney()
    {
        Console.WriteLine("How much money do you want to transfer?");
        decimal count = decimal.Parse(Console.ReadLine());

        Console.Clear();

        if (count > Card.Balance || count <= 0)
        {
            Console.WriteLine("This opperation can't be applied\n");
            return;
        }

        User user = (User) BankDB.FindAccount(Credentials.GetUsername("Enter Username: "));

        Console.Clear();

        if (user == null)
        {
            Console.WriteLine("This user doesn't exist\n");
            return;
        }

        user.Card.Balance += count;
        Card.Balance -= count;

        BankDB.PrintFile();
    }


    private void ChangeSalary()
    {
        Console.Clear();

        bool isValid = false;
        while (!isValid)
        {

            Console.Write("Enter Salary: ");
            try
            {
                int.TryParse(Console.ReadLine(), out int salary);
                Card.Salary = salary;
                isValid = true;
            }
            catch (Exception exception)
            {
                Console.Clear();
                Console.WriteLine(exception.Message);
            }
        }
        Console.Clear();

        BankDB.PrintFile();
        Console.WriteLine("Salary has been Changed\n");
    }

}
