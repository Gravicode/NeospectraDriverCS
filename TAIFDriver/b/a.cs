using System;

namespace sws.TAIFDriver.b
{
	using b = sws.TAIFDriver.a.b;

	public class a : Exception
	{
//JAVA TO C# CONVERTER NOTE: Members cannot have the same name as their enclosing type:
	  private const long a_Conflict = -5771960360292389271L;

	  private b b;

	  public a()
	  {
	  }

	  public a(b paramb)
	  {
		  this.b = paramb;
	  }

	  public a(Exception paramThrowable, b paramb) : base(paramThrowable)
	  {
		this.b = paramb;
	  }

	  public a(string paramString) : base(paramString)
	  {
	  }

	  public a(string paramString, b paramb) : base(paramString)
	  {
		this.b = paramb;
	  }

	  public b a()
	  {
		  return this.b;
	  }
	}


	/* Location:              D:\jobs\BalitTanah.SoilSensingKit\Decompile Driver\SDK v4.3\SDKv4.3\bin_win_x64\TAIFDriver.jar!\sws\TAIFDriver\b\a.class
	 * Java compiler version: 7 (51.0)
	 * JD-Core Version:       1.0.7
	 */
}