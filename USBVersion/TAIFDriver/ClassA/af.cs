using System.Collections.Generic;

namespace sws.TAIFDriver.ClassA
{
    public class af
    {
        private int data { get; set; }
        public af(int val)
        {
            this.data = (int)val;
        }

        public int getValue()
        {
            return this.data;
        }

        public static readonly af a = new af(1);
        public static readonly af b = new af(2);
        public static readonly af c = new af(3);
        public static readonly af d = new af(16);
        public static readonly af e = new af(17);
        public static readonly af f = new af(32);
        public static readonly af g = new af(48);
        public static readonly af h = new af(49);
        public static readonly af i = new af(96);
        public static readonly af j = new af(1);
        public static readonly af k = new af(2);
        public static readonly af l = new af(16);
        public static readonly af m = new af(17);
        public static readonly af n = new af(64);
        public static readonly af o = new af(80);
        public static readonly af p = new af(96);


    }

    /* Location:              D:\jobs\BalitTanah.SoilSensingKit\Decompile Driver\SDK v4.3\SDKv4.3\bin_win_x64\TAIFDriver.jar!\sws\TAIFDriver\a\f.class
	 * Java compiler version: 7 (51.0)
	 * JD-Core Version:       1.0.7
	 */
}