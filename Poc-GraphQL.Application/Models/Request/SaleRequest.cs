﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poc_GraphQL.Application.Models.Request
{
    public class SaleRequest
    {
        public int Price { get; set; }
        public string? Product { get; set; }
        public int CustomerId { get; set; }
    }
}
