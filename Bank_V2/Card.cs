namespace Bank;

class Card
{
    private string id;
    private const int idLength = 16;

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
        get => balance;
        set
        {
            if (value < 0)
                throw new ArgumentException("Balance Can't Be Less Than Zero");

            balance = value;
        }
    }

    public decimal Salary
    {
        get => salary;
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


    public void DisplayData(object data, int offset, string separator)
    {
        if (data == null || offset == 0 || data.ToString().Length <= offset)
            return;

        int firstDigits = 0;

        while ((data.ToString().Length - firstDigits) > offset)
            firstDigits += offset;

        firstDigits = data.ToString().Length - firstDigits;

        for (int i = 0; i < firstDigits; i++)
            Console.Write(data.ToString()[i]);

         Console.Write(separator);

        for (int i = firstDigits; i < data.ToString().Length; i++)
        {
            if ((i - firstDigits) % offset == 0 && i != 0 && i != firstDigits)
                Console.Write(separator);
            Console.Write(data.ToString()[i]);
            
        
        }
        Console.WriteLine();
    }

}
