using System;
using System.Collections.Generic;
using System.Text;

namespace AmaryllisTestProject.BLL.DTO
{
   public class OrderDTO
    {
        public int CarId { get; set; }
        public int UserId { get; set; }
        public DateTime StartContractDateTime { get; set; }
        public DateTime FinishedContractDateTime { get; set; }
        public string Comment { get; set; }
    }
}
