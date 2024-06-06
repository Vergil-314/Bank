namespace Bank_V2;

class Card
{
    private string id;
    private int idLength = 16;
    private decimal balance;
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

    public Card(string id = null, decimal balance = 0)
    {
        this.id = id;
        Balance = balance;
    }

}
