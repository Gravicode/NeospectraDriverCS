using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeospectraApp.MathHelper
{
    public class SplineInterpolation
    {
        private double[] x;
        private double[] y;
        private double[] h;
        private double[] b;
        private double[] c;
        private double[] d;

        public SplineInterpolation(double[] x, double[] y)
        {
            this.x = x;
            this.y = y;

            int n = x.Length;
            h = new double[n - 1];
            b = new double[n - 1];
            c = new double[n];
            d = new double[n - 1];

            for (int i = 0; i < n - 1; i++)
            {
                h[i] = x[i + 1] - x[i];
                b[i] = (y[i + 1] - y[i]) / h[i];
            }

            for (int i = 1; i < n - 1; i++)
            {
                double hi = h[i - 1];
                double hi1 = h[i];
                double bim1 = b[i - 1];
                double bi = b[i];

                c[i] = (bi - bim1 - hi * c[i - 1]) / (2 * (hi + hi1));
                d[i - 1] = (c[i] - c[i - 1]) / (3 * hi);
            }
        }

        public double Interpolate(double xi)
        {
            int k = 0;
            for (int i = 0; i < x.Length - 1; i++)
            {
                if (xi >= x[i] && xi <= x[i + 1])
                {
                    k = i;
                    break;
                }
            }

            double xi1 = x[k + 1];
            double hi = h[k];
            double yk = y[k];
            double yk1 = y[k + 1];
            double bi = b[k];
            double ci = c[k];
            double di = d[k];

            double dx = xi - x[k];

            double yi = yk + bi * dx + ci * dx * dx + di * dx * dx * dx;

            return yi;
        }

        public double[] Interpolate(double[] xs)
        {
            double[] ys = new double[xs.Length];

            for (int j = 0; j < xs.Length; j++)
            {
                ys[j] = Interpolate(xs[j]);
            }

            return ys;
        }
    }

}
