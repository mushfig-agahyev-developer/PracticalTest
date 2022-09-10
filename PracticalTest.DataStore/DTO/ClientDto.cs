using PracticalTest.DataStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticalTest.DataStore.DTO
{
    public class ClientDto
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public float Salary { get; set; }
        public  List<LoanDto> Loans { get; set; }

        public static implicit operator ClientDto(Client client)
        {
            if (client == null)
                return null;
            return new ClientDto()
            {
                ID = client.ClientUniqueId,
                Name = client.Name,
                Surname = client.Surname,
                Phone = client.TelephoneNr,
                Loans = client.Loans.Select(r => (LoanDto)r).ToList()
            };
        }
    }
}
