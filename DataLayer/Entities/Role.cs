﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Role
    {
        public Role(string role)
        {
            RoleName = role;
        }
        public Role() { }

        public int Id { get; set; }
        public string RoleName { get; set; }
    }
}
