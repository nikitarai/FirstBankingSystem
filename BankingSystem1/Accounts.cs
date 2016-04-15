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

        

        //fields
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
            Balance = Balance - amount;
            this.Transactions.Add(new Object[] { DateTime.Now,"  -",amount,this.Balance});
            writeHistory();
            Console.Write("New Current Balance: $");
            Console.WriteLine(this.Balance);
        }

        public void Deposit(decimal amount)
        { 
            Balance = Balance + amount;
           this.Transactions.Add(new Object[] { DateTime.Now, "  +", amount, this.Balance });
            writeHistory();
            Console.Write("New Current Balance: $");
            Console.WriteLine(this.Balance);

        }

        private void writeHistory()
        {
            StreamWriter write = new StreamWriter("AccountSummary.txt");

            using (write)
            {
                write.WriteLine("Client Name: " + this.Name);
                write.WriteLine("Account Number: " + this.AcctNum);
                write.WriteLine("Current Account Balance: {0}",this.Balance);
                write.WriteLine("\r\n");
                write.WriteLine("Date\t  Time\t\t(+/-)\tAmount\t\tNew Balance");
                write.WriteLine("\r\n");

                foreach (Array lineHistory in transactions)
                {
                    write.WriteLine("{0}\t{1}\t{2}\t\t{3}",lineHistory.GetValue(0), lineHistory.GetValue(1), lineHistory.GetValue(2), lineHistory.GetValue(3));
                }
            }
        }

        //constructors

        public Accounts(string client)
        {
            this.Name = client;
            this.AcctNum = new Random().Next(00000001, 99999999);
            this.Balance = 0;
            writeHistory();

        }

        
    }
}
