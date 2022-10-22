using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Table = OptiRest.Data.Models.Table;

namespace OptiRest.Models.Dtos
{
    public class AreaDto
    {
        public int Id { get; set; }
        public int TenantId { get; set; }
        public string Name { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public string Summary { get; set; }

        public ICollection<Table>? Tables { get; set; }

    }
}
