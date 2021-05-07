using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Shifts.DB
{
    public class Shift
    {
        [Key]
        public int Id { get; set; }
        public string startAt { get; set; }
        public string endAt { get; set; }

        public string staffName { get; set; }

        public DateTime date { get; set; }
    }
}
