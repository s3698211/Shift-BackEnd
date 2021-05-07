using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class User : IdentityUser
    {
        
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Shift> Shifts { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }

        public virtual ICollection<WorkingDate> WorkingDates { get; set; }

        public User()
        {
            
        }

        public static explicit operator User(Task<User> v)
        {
            throw new NotImplementedException();
        }
    }
}
