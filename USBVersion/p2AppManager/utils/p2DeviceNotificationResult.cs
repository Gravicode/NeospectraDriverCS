namespace sws.p2AppManager.utils
{
	public class p2DeviceNotificationResult
	{
	  private p2Enumerations.p2DeviceAction a;

	  private string b;

	  private p2Enumerations.p2AppManagerStatus c;

	  public virtual p2Enumerations.p2DeviceAction Action
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


	  public virtual string DeviceId
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


	  public virtual p2Enumerations.p2AppManagerStatus Status
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


	/* Location:              D:\jobs\BalitTanah.SoilSensingKit\Decompile Driver\SDK v4.3\SDKv4.3\bin_win_x64\p2AppManager.jar!\sws\p2AppManage\\utils\p2DeviceNotificationResult.class
	 * Java compiler version: 7 (51.0)
	 * JD-Core Version:       1.0.7
	 */
}