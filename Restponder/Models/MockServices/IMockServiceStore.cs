using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restponder.Models.MockServices
{
    public interface IMockServiceStore
    {

        Task<MockService> FindByKeyAsync(string key);

        Task UpdateAsync(MockService mockResponse);

        Task CreateAsync(MockService mockResponse);

    }
}
