using System.Collections.Generic;

namespace sws.TAIFDriver.a
{
	public sealed class a
	{
	  public static readonly a a = new a("a", InnerEnum.a, 1);
	  public static readonly a b = new a("b", InnerEnum.b, 2);
	  public static readonly a c = new a("c", InnerEnum.c, 4);
	  public static readonly a d = new a("d", InnerEnum.d, 8);
	  public static readonly a e = new a("e", InnerEnum.e, 16);
	  public static readonly a f = new a("f", InnerEnum.f, 32);
	  public static readonly a g = new a("g", InnerEnum.g, 64);
	  public static readonly a h = new a("h", InnerEnum.h, 128);
	  public static readonly a i = new a("i", InnerEnum.i, 0);

	  private static readonly IList<a> valueList = new List<a>();

	  static a()
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
		  i
	  }

	  public readonly InnerEnum innerEnumValue;
	  private readonly string nameValue;
	  private readonly int ordinalValue;
	  private static int nextOrdinal = 0;

	  private int j;

	  internal a(string name, InnerEnum innerEnum, int paramInt1)
	  {
		  this.j = paramInt1;

		  nameValue = name;
		  ordinalValue = nextOrdinal++;
		  innerEnumValue = innerEnum;
	  }

	  public int a(string name, InnerEnum innerEnum)
	  {
		  return this.j;

		  nameValue = name;
		  ordinalValue = nextOrdinal++;
		  innerEnumValue = innerEnum;
	  }

		public static IList<a> values()
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

		public static a valueOf(string name)
		{
			foreach (a enumInstance in a.valueList)
			{
				if (enumInstance.nameValue == name)
				{
					return enumInstance;
				}
			}
			throw new System.ArgumentException(name);
		}
	}


	/* Location:              D:\jobs\BalitTanah.SoilSensingKit\Decompile Driver\SDK v4.3\SDKv4.3\bin_win_x64\TAIFDriver.jar!\sws\TAIFDriver\a\a.class
	 * Java compiler version: 7 (51.0)
	 * JD-Core Version:       1.0.7
	 */
}