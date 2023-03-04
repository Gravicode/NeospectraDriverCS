using System;

namespace com.gravicode.neospectralib.Models
{
    public class dbReading : Serializable
    {
        private double[] yReading;
        private double[] xReading;

        public dbReading()
        {
        }

        public double[] getXReading()
        {
            return xReading;
        }

        public double[] getYReading()
        {
            return yReading;
        }

        public void setReading(double[] yReading, double[] xReading)
        {
            this.yReading = yReading;
            this.xReading = xReading;
        }

        public override string ToString()
        {
            return "dbReading{" +
                "yReading=" + string.Join(",", yReading) +
                ", xReading=" + string.Join(",", xReading) +
                '}';
        }
    }
}
