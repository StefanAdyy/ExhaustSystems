﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Part:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }

        public ICollection<OrderedPart> OrderedParts { get; set; }
    }
}
