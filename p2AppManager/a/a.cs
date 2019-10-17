using System;
using System.IO;

namespace sws.p2AppManager.a
{
	using p2AppManagerUtils = sws.p2AppManager.utils.p2AppManagerUtils;
	using p2Constants = sws.p2AppManager.utils.p2Constants;
	using p2Enumerations = sws.p2AppManager.utils.p2Enumerations;

	public abstract class a
	{
//JAVA TO C# CONVERTER NOTE: Members cannot have the same name as their enclosing type:
	  protected internal readonly int a_Conflict = 58;

//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
	  protected internal readonly int b_Conflict = 10;

//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
	  protected internal readonly int c_Conflict = 2;

//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
	  protected internal readonly int d_Conflict = 2;

//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
	  protected internal int e_Conflict;

	  protected internal string f;

	  protected internal string g;

	  protected internal double[] h;

	  protected internal long[] i;

	  public string a()
	  {
		  return this.g;
	  }

	  public virtual double[] b()
	  {
		  return this.h;
	  }

//JAVA TO C# CONVERTER NOTE: Members cannot have the same name as their enclosing type:
	  public virtual void a_Conflict(double[] paramArrayOfDouble)
	  {
		  this.h = paramArrayOfDouble;
	  }

	  public virtual long[] c()
	  {
		  return this.i;
	  }

//JAVA TO C# CONVERTER NOTE: Members cannot have the same name as their enclosing type:
	  public virtual void a_Conflict(double paramDouble)
	  {
		  this.h[9] = paramDouble;
	  }

	  public virtual p2Enumerations.p2AppManagerStatus d()
	  {
		  return a(new string[] {(string)null});
	  }

	  public p2Enumerations.p2AppManagerStatus a(params string[] paramVarArgs)
	  {
		try
		{
		  b(paramVarArgs);
		  this.h = p2AppManagerUtils.loadParamFile(this.f);
		  if (this.h == null)
		  {
			return p2Enumerations.p2AppManagerStatus.CONFIG_FILES_LOADING_ERROR;
		  }
		  if (this.h.Length < 58)
		  {
			double[] arrayOfDouble2 = p2AppManagerUtils.loadParamFile(this.f);
			string str = p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.GLOBAL_CONFIG_FILES_PATH), new object[] {"param.conf"});
			double[] arrayOfDouble1 = p2AppManagerUtils.loadParamFile(str);
			this.h = new double[58];
			sbyte b1;
			for (b1 = 0; b1 < arrayOfDouble2.Length; b1++)
			{
			  this.h[b1] = arrayOfDouble2[b1];
			}
			while (b1 < 58)
			{
			  this.h[b1] = arrayOfDouble1[b1];
			  b1++;
			}
		  }
		  else if (this.h.Length != 58)
		  {
			return p2Enumerations.p2AppManagerStatus.CONFIG_PARAM_LENGTH_ERROR;
		  }
		  return e();
		}
		catch (Exception)
		{
		  return p2Enumerations.p2AppManagerStatus.CONFIG_FILES_LOADING_ERROR;
		}
	  }

	  protected internal long[] a(string paramString)
	  {
		try
		{
		  StreamReader bufferedReader = new StreamReader(paramString);
		  long[] arrayOfLong = new long[this.e_Conflict];
		  for (sbyte b1 = 0; b1 < this.e_Conflict; b1++)
		  {
			arrayOfLong[b1] = Convert.ToInt64(bufferedReader.ReadLine(), 16);
		  }
		  bufferedReader.Close();
		  return arrayOfLong;
		}
		catch (Exception)
		{
		  return null;
		}
	  }

	  internal abstract void b(params string[] paramVarArgs);

	  internal abstract p2Enumerations.p2AppManagerStatus e();
	}


	/* Location:              D:\jobs\BalitTanah.SoilSensingKit\Decompile Driver\SDK v4.3\SDKv4.3\bin_win_x64\p2AppManager.jar!\sws\p2AppManager\a\a.class
	 * Java compiler version: 7 (51.0)
	 * JD-Core Version:       1.0.7
	 */
}