namespace Bank;

class Deposit
{
    private int time;

    public Deposit(int time)
    {
        Time = time;
    }

    public int Time
    {
        get => time;
        set
        {
            if (value <= 0)
                throw new ArgumentException("Time can't be less or equal zero");

            time = value;
        }
    }
    private decimal Coefficient
    {
        get
        {
            if (time <= 1)
                return 0.05M;

             if (time <= 3)
                return 0.15M;

            return 0.20M;

        }
    }

    public decimal GetDepositMoney(decimal money) => money * Coefficient;
}
