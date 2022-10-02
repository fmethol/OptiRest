﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiRest.Models.Dtos
{
    public class TakedRangeDto
    {
        public int takedRangeId { get; set; }

        public int tenantId { get; set; }

        public string name { get; set; }

        public string summary { get; set; }
    }
}
