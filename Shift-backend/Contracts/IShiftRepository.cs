using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IShiftRepository
    {
        IEnumerable<Shift> GetAllShifts(bool trackChanges);
        Shift GetShift(string shiftId, bool trackChanges);
        void CreateShift(Shift shift, string userId);

        void DeleteShift(Shift shift);
        void UpdateShift(Shift shift);
    }
}
