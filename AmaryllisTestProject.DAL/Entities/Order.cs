using System;
using System.Collections.Generic;
using System.Text;

namespace AmaryllisTestProject.DAL.Entities
{
    public class Order : BaseEntity
    {
        public int CarId { get; set; }
        public int UserId { get; set; }
        public DateTime StartContractDateTime { get; set; }
        public DateTime FinishedContractDateTime { get; set; }
        public string Comment { get; set; }
        public Car Car { get; set; }
        public User User { get; set; }
    }
}
