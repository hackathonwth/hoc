﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HOC.Entities.Models.DB
{
    public partial class Schedules
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
