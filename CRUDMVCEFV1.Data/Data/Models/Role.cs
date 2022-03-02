using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CRUDMVCEFV1.Data.Data.Models
{
    public class Role
    {
        [Key]
        public Int32 RecordId { get; set; }
        public string RoluName { get; set; }
        public string RoleDesc { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public string CreateBy { get; set; }
        public string ModifyBy { get; set; }

    }
}
