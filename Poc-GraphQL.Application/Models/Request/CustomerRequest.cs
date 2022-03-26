using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poc_GraphQL.Application.Models.Request
{
    public class CustomerRequest
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime Birth { get; set; }
    }
}
