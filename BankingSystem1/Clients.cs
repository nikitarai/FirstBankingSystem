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
        public virtual string Name { get; set; }
        public virtual Accounts Accounts { get; set; }

        //Balance Method
        public void Balance()
        {
            
            
            Console.WriteLine("Account Balance : ${0}", this.Accounts.Balance);
        }

        //Information Method
        public void Info()
        {
            Console.WriteLine("Account Information");
            Console.WriteLine();
            Console.WriteLine("Client Name: {0}", this.Name);
            Console.WriteLine("Account Number: {0}", this.Accounts.AcctNum);
            
           // Console.WriteLine("");
        }

        //Constructor
        public Clients(string name)
        {
            this.Name = name;
            

        }

       


    }
}
