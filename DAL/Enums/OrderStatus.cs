﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Enums
{
    public enum OrderStatus
    {
        Pending, 
        Processing,
        Shipped,
        Delivered,
        Cancelled
    }
}
