using System.Threading;

namespace sws.p2AppManager.c
{

	public class b : ThreadPoolExecutor
	{
//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
	  internal const int a_Conflict = 3;

//JAVA TO C# CONVERTER NOTE: Members cannot have the same name as their enclosing type:
	  internal const int b_Conflict = 3;

	  internal const long c = 3L;

	  internal static readonly TimeUnit d = TimeUnit.MINUTES;

	  internal static readonly BlockingQueue<ThreadStart> e = new LinkedBlockingQueue();

	  private static b f;

	  private b() : base(3, 3, 3L, d, e)
	  {
	  }

	  internal static b a()
	  {
		if (f == null)
		{
		  f = new b();
		}
		return f;
	  }
	}


	/* Location:              D:\jobs\BalitTanah.SoilSensingKit\Decompile Driver\SDK v4.3\SDKv4.3\bin_win_x64\p2AppManager.jar!\sws\p2AppManager\c\b.class
	 * Java compiler version: 7 (51.0)
	 * JD-Core Version:       1.0.7
	 */
}