namespace Bank_V2;

class Card
{
    private string id;
    private int idLength = 16;
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
        get => Balance;
        set
        {
            if (value < 0)
                throw new ArgumentException("Balance Can't Be Less Than Zero");

            Balance = value;
        }
    }

}
