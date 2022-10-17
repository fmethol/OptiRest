using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiRest.Data.Models
{
    public class DinerUser
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string CelPhone { get; set; }
        public string FirstNames { get; set; }
        public string LastName { get; set; }
        

    }
}
