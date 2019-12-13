using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmaryllisTestProject.WEB.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string DriveNumber { get; set; }
    }
}
