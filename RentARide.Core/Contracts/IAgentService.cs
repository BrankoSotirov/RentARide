using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentARide.Core.Contracts
{
    public interface IAgentService
    {
        Task<bool> ExistsById(string userId);

        Task<bool> UserWithPhoneNumberExists(string phoneNumber);

        Task<bool> UserHasRent(string userId); 

        Task Create (string userId, string phoneNumber);
    }
}
