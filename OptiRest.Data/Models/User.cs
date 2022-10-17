using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiRest.Data.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public int TenantId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string FirstNames { get; set; }
        public string LastName { get; set; }
        public int RoleId { get; set; }
        public bool Active { get; set; }

        public List<Kitchen>? Kitchens { get; set; }
        //public List<Table>? Tables { get; set; }
    }
}
