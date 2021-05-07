using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTO
{
    public class ShiftDTO
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public string StartAt { get; set; }
        public string EndAt { get; set; }
        public string StaffName { get; set; }

        

    }
}
