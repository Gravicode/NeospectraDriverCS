using System.Collections.Generic;

namespace sws.TAIFDriver.ClassA
{

    public class aa
    {
        private int data { get; set; }
        public aa(int val)
        {
            this.data = (int)val;
        }

        public int getValue()
        {
            return this.data;
        }

        public static readonly aa a = new aa(1);
        public static readonly aa b = new aa(2);
        public static readonly aa c = new aa(4);
        public static readonly aa d = new aa(8);
        public static readonly aa e = new aa(16);
        public static readonly aa f = new aa(32);
        public static readonly aa g = new aa(64);
        public static readonly aa h = new aa(128);
        public static readonly aa i = new aa(0);
        
    }


	/* Location:              D:\jobs\BalitTanah.SoilSensingKit\Decompile Driver\SDK v4.3\SDKv4.3\bin_win_x64\TAIFDriver.jar!\sws\TAIFDriver\a\a.class
	 * Java compiler version: 7 (51.0)
	 * JD-Core Version:       1.0.7
	 */
}