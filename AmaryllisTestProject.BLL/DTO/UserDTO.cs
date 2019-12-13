using System;
using System.Collections.Generic;
using System.Text;

namespace AmaryllisTestProject.BLL.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string DriveNumber { get; set; }
    }
}
