namespace sws.p2AppManager.utils
{
	public class p2AppManagerNotification
	{
	  private int a;

	  private int b;

	  private string c;

	  public p2AppManagerNotification(int paramInt1, int paramInt2, string paramString)
	  {
		this.a = paramInt1;
		this.b = paramInt2;
		this.c = paramString;
	  }

	  public virtual int Action
	  {
		  get
		  {
			  return this.a;
		  }
		  set
		  {
			  this.a = value;
		  }
	  }


	  public virtual int Status
	  {
		  get
		  {
			  return this.b;
		  }
		  set
		  {
			  this.b = value;
		  }
	  }


	  public virtual string DeviceId
	  {
		  get
		  {
			  return this.c;
		  }
		  set
		  {
			  this.c = value;
		  }
	  }

	}


	/* Location:              D:\jobs\BalitTanah.SoilSensingKit\Decompile Driver\SDK v4.3\SDKv4.3\bin_win_x64\p2AppManager.jar!\sws\p2AppManage\\utils\p2AppManagerNotification.class
	 * Java compiler version: 7 (51.0)
	 * JD-Core Version:       1.0.7
	 */
}