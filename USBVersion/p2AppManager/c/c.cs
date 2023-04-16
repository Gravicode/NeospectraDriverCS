using System;

namespace sws.p2AppManager.c
{
	using p2AppManagerException = sws.p2AppManager.utils.p2AppManagerException;
	using p2Enumerations = sws.p2AppManager.utils.p2Enumerations;

	public class c
	{
//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
	  private static b a_Conflict = b.a();

	  public static Future<T> a<T>(a<T> parama)
	  {
		try
		{
		  return a_Conflict.submit(parama);
		}
		catch (Exception)
		{
		  throw new p2AppManagerException("Failed to sumbit current job ", p2Enumerations.p2AppManagerStatus.THREADING_ERROR.NumVal);
		}
	  }

	  public static void a()
	  {
		  a_Conflict.shutdown();
	  }

	  public static bool b()
	  {
		  return a_Conflict.Terminated;
	  }
	}


	/* Location:              D:\jobs\BalitTanah.SoilSensingKit\Decompile Driver\SDK v4.3\SDKv4.3\bin_win_x64\p2AppManager.jar!\sws\p2AppManager\c\c.class
	 * Java compiler version: 7 (51.0)
	 * JD-Core Version:       1.0.7
	 */
}