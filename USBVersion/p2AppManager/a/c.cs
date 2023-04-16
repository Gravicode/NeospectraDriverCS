namespace sws.p2AppManager.a
{
	using p2AppManagerUtils = sws.p2AppManager.utils.p2AppManagerUtils;
	using p2Constants = sws.p2AppManager.utils.p2Constants;
	using p2Enumerations = sws.p2AppManager.utils.p2Enumerations;

	public class c : a
	{
//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
	  private string j_Conflict;

	  private string k;

	  private string l;

	  private string m;

	  private double[] n;

	  private double[] o;

	  private double[] p;

	  private double[] q;

	  public virtual string f()
	  {
		  return this.k;
	  }

	  public virtual double[] g()
	  {
		  return this.n;
	  }

	  public virtual double[] h()
	  {
		  return this.o;
	  }

	  public virtual double[] i()
	  {
		  return this.p;
	  }

	  public virtual double[] j()
	  {
		  return this.q;
	  }

	  protected internal override void b(params string[] paramVarArgs)
	  {
		this.f = p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.CONFIG_SAMPLE_PROFILE_FILES_PATH_TEMPLATE), new object[] {paramVarArgs[0], paramVarArgs[1], "param.conf"});
		this.g = p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.CONFIG_SAMPLE_PROFILE_FILES_PATH_TEMPLATE), new object[] {paramVarArgs[0], paramVarArgs[1], "t.reg"});
		this.j_Conflict = p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.CONFIG_SAMPLE_PROFILE_FILES_PATH_TEMPLATE), new object[] {paramVarArgs[0], paramVarArgs[1], "C2x.cal"});
		this.k = p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.CONFIG_SAMPLE_PROFILE_FILES_PATH_TEMPLATE), new object[] {paramVarArgs[0], paramVarArgs[1], "corr.cal"});
		this.l = p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.CONFIG_SAMPLE_PROFILE_FILES_PATH_TEMPLATE), new object[] {paramVarArgs[0], paramVarArgs[1], "wl_corr.cal"});
		this.m = p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.CONFIG_SAMPLE_PROFILE_FILES_PATH_TEMPLATE), new object[] {paramVarArgs[0], paramVarArgs[1], "wavelength_corr.cal"});
		this.e_Conflict = int.Parse(paramVarArgs[2]);
	  }

	  protected internal override p2Enumerations.p2AppManagerStatus e()
	  {
		this.n = p2AppManagerUtils.loadRawDataFile(this.j_Conflict);
		if (this.n == null)
		{
		  return p2Enumerations.p2AppManagerStatus.CONFIG_FILES_LOADING_ERROR;
		}
		this.o = p2AppManagerUtils.loadRawDataFile(this.k);
		if (this.o == null || this.o.Length != 2)
		{
		  this.o = null;
		  return p2Enumerations.p2AppManagerStatus.CONFIG_FILES_LOADING_ERROR;
		}
		this.p = p2AppManagerUtils.loadRawDataFile(this.l);
		if (this.p == null || this.p.Length != 10)
		{
		  this.p = null;
		  return p2Enumerations.p2AppManagerStatus.CONFIG_FILES_LOADING_ERROR;
		}
		this.q = p2AppManagerUtils.loadRawDataFile(this.m);
		if (this.q == null || this.q.Length != 2)
		{
		  this.q = null;
		  return p2Enumerations.p2AppManagerStatus.CONFIG_FILES_LOADING_ERROR;
		}
		this.i = a(this.g);
		return (this.i == null) ? p2Enumerations.p2AppManagerStatus.INAVLID_REG_FILE_FORMAT_ERROR : p2Enumerations.p2AppManagerStatus.NO_ERROR;
	  }

	  public virtual double a(string paramString1, string paramString2)
	  {
		string str = p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.CONFIG_SAMPLE_PROFILE_FILES_PATH_TEMPLATE), new object[] {paramString1, paramString2, "param.conf"});
		double[] arrayOfDouble = p2AppManagerUtils.loadParamFile(str);
		if (arrayOfDouble == null)
		{
		  return -1.0D;
		}
		if (arrayOfDouble.Length < 58)
		{
		  double[] arrayOfDouble2 = p2AppManagerUtils.loadParamFile(str);
		  string str1 = p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.GLOBAL_CONFIG_FILES_PATH), new object[] {"param.conf"});
		  double[] arrayOfDouble1 = p2AppManagerUtils.loadParamFile(str1);
		  arrayOfDouble = new double[58];
		  sbyte b;
		  for (b = 0; b < arrayOfDouble2.Length; b++)
		  {
			arrayOfDouble[b] = arrayOfDouble2[b];
		  }
		  while (b < 58)
		  {
			arrayOfDouble[b] = arrayOfDouble1[b];
			b++;
		  }
		}
		return arrayOfDouble[33];
	  }
	}


	/* Location:              D:\jobs\BalitTanah.SoilSensingKit\Decompile Driver\SDK v4.3\SDKv4.3\bin_win_x64\p2AppManager.jar!\sws\p2AppManager\a\c.class
	 * Java compiler version: 7 (51.0)
	 * JD-Core Version:       1.0.7
	 */
}