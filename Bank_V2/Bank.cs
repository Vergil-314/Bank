namespace Bank_V2;

class Bank
{

    public void MainMenu()
    {
        bool isExit = false;
        while (!isExit)
        {
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1. Log In");
            Console.WriteLine("2. Sign up");
            Console.WriteLine("3. Change Password");
            Console.WriteLine("0. Quit");

            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    // LogIn();
                    break;

                case "2":
                    // CreateAccount();
                    break;

                case "3":
                    // ChangePassword();
                    break;

                case "4":
                    isExit = true;
                    break;
            }
        }
    }


    private void LogIn()
    {
        Account account = new Account(Credentials.GetUsername(), Credentials.GetPassword());

        if (BankDB.isExist(account))
        {

        }

    }


}
