﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonDB.Data.Model
{
    public partial class Staff
    {
        public string Name()
        {
            return $"{this.FirstName} {this.LastName}";
        }
    }
}