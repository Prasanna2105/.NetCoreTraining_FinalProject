using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorkForceManagement.API.Models
{
    public class Users
    {
        [Key]
        public string username { get; set; }
        [JsonIgnore]
        public string password { get; set; }
        public string name { get; set; }
        public string role { get; set; }
        public string email { get; set; }
    }
}
