﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeospectraApp.Driver
{
    public class DataPoint
    {
        public DataPoint(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }
        public double X { get; set; }
        public double Y { get; set; }
    }
}
