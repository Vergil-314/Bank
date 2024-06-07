using System.Security.Cryptography;

namespace Bank_V2;

static class BankDB
{
    private const int maxAccountCount = maxUserAccountsCount + maxAdminAccountsCount;
    private const int maxUserAccountsCount = 7;
    private const int maxAdminAccountsCount = 3;

    public static User[] userAccounts = new User[maxUserAccountsCount];
    public static Admin[] adminAccounts = new Admin[maxAdminAccountsCount];

    private const string fileName = "Data.txt";
    private const string nullAdminStringInFile = " ";
    private const string nullUserStringInFile = "    ";

    static BankDB()
    {
        Directory.SetCurrentDirectory("C:\\Users\\User\\source\\repos\\Bank_V2\\Bank_V2\\Data");

        ReadFile();
    }

    public static bool IsAdmin { get; set; }

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
            string str = file.ReadLine() ?? nullAdminStringInFile;
            string[] data = str.Split(' ');

            if (data.Length < nullAdminStringInFile.Length)
            {
                string[] array = new string[nullUserStringInFile.Length];
                for (int j = 0; j < array.Length; j++)
                    array[i] = data[i];
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
            string str = file.ReadLine() ?? nullUserStringInFile;
            string[] data = str.Split(' ');

            if (data.Length < nullUserStringInFile.Length)
            {
                string[] array = new string[nullUserStringInFile.Length];
                for (int j = 0; j < array.Length; j++)
                    array[i] = data[i];
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


    public static User FindUserAccount(string username)
    {
        foreach (User user in userAccounts)
            if (user.Username == username)
                return user;

        return null;
    }

    public static Admin FindAdminAccount(string username)
    {
        foreach (Admin admin in adminAccounts)
            if (admin.Username == username)
                return admin;

        return null;
    }

    public static bool isExist(string username)
    {
        IsAdmin = true;
        foreach (Admin admin in adminAccounts)
            if ((admin.Username) == username)
                return true;

        IsAdmin = false;
        foreach (User user in userAccounts)
            if (user != null)
                if (user.Username == username)
                    return true;

        return false;
    }

    public static bool isCorrect(Account account)
    {
        foreach (Admin admin in adminAccounts)
            if (admin.Username == account.Username && admin.Password == account.Password)
                return true;

        foreach (User user in userAccounts)
            if (user != null)
                if (user.Username == account.Username && user.Password == account.Password)
                    return true;

        return false;
    }

    public static int FindEmptySpaceForUserAccount() // Need to change the name
    {
        for (int i = 0; i < maxUserAccountsCount; i++)
            try
            {
                if (userAccounts[i] == null)
                    return i;
            }
            catch (Exception) { }

        return -1;
    }

    public static int FindEmptySpaceForAdminAccount() // Also need to change the name
    {
        for (int i = 0; i < maxAdminAccountsCount; i++)
            if (adminAccounts[i].Username == "")
                return i;

        return -1;
    }


}
