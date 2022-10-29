using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiRest.Models.Dtos
{
    public class OrderDto
    {
        public int TableServiceId { get; set; }

        public List<OrderDetailDto> OrderDetails { get; set; }
    }
}
