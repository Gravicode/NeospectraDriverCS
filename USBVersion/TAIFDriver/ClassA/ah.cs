using System.Collections.Generic;

namespace sws.TAIFDriver.ClassA
{
    public class ah
    {
        private int data { get; set; }
        public ah(int val)
        {
            this.data = (int)val;
        }

        public int getValue()
        {
            return this.data;
        }

        public static readonly ah a = new ah(1);
        public static readonly ah b = new ah(0);

    }

    /* Location:              D:\jobs\BalitTanah.SoilSensingKit\Decompile Driver\SDK v4.3\SDKv4.3\bin_win_x64\TAIFDriver.jar!\sws\TAIFDriver\a\h.class
	 * Java compiler version: 7 (51.0)
	 * JD-Core Version:       1.0.7
	 */
}