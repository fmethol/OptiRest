using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiRest.Models.Dtos
{
    public class DinerUserDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string CelPhone { get; set; }
        public string FirstNames { get; set; }
        public string LastName { get; set; }
    }
}
