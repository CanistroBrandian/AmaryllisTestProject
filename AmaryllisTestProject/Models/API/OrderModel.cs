﻿using AmaryllisTestProject.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmaryllisTestProject.WEB.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int UserId { get; set; }
        public DateTime StartContractDateTime { get; set; }
        public DateTime FinishedContractDateTime { get; set; }
        public string Comment { get; set; }
    }
}
