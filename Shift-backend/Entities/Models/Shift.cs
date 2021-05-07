using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    public class Shift
    {
        [Key]
        [Required(ErrorMessage ="Id is a required field")]
        [Column("ShiftId")]        
        public string Id { get; set; }
        [Required(ErrorMessage = "Date is required field")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "StartAt is required field")]
        public String StartAt { get; set; }
        [Required(ErrorMessage = "EndAt is required field")]
        public String EndAt { get; set; }
        [Required(ErrorMessage = "StaffName is required field")]
        public String StaffName { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public User User { get; set; }
    }
}




