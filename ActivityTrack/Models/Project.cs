﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ActivityTrack.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<ActivityEO> Activities { get; set; }
    }
}