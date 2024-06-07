namespace Bank_V2;

static class BankDB
{
    private const int maxUserAccountsCount = 7;
    private const int maxAdminAccountsCount = 3;

    public static User[] userAccounts = new User[maxUserAccountsCount];
    public static Admin[] adminAccounts = new Admin[maxAdminAccountsCount];

    private const string fileName = "Data.txt";
    private const int minAdminData = 2;
    private const int minUserData = 4;

    static BankDB()
    {
        Directory.SetCurrentDirectory("C:\\Users\\User\\source\\repos\\Bank_V2\\Bank_V2\\Data");

        ReadFile();
    }

    public static bool IsAdmin { get; private set; }

    public static void PrintFile()
    {
        using StreamWriter file = new(fileName);

        for (int i = 0; i < maxAdminAccountsCount; i++) // Write Admin Data
            file.WriteLine(adminAccounts[i].Username + " " + adminAccounts[i].Password);

        for (int i = 0; i < maxUserAccountsCount; i++) // Write User Data
        {
            if (userAccounts[i] != null)
            {    
                file.Write(userAccounts[i].Username + " ");
                file.Write(userAccounts[i].Password + " ");
                file.Write(userAccounts[i].Card.ID  + " ");
                file.Write(userAccounts[i].Card.Balance + " ");
                file.Write(userAccounts[i].Card.Salary);
                file.WriteLine();
            }
        }

    }

    private static void ReadFile()
    {
        using StreamReader file = new(fileName);

        for (int i = 0; i < maxAdminAccountsCount; i++) // Read Admin's Data
        {
            string str = file.ReadLine() ?? " ";
            string[] data = str.Split(' ');

            if (data.Length < minAdminData)
            {
                string[] array = new string[minAdminData];
                for (int j = 0; j < data.Length; j++)
                    array[j] = data[j];
                data = array;
            }

            try 
            {
                adminAccounts[i] = new Admin(
                    username: data[0],
                    password: data[1]);
            }
            catch (Exception) { }
        }

        for (int i = 0; i < maxUserAccountsCount; i++) // Read User's Data
        {
            string str = file.ReadLine() ?? " ";
            string[] data = str.Split(' ');

            if (data.Length < minUserData)
            {
                string[] array = new string[minUserData];
                for (int j = 0; j < data.Length; j++)
                    array[j] = data[j];
                data = array;
            }


            try
            {
                userAccounts[i] = new User(
                    username: data[0],
                    password: data[1],

                    new Card
                    (
                        id:      data[2],
                        balance: decimal.Parse(data[3]),
                        salary:  int.Parse(data[4])
                        ));
            }
            catch (Exception) { }
        }



    }


    public static void AddAccount(string username, string password)
    {
        bool isValid = false;
        while (!isValid)
        {
            Console.Clear();
            Console.WriteLine("This Account Doesn't Exist\n");
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1. Create a New Account");
            Console.WriteLine("0. Go Back");
            Console.WriteLine("-----------------------------");


            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    isValid = true;
                    Create.UserAccount(username, password);
                    break;
                case "0":
                    isValid = true;
                    Console.Clear();
                    break;

            }
        }
    }

    public static User FindUserAccount(string username)
    {
        foreach (User user in userAccounts)
        {
            if (user == null)
                return null;

            if (user.Username == username)
                return user;
        }

        return null;
    }

    public static Admin FindAdminAccount(string username)
    {
        foreach (Admin admin in adminAccounts)
        {
            if (admin.Password == null)
                return null;

            if (admin.Username == username)
                return admin;
        }

        return null;
    }

    public static bool isExist(string username)
    {
        IsAdmin = true;
        if(FindAdminAccount(username) != null)
            return true;

        IsAdmin = false;
        if (FindUserAccount(username) != null)
            return true;

        return false;
    }

    public static bool isCorrect(Account account)
    {
        Admin admin = FindAdminAccount(account.Username);
        if (admin != null)
            if (admin.Username == account.Username && admin.Password == account.Password)
                return true;

        User user = FindUserAccount(account.Username);
        if (user != null)
            if (user.Username == account.Username && user.Password == account.Password)
                return true;

        return false;
    }
    
    public static int FindEmptySpaceForUserAccount() // Need to change the name
    {
        for (int i = 0; i < maxUserAccountsCount; i++)
            if (userAccounts[i] == null)
                return i;

        return -1;
    }

    public static int FindEmptySpaceForAdminAccount() // Also need to change the name
    {
        for (int i = 0; i < maxAdminAccountsCount; i++)
            if (adminAccounts[i] == null)
                return i;

        return -1;
    }


}
