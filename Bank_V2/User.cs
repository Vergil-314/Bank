﻿namespace Bank_V2;

class User : Account
{

    public Card Card { get; set; }

    public User(string username, string password, Card card) : base(username, password)
    {
        Card = card;
    }

    public void MainMenu()
    {
        bool isExit = false;
        while (!isExit)
        {
            Console.Clear();

            Console.WriteLine("Hello " + Username + "!");
            Console.Write("Your Card Number is: "); Card.DiplayID();

            Console.WriteLine("Your Balance is: " + Card.Balance);
            Console.WriteLine("What would you like to do?\n");
            Console.WriteLine("1. Get Salary");
            Console.WriteLine("2. Transfer Money");
            Console.WriteLine("3. Change Salary");
            Console.WriteLine("4. Delete Account");
            Console.WriteLine("0. Log Out");
            Console.WriteLine("-----------------------------");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    GetSalary(Card.Salary);
                    break;

                case "2":
                    // Method TransferMoney()
                    break;

                case "3":
                    ChangeSalary();
                    break;

                case "4":
                    BankDB.DeleteUserAccount(new User(Username, Password, Card));
                    isExit = true;
                    Console.Clear();
                    break;
                    
                case "0":
                    isExit = true;
                    Console.Clear();
                    break;
            }

        }
    }


    private void GetSalary(int salary = 0)
    {
        Console.Clear();

        if (salary == 0)
        {
            bool isValid = false;
            while (!isValid)
            {

                Console.Write("Enter Your Salary: ");
                try
                {
                    int.TryParse(Console.ReadLine(), out salary);
                    Card.Salary = salary;
                    isValid = true;
                }
                catch (Exception exception)
                {
                    Console.Clear();
                    Console.WriteLine(exception.Message);
                }
            }
        }
        
        Card.Balance += salary;
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
        Console.WriteLine("Salary has been Changed");
    }

}
