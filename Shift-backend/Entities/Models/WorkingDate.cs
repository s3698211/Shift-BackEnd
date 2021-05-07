using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    
    public class WorkingDate
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool Shift1 { get; set; }
        public bool Shift2 { get; set; }
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public User User { get; set; }

        public WorkingDate()
        {
           
        }
    }
}
