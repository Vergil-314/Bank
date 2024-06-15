namespace Bank;

class Card
{
    private string id;
    private decimal balance;
    private decimal salary;
    public string ID
    {
        get
        {
            if (id == null)
            {
                Random random = new();

                for (int i = 0; i < idLength; i++)
                    id += random.Next(1, 10).ToString();
            }
            return id;
        }
    }
    public decimal Balance
    {
        get => Math.Round(balance, 2);
        set
        {
            if (value < 0)
                throw new ArgumentException("Balance Can't Be Less Than Zero");

            balance = value;
        }
    }
    public decimal Salary
    {
        get => Math.Round(salary, 2);
        set
        {
            if (value <= 0)
                throw new ArgumentException("Salary Can't Be Equal or Less Than Zero");

            salary = value;
        }
    }

    public Card(string id = null, decimal balance = 0, int salary = 0)
    {
        this.id = id;
        this.balance = balance;
        this.salary = salary;
    }

    public void GetSalary()
    {
        Console.Clear();

        if (Salary == 0)
        {
            Console.WriteLine("You don't have a salary\n");
            return;
        }    

        Balance += Salary;
        BankDB.PrintFile();
    }

    public void TransferMoney()
    {
        Console.WriteLine("How much money do you want to transfer?");
        decimal count = decimal.Parse(Console.ReadLine());
        Console.Clear();

        if (count > Balance || count <= 0)
        {
            Console.WriteLine("This opperation can't be applied\n");
            return;
        }

        User user = (User)BankDB.FindAccount(Credentials.GetUsername("Enter Username: "));
        Console.Clear();

        if (user == null)
        {
            Console.WriteLine("This user doesn't exist\n");
            return;
        }

        user.Card.Balance += count;
        Balance -= count;

        BankDB.PrintFile();
    }

    public void MakeDeposit()
    {
        Console.Clear();

        bool isExit = false;
        while (!isExit)
        {
            Console.WriteLine("How much time do you want to wait?");
            int time = int.Parse(Console.ReadLine());

            Console.Clear();

            try
            {
                Deposit deposit = new Deposit(time);
                Balance += deposit.GetDepositMoney(Balance);
                isExit = true;
            }
            catch (Exception exception)
            {
                Console.Clear();
                Console.WriteLine(exception.Message + "\n");
            }
        }
        BankDB.PrintFile();
    }

    public void DisplayID()
    {

        for (int i = 0; i < ID.Length; i++)
        {
            if (i % 4 == 0 && i != 0)
                Console.Write("-");

            Console.Write(ID[i]);
        }
        Console.WriteLine();
    }

}
