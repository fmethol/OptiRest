﻿using OptiRest.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiRest.Models.Dtos
{
    public class UserDto
    {
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
    }
}
