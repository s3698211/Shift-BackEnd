using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shift_backend.Services
{
    public class UserService : IUserService
    {
        private readonly RepositoryContext _repositoryContext;

        public UserService(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public ICollection<Shift> getShiftsOfUser(string userId)
        {
           var user = _repositoryContext.Users.Include(user => user.Shifts).First(user => user.Id.Equals(userId));
            return user.Shifts;
        }
    }
}
