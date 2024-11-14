using Microsoft.EntityFrameworkCore;
using RentARide.Core.Contracts;
using RentARide.Infrastructure.Data.Common;
using RentARide.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentARide.Core.Services
{
    public class AgentService : IAgentService
    {
        private readonly IRepository repository;

        public AgentService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task Create(string userId, string phoneNumber)
        {
           await repository.Add(new Agent()
           {
               UserId = userId,
               PhoneNumber = phoneNumber
           });
            
            await repository.SaveChanges();
        }

        public async Task<bool> ExistsById(string userId)
        {
            return await repository.AllReadOnly<Agent>()
                .AnyAsync(a => a.UserId == userId);
               
        }

        public async Task<bool> UserHasRent(string userId)
        {
             return  await repository.AllReadOnly<Vehicle>()
                 .AnyAsync(v => v.RenterId == userId);
        }

        public async Task<bool> UserWithPhoneNumberExists(string phoneNumber)
        {
            return await repository.AllReadOnly<Agent>()
               .AnyAsync(a => a.PhoneNumber == phoneNumber);    
        }
    }
}
