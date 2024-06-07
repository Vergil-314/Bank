namespace Bank_V2;

class Card
{
    private string id;
    private const int idLength = 16;

    private decimal balance;

    private int salary;
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
        get => balance;
        set
        {
            if (value < 0)
                throw new ArgumentException("Balance Can't Be Less Than Zero");

            balance = value;
        }
    }

    public int Salary
    {
        get => salary;
        set
        {
            if (value < 0)
                throw new ArgumentException("Salary Can't Be Less Than Zero");

            salary = value;
        }
    }

    public Card(string id = null, decimal balance = 0, int salary = 0)
    {
        this.id = id;
        this.balance = balance;
        this.salary = salary;
    }

    public void DiplayID()
    {
        int i = 0;
        foreach (char num in ID)
        {
            if (i % 4 == 0 && i != 0)
                Console.Write("-");

            Console.Write(num);
            i++;
        }
        Console.WriteLine();
    }

}
