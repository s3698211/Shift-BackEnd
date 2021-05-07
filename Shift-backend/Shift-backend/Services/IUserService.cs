using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shift_backend.Services
{
    public interface IUserService
    {
        ICollection<Shift> getShiftsOfUser(string userId);
    }
}
