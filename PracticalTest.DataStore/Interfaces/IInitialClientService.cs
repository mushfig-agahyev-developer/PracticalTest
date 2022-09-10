using PracticalTest.DataStore.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticalTest.DataStore.Interfaces
{
    public interface IInitialClientService
    {
        Task Initialize(AppStore context);
    }
}
