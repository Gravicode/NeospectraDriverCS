using System.Collections.Generic;

namespace sws.TAIFDriver.a
{
	public sealed class h
	{
	  public static readonly h a = new h("a", InnerEnum.a, 1);
	  public static readonly h b = new h("b", InnerEnum.b, 0);

	  private static readonly IList<h> valueList = new List<h>();

	  static h()
	  {
		  valueList.Add(a);
		  valueList.Add(b);
	  }

	  public enum InnerEnum
	  {
		  a,
		  b
	  }

	  public readonly InnerEnum innerEnumValue;
	  private readonly string nameValue;
	  private readonly int ordinalValue;
	  private static int nextOrdinal = 0;

//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
	  private int c_Conflict;

	  internal h(string name, InnerEnum innerEnum, int paramInt1)
	  {
		  this.c_Conflict = paramInt1;

		  nameValue = name;
		  ordinalValue = nextOrdinal++;
		  innerEnumValue = innerEnum;
	  }

	  public int a()
	  {
		  return this.c_Conflict;
	  }

		public static IList<h> values()
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

		public static h valueOf(string name)
		{
			foreach (h enumInstance in h.valueList)
			{
				if (enumInstance.nameValue == name)
				{
					return enumInstance;
				}
			}
			throw new System.ArgumentException(name);
		}
	}


	/* Location:              D:\jobs\BalitTanah.SoilSensingKit\Decompile Driver\SDK v4.3\SDKv4.3\bin_win_x64\TAIFDriver.jar!\sws\TAIFDriver\a\h.class
	 * Java compiler version: 7 (51.0)
	 * JD-Core Version:       1.0.7
	 */
}