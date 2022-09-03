using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticalTest.DataStore.DTO
{
    public class ClientDto
    {
        public string ClientUniqueId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TelephoneNr { get; set; }
        public  List<LoanDto> Loans { get; set; }
    }
}
