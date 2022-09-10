using PracticalTest.DataStore.DAL;
using PracticalTest.DataStore.Interfaces;
using PracticalTest.DataStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticalTest.DataStore.Repositories
{
    public class InitialClientService : IInitialClientService
    {
        public async Task Initialize(AppStore context)
        {
            List<Client> clients = new List<Client>() {
            new Client() { Name = "Aqil", Surname="Abbasov", TelephoneNr="0558887700" },
            new Client() { Name = "Abid", Surname = "Kerimov", TelephoneNr = "0557771546" },
            new Client() { Name = "Hadi", Surname = "Ezizov", TelephoneNr = "0554158877" },
            new Client() { Name = "Razi", Surname = "Malikov", TelephoneNr = "0558974556" },
            new Client() { Name = "Selim", Surname = "Azimov", TelephoneNr = "0557841515" },
        };
            await context.AddRangeAsync(clients);
            await context.SaveChangesAsync();
        }
    }
}
