using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem1
{
    class Clients
    {
        //fields
        private string name;
        private Accounts account;

        //properties
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
        public virtual Accounts Accounts
        {
            get
            {
                return this.account;
            }
            set
            {
                this.account = value;
            }
        }

        //Balance Method
        public void Balance()
        {
            //printing balance to console
            Console.WriteLine("Account Balance : ${0}", this.Accounts.Balance);
        }

        //Information Method
        public void Info()
        {
            //printing account information to the console
            Console.WriteLine("Account Information");
            Console.WriteLine();
            Console.WriteLine("Client Name: {0}", this.Name);
            Console.WriteLine("Account Number: {0}", this.Accounts.AcctNum);
            Console.WriteLine("Account Balance: {0}", this.Accounts.Balance);
            
           // Console.WriteLine("");
        }

        //Constructor with one parameter
        public Clients(string name)
        {
            this.Name = name;
            

        }

       


    }
}
