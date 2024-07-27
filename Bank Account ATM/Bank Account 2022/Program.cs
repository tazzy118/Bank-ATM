using System;

public class BankUser
{
    string fName;
    string lName;
    string longNo;             //attributes in the class
    int pinNo;
    int balance;
    // using constructer to establish the objects from my class
    public BankUser(string fName, string lName, string longNo, int pinNo, int balance)
    {
        this.fName = fName;
        this.lName = lName;
        this.longNo = longNo;
        this.pinNo = pinNo;
        this.balance = balance;
    }
    // Adds security by encapsulation. better for banks imo
    public string getFName()
    {
        return fName;
    }

    public string getLName()
    {
        return lName;
    }

    public string getLongNo()
    {
        return longNo;
    }

    public int getPinNo()
    {
        return pinNo;
    }

    public int getBalance()
    {
        return balance;
    }
    //setters writes the values when needed and adds a type of security (if added). setters would store 

    public void setfName(string newFName)
    {
        fName = newFName;
    }
    public void setlName(string newLName)
    {
        lName = newLName;
    }
    public void setlongNo(string newLongNo)
    {
        longNo = newLongNo;
    }
    public void setpinNo(int newPinNo)
    {
        pinNo = newPinNo;
    }
    public void setBalance(int newBalance)
    {
        balance = newBalance;
    }

    //Tells your main method has to run without any access restrictions. It's public to avoid compile time error.
    public static void Main(String[] args)
    {
        void Main_Menu()
        {
            Console.WriteLine("Select one of the options below:");
            Console.WriteLine("1 - Withdraw");
            Console.WriteLine("2 - Deposit");
            Console.WriteLine("3 - Balance");
            Console.WriteLine("4 - Exit");
        }

        //USER "GUI"
        Console.WriteLine("TSB Bank");
        Console.WriteLine("Enter Bank Card 16 digit number:");
        string bankCardno = "";
        BankUser activeUser;
        // ^ These are just blank inputs that will be filled in later on. I had help from my cousin with this bit.

        //"DATABASE"
        List<BankUser> bankUsers = new List<BankUser>();
        bankUsers.Add(new BankUser("Tasnim", "Begum", "4111111111111111", 1234, 1305));
        bankUsers.Add(new BankUser("Lafifa", "Sultana", "4222222222222222", 4321, 1300));

        //List<BankUser> bankUsers = new List<BankUser>();
        //string Fname = Console.ReadLine();
        //string LName = Console.ReadLine();
        //string 16digitNo = Console.ReadLine();                 ==> Improvemnts User adds thier own data
        //string Pin = Console.ReadLine();                       ==> The user program would also save a list of arryas in a database.
        //string Balance = Console.ReadLine();
        //bankUsers.Add(new BankUser(FName, LName, 16digitNo, Pin, Balance));
        // File.WriteAllText(list<BankAccount);
        
        //I would use a while loop to continuosly check the data until its true. For my case it was checking if bankCardno was right.
        while (true)
        {
            bankCardno = Console.ReadLine();
            activeUser = bankUsers.FirstOrDefault(a => a.longNo == bankCardno);
            // (Had some help from my cousin & https://stackoverflow.com/questions/1024559/when-to-use-first-and-when-to-use-firstordefault-with-linq)
            if (activeUser != null) //https://stackoverflow.com/questions/444798/case-insensitive-containsstring/444818#444818 //(all good no faults)
            {
                break;
            }
            else
            {
                Console.WriteLine("The card 16 digit bank number is incorrect. Please try Again.");
            }
            // i used if/else to check if my pin was enetered corectly.
            Console.WriteLine("Enter your Pin");
            int userPin = 0;

            userPin = Convert.ToInt32(Console.ReadLine());
            if (activeUser.getPinNo() == userPin)
            {
                break;
            }
            else
            {
                Console.WriteLine("The Pin Number is Wrong. Please try Again.");
            }

            // The do/while loop executes options until a condtion is satisfied. For this case its when the user chooses an option.
            Console.WriteLine("Hello " + activeUser.getLName);
            int option = 0;
            do
            {
                Main_Menu();
                try
                {
                    option = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    if (option == 1)
                    { withdraw(activeUser); }

                    else if (option == 2)
                    { deposit(activeUser); }

                    else if (option == 3)
                    { balance(activeUser); }

                    else if (option == 4)
                    { break; }
                }
            }
            while (option == 4);
            Console.WriteLine("Goodbye " + activeUser.getLName);
            //This would also be improved if it were on a GUI interface since it would be more interctacive for the user.
        }

        //function about withdraw
        void withdraw(BankUser activeUser)
        {
            Console.WriteLine("Type in the amount you would like to withdraw: ");
            int withdraw = Convert.ToInt32(Console.ReadLine());
            if (activeUser.getBalance() < withdraw) //dont take out what you dont have
            {
                Console.WriteLine("You dont have enough money");
            }
            else//the newBalance is going to be te current balance minus the withdraw.
            {
                int withdrawn = activeUser.getBalance() - withdraw;
                activeUser.setBalance(withdrawn);
                Console.WriteLine("You have withdrawn");

            }
        }
        //This would pass the BankUser Info (object) into the activeUser.(function)
        //the try and catch would find errors when the user inputs a wrong vaule without disturbing the code when ran.
        void deposit(BankUser activeUser)
        {
            try
            {
                Console.WriteLine("Type in the amount you would like to deposit: ");
                int deposit = Convert.ToInt32(Console.ReadLine());
                activeUser.setBalance(activeUser.getBalance() + deposit);
                Console.WriteLine("New Balance:" + activeUser.getBalance());
            }//im getting the current balance and adding my deposit to it. Which is then getting displayed with activeUser.getBalance (the new balance).
            catch (FormatException e)
            {
                Console.WriteLine("Only type in numbers please");
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occured");
            }
        }
        //shows user their balance
        void balance(BankUser activeUser)
        {
            Console.WriteLine("Your Balance: " + activeUser.getBalance());
        }
        

    }


}