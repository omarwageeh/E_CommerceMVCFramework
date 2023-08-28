﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Model
{
    public class Product : BaseEntity
    {
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public decimal UnitPrice { get; set; }
        public int StockQuantity { get; set; }
        public Category Category { get; set; }
    }
}
