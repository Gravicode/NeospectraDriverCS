using System;

namespace sws.p2AppManager.utils
{
	public class p2AppManagerException : Exception
	{
	  private const long a = 1L;

	  private int b = 0;

	  public p2AppManagerException(string paramString, int paramInt) : base(paramString)
	  {
		this.b = paramInt;
	  }

	  public virtual int ErrorCode
	  {
		  get
		  {
			  return this.b;
		  }
	  }
	}


	/* Location:              D:\jobs\BalitTanah.SoilSensingKit\Decompile Driver\SDK v4.3\SDKv4.3\bin_win_x64\p2AppManager.jar!\sws\p2AppManage\\utils\p2AppManagerException.class
	 * Java compiler version: 7 (51.0)
	 * JD-Core Version:       1.0.7
	 */
}