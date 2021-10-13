using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleDemoApp.Model
{
    public class UserDetails
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public string EmployeeType { get; set; }
        public string Name { get; set; }
        public int MobileNo { get; set; }
        public string Email { get; set; }
        public string Nationality { get; set; }
        public string Designation { get; set; }
        public string PassportNo { get; set; }
        public DateTime PassportExpirtDate { get; set; }
        public string PassportFilePath { get; set; }
        public string PersonPhoto { get; set; }

        public IFormFile Passport { get; set; }
        public IFormFile Photo { get; set; }
    }
}
