using System.Collections.Generic;

namespace sws.TAIFDriver.a
{
	public sealed class g
	{
	  public static readonly g a = new g("a", InnerEnum.a, 0);
	  public static readonly g b = new g("b", InnerEnum.b, 16);
	  public static readonly g c = new g("c", InnerEnum.c, 17);

	  private static readonly IList<g> valueList = new List<g>();

	  static g()
	  {
		  valueList.Add(a);
		  valueList.Add(b);
		  valueList.Add(c);
	  }

	  public enum InnerEnum
	  {
		  a,
		  b,
		  c
	  }

	  public readonly InnerEnum innerEnumValue;
	  private readonly string nameValue;
	  private readonly int ordinalValue;
	  private static int nextOrdinal = 0;

//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
	  private int d_Conflict;

	  internal g(string name, InnerEnum innerEnum, int paramInt1)
	  {
		  this.d_Conflict = paramInt1;

		  nameValue = name;
		  ordinalValue = nextOrdinal++;
		  innerEnumValue = innerEnum;
	  }

	  public int a()
	  {
		  return this.d_Conflict;
	  }

		public static IList<g> values()
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

		public static g valueOf(string name)
		{
			foreach (g enumInstance in g.valueList)
			{
				if (enumInstance.nameValue == name)
				{
					return enumInstance;
				}
			}
			throw new System.ArgumentException(name);
		}
	}


	/* Location:              D:\jobs\BalitTanah.SoilSensingKit\Decompile Driver\SDK v4.3\SDKv4.3\bin_win_x64\TAIFDriver.jar!\sws\TAIFDriver\a\g.class
	 * Java compiler version: 7 (51.0)
	 * JD-Core Version:       1.0.7
	 */
}