using System;
using System.Collections.Generic;
using System.Text;

namespace NASANavigateRover
{
    public class Position
    {
        public Position(int xAxis, int yAxis)
        {
            XAxis = xAxis;
            YAxis = yAxis;
        }

        public int XAxis { get; set; }

        public int YAxis { get; set; }
    }
}
