﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFNet5.Domain
{
    public class League : BaseDomainObject
    {
        public string Name { get; set; }
        public List<Team> Teams { get; set; }
    }
}
