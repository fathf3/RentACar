﻿using RentACar.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Domain.Entities
{
    public class SocialMedia : BaseEntity
    {
        public string Name { get; set; }
        public string Link { get; set; }
        public string IconUrl { get; set; }
    }
}
