using System;
using System.Collections.Generic;
using System.Text;

namespace AmaryllisTestProject.DAL.Entities
{
   public class User :BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string DriveNumber { get; set; }
        public Order Order { get; set; }
    }
}
