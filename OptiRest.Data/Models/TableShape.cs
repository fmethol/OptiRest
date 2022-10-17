using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiRest.Data.Models
{
    public class TableShape
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
