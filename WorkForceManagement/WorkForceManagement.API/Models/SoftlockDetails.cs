using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkForceManagement.API.Models
{
    public class SoftlockDetails
    {
        public int lockid { get; set; }
        public int employee_id { get; set; }
        public string employee_name { get; set; }
        public string manager { get; set; }
        public string requestmessage { get; set; }
        public string managerstatus { get; set; }
        public DateTime reqdate { get; set; }
    }
}
