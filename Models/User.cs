using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string ContactNo { get; set; }

        public Gender Gender { get; set; }

        public int GenderId { get; set; }

        public EmployeeRole EmployeeRole { get; set; }

        public int EmployeeRoleId { get; set; }

        

        public int Salary { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime JoiningDate { get; set; }

        public string Image { get; set; }

    }
}