using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class ShiftRepository :RepositoryBase<Shift>, IShiftRepository
    {
        private readonly RepositoryContext _repositoryContext;
        public ShiftRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public IEnumerable<Shift> GetAllShifts(bool trackChanges) =>
            FindAll(trackChanges)
            .OrderBy(s => s.Date)
            .ToList();

        
        public Shift GetShift(string shiftId, bool trackChanges) =>
            FindByCondition(s => s.Id.Equals(shiftId), trackChanges)
            .SingleOrDefault();

        public void CreateShift(Shift shift, string userId) {
            shift.UserId = userId;
            var user = _repositoryContext.Users.Include(user => user.Shifts).First(user => user.Id.Equals(userId));
            user.Shifts.Add(shift);
            Create(shift); 
        }

        public void DeleteShift(Shift shift)
        {
            Delete(shift);
        }
        public void UpdateShift(Shift shift)
        {
            var editShift = _repositoryContext.Shifts.First(s => s.Id.Equals(shift.Id));
            editShift.Date = shift.Date;
            editShift.StartAt = shift.StartAt;
            editShift.EndAt = shift.EndAt;
            editShift.StaffName = shift.StaffName;
        }
        
    }
}
