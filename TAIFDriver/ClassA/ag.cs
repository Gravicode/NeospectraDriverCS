using System.Collections.Generic;

namespace sws.TAIFDriver.ClassA
{
    public class ag
    {
        private int data { get; set; }
        public ag(int val)
        {
            this.data = (int)val;
        }

        public int getValue()
        {
            return this.data;
        }

        public static readonly ag a = new ag(0);
        public static readonly ag b = new ag(16);
        public static readonly ag c = new ag(17);

    }


    /* Location:              D:\jobs\BalitTanah.SoilSensingKit\Decompile Driver\SDK v4.3\SDKv4.3\bin_win_x64\TAIFDriver.jar!\sws\TAIFDriver\a\g.class
	 * Java compiler version: 7 (51.0)
	 * JD-Core Version:       1.0.7
	 */
}