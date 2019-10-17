using System.Collections.Generic;

namespace sws.TAIFDriver.a
{
	public sealed class f
	{
	  public static readonly f a = new f("a", InnerEnum.a, 1);
	  public static readonly f b = new f("b", InnerEnum.b, 2);
	  public static readonly f c = new f("c", InnerEnum.c, 3);
	  public static readonly f d = new f("d", InnerEnum.d, 16);
	  public static readonly f e = new f("e", InnerEnum.e, 17);
	  public static readonly f f = new f("f", InnerEnum.f, 32);
	  public static readonly f g = new f("g", InnerEnum.g, 48);
	  public static readonly f h = new f("h", InnerEnum.h, 49);
	  public static readonly f i = new f("i", InnerEnum.i, 96);
	  public static readonly f j = new f("j", InnerEnum.j, 1);
	  public static readonly f k = new f("k", InnerEnum.k, 2);
	  public static readonly f l = new f("l", InnerEnum.l, 16);
	  public static readonly f m = new f("m", InnerEnum.m, 17);
	  public static readonly f n = new f("n", InnerEnum.n, 64);
	  public static readonly f o = new f("o", InnerEnum.o, 80);
	  public static readonly f p = new f("p", InnerEnum.p, 96);

	  private static readonly IList<f> valueList = new List<f>();

	  static f()
	  {
		  valueList.Add(a);
		  valueList.Add(b);
		  valueList.Add(c);
		  valueList.Add(d);
		  valueList.Add(e);
		  valueList.Add(f);
		  valueList.Add(g);
		  valueList.Add(h);
		  valueList.Add(i);
		  valueList.Add(j);
		  valueList.Add(k);
		  valueList.Add(l);
		  valueList.Add(m);
		  valueList.Add(n);
		  valueList.Add(o);
		  valueList.Add(p);
	  }

	  public enum InnerEnum
	  {
		  a,
		  b,
		  c,
		  d,
		  e,
		  f,
		  g,
		  h,
		  i,
		  j,
		  k,
		  l,
		  m,
		  n,
		  o,
		  p
	  }

	  public readonly InnerEnum innerEnumValue;
	  private readonly string nameValue;
	  private readonly int ordinalValue;
	  private static int nextOrdinal = 0;

	  private int q;

	  internal f(string name, InnerEnum innerEnum, int paramInt1)
	  {
		  this.q = paramInt1;

		  nameValue = name;
		  ordinalValue = nextOrdinal++;
		  innerEnumValue = innerEnum;
	  }

	  public int a()
	  {
		  return this.q;
	  }

		public static IList<f> values()
		{
			return valueList;
		}

		public int ordinal()
		{
			return ordinalValue;
		}

		public override string ToString()
		{
			return nameValue;
		}

		public static f valueOf(string name)
		{
			foreach (f enumInstance in f.valueList)
			{
				if (enumInstance.nameValue == name)
				{
					return enumInstance;
				}
			}
			throw new System.ArgumentException(name);
		}
	}


	/* Location:              D:\jobs\BalitTanah.SoilSensingKit\Decompile Driver\SDK v4.3\SDKv4.3\bin_win_x64\TAIFDriver.jar!\sws\TAIFDriver\a\f.class
	 * Java compiler version: 7 (51.0)
	 * JD-Core Version:       1.0.7
	 */
}