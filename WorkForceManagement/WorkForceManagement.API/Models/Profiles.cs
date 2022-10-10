using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorkForceManagement.API.Models
{
    public class Profiles
    {
        [Key]
        public int profile_id { get; set; }
        public string profile_name { get; set; }
        public ICollection<Employees> employees { get; set; }
    }
}
