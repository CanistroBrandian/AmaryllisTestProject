using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmaryllisTestProject.WEB.Models
{
    public class CarModel
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Class { get; set; }
        public int YearOfIssue { get; set; }
        public string RegistrationNumber { get; set; }
    }
}
