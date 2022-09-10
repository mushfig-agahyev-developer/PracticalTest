using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticalTest.DataStore.Models
{
    public class Client
    {
        public Client()
        {
            ClientUniqueId = Guid.NewGuid().ToString();
        }
        
        public string ClientUniqueId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TelephoneNr { get; set; }
        public virtual ICollection<Loan> Loans { get; set; }
    }
}
