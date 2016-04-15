using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;


namespace BankingSystem1
{
    class Accounts
    {

        

        //declaring fields
        private string name;
        private decimal balance;
        private int acctNum;
        private List<Array> transactions = new List<Array>();


        //properties
        public virtual decimal Balance
        {
            get
            {
                return this.balance;
            }
            set
            {
                this.balance = value;
            }
        }


        public virtual int AcctNum
        {
            get
            {
                return this.acctNum;
            }
            set
            {
                this.acctNum = value;
            }
        }

        public virtual string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }
        public virtual List<Array> Transactions
        {
            get
            {
                return this.transactions;
            }
            set
            {
                this.transactions = value;
            }
        }

        //methods

        public void Withdraw(decimal amount)
        {
            //subtracting withdraw amount from current balance
            Balance = Balance - amount;
            //adding a collection of objects to list 
            this.Transactions.Add(new Object[] { DateTime.Now,"  -",amount,this.Balance});
            //calling method to write to file everytime a transaction happens
            writeHistory();
            Console.Write("New Current Balance: $");
            //printing new balance to console
            Console.WriteLine(this.Balance);
        }

        public void Deposit(decimal amount)
        { 
            //adding deposit amount to current balance
            Balance = Balance + amount;
            //adding collection of objects to list
           this.Transactions.Add(new Object[] { DateTime.Now, "  +", amount, this.Balance });
            // call method to write information to file
            writeHistory();
            Console.Write("New Current Balance: $");
            //print new balance to the console
            Console.WriteLine(this.Balance);

        }

        private void writeHistory()
        {
            //instantiate new streamwriter and creating new file
            StreamWriter write = new StreamWriter("AccountSummary.txt");

            //closing for streamwriter
            using (write)
            {
                //printing information to the file named above
                write.WriteLine("Client Name: " + this.Name);
                write.WriteLine("Account Number: " + this.AcctNum);
                write.WriteLine("Current Account Balance: {0}",this.Balance);
                write.WriteLine("\r\n");
                write.WriteLine("Date\t  Time\t\t(+/-)\tAmount\t\tNew Balance");
                write.WriteLine("\r\n");

                //looping through arrays in the list transactions and printing value to the file
                foreach (Array lineHistory in transactions)
                {
                    write.WriteLine("{0}\t{1}\t{2}\t\t{3}",lineHistory.GetValue(0), lineHistory.GetValue(1), lineHistory.GetValue(2), lineHistory.GetValue(3));
                }
            }
        }

        //constructors with one parameter

        public Accounts(string client)
        {
            this.Name = client;
            //creating random number between two given numbers and assigning it to the account number
            this.AcctNum = new Random().Next(00000001, 99999999);
            this.Balance = 0;
            //when a new client is created information is printed to file by calling this method
            writeHistory();

        }

        
    }
}
