using System;
using Shift.DB;
namespace Shifts.Core

{
    public class ShiftsServices
    {
        private AppDBContext _context;
        public ShiftsServices(AppDBContext context)
        {
            _context = context;
        }

        public Shift createShift(Shift shift)
        {
            _context.Add(shift);
            _context.SaveChanges();
            return shift;
        }
    }
}
