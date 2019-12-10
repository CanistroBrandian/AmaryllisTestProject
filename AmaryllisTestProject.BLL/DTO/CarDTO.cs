using System;
using System.Collections.Generic;
using System.Text;

namespace AmaryllisTestProject.BLL.DTO
{
   public class CarDTO
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Class { get; set; }
        public int YearOfIssue { get; set; }
        public string RegistrationNumber { get; set; }
    }
}
