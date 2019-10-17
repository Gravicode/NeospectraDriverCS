using System.IO;

namespace sws.p2AppManager.a
{
	using p2AppManagerUtils = sws.p2AppManager.utils.p2AppManagerUtils;
	using p2Constants = sws.p2AppManager.utils.p2Constants;
	using p2Enumerations = sws.p2AppManager.utils.p2Enumerations;

	public class b : a
	{
//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
	  private readonly string j_Conflict = p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.GLOBAL_CONFIG_FILES_PATH), new object[] {"filt3.filt"});

//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
	  private readonly string k_Conflict = p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.GLOBAL_CONFIG_FILES_PATH), new object[] {"filt4.filt"});

//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
	  private readonly string l_Conflict = p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.GLOBAL_CONFIG_FILES_PATH), new object[] {"filt5.filt"});

	  private string m = p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.GLOBAL_CONFIG_FILES_PATH), new object[] {"filt6.filt"});

	  private readonly string n = p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.GLOBAL_CONFIG_FILES_PATH), new object[] {"filt7.filt"});

	  private readonly string o = p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.GLOBAL_CONFIG_FILES_PATH), new object[] {"filt9.filt"});

	  private readonly string p = p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.GLOBAL_CONFIG_FILES_PATH), new object[] {"filt10.filt"});

	  private double[] q;

	  private double[] r;

	  private double[] s;

	  private double[] t;

	  private double[] u;

	  private double[] v;

	  private double[] w;

	  public virtual double[] f()
	  {
		  return this.s;
	  }

	  public virtual double[] g()
	  {
		  return this.t;
	  }

	  public virtual double[] h()
	  {
		  return this.u;
	  }

	  public virtual double[] i()
	  {
		  return this.v;
	  }

	  public virtual double[] j()
	  {
		  return this.w;
	  }

	  public virtual double[] k()
	  {
		  return this.q;
	  }

	  public virtual double[] l()
	  {
		  return this.r;
	  }

//JAVA TO C# CONVERTER NOTE: Members cannot have the same name as their enclosing type:
	  protected internal virtual void b_Conflict(params string[] paramVarArgs)
	  {
		this.h = null;
		this.f = p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.GLOBAL_CONFIG_FILES_PATH), new object[] {"param.conf"});
	  }

	  protected internal override p2Enumerations.p2AppManagerStatus e()
	  {
		this.q = p2AppManagerUtils.loadRawDataFile(this.j_Conflict);
		if (this.q == null)
		{
		  return p2Enumerations.p2AppManagerStatus.CONFIG_FILES_LOADING_ERROR;
		}
		this.r = p2AppManagerUtils.loadRawDataFile(this.k_Conflict);
		if (this.r == null)
		{
		  return p2Enumerations.p2AppManagerStatus.CONFIG_FILES_LOADING_ERROR;
		}
		this.s = p2AppManagerUtils.loadRawDataFile(this.l_Conflict);
		if (this.s == null)
		{
		  return p2Enumerations.p2AppManagerStatus.CONFIG_FILES_LOADING_ERROR;
		}
		this.t = p2AppManagerUtils.loadRawDataFile(this.m);
		if (this.t == null)
		{
		  return p2Enumerations.p2AppManagerStatus.CONFIG_FILES_LOADING_ERROR;
		}
		this.u = p2AppManagerUtils.loadRawDataFile(this.n);
		if (this.u == null)
		{
		  return p2Enumerations.p2AppManagerStatus.CONFIG_FILES_LOADING_ERROR;
		}
		this.v = p2AppManagerUtils.loadRawDataFile(this.o);
		if (this.v == null)
		{
		  return p2Enumerations.p2AppManagerStatus.CONFIG_FILES_LOADING_ERROR;
		}
		this.w = p2AppManagerUtils.loadRawDataFile(this.p);
		return (this.w == null) ? p2Enumerations.p2AppManagerStatus.CONFIG_FILES_LOADING_ERROR : p2Enumerations.p2AppManagerStatus.NO_ERROR;
	  }

	  public virtual void a(string paramString, int paramInt)
	  {
		this.e_Conflict = paramInt;
		string str = p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "mems" + Path.DirectorySeparatorChar + "{0}" + Path.DirectorySeparatorChar + "t.reg";
		this.g = p2AppManagerUtils.formatString(str, new object[] {paramString});
		this.i = a(this.g);
	  }
	}


	/* Location:              D:\jobs\BalitTanah.SoilSensingKit\Decompile Driver\SDK v4.3\SDKv4.3\bin_win_x64\p2AppManager.jar!\sws\p2AppManager\a\b.class
	 * Java compiler version: 7 (51.0)
	 * JD-Core Version:       1.0.7
	 */
}