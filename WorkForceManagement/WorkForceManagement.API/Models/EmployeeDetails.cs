using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WorkForceManagement.API.Models
{
    public class EmployeeDetails
    {
        [Key]
        public int employee_id { get; set; }
        public string employee_name { get; set; }
        public string status { get; set; }
        public string manager { get; set; }
        public string wfm_manager { get; set; }
        public string email { get; set; }
        public string lockstatus { get; set; }
        public decimal experience { get; set; }
        [NotMapped]
        public List<string> skills { get; set; }
    }
}
