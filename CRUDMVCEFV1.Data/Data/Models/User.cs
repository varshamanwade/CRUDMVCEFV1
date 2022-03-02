using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CRUDMVCEFV1.Data.Data.Models
{
    public class User
    {
        [Key]
        public Int32 RecordId { get; set; }
        [Required]
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public string CreateBy { get; set; }
        public string ModifyBy { get; set; } 
    }
}
