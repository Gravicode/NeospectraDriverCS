using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace sws.p2AppManager.b
{
	using FileUtils = org.apache.commons.io.FileUtils;
	using Logger = org.apache.log4j.Logger;
	using a = sws.TAIFDriver.a;
	using i = sws.TAIFDriver.a.i;
	using j = sws.TAIFDriver.a.j;
	using k = sws.TAIFDriver.a.k;
	using a = sws.TAIFDriver.b.a;
	using c = sws.TAIFDriver.c.c;
	using b = sws.p2AppManager.a.b;
	using c = sws.p2AppManager.a.c;
	using sws.p2AppManager.c;
	using c = sws.p2AppManager.c.c;
	using a = sws.p2AppManager.dspAPI.a;
	using p2SpectroDSP = sws.p2AppManager.dspAPI.p2SpectroDSP;
	using p2AppManagerException = sws.p2AppManager.utils.p2AppManagerException;
	using p2AppManagerUtils = sws.p2AppManager.utils.p2AppManagerUtils;
	using p2Constants = sws.p2AppManager.utils.p2Constants;
	using p2DeviceNotificationResult = sws.p2AppManager.utils.p2DeviceNotificationResult;
	using p2Enumerations = sws.p2AppManager.utils.p2Enumerations;

	public class b : a
	{
		private bool InstanceFieldsInitialized = false;

		private void InitializeInstanceFields()
		{
			O = new a(this, int.Parse(this.N), p2Constants.APPLICATION_WORKING_DIRECTORY);
		}

//JAVA TO C# CONVERTER NOTE: Members cannot have the same name as their enclosing type:
	  private static Logger b_Conflict = Logger.getLogger(typeof(b_Conflict));

//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
	  private string c_Conflict;

//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
	  private p2Enumerations.p2AppManagerState d_Conflict = p2Enumerations.p2AppManagerState.Idle;

//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
	  private double[][] e_Conflict = (double[][])null;

//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
	  private double[][] f_Conflict = (double[][])null;

//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
	  private double[][] g_Conflict = (double[][])null;

//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
	  private double[][] h_Conflict = (double[][])null;

//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
	  private double[][] i_Conflict = (double[][])null;

//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
	  private double[][] j_Conflict = (double[][])null;

//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
	  private double[][] k_Conflict = (double[][])null;

//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
	  private double[][] l_Conflict = (double[][])null;

//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
	  private double[][] m_Conflict = (double[][])null;

//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
	  private double[][] n_Conflict = (double[][])null;

//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
	  private double[][] o_Conflict = (double[][])null;

//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
	  private double[][] p_Conflict = (double[][])null;

//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
	  private double[][] q_Conflict = (double[][])null;

//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
	  private double[][] r_Conflict = (double[][])null;

//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
	  private double[][] s_Conflict = (double[][])null;

//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
	  private double[][] t_Conflict = (double[][])null;

//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
	  private double[][] u_Conflict = (double[][])null;

//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
	  private double[][] v_Conflict = (double[][])null;

//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
	  private double[][] w_Conflict = (double[][])null;

//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
	  private double[][] x_Conflict = (double[][])null;

//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
	  private long[] y_Conflict = null;

//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
	  private double z_Conflict = 0.0D;

//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
	  private double A_Conflict = 0.0D;

//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
	  private double B_Conflict = 0.0D;

//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
	  private c C_Conflict = new c();

//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
	  private b D_Conflict;

//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
	  private string E_Conflict = "";

//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
	  private string F_Conflict = "";

//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
	  private string G_Conflict = "";

//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
	  private bool H_Conflict = false;

//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
	  private bool I_Conflict = false;

//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
	  private string J_Conflict = "";

	  private string K = "";

	  private bool L = false;

	  private double M = 1.0D;

	  private string N = "21845";

	  private a O;

	  private double[] P;

	  private readonly int Q = 31;

//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
	  internal int[][] a_Conflict = new int[][]
	  {
		  new int[] {0, 0, 1},
		  new int[] {1, 0, 2},
		  new int[] {1, 1, 4},
		  new int[] {3, 0, 6},
		  new int[] {2, 1, 8},
		  new int[] {5, 0, 10},
		  new int[] {3, 1, 12},
		  new int[] {2, 2, 16},
		  new int[] {5, 1, 20},
		  new int[] {3, 2, 24},
		  new int[] {4, 2, 32},
		  new int[] {3, 3, 36},
		  new int[] {5, 2, 40},
		  new int[] {4, 3, 48},
		  new int[] {5, 3, 60},
		  new int[] {4, 4, 64},
		  new int[] {5, 4, 80},
		  new int[] {5, 5, 100}
	  };

	  public virtual void u()
	  {
		  this.O.a(p2Constants.APPLICATION_WORKING_DIRECTORY);
	  }

	  private p2Enumerations.p2AppManagerState w()
	  {
		  return this.d_Conflict;
	  }

	  private void a(p2Enumerations.p2AppManagerState paramp2AppManagerState)
	  {
		b_Conflict.info("------State Change------From------" + this.d_Conflict + "-----To-----" + paramp2AppManagerState);
		this.d_Conflict = paramp2AppManagerState;
	  }

	  public virtual string a()
	  {
		  return this.c_Conflict;
	  }

	  public virtual p2Enumerations.p2AppManagerStatus a(b paramb, params string[] paramVarArgs)
	  {
		if (p2Enumerations.p2AppManagerState.Idle != w())
		{
		  return p2Enumerations.p2AppManagerStatus.DEVICE_BUSY_ERROR;
		}
		p2Enumerations.p2AppManagerStatus p2AppManagerStatus = y();
		if (p2Enumerations.p2AppManagerStatus.BOARD_DISTCONNECTED_ERROR == p2AppManagerStatus || p2Enumerations.p2AppManagerStatus.BOARD_ALREADY_INITIALIZED == p2AppManagerStatus || p2Enumerations.p2AppManagerStatus.UNKNOWN_ERROR == p2AppManagerStatus)
		{
		  return p2AppManagerStatus;
		}
		if (p2Enumerations.p2AppManagerStatus.BOARD_NOT_INITIALIZED_ERROR == p2AppManagerStatus)
		{
		  a(p2Enumerations.p2AppManagerState.Initialize);
		  this.D_Conflict = paramb;
		  x();
		}
		return p2Enumerations.p2AppManagerStatus.NO_ERROR;
	  }

	  public p2Enumerations.p2AppManagerStatus b(b paramb, params string[] paramVarArgs)
	  {
		  if (!InstanceFieldsInitialized)
		  {
			  InitializeInstanceFields();
			  InstanceFieldsInitialized = true;
		  }
		if (p2Enumerations.p2AppManagerState.Idle != w())
		{
		  return (p2Enumerations.p2AppManagerState.Initialize == w()) ? p2Enumerations.p2AppManagerStatus.INITIALIZATION_IN_PROGRESS : p2Enumerations.p2AppManagerStatus.NO_ERROR;
		}
		a(p2Enumerations.p2AppManagerState.CheckingDeviceStatus);
		p2Enumerations.p2AppManagerStatus p2AppManagerStatus = y();
		a(p2Enumerations.p2AppManagerState.Idle);
		b_Conflict.info("checkBoardStatus method returned : " + p2AppManagerStatus.ToString());
		if (p2Enumerations.p2AppManagerStatus.BOARD_ALREADY_INITIALIZED == p2AppManagerStatus)
		{
		  return p2Enumerations.p2AppManagerStatus.NO_ERROR;
		}
		if (p2Enumerations.p2AppManagerStatus.BOARD_NOT_INITIALIZED_ERROR == p2AppManagerStatus)
		{
		  a(paramb, new string[0]);
		}
		else if (p2AppManagerStatus == p2Enumerations.p2AppManagerStatus.INITIATE_TAIFDRIVER_ERROR)
		{
		  b_Conflict.error("INITIATE_TAIFDRIVER_ERROR returned but the application manager swallowed it");
		  return p2Enumerations.p2AppManagerStatus.INITIALIZATION_IN_PROGRESS;
		}
		return p2AppManagerStatus;
	  }

	  public virtual void u(b paramb, params string[] paramVarArgs)
	  {
		this.F_Conflict = paramVarArgs[0];
		if (paramVarArgs.Length == 1)
		{
		  this.H_Conflict = true;
		}
		else
		{
		  this.H_Conflict = bool.Parse(paramVarArgs[1]);
		}
	  }

	  public virtual void a(params string[] paramVarArgs)
	  {
		this.J_Conflict = paramVarArgs[0];
		this.K = paramVarArgs[1];
		this.L = true;
	  }

	  public virtual p2Enumerations.p2AppManagerStatus c(b paramb, params string[] paramVarArgs)
	  {
		a a1;
		if (paramVarArgs.Length != 4 && paramVarArgs.Length != 2)
		{
		  return p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR;
		}
		if (p2Enumerations.p2AppManagerState.Idle != this.d_Conflict)
		{
		  return p2Enumerations.p2AppManagerStatus.DEVICE_BUSY_ERROR;
		}
		bool bool1 = false;
		p2Enumerations.p2AppManagerStatus p2AppManagerStatus = y();
		if (p2Enumerations.p2AppManagerStatus.BOARD_DISTCONNECTED_ERROR == p2AppManagerStatus || p2Enumerations.p2AppManagerStatus.UNKNOWN_ERROR == p2AppManagerStatus)
		{
		  return p2AppManagerStatus;
		}
		if (p2Enumerations.p2AppManagerStatus.BOARD_NOT_INITIALIZED_ERROR == p2AppManagerStatus)
		{
		  bool1 = true;
		}
		bool bool2 = bool.Parse(paramVarArgs[1]);
		try
		{
		  if (bool2)
		  {
			if (this.f_Conflict == null)
			{
			  return p2Enumerations.p2AppManagerStatus.NO_VALID_BG_DATA_ERROR;
			}
			if (this.z_Conflict < double.Parse(paramVarArgs[0]))
			{
			  return p2Enumerations.p2AppManagerStatus.INVALID_RUN_TIME_NOT_EQUAL_BG_RUN_TIME_ERROR;
			}
			a1 = a(p2Enumerations.p2DeviceAction.RunSpecSample, paramVarArgs);
			this.e_Conflict = (double[][])null;
		  }
		  else
		  {
			this.z_Conflict = double.Parse(paramVarArgs[0]);
			a1 = a(p2Enumerations.p2DeviceAction.RunSpecBackground, paramVarArgs);
			this.f_Conflict = (double[][])null;
		  }
		}
		catch (Exception)
		{
		  return p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR;
		}
		this.D_Conflict = paramb;
		p(a1, bool1);
		return p2Enumerations.p2AppManagerStatus.NO_ERROR;
	  }

	  public virtual p2Enumerations.p2AppManagerStatus d(b paramb, params string[] paramVarArgs)
	  {
		a a1;
		if (paramVarArgs.Length != 3)
		{
		  return p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR;
		}
		if (p2Enumerations.p2AppManagerState.Idle != this.d_Conflict)
		{
		  return p2Enumerations.p2AppManagerStatus.DEVICE_BUSY_ERROR;
		}
		bool @bool = false;
		p2Enumerations.p2AppManagerStatus p2AppManagerStatus = y();
		if (p2Enumerations.p2AppManagerStatus.BOARD_DISTCONNECTED_ERROR == p2AppManagerStatus || p2Enumerations.p2AppManagerStatus.UNKNOWN_ERROR == p2AppManagerStatus)
		{
		  return p2AppManagerStatus;
		}
		if (p2Enumerations.p2AppManagerStatus.BOARD_NOT_INITIALIZED_ERROR == p2AppManagerStatus)
		{
		  @bool = true;
		}
		try
		{
		  this.g_Conflict = (double[][])null;
		  a1 = a(p2Enumerations.p2DeviceAction.RunWavelengthCalibrationBG, paramVarArgs);
		}
		catch (Exception)
		{
		  return p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR;
		}
		this.D_Conflict = paramb;
		p(a1, @bool);
		return p2Enumerations.p2AppManagerStatus.NO_ERROR;
	  }

	  public virtual p2Enumerations.p2AppManagerStatus e(b paramb, params string[] paramVarArgs)
	  {
		a a1;
		if (paramVarArgs.Length != 4)
		{
		  return p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR;
		}
		if (p2Enumerations.p2AppManagerState.Idle != this.d_Conflict)
		{
		  return p2Enumerations.p2AppManagerStatus.DEVICE_BUSY_ERROR;
		}
		bool @bool = false;
		p2Enumerations.p2AppManagerStatus p2AppManagerStatus = y();
		if (p2Enumerations.p2AppManagerStatus.BOARD_DISTCONNECTED_ERROR == p2AppManagerStatus || p2Enumerations.p2AppManagerStatus.UNKNOWN_ERROR == p2AppManagerStatus)
		{
		  return p2AppManagerStatus;
		}
		if (p2Enumerations.p2AppManagerStatus.BOARD_NOT_INITIALIZED_ERROR == p2AppManagerStatus)
		{
		  @bool = true;
		}
		try
		{
		  if (this.g_Conflict == null)
		  {
			return p2Enumerations.p2AppManagerStatus.NO_VALID_BG_DATA_ERROR;
		  }
		  a1 = a(p2Enumerations.p2DeviceAction.RunWavelengthCalibration, paramVarArgs);
		}
		catch (Exception)
		{
		  return p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR;
		}
		this.D_Conflict = paramb;
		p(a1, @bool);
		return p2Enumerations.p2AppManagerStatus.NO_ERROR;
	  }

	  public double b()
	  {
		  if (!InstanceFieldsInitialized)
		  {
			  InitializeInstanceFields();
			  InstanceFieldsInitialized = true;
		  }
		  return this.M;
	  }

	  public virtual double[][] c()
	  {
		if (p2Enumerations.p2AppManagerState.Idle != w())
		{
		  b_Conflict.error("p2Device is busy now");
		  return (double[][])null;
		}
		if (this.e_Conflict == null)
		{
		  b_Conflict.error("there is no Spec data may be you don't have any successful spec run ");
		  return (double[][])null;
		}
		return this.e_Conflict;
	  }

	  public virtual p2Enumerations.p2AppManagerStatus a(b paramb, double[][] paramArrayOfDouble, params string[] paramVarArgs)
	  {
		a a1;
		if (paramVarArgs.Length != 3 && paramVarArgs.Length != 1)
		{
		  return p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR;
		}
		if (p2Enumerations.p2AppManagerState.Idle != w())
		{
		  return p2Enumerations.p2AppManagerStatus.DEVICE_BUSY_ERROR;
		}
		bool @bool = false;
		p2Enumerations.p2AppManagerStatus p2AppManagerStatus = y();
		if (p2Enumerations.p2AppManagerStatus.BOARD_DISTCONNECTED_ERROR == p2AppManagerStatus || p2Enumerations.p2AppManagerStatus.UNKNOWN_ERROR == p2AppManagerStatus)
		{
		  return p2AppManagerStatus;
		}
		if (p2Enumerations.p2AppManagerStatus.BOARD_NOT_INITIALIZED_ERROR == p2AppManagerStatus)
		{
		  @bool = true;
		}
		this.k_Conflict = (double[][])null;
		this.x_Conflict = paramArrayOfDouble;
		try
		{
		  a1 = a(p2Enumerations.p2DeviceAction.RunInterSpec, paramVarArgs);
		}
		catch (Exception)
		{
		  return p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR;
		}
		a(p2Enumerations.p2AppManagerState.InterferogramRun);
		this.D_Conflict = paramb;
		o(a1, @bool);
		return p2Enumerations.p2AppManagerStatus.NO_ERROR;
	  }

	  public virtual p2Enumerations.p2AppManagerStatus f(b paramb, params string[] paramVarArgs)
	  {
		a a1;
		if (paramVarArgs.Length != 3 && paramVarArgs.Length != 1)
		{
		  return p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR;
		}
		if (p2Enumerations.p2AppManagerState.Idle != w())
		{
		  return p2Enumerations.p2AppManagerStatus.DEVICE_BUSY_ERROR;
		}
		bool @bool = false;
		p2Enumerations.p2AppManagerStatus p2AppManagerStatus = y();
		if (p2Enumerations.p2AppManagerStatus.BOARD_DISTCONNECTED_ERROR == p2AppManagerStatus || p2Enumerations.p2AppManagerStatus.UNKNOWN_ERROR == p2AppManagerStatus)
		{
		  return p2AppManagerStatus;
		}
		if (p2Enumerations.p2AppManagerStatus.BOARD_NOT_INITIALIZED_ERROR == p2AppManagerStatus)
		{
		  @bool = true;
		}
		this.k_Conflict = (double[][])null;
		try
		{
		  a1 = a(p2Enumerations.p2DeviceAction.RunInterSpec, paramVarArgs);
		}
		catch (Exception)
		{
		  return p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR;
		}
		a(p2Enumerations.p2AppManagerState.InterferogramRun);
		this.D_Conflict = paramb;
		p(a1, @bool);
		return p2Enumerations.p2AppManagerStatus.NO_ERROR;
	  }

	  public virtual p2Enumerations.p2AppManagerStatus g(b paramb, params string[] paramVarArgs)
	  {
		a a1;
		if (paramVarArgs.Length != 2)
		{
		  return p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR;
		}
		if (p2Enumerations.p2AppManagerState.Idle != w())
		{
		  return p2Enumerations.p2AppManagerStatus.DEVICE_BUSY_ERROR;
		}
		if (this.k_Conflict == null)
		{
		  return p2Enumerations.p2AppManagerStatus.NO_VALID_OLD_MEASUREMENT_ERROR;
		}
		try
		{
		  a1 = a(p2Enumerations.p2DeviceAction.RunUpdateFFT_SettingsInterSpec, paramVarArgs);
		}
		catch (Exception)
		{
		  return p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR;
		}
		a(p2Enumerations.p2AppManagerState.updateFFT_SettingsInterSpecRun);
		this.D_Conflict = paramb;
		b_Conflict(a1);
		return p2Enumerations.p2AppManagerStatus.NO_ERROR;
	  }

	  public virtual p2Enumerations.p2AppManagerStatus h(b paramb, params string[] paramVarArgs)
	  {
		a a1;
		if (paramVarArgs.Length != 2)
		{
		  return p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR;
		}
		if (p2Enumerations.p2AppManagerState.Idle != w())
		{
		  return p2Enumerations.p2AppManagerStatus.DEVICE_BUSY_ERROR;
		}
		if (this.e_Conflict == null || this.f_Conflict == null)
		{
		  return p2Enumerations.p2AppManagerStatus.NO_VALID_OLD_MEASUREMENT_ERROR;
		}
		try
		{
		  a1 = a(p2Enumerations.p2DeviceAction.RunUpdateFFT_SettingsSpec, paramVarArgs);
		}
		catch (Exception)
		{
		  return p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR;
		}
		a(p2Enumerations.p2AppManagerState.updateFFT_SettingsSpecRun);
		this.D_Conflict = paramb;
		c(a1);
		return p2Enumerations.p2AppManagerStatus.NO_ERROR;
	  }

	  public virtual p2Enumerations.p2AppManagerStatus i(b paramb, params string[] paramVarArgs)
	  {
		a a1;
		if (paramVarArgs.Length != 4)
		{
		  return p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR;
		}
		if (p2Enumerations.p2AppManagerState.Idle != w())
		{
		  return p2Enumerations.p2AppManagerStatus.DEVICE_BUSY_ERROR;
		}
		bool @bool = false;
		p2Enumerations.p2AppManagerStatus p2AppManagerStatus = y();
		if (p2Enumerations.p2AppManagerStatus.BOARD_DISTCONNECTED_ERROR == p2AppManagerStatus || p2Enumerations.p2AppManagerStatus.UNKNOWN_ERROR == p2AppManagerStatus)
		{
		  return p2AppManagerStatus;
		}
		if (p2Enumerations.p2AppManagerStatus.BOARD_NOT_INITIALIZED_ERROR == p2AppManagerStatus)
		{
		  @bool = true;
		}
		this.l_Conflict = (double[][])null;
		try
		{
		  a1 = a(p2Enumerations.p2DeviceAction.RunSNR, paramVarArgs);
		}
		catch (Exception)
		{
		  return p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR;
		}
		a(p2Enumerations.p2AppManagerState.SNR_Run);
		this.D_Conflict = paramb;
		q(a1, @bool);
		return p2Enumerations.p2AppManagerStatus.NO_ERROR;
	  }

	  public virtual p2Enumerations.p2AppManagerStatus j(b paramb, params string[] paramVarArgs)
	  {
		a a1;
		if (paramVarArgs.Length != 6)
		{
		  return p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR;
		}
		if (p2Enumerations.p2AppManagerState.Idle != w())
		{
		  return p2Enumerations.p2AppManagerStatus.DEVICE_BUSY_ERROR;
		}
		bool @bool = false;
		p2Enumerations.p2AppManagerStatus p2AppManagerStatus = y();
		if (p2Enumerations.p2AppManagerStatus.BOARD_DISTCONNECTED_ERROR == p2AppManagerStatus || p2Enumerations.p2AppManagerStatus.UNKNOWN_ERROR == p2AppManagerStatus)
		{
		  return p2AppManagerStatus;
		}
		if (p2Enumerations.p2AppManagerStatus.BOARD_NOT_INITIALIZED_ERROR == p2AppManagerStatus)
		{
		  @bool = true;
		}
		if (this.f_Conflict == null)
		{
		  return p2Enumerations.p2AppManagerStatus.NO_VALID_BG_DATA_ERROR;
		}
		if (this.z_Conflict != double.Parse(paramVarArgs[0]))
		{
		  return p2Enumerations.p2AppManagerStatus.INVALID_RUN_TIME_NOT_EQUAL_BG_RUN_TIME_ERROR;
		}
		this.m_Conflict = (double[][])null;
		try
		{
		  a1 = a(p2Enumerations.p2DeviceAction.RunStability, paramVarArgs);
		}
		catch (Exception)
		{
		  return p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR;
		}
		a(p2Enumerations.p2AppManagerState.StabilityRun);
		this.D_Conflict = paramb;
		r(a1, @bool);
		return p2Enumerations.p2AppManagerStatus.NO_ERROR;
	  }

	  public virtual p2Enumerations.p2AppManagerStatus k(b paramb, params string[] paramVarArgs)
	  {
		a a1;
		if (paramVarArgs.Length != 3)
		{
		  return p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR;
		}
		if (p2Enumerations.p2AppManagerState.Idle != w())
		{
		  return p2Enumerations.p2AppManagerStatus.DEVICE_BUSY_ERROR;
		}
		bool @bool = false;
		p2Enumerations.p2AppManagerStatus p2AppManagerStatus = y();
		if (p2Enumerations.p2AppManagerStatus.BOARD_DISTCONNECTED_ERROR == p2AppManagerStatus || p2Enumerations.p2AppManagerStatus.UNKNOWN_ERROR == p2AppManagerStatus)
		{
		  return p2AppManagerStatus;
		}
		if (p2Enumerations.p2AppManagerStatus.BOARD_NOT_INITIALIZED_ERROR == p2AppManagerStatus)
		{
		  @bool = true;
		}
		this.k_Conflict = (double[][])null;
		try
		{
		  a1 = a(p2Enumerations.p2DeviceAction.RunSelfCorr, paramVarArgs);
		}
		catch (Exception)
		{
		  return p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR;
		}
		a(p2Enumerations.p2AppManagerState.selfCorr_Run);
		this.D_Conflict = paramb;
		p(a1, @bool);
		return p2Enumerations.p2AppManagerStatus.NO_ERROR;
	  }

	  public virtual p2Enumerations.p2AppManagerStatus l(b paramb, params string[] paramVarArgs)
	  {
		a a1;
		if (paramVarArgs.Length != 1)
		{
		  return p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR;
		}
		if (p2Enumerations.p2AppManagerState.Idle != w())
		{
		  return p2Enumerations.p2AppManagerStatus.DEVICE_BUSY_ERROR;
		}
		bool @bool = false;
		p2Enumerations.p2AppManagerStatus p2AppManagerStatus = y();
		if (p2Enumerations.p2AppManagerStatus.BOARD_DISTCONNECTED_ERROR == p2AppManagerStatus || p2Enumerations.p2AppManagerStatus.UNKNOWN_ERROR == p2AppManagerStatus)
		{
		  return p2AppManagerStatus;
		}
		if (p2Enumerations.p2AppManagerStatus.BOARD_NOT_INITIALIZED_ERROR == p2AppManagerStatus)
		{
		  @bool = true;
		}
		this.h_Conflict = (double[][])null;
		try
		{
		  a1 = a(p2Enumerations.p2DeviceAction.RunGainAdjustInterSpec, paramVarArgs);
		}
		catch (Exception)
		{
		  return p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR;
		}
		a(p2Enumerations.p2AppManagerState.gainAdjustInterSpecRun);
		this.D_Conflict = paramb;
		s(a1, @bool);
		return p2Enumerations.p2AppManagerStatus.NO_ERROR;
	  }

	  public virtual p2Enumerations.p2AppManagerStatus m(b paramb, params string[] paramVarArgs)
	  {
		a a1;
		if (paramVarArgs.Length != 1)
		{
		  return p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR;
		}
		if (p2Enumerations.p2AppManagerState.Idle != w())
		{
		  return p2Enumerations.p2AppManagerStatus.DEVICE_BUSY_ERROR;
		}
		bool @bool = false;
		p2Enumerations.p2AppManagerStatus p2AppManagerStatus = y();
		if (p2Enumerations.p2AppManagerStatus.BOARD_DISTCONNECTED_ERROR == p2AppManagerStatus || p2Enumerations.p2AppManagerStatus.UNKNOWN_ERROR == p2AppManagerStatus)
		{
		  return p2AppManagerStatus;
		}
		if (p2Enumerations.p2AppManagerStatus.BOARD_NOT_INITIALIZED_ERROR == p2AppManagerStatus)
		{
		  @bool = true;
		}
		this.i_Conflict = (double[][])null;
		this.j_Conflict = (double[][])null;
		try
		{
		  a1 = a(p2Enumerations.p2DeviceAction.RunGainAdjustSpecBG, paramVarArgs);
		}
		catch (Exception)
		{
		  return p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR;
		}
		a(p2Enumerations.p2AppManagerState.gainAdjustSpecBG_Run);
		this.D_Conflict = paramb;
		s(a1, @bool);
		return p2Enumerations.p2AppManagerStatus.NO_ERROR;
	  }

	  public virtual p2Enumerations.p2AppManagerStatus n(b paramb, params string[] paramVarArgs)
	  {
		a a1;
		if (paramVarArgs.Length != 3)
		{
		  return p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR;
		}
		if (p2Enumerations.p2AppManagerState.Idle != w())
		{
		  return p2Enumerations.p2AppManagerStatus.DEVICE_BUSY_ERROR;
		}
		bool @bool = false;
		p2Enumerations.p2AppManagerStatus p2AppManagerStatus = y();
		if (p2Enumerations.p2AppManagerStatus.BOARD_DISTCONNECTED_ERROR == p2AppManagerStatus || p2Enumerations.p2AppManagerStatus.UNKNOWN_ERROR == p2AppManagerStatus)
		{
		  return p2AppManagerStatus;
		}
		if (p2Enumerations.p2AppManagerStatus.BOARD_NOT_INITIALIZED_ERROR == p2AppManagerStatus)
		{
		  @bool = true;
		}
		if (this.i_Conflict == null)
		{
		  return p2Enumerations.p2AppManagerStatus.NO_VALID_BG_DATA_ERROR;
		}
		this.j_Conflict = (double[][])null;
		try
		{
		  a1 = a(p2Enumerations.p2DeviceAction.RunGainAdjustSpecSample, paramVarArgs);
		}
		catch (Exception)
		{
		  return p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR;
		}
		a(p2Enumerations.p2AppManagerState.gainAdjustSpecSampleRun);
		this.D_Conflict = paramb;
		s(a1, @bool);
		return p2Enumerations.p2AppManagerStatus.NO_ERROR;
	  }

	  public virtual p2Enumerations.p2AppManagerStatus a(string paramString, double[][] paramArrayOfDouble)
	  {
		if (null != paramString && "" != paramString && null != paramArrayOfDouble)
		{
		  paramString = paramString.Replace(" ", "");
		  paramString = "_InterSpec_" + paramString;
		  string[] arrayOfString = new string[] {".option " + paramString, "CURRENT_RANGE=" + p2Constants.currentRanges[(int)paramArrayOfDouble[0][0]], "PGA1=" + Convert.ToString(p2Constants.PGA1_values[(int)paramArrayOfDouble[0][1]]), "PGA2=" + Convert.ToString(p2Constants.PGA2_values[(int)paramArrayOfDouble[0][2]]), ".end", ""};
		  if (c(arrayOfString))
		  {
			return p2Enumerations.p2AppManagerStatus.NO_ERROR;
		  }
		  Console.WriteLine("Failed saving in saveInterSpecGainSettings (1)!");
		  return p2Enumerations.p2AppManagerStatus.FAILED_IN_ADAPTIVE_GAIN;
		}
		Console.WriteLine("Failed saving in saveInterSpecGainSettings (2)!");
		return p2Enumerations.p2AppManagerStatus.FAILED_IN_ADAPTIVE_GAIN;
	  }

	  public p2Enumerations.p2AppManagerStatus b(string paramString, double[][] paramArrayOfDouble)
	  {
		  if (!InstanceFieldsInitialized)
		  {
			  InitializeInstanceFields();
			  InstanceFieldsInitialized = true;
		  }
		if (null != paramString && "" != paramString && null != paramArrayOfDouble)
		{
		  paramString = paramString.Replace(" ", "");
		  paramString = "_Spec_" + paramString;
		  string[] arrayOfString = new string[] {".option " + paramString, "BG_CURRENT_RANGE=" + p2Constants.currentRanges[(int)paramArrayOfDouble[0][0]], "BG_PGA1=" + Convert.ToString(p2Constants.PGA1_values[(int)paramArrayOfDouble[0][1]]), "BG_PGA2=" + Convert.ToString(p2Constants.PGA2_values[(int)paramArrayOfDouble[0][2]]), "Sample_CURRENT_RANGE=" + p2Constants.currentRanges[(int)paramArrayOfDouble[1][0]], "Sample_PGA1=" + Convert.ToString(p2Constants.PGA1_values[(int)paramArrayOfDouble[1][1]]), "Sample_PGA2=" + Convert.ToString(p2Constants.PGA2_values[(int)paramArrayOfDouble[1][2]]), "ERROR=" + Convert.ToString(paramArrayOfDouble[2][0]), ".end", ""};
		  if (c(arrayOfString))
		  {
			return p2Enumerations.p2AppManagerStatus.NO_ERROR;
		  }
		  Console.WriteLine("Failed saving in saveSpecGainSettings (1)!");
		  return p2Enumerations.p2AppManagerStatus.FAILED_IN_ADAPTIVE_GAIN;
		}
		Console.WriteLine("Failed saving in saveSpecGainSettings (2)!");
		return p2Enumerations.p2AppManagerStatus.FAILED_IN_ADAPTIVE_GAIN;
	  }

	  public virtual p2Enumerations.p2AppManagerStatus o(b paramb, params string[] paramVarArgs)
	  {
		a a1;
		if (paramVarArgs.Length != 17)
		{
		  return p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR;
		}
		if (p2Enumerations.p2AppManagerState.Idle != w())
		{
		  return p2Enumerations.p2AppManagerStatus.DEVICE_BUSY_ERROR;
		}
		bool bool1 = false;
		p2Enumerations.p2AppManagerStatus p2AppManagerStatus = y();
		if (p2Enumerations.p2AppManagerStatus.BOARD_DISTCONNECTED_ERROR == p2AppManagerStatus || p2Enumerations.p2AppManagerStatus.UNKNOWN_ERROR == p2AppManagerStatus)
		{
		  return p2AppManagerStatus;
		}
		if (p2Enumerations.p2AppManagerStatus.BOARD_NOT_INITIALIZED_ERROR == p2AppManagerStatus)
		{
		  bool1 = true;
		}
		this.E_Conflict = "";
		if (bool.Parse(paramVarArgs[1]))
		{
		  sws.p2AppManager.b.b.a("TAIFReg", this.O.f());
		  try
		  {
			this.O.a(paramb.c());
		  }
		  catch (a_Conflict)
		  {
			b_Conflict.error("Loading register file failed");
			return p2Enumerations.p2AppManagerStatus.ASIC_REGISTER_WRITING_ERROR;
		  }
		}
		try
		{
		  a1 = a(p2Enumerations.p2DeviceAction.RunCapTimeCalibration, paramVarArgs);
		}
		catch (Exception)
		{
		  return p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR;
		}
		bool bool2 = false;
		if (bool.Parse(paramVarArgs[1]))
		{
		  try
		  {
			bool2 = this.O.a(bool.Parse(paramVarArgs[1]));
		  }
		  catch (a_Conflict)
		  {
			return p2Enumerations.p2AppManagerStatus.ACTUATION_SETTING_ERROR;
		  }
		}
		else
		{
		  bool2 = false;
		  try
		  {
			this.O.a(false, bool.Parse(paramVarArgs[1]), (int)paramb.b()[48]);
		  }
		  catch (a_Conflict)
		  {
			return p2Enumerations.p2AppManagerStatus.DEVICE_IS_TURNED_OFF_ERROR;
		  }
		}
		if (!bool2)
		{
		  try
		  {
			this.O.a(true, bool.Parse(paramVarArgs[1]), (int)paramb.b()[48]);
			try
			{
			  Thread.Sleep((long)paramb.b()[12]);
			}
			catch (InterruptedException interruptedException)
			{
			  b_Conflict.error(interruptedException.Message);
			}
		  }
		  catch (a_Conflict)
		  {
			return p2Enumerations.p2AppManagerStatus.DEVICE_IS_TURNED_OFF_ERROR;
		  }
		}
		this.n_Conflict = (double[][])null;
		a(p2Enumerations.p2AppManagerState.CalibrationCapVsTimeRun);
		this.D_Conflict = paramb;
		a(a1, bool1);
		return p2Enumerations.p2AppManagerStatus.NO_ERROR;
	  }

	  public virtual p2Enumerations.p2AppManagerStatus p(b paramb, params string[] paramVarArgs)
	  {
		a a1;
		if (paramVarArgs.Length != 9)
		{
		  return p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR;
		}
		if (p2Enumerations.p2AppManagerState.Idle != w())
		{
		  return p2Enumerations.p2AppManagerStatus.DEVICE_BUSY_ERROR;
		}
		bool bool1 = false;
		p2Enumerations.p2AppManagerStatus p2AppManagerStatus = y();
		if (p2Enumerations.p2AppManagerStatus.BOARD_DISTCONNECTED_ERROR == p2AppManagerStatus || p2Enumerations.p2AppManagerStatus.UNKNOWN_ERROR == p2AppManagerStatus)
		{
		  return p2AppManagerStatus;
		}
		if (p2Enumerations.p2AppManagerStatus.BOARD_NOT_INITIALIZED_ERROR == p2AppManagerStatus)
		{
		  bool1 = true;
		}
		try
		{
		  a1 = a(p2Enumerations.p2DeviceAction.RunDelayCompensation, paramVarArgs);
		}
		catch (Exception)
		{
		  return p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR;
		}
		bool bool2 = false;
		if (bool.Parse(paramVarArgs[1]))
		{
		  try
		  {
			bool2 = this.O.a(bool.Parse(paramVarArgs[1]));
		  }
		  catch (a_Conflict)
		  {
			return p2Enumerations.p2AppManagerStatus.ACTUATION_SETTING_ERROR;
		  }
		}
		else
		{
		  bool2 = false;
		  try
		  {
			this.O.a(false, bool.Parse(paramVarArgs[1]), (int)paramb.b()[48]);
		  }
		  catch (a_Conflict)
		  {
			return p2Enumerations.p2AppManagerStatus.DEVICE_IS_TURNED_OFF_ERROR;
		  }
		}
		if (!bool2)
		{
		  try
		  {
			this.O.a(true, bool.Parse(paramVarArgs[7]), (int)paramb.b()[48]);
			try
			{
			  Thread.Sleep((long)paramb.b()[12]);
			}
			catch (InterruptedException interruptedException)
			{
			  b_Conflict.error(interruptedException.Message);
			}
		  }
		  catch (a_Conflict)
		  {
			return p2Enumerations.p2AppManagerStatus.DEVICE_IS_TURNED_OFF_ERROR;
		  }
		}
		a(p2Enumerations.p2AppManagerState.CalibrationDelayCompensationRun);
		this.D_Conflict = paramb;
		e(a1, bool1);
		return p2Enumerations.p2AppManagerStatus.NO_ERROR;
	  }

	  public virtual p2Enumerations.p2AppManagerStatus q(b paramb, params string[] paramVarArgs)
	  {
		a a1;
		if (paramVarArgs.Length != 11)
		{
		  return p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR;
		}
		if (p2Enumerations.p2AppManagerState.Idle != w())
		{
		  return p2Enumerations.p2AppManagerStatus.DEVICE_BUSY_ERROR;
		}
		bool bool1 = false;
		p2Enumerations.p2AppManagerStatus p2AppManagerStatus = y();
		if (p2Enumerations.p2AppManagerStatus.BOARD_DISTCONNECTED_ERROR == p2AppManagerStatus || p2Enumerations.p2AppManagerStatus.UNKNOWN_ERROR == p2AppManagerStatus)
		{
		  return p2AppManagerStatus;
		}
		if (p2Enumerations.p2AppManagerStatus.BOARD_NOT_INITIALIZED_ERROR == p2AppManagerStatus)
		{
		  bool1 = true;
		}
		try
		{
		  a1 = a(p2Enumerations.p2DeviceAction.RunCalibration, paramVarArgs);
		}
		catch (Exception)
		{
		  return p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR;
		}
		bool bool2 = false;
		if (bool.Parse(paramVarArgs[1]))
		{
		  try
		  {
			bool2 = this.O.a(bool.Parse(paramVarArgs[1]));
		  }
		  catch (a_Conflict)
		  {
			return p2Enumerations.p2AppManagerStatus.ACTUATION_SETTING_ERROR;
		  }
		}
		else
		{
		  bool2 = false;
		  try
		  {
			this.O.a(false, bool.Parse(paramVarArgs[1]), (int)paramb.b()[48]);
		  }
		  catch (a_Conflict)
		  {
			return p2Enumerations.p2AppManagerStatus.DEVICE_IS_TURNED_OFF_ERROR;
		  }
		}
		if (!bool2)
		{
		  try
		  {
			this.O.a(true, bool.Parse(paramVarArgs[7]), (int)paramb.b()[48]);
			try
			{
			  Thread.Sleep((long)paramb.b()[12]);
			}
			catch (InterruptedException interruptedException)
			{
			  b_Conflict.error(interruptedException.Message);
			}
		  }
		  catch (a_Conflict)
		  {
			return p2Enumerations.p2AppManagerStatus.DEVICE_IS_TURNED_OFF_ERROR;
		  }
		}
		a(p2Enumerations.p2AppManagerState.CalibrationCoreRun);
		this.D_Conflict = paramb;
		f(a1, bool1);
		return p2Enumerations.p2AppManagerStatus.NO_ERROR;
	  }

	  public virtual p2Enumerations.p2AppManagerStatus r(b paramb, params string[] paramVarArgs)
	  {
		a a1;
		if (paramVarArgs.Length != 16 && paramVarArgs.Length != 17 && paramVarArgs.Length != 18)
		{
		  return p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR;
		}
		if (p2Enumerations.p2AppManagerState.Idle != w())
		{
		  return p2Enumerations.p2AppManagerStatus.DEVICE_BUSY_ERROR;
		}
		try
		{
		  a1 = a(p2Enumerations.p2DeviceAction.GenerateCalibration, paramVarArgs);
		}
		catch (Exception)
		{
		  return p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR;
		}
		a(p2Enumerations.p2AppManagerState.CalibrationGeneration);
		this.D_Conflict = paramb;
		a(a1);
		return p2Enumerations.p2AppManagerStatus.NO_ERROR;
	  }

	  public virtual double[][] j()
	  {
		if (p2Enumerations.p2AppManagerState.Idle != w())
		{
		  b_Conflict.error("p2Device is busy now");
		  return (double[][])null;
		}
		if (this.n_Conflict == null)
		{
		  b_Conflict.error("there is no Cap Time data may be you don't have any successful Cap Time runs");
		  return (double[][])null;
		}
		return this.n_Conflict;
	  }

	  public virtual double[][] k()
	  {
		if (p2Enumerations.p2AppManagerState.Idle != w())
		{
		  b_Conflict.error("p2Device is busy now");
		  return (double[][])null;
		}
		if (this.o_Conflict == null)
		{
		  b_Conflict.error("there is no calibration data may be you don't have any successful calibrations ");
		  return (double[][])null;
		}
		return this.o_Conflict;
	  }

	  public virtual double[][] l()
	  {
		if (p2Enumerations.p2AppManagerState.Idle != w())
		{
		  b_Conflict.error("p2Device is busy now");
		  return (double[][])null;
		}
		if (this.p_Conflict == null)
		{
		  b_Conflict.error("there is no Cap & Current data may be you don't have any successful cap & current runs");
		  return (double[][])null;
		}
		return this.p_Conflict;
	  }

	  public virtual double[][] d()
	  {
		if (p2Enumerations.p2AppManagerState.Idle != w())
		{
		  b_Conflict.error("p2Device is busy now");
		  return (double[][])null;
		}
		if (this.x_Conflict == null)
		{
		  b_Conflict.error("there is no raw data may be you don't have any successful runs ");
		  return (double[][])null;
		}
		return this.x_Conflict;
	  }

	  public virtual double[][] e()
	  {
		if (p2Enumerations.p2AppManagerState.Idle != w())
		{
		  b_Conflict.error("p2Device is busy now");
		  return (double[][])null;
		}
		if (this.k_Conflict == null)
		{
		  b_Conflict.error("there is no interSpec data may be you don't have any successful interspec run ");
		  return (double[][])null;
		}
		return this.k_Conflict;
	  }

	  public virtual double[][] f()
	  {
		if (p2Enumerations.p2AppManagerState.Idle != w())
		{
		  b_Conflict.error("p2Device is busy now");
		  return (double[][])null;
		}
		if (this.h_Conflict == null)
		{
		  b_Conflict.error("there is no valid data");
		  return (double[][])null;
		}
		return this.h_Conflict;
	  }

	  public virtual double[][] g()
	  {
		if (p2Enumerations.p2AppManagerState.Idle != w())
		{
		  b_Conflict.error("p2Device is busy now");
		  return (double[][])null;
		}
		if (this.i_Conflict == null || this.j_Conflict == null)
		{
		  b_Conflict.error("there is no valid data");
		  return (double[][])null;
		}
		return new double[][] {this.i_Conflict[0], this.j_Conflict[0], this.j_Conflict[1]};
	  }

	  public virtual double[][] h()
	  {
		if (p2Enumerations.p2AppManagerState.Idle != w())
		{
		  b_Conflict.error("p2Device is busy now");
		  return (double[][])null;
		}
		if (this.l_Conflict == null)
		{
		  b_Conflict.error("there is no SNR data may be you don't have any successful run ");
		  return (double[][])null;
		}
		return this.l_Conflict;
	  }

	  public virtual double[][] i()
	  {
		if (p2Enumerations.p2AppManagerState.Idle != w())
		{
		  b_Conflict.error("p2Device is busy now");
		  return (double[][])null;
		}
		if (this.m_Conflict == null)
		{
		  b_Conflict.error("there is no Stability data may be you don't have any successful run ");
		  return (double[][])null;
		}
		return this.m_Conflict;
	  }

	  public virtual p2Enumerations.p2AppManagerStatus s(b paramb, params string[] paramVarArgs)
	  {
		a a1;
		if (paramVarArgs.Length != 13)
		{
		  return p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR;
		}
		if (p2Enumerations.p2AppManagerState.Idle != w())
		{
		  return p2Enumerations.p2AppManagerStatus.DEVICE_BUSY_ERROR;
		}
		bool bool1 = false;
		p2Enumerations.p2AppManagerStatus p2AppManagerStatus = y();
		if (p2Enumerations.p2AppManagerStatus.BOARD_DISTCONNECTED_ERROR == p2AppManagerStatus || p2Enumerations.p2AppManagerStatus.UNKNOWN_ERROR == p2AppManagerStatus)
		{
		  return p2AppManagerStatus;
		}
		if (p2Enumerations.p2AppManagerStatus.BOARD_NOT_INITIALIZED_ERROR == p2AppManagerStatus)
		{
		  bool1 = true;
		}
		this.E_Conflict = "";
		if (bool.Parse(paramVarArgs[1]))
		{
		  sws.p2AppManager.b.b.a("TAIFReg", this.O.f());
		  try
		  {
			this.O.a(paramb.c());
		  }
		  catch (a_Conflict)
		  {
			b_Conflict.error("Loading register file failed");
			return p2Enumerations.p2AppManagerStatus.ASIC_REGISTER_WRITING_ERROR;
		  }
		}
		try
		{
		  a1 = a(p2Enumerations.p2DeviceAction.RunCapCurrent, paramVarArgs);
		}
		catch (Exception)
		{
		  return p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR;
		}
		bool bool2 = false;
		if (bool.Parse(paramVarArgs[1]))
		{
		  try
		  {
			bool2 = this.O.a(bool.Parse(paramVarArgs[1]));
		  }
		  catch (a_Conflict)
		  {
			return p2Enumerations.p2AppManagerStatus.ACTUATION_SETTING_ERROR;
		  }
		}
		else
		{
		  bool2 = false;
		  try
		  {
			this.O.a(false, bool.Parse(paramVarArgs[1]), (int)paramb.b()[48]);
		  }
		  catch (a_Conflict)
		  {
			return p2Enumerations.p2AppManagerStatus.DEVICE_IS_TURNED_OFF_ERROR;
		  }
		}
		if (!bool2)
		{
		  try
		  {
			this.O.a(true, bool.Parse(paramVarArgs[1]), (int)paramb.b()[48]);
			try
			{
			  Thread.Sleep((long)paramb.b()[12]);
			}
			catch (InterruptedException interruptedException)
			{
			  b_Conflict.error(interruptedException.Message);
			}
		  }
		  catch (a_Conflict)
		  {
			return p2Enumerations.p2AppManagerStatus.DEVICE_IS_TURNED_OFF_ERROR;
		  }
		}
		this.p_Conflict = (double[][])null;
		a(p2Enumerations.p2AppManagerState.CapCurrentRun);
		this.D_Conflict = paramb;
		a(a1, bool1);
		return p2Enumerations.p2AppManagerStatus.NO_ERROR;
	  }

	  public virtual p2Enumerations.p2AppManagerStatus v(b paramb, params string[] paramVarArgs)
	  {
		a a1;
		if (paramVarArgs.Length != 1)
		{
		  return p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR;
		}
		if (p2Enumerations.p2AppManagerState.Idle != w())
		{
		  return p2Enumerations.p2AppManagerStatus.DEVICE_BUSY_ERROR;
		}
		bool @bool = false;
		p2Enumerations.p2AppManagerStatus p2AppManagerStatus = y();
		if (p2Enumerations.p2AppManagerStatus.BOARD_DISTCONNECTED_ERROR == p2AppManagerStatus || p2Enumerations.p2AppManagerStatus.UNKNOWN_ERROR == p2AppManagerStatus)
		{
		  return p2AppManagerStatus;
		}
		if (p2Enumerations.p2AppManagerStatus.BOARD_NOT_INITIALIZED_ERROR == p2AppManagerStatus)
		{
		  @bool = true;
		}
		try
		{
		  a1 = a(p2Enumerations.p2DeviceAction.BurnSampleID, paramVarArgs);
		}
		catch (Exception)
		{
		  return p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR;
		}
		a(p2Enumerations.p2AppManagerState.SampleIDBurn);
		this.D_Conflict = paramb;
		g(a1, @bool);
		return p2Enumerations.p2AppManagerStatus.NO_ERROR;
	  }

	  public virtual p2Enumerations.p2AppManagerStatus w(b paramb, string[] paramArrayOfString)
	  {
		if (p2Enumerations.p2AppManagerState.Idle != w())
		{
		  return p2Enumerations.p2AppManagerStatus.DEVICE_BUSY_ERROR;
		}
		bool @bool = false;
		p2Enumerations.p2AppManagerStatus p2AppManagerStatus = y();
		if (p2Enumerations.p2AppManagerStatus.BOARD_DISTCONNECTED_ERROR == p2AppManagerStatus || p2Enumerations.p2AppManagerStatus.UNKNOWN_ERROR == p2AppManagerStatus)
		{
		  return p2AppManagerStatus;
		}
		if (p2Enumerations.p2AppManagerStatus.BOARD_NOT_INITIALIZED_ERROR == p2AppManagerStatus)
		{
		  @bool = true;
		}
		a a1 = new a(this, this, null);
		a1.a = p2Enumerations.p2AppManagerState.SampleFoldersBurn;
		a1.0F = paramArrayOfString;
		a(p2Enumerations.p2AppManagerState.SampleFoldersBurn);
		this.D_Conflict = paramb;
		k(a1, @bool);
		return p2Enumerations.p2AppManagerStatus.NO_ERROR;
	  }

	  public virtual p2Enumerations.p2AppManagerStatus x(b paramb, params string[] paramVarArgs)
	  {
		if (p2Enumerations.p2AppManagerState.Idle != w())
		{
		  return p2Enumerations.p2AppManagerStatus.DEVICE_BUSY_ERROR;
		}
		bool @bool = false;
		p2Enumerations.p2AppManagerStatus p2AppManagerStatus = y();
		if (p2Enumerations.p2AppManagerStatus.BOARD_DISTCONNECTED_ERROR == p2AppManagerStatus || p2Enumerations.p2AppManagerStatus.UNKNOWN_ERROR == p2AppManagerStatus)
		{
		  return p2AppManagerStatus;
		}
		if (p2Enumerations.p2AppManagerStatus.BOARD_NOT_INITIALIZED_ERROR == p2AppManagerStatus)
		{
		  @bool = true;
		}
		a a1 = new a(this, this, null);
		a1.a = p2Enumerations.p2AppManagerState.RestoreDefault;
		if (paramVarArgs.Length != 0)
		{
		  a1.G = paramVarArgs[0];
		}
		else
		{
		  a1.G = p2Enumerations.RestoreOptionsEnum.ALL.StringVal;
		}
		a(p2Enumerations.p2AppManagerState.RestoreDefault);
		this.D_Conflict = paramb;
		l(a1, @bool);
		return p2Enumerations.p2AppManagerStatus.NO_ERROR;
	  }

	  public virtual p2Enumerations.p2AppManagerStatus y(b paramb, params string[] paramVarArgs)
	  {
		if (p2Enumerations.p2AppManagerState.Idle != w())
		{
		  return p2Enumerations.p2AppManagerStatus.DEVICE_BUSY_ERROR;
		}
		bool @bool = false;
		p2Enumerations.p2AppManagerStatus p2AppManagerStatus = y();
		if (p2Enumerations.p2AppManagerStatus.BOARD_DISTCONNECTED_ERROR == p2AppManagerStatus || p2Enumerations.p2AppManagerStatus.UNKNOWN_ERROR == p2AppManagerStatus)
		{
		  return p2AppManagerStatus;
		}
		if (p2Enumerations.p2AppManagerStatus.BOARD_NOT_INITIALIZED_ERROR == p2AppManagerStatus)
		{
		  @bool = true;
		}
		a a1 = new a(this, this, null);
		a1.a = p2Enumerations.p2AppManagerState.BurnSettings;
		a(p2Enumerations.p2AppManagerState.BurnSettings);
		this.D_Conflict = paramb;
		m(a1, @bool);
		return p2Enumerations.p2AppManagerStatus.NO_ERROR;
	  }

	  public virtual p2Enumerations.p2AppManagerStatus J(b paramb, params string[] paramVarArgs)
	  {
		if (p2Enumerations.p2AppManagerState.Idle != w())
		{
		  return p2Enumerations.p2AppManagerStatus.DEVICE_BUSY_ERROR;
		}
		bool bool1 = false;
		p2Enumerations.p2AppManagerStatus p2AppManagerStatus = y();
		if (p2Enumerations.p2AppManagerStatus.BOARD_DISTCONNECTED_ERROR == p2AppManagerStatus || p2Enumerations.p2AppManagerStatus.UNKNOWN_ERROR == p2AppManagerStatus)
		{
		  return p2AppManagerStatus;
		}
		if (p2Enumerations.p2AppManagerStatus.BOARD_NOT_INITIALIZED_ERROR == p2AppManagerStatus)
		{
		  bool1 = true;
		}
		a a1 = new a(this, this, null);
		a1.a = p2Enumerations.p2AppManagerState.BurnSettings;
		string[] arrayOfString = new string[paramVarArgs.Length - 1];
		Array.Copy(paramVarArgs, 0, arrayOfString, 0, paramVarArgs.Length - 1);
		bool bool2 = bool.Parse(paramVarArgs[paramVarArgs.Length - 1]);
		a(p2Enumerations.p2AppManagerState.BurnSettings);
		this.D_Conflict = paramb;
		a(a1, bool1, bool2, arrayOfString);
		return p2Enumerations.p2AppManagerStatus.NO_ERROR;
	  }

	  public virtual p2Enumerations.p2AppManagerStatus z(b paramb, params string[] paramVarArgs)
	  {
		a a1;
		if (paramVarArgs.Length != 0)
		{
		  return p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR;
		}
		if (p2Enumerations.p2AppManagerState.Idle != w())
		{
		  return p2Enumerations.p2AppManagerStatus.DEVICE_BUSY_ERROR;
		}
		bool @bool = false;
		p2Enumerations.p2AppManagerStatus p2AppManagerStatus = y();
		if (p2Enumerations.p2AppManagerStatus.BOARD_DISTCONNECTED_ERROR == p2AppManagerStatus || p2Enumerations.p2AppManagerStatus.UNKNOWN_ERROR == p2AppManagerStatus)
		{
		  return p2AppManagerStatus;
		}
		if (p2Enumerations.p2AppManagerStatus.BOARD_NOT_INITIALIZED_ERROR == p2AppManagerStatus)
		{
		  @bool = true;
		}
		try
		{
		  a1 = a(p2Enumerations.p2DeviceAction.ReadSampleFolders, paramVarArgs);
		}
		catch (Exception)
		{
		  return p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR;
		}
		a(p2Enumerations.p2AppManagerState.SampleFoldersReading);
		this.D_Conflict = paramb;
		n(a1, @bool);
		return p2Enumerations.p2AppManagerStatus.NO_ERROR;
	  }

	  public virtual p2Enumerations.p2AppManagerStatus A(b paramb, params string[] paramVarArgs)
	  {
		a a1;
		if (paramVarArgs.Length != 0)
		{
		  return p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR;
		}
		if (p2Enumerations.p2AppManagerState.Idle != w())
		{
		  return p2Enumerations.p2AppManagerStatus.DEVICE_BUSY_ERROR;
		}
		bool @bool = false;
		p2Enumerations.p2AppManagerStatus p2AppManagerStatus = y();
		if (p2Enumerations.p2AppManagerStatus.BOARD_DISTCONNECTED_ERROR == p2AppManagerStatus || p2Enumerations.p2AppManagerStatus.UNKNOWN_ERROR == p2AppManagerStatus)
		{
		  return p2AppManagerStatus;
		}
		if (p2Enumerations.p2AppManagerStatus.BOARD_NOT_INITIALIZED_ERROR == p2AppManagerStatus)
		{
		  @bool = true;
		}
		try
		{
		  a1 = a(p2Enumerations.p2DeviceAction.ReadTemp, paramVarArgs);
		}
		catch (Exception)
		{
		  return p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR;
		}
		a(p2Enumerations.p2AppManagerState.TempReading);
		this.D_Conflict = paramb;
		h(a1, @bool);
		return p2Enumerations.p2AppManagerStatus.NO_ERROR;
	  }

	  public virtual double[][] m()
	  {
		if (p2Enumerations.p2AppManagerState.Idle != w())
		{
		  b_Conflict.error("p2Device is busy now");
		  return (double[][])null;
		}
		if (this.q_Conflict == null)
		{
		  b_Conflict.error("there is no temperature data.");
		  return (double[][])null;
		}
		return this.q_Conflict;
	  }

	  public virtual p2Enumerations.p2AppManagerStatus B(b paramb, params string[] paramVarArgs)
	  {
		a a1;
		if (paramVarArgs.Length != 0)
		{
		  return p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR;
		}
		if (p2Enumerations.p2AppManagerState.Idle != w())
		{
		  return p2Enumerations.p2AppManagerStatus.DEVICE_BUSY_ERROR;
		}
		bool @bool = false;
		p2Enumerations.p2AppManagerStatus p2AppManagerStatus = y();
		if (p2Enumerations.p2AppManagerStatus.BOARD_DISTCONNECTED_ERROR == p2AppManagerStatus || p2Enumerations.p2AppManagerStatus.UNKNOWN_ERROR == p2AppManagerStatus)
		{
		  return p2AppManagerStatus;
		}
		if (p2Enumerations.p2AppManagerStatus.BOARD_NOT_INITIALIZED_ERROR == p2AppManagerStatus)
		{
		  @bool = true;
		}
		try
		{
		  a1 = a(p2Enumerations.p2DeviceAction.ReadASICRegisters, paramVarArgs);
		}
		catch (Exception)
		{
		  return p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR;
		}
		a(p2Enumerations.p2AppManagerState.ASICRegistersReading);
		this.D_Conflict = paramb;
		i(a1, @bool);
		return p2Enumerations.p2AppManagerStatus.NO_ERROR;
	  }

	  public virtual p2Enumerations.p2AppManagerStatus a(b paramb, long[] paramArrayOfLong)
	  {
		if (paramArrayOfLong == null)
		{
		  return p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR;
		}
		if (p2Enumerations.p2AppManagerState.Idle != w())
		{
		  return p2Enumerations.p2AppManagerStatus.DEVICE_BUSY_ERROR;
		}
		bool @bool = false;
		p2Enumerations.p2AppManagerStatus p2AppManagerStatus = y();
		if (p2Enumerations.p2AppManagerStatus.BOARD_DISTCONNECTED_ERROR == p2AppManagerStatus || p2Enumerations.p2AppManagerStatus.UNKNOWN_ERROR == p2AppManagerStatus)
		{
		  return p2AppManagerStatus;
		}
		if (p2Enumerations.p2AppManagerStatus.BOARD_NOT_INITIALIZED_ERROR == p2AppManagerStatus)
		{
		  @bool = true;
		}
		a a1 = new a(this, this, null);
		a1.a = p2Enumerations.p2AppManagerState.ASICRegistersWriting;
		a1.E = paramArrayOfLong;
		a(p2Enumerations.p2AppManagerState.ASICRegistersWriting);
		this.D_Conflict = paramb;
		j(a1, @bool);
		return p2Enumerations.p2AppManagerStatus.NO_ERROR;
	  }

	  public virtual long[] n()
	  {
		if (p2Enumerations.p2AppManagerState.Idle != w())
		{
		  b_Conflict.error("p2Device is busy now");
		  return null;
		}
		if (this.y_Conflict == null)
		{
		  b_Conflict.error("there is no ASIC registers data.");
		  return null;
		}
		return this.y_Conflict;
	  }

	  public virtual p2Enumerations.p2AppManagerStatus t(b paramb, params string[] paramVarArgs)
	  {
		bool bool2;
		if (paramVarArgs.Length == 0 || p2AppManagerUtils.isEmptyString(paramVarArgs[0]))
		{
		  return p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR;
		}
		try
		{
		  bool.Parse(paramVarArgs[0]);
		}
		catch (Exception)
		{
		  return p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR;
		}
		if (p2Enumerations.p2AppManagerState.Idle != w())
		{
		  return p2Enumerations.p2AppManagerStatus.DEVICE_BUSY_ERROR;
		}
		bool bool1 = false;
		p2Enumerations.p2AppManagerStatus p2AppManagerStatus = y();
		if (p2Enumerations.p2AppManagerStatus.BOARD_DISTCONNECTED_ERROR == p2AppManagerStatus || p2Enumerations.p2AppManagerStatus.UNKNOWN_ERROR == p2AppManagerStatus)
		{
		  return p2AppManagerStatus;
		}
		if (p2Enumerations.p2AppManagerStatus.BOARD_NOT_INITIALIZED_ERROR == p2AppManagerStatus)
		{
		  bool1 = true;
		}
		a(p2Enumerations.p2AppManagerState.ActuationProfileSetting);
		this.D_Conflict = paramb;
		if (paramVarArgs.Length == 1)
		{
		  bool2 = true;
		}
		else
		{
		  bool2 = bool.Parse(paramVarArgs[1]);
		}
		a(bool1, bool.Parse(paramVarArgs[0]), bool2);
		return p2Enumerations.p2AppManagerStatus.NO_ERROR;
	  }

	  private void x()
	  {
		b_Conflict.info("executeIntiliazation method :: Start");
		c_Conflict.a(new aAnonymousInnerClass(this));
	  }

	  private class aAnonymousInnerClass : a<bool>
	  {
		  private readonly b outerInstance;

		  public aAnonymousInnerClass(b outerInstance) : base(outerInstance)
		  {
			  this.outerInstance = outerInstance;
		  }

		  protected internal bool? a()
		  {
			try
			{
			  b.a(this.a, b.a(this.a));
			  b.a(this.a, p2Enumerations.p2DeviceAction.initializeCore, (double[][])null, p2Enumerations.p2AppManagerStatus.NO_ERROR);
			}
			catch (p2AppManagerException p2AppManagerException)
			{
			  b.v().error(p2AppManagerException.Message);
			  b.a(this.a, p2Enumerations.p2DeviceAction.initializeCore, (double[][])null, p2Enumerations.p2AppManagerStatus.getAppManagerStatusByCode(p2AppManagerException.ErrorCode));
			}
			return Convert.ToBoolean(true);
		  }
	  }

	  private void a(a parama, bool paramBoolean)
	  {
		  c_Conflict.a(new aAnonymousInnerClass2(this, paramBoolean, parama));
	  }

	  private class aAnonymousInnerClass2 : a<bool>
	  {
		  private readonly b outerInstance;

		  public aAnonymousInnerClass2(b outerInstance, bool paramBoolean, sws.p2AppManager.b.a parama) : base(outerInstance, paramBoolean, parama)
		  {
			  this.outerInstance = outerInstance;
		  }

		  protected internal bool? a()
		  {
			try
			{
			  if (this.a)
			  {
				b.a(this.c_Conflict, b.a(this.c_Conflict));
			  }
			  if (this.b.a == p2Enumerations.p2AppManagerState.CalibrationCapVsTimeRun)
			  {
				double[] arrayOfDouble = b.a(this.c_Conflict, this.b, b.a(this.c_Conflict));
				if (arrayOfDouble == null)
				{
				  throw new p2AppManagerException("Not a valid reading for this sample: " + b.b(this.c_Conflict) + " run.", p2Enumerations.p2AppManagerStatus.INTERPOLATION_THRESHOLD_ERROR.NumVal);
				}
				double d1 = b.c(this.c_Conflict).b(a.i.fH.a(), a.k.fH.a(), a.j.fH.a());
				double d2 = b.c(this.c_Conflict).b(a.i.fI.a(), a.k.fI.a(), a.j.fI.a());
				double d3 = b.c(this.c_Conflict).b(a.i.fy.a(), a.k.fy.a(), a.j.fy.a());
				double d4 = Math.Pow(2.0D, d3) * 5000.0D * this.b.p * this.b.q;
				double[][] arrayOfDouble1 = new double[3][];
				arrayOfDouble1[0] = arrayOfDouble;
				new[3][0] double = d1;
				new[3][1] double = d2;
				new[3][2] double = d4;
				arrayOfDouble1[1] = new double[3];
				arrayOfDouble1[2] = b.d(this.c_Conflict);
				p2AppManagerUtils.writeFileOfArray(b.d(this.c_Conflict), "Calibration" + Path.DirectorySeparatorChar + "param.conf", "\n");
				b.a(this.c_Conflict, this.b.a.DeviceAtion, arrayOfDouble1, p2Enumerations.p2AppManagerStatus.NO_ERROR);
			  }
			  else if (this.b.a == p2Enumerations.p2AppManagerState.CapCurrentRun)
			  {
				double[][] arrayOfDouble = b.b(this.c_Conflict, this.b, b.a(this.c_Conflict));
				if (arrayOfDouble == null)
				{
				  throw new p2AppManagerException("No valid result back for this p2Sample : " + b.b(this.c_Conflict) + " run.", p2Enumerations.p2AppManagerStatus.NO_OF_SCANS_DSP_ERROR.NumVal);
				}
				b.a(this.c_Conflict, this.b.a.DeviceAtion, arrayOfDouble, p2Enumerations.p2AppManagerStatus.NO_ERROR);
			  }
			  else if (this.b.a == p2Enumerations.p2AppManagerState.ResponseCalculation)
			  {
				double[][] arrayOfDouble = b.c(this.c_Conflict, this.b, b.a(this.c_Conflict));
				if (arrayOfDouble == null)
				{
				  throw new p2AppManagerException("No valid result back for this p2Sample : " + b.b(this.c_Conflict) + " run.", p2Enumerations.p2AppManagerStatus.NO_OF_SCANS_DSP_ERROR.NumVal);
				}
				b.a(this.c_Conflict, this.b.a.DeviceAtion, arrayOfDouble, p2Enumerations.p2AppManagerStatus.NO_ERROR);
			  }
			  else if (this.b.a == p2Enumerations.p2AppManagerState.ParametersCalculation)
			  {
				double[][] arrayOfDouble1 = b.d(this.c_Conflict, this.b, b.a(this.c_Conflict));
				if (arrayOfDouble1 == null)
				{
				  throw new p2AppManagerException("No valid result back for this p2Sample : " + b.b(this.c_Conflict) + " run.", p2Enumerations.p2AppManagerStatus.NO_OF_SCANS_DSP_ERROR.NumVal);
				}
				double[][] arrayOfDouble2 = new double[arrayOfDouble1.Length + 1][];
				for (sbyte b1 = 0; b1 < arrayOfDouble1.Length; b1++)
				{
				  arrayOfDouble2[b1] = new double[arrayOfDouble1[b1].Length];
				  Array.Copy(arrayOfDouble1[b1], 0, arrayOfDouble2[b1], 0, arrayOfDouble1[b1].Length);
				}
				arrayOfDouble2[arrayOfDouble1.Length] = new double[1];
				arrayOfDouble2[arrayOfDouble1.Length][0] = b.e(this.c_Conflict);
				b.a(this.c_Conflict, this.b.a.DeviceAtion, arrayOfDouble2, p2Enumerations.p2AppManagerStatus.NO_ERROR);
			  }
			  else if (this.b.a == p2Enumerations.p2AppManagerState.WaveformPreview)
			  {
				double[][] arrayOfDouble = b.e(this.c_Conflict, this.b, b.a(this.c_Conflict));
				if (arrayOfDouble == null)
				{
				  throw new p2AppManagerException("No valid result back for this p2Sample : " + b.b(this.c_Conflict) + " run.", p2Enumerations.p2AppManagerStatus.NO_OF_SCANS_DSP_ERROR.NumVal);
				}
				b.a(this.c_Conflict, this.b.a.DeviceAtion, arrayOfDouble, p2Enumerations.p2AppManagerStatus.NO_ERROR);
			  }
			}
			catch (p2AppManagerException p2AppManagerException)
			{
			  b.v().error(p2AppManagerException.Message);
			  b.a(this.c_Conflict, this.b.a.DeviceAtion, (double[][])null, p2Enumerations.p2AppManagerStatus.getAppManagerStatusByCode(p2AppManagerException.ErrorCode));
			}
			catch (a a1)
			{
			  b.v().error(a1.Message);
			  b.a(this.c_Conflict, this.b.a.DeviceAtion, (double[][])null, p2Enumerations.p2AppManagerStatus.ASIC_REGISTER_WRITING_ERROR);
			}
			return Convert.ToBoolean(true);
		  }
	  }

//JAVA TO C# CONVERTER NOTE: Members cannot have the same name as their enclosing type:
	  private void b_Conflict(a parama, bool paramBoolean)
	  {
		  c_Conflict.a(new aAnonymousInnerClass3(this, paramBoolean, parama));
	  }

	  private class aAnonymousInnerClass3 : a<bool>
	  {
		  private readonly b outerInstance;

		  public aAnonymousInnerClass3(b outerInstance, bool paramBoolean, sws.p2AppManager.b.a parama) : base(outerInstance, paramBoolean, parama)
		  {
			  this.outerInstance = outerInstance;
		  }

		  protected internal bool? a()
		  {
			try
			{
			  if (this.a)
			  {
				b.a(this.c_Conflict, b.a(this.c_Conflict));
			  }
			  double[][] arrayOfDouble = b.f(this.c_Conflict, this.b, b.a(this.c_Conflict));
			  if (arrayOfDouble == null)
			  {
				throw new p2AppManagerException("No valid result back for this p2Sample : " + b.b(this.c_Conflict) + " run.", p2Enumerations.p2AppManagerStatus.NO_OF_SCANS_DSP_ERROR.NumVal);
			  }
			  b.a(this.c_Conflict, this.b.a.DeviceAtion, arrayOfDouble, p2Enumerations.p2AppManagerStatus.NO_ERROR);
			}
			catch (p2AppManagerException p2AppManagerException)
			{
			  b.v().error(p2AppManagerException.Message);
			  b.a(this.c_Conflict, this.b.a.DeviceAtion, (double[][])null, p2Enumerations.p2AppManagerStatus.getAppManagerStatusByCode(p2AppManagerException.ErrorCode));
			}
			return Convert.ToBoolean(true);
		  }
	  }

	  private void c(a parama, bool paramBoolean)
	  {
		  c_Conflict.a(new aAnonymousInnerClass4(this, paramBoolean, parama));
	  }

	  private class aAnonymousInnerClass4 : a<bool>
	  {
		  private readonly b outerInstance;

		  public aAnonymousInnerClass4(b outerInstance, bool paramBoolean, sws.p2AppManager.b.a parama) : base(outerInstance, paramBoolean, parama)
		  {
			  this.outerInstance = outerInstance;
		  }

		  protected internal bool? a()
		  {
			try
			{
			  if (this.a)
			  {
				b.a(this.c_Conflict, b.a(this.c_Conflict));
			  }
			  double[][] arrayOfDouble = (double[][])null;
			  if (this.b.a == p2Enumerations.p2AppManagerState.PhaseTrimming)
			  {
				arrayOfDouble = b.g(this.c_Conflict, this.b, b.a(this.c_Conflict));
			  }
			  else if (this.b.a == p2Enumerations.p2AppManagerState.FastPhaseTrimming)
			  {
				arrayOfDouble = b.h(this.c_Conflict, this.b, b.a(this.c_Conflict));
			  }
			  if (arrayOfDouble == null)
			  {
				throw new p2AppManagerException("No valid result back for this p2Sample : " + b.b(this.c_Conflict) + " run.", p2Enumerations.p2AppManagerStatus.NO_OF_SCANS_DSP_ERROR.NumVal);
			  }
			  b.a(this.c_Conflict, this.b.a.DeviceAtion, arrayOfDouble, p2Enumerations.p2AppManagerStatus.NO_ERROR);
			}
			catch (p2AppManagerException p2AppManagerException)
			{
			  b.v().error(p2AppManagerException.Message);
			  b.a(this.c_Conflict, this.b.a.DeviceAtion, (double[][])null, p2Enumerations.p2AppManagerStatus.getAppManagerStatusByCode(p2AppManagerException.ErrorCode));
			}
			return Convert.ToBoolean(true);
		  }
	  }

	  private void d(a parama, bool paramBoolean)
	  {
		  c_Conflict.a(new aAnonymousInnerClass5(this, paramBoolean, parama));
	  }

	  private class aAnonymousInnerClass5 : a<bool>
	  {
		  private readonly b outerInstance;

		  public aAnonymousInnerClass5(b outerInstance, bool paramBoolean, sws.p2AppManager.b.a parama) : base(outerInstance, paramBoolean, parama)
		  {
			  this.outerInstance = outerInstance;
		  }

		  protected internal bool? a()
		  {
			try
			{
			  if (this.a)
			  {
				b.a(this.c_Conflict, b.a(this.c_Conflict));
			  }
			  double[][] arrayOfDouble = b.i(this.c_Conflict, this.b, b.a(this.c_Conflict));
			  if (arrayOfDouble == null)
			  {
				throw new p2AppManagerException("No valid result back for this p2Sample : " + b.b(this.c_Conflict) + " run.", p2Enumerations.p2AppManagerStatus.NO_OF_SCANS_DSP_ERROR.NumVal);
			  }
			  b.a(this.c_Conflict, this.b.a.DeviceAtion, arrayOfDouble, p2Enumerations.p2AppManagerStatus.NO_ERROR);
			}
			catch (p2AppManagerException p2AppManagerException)
			{
			  b.v().error(p2AppManagerException.Message);
			  b.a(this.c_Conflict, this.b.a.DeviceAtion, (double[][])null, p2Enumerations.p2AppManagerStatus.getAppManagerStatusByCode(p2AppManagerException.ErrorCode));
			}
			return Convert.ToBoolean(true);
		  }
	  }

	  private void e(a parama, bool paramBoolean)
	  {
		  c_Conflict.a(new aAnonymousInnerClass6(this, paramBoolean, parama));
	  }

	  private class aAnonymousInnerClass6 : a<bool>
	  {
		  private readonly b outerInstance;

		  public aAnonymousInnerClass6(b outerInstance, bool paramBoolean, sws.p2AppManager.b.a parama) : base(outerInstance, paramBoolean, parama)
		  {
			  this.outerInstance = outerInstance;
		  }

		  protected internal bool? a()
		  {
			try
			{
			  if (this.a)
			  {
				b.a(this.c_Conflict, b.a(this.c_Conflict));
			  }
			  b.a a1 = b.a(this.c_Conflict, b.a(this.c_Conflict), this.b);
			  double[] arrayOfDouble = b.j(this.c_Conflict, a1, b.a(this.c_Conflict));
			  if (arrayOfDouble == null)
			  {
				throw new p2AppManagerException("No valid result back for this p2Sample : " + b.b(this.c_Conflict) + " run.", p2Enumerations.p2AppManagerStatus.NO_OF_SCANS_DSP_ERROR.NumVal);
			  }
			  double[][] arrayOfDouble1 = new double[1][];
			  arrayOfDouble1[0] = arrayOfDouble;
			  b.a(this.c_Conflict, this.b.a.DeviceAtion, arrayOfDouble1, p2Enumerations.p2AppManagerStatus.NO_ERROR);
			}
			catch (p2AppManagerException p2AppManagerException)
			{
			  b.v().error(p2AppManagerException.Message);
			  b.a(this.c_Conflict, this.b.a.DeviceAtion, (double[][])null, p2Enumerations.p2AppManagerStatus.getAppManagerStatusByCode(p2AppManagerException.ErrorCode));
			}
			return Convert.ToBoolean(true);
		  }
	  }

	  private void f(a parama, bool paramBoolean)
	  {
		  c_Conflict.a(new aAnonymousInnerClass7(this, paramBoolean, parama));
	  }

	  private class aAnonymousInnerClass7 : a<bool>
	  {
		  private readonly b outerInstance;

		  public aAnonymousInnerClass7(b outerInstance, bool paramBoolean, sws.p2AppManager.b.a parama) : base(outerInstance, paramBoolean, parama)
		  {
			  this.outerInstance = outerInstance;
		  }

		  protected internal bool? a()
		  {
			try
			{
			  if (this.a)
			  {
				b.a(this.c_Conflict, b.a(this.c_Conflict));
			  }
			  b.a a1 = b.a(this.c_Conflict, b.a(this.c_Conflict), this.b);
			  b.k(this.c_Conflict, a1, b.a(this.c_Conflict));
			  b.a(this.c_Conflict, this.b.a.DeviceAtion, (double[][])null, p2Enumerations.p2AppManagerStatus.NO_ERROR);
			}
			catch (p2AppManagerException p2AppManagerException)
			{
			  b.v().error(p2AppManagerException.Message);
			  b.a(this.c_Conflict, this.b.a.DeviceAtion, (double[][])null, p2Enumerations.p2AppManagerStatus.getAppManagerStatusByCode(p2AppManagerException.ErrorCode));
			}
			return Convert.ToBoolean(true);
		  }
	  }

	  private void a(a parama)
	  {
		  c_Conflict.a(new aAnonymousInnerClass8(this, parama));
	  }

	  private class aAnonymousInnerClass8 : a<bool>
	  {
		  private readonly b outerInstance;

		  public aAnonymousInnerClass8(b outerInstance, sws.p2AppManager.b.a parama) : base(outerInstance, parama)
		  {
			  this.outerInstance = outerInstance;
		  }

		  protected internal bool? a()
		  {
			try
			{
			  this.a.aa = b.a(this.b, this.a.ac, this.a.b);
			  b.v().info("noOfSlices: " + this.a.aa);
			  this.a.ab = b.a(this.b, this.a.aa);
			  b.v().info("avgShiftBits: " + this.a.ab);
			  double[][] arrayOfDouble = (double[][])null;
			  b.a(this.b, p2AppManagerUtils.loadRawDataFile("Calibration" + Path.DirectorySeparatorChar + "param.conf"));
			  double[] arrayOfDouble1 = p2AppManagerUtils.loadRawDataFile(p2Constants.getPath(p2Constants.LASER_FILE_PATH) + "_1" + ".txt");
			  double[] arrayOfDouble2 = p2AppManagerUtils.loadRawDataFile(p2Constants.getPath(p2Constants.LASER_FILE_PATH) + "_2" + ".txt");
			  double[] arrayOfDouble3 = p2AppManagerUtils.loadRawDataFile(p2Constants.getPath(p2Constants.WL_FILE_PATH) + "_1" + ".txt");
			  double[] arrayOfDouble4 = p2AppManagerUtils.loadRawDataFile(p2Constants.getPath(p2Constants.WL_FILE_PATH) + "_2" + ".txt");
			  double[] arrayOfDouble5 = null;
			  double[] arrayOfDouble6 = null;
			  double[] arrayOfDouble7 = null;
			  if (!this.a.A)
			  {
				arrayOfDouble5 = p2AppManagerUtils.loadRawDataFile(p2Constants.getPath(p2Constants.METH_FILE_PATH) + "_1" + ".txt");
				arrayOfDouble6 = p2AppManagerUtils.loadRawDataFile(p2Constants.getPath(p2Constants.METH_FILE_PATH) + "_2" + ".txt");
				arrayOfDouble7 = p2AppManagerUtils.loadRawDataFile(p2Constants.getPath(p2Constants.STANDARD_CALIBRATORS_FOLDER_PATH) + Path.DirectorySeparatorChar + this.a.Y + ".txt");
			  }
			  if (arrayOfDouble1 == null || arrayOfDouble2 == null)
			  {
				throw new p2AppManagerException("Failed to load laser files ", p2Enumerations.p2AppManagerStatus.LASER_FILE_NOT_EXIST_ERROR.NumVal);
			  }
			  if (arrayOfDouble3 == null || arrayOfDouble4 == null)
			  {
				throw new p2AppManagerException("Failed to load white light files ", p2Enumerations.p2AppManagerStatus.WHITE_FILE_NOT_EXIST_ERROR.NumVal);
			  }
			  if (arrayOfDouble7 == null && !this.a.A)
			  {
				throw new p2AppManagerException("Failed to load standard calibrator file ", p2Enumerations.p2AppManagerStatus.WHITE_FILE_NOT_EXIST_ERROR.NumVal);
			  }
			  if ((arrayOfDouble5 == null || arrayOfDouble6 == null) && !this.a.A)
			  {
				this.a.A = true;
			  }
			  if (this.a.A == true)
			  {
				arrayOfDouble5 = new double[] {0.0D};
				arrayOfDouble6 = new double[] {0.0D};
				arrayOfDouble7 = new double[] {0.0D};
			  }
			  int i = (int)b.c(this.b).b(a.i.fH.a(), a.k.fH.a(), a.j.fH.a());
			  int j = (int)b.c(this.b).b(i.fI.a(), a.k.fI.a(), a.j.fI.a());
			  int k = (int)b.c(this.b).b(i.fy.a(), a.k.fy.a(), j.fy.a());
			  double d1 = Math.Pow(2.0D, k) * 5000.0D * this.a.p * this.a.q;
			  double d2 = b.c(this.b).b(i.cB.a(), k.cB.a(), j.cB.a());
			  if (this.a.h)
			  {
				b.d(this.b)[47] = 0.0D;
			  }
			  else
			  {
				b.d(this.b)[47] = 1.0D;
			  }
			  if (this.a.s)
			  {
				b.d(this.b)[1] = this.a.t;
			  }
			  string str1 = this.a.ah;
			  List<object> arrayList1 = new List<object>();
			  if (!string.ReferenceEquals(str1, null))
			  {
				if (str1.Equals("1.7"))
				{
				  foreach (double d in arrayOfDouble7)
				  {
					if (d >= 1200.0D && d <= 1690.0D)
					{
					  arrayList1.Add(Convert.ToDouble(d));
					}
				  }
				}
				else if (str1.Equals("2.1"))
				{
				  foreach (double d in arrayOfDouble7)
				  {
					if (d >= 1250.0D && d <= 2050.0D)
					{
					  arrayList1.Add(Convert.ToDouble(d));
					}
				  }
				}
				else if (str1.Equals("2.6"))
				{
				  foreach (double d in arrayOfDouble7)
				  {
					if (d >= 1300.0D && d <= 2550.0D)
					{
					  arrayList1.Add(Convert.ToDouble(d));
					}
				  }
				}
			  }
			  if (arrayList1.Count != 0)
			  {
				arrayOfDouble7 = new double[arrayList1.Count];
				for (sbyte b2 = 0; b2 < arrayList1.Count; b2++)
				{
				  arrayOfDouble7[b2] = ((double?)arrayList1[b2]).Value;
				}
			  }
			  try
			  {
				arrayOfDouble = p2SpectroDSP.a().a(arrayOfDouble2, arrayOfDouble1, arrayOfDouble4, arrayOfDouble3, arrayOfDouble6, arrayOfDouble5, b.a(this.b).f(), b.a(this.b).g(), b.a(this.b).h(), b.a(this.b).k(), b.a(this.b).l(), this.a.b, d1, this.a.B, this.a.A, this.a.m, i, j, this.a.v, this.a.aa, this.a.ab, d2, b.d(this.b), this.a.X, arrayOfDouble7, this.a.e);
			  }
			  catch (a)
			  {
				throw new p2AppManagerException("Error while make DSP data calibration generation ", p2Enumerations.p2AppManagerStatus.CALIBRATION_GENERATION_ERROR.NumVal);
			  }
			  arrayOfDouble1 = null;
			  arrayOfDouble2 = null;
			  arrayOfDouble3 = null;
			  arrayOfDouble4 = null;
			  arrayOfDouble5 = null;
			  arrayOfDouble6 = null;
			  arrayOfDouble7 = null;
			  long l = b.f(this.b);
			  if (l == -1L || l == 0L)
			  {
				throw new p2AppManagerException("Error during reading temp. ", p2Enumerations.p2AppManagerStatus.READING_TEMP_ERROR.NumVal);
			  }
			  string str2 = l.ToString();
			  string[] arrayOfString1 = p2AppManagerUtils.getFolderSubFoldersNames(p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.getPath(p2Constants.CONFIG_SAMPLE_PATH_TEMPLATE)), new object[] {b.b(this.b)}), new List<object>(), false);
			  if (arrayOfString1 != null)
			  {
				for (sbyte b2 = 0; b2 < arrayOfString1.Length; b2++)
				{
				  double d = 0.0D;
				  try
				  {
					d = double.Parse(arrayOfString1[b2]);
				  }
				  catch (Exception)
				  {
				  }
				  if (Math.Abs(l - d) <= 72000.0D)
				  {
					str2 = arrayOfString1[b2];
					break;
				  }
				}
			  }
			  p2AppManagerUtils.createDir(p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.CONFIG_SAMPLE_PROFILE_PATH_TEMPLATE), new object[] {this.a.C, str2 + Path.DirectorySeparatorChar + this.a.D}));
			  b.a(this.b, p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.CONFIG_SAMPLE_PROFILE_PATH_TEMPLATE), new object[] {this.a.C, str2 + Path.DirectorySeparatorChar + this.a.D}), p2Constants.getPath(p2Constants.GLOBAL_CONFIG_MEMS_PATH), this.a);
			  StreamReader bufferedReader = new StreamReader(p2Constants.getPath(p2Constants.PARAM_HEADER_FIE_PATH));
			  List<object> arrayList2 = new List<object>();
			  string str3;
			  while (!string.ReferenceEquals((str3 = bufferedReader.ReadLine()), null))
			  {
				arrayList2.Add(str3);
			  }
			  bufferedReader.Close();
			  for (sbyte b1 = 0; b1 < arrayList2.Count; b1++)
			  {
				if (double.Parse(((string)arrayList2[b1]).Split(":", true)[1]) != arrayOfDouble[6][b1])
				{
				  arrayList2[b1] = ((string)arrayList2[b1]).Split(":", true)[0] + " : " + arrayOfDouble[6][b1];
				}
			  }
			  arrayList2[33] = ((string)arrayList2[33]).Split(":", true)[0] + " : " + l;
			  string[] arrayOfString2 = new string[] {""};
			  p2AppManagerUtils.writeFileOfArray((string[])arrayList2.toArray(arrayOfString2), p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.CONFIG_SAMPLE_PROFILE_FILES_PATH_TEMPLATE), new object[] {this.a.C, str2 + Path.DirectorySeparatorChar + this.a.D, "param.conf"}), "\n");
			  int[] arrayOfInt = new int[2];
			  arrayOfInt[0] = 1;
			  arrayOfInt[1] = 0;
			  p2AppManagerUtils.writeFileOfArray(arrayOfInt, p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.CONFIG_SAMPLE_PROFILE_FILES_PATH_TEMPLATE), new object[] {this.a.C, str2 + Path.DirectorySeparatorChar + this.a.D, "corr.cal"}), "\n");
			  double[] arrayOfDouble8 = new double[arrayOfDouble[0].Length + arrayOfDouble[1].Length + arrayOfDouble[2].Length];
			  Array.Copy(arrayOfDouble[0], 0, arrayOfDouble8, 0, arrayOfDouble[0].Length);
			  Array.Copy(arrayOfDouble[1], 0, arrayOfDouble8, arrayOfDouble[0].Length, arrayOfDouble[1].Length);
			  Array.Copy(arrayOfDouble[2], 0, arrayOfDouble8, arrayOfDouble[0].Length + arrayOfDouble[1].Length, arrayOfDouble[2].Length);
			  p2AppManagerUtils.writeFileOfArray(arrayOfDouble8, p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.CONFIG_SAMPLE_PROFILE_FILES_PATH_TEMPLATE), new object[] {this.a.C, str2 + Path.DirectorySeparatorChar + this.a.D, "C2x.cal"}), "\n");
			  p2AppManagerUtils.writeFileOfArray(arrayOfDouble[4], p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.CONFIG_SAMPLE_PROFILE_FILES_PATH_TEMPLATE), new object[] {this.a.C, str2 + Path.DirectorySeparatorChar + this.a.D, "wl_corr.cal"}), "\n");
			  p2AppManagerUtils.writeFileOfArray(arrayOfDouble[5], p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.CONFIG_SAMPLE_PROFILE_FILES_PATH_TEMPLATE), new object[] {this.a.C, str2 + Path.DirectorySeparatorChar + this.a.D, "wavelength_corr.cal"}), "\n");
			  b.a(this.b, this.a.a.DeviceAtion, arrayOfDouble, p2Enumerations.p2AppManagerStatus.NO_ERROR);
			}
			catch (p2AppManagerException p2AppManagerException)
			{
			  b.v().error(p2AppManagerException.Message);
			  b.a(this.b, this.a.a.DeviceAtion, (double[][])null, p2Enumerations.p2AppManagerStatus.getAppManagerStatusByCode(p2AppManagerException.ErrorCode));
			}
			catch (Exception exception)
			{
			  b.v().error(exception.Message);
			  b.a(this.b, this.a.a.DeviceAtion, (double[][])null, p2Enumerations.p2AppManagerStatus.CALIBRATION_GENERATION_ERROR);
			}
			return Convert.ToBoolean(true);
		  }
	  }

	  private void a(string paramString1, string paramString2, a parama)
	  {
		try
		{
		  this.O.b(i_Conflict.aM.a(), 0L, k_Conflict.aM.a(), j_Conflict.aM.a());
		  this.O.b(i_Conflict.aN.a(), 0L, k_Conflict.aN.a(), j_Conflict.aN.a());
		  this.O.b(i_Conflict.cX.a(), 0L, k_Conflict.cX.a(), j_Conflict.cX.a());
		  this.O.b(i_Conflict.cI.a(), 0L, k_Conflict.cI.a(), j_Conflict.cI.a());
		  this.O.b(i_Conflict.k.a(), 1L, k_Conflict.k.a(), j_Conflict.k.a());
		  long[] arrayOfLong = this.O.b();
		  PrintWriter printWriter = new PrintWriter(paramString1 + Path.DirectorySeparatorChar + "t.reg", "UTF-8");
		  foreach (long l1 in arrayOfLong)
		  {
			printWriter.println(l1.ToString("x"));
		  }
		  printWriter.close();
		  Files.copy((new File(paramString2 + Path.DirectorySeparatorChar + "param.conf")).toPath(), (new File(paramString1 + Path.DirectorySeparatorChar + "param.conf")).toPath(), new CopyOption[] {StandardCopyOption.REPLACE_EXISTING});
		}
		catch (Exception exception)
		{
		  b_Conflict.error(exception.Message);
		}
	  }

	  private void g(a parama, bool paramBoolean)
	  {
		  c_Conflict.a(new aAnonymousInnerClass9(this, paramBoolean, parama));
	  }

	  private class aAnonymousInnerClass9 : a<bool>
	  {
		  private readonly b outerInstance;

		  public aAnonymousInnerClass9(b outerInstance, bool paramBoolean, sws.p2AppManager.b.a parama) : base(outerInstance, paramBoolean, parama)
		  {
			  this.outerInstance = outerInstance;
		  }

		  protected internal bool? a()
		  {
			try
			{
			  if (this.a)
			  {
				b.a(this.c_Conflict, b.a(this.c_Conflict));
			  }
			  b.c(this.c_Conflict).a(this.b.C.Bytes);
			  b.a(this.c_Conflict, this.b.C);
			  p2AppManagerUtils.createDir(p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.getPath(p2Constants.CONFIG_SAMPLE_PATH_TEMPLATE)), new object[] {b.b(this.c_Conflict)}));
			  b.a(this.c_Conflict, this.b.a.DeviceAtion, (double[][])null, p2Enumerations.p2AppManagerStatus.NO_ERROR);
			}
			catch (p2AppManagerException p2AppManagerException)
			{
			  b.v().error(p2AppManagerException.Message);
			  b.a(this.c_Conflict, this.b.a.DeviceAtion, (double[][])null, p2Enumerations.p2AppManagerStatus.getAppManagerStatusByCode(p2AppManagerException.ErrorCode));
			}
			catch (Exception exception)
			{
			  b.v().error(exception.Message);
			  b.a(this.c_Conflict, this.b.a.DeviceAtion, (double[][])null, p2Enumerations.p2AppManagerStatus.BURNING_SAMPLE_ID_ERROR);
			}
			return Convert.ToBoolean(true);
		  }
	  }

	  private void h(a parama, bool paramBoolean)
	  {
		  c_Conflict.a(new aAnonymousInnerClass10(this, paramBoolean, parama));
	  }

	  private class aAnonymousInnerClass10 : a<bool>
	  {
		  private readonly b outerInstance;

		  public aAnonymousInnerClass10(b outerInstance, bool paramBoolean, sws.p2AppManager.b.a parama) : base(outerInstance, paramBoolean, parama)
		  {
			  this.outerInstance = outerInstance;
		  }

		  protected internal bool? a()
		  {
			try
			{
			  if (this.a)
			  {
				b.a(this.c_Conflict, b.a(this.c_Conflict));
			  }
			  long l = b.c(this.c_Conflict).d();
			  double[][] arrayOfDouble = new double[][]
			  {
				  new double[] {l}
			  };
			  b.a(this.c_Conflict, this.b.a.DeviceAtion, arrayOfDouble, p2Enumerations.p2AppManagerStatus.NO_ERROR);
			}
			catch (p2AppManagerException p2AppManagerException)
			{
			  b.v().error(p2AppManagerException.Message);
			  b.a(this.c_Conflict, this.b.a.DeviceAtion, (double[][])null, p2Enumerations.p2AppManagerStatus.getAppManagerStatusByCode(p2AppManagerException.ErrorCode));
			}
			catch (Exception exception)
			{
			  b.v().error(exception.Message);
			  b.a(this.c_Conflict, this.b.a.DeviceAtion, (double[][])null, p2Enumerations.p2AppManagerStatus.BURNING_SAMPLE_ID_ERROR);
			}
			return Convert.ToBoolean(true);
		  }
	  }

	  private void i(a parama, bool paramBoolean)
	  {
		  c_Conflict.a(new aAnonymousInnerClass11(this, paramBoolean, parama));
	  }

	  private class aAnonymousInnerClass11 : a<bool>
	  {
		  private readonly b outerInstance;

		  public aAnonymousInnerClass11(b outerInstance, bool paramBoolean, sws.p2AppManager.b.a parama) : base(outerInstance, paramBoolean, parama)
		  {
			  this.outerInstance = outerInstance;
		  }

		  protected internal bool? a()
		  {
			try
			{
			  if (this.a)
			  {
				b.a(this.c_Conflict, b.a(this.c_Conflict));
			  }
			  b.a(this.c_Conflict, b.c(this.c_Conflict).b());
			  b.a(this.c_Conflict, this.b.a.DeviceAtion, (double[][])null, p2Enumerations.p2AppManagerStatus.NO_ERROR);
			}
			catch (p2AppManagerException p2AppManagerException)
			{
			  b.v().error(p2AppManagerException.Message);
			  b.a(this.c_Conflict, this.b.a.DeviceAtion, (double[][])null, p2Enumerations.p2AppManagerStatus.getAppManagerStatusByCode(p2AppManagerException.ErrorCode));
			}
			catch (Exception exception)
			{
			  b.v().error(exception.Message);
			  b.a(this.c_Conflict, this.b.a.DeviceAtion, (double[][])null, p2Enumerations.p2AppManagerStatus.READING_ASIC_REGISTERS_ERROR);
			}
			return Convert.ToBoolean(true);
		  }
	  }

	  private void j(a parama, bool paramBoolean)
	  {
		  c_Conflict.a(new aAnonymousInnerClass12(this, paramBoolean, parama));
	  }

	  private class aAnonymousInnerClass12 : a<bool>
	  {
		  private readonly b outerInstance;

		  public aAnonymousInnerClass12(b outerInstance, bool paramBoolean, sws.p2AppManager.b.a parama) : base(outerInstance, paramBoolean, parama)
		  {
			  this.outerInstance = outerInstance;
		  }

		  protected internal bool? a()
		  {
			try
			{
			  if (this.a)
			  {
				b.a(this.c_Conflict, b.a(this.c_Conflict));
			  }
			  b.c(this.c_Conflict).a(this.b.E);
			  b.a(this.c_Conflict, this.b.a.DeviceAtion, (double[][])null, p2Enumerations.p2AppManagerStatus.NO_ERROR);
			}
			catch (p2AppManagerException p2AppManagerException)
			{
			  b.v().error(p2AppManagerException.Message);
			  b.a(this.c_Conflict, this.b.a.DeviceAtion, (double[][])null, p2Enumerations.p2AppManagerStatus.getAppManagerStatusByCode(p2AppManagerException.ErrorCode));
			}
			catch (Exception exception)
			{
			  b.v().error(exception.Message);
			  b.a(this.c_Conflict, this.b.a.DeviceAtion, (double[][])null, p2Enumerations.p2AppManagerStatus.WRITING_ASIC_REGISTERS_ERROR);
			}
			return Convert.ToBoolean(true);
		  }
	  }

	  private void k(a parama, bool paramBoolean)
	  {
		  c_Conflict.a(new aAnonymousInnerClass13(this, paramBoolean, parama));
	  }

	  private class aAnonymousInnerClass13 : a<bool>
	  {
		  private readonly b outerInstance;

		  public aAnonymousInnerClass13(b outerInstance, bool paramBoolean, sws.p2AppManager.b.a parama) : base(outerInstance, paramBoolean, parama)
		  {
			  this.outerInstance = outerInstance;
		  }

		  protected internal bool? a()
		  {
			try
			{
			  if (this.a)
			  {
				b.a(this.c_Conflict, b.a(this.c_Conflict));
			  }
			  b.a(this.c_Conflict, this.b.F);
			  b.a(this.c_Conflict, this.b.a.DeviceAtion, (double[][])null, p2Enumerations.p2AppManagerStatus.NO_ERROR);
			}
			catch (p2AppManagerException p2AppManagerException)
			{
			  b.v().error(p2AppManagerException.Message);
			  b.a(this.c_Conflict, this.b.a.DeviceAtion, (double[][])null, p2Enumerations.p2AppManagerStatus.getAppManagerStatusByCode(p2AppManagerException.ErrorCode));
			}
			catch (Exception exception)
			{
			  b.v().error(exception.Message);
			  b.a(this.c_Conflict, this.b.a.DeviceAtion, (double[][])null, p2Enumerations.p2AppManagerStatus.WRITING_PROFILES_TO_ROM_ERROR);
			}
			return Convert.ToBoolean(true);
		  }
	  }

	  private void l(a parama, bool paramBoolean)
	  {
		  c_Conflict.a(new aAnonymousInnerClass14(this, paramBoolean, parama));
	  }

	  private class aAnonymousInnerClass14 : a<bool>
	  {
		  private readonly b outerInstance;

		  public aAnonymousInnerClass14(b outerInstance, bool paramBoolean, sws.p2AppManager.b.a parama) : base(outerInstance, paramBoolean, parama)
		  {
			  this.outerInstance = outerInstance;
		  }

		  protected internal bool? a()
		  {
			try
			{
			  if (this.a)
			  {
				b.a(this.c_Conflict, b.a(this.c_Conflict));
			  }
			  p2AppManagerUtils.removeDir(p2Constants.getPath(p2Constants.TEMP_CONFIG_SAMPLE_PATH), true);
			  if (this.b.G.Equals(p2Enumerations.RestoreOptionsEnum.OPTICAL_GAIN_SETTINGS.StringVal))
			  {
				string[] arrayOfString = p2AppManagerUtils.getFolderSubFoldersNames(p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.CONFIG_SAMPLE_PATH_TEMPLATE), new object[] {b.b(this.c_Conflict)}), new List<object>(), false);
				foreach (string str in arrayOfString)
				{
				  string[] arrayOfString1 = p2AppManagerUtils.getFolderSubFoldersNames(p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.CONFIG_SAMPLE_PATH_TEMPLATE), new object[] {b.b(this.c_Conflict)}) + File.separator + str, new List<object>(), false);
				  foreach (string str1 in arrayOfString1)
				  {
					string str2 = p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.CONFIG_SAMPLE_PATH_TEMPLATE), new object[] {b.b(this.c_Conflict)}) + File.separator + str + File.separator + str1 + File.separator + "corr.cal";
					string str3 = p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.CONFIG_SAMPLE_PATH_TEMPLATE), new object[] {b.b(this.c_Conflict)}) + File.separator + str + File.separator + str1 + File.separator + "wavelength_corr.cal";
					File file1 = new File(p2Constants.getPath(p2Constants.TEMP_CONFIG_SAMPLE_PATH) + File.separator + str + File.separator + str1 + File.separator + "corr.cal");
					File file2 = new File(p2Constants.getPath(p2Constants.TEMP_CONFIG_SAMPLE_PATH) + File.separator + str + File.separator + str1 + File.separator + "wavelength_corr.cal");
					try
					{
					  FileUtils.copyFile(new File(str2), file1);
					  FileUtils.copyFile(new File(str3), file2);
					}
					catch (IOException iOException)
					{
					  b.v().error(iOException.Message + "");
					  b.a(this.c_Conflict, this.b.a.DeviceAtion, (double[][])null, p2Enumerations.p2AppManagerStatus.WRITING_PROFILES_TO_ROM_ERROR);
					}
				  }
				}
			  }
			  else if (this.b.G.Equals(p2Enumerations.RestoreOptionsEnum.CORRECTION_SETTINGS.StringVal))
			  {
				string str = p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.OPTICAL_SETTINGS_FILE_PATH), new object[] {b.b(this.c_Conflict)});
				File file = new File(p2Constants.getPath(p2Constants.OPTICAL_SETTINGS_TEMP_FILE_PATH));
				try
				{
				  FileUtils.copyFile(new File(str), file);
				}
				catch (IOException iOException)
				{
				  b.v().error(iOException.Message);
				  b.a(this.c_Conflict, this.b.a.DeviceAtion, (double[][])null, p2Enumerations.p2AppManagerStatus.WRITING_PROFILES_TO_ROM_ERROR);
				}
			  }
			  b.g(this.c_Conflict);
			  if (this.b.G.Equals(p2Enumerations.RestoreOptionsEnum.OPTICAL_GAIN_SETTINGS.StringVal))
			  {
				string[] arrayOfString = p2AppManagerUtils.getFolderSubFoldersNames(p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.CONFIG_SAMPLE_PATH_TEMPLATE), new object[] {b.b(this.c_Conflict)}), new List<object>(), false);
				foreach (string str in arrayOfString)
				{
				  string[] arrayOfString1 = p2AppManagerUtils.getFolderSubFoldersNames(p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.CONFIG_SAMPLE_PATH_TEMPLATE), new object[] {b.b(this.c_Conflict)}) + File.separator + str, new List<object>(), false);
				  foreach (string str1 in arrayOfString1)
				  {
					string str2 = p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.CONFIG_SAMPLE_PATH_TEMPLATE), new object[] {b.b(this.c_Conflict)}) + File.separator + str + File.separator + str1 + File.separator + "corr.cal";
					string str3 = p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.CONFIG_SAMPLE_PATH_TEMPLATE), new object[] {b.b(this.c_Conflict)}) + File.separator + str + File.separator + str1 + File.separator + "wavelength_corr.cal";
					File file1 = new File(p2Constants.getPath(p2Constants.TEMP_CONFIG_SAMPLE_PATH) + File.separator + str + File.separator + str1 + File.separator + "corr.cal");
					File file2 = new File(p2Constants.getPath(p2Constants.TEMP_CONFIG_SAMPLE_PATH) + File.separator + str + File.separator + str1 + File.separator + "wavelength_corr.cal");
					try
					{
					  Files.delete((new File(str2)).toPath());
					  Files.delete((new File(str3)).toPath());
					  FileUtils.moveFile(file1, new File(str2));
					  FileUtils.moveFile(file2, new File(str3));
					}
					catch (IOException iOException)
					{
					  b.v().error(iOException.Message);
					  b.a(this.c_Conflict, this.b.a.DeviceAtion, (double[][])null, p2Enumerations.p2AppManagerStatus.WRITING_PROFILES_TO_ROM_ERROR);
					}
				  }
				}
			  }
			  else if (this.b.G.Equals(p2Enumerations.RestoreOptionsEnum.CORRECTION_SETTINGS.StringVal))
			  {
				string str1 = p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.OPTICAL_SETTINGS_FILE_PATH), new object[] {b.b(this.c_Conflict)});
				string str2 = p2Constants.getPath(p2Constants.OPTICAL_SETTINGS_TEMP_FILE_PATH);
				try
				{
				  Files.delete((new File(str1)).toPath());
				  FileUtils.moveFile(new File(str2), new File(str1));
				}
				catch (IOException iOException)
				{
				  b.v().error(iOException.Message);
				  b.a(this.c_Conflict, this.b.a.DeviceAtion, (double[][])null, p2Enumerations.p2AppManagerStatus.WRITING_PROFILES_TO_ROM_ERROR);
				}
			  }
			  b.a(this.c_Conflict, this.b.a.DeviceAtion, (double[][])null, p2Enumerations.p2AppManagerStatus.NO_ERROR);
			}
			catch (p2AppManagerException p2AppManagerException)
			{
			  b.v().error(p2AppManagerException.Message);
			  b.a(this.c_Conflict, this.b.a.DeviceAtion, (double[][])null, p2Enumerations.p2AppManagerStatus.getAppManagerStatusByCode(p2AppManagerException.ErrorCode));
			}
			catch (Exception exception)
			{
			  b.v().error(exception.Message);
			  b.a(this.c_Conflict, this.b.a.DeviceAtion, (double[][])null, p2Enumerations.p2AppManagerStatus.WRITING_PROFILES_TO_ROM_ERROR);
			}
			return Convert.ToBoolean(true);
		  }
	  }

	  private void m(a parama, bool paramBoolean)
	  {
		  c_Conflict.a(new aAnonymousInnerClass15(this, paramBoolean, parama));
	  }

	  private class aAnonymousInnerClass15 : a<bool>
	  {
		  private readonly b outerInstance;

		  public aAnonymousInnerClass15(b outerInstance, bool paramBoolean, sws.p2AppManager.b.a parama) : base(outerInstance, paramBoolean, parama)
		  {
			  this.outerInstance = outerInstance;
		  }

		  protected internal bool? a()
		  {
			try
			{
			  if (this.a)
			  {
				b.a(this.c_Conflict, b.a(this.c_Conflict));
			  }
			  b.h(this.c_Conflict);
			  b.a(this.c_Conflict, this.b.a.DeviceAtion, (double[][])null, p2Enumerations.p2AppManagerStatus.NO_ERROR);
			}
			catch (p2AppManagerException p2AppManagerException)
			{
			  b.v().error(p2AppManagerException.Message);
			  b.a(this.c_Conflict, this.b.a.DeviceAtion, (double[][])null, p2Enumerations.p2AppManagerStatus.getAppManagerStatusByCode(p2AppManagerException.ErrorCode));
			}
			catch (Exception exception)
			{
			  b.v().error(exception.Message);
			  b.a(this.c_Conflict, this.b.a.DeviceAtion, (double[][])null, p2Enumerations.p2AppManagerStatus.WRITING_PROFILES_TO_ROM_ERROR);
			}
			return Convert.ToBoolean(true);
		  }
	  }

	  private void a(a parama, bool paramBoolean1, bool paramBoolean2, string[] paramArrayOfString)
	  {
		  c_Conflict.a(new aAnonymousInnerClass16(this, paramBoolean1, parama, paramArrayOfString, paramBoolean2));
	  }

	  private class aAnonymousInnerClass16 : a<bool>
	  {
		  private readonly b outerInstance;

		  public aAnonymousInnerClass16(b outerInstance, bool paramBoolean1, sws.p2AppManager.b.a parama, string[] paramArrayOfString, bool paramBoolean2) : base(outerInstance, paramBoolean1, parama, paramArrayOfString, paramBoolean2)
		  {
			  this.outerInstance = outerInstance;
		  }

		  protected internal bool? a()
		  {
			try
			{
			  if (this.a)
			  {
				b.a(this.e_Conflict, b.a(this.e_Conflict));
			  }
			  string str1 = p2Constants.getPath(p2Constants.TEMP_CONFIG_SAMPLE_PATH);
			  p2AppManagerUtils.removeDir(str1, true);
			  string str2 = p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.OPTICAL_SETTINGS_FILE_PATH), new object[] {b.b(this.e_Conflict)});
			  File file = new File(p2Constants.getPath(p2Constants.OPTICAL_SETTINGS_TEMP_FILE_PATH));
			  try
			  {
				FileUtils.copyFile(new File(str2), file);
			  }
			  catch (IOException iOException)
			  {
				b.v().error(iOException.Message);
				b.a(this.e_Conflict, this.b.a.DeviceAtion, (double[][])null, p2Enumerations.p2AppManagerStatus.WRITING_PROFILES_TO_ROM_ERROR);
			  }
			  b.i(this.e_Conflict);
			  this.e_Conflict.b(this.c_Conflict);
			  b.a(this.e_Conflict, this.d_Conflict);
			  try
			  {
				FileUtils.deleteQuietly(new File(str2));
				FileUtils.copyFile(file, new File(str2));
			  }
			  catch (IOException iOException)
			  {
				b.v().error(iOException.Message);
				b.a(this.e_Conflict, this.b.a.DeviceAtion, (double[][])null, p2Enumerations.p2AppManagerStatus.WRITING_PROFILES_TO_ROM_ERROR);
			  }
			  p2AppManagerUtils.removeDir(str1, true);
			  b.a(this.e_Conflict, this.b.a.DeviceAtion, (double[][])null, p2Enumerations.p2AppManagerStatus.NO_ERROR);
			}
			catch (p2AppManagerException p2AppManagerException)
			{
			  b.v().error(p2AppManagerException.Message);
			  b.a(this.e_Conflict, this.b.a.DeviceAtion, (double[][])null, p2Enumerations.p2AppManagerStatus.getAppManagerStatusByCode(p2AppManagerException.ErrorCode));
			}
			catch (Exception exception)
			{
			  b.v().error(exception.Message);
			  b.a(this.e_Conflict, this.b.a.DeviceAtion, (double[][])null, p2Enumerations.p2AppManagerStatus.WRITING_PROFILES_TO_ROM_ERROR);
			}
			return Convert.ToBoolean(true);
		  }
	  }

	  private void n(a parama, bool paramBoolean)
	  {
		  c_Conflict.a(new aAnonymousInnerClass17(this, paramBoolean, parama));
	  }

	  private class aAnonymousInnerClass17 : a<bool>
	  {
		  private readonly b outerInstance;

		  public aAnonymousInnerClass17(b outerInstance, bool paramBoolean, sws.p2AppManager.b.a parama) : base(outerInstance, paramBoolean, parama)
		  {
			  this.outerInstance = outerInstance;
		  }

		  protected internal bool? a()
		  {
			try
			{
			  if (this.a)
			  {
				b.a(this.c_Conflict, b.a(this.c_Conflict));
			  }
			  b.j(this.c_Conflict);
			  b.a(this.c_Conflict, this.b.a.DeviceAtion, (double[][])null, p2Enumerations.p2AppManagerStatus.NO_ERROR);
			}
			catch (p2AppManagerException p2AppManagerException)
			{
			  b.v().error(p2AppManagerException.Message);
			  b.a(this.c_Conflict, this.b.a.DeviceAtion, (double[][])null, p2Enumerations.p2AppManagerStatus.getAppManagerStatusByCode(p2AppManagerException.ErrorCode));
			}
			catch (Exception exception)
			{
			  b.v().error(exception.Message);
			  b.a(this.c_Conflict, this.b.a.DeviceAtion, (double[][])null, p2Enumerations.p2AppManagerStatus.READING_PROFILES_FROM_ROM_ERROR);
			}
			return Convert.ToBoolean(true);
		  }
	  }

	  private void o(a parama, bool paramBoolean)
	  {
		  c_Conflict.a(new aAnonymousInnerClass18(this, paramBoolean, parama));
	  }

	  private class aAnonymousInnerClass18 : a<bool>
	  {
		  private readonly b outerInstance;

		  public aAnonymousInnerClass18(b outerInstance, bool paramBoolean, sws.p2AppManager.b.a parama) : base(outerInstance, paramBoolean, parama)
		  {
			  this.outerInstance = outerInstance;
		  }

		  protected internal bool? a()
		  {
			try
			{
			  if (this.a)
			  {
				b.a(this.c_Conflict, b.a(this.c_Conflict));
			  }
			  string str1 = b.b(this.c_Conflict, b.k(this.c_Conflict));
			  if (b.l(this.c_Conflict).Equals(str1 + Path.DirectorySeparatorChar + b.k(this.c_Conflict)))
			  {
				b.b(this.c_Conflict, false);
			  }
			  else
			  {
				b.c(this.c_Conflict, str1 + Path.DirectorySeparatorChar + b.k(this.c_Conflict));
				b.b(this.c_Conflict, true);
			  }
			  b.d(this.c_Conflict, str1);
			  string str2 = p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.CONFIG_SAMPLE_PROFILE_PATH_TEMPLATE), new object[] {b.b(this.c_Conflict), str1 + Path.DirectorySeparatorChar + "two_points_corr"});
			  if (p2Enumerations.p2AppManagerState.selfCorr_Run == this.b.a && !p2AppManagerUtils.exist(str2))
			  {
				throw new p2AppManagerException("Failed to find correction folder   ", p2Enumerations.p2AppManagerStatus.TWO_POINTS_CORR_CALIB_FOLDER_ERROR.NumVal);
			  }
			  b.c(this.c_Conflict, true);
			  if (b.m(this.c_Conflict))
			  {
				File file = new File(p2AppManagerUtils.formatString(p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.CONFIG_SAMPLE_PROFILE_FILES_PATH_TEMPLATE), new object[] {b.b(this.c_Conflict), str1 + Path.DirectorySeparatorChar + "two_points_corr", "corr.cal"}), new object[0]));
				if (file.exists() && !b.k(this.c_Conflict).Equals("two_points_corr"))
				{
				  string[] arrayOfString = p2AppManagerUtils.readStringfile(p2AppManagerUtils.formatString(p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.CONFIG_SAMPLE_PROFILE_FILES_PATH_TEMPLATE), new object[] {b.b(this.c_Conflict), str1 + Path.DirectorySeparatorChar + "two_points_corr", "corr.cal"}), new object[0]));
				  double[] arrayOfDouble1 = new double[arrayOfString.Length];
				  for (sbyte b2 = 0; b2 < arrayOfString.Length; b2++)
				  {
					arrayOfDouble1[b2] = double.Parse(arrayOfString[b2]);
				  }
				  p2AppManagerUtils.writeFileOfArray(arrayOfDouble1, p2AppManagerUtils.formatString(p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.CONFIG_SAMPLE_PROFILE_FILES_PATH_TEMPLATE), new object[] {b.b(this.c_Conflict), b.l(this.c_Conflict), "corr.cal"}), new object[0]), "\n");
				}
				b.v().info("loading sample folder started");
				b.a(this.c_Conflict, b.c(this.c_Conflict), b.n(this.c_Conflict), b.b(this.c_Conflict), b.l(this.c_Conflict));
				b.v().info("loading sample folder finished");
				b.d(this.c_Conflict, true);
			  }
			  if (b.o(this.c_Conflict))
			  {
				b.v().info("writing t reg file started");
				try
				{
				  b.c(this.c_Conflict).a(b.n(this.c_Conflict).c());
				}
				catch (a)
				{
				  throw new p2AppManagerException("Failed to setASICRegisters   ", p2Enumerations.p2AppManagerStatus.ASIC_REGISTER_WRITING_ERROR.NumVal);
				}
				b.v().info("writing t reg file finished");
			  }
			  if (b.p(this.c_Conflict))
			  {
				b.v().info("writing optical settings started");
				try
				{
				  b.b(this.c_Conflict, b.q(this.c_Conflict), p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.OPTICAL_SETTINGS_FILE_PATH), new object[] {b.b(this.c_Conflict)}), this.b);
				}
				catch (Exception exception)
				{
				  throw new p2AppManagerException(exception.Message, p2Enumerations.p2AppManagerStatus.GAIN_OPTIONS_ERROR.NumVal);
				}
				int i = 0;
				try
				{
				  i = (int)b.c(this.c_Conflict).b(i.fy.a(), a.k.fy.a(), a.j.fy.a());
				}
				catch (a)
				{
				  throw new p2AppManagerException("Failed to readASICRegisters   ", p2Enumerations.p2AppManagerStatus.ASIC_REGISTER_READING_ERROR.NumVal);
				}
				double d = Math.Pow(2.0D, i) * 5000.0D * this.b.p * this.b.q;
				b.n(this.c_Conflict).a(d);
				b.v().info("Current Range:" + this.b.o);
				b.v().info("PGA1: " + this.b.p);
				b.v().info("PGA2: " + this.b.q);
				b.v().info("Param.conf[I_adc_gain] = " + b.n(this.c_Conflict).b()[9]);
				b.v().info("writing optical settings finished");
			  }
			  b.a a1 = b.b(this.c_Conflict, b.a(this.c_Conflict), this.b);
			  Future future = null;
			  int[][] arrayOfInt = new int[b.r(this.c_Conflict).length][];
			  for (sbyte b1 = 0; b1 < arrayOfInt.Length; b1++)
			  {
				arrayOfInt[b1] = new int[b.r(this.c_Conflict)[b1].length];
				for (sbyte b2 = 0; b2 < arrayOfInt[b1].Length; b2++)
				{
				  arrayOfInt[b1][b2] = (int)b.r(this.c_Conflict)[b1][b2];
				}
			  }
			  if (p2Enumerations.p2AppManagerState.wavelengthCalibration_Run == this.b.a)
			  {
				future = b.a(this.c_Conflict, b.c(this.c_Conflict), arrayOfInt, a1, b.n(this.c_Conflict), b.s(this.c_Conflict));
			  }
			  else
			  {
				future = b.a(this.c_Conflict, b.c(this.c_Conflict), arrayOfInt, a1, b.n(this.c_Conflict), b.t(this.c_Conflict));
			  }
			  double[][] arrayOfDouble = (double[][])null;
			  try
			  {
				b.v().info("begin DSP process...");
				arrayOfDouble = (double[][])future.get();
				b.v().info("end DSP process.");
			  }
			  catch (InterruptedException interruptedException)
			  {
				b.v().error(interruptedException.Message);
				throw new p2AppManagerException("Failed to get thread data  ", p2Enumerations.p2AppManagerStatus.UNKNOWN_ERROR.NumVal);
			  }
			  catch (ExecutionException executionException)
			  {
				b.v().error(executionException.Message);
				if (executionException.InnerException is p2AppManagerException)
				{
				  throw (p2AppManagerException)executionException.InnerException;
				}
				throw new p2AppManagerException("Failed to get thread data  ", p2Enumerations.p2AppManagerStatus.UNKNOWN_ERROR.NumVal);
			  }
			  if (arrayOfDouble == null)
			  {
				throw new p2AppManagerException("No valid result back for this p2Sample : " + b.b(this.c_Conflict) + " run.", p2Enumerations.p2AppManagerStatus.NO_OF_SCANS_DSP_ERROR.NumVal);
			  }
			  if (p2Enumerations.p2AppManagerState.wavelengthCalibration_Run == this.b.a)
			  {
				double[] arrayOfDouble1 = null;
				arrayOfDouble1 = p2AppManagerUtils.loadRawDataFile(p2Constants.getPath(p2Constants.STANDARD_CALIBRATORS_FOLDER_PATH) + Path.DirectorySeparatorChar + this.b.Y + ".txt");
				if (arrayOfDouble1 == null)
				{
				  throw new p2AppManagerException("Failed to load standard calibrator file ", p2Enumerations.p2AppManagerStatus.WHITE_FILE_NOT_EXIST_ERROR.NumVal);
				}
				List<object> arrayList = new List<object>();
				for (b2 = 0; b2 < arrayOfDouble1.Length; b2++)
				{
				  if (arrayOfDouble1[b2] < b.n(this.c_Conflict).b()[24] * 1000.0D && arrayOfDouble1[b2] > b.n(this.c_Conflict).b()[23] * 1000.0D)
				  {
					arrayList.Add(Convert.ToDouble(arrayOfDouble1[b2]));
				  }
				}
				if (arrayList.Count != 0)
				{
				  arrayOfDouble1 = new double[arrayList.Count];
				  for (b2 = 0; b2 < arrayList.Count; b2++)
				  {
					arrayOfDouble1[b2] = ((double?)arrayList[b2]).Value;
				  }
				}
				else
				{
				  throw new p2AppManagerException("Calibrator has no wavelengths in the detector range ", p2Enumerations.p2AppManagerStatus.WAVELENGTH_CALIBRATION_ERROR.NumVal);
				}
				try
				{
				  if ((int)b.n(this.c_Conflict).b()[56] != 1)
				  {
					string[] arrayOfString = p2AppManagerUtils.readStringfile(p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.CONFIG_SAMPLE_PROFILE_FILES_PATH_TEMPLATE), new object[] {b.b(this.c_Conflict), str1 + Path.DirectorySeparatorChar + b.k(this.c_Conflict), "wavelength_corr.cal"}));
					double[] arrayOfDouble2 = new double[arrayOfString.Length];
					for (sbyte b3 = 0; b3 < arrayOfString.Length; b3++)
					{
					  arrayOfDouble2[b3] = double.Parse(arrayOfString[b3]);
					}
					double[][] arrayOfDouble3 = p2SpectroDSP.a().a(arrayOfDouble[2], arrayOfDouble[3], arrayOfDouble1, 0, (int)b.n(this.c_Conflict).b()[54]);
					double[] arrayOfDouble4 = new double[arrayOfDouble3[0].Length];
					for (sbyte b4 = 0; b4 < arrayOfDouble3[0].Length; b4++)
					{
					  arrayOfDouble4[b4] = arrayOfDouble2[b4] * arrayOfDouble3[0][0];
					}
					arrayOfDouble4[arrayOfDouble4.Length - 1] = arrayOfDouble2[arrayOfDouble2.Length - 1] + arrayOfDouble3[0][1];
					p2AppManagerUtils.writeFileOfArray(arrayOfDouble4, p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.CONFIG_SAMPLE_PROFILE_FILES_PATH_TEMPLATE), new object[] {b.b(this.c_Conflict), str1 + Path.DirectorySeparatorChar + b.k(this.c_Conflict), "wavelength_corr.cal"}), "\n");
					arrayOfDouble4 = null;
				  }
				}
				catch (a)
				{
				  a a2;
				  throw new p2AppManagerException("Error while make DSP data wavelength calibration ", p2Enumerations.p2AppManagerStatus.WAVELENGTH_CALIBRATION_ERROR.NumVal);
				}
				arrayOfDouble1 = null;
				b.c(this.c_Conflict, "");
			  }
			  b.a(this.c_Conflict, this.b.a.DeviceAtion, arrayOfDouble, p2Enumerations.p2AppManagerStatus.NO_ERROR);
			}
			catch (p2AppManagerException p2AppManagerException)
			{
			  b.v().error(p2AppManagerException.Message);
			  b.a(this.c_Conflict, this.b.a.DeviceAtion, (double[][])null, p2Enumerations.p2AppManagerStatus.getAppManagerStatusByCode(p2AppManagerException.ErrorCode));
			}
			return Convert.ToBoolean(true);
		  }
	  }

	  private void p(a parama, bool paramBoolean)
	  {
		  c_Conflict.a(new aAnonymousInnerClass19(this, paramBoolean, parama));
	  }

	  private class aAnonymousInnerClass19 : a<bool>
	  {
		  private readonly b outerInstance;

		  public aAnonymousInnerClass19(b outerInstance, bool paramBoolean, sws.p2AppManager.b.a parama) : base(outerInstance, paramBoolean, parama)
		  {
			  this.outerInstance = outerInstance;
		  }

		  protected internal bool? a()
		  {
			try
			{
			  if (this.a)
			  {
				b.a(this.c_Conflict, b.a(this.c_Conflict));
			  }
			  string str1 = b.b(this.c_Conflict, b.k(this.c_Conflict));
			  if (b.l(this.c_Conflict).Equals(str1 + Path.DirectorySeparatorChar + b.k(this.c_Conflict)))
			  {
				b.b(this.c_Conflict, false);
			  }
			  else
			  {
				b.c(this.c_Conflict, str1 + Path.DirectorySeparatorChar + b.k(this.c_Conflict));
				b.b(this.c_Conflict, true);
			  }
			  b.d(this.c_Conflict, str1);
			  string str2 = p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.CONFIG_SAMPLE_PROFILE_PATH_TEMPLATE), new object[] {b.b(this.c_Conflict), str1 + Path.DirectorySeparatorChar + "two_points_corr"});
			  if (p2Enumerations.p2AppManagerState.selfCorr_Run == this.b.a && !p2AppManagerUtils.exist(str2))
			  {
				throw new p2AppManagerException("Failed to find correction folder   ", p2Enumerations.p2AppManagerStatus.TWO_POINTS_CORR_CALIB_FOLDER_ERROR.NumVal);
			  }
			  b.c(this.c_Conflict, true);
			  if (b.m(this.c_Conflict))
			  {
				File file = new File(p2AppManagerUtils.formatString(p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.CONFIG_SAMPLE_PROFILE_FILES_PATH_TEMPLATE), new object[] {b.b(this.c_Conflict), str1 + Path.DirectorySeparatorChar + "two_points_corr", "corr.cal"}), new object[0]));
				if (file.exists() && !b.k(this.c_Conflict).Equals("two_points_corr"))
				{
				  string[] arrayOfString = p2AppManagerUtils.readStringfile(p2AppManagerUtils.formatString(p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.CONFIG_SAMPLE_PROFILE_FILES_PATH_TEMPLATE), new object[] {b.b(this.c_Conflict), str1 + Path.DirectorySeparatorChar + "two_points_corr", "corr.cal"}), new object[0]));
				  double[] arrayOfDouble1 = new double[arrayOfString.Length];
				  for (sbyte b1 = 0; b1 < arrayOfString.Length; b1++)
				  {
					arrayOfDouble1[b1] = double.Parse(arrayOfString[b1]);
				  }
				  p2AppManagerUtils.writeFileOfArray(arrayOfDouble1, p2AppManagerUtils.formatString(p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.CONFIG_SAMPLE_PROFILE_FILES_PATH_TEMPLATE), new object[] {b.b(this.c_Conflict), b.l(this.c_Conflict), "corr.cal"}), new object[0]), "\n");
				}
				b.v().info("loading sample folder started");
				b.a(this.c_Conflict, b.c(this.c_Conflict), b.n(this.c_Conflict), b.b(this.c_Conflict), b.l(this.c_Conflict));
				b.v().info("loading sample folder finished");
				b.d(this.c_Conflict, true);
			  }
			  if (b.o(this.c_Conflict))
			  {
				b.v().info("writing t reg file started");
				try
				{
				  b.c(this.c_Conflict).a(b.n(this.c_Conflict).c());
				}
				catch (a)
				{
				  throw new p2AppManagerException("Failed to setASICRegisters   ", p2Enumerations.p2AppManagerStatus.ASIC_REGISTER_WRITING_ERROR.NumVal);
				}
				b.v().info("writing t reg file finished");
			  }
			  if (b.p(this.c_Conflict))
			  {
				b.v().info("writing optical settings started");
				try
				{
				  b.b(this.c_Conflict, b.q(this.c_Conflict), p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.OPTICAL_SETTINGS_FILE_PATH), new object[] {b.b(this.c_Conflict)}), this.b);
				}
				catch (Exception exception)
				{
				  throw new p2AppManagerException(exception.Message, p2Enumerations.p2AppManagerStatus.GAIN_OPTIONS_ERROR.NumVal);
				}
				int i = 0;
				try
				{
				  i = (int)b.c(this.c_Conflict).b(i.fy.a(), a.k.fy.a(), a.j.fy.a());
				}
				catch (a)
				{
				  throw new p2AppManagerException("Failed to readASICRegisters   ", p2Enumerations.p2AppManagerStatus.ASIC_REGISTER_READING_ERROR.NumVal);
				}
				double d = Math.Pow(2.0D, i) * 5000.0D * this.b.p * this.b.q;
				b.n(this.c_Conflict).a(d);
				b.v().info("Current Range:" + this.b.o);
				b.v().info("PGA1: " + this.b.p);
				b.v().info("PGA2: " + this.b.q);
				b.v().info("Param.conf[I_adc_gain] = " + b.n(this.c_Conflict).b()[9]);
				b.v().info("writing optical settings finished");
			  }
			  bool bool1 = true;
			  if (b.n(this.c_Conflict).b()[47] != 0.0D)
			  {
				bool1 = false;
			  }
			  bool bool2 = false;
			  try
			  {
				bool2 = b.c(this.c_Conflict).a(bool1);
			  }
			  catch (a)
			  {
				throw new p2AppManagerException("Failed to read act register ", p2Enumerations.p2AppManagerStatus.ACTUATION_SETTING_ERROR.NumVal);
			  }
			  if (!bool2)
			  {
				try
				{
				  b.c(this.c_Conflict).a(true, bool1, (int)b.a(this.c_Conflict).b()[48]);
				  b.v().info("sleep for " + b.a(this.c_Conflict).b()[12] + " after starting actuation started");
				  try
				  {
					Thread.Sleep((long)b.a(this.c_Conflict).b()[12]);
				  }
				  catch (InterruptedException interruptedException)
				  {
					b.v().error(interruptedException.Message);
				  }
				  b.v().info("sleep for " + b.a(this.c_Conflict).b()[12] + " after starting actuation finished");
				}
				catch (a)
				{
				  throw new p2AppManagerException("Failed to start actuation ", p2Enumerations.p2AppManagerStatus.DEVICE_IS_TURNED_OFF_ERROR.NumVal);
				}
			  }
			  b.a a1 = b.b(this.c_Conflict, b.a(this.c_Conflict), this.b);
			  double[][] arrayOfDouble = b.l(this.c_Conflict, a1, b.a(this.c_Conflict));
			  if (arrayOfDouble == null)
			  {
				throw new p2AppManagerException("No valid result back for this p2Sample : " + b.b(this.c_Conflict) + " run.", p2Enumerations.p2AppManagerStatus.NO_OF_SCANS_DSP_ERROR.NumVal);
			  }
			  if (p2Enumerations.p2AppManagerState.wavelengthCalibration_Run == this.b.a)
			  {
				double[] arrayOfDouble1 = null;
				arrayOfDouble1 = p2AppManagerUtils.loadRawDataFile(p2Constants.getPath(p2Constants.STANDARD_CALIBRATORS_FOLDER_PATH) + Path.DirectorySeparatorChar + this.b.Y + ".txt");
				if (arrayOfDouble1 == null)
				{
				  throw new p2AppManagerException("Failed to load standard calibrator file ", p2Enumerations.p2AppManagerStatus.WHITE_FILE_NOT_EXIST_ERROR.NumVal);
				}
				List<object> arrayList = new List<object>();
				for (b1 = 0; b1 < arrayOfDouble1.Length; b1++)
				{
				  if (arrayOfDouble1[b1] < b.n(this.c_Conflict).b()[24] * 1000.0D && arrayOfDouble1[b1] > b.n(this.c_Conflict).b()[23] * 1000.0D)
				  {
					arrayList.Add(Convert.ToDouble(arrayOfDouble1[b1]));
				  }
				}
				if (arrayList.Count != 0)
				{
				  arrayOfDouble1 = new double[arrayList.Count];
				  for (b1 = 0; b1 < arrayList.Count; b1++)
				  {
					arrayOfDouble1[b1] = ((double?)arrayList[b1]).Value;
				  }
				}
				else
				{
				  throw new p2AppManagerException("Calibrator has no wavelengths in the detector range ", p2Enumerations.p2AppManagerStatus.WAVELENGTH_CALIBRATION_ERROR.NumVal);
				}
				try
				{
				  if ((int)b.n(this.c_Conflict).b()[56] != 1)
				  {
					string[] arrayOfString = p2AppManagerUtils.readStringfile(p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.CONFIG_SAMPLE_PROFILE_FILES_PATH_TEMPLATE), new object[] {b.b(this.c_Conflict), str1 + Path.DirectorySeparatorChar + b.k(this.c_Conflict), "wavelength_corr.cal"}));
					double[] arrayOfDouble2 = new double[arrayOfString.Length];
					for (sbyte b2 = 0; b2 < arrayOfString.Length; b2++)
					{
					  arrayOfDouble2[b2] = double.Parse(arrayOfString[b2]);
					}
					double[][] arrayOfDouble3 = p2SpectroDSP.a().a(arrayOfDouble[2], arrayOfDouble[3], arrayOfDouble1, 0, (int)b.n(this.c_Conflict).b()[56]);
					double[] arrayOfDouble4 = new double[arrayOfDouble3[0].Length];
					for (sbyte b3 = 0; b3 < arrayOfDouble3[0].Length; b3++)
					{
					  arrayOfDouble4[b3] = arrayOfDouble2[b3] * arrayOfDouble3[0][0];
					}
					arrayOfDouble4[arrayOfDouble4.Length - 1] = arrayOfDouble2[arrayOfDouble2.Length - 1] + arrayOfDouble3[0][1];
					p2AppManagerUtils.writeFileOfArray(arrayOfDouble4, p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.CONFIG_SAMPLE_PROFILE_FILES_PATH_TEMPLATE), new object[] {b.b(this.c_Conflict), str1 + Path.DirectorySeparatorChar + b.k(this.c_Conflict), "wavelength_corr.cal"}), "\n");
					arrayOfDouble4 = null;
				  }
				}
				catch (a)
				{
				  a a2;
				  throw new p2AppManagerException("Error while make DSP data wavelength calibration ", p2Enumerations.p2AppManagerStatus.WAVELENGTH_CALIBRATION_ERROR.NumVal);
				}
				arrayOfDouble1 = null;
				b.c(this.c_Conflict, "");
			  }
			  b.a(this.c_Conflict, this.b.a.DeviceAtion, arrayOfDouble, p2Enumerations.p2AppManagerStatus.NO_ERROR);
			}
			catch (p2AppManagerException p2AppManagerException)
			{
			  b.v().error(p2AppManagerException.Message);
			  b.a(this.c_Conflict, this.b.a.DeviceAtion, (double[][])null, p2Enumerations.p2AppManagerStatus.getAppManagerStatusByCode(p2AppManagerException.ErrorCode));
			}
			return Convert.ToBoolean(true);
		  }
	  }

//JAVA TO C# CONVERTER NOTE: Members cannot have the same name as their enclosing type:
	  private void b_Conflict(a parama)
	  {
		  c_Conflict.a(new aAnonymousInnerClass20(this, parama));
	  }

	  private class aAnonymousInnerClass20 : a<bool>
	  {
		  private readonly b outerInstance;

		  public aAnonymousInnerClass20(b outerInstance, sws.p2AppManager.b.a parama) : base(outerInstance, parama)
		  {
			  this.outerInstance = outerInstance;
		  }

		  protected internal bool? a()
		  {
			try
			{
			  string str = b.b(this.b, b.k(this.b));
			  if (b.l(this.b).Equals(str + Path.DirectorySeparatorChar + b.k(this.b)))
			  {
				b.c(this.b, false);
			  }
			  else
			  {
				b.c(this.b, str + Path.DirectorySeparatorChar + b.k(this.b));
				b.c(this.b, true);
			  }
			  b.d(this.b, str);
			  if (b.m(this.b))
			  {
				File file = new File(p2AppManagerUtils.formatString(p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.CONFIG_SAMPLE_PROFILE_FILES_PATH_TEMPLATE), new object[] {b.b(this.b), str + Path.DirectorySeparatorChar + "two_points_corr", "corr.cal"}), new object[0]));
				if (file.exists() && !b.k(this.b).Equals("two_points_corr"))
				{
				  string[] arrayOfString = p2AppManagerUtils.readStringfile(p2AppManagerUtils.formatString(p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.CONFIG_SAMPLE_PROFILE_FILES_PATH_TEMPLATE), new object[] {b.b(this.b), str + Path.DirectorySeparatorChar + "two_points_corr", "corr.cal"}), new object[0]));
				  double[] arrayOfDouble = new double[arrayOfString.Length];
				  for (sbyte b2 = 0; b2 < arrayOfString.Length; b2++)
				  {
					arrayOfDouble[b2] = double.Parse(arrayOfString[b2]);
				  }
				  p2AppManagerUtils.writeFileOfArray(arrayOfDouble, p2AppManagerUtils.formatString(p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.CONFIG_SAMPLE_PROFILE_FILES_PATH_TEMPLATE), new object[] {b.b(this.b), b.l(this.b), "corr.cal"}), new object[0]), "\n");
				}
				b.v().info("loading sample folder started");
				b.a(this.b, b.c(this.b), b.n(this.b), b.b(this.b), b.l(this.b));
				b.v().info("loading sample folder finished");
			  }
			  double d1 = b.n(this.b).b()[19];
			  double d2 = b.n(this.b).b()[22];
			  b.n(this.b).b()[19] = this.a.af;
			  b.n(this.b).b()[22] = b.n(this.b).b()[22] * this.a.ag;
			  double[] arrayOfDouble1 = new double[b.u(this.b)[1].length];
			  for (sbyte b1 = 0; b1 < b.u(this.b)[1].length; b1++)
			  {
				arrayOfDouble1[b1] = b.u(this.b)[1][b1] / 1000.0D;
			  }
			  double[][] arrayOfDouble2 = (double[][])null;
			  try
			  {
				arrayOfDouble2 = p2SpectroDSP.a().a(b.n(this.b).b(), b.u(this.b)[0], arrayOfDouble1, this.a.d, b.n(this.b).i());
			  }
			  catch (a)
			  {
				throw new p2AppManagerException("Error while make DSP data update FFT settings", p2Enumerations.p2AppManagerStatus.DSP_UPDATE_FFT_SETTINGS_ERROR.NumVal);
			  }
			  if (arrayOfDouble2 == null || arrayOfDouble2[0].Length == 0 || arrayOfDouble2[1].Length == 0)
			  {
				throw new p2AppManagerException("Data returned from DSP is empty    ", p2Enumerations.p2AppManagerStatus.DSP_UPDATE_FFT_SETTINGS_ERROR.NumVal);
			  }
			  double[][] arrayOfDouble3 = new double[5][];
			  arrayOfDouble3[0] = new double[b.u(this.b)[0].length];
			  Array.Copy(b.u(this.b)[0], 0, arrayOfDouble3[0], 0, b.u(this.b)[0].length);
			  arrayOfDouble3[1] = new double[b.u(this.b)[1].length];
			  Array.Copy(b.u(this.b)[1], 0, arrayOfDouble3[1], 0, b.u(this.b)[1].length);
			  arrayOfDouble3[4] = new double[b.u(this.b)[4].length];
			  Array.Copy(b.u(this.b)[4], 0, arrayOfDouble3[4], 0, b.u(this.b)[4].length);
			  arrayOfDouble3[2] = new double[arrayOfDouble2[0].Length];
			  Array.Copy(arrayOfDouble2[0], 0, arrayOfDouble3[2], 0, arrayOfDouble2[0].Length);
			  arrayOfDouble3[3] = new double[arrayOfDouble2[1].Length];
			  Array.Copy(arrayOfDouble2[1], 0, arrayOfDouble3[3], 0, arrayOfDouble2[1].Length);
			  b.a(this.b, arrayOfDouble3);
			  arrayOfDouble2 = (double[][])null;
			  double[] arrayOfDouble4 = arrayOfDouble3[0];
			  double[] arrayOfDouble5 = arrayOfDouble3[2];
			  double[] arrayOfDouble6 = arrayOfDouble3[3];
			  double[] arrayOfDouble7 = arrayOfDouble3[1];
			  bool @bool = b.b(this.b, arrayOfDouble7);
			  b.a(this.b, this.a, @bool, b.n(this.b), arrayOfDouble4, arrayOfDouble7, arrayOfDouble5, arrayOfDouble6);
			  b.a(this.b, b.n(this.b).i(), this.a, arrayOfDouble3, (double[][])null);
			  b.n(this.b).b()[19] = d1;
			  b.n(this.b).b()[22] = d2;
			  b.a(this.b, this.a.a.DeviceAtion, arrayOfDouble3, p2Enumerations.p2AppManagerStatus.NO_ERROR);
			}
			catch (p2AppManagerException p2AppManagerException)
			{
			  b.v().error(p2AppManagerException.Message);
			  b.a(this.b, this.a.a.DeviceAtion, (double[][])null, p2Enumerations.p2AppManagerStatus.getAppManagerStatusByCode(p2AppManagerException.ErrorCode));
			}
			return Convert.ToBoolean(true);
		  }
	  }

	  private void c(a parama)
	  {
		  c_Conflict.a(new aAnonymousInnerClass21(this, parama));
	  }

	  private class aAnonymousInnerClass21 : a<bool>
	  {
		  private readonly b outerInstance;

		  public aAnonymousInnerClass21(b outerInstance, sws.p2AppManager.b.a parama) : base(outerInstance, parama)
		  {
			  this.outerInstance = outerInstance;
		  }

		  protected internal bool? a()
		  {
			try
			{
			  string str = b.b(this.b, b.k(this.b));
			  if (b.l(this.b).Equals(str + Path.DirectorySeparatorChar + b.k(this.b)))
			  {
				b.c(this.b, false);
			  }
			  else
			  {
				b.c(this.b, str + Path.DirectorySeparatorChar + b.k(this.b));
				b.c(this.b, true);
			  }
			  b.d(this.b, str);
			  if (b.m(this.b))
			  {
				File file = new File(p2AppManagerUtils.formatString(p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.CONFIG_SAMPLE_PROFILE_FILES_PATH_TEMPLATE), new object[] {b.b(this.b), str + Path.DirectorySeparatorChar + "two_points_corr", "corr.cal"}), new object[0]));
				if (file.exists() && !b.k(this.b).Equals("two_points_corr"))
				{
				  string[] arrayOfString = p2AppManagerUtils.readStringfile(p2AppManagerUtils.formatString(p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.CONFIG_SAMPLE_PROFILE_FILES_PATH_TEMPLATE), new object[] {b.b(this.b), str + Path.DirectorySeparatorChar + "two_points_corr", "corr.cal"}), new object[0]));
				  double[] arrayOfDouble = new double[arrayOfString.Length];
				  for (sbyte b1 = 0; b1 < arrayOfString.Length; b1++)
				  {
					arrayOfDouble[b1] = double.Parse(arrayOfString[b1]);
				  }
				  p2AppManagerUtils.writeFileOfArray(arrayOfDouble, p2AppManagerUtils.formatString(p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.CONFIG_SAMPLE_PROFILE_FILES_PATH_TEMPLATE), new object[] {b.b(this.b), b.l(this.b), "corr.cal"}), new object[0]), "\n");
				}
				b.v().info("loading sample folder started");
				b.a(this.b, b.c(this.b), b.n(this.b), b.b(this.b), b.l(this.b));
				b.v().info("loading sample folder finished");
			  }
			  double d1 = b.n(this.b).b()[19];
			  double d2 = b.n(this.b).b()[22];
			  b.n(this.b).b()[19] = this.a.af;
			  b.n(this.b).b()[22] = b.n(this.b).b()[22] * this.a.ag;
			  double[][] arrayOfDouble1 = (double[][])null;
			  try
			  {
				arrayOfDouble1 = p2SpectroDSP.a().a(b.n(this.b).b(), b.t(this.b)[0], b.t(this.b)[1], this.a.d, b.n(this.b).i());
			  }
			  catch (a)
			  {
				throw new p2AppManagerException("Error while make DSP data update FFT settings", p2Enumerations.p2AppManagerStatus.DSP_UPDATE_FFT_SETTINGS_ERROR.NumVal);
			  }
			  if (arrayOfDouble1 == null || arrayOfDouble1[0].Length == 0 || arrayOfDouble1[1].Length == 0)
			  {
				throw new p2AppManagerException("Data returned from DSP is empty    ", p2Enumerations.p2AppManagerStatus.DSP_UPDATE_FFT_SETTINGS_ERROR.NumVal);
			  }
			  double[][] arrayOfDouble2 = new double[5][];
			  arrayOfDouble2[0] = new double[b.t(this.b)[0].length];
			  Array.Copy(b.t(this.b)[0], 0, arrayOfDouble2[0], 0, b.t(this.b)[0].length);
			  arrayOfDouble2[1] = new double[b.t(this.b)[1].length];
			  Array.Copy(b.t(this.b)[1], 0, arrayOfDouble2[1], 0, b.t(this.b)[1].length);
			  arrayOfDouble2[4] = new double[b.t(this.b)[4].length];
			  Array.Copy(b.t(this.b)[4], 0, arrayOfDouble2[4], 0, b.t(this.b)[4].length);
			  arrayOfDouble2[2] = new double[arrayOfDouble1[0].Length];
			  Array.Copy(arrayOfDouble1[0], 0, arrayOfDouble2[2], 0, arrayOfDouble1[0].Length);
			  arrayOfDouble2[3] = new double[arrayOfDouble1[1].Length];
			  Array.Copy(arrayOfDouble1[1], 0, arrayOfDouble2[3], 0, arrayOfDouble1[1].Length);
			  arrayOfDouble1 = (double[][])null;
			  double[] arrayOfDouble3 = arrayOfDouble2[0];
			  double[] arrayOfDouble4 = arrayOfDouble2[2];
			  double[] arrayOfDouble5 = arrayOfDouble2[3];
			  double[] arrayOfDouble6 = arrayOfDouble2[1];
			  bool @bool = b.b(this.b, arrayOfDouble6);
			  b.a(this.b, this.a, @bool, b.n(this.b), arrayOfDouble3, arrayOfDouble6, arrayOfDouble4, arrayOfDouble5);
			  try
			  {
				arrayOfDouble1 = p2SpectroDSP.a().a(b.n(this.b).b(), b.v(this.b)[0], b.v(this.b)[1], this.a.d, b.n(this.b).i());
			  }
			  catch (a)
			  {
				throw new p2AppManagerException("Error while make DSP data update FFT settings", p2Enumerations.p2AppManagerStatus.DSP_UPDATE_FFT_SETTINGS_ERROR.NumVal);
			  }
			  if (arrayOfDouble1 == null || arrayOfDouble1[0].Length == 0 || arrayOfDouble1[1].Length == 0)
			  {
				throw new p2AppManagerException("Data returned from DSP is empty    ", p2Enumerations.p2AppManagerStatus.DSP_UPDATE_FFT_SETTINGS_ERROR.NumVal);
			  }
			  double[][] arrayOfDouble7 = new double[5][];
			  arrayOfDouble7[0] = new double[b.v(this.b)[0].length];
			  Array.Copy(b.v(this.b)[0], 0, arrayOfDouble7[0], 0, b.v(this.b)[0].length);
			  arrayOfDouble7[1] = new double[b.v(this.b)[1].length];
			  Array.Copy(b.v(this.b)[1], 0, arrayOfDouble7[1], 0, b.v(this.b)[1].length);
			  arrayOfDouble7[4] = new double[b.v(this.b)[4].length];
			  Array.Copy(b.v(this.b)[4], 0, arrayOfDouble7[4], 0, b.v(this.b)[4].length);
			  arrayOfDouble7[2] = new double[arrayOfDouble1[0].Length];
			  Array.Copy(arrayOfDouble1[0], 0, arrayOfDouble7[2], 0, arrayOfDouble1[0].Length);
			  arrayOfDouble7[3] = new double[arrayOfDouble1[1].Length];
			  Array.Copy(arrayOfDouble1[1], 0, arrayOfDouble7[3], 0, arrayOfDouble1[1].Length);
			  arrayOfDouble1 = (double[][])null;
			  arrayOfDouble3 = arrayOfDouble7[0];
			  arrayOfDouble4 = arrayOfDouble7[2];
			  arrayOfDouble5 = arrayOfDouble7[3];
			  arrayOfDouble6 = arrayOfDouble7[1];
			  @bool = b.b(this.b, arrayOfDouble6);
			  b.a(this.b, this.a, @bool, b.n(this.b), arrayOfDouble3, arrayOfDouble6, arrayOfDouble4, arrayOfDouble5);
			  b.a(this.b, b.n(this.b).i(), this.a, arrayOfDouble7, arrayOfDouble2);
			  b.n(this.b).b()[19] = d1;
			  b.n(this.b).b()[22] = d2;
			  b.a(this.b, this.a.a.DeviceAtion, arrayOfDouble7, p2Enumerations.p2AppManagerStatus.NO_ERROR);
			}
			catch (p2AppManagerException p2AppManagerException)
			{
			  b.v().error(p2AppManagerException.Message);
			  b.a(this.b, this.a.a.DeviceAtion, (double[][])null, p2Enumerations.p2AppManagerStatus.getAppManagerStatusByCode(p2AppManagerException.ErrorCode));
			}
			return Convert.ToBoolean(true);
		  }
	  }

	  private void q(a parama, bool paramBoolean)
	  {
		  c_Conflict.a(new aAnonymousInnerClass22(this, paramBoolean, parama));
	  }

	  private class aAnonymousInnerClass22 : a<bool>
	  {
		  private readonly b outerInstance;

		  public aAnonymousInnerClass22(b outerInstance, bool paramBoolean, sws.p2AppManager.b.a parama) : base(outerInstance, paramBoolean, parama)
		  {
			  this.outerInstance = outerInstance;
		  }

		  protected internal bool? a()
		  {
			try
			{
			  if (this.a)
			  {
				b.a(this.c_Conflict, b.a(this.c_Conflict));
			  }
			  string str = b.b(this.c_Conflict, b.k(this.c_Conflict));
			  if (b.l(this.c_Conflict).Equals(str + Path.DirectorySeparatorChar + b.k(this.c_Conflict)))
			  {
				b.c(this.c_Conflict, false);
			  }
			  else
			  {
				b.c(this.c_Conflict, str + Path.DirectorySeparatorChar + b.k(this.c_Conflict));
				b.c(this.c_Conflict, true);
			  }
			  if (b.m(this.c_Conflict))
			  {
				b.v().info("loading sample folder started");
				b.a(this.c_Conflict, b.c(this.c_Conflict), b.n(this.c_Conflict), b.b(this.c_Conflict), b.l(this.c_Conflict));
				b.v().info("loading sample folder finished");
				b.b(this.c_Conflict, true);
				b.d(this.c_Conflict, true);
			  }
			  if (b.o(this.c_Conflict))
			  {
				b.v().info("writing t reg file started");
				try
				{
				  b.c(this.c_Conflict).a(b.n(this.c_Conflict).c());
				}
				catch (a)
				{
				  throw new p2AppManagerException("Failed to setASICRegisters   ", p2Enumerations.p2AppManagerStatus.ASIC_REGISTER_WRITING_ERROR.NumVal);
				}
				b.v().info("writing t reg file finished");
			  }
			  if (b.p(this.c_Conflict))
			  {
				b.v().info("writing optical settings started");
				try
				{
				  b.b(this.c_Conflict, b.q(this.c_Conflict), p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.OPTICAL_SETTINGS_FILE_PATH), new object[] {b.b(this.c_Conflict)}), this.b);
				}
				catch (Exception exception)
				{
				  throw new p2AppManagerException(exception.Message, p2Enumerations.p2AppManagerStatus.GAIN_OPTIONS_ERROR.NumVal);
				}
				int i = 0;
				try
				{
				  i = (int)b.c(this.c_Conflict).b(i.fy.a(), a.k.fy.a(), a.j.fy.a());
				}
				catch (a)
				{
				  throw new p2AppManagerException("Failed to readASICRegisters   ", p2Enumerations.p2AppManagerStatus.ASIC_REGISTER_READING_ERROR.NumVal);
				}
				double d = Math.Pow(2.0D, i) * 5000.0D * this.b.p * this.b.q;
				b.n(this.c_Conflict).a(d);
				b.v().info("Current Range:" + this.b.o);
				b.v().info("PGA1: " + this.b.p);
				b.v().info("PGA2: " + this.b.q);
				b.v().info("Param.conf[I_adc_gain] = " + b.n(this.c_Conflict).b()[9]);
				b.v().info("writing optical settings finished");
			  }
			  bool bool1 = true;
			  if (b.n(this.c_Conflict).b()[47] != 0.0D)
			  {
				bool1 = false;
			  }
			  bool bool2 = false;
			  if (bool1)
			  {
				try
				{
				  bool2 = b.c(this.c_Conflict).a(bool1);
				}
				catch (a)
				{
				  throw new p2AppManagerException("Failed to read act register ", p2Enumerations.p2AppManagerStatus.ACTUATION_SETTING_ERROR.NumVal);
				}
			  }
			  else
			  {
				bool2 = false;
				try
				{
				  b.c(this.c_Conflict).a(false, bool1, (int)b.a(this.c_Conflict).b()[48]);
				}
				catch (a)
				{
				  throw new p2AppManagerException("Failed to read act register ", p2Enumerations.p2AppManagerStatus.DEVICE_IS_TURNED_OFF_ERROR.NumVal);
				}
			  }
			  if (!bool2)
			  {
				try
				{
				  b.c(this.c_Conflict).a(true, bool1, (int)b.a(this.c_Conflict).b()[48]);
				  b.v().info("sleep for " + b.a(this.c_Conflict).b()[12] + " after starting actuation started");
				  try
				  {
					Thread.Sleep((long)b.a(this.c_Conflict).b()[12]);
				  }
				  catch (InterruptedException interruptedException)
				  {
					b.v().error(interruptedException.Message);
				  }
				  b.v().info("sleep for " + b.a(this.c_Conflict).b()[12] + " after starting actuation finished");
				}
				catch (a)
				{
				  throw new p2AppManagerException("Failed to start actuation ", p2Enumerations.p2AppManagerStatus.DEVICE_IS_TURNED_OFF_ERROR.NumVal);
				}
			  }
			  b.a a1 = b.b(this.c_Conflict, b.a(this.c_Conflict), this.b);
			  double[][] arrayOfDouble = b.m(this.c_Conflict, a1, b.a(this.c_Conflict));
			  if (arrayOfDouble == null)
			  {
				throw new p2AppManagerException("No valid result back for this p2Sample : " + b.b(this.c_Conflict) + " run.", p2Enumerations.p2AppManagerStatus.NO_OF_SCANS_DSP_ERROR.NumVal);
			  }
			  b.a(this.c_Conflict, this.b.a.DeviceAtion, arrayOfDouble, p2Enumerations.p2AppManagerStatus.NO_ERROR);
			}
			catch (p2AppManagerException p2AppManagerException)
			{
			  b.v().error(p2AppManagerException.Message);
			  b.a(this.c_Conflict, this.b.a.DeviceAtion, (double[][])null, p2Enumerations.p2AppManagerStatus.getAppManagerStatusByCode(p2AppManagerException.ErrorCode));
			}
			return Convert.ToBoolean(true);
		  }
	  }

	  private void r(a parama, bool paramBoolean)
	  {
		  c_Conflict.a(new aAnonymousInnerClass23(this, paramBoolean, parama));
	  }

	  private class aAnonymousInnerClass23 : a<bool>
	  {
		  private readonly b outerInstance;

		  public aAnonymousInnerClass23(b outerInstance, bool paramBoolean, sws.p2AppManager.b.a parama) : base(outerInstance, paramBoolean, parama)
		  {
			  this.outerInstance = outerInstance;
		  }

		  protected internal bool? a()
		  {
			try
			{
			  if (this.a)
			  {
				b.a(this.c_Conflict, b.a(this.c_Conflict));
			  }
			  string str = b.b(this.c_Conflict, b.k(this.c_Conflict));
			  if (b.l(this.c_Conflict).Equals(str + Path.DirectorySeparatorChar + b.k(this.c_Conflict)))
			  {
				b.c(this.c_Conflict, false);
			  }
			  else
			  {
				b.c(this.c_Conflict, str + Path.DirectorySeparatorChar + b.k(this.c_Conflict));
				b.c(this.c_Conflict, true);
			  }
			  if (b.m(this.c_Conflict))
			  {
				b.v().info("loading sample folder started");
				b.a(this.c_Conflict, b.c(this.c_Conflict), b.n(this.c_Conflict), b.b(this.c_Conflict), b.l(this.c_Conflict));
				b.v().info("loading sample folder finished");
				b.b(this.c_Conflict, true);
				b.d(this.c_Conflict, true);
			  }
			  if (b.o(this.c_Conflict))
			  {
				b.v().info("writing t reg file started");
				try
				{
				  b.c(this.c_Conflict).a(b.n(this.c_Conflict).c());
				}
				catch (a)
				{
				  throw new p2AppManagerException("Failed to setASICRegisters   ", p2Enumerations.p2AppManagerStatus.ASIC_REGISTER_WRITING_ERROR.NumVal);
				}
				b.v().info("writing t reg file finished");
			  }
			  if (b.p(this.c_Conflict))
			  {
				b.v().info("writing optical settings started");
				try
				{
				  b.b(this.c_Conflict, b.q(this.c_Conflict), p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.OPTICAL_SETTINGS_FILE_PATH), new object[] {b.b(this.c_Conflict)}), this.b);
				}
				catch (Exception exception)
				{
				  throw new p2AppManagerException(exception.Message, p2Enumerations.p2AppManagerStatus.GAIN_OPTIONS_ERROR.NumVal);
				}
				int i = 0;
				try
				{
				  i = (int)b.c(this.c_Conflict).b(i.fy.a(), a.k.fy.a(), a.j.fy.a());
				}
				catch (a)
				{
				  throw new p2AppManagerException("Failed to readASICRegisters   ", p2Enumerations.p2AppManagerStatus.ASIC_REGISTER_READING_ERROR.NumVal);
				}
				double d = Math.Pow(2.0D, i) * 5000.0D * this.b.p * this.b.q;
				b.n(this.c_Conflict).a(d);
				b.v().info("Current Range:" + this.b.o);
				b.v().info("PGA1: " + this.b.p);
				b.v().info("PGA2: " + this.b.q);
				b.v().info("Param.conf[I_adc_gain] = " + b.n(this.c_Conflict).b()[9]);
				b.v().info("writing optical settings finished");
			  }
			  bool bool1 = true;
			  if (b.n(this.c_Conflict).b()[47] != 0.0D)
			  {
				bool1 = false;
			  }
			  bool bool2 = false;
			  if (bool1)
			  {
				try
				{
				  bool2 = b.c(this.c_Conflict).a(bool1);
				}
				catch (a)
				{
				  throw new p2AppManagerException("Failed to read act register ", p2Enumerations.p2AppManagerStatus.ACTUATION_SETTING_ERROR.NumVal);
				}
			  }
			  else
			  {
				bool2 = false;
				try
				{
				  b.c(this.c_Conflict).a(false, bool1, (int)b.a(this.c_Conflict).b()[48]);
				}
				catch (a)
				{
				  throw new p2AppManagerException("Failed to read act register ", p2Enumerations.p2AppManagerStatus.DEVICE_IS_TURNED_OFF_ERROR.NumVal);
				}
			  }
			  if (!bool2)
			  {
				try
				{
				  b.c(this.c_Conflict).a(true, bool1, (int)b.a(this.c_Conflict).b()[48]);
				  b.v().info("sleep for " + b.a(this.c_Conflict).b()[12] + " after starting actuation started");
				  try
				  {
					Thread.Sleep((long)b.a(this.c_Conflict).b()[12]);
				  }
				  catch (InterruptedException interruptedException)
				  {
					b.v().error(interruptedException.Message);
				  }
				  b.v().info("sleep for " + b.a(this.c_Conflict).b()[12] + " after starting actuation finished");
				}
				catch (a)
				{
				  throw new p2AppManagerException("Failed to start actuation ", p2Enumerations.p2AppManagerStatus.DEVICE_IS_TURNED_OFF_ERROR.NumVal);
				}
			  }
			  b.a a1 = b.b(this.c_Conflict, b.a(this.c_Conflict), this.b);
			  double[][] arrayOfDouble = b.n(this.c_Conflict, a1, b.a(this.c_Conflict));
			  if (arrayOfDouble == null)
			  {
				throw new p2AppManagerException("No valid result back for this p2Sample : " + b.b(this.c_Conflict) + " run.", p2Enumerations.p2AppManagerStatus.NO_OF_SCANS_DSP_ERROR.NumVal);
			  }
			  b.a(this.c_Conflict, this.b.a.DeviceAtion, arrayOfDouble, p2Enumerations.p2AppManagerStatus.NO_ERROR);
			}
			catch (p2AppManagerException p2AppManagerException)
			{
			  b.v().error(p2AppManagerException.Message);
			  b.a(this.c_Conflict, this.b.a.DeviceAtion, (double[][])null, p2Enumerations.p2AppManagerStatus.getAppManagerStatusByCode(p2AppManagerException.ErrorCode));
			}
			return Convert.ToBoolean(true);
		  }
	  }

	  private void s(a parama, bool paramBoolean)
	  {
		  c_Conflict.a(new aAnonymousInnerClass24(this, paramBoolean, parama));
	  }

	  private class aAnonymousInnerClass24 : a<bool>
	  {
		  private readonly b outerInstance;

		  public aAnonymousInnerClass24(b outerInstance, bool paramBoolean, sws.p2AppManager.b.a parama) : base(outerInstance, paramBoolean, parama)
		  {
			  this.outerInstance = outerInstance;
		  }

		  protected internal bool? a()
		  {
			try
			{
			  if (this.a)
			  {
				b.a(this.c_Conflict, b.a(this.c_Conflict));
			  }
			  string str = b.b(this.c_Conflict, b.k(this.c_Conflict));
			  if (b.l(this.c_Conflict).Equals(str + Path.DirectorySeparatorChar + b.k(this.c_Conflict)))
			  {
				b.b(this.c_Conflict, false);
			  }
			  else
			  {
				b.c(this.c_Conflict, str + Path.DirectorySeparatorChar + b.k(this.c_Conflict));
				b.b(this.c_Conflict, true);
			  }
			  b.v().info("loading sample folder started");
			  b.a(this.c_Conflict, b.c(this.c_Conflict), b.n(this.c_Conflict), b.b(this.c_Conflict), b.l(this.c_Conflict));
			  b.v().info("loading sample folder finished");
			  if (b.o(this.c_Conflict))
			  {
				b.v().info("writing t reg file started");
				try
				{
				  b.c(this.c_Conflict).a(b.n(this.c_Conflict).c());
				}
				catch (a)
				{
				  throw new p2AppManagerException("Failed to setASICRegisters   ", p2Enumerations.p2AppManagerStatus.ASIC_REGISTER_WRITING_ERROR.NumVal);
				}
				b.v().info("writing t reg file finished");
			  }
			  bool bool1 = true;
			  if (b.n(this.c_Conflict).b()[47] != 0.0D)
			  {
				bool1 = false;
			  }
			  bool bool2 = false;
			  if (bool1)
			  {
				try
				{
				  bool2 = b.c(this.c_Conflict).a(bool1);
				}
				catch (a)
				{
				  throw new p2AppManagerException("Failed to read act register ", p2Enumerations.p2AppManagerStatus.ACTUATION_SETTING_ERROR.NumVal);
				}
			  }
			  else
			  {
				bool2 = false;
				try
				{
				  b.c(this.c_Conflict).a(false, bool1, (int)b.a(this.c_Conflict).b()[48]);
				}
				catch (a)
				{
				  throw new p2AppManagerException("Failed to read act register ", p2Enumerations.p2AppManagerStatus.DEVICE_IS_TURNED_OFF_ERROR.NumVal);
				}
			  }
			  if (!bool2)
			  {
				try
				{
				  b.c(this.c_Conflict).a(true, bool1, (int)b.a(this.c_Conflict).b()[48]);
				  b.v().info("sleep for " + b.a(this.c_Conflict).b()[12] + " after starting actuation started");
				  try
				  {
					Thread.Sleep((long)b.a(this.c_Conflict).b()[12]);
				  }
				  catch (InterruptedException interruptedException)
				  {
					b.v().error(interruptedException.Message);
				  }
				  b.v().info("sleep for " + b.a(this.c_Conflict).b()[12] + " after starting actuation finished");
				}
				catch (a)
				{
				  throw new p2AppManagerException("Failed to start actuation ", p2Enumerations.p2AppManagerStatus.DEVICE_IS_TURNED_OFF_ERROR.NumVal);
				}
			  }
			  double d1 = 512.0D * b.n(this.c_Conflict).b()[49] / 1.35D;
			  double d2 = 512.0D * b.n(this.c_Conflict).b()[49];
			  double d3 = 0.0D;
			  double d4 = 0.0D;
			  int i = 6;
			  sbyte b1 = 0;
			  bool @bool = false;
			  b.a a1 = b.b(this.c_Conflict, b.a(this.c_Conflict), this.b);
			  double d5 = Math.Pow(2.0D, 4.0D) * this.b.aa / Math.Pow(2.0D, this.b.ab);
			  b.v().info("Gain optimization: " + (d5 * 512.0D));
			  this.b.r = true;
			  b.v().info("writing hpfBypass started");
			  try
			  {
				b.c(this.c_Conflict).b(i.fD.a(), 1L, a.k.fD.a(), a.j.fD.a());
			  }
			  catch (a)
			  {
				throw new p2AppManagerException("Failed to set HPFBYPASS=1   ", p2Enumerations.p2AppManagerStatus.ASIC_REGISTER_WRITING_ERROR.NumVal);
			  }
			  b.v().info("writing hpfBypass finished");
			  this.b.p = p2Constants.PGA1_values[b1];
			  this.b.q = p2Constants.PGA2_values[@bool];
			  b.a(this.c_Conflict, this.b.p.ToString(), p2Constants.getPath(p2Constants.PGA1_OPTION_FILE_PATH));
			  b.a(this.c_Conflict, this.b.q.ToString(), p2Constants.getPath(p2Constants.PGA2_OPTION_FILE_PATH));
			  this.b.o = p2Constants.currentRanges[i];
			  b.a(this.c_Conflict, this.b.o, p2Constants.getPath(p2Constants.DETECTOR_AND_CURRENT_RANGE_OPTION_FILE_PATH));
			  b.v().info("DetectorAndCurrentRange: " + this.b.o);
			  b.v().info("PGA1: " + this.b.p);
			  b.v().info("PGA2: " + this.b.q);
			  double[][] arrayOfDouble1 = b.o(this.c_Conflict, a1, b.a(this.c_Conflict));
			  if (arrayOfDouble1 == null)
			  {
				throw new p2AppManagerException("No valid result back for this p2Sample : " + b.b(this.c_Conflict) + " run.", p2Enumerations.p2AppManagerStatus.NO_OF_SCANS_DSP_ERROR.NumVal);
			  }
			  d3 = arrayOfDouble1[0][0];
			  for (sbyte b2 = 1; b2 < arrayOfDouble1[0].Length; b2++)
			  {
				d4 = (arrayOfDouble1[0][b2] < 0.0D) ? (arrayOfDouble1[0][b2] * -1.0D) : arrayOfDouble1[0][b2];
				d3 = (d3 > d4) ? d3 : d4;
			  }
			  d3 /= d5;
			  double d6 = d1 / d3;
			  int j = (int)Math.Floor(Math.Log10(d6) / Math.Log10(2.0D));
			  if (j >= p2Constants.currentRanges.Length)
			  {
				b.v().error("No of steps in larger than current ranges! setting it to the max!");
				Console.WriteLine("No of steps in larger than current ranges! setting it to the max!");
				j = p2Constants.currentRanges.Length - 1;
			  }
			  if (j < 0)
			  {
				b.v().error("No of steps is -ve!");
				Console.WriteLine("No of steps is -ve!");
				j = 0;
			  }
			  i -= j;
			  if (i < 0 || i > 6)
			  {
				i = 0;
			  }
			  this.b.o = p2Constants.currentRanges[i];
			  b.a(this.c_Conflict, this.b.o, p2Constants.getPath(p2Constants.DETECTOR_AND_CURRENT_RANGE_OPTION_FILE_PATH));
			  b.v().info("DetectorAndCurrentRange: " + this.b.o);
			  double[][] arrayOfDouble2 = (double[][])null;
			  this.b.r = false;
			  b.v().info("writing hpfBypass started");
			  try
			  {
				b.c(this.c_Conflict).b(i.fD.a(), 0L, a.k.fD.a(), j.fD.a());
			  }
			  catch (a)
			  {
				throw new p2AppManagerException("Failed to set HPFBYPASS=1   ", p2Enumerations.p2AppManagerStatus.ASIC_REGISTER_WRITING_ERROR.NumVal);
			  }
			  b.v().info("writing hpfBypass finished");
			  b1 = 2;
			  this.b.p = p2Constants.PGA1_values[b1];
			  b.v().info("PGA1: " + this.b.p);
			  b.a(this.c_Conflict, this.b.p.ToString(), p2Constants.getPath(p2Constants.PGA1_OPTION_FILE_PATH));
			  b.v().info("DetectorAndCurrentRange: " + this.b.o);
			  arrayOfDouble1 = b.o(this.c_Conflict, a1, b.a(this.c_Conflict));
			  if (arrayOfDouble1 == null)
			  {
				throw new p2AppManagerException("No valid result back for this p2Sample : " + b.b(this.c_Conflict) + " run.", p2Enumerations.p2AppManagerStatus.NO_OF_SCANS_DSP_ERROR.NumVal);
			  }
			  d3 = arrayOfDouble1[0][0];
			  for (sbyte b3 = 1; b3 < arrayOfDouble1[0].Length; b3++)
			  {
				d4 = (arrayOfDouble1[0][b3] < 0.0D) ? (arrayOfDouble1[0][b3] * -1.0D) : arrayOfDouble1[0][b3];
				d3 = (d3 > d4) ? d3 : d4;
			  }
			  d3 /= d5;
			  double d7 = d2 / d3;
			  b.v().info("Max Abs: " + d3);
			  b.v().info("Gain Factor: " + d7);
			  sbyte b4;
			  for (b4 = 0; b4 < this.c_Conflict.a.length - 1 && (this.c_Conflict.a[b4][2] > d7 * p2Constants.PGA1_values[b1] * p2Constants.PGA2_values[@bool] || this.c_Conflict.a[b4 + true][2] <= d7 * p2Constants.PGA1_values[b1] * p2Constants.PGA2_values[@bool]); b4++)
			  {
				  ;
			  }
			  this.b.p = p2Constants.PGA1_values[this.c_Conflict.a[b4][0]];
			  this.b.q = p2Constants.PGA2_values[this.c_Conflict.a[b4][1]];
			  b.a(this.c_Conflict, this.b.p.ToString(), p2Constants.getPath(p2Constants.PGA1_OPTION_FILE_PATH));
			  b.a(this.c_Conflict, this.b.q.ToString(), p2Constants.getPath(p2Constants.PGA2_OPTION_FILE_PATH));
			  b.v().info("PGA1: " + this.b.p);
			  b.v().info("PGA2: " + this.b.q);
			  if (this.b.a == p2Enumerations.p2AppManagerState.gainAdjustSpecSampleRun)
			  {
				double d8 = 1.0D;
				double[][] arrayOfDouble3 = new double[][]
				{
					new double[] {i, this.c_Conflict.a[b4][0], this.c_Conflict.a[b4][1]}
				};
				b.v().info("writing optical settings started");
				this.b.o = p2Constants.currentRanges[(int)b.w(this.c_Conflict)[0][0]];
				this.b.p = p2Constants.PGA1_values[(int)b.w(this.c_Conflict)[0][1]];
				this.b.q = p2Constants.PGA2_values[(int)b.w(this.c_Conflict)[0][2]];
				b.a(this.c_Conflict, this.b.o, p2Constants.getPath(p2Constants.DETECTOR_AND_CURRENT_RANGE_OPTION_FILE_PATH));
				b.a(this.c_Conflict, this.b.p.ToString(), p2Constants.getPath(p2Constants.PGA1_OPTION_FILE_PATH));
				b.a(this.c_Conflict, this.b.q.ToString(), p2Constants.getPath(p2Constants.PGA2_OPTION_FILE_PATH));
				int k = 0;
				try
				{
				  k = (int)b.c(this.c_Conflict).b(i.fy.a(), k.fy.a(), j.fy.a());
				}
				catch (a)
				{
				  throw new p2AppManagerException("Failed to readASICRegisters   ", p2Enumerations.p2AppManagerStatus.ASIC_REGISTER_READING_ERROR.NumVal);
				}
				double d9 = Math.Pow(2.0D, k) * 5000.0D * this.b.p * this.b.q;
				b.n(this.c_Conflict).a(d9);
				b.v().info("Current Range: " + this.b.o);
				b.v().info("PGA1: " + this.b.p);
				b.v().info("PGA2: " + this.b.q);
				b.v().info("Param.conf[I_adc_gain] = " + b.n(this.c_Conflict).b()[9]);
				b.v().info("writing optical settings finished");
				a1 = b.b(this.c_Conflict, b.a(this.c_Conflict), this.b);
				double[][] arrayOfDouble4 = b.l(this.c_Conflict, a1, b.a(this.c_Conflict));
				if (arrayOfDouble4 == null)
				{
				  throw new p2AppManagerException("No valid result back for this p2Sample : " + b.b(this.c_Conflict) + " run.", p2Enumerations.p2AppManagerStatus.NO_OF_SCANS_DSP_ERROR.NumVal);
				}
				b.v().info("writing optical settings started");
				this.b.o = p2Constants.currentRanges[(int)arrayOfDouble3[0][0]];
				this.b.p = p2Constants.PGA1_values[(int)arrayOfDouble3[0][1]];
				this.b.q = p2Constants.PGA2_values[(int)arrayOfDouble3[0][2]];
				b.a(this.c_Conflict, this.b.o, p2Constants.getPath(p2Constants.DETECTOR_AND_CURRENT_RANGE_OPTION_FILE_PATH));
				b.a(this.c_Conflict, this.b.p.ToString(), p2Constants.getPath(p2Constants.PGA1_OPTION_FILE_PATH));
				b.a(this.c_Conflict, this.b.q.ToString(), p2Constants.getPath(p2Constants.PGA2_OPTION_FILE_PATH));
				int m = 0;
				try
				{
				  m = (int)b.c(this.c_Conflict).b(i.fy.a(), k.fy.a(), j.fy.a());
				}
				catch (a)
				{
				  throw new p2AppManagerException("Failed to readASICRegisters   ", p2Enumerations.p2AppManagerStatus.ASIC_REGISTER_READING_ERROR.NumVal);
				}
				double d10 = Math.Pow(2.0D, m) * 5000.0D * this.b.p * this.b.q;
				b.n(this.c_Conflict).a(d10);
				b.v().info("Current Range:" + this.b.o);
				b.v().info("PGA1: " + this.b.p);
				b.v().info("PGA2: " + this.b.q);
				b.v().info("Param.conf[I_adc_gain] = " + b.n(this.c_Conflict).b()[9]);
				b.v().info("writing optical settings finished");
				a1 = b.b(this.c_Conflict, b.a(this.c_Conflict), this.b);
				double[][] arrayOfDouble5 = b.l(this.c_Conflict, a1, b.a(this.c_Conflict));
				if (arrayOfDouble5 == null)
				{
				  throw new p2AppManagerException("No valid result back for this p2Sample : " + b.b(this.c_Conflict) + " run.", p2Enumerations.p2AppManagerStatus.NO_OF_SCANS_DSP_ERROR.NumVal);
				}
				b.a(this.c_Conflict, arrayOfDouble5, arrayOfDouble4);
				for (sbyte b5 = 0; b5 < arrayOfDouble5[3].Length; b5++)
				{
				  arrayOfDouble5[3][b5] = Math.Pow(10.0D, arrayOfDouble5[3][b5] / 10.0D);
				}
				double[] arrayOfDouble = new double[arrayOfDouble5[2].Length];
				sbyte b6;
				for (b6 = 0; b6 < arrayOfDouble.Length; b6++)
				{
				  arrayOfDouble[b6] = 1.0E7D / arrayOfDouble5[2][b6];
				}
				b6 = 0;
				double d11 = 0.0D;
				for (sbyte b7 = 0; b7 < arrayOfDouble.Length; b7++)
				{
				  if (arrayOfDouble[b7] < b.n(this.c_Conflict).b()[24] * 1000.0D - 100.0D && arrayOfDouble[b7] > b.n(this.c_Conflict).b()[23] * 1000.0D + 100.0D)
				  {
					d11 += arrayOfDouble5[3][b7];
					b6++;
				  }
				}
				d8 = d11 / b6;
				arrayOfDouble2 = new double[][]
				{
					new double[] {i, this.c_Conflict.a[b4][0], this.c_Conflict.a[b4][1]},
					new double[] {d8}
				};
			  }
			  else
			  {
				if (this.b.a == p2Enumerations.p2AppManagerState.gainAdjustSpecBG_Run)
				{
				  arrayOfDouble2 = new double[][]
				  {
					  new double[] {i, this.c_Conflict.a[b4][0], this.c_Conflict.a[b4][1]},
					  new double[] {1.0D}
				  };
				  b.a(this.c_Conflict, p2Enumerations.p2AppManagerState.gainAdjustSpecSampleRun.DeviceAtion, arrayOfDouble2, p2Enumerations.p2AppManagerStatus.NO_ERROR);
				}
				arrayOfDouble2 = new double[][]
				{
					new double[] {i, this.c_Conflict.a[b4][0], this.c_Conflict.a[b4][1]}
				};
			  }
			  b.a(this.c_Conflict, this.b.a.DeviceAtion, arrayOfDouble2, p2Enumerations.p2AppManagerStatus.NO_ERROR);
			}
			catch (p2AppManagerException p2AppManagerException)
			{
			  b.v().error(p2AppManagerException.Message);
			  b.a(this.c_Conflict, this.b.a.DeviceAtion, (double[][])null, p2Enumerations.p2AppManagerStatus.getAppManagerStatusByCode(p2AppManagerException.ErrorCode));
			}
			return Convert.ToBoolean(true);
		  }
	  }

	  private void a(bool paramBoolean1, bool paramBoolean2, bool paramBoolean3)
	  {
		  c_Conflict.a(new aAnonymousInnerClass25(this, paramBoolean1, paramBoolean2, paramBoolean3));
	  }

	  private class aAnonymousInnerClass25 : a<bool>
	  {
		  private readonly b outerInstance;

		  public aAnonymousInnerClass25(b outerInstance, bool paramBoolean1, bool paramBoolean2, bool paramBoolean3) : base(outerInstance, paramBoolean1, paramBoolean2, paramBoolean3)
		  {
			  this.outerInstance = outerInstance;
		  }

		  protected internal bool? a()
		  {
			try
			{
			  if (this.a)
			  {
				b.a(this.d_Conflict, b.a(this.d_Conflict));
			  }
			  try
			  {
				b.c(this.d_Conflict).a(this.b, this.c_Conflict, (int)b.a(this.d_Conflict).b()[48]);
				if (this.b)
				{
				  try
				  {
					Thread.Sleep((long)b.a(this.d_Conflict).b()[12]);
				  }
				  catch (InterruptedException interruptedException)
				  {
					b.v().error(interruptedException.Message);
				  }
				}
				b.a(this.d_Conflict, p2Enumerations.p2AppManagerState.ActuationProfileSetting.DeviceAtion, (double[][])null, p2Enumerations.p2AppManagerStatus.NO_ERROR);
			  }
			  catch (a a1)
			  {
				b.v().error(a1.Message);
				throw new p2AppManagerException(a1.Message, p2Enumerations.p2AppManagerStatus.ACTUATION_SETTING_ERROR.NumVal);
			  }
			}
			catch (p2AppManagerException p2AppManagerException)
			{
			  b.v().error(p2AppManagerException.Message);
			  b.a(this.d_Conflict, p2Enumerations.p2AppManagerState.ActuationProfileSetting.DeviceAtion, (double[][])null, p2Enumerations.p2AppManagerStatus.getAppManagerStatusByCode(p2AppManagerException.ErrorCode));
			}
			return Convert.ToBoolean(true);
		  }
	  }

	  private void a(b paramb)
	  {
		try
		{
		  this.O.a(new bool[0]);
		  try
		  {
			this.c_Conflict = this.O.e();
		  }
		  catch (Exception)
		  {
			this.c_Conflict = "sampleId";
		  }
		  try
		  {
			A();
		  }
		  catch (Exception exception)
		  {
			b_Conflict.error(exception.Message);
		  }
		  sws.p2AppManager.b.b.a("TAIFReg", this.O.f());
		  this.O.a(paramb.c());
		}
		catch (System.FormatException)
		{
		  throw new p2AppManagerException("Invalid productId ", p2Enumerations.p2AppManagerStatus.INVALID_BOARD_CONFIGURATION_ERROR.NumVal);
		}
		catch (p2AppManagerException p2AppManagerException)
		{
		  throw p2AppManagerException;
		}
		catch (Exception exception)
		{
		  b_Conflict.error(exception.Message);
		  throw new p2AppManagerException("Failed to initiate TAIFDriver   ", p2Enumerations.p2AppManagerStatus.INITIATE_TAIFDRIVER_ERROR.NumVal);
		}
	  }

	  private void a(string paramString1, string paramString2)
	  {
		List<object> arrayList1 = new List<object>();
		List<object> arrayList2 = new List<object>();
		File file = new File(paramString2);
		if (file.exists())
		{
		  bufferedReader = null;
		  try
		  {
			bufferedReader = new StreamReader(paramString2);
			str = null;
			while ((str = bufferedReader.readLine()) != null)
			{
			  if (str.StartsWith(".option") && str.contains(paramString1))
			  {
				while (!(str = bufferedReader.readLine()).Equals(".end"))
				{
				  if (!str.StartsWith("#"))
				  {
					string[] arrayOfString = str.Split("=");
					if (arrayOfString.Length == 2)
					{
					  arrayList1.Add(arrayOfString[0].replaceAll(" ", ""));
					  arrayList2.Add(Convert.ToInt32(int.Parse(arrayOfString[1].replaceAll(" ", ""))));
					}
				  }
				}
				break;
			  }
			}
			for (sbyte b1 = 0; b1 < arrayList1.Count; b1++)
			{
			  this.O.b(i_Conflict.valueOf((string)arrayList1[b1]).a(), ((int?)arrayList2[b1]).Value, k_Conflict.valueOf((string)arrayList1[b1]).a(), j_Conflict.valueOf((string)arrayList1[b1]).a());
			}
		  }
		  catch (Exception exception)
		  {
			b_Conflict.error(exception.Message);
			return;
		  }
		  finally
		  {
			try
			{
			  bufferedReader.close();
			}
			catch (Exception exception)
			{
			  b_Conflict.error(exception.Message);
			}
		  }
		}
	  }

//JAVA TO C# CONVERTER NOTE: Members cannot have the same name as their enclosing type:
	  private void b_Conflict(string paramString1, string paramString2, a parama)
	  {
		paramString1 = this.K + paramString1;
		List<object> arrayList1 = new List<object>();
		List<object> arrayList2 = new List<object>();
		File file = new File(paramString2);
		if (file.exists())
		{
		  bufferedReader = null;
		  try
		  {
			bufferedReader = new StreamReader(paramString2);
			str = null;
			while ((str = bufferedReader.readLine()) != null)
			{
			  if (str.StartsWith(".option") && str.replace(".option ", "").Equals(paramString1))
			  {
				while (!(str = bufferedReader.readLine()).Equals(".end"))
				{
				  if (!str.StartsWith("#"))
				  {
					string[] arrayOfString = str.Split("=");
					if (arrayOfString.Length == 2)
					{
					  arrayList1.Add(arrayOfString[0].replaceAll(" ", ""));
					  arrayList2.Add(arrayOfString[1].replaceAll(" ", ""));
					}
				  }
				}
				break;
			  }
			}
			if (arrayList1.Count == 0)
			{
			  throw new Exception("Optical gain option not found");
			}
			for (sbyte b1 = 0; b1 < arrayList1.Count; b1++)
			{
			  if ((p2Enumerations.p2AppManagerState.InterferogramRun == parama.a && string.ReferenceEquals(this.K, "_InterSpec_")) || (p2Enumerations.p2AppManagerState.SNR_Run == parama.a && string.ReferenceEquals(this.K, "_InterSpec_")) || (p2Enumerations.p2AppManagerState.selfCorr_Run == parama.a && string.ReferenceEquals(this.K, "_InterSpec_")))
			  {
				if ("CURRENT_RANGE".Equals(arrayList1[b1]))
				{
				  parama.o = (string)arrayList2[b1];
				  a(parama.o, p2Constants.getPath(p2Constants.DETECTOR_AND_CURRENT_RANGE_OPTION_FILE_PATH));
				}
				if ("PGA1".Equals(arrayList1[b1]))
				{
				  parama.p = int.Parse((string)arrayList2[b1]);
				  a(parama.p.ToString(), p2Constants.getPath(p2Constants.PGA1_OPTION_FILE_PATH));
				}
				if ("PGA2".Equals(arrayList1[b1]))
				{
				  parama.q = int.Parse((string)arrayList2[b1]);
				  a(parama.q.ToString(), p2Constants.getPath(p2Constants.PGA2_OPTION_FILE_PATH));
				}
			  }
			  else if ((p2Enumerations.p2AppManagerState.selfCorr_Run == parama.a && string.ReferenceEquals(this.K, "_Spec_")) || (p2Enumerations.p2AppManagerState.SpectroscopyBackgroundRun == parama.a && string.ReferenceEquals(this.K, "_Spec_")) || (p2Enumerations.p2AppManagerState.wavelengthCalibrationBG_Run == parama.a && string.ReferenceEquals(this.K, "_Spec_")))
			  {
				if ("BG_CURRENT_RANGE".Equals(arrayList1[b1]))
				{
				  parama.o = (string)arrayList2[b1];
				  a(parama.o, p2Constants.getPath(p2Constants.DETECTOR_AND_CURRENT_RANGE_OPTION_FILE_PATH));
				}
				if ("BG_PGA1".Equals(arrayList1[b1]))
				{
				  parama.p = int.Parse((string)arrayList2[b1]);
				  a(parama.p.ToString(), p2Constants.getPath(p2Constants.PGA1_OPTION_FILE_PATH));
				}
				if ("BG_PGA2".Equals(arrayList1[b1]))
				{
				  parama.q = int.Parse((string)arrayList2[b1]);
				  a(parama.q.ToString(), p2Constants.getPath(p2Constants.PGA2_OPTION_FILE_PATH));
				}
			  }
			  else if ((p2Enumerations.p2AppManagerState.SpectroscopySampleRun == parama.a && string.ReferenceEquals(this.K, "_Spec_")) || (p2Enumerations.p2AppManagerState.wavelengthCalibration_Run == parama.a && string.ReferenceEquals(this.K, "_Spec_")) || (p2Enumerations.p2AppManagerState.StabilityRun == parama.a && string.ReferenceEquals(this.K, "_Spec_")))
			  {
				if ("Sample_CURRENT_RANGE".Equals(arrayList1[b1]))
				{
				  parama.o = (string)arrayList2[b1];
				  a(parama.o, p2Constants.getPath(p2Constants.DETECTOR_AND_CURRENT_RANGE_OPTION_FILE_PATH));
				}
				if ("Sample_PGA1".Equals(arrayList1[b1]))
				{
				  parama.p = int.Parse((string)arrayList2[b1]);
				  a(parama.p.ToString(), p2Constants.getPath(p2Constants.PGA1_OPTION_FILE_PATH));
				}
				if ("Sample_PGA2".Equals(arrayList1[b1]))
				{
				  parama.q = int.Parse((string)arrayList2[b1]);
				  a(parama.q.ToString(), p2Constants.getPath(p2Constants.PGA2_OPTION_FILE_PATH));
				}
				if ("ERROR".Equals(arrayList1[b1]))
				{
				  this.M = double.Parse((string)arrayList2[b1]);
				}
			  }
			}
		  }
		  catch (Exception exception)
		  {
			b_Conflict.error(exception.Message);
			throw exception;
		  }
		  finally
		  {
			try
			{
			  bufferedReader.close();
			}
			catch (Exception exception)
			{
			  b_Conflict.error(exception.Message);
			}
		  }
		}
	  }

	  private a a(b paramb, a parama)
	  {
		b_Conflict.info("prepareRunConfigDataInterp function started");
		parama.b = this.C_Conflict.b()[11];
		b_Conflict.info("actFreq: " + parama.b);
		p2Constants.MAX_RUNTIME_MS = 1.6384E7D / parama.b;
		parama.Z = a(parama.ac);
		b_Conflict.info("noOfRuns: " + parama.Z);
		parama.ac = (parama.Z == 1) ? parama.ac : (parama.ac / parama.Z);
		b_Conflict.info("runTime: " + parama.ac);
		parama.aa = a(parama.ac, parama.b);
		b_Conflict.info("noOfSlices: " + parama.aa);
		parama.ab = b(parama.aa);
		b_Conflict.info("avgShiftBits: " + parama.ab);
		b_Conflict.info("prepareRunConfigDataInterp function finished");
		return parama;
	  }

	  private a b(b paramb, a parama)
	  {
		  if (!InstanceFieldsInitialized)
		  {
			  InitializeInstanceFields();
			  InstanceFieldsInitialized = true;
		  }
		p2Constants.MAX_RUNTIME_MS = 1.6384E7D / parama.b;
		parama.Z = a(parama.ac);
		b_Conflict.info("noOfRuns: " + parama.Z);
		parama.ac = (parama.Z == 1) ? parama.ac : (parama.ac / parama.Z);
		b_Conflict.info("runTime: " + parama.ac);
		parama.aa = a(parama.ac, parama.b);
		b_Conflict.info("noOfSlices: " + parama.aa);
		parama.ab = b(parama.aa);
		b_Conflict.info("avgShiftBits: " + parama.ab);
		return parama;
	  }

	  private int a(double paramDouble)
	  {
		if (paramDouble < 10.0D)
		{
		  throw new p2AppManagerException("Invalid run time value < 10M second  ", p2Enumerations.p2AppManagerStatus.INVALID_RUN_TIME_ERROR.NumVal);
		}
		double d1 = paramDouble;
		double d2 = paramDouble;
		sbyte b1 = 1;
		while (d2 > p2Constants.MAX_RUNTIME_MS)
		{
		  d2 = d1 / ++b1;
		}
		return b1;
	  }

	  private int a(double paramDouble1, double paramDouble2)
	  {
		  return (int)(paramDouble1 * paramDouble2 / 1000.0D);
	  }

	  private int b(double paramDouble)
	  {
		  if (!InstanceFieldsInitialized)
		  {
			  InitializeInstanceFields();
			  InstanceFieldsInitialized = true;
		  }
		double d1 = 0.0D;
		if (paramDouble > 1024.0D)
		{
		  d1 = Math.Ceiling(Math.Log10(paramDouble / 1024.0D) / Math.Log10(2.0D));
		}
		return (int)d1;
	  }

	  private void a(a parama, c paramc, string paramString1, string paramString2)
	  {
		int i1 = parama.f();
		p2Enumerations.p2AppManagerStatus p2AppManagerStatus = paramc.a(new string[] {paramString1, paramString2, Convert.ToString(i1)});
		if (p2Enumerations.p2AppManagerStatus.NO_ERROR != p2AppManagerStatus)
		{
		  throw new p2AppManagerException("Failed to load sample configuration ", p2AppManagerStatus.NumVal);
		}
	  }

	  private double[][] a(a parama, b paramb)
	  {
		b_Conflict.info("responseCalculationStreamingProcessing entered");
		Future future1 = null;
		Future future2 = null;
		int[][] arrayOfInt = (int[][])null;
		double[][] arrayOfDouble1 = (double[][])null;
		double[][] arrayOfDouble2 = new double[2][];
		double d1 = parama.I;
		sbyte b1;
		for (b1 = 0; d1 <= parama.J; b1++)
		{
		  d1 += parama.K;
		}
		arrayOfDouble2[0] = new double[b1];
		arrayOfDouble2[1] = new double[b1];
		d1 = parama.I;
		for (b1 = 0; d1 <= parama.J; b1++)
		{
		  arrayOfDouble2[0][b1] = d1;
		  d1 += parama.K;
		}
		b_Conflict.info("----------------Run numbers : " + parama.Z);
		try
		{
		  p2SpectroDSP.a().a(this.D_Conflict.b());
		  for (sbyte b2 = 0; b2 < arrayOfDouble2[0].Length; b2++)
		  {
			double d4 = arrayOfDouble2[0][b2];
			long l1 = (long)(d4 * Math.Pow(2.0D, 14.0D) / 50.0D * Math.Pow(10.0D, 3.0D));
			this.O.b(i_Conflict.cD.a(), l1, k_Conflict.cD.a(), j_Conflict.cD.a());
			this.O.a(false, true, (int)this.D_Conflict.b()[48]);
			try
			{
			  Thread.Sleep((long)this.D_Conflict.b()[12]);
			}
			catch (InterruptedException interruptedException)
			{
			  b_Conflict.error(interruptedException.Message);
			}
			this.O.a(true, true, (int)this.D_Conflict.b()[48]);
			try
			{
			  Thread.Sleep((long)this.D_Conflict.b()[12]);
			}
			catch (InterruptedException interruptedException)
			{
			  b_Conflict.error(interruptedException.Message);
			}
			future1 = a(this.O, parama);
			b_Conflict.info("begin streaming process...");
			arrayOfInt = (int[][])future1.get();
			b_Conflict.info("end streaming process.");
			this.D_Conflict = paramb;
			future2 = b(this.O, arrayOfInt, parama);
			b_Conflict.info("begin DSP Response Calculation Res Freq And Quality Factor...");
			arrayOfDouble1 = (double[][])future2.get();
			arrayOfDouble2[1][b2] = arrayOfDouble1[0][0];
			b_Conflict.info("end DSP Response Calculation Res Freq And Quality Factor.");
		  }
		  double d2 = this.O.b(i_Conflict.fH.a(), k_Conflict.fH.a(), j_Conflict.fH.a());
		  double d3 = this.O.b(i_Conflict.fI.a(), k_Conflict.fI.a(), j_Conflict.fI.a());
		  arrayOfDouble2[1] = p2SpectroDSP.a().a(arrayOfDouble2[1], parama.m, d2, d3, parama.n)[0];
		  b_Conflict.info("responseCalculationStreamingProcessing finished");
		  return arrayOfDouble2;
		}
		catch (InterruptedException interruptedException)
		{
		  b_Conflict.error("responseCalculationStreamingProcessing throw exception : " + interruptedException.Message);
		  throw new p2AppManagerException("Failed to get thread data  ", p2Enumerations.p2AppManagerStatus.UNKNOWN_ERROR.NumVal);
		}
		catch (Exception exception)
		{
		  b_Conflict.error("responseCalculationStreamingProcessing throw exception : " + exception.Message);
		  if (exception.InnerException is p2AppManagerException)
		  {
			throw (p2AppManagerException)exception.InnerException;
		  }
		  throw new p2AppManagerException("Failed to get thread data  ", p2Enumerations.p2AppManagerStatus.UNKNOWN_ERROR.NumVal);
		}
	  }

	  private double[][] b(a parama, b paramb)
	  {
		  if (!InstanceFieldsInitialized)
		  {
			  InitializeInstanceFields();
			  InstanceFieldsInitialized = true;
		  }
		b_Conflict.info("parametersCalculationStreamingProcessing entered");
		Future future1 = null;
		Future future2 = null;
		int[][] arrayOfInt = (int[][])null;
		double[][] arrayOfDouble1 = (double[][])null;
		double[][] arrayOfDouble2 = (double[][])null;
		double[][] arrayOfDouble3 = (double[][])null;
		b_Conflict.info("----------------Run numbers : " + parama.Z);
		try
		{
		  p2SpectroDSP.a().a(this.D_Conflict.b());
		  future1 = a(this.O, parama);
		  b_Conflict.info("begin streaming process...");
		  arrayOfInt = (int[][])future1.get();
		  b_Conflict.info("end streaming process.");
		  this.D_Conflict = paramb;
		  future2 = c(this.O, arrayOfInt, parama);
		  b_Conflict.info("begin DSP Parameters Calculation Res Freq And Quality Factor...");
		  arrayOfDouble1 = (double[][])future2.get();
		  b_Conflict.info("end DSP Parameters Calculation Res Freq And Quality Factor.");
		  try
		  {
			this.O.a(paramb.c());
		  }
		  catch (a_Conflict)
		  {
			b_Conflict.error("Loading register file failed");
			throw new p2AppManagerException("Failed to get thread data  ", p2Enumerations.p2AppManagerStatus.ASIC_REGISTER_WRITING_ERROR.NumVal);
		  }
		  a("Push-Pull", p2Constants.getPath(p2Constants.ACTUATION_DIRECTION_OPTION_FILE_PATH));
		  a("Sine", p2Constants.getPath(p2Constants.WAVEFORM_OPTION_FILE_PATH));
		  double d1 = 0.0D;
		  if (this.r_Conflict == null)
		  {
			double d2 = arrayOfDouble1[0][0];
			d1 = d2 - parama.H;
		  }
		  else
		  {
			double d2 = this.r_Conflict[1][0];
			sbyte b1 = 0;
			for (sbyte b2 = 1; b2 < this.r_Conflict[1].Length; b2++)
			{
			  if (this.r_Conflict[1][b2] > d2)
			  {
				d2 = this.r_Conflict[1][b2];
				b1 = b2;
			  }
			}
			double d3 = this.r_Conflict[0][b1];
			d1 = d3 - parama.H;
		  }
		  long l1 = (long)Math.Round((parama.j * Math.Pow(2.0D, k_Conflict.cF.a()) - 1.0D) / 100.0D, MidpointRounding.AwayFromZero);
		  this.O.b(i_Conflict.cF.a(), l1, k_Conflict.cF.a(), j_Conflict.cF.a());
		  long l2 = (long)(d1 * Math.Pow(2.0D, 14.0D) / 50.0D * Math.Pow(10.0D, 3.0D));
		  this.O.b(i_Conflict.cD.a(), l2, k_Conflict.cD.a(), j_Conflict.cD.a());
		  a(parama.l.ToString(), p2Constants.getPath(p2Constants.SAMPLING_RATE_OPTION_FILE_PATH));
		  a(parama.m.ToString(), p2Constants.getPath(p2Constants.EXCITATION_VOLTAGE_OPTION_FILE_PATH));
		  a(parama.n.ToString(), p2Constants.getPath(p2Constants.C2V_GAIN_OPTION_FILE_PATH));
		  bool @bool = false;
		  try
		  {
			@bool = this.O.a(true);
		  }
		  catch (a_Conflict)
		  {
			throw new p2AppManagerException("Failed to get thread data  ", p2Enumerations.p2AppManagerStatus.ACTUATION_SETTING_ERROR.NumVal);
		  }
		  if (!@bool)
		  {
			try
			{
			  this.O.a(true, true, (int)paramb.b()[48]);
			  try
			  {
				Thread.Sleep((long)paramb.b()[12]);
			  }
			  catch (InterruptedException interruptedException)
			  {
				b_Conflict.error(interruptedException.Message);
			  }
			}
			catch (a_Conflict)
			{
			  throw new p2AppManagerException("Failed to get thread data  ", p2Enumerations.p2AppManagerStatus.DEVICE_IS_TURNED_OFF_ERROR.NumVal);
			}
		  }
		  future1 = a(this.O, parama);
		  b_Conflict.info("begin streaming process...");
		  arrayOfInt = (int[][])future1.get();
		  b_Conflict.info("end streaming process.");
		  future2 = d(this.O, arrayOfInt, parama);
		  b_Conflict.info("begin DSP Parameters Calculation Forward Gain...");
		  arrayOfDouble2 = (double[][])future2.get();
		  b_Conflict.info("end DSP Parameters Calculation Forward Gain.");
		  int i1 = (int)this.O.b(i_Conflict.fE.a(), k_Conflict.fE.a(), j_Conflict.fE.a());
		  int i2 = (int)this.O.b(i_Conflict.fF.a(), k_Conflict.fF.a(), j_Conflict.fF.a());
		  i1 *= 2;
		  i2 *= 2;
		  if (i1 == 0)
		  {
			i1 = 1;
		  }
		  if (i2 == 0)
		  {
			i2 = 1;
		  }
		  parama.p = i1;
		  parama.q = i2;
		  future2 = e(this.O, arrayOfInt, parama);
		  b_Conflict.info("begin DSP process...");
		  arrayOfDouble3 = (double[][])future2.get();
		  b_Conflict.info("end DSP process.");
		  b_Conflict.info("parametersCalculationStreamingProcessing finished");
		  double[][] arrayOfDouble = new double[5][];
		  arrayOfDouble[0] = arrayOfDouble3[0];
		  arrayOfDouble[1] = arrayOfDouble3[1];
		  arrayOfDouble[2] = new double[1];
		  arrayOfDouble[2][0] = arrayOfDouble1[0][0];
		  arrayOfDouble[3] = new double[1];
		  arrayOfDouble[3][0] = arrayOfDouble1[1][0];
		  arrayOfDouble[4] = new double[1];
		  arrayOfDouble[4][0] = arrayOfDouble2[0][0];
		  return arrayOfDouble;
		}
		catch (InterruptedException interruptedException)
		{
		  b_Conflict.error("parametersCalculationStreamingProcessing throw exception : " + interruptedException.Message);
		  throw new p2AppManagerException("Failed to get thread data  ", p2Enumerations.p2AppManagerStatus.UNKNOWN_ERROR.NumVal);
		}
		catch (Exception exception)
		{
		  b_Conflict.error("parametersCalculationStreamingProcessing throw exception : " + exception.Message);
		  if (exception.InnerException is p2AppManagerException)
		  {
			throw (p2AppManagerException)exception.InnerException;
		  }
		  throw new p2AppManagerException("Failed to get thread data  ", p2Enumerations.p2AppManagerStatus.UNKNOWN_ERROR.NumVal);
		}
	  }

	  private double[][] c(a parama, b paramb)
	  {
		b_Conflict.info("CoefficientsTrimmingProcessing entered");
		Future future = null;
		double[][] arrayOfDouble = (double[][])null;
		b_Conflict.info("----------------Run numbers : " + parama.Z);
		try
		{
		  this.D_Conflict = paramb;
		  future = e(this.O, parama);
		  b_Conflict.info("begin DSP Coefficients Trimming...");
		  arrayOfDouble = (double[][])future.get();
		  b_Conflict.info("end DSP Coefficients Trimming.");
		  long l1 = (long)arrayOfDouble[3][0];
		  this.O.b(i_Conflict.fH.a(), l1, k_Conflict.fH.a(), j_Conflict.fH.a());
		  long l2 = (long)arrayOfDouble[4][0];
		  this.O.b(i_Conflict.fI.a(), l2, k_Conflict.fI.a(), j_Conflict.fI.a());
		  long l3 = (long)arrayOfDouble[6][0];
		  this.O.b(i_Conflict.cC.a(), l3, k_Conflict.cC.a(), j_Conflict.cC.a());
		  long l4 = (long)arrayOfDouble[8][0];
		  this.O.b(i_Conflict.dl.a(), l4, k_Conflict.dl.a(), j_Conflict.dl.a());
		  long l5 = (long)arrayOfDouble[10][0];
		  this.O.b(i_Conflict.dg.a(), l5, k_Conflict.dg.a(), j_Conflict.dg.a());
		  long l6 = (long)arrayOfDouble[11][0];
		  this.O.b(i_Conflict.ds.a(), l6, k_Conflict.ds.a(), j_Conflict.ds.a());
		  long l7 = (long)arrayOfDouble[13][0];
		  this.O.b(i_Conflict.dj.a(), l7, k_Conflict.dj.a(), j_Conflict.dj.a());
		  long l8 = (long)arrayOfDouble[2][0];
		  this.O.b(i_Conflict.di.a(), l8, k_Conflict.di.a(), j_Conflict.di.a());
		  b_Conflict.info("CoefficientsTrimmingProcessing finished");
		  return arrayOfDouble;
		}
		catch (InterruptedException interruptedException)
		{
		  b_Conflict.error("CoefficientsTrimmingProcessing throw exception : " + interruptedException.Message);
		  throw new p2AppManagerException("Failed to get thread data  ", p2Enumerations.p2AppManagerStatus.UNKNOWN_ERROR.NumVal);
		}
		catch (Exception exception)
		{
		  b_Conflict.error("CoefficientsTrimmingProcessing throw exception : " + exception.Message);
		  if (exception.InnerException is p2AppManagerException)
		  {
			throw (p2AppManagerException)exception.InnerException;
		  }
		  throw new p2AppManagerException("Failed to get thread data  ", p2Enumerations.p2AppManagerStatus.UNKNOWN_ERROR.NumVal);
		}
	  }

	  private double[][] d(a parama, b paramb)
	  {
		b_Conflict.info("PhaseTrimmingStreamingProcessing entered");
		Future future1 = null;
		Future future2 = null;
		int[][] arrayOfInt1 = (int[][])null;
		int[][] arrayOfInt2 = (int[][])null;
		double[][] arrayOfDouble = (double[][])null;
		double d1 = parama.P;
		sbyte b1;
		for (b1 = 0; d1 <= parama.Q; b1++)
		{
		  d1 += parama.R;
		}
		double[] arrayOfDouble1 = new double[b1];
		double[] arrayOfDouble2 = new double[b1];
		double[] arrayOfDouble3 = new double[b1];
		d1 = parama.P;
		for (b1 = 0; d1 <= parama.Q; b1++)
		{
		  arrayOfDouble1[b1] = d1;
		  d1 += parama.R;
		}
		b_Conflict.info("----------------Run numbers : " + parama.Z);
		try
		{
		  long l1 = this.O.b(i_Conflict.cD.a(), k_Conflict.cD.a(), j_Conflict.cD.a());
		  double d2 = l1 * 50.0D * Math.Pow(10.0D, 3.0D) / Math.Pow(2.0D, 14.0D);
		  for (sbyte b2 = 0; b2 < arrayOfDouble1.Length; b2++)
		  {
			double[][] arrayOfDouble7 = p2SpectroDSP.a().a(arrayOfDouble1[b2], d2);
			double d3 = arrayOfDouble7[0][0];
			this.O.b(i_Conflict.k.a(), 1L, k_Conflict.k.a(), j_Conflict.k.a());
			this.O.b(i_Conflict.di.a(), (long)d3, k_Conflict.di.a(), j_Conflict.di.a());
			this.O.b(i_Conflict.k.a(), 0L, k_Conflict.k.a(), j_Conflict.k.a());
			long l2 = this.O.b(i_Conflict.dj.a(), k_Conflict.dj.a(), j_Conflict.dj.a());
			this.O.b(i_Conflict.dj.a(), l2 * (int)paramb.b()[48], k_Conflict.dj.a(), j_Conflict.dj.a());
			try
			{
			  Thread.Sleep(500L);
			}
			catch (InterruptedException)
			{
			}
			this.O.b(i_Conflict.dj.a(), l2, k_Conflict.dj.a(), j_Conflict.dj.a());
			try
			{
			  Thread.Sleep(800L);
			}
			catch (InterruptedException)
			{
			}
			future1 = a(this.O, parama);
			b_Conflict.info("begin streaming CAPLPF process...");
			arrayOfInt1 = (int[][])future1.get();
			b_Conflict.info("end streaming CAPLPF process.");
			future1 = c(this.O, parama);
			b_Conflict.info("begin streaming AACOUT process...");
			arrayOfInt2 = (int[][])future1.get();
			double d4 = arrayOfInt2[0][0];
			double d5 = arrayOfInt2[0][0];
			for (sbyte b4 = 0; b4 < arrayOfInt2[0].Length; b4++)
			{
			  if (arrayOfInt2[0][b4] > d4)
			  {
				d4 = arrayOfInt2[0][b4];
			  }
			  if (arrayOfInt2[0][b4] < d5)
			  {
				d5 = arrayOfInt2[0][b4];
			  }
			}
			b_Conflict.info("end streaming AACOUT process.");
			this.D_Conflict = paramb;
			future2 = a(this.O, arrayOfInt1, arrayOfInt2, parama);
			b_Conflict.info("begin DSP Phase trimming...");
			arrayOfDouble = (double[][])future2.get();
			arrayOfDouble2[b2] = arrayOfDouble[0][0];
			arrayOfDouble3[b2] = d4 - d5;
			b_Conflict.info("end DSP Phase trimming.");
		  }
		  double[][] arrayOfDouble4 = p2SpectroDSP.a().a(arrayOfDouble1, arrayOfDouble3, arrayOfDouble2);
		  double[][] arrayOfDouble5 = p2SpectroDSP.a().a(arrayOfDouble4[0][0], d2);
		  this.O.b(i_Conflict.di.a(), (long)arrayOfDouble5[0][0], k_Conflict.di.a(), j_Conflict.di.a());
		  b_Conflict.info("PhaseTrimmingStreamingProcessing finished");
		  for (sbyte b3 = 0; b3 < arrayOfDouble4[2].Length; b3++)
		  {
			arrayOfDouble4[2][b3] = arrayOfDouble4[2][b3] / this.D_Conflict.b()[44];
		  }
		  double[][] arrayOfDouble6 = new double[3][];
		  arrayOfDouble6[0] = arrayOfDouble4[1];
		  arrayOfDouble6[1] = arrayOfDouble4[2];
		  arrayOfDouble6[2] = arrayOfDouble4[0];
		  return arrayOfDouble6;
		}
		catch (InterruptedException interruptedException)
		{
		  b_Conflict.error("PhaseTrimmingStreamingProcessing throw exception : " + interruptedException.Message);
		  throw new p2AppManagerException("Failed to get thread data  ", p2Enumerations.p2AppManagerStatus.UNKNOWN_ERROR.NumVal);
		}
		catch (Exception exception)
		{
		  b_Conflict.error("PhaseTrimmingStreamingProcessing throw exception : " + exception.Message);
		  if (exception.InnerException is p2AppManagerException)
		  {
			throw (p2AppManagerException)exception.InnerException;
		  }
		  throw new p2AppManagerException("Failed to get thread data  ", p2Enumerations.p2AppManagerStatus.UNKNOWN_ERROR.NumVal);
		}
	  }

	  private double[][] e(a parama, b paramb)
	  {
		b_Conflict.info("FastPhaseTrimmingStreamingProcessing entered");
		Future future1 = null;
		Future future2 = null;
		int[][] arrayOfInt1 = (int[][])null;
		int[][] arrayOfInt2 = (int[][])null;
		double[][] arrayOfDouble = (double[][])null;
		sbyte b1 = 3;
		double[] arrayOfDouble1 = new double[b1];
		double[] arrayOfDouble2 = new double[b1];
		double[] arrayOfDouble3 = new double[b1];
		arrayOfDouble1[0] = parama.S;
		arrayOfDouble1[1] = parama.T;
		arrayOfDouble1[2] = parama.U;
		b_Conflict.info("----------------Run numbers : " + parama.Z);
		try
		{
		  long l1 = this.O.b(i_Conflict.cD.a(), k_Conflict.cD.a(), j_Conflict.cD.a());
		  double d1 = l1 * 50.0D * Math.Pow(10.0D, 3.0D) / Math.Pow(2.0D, 14.0D);
		  for (sbyte b2 = 0; b2 < arrayOfDouble1.Length; b2++)
		  {
			Console.WriteLine("New phase value = " + arrayOfDouble1[b2]);
			double[][] arrayOfDouble7 = p2SpectroDSP.a().a(arrayOfDouble1[b2], d1);
			double d2 = arrayOfDouble7[0][0];
			this.O.b(i_Conflict.k.a(), 1L, k_Conflict.k.a(), j_Conflict.k.a());
			this.O.b(i_Conflict.di.a(), (long)d2, k_Conflict.di.a(), j_Conflict.di.a());
			this.O.b(i_Conflict.k.a(), 0L, k_Conflict.k.a(), j_Conflict.k.a());
			long l2 = this.O.b(i_Conflict.dj.a(), k_Conflict.dj.a(), j_Conflict.dj.a());
			this.O.b(i_Conflict.dj.a(), l2 * (int)paramb.b()[48], k_Conflict.dj.a(), j_Conflict.dj.a());
			try
			{
			  Thread.Sleep(500L);
			}
			catch (InterruptedException)
			{
			}
			this.O.b(i_Conflict.dj.a(), l2, k_Conflict.dj.a(), j_Conflict.dj.a());
			try
			{
			  Thread.Sleep(800L);
			}
			catch (InterruptedException)
			{
			}
			future1 = a(this.O, parama);
			b_Conflict.info("begin streaming CAPLPF process...");
			arrayOfInt1 = (int[][])future1.get();
			b_Conflict.info("end streaming CAPLPF process.");
			future1 = c(this.O, parama);
			b_Conflict.info("begin streaming AACOUT process...");
			arrayOfInt2 = (int[][])future1.get();
			double d3 = arrayOfInt2[0][0];
			double d4 = arrayOfInt2[0][0];
			for (sbyte b4 = 0; b4 < arrayOfInt2[0].Length; b4++)
			{
			  if (arrayOfInt2[0][b4] > d3)
			  {
				d3 = arrayOfInt2[0][b4];
			  }
			  if (arrayOfInt2[0][b4] < d4)
			  {
				d4 = arrayOfInt2[0][b4];
			  }
			}
			b_Conflict.info("end streaming AACOUT process.");
			this.D_Conflict = paramb;
			future2 = a(this.O, arrayOfInt1, arrayOfInt2, parama);
			b_Conflict.info("begin DSP Phase trimming...");
			arrayOfDouble = (double[][])future2.get();
			arrayOfDouble2[b2] = arrayOfDouble[0][0];
			arrayOfDouble3[b2] = d3 - d4;
			if (arrayOfDouble2[b2] != 1.0D)
			{
			  Console.WriteLine("Phase isn't stable for value = " + arrayOfDouble1[b2]);
			  if (!b2 || b2 == 1)
			  {
				arrayOfDouble1[b2] = arrayOfDouble1[b2] + parama.R;
			  }
			  else
			  {
				arrayOfDouble1[b2] = arrayOfDouble1[b2] - parama.R;
			  }
			  b2--;
			}
			else
			{
			  Console.WriteLine("Phase is stable for value = " + arrayOfDouble1[b2]);
			}
			b_Conflict.info("end DSP Phase trimming.");
		  }
		  double[][] arrayOfDouble4 = p2SpectroDSP.a().a(arrayOfDouble1, arrayOfDouble3);
		  double[][] arrayOfDouble5 = p2SpectroDSP.a().a(arrayOfDouble4[0][0], d1);
		  this.O.b(i_Conflict.di.a(), (long)arrayOfDouble5[0][0], k_Conflict.di.a(), j_Conflict.di.a());
		  b_Conflict.info("FastPhaseTrimmingStreamingProcessing finished");
		  for (sbyte b3 = 0; b3 < arrayOfDouble4[2].Length; b3++)
		  {
			arrayOfDouble4[2][b3] = arrayOfDouble4[2][b3] / this.D_Conflict.b()[44];
		  }
		  double[][] arrayOfDouble6 = new double[3][];
		  arrayOfDouble6[0] = arrayOfDouble4[1];
		  arrayOfDouble6[1] = arrayOfDouble4[2];
		  arrayOfDouble6[2] = arrayOfDouble4[0];
		  return arrayOfDouble6;
		}
		catch (InterruptedException interruptedException)
		{
		  b_Conflict.error("FastPhaseTrimmingStreamingProcessing throw exception : " + interruptedException.Message);
		  throw new p2AppManagerException("Failed to get thread data  ", p2Enumerations.p2AppManagerStatus.UNKNOWN_ERROR.NumVal);
		}
		catch (Exception exception)
		{
		  b_Conflict.error("FastPhaseTrimmingStreamingProcessing throw exception : " + exception.Message);
		  if (exception.InnerException is p2AppManagerException)
		  {
			throw (p2AppManagerException)exception.InnerException;
		  }
		  throw new p2AppManagerException("Failed to get thread data  ", p2Enumerations.p2AppManagerStatus.UNKNOWN_ERROR.NumVal);
		}
	  }

	  private double[][] f(a parama, b paramb)
	  {
		b_Conflict.info("StabilityCheckStreamingProcessing entered");
		Future future1 = null;
		Future future2 = null;
		int[][] arrayOfInt1 = (int[][])null;
		int[][] arrayOfInt2 = (int[][])null;
		double[][] arrayOfDouble1 = (double[][])null;
		double[][] arrayOfDouble2 = (double[][])null;
		b_Conflict.info("----------------Run numbers : " + parama.Z);
		try
		{
		  p2SpectroDSP.a().a(this.D_Conflict.b());
		  future1 = a(this.O, parama);
		  b_Conflict.info("begin streaming CAPLPF process...");
		  arrayOfInt1 = (int[][])future1.get();
		  b_Conflict.info("end streaming CAPLPF process.");
		  future1 = c(this.O, parama);
		  b_Conflict.info("begin streaming AACOUT process...");
		  arrayOfInt2 = (int[][])future1.get();
		  b_Conflict.info("end streaming AACOUT process.");
		  this.D_Conflict = paramb;
		  future2 = b(this.O, arrayOfInt1, arrayOfInt2, parama);
		  b_Conflict.info("begin DSP Stability Check...");
		  arrayOfDouble1 = (double[][])future2.get();
		  b_Conflict.info("end DSP Stability Check.");
		  int i1 = 0;
		  int i2 = 0;
		  sbyte b1 = 1;
		  long l1 = this.O.b(i_Conflict.ds.a(), k_Conflict.ds.a(), j_Conflict.ds.a());
		  double d1 = p2SpectroDSP.a().a(l1);
		  while (!i1 && !i2)
		  {
			future1 = a(this.O, parama);
			b_Conflict.info("begin streaming CAPLPF process...");
			arrayOfInt1 = (int[][])future1.get();
			b_Conflict.info("end streaming CAPLPF process.");
			future2 = a(this.O, arrayOfInt1, b1, d1, parama);
			b_Conflict.info("begin DSP Stability Check...");
			arrayOfDouble2 = (double[][])future2.get();
			b_Conflict.info("end DSP Stability Check.");
			d1 = arrayOfDouble2[0][0];
			l1 = (long)arrayOfDouble2[2][0];
			i1 = (int)arrayOfDouble2[3][0];
			i2 = (int)arrayOfDouble2[4][0];
			this.O.b(i_Conflict.ds.a(), l1, k_Conflict.ds.a(), j_Conflict.ds.a());
			b1++;
		  }
//JAVA TO C# CONVERTER NOTE: The following call to the 'RectangularArrays' helper class reproduces the rectangular array initialization that is automatic in Java:
//ORIGINAL LINE: double[][] arrayOfDouble = new double[arrayOfDouble1.Length + arrayOfDouble2.Length][1];
		  double[][] arrayOfDouble = RectangularArrays.RectangularDoubleArray(arrayOfDouble1.Length + arrayOfDouble2.Length, 1);
		  int i3;
		  for (i3 = 0; i3 < arrayOfDouble1.Length; i3++)
		  {
			arrayOfDouble[i3][0] = arrayOfDouble1[i3][0];
		  }
		  i3 = arrayOfDouble1.Length;
		  for (sbyte b2 = 0; b2 < arrayOfDouble2.Length; b2++)
		  {
			arrayOfDouble[i3][0] = arrayOfDouble2[b2][0];
			i3++;
		  }
		  b_Conflict.info("StabilityCheckStreamingProcessing finished");
		  return arrayOfDouble;
		}
		catch (InterruptedException interruptedException)
		{
		  b_Conflict.error("StabilityCheckStreamingProcessing throw exception : " + interruptedException.Message);
		  throw new p2AppManagerException("Failed to get thread data  ", p2Enumerations.p2AppManagerStatus.UNKNOWN_ERROR.NumVal);
		}
		catch (Exception exception)
		{
		  b_Conflict.error("StabilityCheckStreamingProcessing throw exception : " + exception.Message);
		  if (exception.InnerException is p2AppManagerException)
		  {
			throw (p2AppManagerException)exception.InnerException;
		  }
		  throw new p2AppManagerException("Failed to get thread data  ", p2Enumerations.p2AppManagerStatus.UNKNOWN_ERROR.NumVal);
		}
	  }

	  private double[][] g(a parama, b paramb)
	  {
		b_Conflict.info("capCurrentStreamingProcessing entered");
		Future future1 = null;
		Future future2 = null;
		int[][] arrayOfInt = (int[][])null;
		double[][] arrayOfDouble = (double[][])null;
		b_Conflict.info("----------------Run numbers : " + parama.Z);
		try
		{
		  p2SpectroDSP.a().a(this.D_Conflict.b());
		  if (parama.W == 0)
		  {
			future1 = a(this.O, parama);
		  }
		  else if (parama.W == 1)
		  {
			future1 = c(this.O, parama);
		  }
		  else if (parama.W == 2)
		  {
			future1 = b(this.O, parama);
		  }
		  b_Conflict.info("begin streaming process...");
		  arrayOfInt = (int[][])future1.get();
		  b_Conflict.info("end streaming process.");
		  this.D_Conflict = paramb;
		  if (parama.W == 0)
		  {
			future2 = e(this.O, arrayOfInt, parama);
			b_Conflict.info("begin DSP process...");
			arrayOfDouble = (double[][])future2.get();
			b_Conflict.info("end DSP process.");
			b_Conflict.info("capCurrentStreamingProcessing finished");
		  }
		  else if (parama.W == 1)
		  {
			double[][] arrayOfDouble1 = {new double[arrayOfInt[0].Length], new double[arrayOfInt[0].Length]};
			for (sbyte b1 = 0; b1 < arrayOfInt[0].Length; b1++)
			{
			  arrayOfDouble1[0][b1] = b1 * parama.ac / arrayOfInt[0].Length;
			  arrayOfDouble1[1][b1] = arrayOfInt[0][b1] / this.D_Conflict.b()[44];
			}
			arrayOfDouble = arrayOfDouble1;
		  }
		  else
		  {
			double[][] arrayOfDouble1 = {new double[arrayOfInt[0].Length], new double[arrayOfInt[0].Length]};
			for (sbyte b1 = 0; b1 < arrayOfInt[0].Length; b1++)
			{
			  arrayOfDouble1[0][b1] = b1 * parama.ac / arrayOfInt[0].Length;
			  arrayOfDouble1[1][b1] = arrayOfInt[0][b1] / Math.Pow(2.0D, 20.0D);
			}
			arrayOfDouble = arrayOfDouble1;
		  }
		  return arrayOfDouble;
		}
		catch (InterruptedException interruptedException)
		{
		  b_Conflict.error("capCurrentStreamingProcessing throw exception : " + interruptedException.Message);
		  throw new p2AppManagerException("Failed to get thread data  ", p2Enumerations.p2AppManagerStatus.UNKNOWN_ERROR.NumVal);
		}
		catch (Exception exception)
		{
		  b_Conflict.error("capCurrentStreamingProcessing throw exception : " + exception.Message);
		  if (exception.InnerException is p2AppManagerException)
		  {
			throw (p2AppManagerException)exception.InnerException;
		  }
		  throw new p2AppManagerException("Failed to get thread data  ", p2Enumerations.p2AppManagerStatus.UNKNOWN_ERROR.NumVal);
		}
	  }

	  private double[][] h(a parama, b paramb)
	  {
		b_Conflict.info("capCurrentStreamingProcessing entered");
		Future future1 = null;
		Future future2 = null;
		int[][] arrayOfInt = (int[][])null;
		double[][] arrayOfDouble = (double[][])null;
		b_Conflict.info("----------------Run numbers : " + parama.Z);
		try
		{
		  future1 = a(this.O, parama);
		  b_Conflict.info("begin streaming process...");
		  arrayOfInt = (int[][])future1.get();
		  b_Conflict.info("end streaming process.");
		  this.D_Conflict = paramb;
		  future2 = e(this.O, arrayOfInt, parama);
		  b_Conflict.info("begin DSP process...");
		  arrayOfDouble = (double[][])future2.get();
		  b_Conflict.info("end DSP process.");
		  b_Conflict.info("capCurrentStreamingProcessing finished");
		  return arrayOfDouble;
		}
		catch (InterruptedException interruptedException)
		{
		  b_Conflict.error("capCurrentStreamingProcessing throw exception : " + interruptedException.Message);
		  throw new p2AppManagerException("Failed to get thread data  ", p2Enumerations.p2AppManagerStatus.UNKNOWN_ERROR.NumVal);
		}
		catch (Exception exception)
		{
		  b_Conflict.error("capCurrentStreamingProcessing throw exception : " + exception.Message);
		  if (exception.InnerException is p2AppManagerException)
		  {
			throw (p2AppManagerException)exception.InnerException;
		  }
		  throw new p2AppManagerException("Failed to get thread data  ", p2Enumerations.p2AppManagerStatus.UNKNOWN_ERROR.NumVal);
		}
	  }

	  private double[] i(a parama, b paramb)
	  {
		b_Conflict.info("capTimeCalibrationStreamingProcessing entered");
		Future future1 = null;
		Future future2 = null;
		int[][] arrayOfInt = (int[][])null;
		null = null;
		b_Conflict.info("----------------Run numbers : " + parama.Z);
		try
		{
		  future1 = a(this.O, parama);
		  b_Conflict.info("begin streaming process...");
		  arrayOfInt = (int[][])future1.get();
		  b_Conflict.info("end streaming process.");
		  this.D_Conflict = paramb;
		  future2 = f(this.O, arrayOfInt, parama);
		  b_Conflict.info("begin DSP process...");
		  null = (double[])future2.get();
		  b_Conflict.info("end DSP process.");
		  b_Conflict.info("Extracting settings: INT1_TH_1 = " + (long)null[0]);
		  Console.WriteLine("Extracting settings: INT1_TH_1 = " + (long)null[0]);
		  this.O.b(i_Conflict.be.a(), (long)null[0], k_Conflict.be.a(), j_Conflict.be.a());
		  b_Conflict.info("Extracting settings: INT1_TH_2 = " + (long)null[1]);
		  Console.WriteLine("Extracting settings: INT1_TH_2 = " + (long)null[1]);
		  this.O.b(i_Conflict.bf.a(), (long)null[1], k_Conflict.bf.a(), j_Conflict.bf.a());
		  b_Conflict.info("Extracting settings: INT1_TH_3 = " + (long)null[2]);
		  Console.WriteLine("Extracting settings: INT1_TH_3 = " + (long)null[2]);
		  this.O.b(i_Conflict.bg.a(), (long)null[2], k_Conflict.bg.a(), j_Conflict.bg.a());
		  b_Conflict.info("Extracting settings: INT1_TH_4 = " + (long)null[3]);
		  Console.WriteLine("Extracting settings: INT1_TH_4 = " + (long)null[3]);
		  this.O.b(i_Conflict.bh.a(), (long)null[3], k_Conflict.bh.a(), j_Conflict.bh.a());
		  b_Conflict.info("Extracting settings: INT1_X_INITIAL = " + (long)null[4]);
		  Console.WriteLine("Extracting settings: INT1_X_INITIAL = " + (long)null[4]);
		  this.O.b(i_Conflict.bb.a(), (long)null[4], k_Conflict.bb.a(), j_Conflict.bb.a());
		  b_Conflict.info("Extracting settings: INT1_X_STEP = " + (long)null[5]);
		  Console.WriteLine("Extracting settings: INT1_X_STEP = " + (long)null[5]);
		  this.O.b(i_Conflict.bd.a(), (long)null[5], k_Conflict.bd.a(), j_Conflict.bd.a());
		  b_Conflict.info("Extracting settings: INT1_RAM_SAMPLES = " + parama.v);
		  Console.WriteLine("Extracting settings: INT1_RAM_SAMPLES = " + parama.v);
		  this.O.b(i_Conflict.aW.a(), parama.v, k_Conflict.aW.a(), j_Conflict.aW.a());
		  b_Conflict.info("Extracting settings: INT1_X_DIRECTION = 0");
		  Console.WriteLine("Extracting settings: INT1_X_DIRECTION = 0");
		  this.O.b(i_Conflict.aO.a(), 0L, k_Conflict.aO.a(), j_Conflict.aO.a());
		  b_Conflict.info("Extracting settings: INT2_TH_1 = " + (long)null[0]);
		  Console.WriteLine("Extracting settings: INT2_TH_1 = " + (long)null[0]);
		  this.O.b(i_Conflict.gB.a(), (long)null[0], k_Conflict.gB.a(), j_Conflict.gB.a());
		  b_Conflict.info("Extracting settings: INT2_TH_2 = " + (long)null[1]);
		  Console.WriteLine("Extracting settings: INT2_TH_2 = " + (long)null[1]);
		  this.O.b(i_Conflict.gC.a(), (long)null[1], k_Conflict.gC.a(), j_Conflict.gC.a());
		  b_Conflict.info("Extracting settings: INT2_TH_3 = " + (long)null[2]);
		  Console.WriteLine("Extracting settings: INT2_TH_3 = " + (long)null[2]);
		  this.O.b(i_Conflict.gD.a(), (long)null[2], k_Conflict.gD.a(), j_Conflict.gD.a());
		  b_Conflict.info("Extracting settings: INT2_TH_4 = " + (long)null[3]);
		  Console.WriteLine("Extracting settings: INT2_TH_4 = " + (long)null[3]);
		  this.O.b(i_Conflict.gE.a(), (long)null[3], k_Conflict.gE.a(), j_Conflict.gE.a());
		  b_Conflict.info("Extracting settings: INT2_X_INITIAL = " + (long)null[6]);
		  Console.WriteLine("Extracting settings: INT2_X_INITIAL = " + (long)null[6]);
		  this.O.b(i_Conflict.gy.a(), (long)null[6], k_Conflict.gy.a(), j_Conflict.gy.a());
		  b_Conflict.info("Extracting settings: INT2_X_STEP = " + (long)null[5]);
		  Console.WriteLine("Extracting settings: INT2_X_STEP = " + (long)null[5]);
		  this.O.b(i_Conflict.gA.a(), (long)null[5], k_Conflict.gA.a(), j_Conflict.gA.a());
		  b_Conflict.info("Extracting settings: INT2_RAM_SAMPLES = " + parama.v);
		  Console.WriteLine("Extracting settings: INT2_RAM_SAMPLES = " + parama.v);
		  this.O.b(i_Conflict.gt.a(), parama.v, k_Conflict.gt.a(), j_Conflict.gt.a());
		  b_Conflict.info("Extracting settings: INT2_X_DIRECTION = 1");
		  Console.WriteLine("Extracting settings: INT2_X_DIRECTION = 1");
		  this.O.b(i_Conflict.gl.a(), 1L, k_Conflict.gl.a(), j_Conflict.gl.a());
		  b_Conflict.info("Extracting settings: DMUX10_EN = 0");
		  Console.WriteLine("Extracting settings: DMUX10_EN = 0");
		  this.O.b(i_Conflict.dB.a(), 0L, k_Conflict.dB.a(), j_Conflict.dB.a());
		  b_Conflict.info("Extracting settings: DMUX_EN = 0");
		  Console.WriteLine("Extracting settings: DMUX_EN = 0");
		  this.O.b(i_Conflict.dA.a(), 0L, k_Conflict.dA.a(), j_Conflict.dA.a());
		  return null;
		}
		catch (InterruptedException interruptedException)
		{
		  b_Conflict.error("capTimeCalibrationStreamingProcessing throw exception : " + interruptedException.Message);
		  if (parama.Z == 1)
		  {
			throw new p2AppManagerException("Failed to get thread data  ", p2Enumerations.p2AppManagerStatus.UNKNOWN_ERROR.NumVal);
		  }
		}
		catch (ExecutionException executionException)
		{
		  b_Conflict.error("capTimeCalibrationStreamingProcessing throw exception : " + executionException.Message);
		  if (parama.Z == 1)
		  {
			if (executionException.InnerException is p2AppManagerException)
			{
			  throw (p2AppManagerException)executionException.InnerException;
			}
			throw new p2AppManagerException("Failed to get thread data  ", p2Enumerations.p2AppManagerStatus.UNKNOWN_ERROR.NumVal);
		  }
		}
		catch (a a1)
		{
		  b_Conflict.error("capTimeCalibrationStreamingProcessing throw taif exception : " + a1.Message);
		}
		b_Conflict.info("capTimeCalibrationStreamingProcessing finished");
		arrayOfInt = (int[][])null;
		return null;
	  }

	  private double[] j(a parama, b paramb)
	  {
		b_Conflict.info("delayCompensationCalibrationStreamingProcessing entered");
		Future future1 = null;
		Future future2 = null;
		int[][] arrayOfInt = (int[][])null;
		int[] arrayOfInt1 = null;
		int[] arrayOfInt2 = null;
		null = null;
		int i1 = 512;
		int i2 = 1;
		sbyte b1 = 0;
		bool @bool = true;
		b_Conflict.info("----------------Run numbers : " + parama.Z);
		try
		{
		  sbyte b2 = 0;
		  while (@bool && b2 < 10)
		  {
			future1 = null;
			future2 = null;
			arrayOfInt = (int[][])null;
			arrayOfInt1 = null;
			arrayOfInt2 = null;
			null = null;
			b1 = 0;
			b2++;
			while (b1 < parama.Z)
			{
			  this.O.b(i_Conflict.cB.a(), i1, k_Conflict.cB.a(), j_Conflict.cB.a());
			  this.O.b(i_Conflict.n.a(), 1L, k_Conflict.n.a(), j_Conflict.n.a());
			  this.O.b(i_Conflict.n.a(), 0L, k_Conflict.n.a(), j_Conflict.n.a());
			  b_Conflict.info("----------------Run : " + ++b1 + " started---------------");
			  future1 = d(this.O, parama);
			  b_Conflict.info("begin streaming process...");
			  arrayOfInt = (int[][])future1.get();
			  b_Conflict.info("end streaming process.");
			  if (b1 == 1)
			  {
				arrayOfInt2 = new int[arrayOfInt[0].Length];
				Array.Copy(arrayOfInt[0], 0, arrayOfInt2, 0, arrayOfInt2.Length);
				arrayOfInt1 = new int[arrayOfInt[1].Length];
				Array.Copy(arrayOfInt[1], 0, arrayOfInt1, 0, arrayOfInt1.Length);
			  }
			  else
			  {
				sbyte b4;
				for (b4 = 0; b4 < arrayOfInt[0].Length; b4++)
				{
				  arrayOfInt2[b4] = arrayOfInt2[b4] + arrayOfInt[0][b4];
				}
				for (b4 = 0; b4 < arrayOfInt[1].Length; b4++)
				{
				  arrayOfInt1[b4] = arrayOfInt1[b4] + arrayOfInt[1][b4];
				}
			  }
			  b_Conflict.info("----------------Run : " + b1 + " ended----------------");
			}
			sbyte b3;
			for (b3 = 0; b3 < arrayOfInt2.Length; b3++)
			{
			  arrayOfInt2[b3] = arrayOfInt2[b3] / parama.Z;
			}
			for (b3 = 0; b3 < arrayOfInt1.Length; b3++)
			{
			  arrayOfInt1[b3] = arrayOfInt1[b3] / parama.Z;
			}
			this.D_Conflict = paramb;
			future2 = a(this.O, arrayOfInt1, arrayOfInt2, parama, i1, i2, b2);
			b_Conflict.info("begin DSP process...");
			null = (double[])future2.get();
			i1 = (int)null[0];
			i2 = (int)null[1];
			if (null[2] == 1.0D)
			{
			  @bool = false;
			}
			else
			{
			  @bool = true;
			}
			b_Conflict.info("Delay compensation extraction: delay = " + i1);
			b_Conflict.info("Delay compensation extraction: zpd sign = " + i2);
			b_Conflict.info("Delay compensation extraction: continue iterating = " + @bool);
			Console.WriteLine("Delay compensation extraction: delay = " + i1);
			Console.WriteLine("Delay compensation extraction: zpd sign = " + i2);
			Console.WriteLine("Delay compensation extraction: continue iterating = " + @bool);
			b_Conflict.info("end DSP process.");
		  }
		  if (@bool && b2 == 10)
		  {
			throw new p2AppManagerException("Failed to get valid delay compensation value  ", p2Enumerations.p2AppManagerStatus.DELAY_COMP_MAX_COUNT_ERROR.NumVal);
		  }
		  return null;
		}
		catch (InterruptedException interruptedException)
		{
		  b_Conflict.error("Run no : " + b1 + "throw exception : " + interruptedException.Message);
		  if (parama.Z == 1)
		  {
			throw new p2AppManagerException("Failed to get thread data  ", p2Enumerations.p2AppManagerStatus.UNKNOWN_ERROR.NumVal);
		  }
		}
		catch (Exception exception)
		{
		  b_Conflict.error("Run : " + b1 + " throw exception : " + exception.Message);
		  if (parama.Z == 1)
		  {
			if (exception.InnerException is p2AppManagerException)
			{
			  throw (p2AppManagerException)exception.InnerException;
			}
			throw new p2AppManagerException("Failed to get thread data  ", p2Enumerations.p2AppManagerStatus.UNKNOWN_ERROR.NumVal);
		  }
		}
		b_Conflict.info("delayCompensationCalibrationStreamingProcessing finished");
		arrayOfInt1 = null;
		arrayOfInt = (int[][])null;
		return null;
	  }

	  private void k(a parama, b paramb)
	  {
		b_Conflict.info("CalibrationStreamingProcessing entered");
		Future future1 = null;
		Future future2 = null;
		int[][] arrayOfInt1 = (int[][])null;
		int[][] arrayOfInt2 = (int[][])null;
		int[] arrayOfInt = null;
		sbyte b1 = 0;
		b_Conflict.info("----------------Run numbers : " + parama.Z);
		try
		{
		  while (b1 < parama.Z)
		  {
			b_Conflict.info("----------------Run : " + ++b1 + " started---------------");
			future1 = d(this.O, parama);
			b_Conflict.info("begin streaming process...");
			arrayOfInt1 = (int[][])future1.get();
			b_Conflict.info("end streaming process.");
			if (b1 == 1)
			{
			  arrayOfInt2 = new int[2][];
			  arrayOfInt2[0] = new int[arrayOfInt1[0].Length];
			  arrayOfInt2[1] = new int[arrayOfInt1[1].Length];
			  Array.Copy(arrayOfInt1[0], 0, arrayOfInt2[0], 0, arrayOfInt2[0].Length);
			  Array.Copy(arrayOfInt1[1], 0, arrayOfInt2[1], 0, arrayOfInt2[1].Length);
			}
			else
			{
			  sbyte b3;
			  for (b3 = 0; b3 < arrayOfInt1[0].Length; b3++)
			  {
				arrayOfInt2[0][b3] = arrayOfInt2[0][b3] + arrayOfInt1[0][b3];
			  }
			  for (b3 = 0; b3 < arrayOfInt1[1].Length; b3++)
			  {
				arrayOfInt2[1][b3] = arrayOfInt2[1][b3] + arrayOfInt1[1][b3];
			  }
			}
			b_Conflict.info("----------------Run : " + b1 + " ended----------------");
		  }
		  sbyte b2;
		  for (b2 = 0; b2 < arrayOfInt2[0].Length; b2++)
		  {
			arrayOfInt2[0][b2] = arrayOfInt2[0][b2] / parama.Z;
		  }
		  for (b2 = 0; b2 < arrayOfInt2[1].Length; b2++)
		  {
			arrayOfInt2[1][b2] = arrayOfInt2[1][b2] / parama.Z;
		  }
		  this.D_Conflict = paramb;
		  future2 = a(this.O, arrayOfInt2, parama);
		  b_Conflict.info("begin saving process...");
		  arrayOfInt = (int[])future2.get();
		  b_Conflict.info("end saving process.");
		  if (arrayOfInt[0] != 0)
		  {
			b_Conflict.error("Error occurred during saving readings");
			throw new p2AppManagerException("Failed to save readings  ", p2Enumerations.p2AppManagerStatus.DATA_FILES_SAVING_ERROR.NumVal);
		  }
		}
		catch (InterruptedException interruptedException)
		{
		  b_Conflict.error("Run no : " + b1 + "throw exception : " + interruptedException.Message);
		  if (parama.Z == 1)
		  {
			throw new p2AppManagerException("Failed to get thread data  ", p2Enumerations.p2AppManagerStatus.UNKNOWN_ERROR.NumVal);
		  }
		}
		catch (ExecutionException executionException)
		{
		  b_Conflict.error("Run : " + b1 + " throw exception : " + executionException.Message);
		  if (parama.Z == 1)
		  {
			if (executionException.InnerException is p2AppManagerException)
			{
			  throw (p2AppManagerException)executionException.InnerException;
			}
			throw new p2AppManagerException("Failed to get thread data  ", p2Enumerations.p2AppManagerStatus.UNKNOWN_ERROR.NumVal);
		  }
		}
		b_Conflict.info("CalibrationStreamingProcessing finished");
		arrayOfInt2 = (int[][])null;
		arrayOfInt1 = (int[][])null;
		arrayOfInt = null;
	  }

	  private double[][] l(a parama, b paramb)
	  {
		Future future1 = null;
		Future future2 = null;
		Future future3 = null;
		int[][] arrayOfInt1 = (int[][])null;
		int[][] arrayOfInt2 = (int[][])null;
		double[][] arrayOfDouble1 = (double[][])null;
		double[][] arrayOfDouble2 = (double[][])null;
		double[][] arrayOfDouble3 = new double[parama.ad][];
		double[][] arrayOfDouble4 = new double[parama.ad][];
		sbyte b1 = 0;
		b_Conflict.info("----------------Number of Measurements: " + parama.ad);
		for (b2 = 0; b2 < parama.ad; b2++)
		{
		  b_Conflict.info("----------------Run numbers : " + parama.Z);
		  try
		  {
			b1 = 0;
			while (b1 < parama.Z)
			{
			  b_Conflict.info("----------------Run : " + ++b1 + " started---------------");
			  future1 = d(this.O, parama);
			  b_Conflict.info("begin streaming process...");
			  arrayOfInt1 = (int[][])future1.get();
			  b_Conflict.info("end streaming process.");
			  if (b1 == 1)
			  {
				arrayOfInt2 = new int[2][];
				arrayOfInt2[0] = new int[arrayOfInt1[0].Length];
				arrayOfInt2[1] = new int[arrayOfInt1[1].Length];
				Array.Copy(arrayOfInt1[0], 0, arrayOfInt2[0], 0, arrayOfInt2[0].Length);
				Array.Copy(arrayOfInt1[1], 0, arrayOfInt2[1], 0, arrayOfInt2[1].Length);
			  }
			  else
			  {
				sbyte b4;
				for (b4 = 0; b4 < arrayOfInt1[0].Length; b4++)
				{
				  arrayOfInt2[0][b4] = arrayOfInt2[0][b4] + arrayOfInt1[0][b4];
				}
				for (b4 = 0; b4 < arrayOfInt1[1].Length; b4++)
				{
				  arrayOfInt2[1][b4] = arrayOfInt2[1][b4] + arrayOfInt1[1][b4];
				}
			  }
			  b_Conflict.info("----------------Run : " + b1 + " ended----------------");
			}
			sbyte b3;
			for (b3 = 0; b3 < arrayOfInt2[0].Length; b3++)
			{
			  arrayOfInt2[0][b3] = arrayOfInt2[0][b3] / parama.Z;
			}
			for (b3 = 0; b3 < arrayOfInt2[1].Length; b3++)
			{
			  arrayOfInt2[1][b3] = arrayOfInt2[1][b3] / parama.Z;
			}
			this.D_Conflict = paramb;
			future2 = a(this.O, arrayOfInt2, parama, this.C_Conflict, this.f_Conflict);
			b_Conflict.info("begin DSP process...");
			arrayOfDouble1 = (double[][])future2.get();
			b_Conflict.info("end DSP process.");
			arrayOfDouble3[b2] = new double[arrayOfDouble1[2].Length];
			arrayOfDouble4[b2] = new double[arrayOfDouble1[3].Length];
			Array.Copy(arrayOfDouble1[2], 0, arrayOfDouble3[b2], 0, arrayOfDouble1[2].Length);
			Array.Copy(arrayOfDouble1[3], 0, arrayOfDouble4[b2], 0, arrayOfDouble1[3].Length);
		  }
		  catch (InterruptedException interruptedException)
		  {
			b_Conflict.error("Run no : " + b1 + "throw exception : " + interruptedException.Message);
			throw new p2AppManagerException("Failed to get thread data  ", p2Enumerations.p2AppManagerStatus.UNKNOWN_ERROR.NumVal);
		  }
		  catch (ExecutionException executionException)
		  {
			b_Conflict.error("Run : " + b1 + " throw exception : " + executionException.Message);
			if (executionException.InnerException is p2AppManagerException)
			{
			  throw (p2AppManagerException)executionException.InnerException;
			}
			throw new p2AppManagerException("Failed to get thread data  ", p2Enumerations.p2AppManagerStatus.UNKNOWN_ERROR.NumVal);
		  }
		}
		try
		{
		  future3 = a(parama, this.C_Conflict, arrayOfDouble3[0], arrayOfDouble4);
		  b_Conflict.info("begin SNR DSP process...");
		  arrayOfDouble2 = (double[][])future3.get();
		  b_Conflict.info("end SNR fDSP process.");
		}
		catch (InterruptedException)
		{
		  InterruptedException interruptedException;
		  b_Conflict.error("SNR DSP function throw exception : " + interruptedException.Message);
		  throw new p2AppManagerException("Failed to get thread data  ", p2Enumerations.p2AppManagerStatus.UNKNOWN_ERROR.NumVal);
		}
		catch (ExecutionException)
		{
		  ExecutionException executionException;
		  b_Conflict.error("SNR DSP function throw exception : " + executionException.Message);
		  if (executionException.InnerException is p2AppManagerException)
		  {
			throw (p2AppManagerException)executionException.InnerException;
		  }
		  throw new p2AppManagerException("Failed to get thread data  ", p2Enumerations.p2AppManagerStatus.UNKNOWN_ERROR.NumVal);
		}
		return arrayOfDouble2;
	  }

	  private double[][] m(a parama, b paramb)
	  {
		Future future1 = null;
		Future future2 = null;
		Future future3 = null;
		int[][] arrayOfInt1 = (int[][])null;
		int[][] arrayOfInt2 = (int[][])null;
		double[][] arrayOfDouble1 = (double[][])null;
		double[][] arrayOfDouble2 = (double[][])null;
		double[][] arrayOfDouble3 = new double[parama.ad][];
		double[][] arrayOfDouble4 = new double[parama.ad][];
		double[][] arrayOfDouble5 = new double[parama.ad][];
		sbyte b1 = 0;
		b_Conflict.info("----------------Number of Measurements: " + parama.ad);
		b_Conflict.info("----------------Time Delay between Two Runs: " + parama.ae + " ms");
		for (b2 = 0; b2 < parama.ad; b2++)
		{
		  b_Conflict.info("----------------Run numbers : " + parama.Z);
		  try
		  {
			b1 = 0;
			while (b1 < parama.Z)
			{
			  b_Conflict.info("----------------Run : " + ++b1 + " started---------------");
			  future1 = d(this.O, parama);
			  b_Conflict.info("begin streaming process...");
			  arrayOfInt1 = (int[][])future1.get();
			  b_Conflict.info("end streaming process.");
			  if (b1 == 1)
			  {
				arrayOfInt2 = new int[2][];
				arrayOfInt2[0] = new int[arrayOfInt1[0].Length];
				arrayOfInt2[1] = new int[arrayOfInt1[1].Length];
				Array.Copy(arrayOfInt1[0], 0, arrayOfInt2[0], 0, arrayOfInt2[0].Length);
				Array.Copy(arrayOfInt1[1], 0, arrayOfInt2[1], 0, arrayOfInt2[1].Length);
			  }
			  else
			  {
				sbyte b4;
				for (b4 = 0; b4 < arrayOfInt1[0].Length; b4++)
				{
				  arrayOfInt2[0][b4] = arrayOfInt2[0][b4] + arrayOfInt1[0][b4];
				}
				for (b4 = 0; b4 < arrayOfInt1[1].Length; b4++)
				{
				  arrayOfInt2[1][b4] = arrayOfInt2[1][b4] + arrayOfInt1[1][b4];
				}
			  }
			  b_Conflict.info("----------------Run : " + b1 + " ended----------------");
			}
			sbyte b3;
			for (b3 = 0; b3 < arrayOfInt2[0].Length; b3++)
			{
			  arrayOfInt2[0][b3] = arrayOfInt2[0][b3] / parama.Z;
			}
			for (b3 = 0; b3 < arrayOfInt2[1].Length; b3++)
			{
			  arrayOfInt2[1][b3] = arrayOfInt2[1][b3] / parama.Z;
			}
			this.D_Conflict = paramb;
			future2 = a(this.O, arrayOfInt2, parama, this.C_Conflict, this.f_Conflict);
			b_Conflict.info("begin DSP process...");
			arrayOfDouble1 = (double[][])future2.get();
			b_Conflict.info("end DSP process.");
			arrayOfDouble3[b2] = new double[arrayOfDouble1[2].Length];
			arrayOfDouble4[b2] = new double[arrayOfDouble1[3].Length];
			arrayOfDouble5[b2] = new double[arrayOfDouble1[5].Length];
			Array.Copy(arrayOfDouble1[2], 0, arrayOfDouble3[b2], 0, arrayOfDouble1[2].Length);
			Array.Copy(arrayOfDouble1[3], 0, arrayOfDouble4[b2], 0, arrayOfDouble1[3].Length);
			Array.Copy(arrayOfDouble1[5], 0, arrayOfDouble5[b2], 0, arrayOfDouble1[5].Length);
		  }
		  catch (InterruptedException interruptedException)
		  {
			b_Conflict.error("Run no : " + b1 + "throw exception : " + interruptedException.Message);
			throw new p2AppManagerException("Failed to get thread data  ", p2Enumerations.p2AppManagerStatus.UNKNOWN_ERROR.NumVal);
		  }
		  catch (ExecutionException executionException)
		  {
			b_Conflict.error("Run : " + b1 + " throw exception : " + executionException.Message);
			if (executionException.InnerException is p2AppManagerException)
			{
			  throw (p2AppManagerException)executionException.InnerException;
			}
			throw new p2AppManagerException("Failed to get thread data  ", p2Enumerations.p2AppManagerStatus.UNKNOWN_ERROR.NumVal);
		  }
		  try
		  {
			Thread.Sleep(parama.ae);
		  }
		  catch (InterruptedException interruptedException)
		  {
			b_Conflict.error(interruptedException.Message);
		  }
		}
		try
		{
		  double[] arrayOfDouble = null;
		  arrayOfDouble = p2AppManagerUtils.loadRawDataFile(p2Constants.getPath(p2Constants.STANDARD_CALIBRATORS_FOLDER_PATH) + Path.DirectorySeparatorChar + parama.Y + ".txt");
		  if (arrayOfDouble == null)
		  {
			throw new p2AppManagerException("Failed to load standard calibrator file ", p2Enumerations.p2AppManagerStatus.WHITE_FILE_NOT_EXIST_ERROR.NumVal);
		  }
		  future3 = a(parama, this.C_Conflict, arrayOfDouble3[0], arrayOfDouble4, arrayOfDouble);
		  b_Conflict.info("begin Stability DSP process...");
		  arrayOfDouble2 = (double[][])future3.get();
		  b_Conflict.info("end Stability DSP process.");
		  for (int i1 = 0; i1 < arrayOfDouble5.Length; i1++)
		  {
			Array.Copy(arrayOfDouble5[i1], 0, arrayOfDouble2[1], i1 * arrayOfDouble5[i1].Length, arrayOfDouble5[i1].Length);
		  }
		  arrayOfDouble = null;
		}
		catch (InterruptedException)
		{
		  InterruptedException interruptedException;
		  b_Conflict.error("Stability DSP function throw exception : " + interruptedException.Message);
		  throw new p2AppManagerException("Failed to get thread data  ", p2Enumerations.p2AppManagerStatus.UNKNOWN_ERROR.NumVal);
		}
		catch (ExecutionException)
		{
		  ExecutionException executionException;
		  b_Conflict.error("Stability DSP function throw exception : " + executionException.Message);
		  if (executionException.InnerException is p2AppManagerException)
		  {
			throw (p2AppManagerException)executionException.InnerException;
		  }
		  throw new p2AppManagerException("Failed to get thread data  ", p2Enumerations.p2AppManagerStatus.UNKNOWN_ERROR.NumVal);
		}
		return arrayOfDouble2;
	  }

	  private double[][] n(a parama, b paramb)
	  {
		Future future1 = null;
		Future future2 = null;
		int[][] arrayOfInt1 = (int[][])null;
		int[][] arrayOfInt2 = (int[][])null;
		double[][] arrayOfDouble = (double[][])null;
		sbyte b1 = 0;
		b_Conflict.info("----------------Run numbers : " + parama.Z);
		try
		{
		  while (b1 < parama.Z)
		  {
			b_Conflict.info("----------------Run : " + ++b1 + " started---------------");
			future1 = d(this.O, parama);
			b_Conflict.info("begin streaming process...");
			arrayOfInt1 = (int[][])future1.get();
			b_Conflict.info("end streaming process.");
			if (b1 == 1)
			{
			  arrayOfInt2 = new int[2][];
			  arrayOfInt2[0] = new int[arrayOfInt1[0].Length];
			  arrayOfInt2[1] = new int[arrayOfInt1[1].Length];
			  Array.Copy(arrayOfInt1[0], 0, arrayOfInt2[0], 0, arrayOfInt2[0].Length);
			  Array.Copy(arrayOfInt1[1], 0, arrayOfInt2[1], 0, arrayOfInt2[1].Length);
			}
			else
			{
			  sbyte b3;
			  for (b3 = 0; b3 < arrayOfInt1[0].Length; b3++)
			  {
				arrayOfInt2[0][b3] = arrayOfInt2[0][b3] + arrayOfInt1[0][b3];
			  }
			  for (b3 = 0; b3 < arrayOfInt1[1].Length; b3++)
			  {
				arrayOfInt2[1][b3] = arrayOfInt2[1][b3] + arrayOfInt1[1][b3];
			  }
			}
			b_Conflict.info("----------------Run : " + b1 + " ended----------------");
		  }
		  sbyte b2;
		  for (b2 = 0; b2 < arrayOfInt2[0].Length; b2++)
		  {
			arrayOfInt2[0][b2] = arrayOfInt2[0][b2] / parama.Z;
		  }
		  for (b2 = 0; b2 < arrayOfInt2[1].Length; b2++)
		  {
			arrayOfInt2[1][b2] = arrayOfInt2[1][b2] / parama.Z;
		  }
		  this.x_Conflict = new double[arrayOfInt2.Length][];
		  for (b2 = 0; b2 < this.x_Conflict.Length; b2++)
		  {
			this.x_Conflict[b2] = new double[arrayOfInt2[b2].Length];
			for (sbyte b3 = 0; b3 < this.x_Conflict[b2].Length; b3++)
			{
			  this.x_Conflict[b2][b3] = arrayOfInt2[b2][b3];
			}
		  }
		  this.D_Conflict = paramb;
		  if (p2Enumerations.p2AppManagerState.wavelengthCalibration_Run == parama.a)
		  {
			future2 = a(this.O, arrayOfInt2, parama, this.C_Conflict, this.g_Conflict);
		  }
		  else
		  {
			future2 = a(this.O, arrayOfInt2, parama, this.C_Conflict, this.f_Conflict);
		  }
		  b_Conflict.info("begin DSP process...");
		  arrayOfDouble = (double[][])future2.get();
		  b_Conflict.info("end DSP process.");
		  return arrayOfDouble;
		}
		catch (InterruptedException interruptedException)
		{
		  b_Conflict.error("Run no : " + b1 + "throw exception : " + interruptedException.Message);
		  throw new p2AppManagerException("Failed to get thread data  ", p2Enumerations.p2AppManagerStatus.UNKNOWN_ERROR.NumVal);
		}
		catch (ExecutionException executionException)
		{
		  b_Conflict.error("Run : " + b1 + " throw exception : " + executionException.Message);
		  if (executionException.InnerException is p2AppManagerException)
		  {
			throw (p2AppManagerException)executionException.InnerException;
		  }
		  throw new p2AppManagerException("Failed to get thread data  ", p2Enumerations.p2AppManagerStatus.UNKNOWN_ERROR.NumVal);
		}
	  }

	  private double[][] o(a parama, b paramb)
	  {
		Future future = null;
		int[][] arrayOfInt1 = (int[][])null;
		int[][] arrayOfInt2 = (int[][])null;
		double[][] arrayOfDouble = (double[][])null;
		sbyte b1 = 0;
		b_Conflict.info("----------------Run numbers : " + parama.Z);
		try
		{
		  while (b1 < parama.Z)
		  {
			b_Conflict.info("----------------Run : " + ++b1 + " started---------------");
			future = d(this.O, parama);
			b_Conflict.info("begin streaming process...");
			arrayOfInt1 = (int[][])future.get();
			b_Conflict.info("end streaming process.");
			arrayOfDouble = new double[2][];
			arrayOfDouble[0] = new double[arrayOfInt1[0].Length];
			arrayOfDouble[1] = new double[arrayOfInt1[1].Length];
			if (b1 == 1)
			{
			  arrayOfInt2 = new int[2][];
			  arrayOfInt2[0] = new int[arrayOfInt1[0].Length];
			  arrayOfInt2[1] = new int[arrayOfInt1[1].Length];
			  Array.Copy(arrayOfInt1[0], 0, arrayOfInt2[0], 0, arrayOfInt2[0].Length);
			  Array.Copy(arrayOfInt1[1], 0, arrayOfInt2[1], 0, arrayOfInt2[1].Length);
			}
			else
			{
			  sbyte b3;
			  for (b3 = 0; b3 < arrayOfInt1[0].Length; b3++)
			  {
				arrayOfInt2[0][b3] = arrayOfInt2[0][b3] + arrayOfInt1[0][b3];
			  }
			  for (b3 = 0; b3 < arrayOfInt1[1].Length; b3++)
			  {
				arrayOfInt2[1][b3] = arrayOfInt2[1][b3] + arrayOfInt1[1][b3];
			  }
			}
			b_Conflict.info("----------------Run : " + b1 + " ended----------------");
		  }
		  sbyte b2;
		  for (b2 = 0; b2 < arrayOfInt2[0].Length; b2++)
		  {
			arrayOfDouble[0][b2] = arrayOfInt2[0][b2] / parama.Z;
		  }
		  for (b2 = 0; b2 < arrayOfInt2[1].Length; b2++)
		  {
			arrayOfDouble[1][b2] = arrayOfInt2[1][b2] / parama.Z;
		  }
		  return arrayOfDouble;
		}
		catch (InterruptedException interruptedException)
		{
		  b_Conflict.error("Run no : " + b1 + "throw exception : " + interruptedException.Message);
		  throw new p2AppManagerException("Failed to get thread data  ", p2Enumerations.p2AppManagerStatus.UNKNOWN_ERROR.NumVal);
		}
		catch (ExecutionException executionException)
		{
		  b_Conflict.error("Run : " + b1 + " throw exception : " + executionException.Message);
		  if (executionException.InnerException is p2AppManagerException)
		  {
			throw (p2AppManagerException)executionException.InnerException;
		  }
		  throw new p2AppManagerException("Failed to get thread data  ", p2Enumerations.p2AppManagerStatus.UNKNOWN_ERROR.NumVal);
		}
	  }

	  private Future<int[][]> a(a parama, a parama1)
	  {
		  return c_Conflict.a(new aAnonymousInnerClass26(this, parama, parama1));
	  }

	  private class aAnonymousInnerClass26 : a<int[][]>
	  {
		  private readonly b outerInstance;

		  public aAnonymousInnerClass26(b outerInstance, sws.p2AppManager.b.a parama, sws.p2AppManager.b.a parama1) : base(outerInstance, parama, parama1)
		  {
			  this.outerInstance = outerInstance;
		  }

		  protected internal int[][] a()
		  {
			try
			{
			  return this.a.d(15, this.b.g, (int)this.b.ac);
			}
			catch (a)
			{
			  throw new p2AppManagerException("Failed to stream the data   ", p2Enumerations.p2AppManagerStatus.DATA_STREAMING_TAIF_ERROR.NumVal);
			}
			catch (Exception)
			{
			  throw new p2AppManagerException("Failed to stream the data   ", p2Enumerations.p2AppManagerStatus.DATA_STREAMING_ERROR.NumVal);
			}
		  }
	  }

	  private Future<int[][]> b(a parama, a parama1)
	  {
		  if (!InstanceFieldsInitialized)
		  {
			  InitializeInstanceFields();
			  InstanceFieldsInitialized = true;
		  }
		  return c_Conflict.a(new aAnonymousInnerClass27(this, parama, parama1));
	  }

	  private class aAnonymousInnerClass27 : a<int[][]>
	  {
		  private readonly b outerInstance;

		  public aAnonymousInnerClass27(b outerInstance, sws.p2AppManager.b.a parama, sws.p2AppManager.b.a parama1) : base(outerInstance, parama, parama1)
		  {
			  this.outerInstance = outerInstance;
		  }

		  protected internal int[][] a()
		  {
			try
			{
			  return this.a.d(23, this.b.g, (int)this.b.ac);
			}
			catch (a)
			{
			  throw new p2AppManagerException("Failed to stream the data   ", p2Enumerations.p2AppManagerStatus.DATA_STREAMING_TAIF_ERROR.NumVal);
			}
			catch (Exception)
			{
			  throw new p2AppManagerException("Failed to stream the data   ", p2Enumerations.p2AppManagerStatus.DATA_STREAMING_ERROR.NumVal);
			}
		  }
	  }

	  private Future<int[][]> c(a parama, a parama1)
	  {
		  return c_Conflict.a(new aAnonymousInnerClass28(this, parama, parama1));
	  }

	  private class aAnonymousInnerClass28 : a<int[][]>
	  {
		  private readonly b outerInstance;

		  public aAnonymousInnerClass28(b outerInstance, sws.p2AppManager.b.a parama, sws.p2AppManager.b.a parama1) : base(outerInstance, parama, parama1)
		  {
			  this.outerInstance = outerInstance;
		  }

		  protected internal int[][] a()
		  {
			try
			{
			  return this.a.d(27, this.b.g, (int)this.b.ac);
			}
			catch (a)
			{
			  throw new p2AppManagerException("Failed to stream the data   ", p2Enumerations.p2AppManagerStatus.DATA_STREAMING_TAIF_ERROR.NumVal);
			}
			catch (Exception)
			{
			  throw new p2AppManagerException("Failed to stream the data   ", p2Enumerations.p2AppManagerStatus.DATA_STREAMING_ERROR.NumVal);
			}
		  }
	  }

	  private Future<int[]> a(a parama, int[][] paramArrayOfInt, a parama1)
	  {
		  return c_Conflict.a(new aAnonymousInnerClass29(this, parama1, paramArrayOfInt));
	  }

	  private class aAnonymousInnerClass29 : a<int[]>
	  {
		  private readonly b outerInstance;

		  public aAnonymousInnerClass29(b outerInstance, sws.p2AppManager.b.a parama1, int[][] paramArrayOfInt) : base(outerInstance, parama1, paramArrayOfInt)
		  {
			  this.outerInstance = outerInstance;
		  }

		  protected internal int[] a()
		  {
			arrayOfInt = new int[] {0};
			bufferedWriter1 = null;
			bufferedWriter2 = null;
			if (!p2AppManagerUtils.createDir(p2Constants.getPath(p2Constants.CALIBRATION_FOLDER_PATH)))
			{
			  throw new p2AppManagerException("Calibration Folder Generation Error", p2Enumerations.p2AppManagerStatus.CALIBRATION_FOLDER_GEN_ERROR.NumVal);
			}
			try
			{
			  if (this.a.x)
			  {
				bufferedWriter1 = new StreamWriter(p2Constants.getPath(p2Constants.LASER_FILE_PATH) + "_1" + ".txt");
				bufferedWriter2 = new StreamWriter(p2Constants.getPath(p2Constants.LASER_FILE_PATH) + "_2" + ".txt");
			  }
			  else if (this.a.y)
			  {
				bufferedWriter1 = new StreamWriter(p2Constants.getPath(p2Constants.WL_FILE_PATH) + "_1" + ".txt");
				bufferedWriter2 = new StreamWriter(p2Constants.getPath(p2Constants.WL_FILE_PATH) + "_2" + ".txt");
			  }
			  else if (this.a.z)
			  {
				bufferedWriter1 = new StreamWriter(p2Constants.getPath(p2Constants.METH_FILE_PATH) + "_1" + ".txt");
				bufferedWriter2 = new StreamWriter(p2Constants.getPath(p2Constants.METH_FILE_PATH) + "_2" + ".txt");
			  }
			  b1 = 0;
			  while (b1 < this.b[0].length)
			  {
				bufferedWriter1.write(Convert.ToString(this.b[0][b1++]));
				bufferedWriter1.write("\n");
			  }
			  b1 = 0;
			  while (b1 < this.b[1].length)
			  {
				bufferedWriter2.write(Convert.ToString(this.b[1][b1++]));
				bufferedWriter2.write("\n");
			  }
			  bufferedWriter1.close();
			  bufferedWriter2.close();
			}
			catch (IOException)
			{
			  arrayOfInt[0] = -1;
			}
			finally
			{
			  try
			  {
				bufferedWriter1.close();
				bufferedWriter2.close();
			  }
			  catch (Exception)
			  {
				arrayOfInt[0] = -1;
			  }
			}
			return arrayOfInt;
		  }
	  }

	  private Future<int[][]> d(a parama, a parama1)
	  {
		  return c_Conflict.a(new aAnonymousInnerClass30(this, parama, parama1));
	  }

	  private class aAnonymousInnerClass30 : a<int[][]>
	  {
		  private readonly b outerInstance;

		  public aAnonymousInnerClass30(b outerInstance, sws.p2AppManager.b.a parama, sws.p2AppManager.b.a parama1) : base(outerInstance, parama, parama1)
		  {
			  this.outerInstance = outerInstance;
		  }

		  protected internal int[][] a()
		  {
			try
			{
			  int[][] arrayOfInt1 = this.a.c(this.b.aa, this.b.ab, (int)this.b.ac);
			  long l = this.a.b(a.i.aW.a(), a.k.aW.a(), a.j.aW.a());
			  int[] arrayOfInt2 = new int[(int)l];
			  Array.Copy(arrayOfInt1[0], 0, arrayOfInt2, 0, (int)l);
			  l = this.a.b(a.i.gt.a(), a.k.gt.a(), a.j.gt.a());
			  int[] arrayOfInt3 = new int[(int)l];
			  Array.Copy(arrayOfInt1[1], 0, arrayOfInt3, 0, (int)l);
			  int[][] arrayOfInt4 = new int[2][];
			  arrayOfInt4[0] = arrayOfInt2;
			  arrayOfInt4[1] = arrayOfInt3;
			  return arrayOfInt4;
			}
			catch (a)
			{
			  throw new p2AppManagerException("Failed to stream the data   ", p2Enumerations.p2AppManagerStatus.DATA_STREAMING_TAIF_ERROR.NumVal);
			}
			catch (Exception)
			{
			  throw new p2AppManagerException("Failed to stream the data   ", p2Enumerations.p2AppManagerStatus.DATA_STREAMING_ERROR.NumVal);
			}
		  }
	  }

	  private Future<double[][]> a(a parama, int[][] paramArrayOfInt, a parama1, c paramc, double[][] paramArrayOfDouble)
	  {
		  return c_Conflict.a(new aAnonymousInnerClass31(this, paramArrayOfInt, paramc, parama1, paramArrayOfDouble));
	  }

	  private class aAnonymousInnerClass31 : a<double[][]>
	  {
		  private readonly b outerInstance;

		  public aAnonymousInnerClass31(b outerInstance, int[][] paramArrayOfInt, c paramc, sws.p2AppManager.b.a parama1, double[][] paramArrayOfDouble) : base(outerInstance, paramArrayOfInt, paramc, parama1, paramArrayOfDouble)
		  {
			  this.outerInstance = outerInstance;
		  }

		  protected internal double[][] a()
		  {
			double[] arrayOfDouble1 = new double[this.a[0].length];
			for (sbyte b1 = 0; b1 < arrayOfDouble1.Length; b1++)
			{
			  arrayOfDouble1[b1] = this.a[0][b1];
			}
			double[] arrayOfDouble2 = new double[this.a[1].length];
			for (sbyte b2 = 0; b2 < arrayOfDouble2.Length; b2++)
			{
			  arrayOfDouble2[b2] = this.a[1][b2];
			}
			double d1 = this.b.b()[19];
			double d2 = this.b.b()[22];
			this.b.b()[19] = this.c_Conflict.af;
			this.b.b()[22] = this.b.b()[22] * this.c_Conflict.ag;
			double[][] arrayOfDouble3 = (double[][])null;
			double[][] arrayOfDouble4 = (double[][])null;
			try
			{
			  if (this.c_Conflict.a == p2Enumerations.p2AppManagerState.StabilityRun)
			  {
				arrayOfDouble3 = p2SpectroDSP.a().a(this.b.b(), this.c_Conflict.aa, this.c_Conflict.ab, this.c_Conflict.d, this.c_Conflict.f, this.b.g(), b.a(this.e_Conflict).i(), b.a(this.e_Conflict).j(), this.b.i(), this.b.h(), this.c_Conflict.e, arrayOfDouble1, arrayOfDouble2);
				arrayOfDouble4 = new double[arrayOfDouble3.Length + 1][];
				for (sbyte b4 = 0; b4 < arrayOfDouble3.Length; b4++)
				{
				  arrayOfDouble4[b4] = new double[arrayOfDouble3[b4].Length];
				  Array.Copy(arrayOfDouble3[b4], 0, arrayOfDouble4[b4], 0, arrayOfDouble3[b4].Length);
				}
				arrayOfDouble4[arrayOfDouble3.Length] = new double[arrayOfDouble3[3].Length];
				Array.Copy(arrayOfDouble3[3], 0, arrayOfDouble4[arrayOfDouble3.Length], 0, arrayOfDouble3[3].Length);
			  }
			  else
			  {
				arrayOfDouble4 = p2SpectroDSP.a().a(this.b.b(), this.c_Conflict.aa, this.c_Conflict.ab, this.c_Conflict.d, this.c_Conflict.f, this.b.g(), b.a(this.e_Conflict).i(), b.a(this.e_Conflict).j(), this.b.i(), this.b.h(), this.c_Conflict.e, arrayOfDouble1, arrayOfDouble2);
			  }
			}
			catch (a)
			{
			  throw new p2AppManagerException("Error while make DSP data interferogram post processing   ", p2Enumerations.p2AppManagerStatus.DSP_INTERFEROGRAM_POST_PROCESSING_ERROR.NumVal);
			}
			if (arrayOfDouble4 == null || arrayOfDouble4[0].Length == 0 || arrayOfDouble4[1].Length == 0 || arrayOfDouble4[2].Length == 0 || arrayOfDouble4[3].Length == 0)
			{
			  throw new p2AppManagerException("Data backed from DSP post processign is empty    ", p2Enumerations.p2AppManagerStatus.DSP_INTERFEROGRAM_POST_EMPTY_DATA_ERROR.NumVal);
			}
			if (arrayOfDouble4.Length < 5)
			{
			  throw new p2AppManagerException("Data backed from DSP post processign lenght not right ", p2Enumerations.p2AppManagerStatus.DSP_INTERFEROGRAM_POST_BAD_DATA_ERROR.NumVal);
			}
			double[] arrayOfDouble5 = arrayOfDouble4[0];
			double[] arrayOfDouble6 = arrayOfDouble4[2];
			double[] arrayOfDouble7 = arrayOfDouble4[4];
			double[] arrayOfDouble8 = arrayOfDouble4[3];
			double[] arrayOfDouble9 = arrayOfDouble4[1];
			string str = Arrays.ToString(arrayOfDouble7);
			string[] arrayOfString = str.Substring(1, (str.Length - 1) - 1).Split(",", true);
			if (!p2AppManagerUtils.writeFileOfArray(arrayOfString, this.b.f(), "\n"))
			{
			  throw new p2AppManagerException("Failed to update corr file   ", p2Enumerations.p2AppManagerStatus.UPDATE_CORR_FILE_ERROR.NumVal);
			}
			bool @bool = b.b(this.e_Conflict, arrayOfDouble9);
			b.a(this.e_Conflict, this.c_Conflict, @bool, this.b, arrayOfDouble5, arrayOfDouble9, arrayOfDouble6, arrayOfDouble8);
			if (this.b.b()[57] != 0.0D)
			{
			  try
			  {
				arrayOfDouble4 = p2SpectroDSP.a().a(this.b.b()[23], this.b.b()[24], (int)this.b.b()[55], arrayOfDouble4);
			  }
			  catch (a)
			  {
				throw new p2AppManagerException("Error while make DSP common wavenumber Generation", p2Enumerations.p2AppManagerStatus.DSP_COMMON_WAVENUMBER_GENERATION_ERROR.NumVal);
			  }
			}
			b.a(this.e_Conflict, this.b.i(), this.c_Conflict, arrayOfDouble4, this.d_Conflict);
			double[][] arrayOfDouble10 = new double[arrayOfDouble4.Length][];
			for (sbyte b3 = 0; b3 < arrayOfDouble4.Length; b3++)
			{
			  arrayOfDouble10[b3] = new double[arrayOfDouble4[b3].Length];
			  Array.Copy(arrayOfDouble4[b3], 0, arrayOfDouble10[b3], 0, arrayOfDouble4[b3].Length);
			}
			this.b.b()[19] = d1;
			this.b.b()[22] = d2;
			arrayOfDouble1 = null;
			arrayOfDouble2 = null;
			System.GC.Collect();
			return arrayOfDouble10;
		  }
	  }

	  private Future<double[][]> a(a parama, c paramc, double[] paramArrayOfDouble, double[][] paramArrayOfDouble1)
	  {
		  return c_Conflict.a(new aAnonymousInnerClass32(this, parama, paramArrayOfDouble, paramArrayOfDouble1, paramc));
	  }

	  private class aAnonymousInnerClass32 : a<double[][]>
	  {
		  private readonly b outerInstance;

		  public aAnonymousInnerClass32(b outerInstance, sws.p2AppManager.b.a parama, double[] paramArrayOfDouble, double[][] paramArrayOfDouble1, c paramc) : base(outerInstance, parama, paramArrayOfDouble, paramArrayOfDouble1, paramc)
		  {
			  this.outerInstance = outerInstance;
		  }

		  protected internal double[][] a()
		  {
			double[][] arrayOfDouble1 = (double[][])null;
			try
			{
			  double d1 = 100.0D * Math.Sqrt(this.a.ac / 2000.0D);
			  arrayOfDouble1 = p2SpectroDSP.a().a(this.b, this.c_Conflict, this.d_Conflict.b()[23], this.d_Conflict.b()[24], 500.0D, (int)Math.Floor((this.b.length / 10)), d1);
			}
			catch (a)
			{
			  throw new p2AppManagerException("Error while calling SNR Measurement DSP function -   ", p2Enumerations.p2AppManagerStatus.DSP_INTERFEROGRAM_POST_PROCESSING_ERROR.NumVal);
			}
			if (arrayOfDouble1 == null || arrayOfDouble1[0].Length == 0 || arrayOfDouble1[1].Length == 0 || arrayOfDouble1[2].Length == 0 || arrayOfDouble1[3].Length == 0 || arrayOfDouble1[4].Length == 0 || arrayOfDouble1[5].Length == 0 || arrayOfDouble1[6].Length == 0 || arrayOfDouble1[7].Length == 0 || arrayOfDouble1[8].Length == 0 || arrayOfDouble1[9].Length == 0 || arrayOfDouble1[10].Length == 0 || arrayOfDouble1[11].Length == 0 || arrayOfDouble1[12].Length == 0 || arrayOfDouble1[13].Length == 0 || arrayOfDouble1[14].Length == 0 || arrayOfDouble1[15].Length == 0 || arrayOfDouble1[16].Length == 0)
			{
			  throw new p2AppManagerException("Data coming back from SNR Measurement DSP  -    ", p2Enumerations.p2AppManagerStatus.DSP_INTERFEROGRAM_POST_EMPTY_DATA_ERROR.NumVal);
			}
			if (arrayOfDouble1.Length < 17)
			{
			  throw new p2AppManagerException("Data coming back from SNR Measurement DSP lenght not right -   ", p2Enumerations.p2AppManagerStatus.DSP_INTERFEROGRAM_POST_BAD_DATA_ERROR.NumVal);
			}
			double[][] arrayOfDouble2 = new double[17][];
			for (sbyte b1 = 0; b1 < 17; b1++)
			{
			  arrayOfDouble2[b1] = new double[arrayOfDouble1[b1].Length];
			  Array.Copy(arrayOfDouble1[b1], 0, arrayOfDouble2[b1], 0, arrayOfDouble1[b1].Length);
			}
			System.GC.Collect();
			return arrayOfDouble2;
		  }
	  }

	  private Future<double[][]> a(a parama, c paramc, double[] paramArrayOfDouble1, double[][] paramArrayOfDouble, double[] paramArrayOfDouble2)
	  {
		  return c_Conflict.a(new aAnonymousInnerClass33(this, paramArrayOfDouble1, paramArrayOfDouble, paramArrayOfDouble2, paramc));
	  }

	  private class aAnonymousInnerClass33 : a<double[][]>
	  {
		  private readonly b outerInstance;

		  public aAnonymousInnerClass33(b outerInstance, double[] paramArrayOfDouble1, double[][] paramArrayOfDouble, double[] paramArrayOfDouble2, c paramc) : base(outerInstance, paramArrayOfDouble1, paramArrayOfDouble, paramArrayOfDouble2, paramc)
		  {
			  this.outerInstance = outerInstance;
		  }

		  protected internal double[][] a()
		  {
			double[][] arrayOfDouble1 = (double[][])null;
			try
			{
			  arrayOfDouble1 = p2SpectroDSP.a().a(this.a, this.b, this.c_Conflict, (int)this.d_Conflict.b()[54]);
			}
			catch (a)
			{
			  throw new p2AppManagerException("Error while calling Stability Measurement DSP function -   ", p2Enumerations.p2AppManagerStatus.DSP_INTERFEROGRAM_POST_PROCESSING_ERROR.NumVal);
			}
			if (arrayOfDouble1 == null || arrayOfDouble1[0].Length == 0 || arrayOfDouble1[1].Length == 0 || arrayOfDouble1[2].Length == 0 || arrayOfDouble1[3].Length == 0 || arrayOfDouble1[4].Length == 0 || arrayOfDouble1[5].Length == 0 || arrayOfDouble1[6].Length == 0 || arrayOfDouble1[7].Length == 0)
			{
			  throw new p2AppManagerException("Data coming back from Stability Measurement DSP  -    ", p2Enumerations.p2AppManagerStatus.DSP_INTERFEROGRAM_POST_EMPTY_DATA_ERROR.NumVal);
			}
			if (arrayOfDouble1.Length < 8)
			{
			  throw new p2AppManagerException("Data coming back from Stability Measurement DSP lenght not right -   ", p2Enumerations.p2AppManagerStatus.DSP_INTERFEROGRAM_POST_BAD_DATA_ERROR.NumVal);
			}
			double[][] arrayOfDouble2 = new double[8][];
			sbyte b1;
			for (b1 = 0; b1 < 8; b1++)
			{
			  arrayOfDouble2[b1] = new double[arrayOfDouble1[b1].Length];
			  Array.Copy(arrayOfDouble1[b1], 0, arrayOfDouble2[b1], 0, arrayOfDouble1[b1].Length);
			}
			for (b1 = 0; b1 < arrayOfDouble2[1].Length; b1++)
			{
			  arrayOfDouble2[1][b1] = arrayOfDouble2[1][b1] * 100.0D;
			}
			System.GC.Collect();
			return arrayOfDouble2;
		  }
	  }

	  private Future<double[][]> b(a parama, int[][] paramArrayOfInt, a parama1)
	  {
		  if (!InstanceFieldsInitialized)
		  {
			  InitializeInstanceFields();
			  InstanceFieldsInitialized = true;
		  }
		  return c_Conflict.a(new aAnonymousInnerClass34(this, paramArrayOfInt));
	  }

	  private class aAnonymousInnerClass34 : a<double[][]>
	  {
		  private readonly b outerInstance;

		  public aAnonymousInnerClass34(b outerInstance, int[][] paramArrayOfInt) : base(outerInstance, paramArrayOfInt)
		  {
			  this.outerInstance = outerInstance;
		  }

		  protected internal double[][] a()
		  {
			double[] arrayOfDouble = new double[this.a[0].length];
			for (sbyte b1 = 0; b1 < arrayOfDouble.Length; b1++)
			{
			  arrayOfDouble[b1] = this.a[0][b1];
			}
			double[][] arrayOfDouble1 = (double[][])null;
			try
			{
			  arrayOfDouble1 = p2SpectroDSP.a().b(arrayOfDouble);
			}
			catch (a)
			{
			  throw new p2AppManagerException("Error while calling p2SpectroDSP_MEMSResponse ", p2Enumerations.p2AppManagerStatus.DSP_MEMS_RESPONSE_POST_PROCESSING_ERROR.NumVal);
			}
			if (arrayOfDouble1 == null || arrayOfDouble1.Length == 0)
			{
			  throw new p2AppManagerException("Data backed from DSP post processign is empty    ", p2Enumerations.p2AppManagerStatus.DSP_MEMS_RESPONSE_POST_PROCESSING_ERROR.NumVal);
			}
			return arrayOfDouble1;
		  }
	  }

	  private Future<double[][]> c(a parama, int[][] paramArrayOfInt, a parama1)
	  {
		  return c_Conflict.a(new aAnonymousInnerClass35(this, paramArrayOfInt));
	  }

	  private class aAnonymousInnerClass35 : a<double[][]>
	  {
		  private readonly b outerInstance;

		  public aAnonymousInnerClass35(b outerInstance, int[][] paramArrayOfInt) : base(outerInstance, paramArrayOfInt)
		  {
			  this.outerInstance = outerInstance;
		  }

		  protected internal double[][] a()
		  {
			double[] arrayOfDouble = new double[this.a[0].length];
			for (sbyte b1 = 0; b1 < arrayOfDouble.Length; b1++)
			{
			  arrayOfDouble[b1] = this.a[0][b1];
			}
			double[][] arrayOfDouble1 = (double[][])null;
			try
			{
			  arrayOfDouble1 = p2SpectroDSP.a().c(arrayOfDouble);
			}
			catch (a)
			{
			  throw new p2AppManagerException("Error while calling p2SpectroDSP_ParametersCalculation_ResFreqAndQualityFactor ", p2Enumerations.p2AppManagerStatus.DSP_PARAMETERS_CALC_RES_FREQ_QUALITY_FACTOR_POST_PROCESSING_ERROR.NumVal);
			}
			if (arrayOfDouble1 == null || arrayOfDouble1.Length == 0)
			{
			  throw new p2AppManagerException("Data backed from DSP post processign is empty ", p2Enumerations.p2AppManagerStatus.DSP_PARAMETERS_CALC_RES_FREQ_QUALITY_FACTOR_POST_PROCESSING_ERROR.NumVal);
			}
			return arrayOfDouble1;
		  }
	  }

	  private Future<double[][]> d(a parama, int[][] paramArrayOfInt, a parama1)
	  {
		  return c_Conflict.a(new aAnonymousInnerClass36(this, paramArrayOfInt, parama, parama1));
	  }

	  private class aAnonymousInnerClass36 : a<double[][]>
	  {
		  private readonly b outerInstance;

		  public aAnonymousInnerClass36(b outerInstance, int[][] paramArrayOfInt, sws.p2AppManager.b.a parama, sws.p2AppManager.b.a parama1) : base(outerInstance, paramArrayOfInt, parama, parama1)
		  {
			  this.outerInstance = outerInstance;
		  }

		  protected internal double[][] a()
		  {
			double[] arrayOfDouble = new double[this.a[0].length];
			for (sbyte b1 = 0; b1 < arrayOfDouble.Length; b1++)
			{
			  arrayOfDouble[b1] = this.a[0][b1];
			}
			double[][] arrayOfDouble1 = (double[][])null;
			try
			{
			  double d1 = this.b.b(a.i.fH.a(), a.k.fH.a(), a.j.fH.a());
			  double d2 = this.b.b(a.i.fI.a(), a.k.fI.a(), a.j.fI.a());
			  arrayOfDouble1 = p2SpectroDSP.a().b(arrayOfDouble, this.c_Conflict.m, this.c_Conflict.j, d1, d2);
			}
			catch (a)
			{
			  throw new p2AppManagerException("Error while calling p2SpectroDSP_ParametersCalculation_ForwardGain ", p2Enumerations.p2AppManagerStatus.DSP_PARAMETERS_CALC_FORWARD_GAIN_POST_PROCESSING_ERROR.NumVal);
			}
			catch (a)
			{
			  throw new p2AppManagerException("Error while reading ASIC registers   ", p2Enumerations.p2AppManagerStatus.DSP_CAP_CURRENT_POST_BAD_DATA_ERROR.NumVal);
			}
			if (arrayOfDouble1 == null || arrayOfDouble1.Length == 0)
			{
			  throw new p2AppManagerException("Data backed from DSP post processign is empty ", p2Enumerations.p2AppManagerStatus.DSP_PARAMETERS_CALC_FORWARD_GAIN_POST_PROCESSING_ERROR.NumVal);
			}
			return arrayOfDouble1;
		  }
	  }

	  private Future<double[][]> e(a parama, a parama1)
	  {
		  return c_Conflict.a(new aAnonymousInnerClass37(this, parama1));
	  }

	  private class aAnonymousInnerClass37 : a<double[][]>
	  {
		  private readonly b outerInstance;

		  public aAnonymousInnerClass37(b outerInstance, sws.p2AppManager.b.a parama1) : base(outerInstance, parama1)
		  {
			  this.outerInstance = outerInstance;
		  }

		  protected internal double[][] a()
		  {
			string[] arrayOfString1 = new string[2];
			bufferedReader = null;
			try
			{
			  bufferedReader = new StreamReader(p2Constants.getPath(p2Constants.CLOSED_LOOP_GAIN_VS_FREQ_FILE_PATH));
			  arrayOfString1[0] = bufferedReader.readLine();
			  arrayOfString1[1] = bufferedReader.readLine();
			}
			catch (Exception exception)
			{
			  b.v().error(exception.Message);
			}
			finally
			{
			  try
			  {
				bufferedReader.close();
			  }
			  catch (Exception exception)
			  {
				b.v().error(exception.Message);
			  }
			}
			string[] arrayOfString2 = arrayOfString1[0].Split(" ", true);
			double[] arrayOfDouble1 = new double[arrayOfString2.Length];
			for (sbyte b1 = 0; b1 < arrayOfString2.Length; b1++)
			{
			  arrayOfDouble1[b1] = double.Parse(arrayOfString2[b1]);
			}
			arrayOfString2 = arrayOfString1[1].Split(" ", true);
			double[] arrayOfDouble2 = new double[arrayOfString2.Length];
			for (sbyte b2 = 0; b2 < arrayOfString2.Length; b2++)
			{
			  arrayOfDouble2[b2] = double.Parse(arrayOfString2[b2]);
			}
			double[][] arrayOfDouble = (double[][])null;
			try
			{
			  arrayOfDouble = p2SpectroDSP.a().a(this.a.L, this.a.M, this.a.N, this.a.O, arrayOfDouble1, arrayOfDouble2, this.a.m);
			}
			catch (a)
			{
			  throw new p2AppManagerException("Error while calling p2SpectroDSP_ParametersCalculation_ForwardGain ", p2Enumerations.p2AppManagerStatus.DSP_COEFFICIENTS_CALC_POST_PROCESSING_ERROR.NumVal);
			}
			if (arrayOfDouble == null || arrayOfDouble.Length == 0)
			{
			  throw new p2AppManagerException("Data backed from DSP post processign is empty ", p2Enumerations.p2AppManagerStatus.DSP_COEFFICIENTS_CALC_POST_PROCESSING_ERROR.NumVal);
			}
			return arrayOfDouble;
		  }
	  }

	  private Future<double[][]> a(a parama, int[][] paramArrayOfInt1, int[][] paramArrayOfInt2, a parama1)
	  {
		  return c_Conflict.a(new aAnonymousInnerClass38(this, paramArrayOfInt1, paramArrayOfInt2, parama1));
	  }

	  private class aAnonymousInnerClass38 : a<double[][]>
	  {
		  private readonly b outerInstance;

		  public aAnonymousInnerClass38(b outerInstance, int[][] paramArrayOfInt1, int[][] paramArrayOfInt2, sws.p2AppManager.b.a parama1) : base(outerInstance, paramArrayOfInt1, paramArrayOfInt2, parama1)
		  {
			  this.outerInstance = outerInstance;
		  }

		  protected internal double[][] a()
		  {
			double[] arrayOfDouble1 = new double[this.a[0].length];
			for (sbyte b1 = 0; b1 < arrayOfDouble1.Length; b1++)
			{
			  arrayOfDouble1[b1] = this.a[0][b1];
			}
			double[] arrayOfDouble2 = new double[this.b[0].length];
			for (sbyte b2 = 0; b2 < arrayOfDouble2.Length; b2++)
			{
			  arrayOfDouble2[b2] = this.b[0][b2];
			}
			double[][] arrayOfDouble = (double[][])null;
			try
			{
			  arrayOfDouble = p2SpectroDSP.a().a(arrayOfDouble2, arrayOfDouble1, this.c_Conflict.L);
			}
			catch (a)
			{
			  throw new p2AppManagerException("Error while calling p2SpectroDSP_PhaseTrimming_PhaseValidation ", p2Enumerations.p2AppManagerStatus.DSP_PHASE_VALIDATION_POST_PROCESSING_ERROR.NumVal);
			}
			if (arrayOfDouble == null || arrayOfDouble.Length == 0)
			{
			  throw new p2AppManagerException("Data backed from DSP post processign is empty ", p2Enumerations.p2AppManagerStatus.DSP_PHASE_VALIDATION_POST_PROCESSING_ERROR.NumVal);
			}
			return arrayOfDouble;
		  }
	  }

	  private Future<double[][]> b(a parama, int[][] paramArrayOfInt1, int[][] paramArrayOfInt2, a parama1)
	  {
		  if (!InstanceFieldsInitialized)
		  {
			  InitializeInstanceFields();
			  InstanceFieldsInitialized = true;
		  }
		  return c_Conflict.a(new aAnonymousInnerClass39(this, paramArrayOfInt1, paramArrayOfInt2, parama, parama1));
	  }

	  private class aAnonymousInnerClass39 : a<double[][]>
	  {
		  private readonly b outerInstance;

		  public aAnonymousInnerClass39(b outerInstance, int[][] paramArrayOfInt1, int[][] paramArrayOfInt2, sws.p2AppManager.b.a parama, sws.p2AppManager.b.a parama1) : base(outerInstance, paramArrayOfInt1, paramArrayOfInt2, parama, parama1)
		  {
			  this.outerInstance = outerInstance;
		  }

		  protected internal double[][] a()
		  {
			double d2;
			double[] arrayOfDouble1 = new double[this.a[0].length];
			for (sbyte b1 = 0; b1 < arrayOfDouble1.Length; b1++)
			{
			  arrayOfDouble1[b1] = this.a[0][b1];
			}
			double[] arrayOfDouble2 = new double[this.b[0].length];
			double d1;
			for (d1 = false; d1 < arrayOfDouble2.Length; d1++)
			{
			  arrayOfDouble2[d1] = this.b[0][d1];
			}
			try
			{
			  d1 = this.c_Conflict.b(a.i.fH.a(), a.k.fH.a(), a.j.fH.a());
			  d2 = this.c_Conflict.b(a.i.fI.a(), a.k.fI.a(), a.j.fI.a());
			}
			catch (a)
			{
			  throw new p2AppManagerException("Error while reading ASIC registers before p2SpectroDSP_StabilityCheck ", p2Enumerations.p2AppManagerStatus.DSP_STABILITY_CHECK_POST_PROCESSING_ERROR.NumVal);
			}
			double[][] arrayOfDouble = (double[][])null;
			try
			{
			  arrayOfDouble = p2SpectroDSP.a().a(arrayOfDouble2, arrayOfDouble1, this.d_Conflict.m, this.d_Conflict.L, d1, d2);
			}
			catch (a)
			{
			  throw new p2AppManagerException("Error while calling p2SpectroDSP_StabilityCheck ", p2Enumerations.p2AppManagerStatus.DSP_STABILITY_CHECK_POST_PROCESSING_ERROR.NumVal);
			}
			if (arrayOfDouble == null || arrayOfDouble.Length == 0)
			{
			  throw new p2AppManagerException("Data backed from DSP post processign is empty ", p2Enumerations.p2AppManagerStatus.DSP_STABILITY_CHECK_POST_PROCESSING_ERROR.NumVal);
			}
			return arrayOfDouble;
		  }
	  }

	  private Future<double[][]> a(a parama, int[][] paramArrayOfInt, int paramInt, double paramDouble, a parama1)
	  {
		  return c_Conflict.a(new aAnonymousInnerClass40(this, paramArrayOfInt, parama1, paramInt, paramDouble));
	  }

	  private class aAnonymousInnerClass40 : a<double[][]>
	  {
		  private readonly b outerInstance;

		  public aAnonymousInnerClass40(b outerInstance, int[][] paramArrayOfInt, sws.p2AppManager.b.a parama1, int paramInt, double paramDouble) : base(outerInstance, paramArrayOfInt, parama1, paramInt, paramDouble)
		  {
			  this.outerInstance = outerInstance;
		  }

		  protected internal double[][] a()
		  {
			double[] arrayOfDouble = new double[this.a[0].length];
			for (sbyte b1 = 0; b1 < arrayOfDouble.Length; b1++)
			{
			  arrayOfDouble[b1] = this.a[0][b1];
			}
			double[][] arrayOfDouble1 = (double[][])null;
			try
			{
			  arrayOfDouble1 = p2SpectroDSP.a().a(arrayOfDouble, this.b.V, this.c_Conflict, this.d_Conflict);
			}
			catch (a)
			{
			  throw new p2AppManagerException("Error while calling p2SpectroDSP_GainMarginCalc ", p2Enumerations.p2AppManagerStatus.DSP_GAIN_MARGIN_CALC_POST_PROCESSING_ERROR.NumVal);
			}
			if (arrayOfDouble1 == null || arrayOfDouble1.Length == 0)
			{
			  throw new p2AppManagerException("Data backed from DSP post processign is empty ", p2Enumerations.p2AppManagerStatus.DSP_GAIN_MARGIN_CALC_POST_PROCESSING_ERROR.NumVal);
			}
			return arrayOfDouble1;
		  }
	  }

	  private Future<double[][]> e(a parama, int[][] paramArrayOfInt, a parama1)
	  {
		  return c_Conflict.a(new aAnonymousInnerClass41(this, paramArrayOfInt, parama, parama1));
	  }

	  private class aAnonymousInnerClass41 : a<double[][]>
	  {
		  private readonly b outerInstance;

		  public aAnonymousInnerClass41(b outerInstance, int[][] paramArrayOfInt, sws.p2AppManager.b.a parama, sws.p2AppManager.b.a parama1) : base(outerInstance, paramArrayOfInt, parama, parama1)
		  {
			  this.outerInstance = outerInstance;
		  }

		  protected internal double[][] a()
		  {
			double[] arrayOfDouble1 = new double[this.a[0].length];
			for (sbyte b1 = 0; b1 < arrayOfDouble1.Length; b1++)
			{
			  arrayOfDouble1[b1] = this.a[0][b1];
			}
			double[] arrayOfDouble2 = new double[this.a[2].length];
			for (sbyte b2 = 0; b2 < arrayOfDouble2.Length; b2++)
			{
			  arrayOfDouble2[b2] = this.a[2][b2];
			}
			double[][] arrayOfDouble = (double[][])null;
			try
			{
			  double d1 = this.b.b(a.i.fH.a(), a.k.fH.a(), a.j.fH.a());
			  double d2 = this.b.b(a.i.fI.a(), a.k.fI.a(), a.j.fI.a());
			  int i = (int)this.b.b(a.i.fy.a(), a.k.fy.a(), a.j.fy.a());
			  double d3 = Math.Pow(2.0D, i) * 5000.0D * this.c_Conflict.p * this.c_Conflict.q;
			  arrayOfDouble = p2SpectroDSP.a().a(arrayOfDouble1, arrayOfDouble2, b.a(this.d_Conflict).b(), d3, this.c_Conflict.m, d1, d2);
			}
			catch (a)
			{
			  throw new p2AppManagerException("Error while make DSP data cap & current processing   ", p2Enumerations.p2AppManagerStatus.DSP_CAP_CURRENT_POST_PROCESSING_ERROR.NumVal);
			}
			catch (a)
			{
			  throw new p2AppManagerException("Error while reading ASIC registers   ", p2Enumerations.p2AppManagerStatus.DSP_CAP_CURRENT_POST_BAD_DATA_ERROR.NumVal);
			}
			if (arrayOfDouble == null || arrayOfDouble.Length == 0)
			{
			  throw new p2AppManagerException("Data backed from DSP post processign is empty    ", p2Enumerations.p2AppManagerStatus.DSP_CAP_CURRENT_POST_EMPTY_DATA_ERROR.NumVal);
			}
			if (arrayOfDouble.Length < 12)
			{
			  throw new p2AppManagerException("Data backed from DSP post processign lenght not right ", p2Enumerations.p2AppManagerStatus.DSP_CAP_CURRENT_POST_BAD_DATA_ERROR.NumVal);
			}
			return arrayOfDouble;
		  }
	  }

	  private Future<double[]> f(a parama, int[][] paramArrayOfInt, a parama1)
	  {
		  return c_Conflict.a(new aAnonymousInnerClass42(this, paramArrayOfInt, parama1));
	  }

	  private class aAnonymousInnerClass42 : a<double[]>
	  {
		  private readonly b outerInstance;

		  public aAnonymousInnerClass42(b outerInstance, int[][] paramArrayOfInt, sws.p2AppManager.b.a parama1) : base(outerInstance, paramArrayOfInt, parama1)
		  {
			  this.outerInstance = outerInstance;
		  }

		  protected internal double[] a()
		  {
			double[] arrayOfDouble1 = new double[this.a[0].length];
			for (sbyte b1 = 0; b1 < arrayOfDouble1.Length; b1++)
			{
			  arrayOfDouble1[b1] = this.a[0][b1];
			}
			double[] arrayOfDouble2 = null;
			try
			{
			  b.a(this.c_Conflict, b.a(this.c_Conflict).b());
			  arrayOfDouble2 = p2SpectroDSP.a().a(arrayOfDouble1, b.d(this.c_Conflict), this.b.v, this.b.t, this.b.u);
			}
			catch (a)
			{
			  throw new p2AppManagerException("Error while make DSP data cap vs time processing   ", p2Enumerations.p2AppManagerStatus.DSP_CALIB_CAP_TIME_POST_PROCESSING_ERROR.NumVal);
			}
			if (arrayOfDouble2 == null || arrayOfDouble2.Length == 0)
			{
			  throw new p2AppManagerException("Data backed from DSP post processign is empty    ", p2Enumerations.p2AppManagerStatus.DSP_CALIB_CAP_TIME_POST_EMPTY_DATA_ERROR.NumVal);
			}
			if (arrayOfDouble2.Length < 7)
			{
			  throw new p2AppManagerException("Data backed from DSP post processign lenght not right ", p2Enumerations.p2AppManagerStatus.DSP_CALIB_CAP_TIME_POST_BAD_DATA_ERROR.NumVal);
			}
			return arrayOfDouble2;
		  }
	  }

	  private Future<double[]> a(a parama, int[] paramArrayOfInt1, int[] paramArrayOfInt2, a parama1, int paramInt1, int paramInt2, int paramInt3)
	  {
		  return c_Conflict.a(new aAnonymousInnerClass43(this, paramArrayOfInt1, paramArrayOfInt2, paramInt1, paramInt2, paramInt3));
	  }

	  private class aAnonymousInnerClass43 : a<double[]>
	  {
		  private readonly b outerInstance;

		  public aAnonymousInnerClass43(b outerInstance, int[] paramArrayOfInt1, int[] paramArrayOfInt2, int paramInt1, int paramInt2, int paramInt3) : base(outerInstance, paramArrayOfInt1, paramArrayOfInt2, paramInt1, paramInt2, paramInt3)
		  {
			  this.outerInstance = outerInstance;
		  }

		  protected internal double[] a()
		  {
			double[] arrayOfDouble1 = new double[this.a.length];
			for (sbyte b1 = 0; b1 < arrayOfDouble1.Length; b1++)
			{
			  arrayOfDouble1[b1] = this.a[b1];
			}
			double[] arrayOfDouble2 = new double[this.b.length];
			for (sbyte b2 = 0; b2 < arrayOfDouble2.Length; b2++)
			{
			  arrayOfDouble2[b2] = this.b[b2];
			}
			double[] arrayOfDouble3 = null;
			try
			{
			  arrayOfDouble3 = p2SpectroDSP.a().a(arrayOfDouble1, arrayOfDouble2, b.a(this.f_Conflict).k(), b.a(this.f_Conflict).l(), this.c_Conflict, this.d_Conflict, true, this.e_Conflict);
			}
			catch (a)
			{
			  throw new p2AppManagerException("Error while make DSP data delay compensation processing   ", p2Enumerations.p2AppManagerStatus.DSP_CALIB_DELAY_COMP_POST_PROCESSING_ERROR.NumVal);
			}
			if (arrayOfDouble3 == null || arrayOfDouble3.Length == 0)
			{
			  throw new p2AppManagerException("Data backed from DSP post processign is empty    ", p2Enumerations.p2AppManagerStatus.DSP_CALIB_DELAY_COMP_POST_EMPTY_DATA_ERROR.NumVal);
			}
			if (arrayOfDouble3.Length < 3)
			{
			  throw new p2AppManagerException("Data backed from DSP post processign lenght not right ", p2Enumerations.p2AppManagerStatus.DSP_CALIB_DELAY_COMP_POST_BAD_DATA_ERROR.NumVal);
			}
			return arrayOfDouble3;
		  }
	  }

	  private void a(a parama, bool paramBoolean, c paramc, double[] paramArrayOfDouble1, double[] paramArrayOfDouble2, double[] paramArrayOfDouble3, double[] paramArrayOfDouble4)
	  {
		if (parama.c == 1)
		{
		  a(paramArrayOfDouble1, paramArrayOfDouble2, paramArrayOfDouble3, paramArrayOfDouble4, parama, paramBoolean, paramc);
		  return;
		}
		if (paramBoolean)
		{
		  for (sbyte b1 = 0; b1 < paramArrayOfDouble3.Length; b1++)
		  {
			paramArrayOfDouble3[b1] = paramc.j()[0] * paramArrayOfDouble3[b1] + paramc.j()[1];
		  }
		}
	  }

	  private bool a(double[] paramArrayOfDouble)
	  {
		  return true;
	  }

	  private void a(double[] paramArrayOfDouble1, double[] paramArrayOfDouble2, double[] paramArrayOfDouble3, double[] paramArrayOfDouble4, a parama, bool paramBoolean, c paramc)
	  {
		try
		{
		  double[] arrayOfDouble = new double[paramArrayOfDouble1.Length];
		  Array.Copy(paramArrayOfDouble1, 0, arrayOfDouble, 0, paramArrayOfDouble1.Length);
		  double[][] arrayOfDouble1 = p2SpectroDSP.a().a(paramc.b(), parama.c, parama.d, parama.f, paramArrayOfDouble2, arrayOfDouble, paramArrayOfDouble3, paramc.i());
		  sbyte b1;
		  for (b1 = 0; b1 < paramArrayOfDouble1.Length; b1++)
		  {
			paramArrayOfDouble1[b1] = arrayOfDouble1[2][b1];
		  }
		  for (b1 = 0; b1 < paramArrayOfDouble2.Length; b1++)
		  {
			paramArrayOfDouble2[b1] = arrayOfDouble1[3][b1];
		  }
		  if (paramBoolean)
		  {
			for (b1 = 0; b1 < paramArrayOfDouble3.Length; b1++)
			{
			  paramArrayOfDouble3[b1] = 1.0D / (paramc.j()[0] / arrayOfDouble1[0][b1] + paramc.j()[1]);
			}
		  }
		  else
		  {
			for (b1 = 0; b1 < paramArrayOfDouble3.Length; b1++)
			{
			  paramArrayOfDouble3[b1] = arrayOfDouble1[0][b1];
			}
		  }
		  for (b1 = 0; b1 < paramArrayOfDouble4.Length; b1++)
		  {
			paramArrayOfDouble4[b1] = arrayOfDouble1[1][b1];
		  }
		}
		catch (a_Conflict)
		{
		  throw new p2AppManagerException("Error while FFT post processing    ", p2Enumerations.p2AppManagerStatus.DSP_INTERFEROGRAM_FFT_POST_PROCESSINF_ERROR.NumVal);
		}
	  }

	  private void a(double[] paramArrayOfDouble, a parama, double[][] paramArrayOfDouble1, double[][] paramArrayOfDouble2)
	  {
		if (parama.a == p2Enumerations.p2AppManagerState.InterferogramRun)
		{
		  a(paramArrayOfDouble, paramArrayOfDouble1[0]);
		  sbyte b1;
		  for (b1 = 0; b1 < paramArrayOfDouble1[1].Length; b1++)
		  {
			paramArrayOfDouble1[1][b1] = paramArrayOfDouble1[1][b1] * 1000.0D;
		  }
		  for (b1 = 0; b1 < paramArrayOfDouble1[3].Length; b1++)
		  {
			paramArrayOfDouble1[3][b1] = Math.Pow(10.0D, (paramArrayOfDouble1[3][b1] + 30.0D) / 10.0D);
		  }
		}
		else if (parama.a == p2Enumerations.p2AppManagerState.SpectroscopySampleRun)
		{
		  double[][] arrayOfDouble = a(paramArrayOfDouble1);
		  a(paramArrayOfDouble, arrayOfDouble[0]);
		  this.k_Conflict = arrayOfDouble;
		  b(paramArrayOfDouble1[3]);
		  a(paramArrayOfDouble1, paramArrayOfDouble2);
		}
		else if (parama.a == p2Enumerations.p2AppManagerState.wavelengthCalibrationBG_Run)
		{
		  b(paramArrayOfDouble1[3]);
		}
		else if (parama.a == p2Enumerations.p2AppManagerState.wavelengthCalibration_Run)
		{
		  b(paramArrayOfDouble1[3]);
		  a(paramArrayOfDouble1, paramArrayOfDouble2);
		  sbyte b1;
		  for (b1 = 0; b1 < paramArrayOfDouble1[1].Length; b1++)
		  {
			paramArrayOfDouble1[1][b1] = paramArrayOfDouble1[1][b1] * 1000.0D;
		  }
		  for (b1 = 0; b1 < paramArrayOfDouble1[3].Length; b1++)
		  {
			paramArrayOfDouble1[3][b1] = Math.Pow(10.0D, paramArrayOfDouble1[3][b1] / 10.0D);
		  }
		}
		else if (parama.a == p2Enumerations.p2AppManagerState.StabilityRun)
		{
		  int i1;
		  double[] arrayOfDouble1 = paramArrayOfDouble1[3];
		  double[] arrayOfDouble2 = paramArrayOfDouble1[5];
		  double[] arrayOfDouble3 = paramArrayOfDouble2[3];
		  if (arrayOfDouble1.Length < arrayOfDouble3.Length)
		  {
			i1 = arrayOfDouble1.Length;
		  }
		  else
		  {
			i1 = arrayOfDouble3.Length;
		  }
		  sbyte b1;
		  for (b1 = 0; b1 < i1; b1++)
		  {
			arrayOfDouble1[b1] = arrayOfDouble1[b1] / arrayOfDouble3[b1];
		  }
		  b(paramArrayOfDouble1[5]);
		  if (arrayOfDouble2.Length < arrayOfDouble3.Length)
		  {
			i1 = arrayOfDouble2.Length;
		  }
		  else
		  {
			i1 = arrayOfDouble3.Length;
		  }
		  for (b1 = 0; b1 < i1; b1++)
		  {
			arrayOfDouble2[b1] = arrayOfDouble2[b1] - arrayOfDouble3[b1];
		  }
		}
		else if (parama.a == p2Enumerations.p2AppManagerState.SpectroscopyBackgroundRun)
		{
		  b(paramArrayOfDouble1[3]);
		  b(paramArrayOfDouble1);
		}
		else if (parama.a == p2Enumerations.p2AppManagerState.updateFFT_SettingsInterSpecRun)
		{
		  for (sbyte b1 = 0; b1 < paramArrayOfDouble1[3].Length; b1++)
		  {
			paramArrayOfDouble1[3][b1] = Math.Pow(10.0D, (paramArrayOfDouble1[3][b1] + 30.0D) / 10.0D);
		  }
		}
		else if (parama.a == p2Enumerations.p2AppManagerState.updateFFT_SettingsSpecRun)
		{
		  b(paramArrayOfDouble2[3]);
		  b(paramArrayOfDouble1[3]);
		  a(paramArrayOfDouble1, paramArrayOfDouble2);
		}
	  }

	  private double[][] a(double[][] paramArrayOfDouble)
	  {
		double[][] arrayOfDouble = new double[paramArrayOfDouble.Length][];
		for (sbyte b1 = 0; b1 < paramArrayOfDouble.Length; b1++)
		{
		  arrayOfDouble[b1] = new double[paramArrayOfDouble[b1].Length];
		  Array.Copy(paramArrayOfDouble[b1], 0, arrayOfDouble[b1], 0, paramArrayOfDouble[b1].Length);
		}
		return arrayOfDouble;
	  }

	  private void a(double[] paramArrayOfDouble1, double[] paramArrayOfDouble2)
	  {
		double d1 = paramArrayOfDouble1[0];
		for (sbyte b1 = 0; b1 < paramArrayOfDouble2.Length; b1++)
		{
		  paramArrayOfDouble2[b1] = paramArrayOfDouble2[b1] - d1;
		}
	  }

//JAVA TO C# CONVERTER NOTE: Members cannot have the same name as their enclosing type:
	  private void b_Conflict(double[] paramArrayOfDouble)
	  {
		for (sbyte b1 = 0; b1 < paramArrayOfDouble.Length; b1++)
		{
		  paramArrayOfDouble[b1] = paramArrayOfDouble[b1] - 30.0D;
		}
	  }

	  private void a(double[][] paramArrayOfDouble1, double[][] paramArrayOfDouble2)
	  {
		int i1;
		double[] arrayOfDouble1 = paramArrayOfDouble1[3];
		double[] arrayOfDouble2 = paramArrayOfDouble2[3];
		if (arrayOfDouble1.Length < arrayOfDouble2.Length)
		{
		  i1 = arrayOfDouble1.Length;
		}
		else
		{
		  i1 = arrayOfDouble2.Length;
		}
		for (sbyte b1 = 0; b1 < i1; b1++)
		{
		  arrayOfDouble1[b1] = arrayOfDouble1[b1] - arrayOfDouble2[b1];
		}
	  }

	  private bool b(params double[][] paramVarArgs)
	  {
		  if (!InstanceFieldsInitialized)
		  {
			  InitializeInstanceFields();
			  InstanceFieldsInitialized = true;
		  }
		if (!p2AppManagerUtils.createDir(p2Constants.WHITE_LIGHT_FILES_DIR))
		{
		  throw new p2AppManagerException("Error while creating white light folder    ", p2Enumerations.p2AppManagerStatus.WHITE_LIGHT_PROCESSING_ERROR.NumVal);
		}
		string str = Arrays.ToString(p2AppManagerUtils.concatenateMultipleArraysIntoOne(paramVarArgs));
		string[] arrayOfString = str.Substring(1, (str.Length - 1) - 1).Split(",", true);
		if (!p2AppManagerUtils.writeFileOfArray(arrayOfString, p2Constants.WHITE_LIGHT_FILES_DIR + Path.DirectorySeparatorChar + "WhiteLight.xml", null))
		{
		  throw new p2AppManagerException("Error while write white light file    ", p2Enumerations.p2AppManagerStatus.WHITE_LIGHT_PROCESSING_ERROR.NumVal);
		}
		return true;
	  }

	  private p2Enumerations.p2AppManagerStatus y()
	  {
		try
		{
		  int i1 = this.O.a();
		  if (i1 == 14)
		  {
			this.F_Conflict = "";
			this.E_Conflict = "";
			return p2Enumerations.p2AppManagerStatus.BOARD_DISTCONNECTED_ERROR;
		  }
		  if (i1 == 74)
		  {
			this.F_Conflict = "";
			this.E_Conflict = "";
			return p2Enumerations.p2AppManagerStatus.BOARD_NOT_INITIALIZED_ERROR;
		  }
		  return p2Enumerations.p2AppManagerStatus.BOARD_ALREADY_INITIALIZED;
		}
		catch (a_Conflict)
		{
		  return p2Enumerations.p2AppManagerStatus.UNKNOWN_ERROR;
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private a a(sws.p2AppManager.utils.p2Enumerations.p2DeviceAction paramp2DeviceAction, String... paramVarArgs) throws Exception, a
	  private a a(p2Enumerations.p2DeviceAction paramp2DeviceAction, params string[] paramVarArgs)
	  {
		long l6;
		long l5;
		long l4;
		long l3;
		long l2;
		long l1;
		a a1;
		switch (null.a[paramp2DeviceAction.ordinal()])
		{
		  case 1:
			if (p2AppManagerUtils.isEmptyString(paramVarArgs[0]))
			{
			  throw new p2AppManagerException("Invalid Parameters. Error: ", p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR.NumVal);
			}
			if (paramVarArgs.Length == 3 && (p2AppManagerUtils.isEmptyString(paramVarArgs[1]) || p2AppManagerUtils.isEmptyString(paramVarArgs[2])))
			{
			  throw new p2AppManagerException("Invalid Parameters. Error: ", p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR.NumVal);
			}
			a1 = new a(this, this, null);
			a1.ac = double.Parse(paramVarArgs[0]);
			a1.c = 0;
			a1.d = 0;
			a1.e = p2Constants.INTER_SPEC_WL_CORR;
			a1.0f = 0;
			if (paramVarArgs.Length == 3)
			{
			  a1.af = int.Parse(paramVarArgs[1]);
			  a1.ag = int.Parse(paramVarArgs[2]);
			}
			else
			{
			  a1.af = 0;
			  a1.ag = 1;
			}
			a1.a = p2Enumerations.p2AppManagerState.InterferogramRun;
			return a1;
		  case 2:
			if (p2AppManagerUtils.isEmptyString(paramVarArgs[0]) || p2AppManagerUtils.isEmptyString(paramVarArgs[1]))
			{
			  throw new p2AppManagerException("Invalid Parameters. Error: ", p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR.NumVal);
			}
			a1 = new a(this, this, null);
			a1.c = 0;
			a1.d = 0;
			a1.e = p2Constants.INTER_SPEC_WL_CORR;
			a1.af = int.Parse(paramVarArgs[0]);
			a1.ag = int.Parse(paramVarArgs[1]);
			a1.a = p2Enumerations.p2AppManagerState.updateFFT_SettingsInterSpecRun;
			return a1;
		  case 3:
			if (p2AppManagerUtils.isEmptyString(paramVarArgs[0]) || p2AppManagerUtils.isEmptyString(paramVarArgs[1]))
			{
			  throw new p2AppManagerException("Invalid Parameters. Error: ", p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR.NumVal);
			}
			a1 = new a(this, this, null);
			a1.c = 0;
			a1.d = 0;
			a1.e = p2Constants.INTER_SPEC_WL_CORR;
			a1.af = int.Parse(paramVarArgs[0]);
			a1.ag = int.Parse(paramVarArgs[1]);
			a1.a = p2Enumerations.p2AppManagerState.updateFFT_SettingsSpecRun;
			return a1;
		  case 4:
			if (p2AppManagerUtils.isEmptyString(paramVarArgs[0]) || p2AppManagerUtils.isEmptyString(paramVarArgs[1]))
			{
			  throw new p2AppManagerException("Invalid Parameters. Error: ", p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR.NumVal);
			}
			if (paramVarArgs.Length == 4 && (p2AppManagerUtils.isEmptyString(paramVarArgs[2]) || p2AppManagerUtils.isEmptyString(paramVarArgs[3])))
			{
			  throw new p2AppManagerException("Invalid Parameters. Error: ", p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR.NumVal);
			}
			a1 = new a(this, this, null);
			a1.ac = double.Parse(paramVarArgs[0]);
			a1.c = 0;
			a1.d = 0;
			a1.e = p2Constants.BG_SPEC_WL_CORR;
			a1.0f = 0;
			if (paramVarArgs.Length == 4)
			{
			  a1.af = int.Parse(paramVarArgs[2]);
			  a1.ag = int.Parse(paramVarArgs[3]);
			}
			else
			{
			  a1.af = 0;
			  a1.ag = 1;
			}
			a1.a = p2Enumerations.p2AppManagerState.SpectroscopyBackgroundRun;
			a(p2Enumerations.p2AppManagerState.SpectroscopyBackgroundRun);
			return a1;
		  case 5:
			if (p2AppManagerUtils.isEmptyString(paramVarArgs[0]) || p2AppManagerUtils.isEmptyString(paramVarArgs[1]))
			{
			  throw new p2AppManagerException("Invalid Parameters. Error: ", p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR.NumVal);
			}
			if (paramVarArgs.Length == 4 && (p2AppManagerUtils.isEmptyString(paramVarArgs[2]) || p2AppManagerUtils.isEmptyString(paramVarArgs[3])))
			{
			  throw new p2AppManagerException("Invalid Parameters. Error: ", p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR.NumVal);
			}
			a1 = new a(this, this, null);
			a1.ac = double.Parse(paramVarArgs[0]);
			a1.c = 0;
			a1.d = 0;
			a1.e = p2Constants.SPEC_WL_CORR;
			a1.0f = 0;
			if (paramVarArgs.Length == 4)
			{
			  a1.af = int.Parse(paramVarArgs[2]);
			  a1.ag = int.Parse(paramVarArgs[3]);
			}
			else
			{
			  a1.af = 0;
			  a1.ag = 1;
			}
			a1.a = p2Enumerations.p2AppManagerState.SpectroscopySampleRun;
			a(p2Enumerations.p2AppManagerState.SpectroscopySampleRun);
			return a1;
		  case 6:
			if (p2AppManagerUtils.isEmptyString(paramVarArgs[0]) || p2AppManagerUtils.isEmptyString(paramVarArgs[1]) || p2AppManagerUtils.isEmptyString(paramVarArgs[2]))
			{
			  throw new p2AppManagerException("Invalid Parameters. Error: ", p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR.NumVal);
			}
			a1 = new a(this, this, null);
			a1.ac = double.Parse(paramVarArgs[0]);
			a1.c = 0;
			a1.d = 0;
			a1.e = p2Constants.BG_SPEC_WL_CORR;
			a1.0f = 0;
			a1.af = int.Parse(paramVarArgs[1]);
			a1.ag = int.Parse(paramVarArgs[2]);
			a1.a = p2Enumerations.p2AppManagerState.wavelengthCalibrationBG_Run;
			a(p2Enumerations.p2AppManagerState.wavelengthCalibrationBG_Run);
			return a1;
		  case 7:
			if (p2AppManagerUtils.isEmptyString(paramVarArgs[0]) || p2AppManagerUtils.isEmptyString(paramVarArgs[1]) || p2AppManagerUtils.isEmptyString(paramVarArgs[2]) || p2AppManagerUtils.isEmptyString(paramVarArgs[3]))
			{
			  throw new p2AppManagerException("Invalid Parameters. Error: ", p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR.NumVal);
			}
			a1 = new a(this, this, null);
			a1.ac = double.Parse(paramVarArgs[0]);
			a1.Y = paramVarArgs[1];
			a1.c = 0;
			a1.d = 0;
			a1.e = p2Constants.SPEC_WL_CORR;
			a1.0f = 0;
			a1.af = int.Parse(paramVarArgs[2]);
			a1.ag = int.Parse(paramVarArgs[3]);
			a1.a = p2Enumerations.p2AppManagerState.wavelengthCalibration_Run;
			a(p2Enumerations.p2AppManagerState.wavelengthCalibration_Run);
			return a1;
		  case 8:
			if (p2AppManagerUtils.isEmptyString(paramVarArgs[0]))
			{
			  throw new p2AppManagerException("Invalid Parameters. Error: ", p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR.NumVal);
			}
			a1 = new a(this, this, null);
			a1.ac = double.Parse(paramVarArgs[0]);
			a1.c = 0;
			a1.d = 0;
			a1.e = p2Constants.INTER_SPEC_WL_CORR;
			a1.0f = 0;
			a1.a = p2Enumerations.p2AppManagerState.gainAdjustInterSpecRun;
			return a1;
		  case 9:
			if (p2AppManagerUtils.isEmptyString(paramVarArgs[0]))
			{
			  throw new p2AppManagerException("Invalid Parameters. Error: ", p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR.NumVal);
			}
			a1 = new a(this, this, null);
			a1.ac = double.Parse(paramVarArgs[0]);
			a1.c = 0;
			a1.d = 0;
			a1.e = p2Constants.INTER_SPEC_WL_CORR;
			a1.0f = 0;
			a1.a = p2Enumerations.p2AppManagerState.gainAdjustSpecBG_Run;
			return a1;
		  case 10:
			if (p2AppManagerUtils.isEmptyString(paramVarArgs[0]) || p2AppManagerUtils.isEmptyString(paramVarArgs[1]) || p2AppManagerUtils.isEmptyString(paramVarArgs[2]))
			{
			  throw new p2AppManagerException("Invalid Parameters. Error: ", p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR.NumVal);
			}
			a1 = new a(this, this, null);
			a1.ac = double.Parse(paramVarArgs[0]);
			a1.c = 0;
			a1.d = 0;
			a1.e = p2Constants.INTER_SPEC_WL_CORR;
			a1.0f = 0;
			a1.af = int.Parse(paramVarArgs[1]);
			a1.ag = int.Parse(paramVarArgs[2]);
			a1.a = p2Enumerations.p2AppManagerState.gainAdjustSpecSampleRun;
			return a1;
		  case 11:
			if (p2AppManagerUtils.isEmptyString(paramVarArgs[0]) || p2AppManagerUtils.isEmptyString(paramVarArgs[1]) || p2AppManagerUtils.isEmptyString(paramVarArgs[2]) || p2AppManagerUtils.isEmptyString(paramVarArgs[3]))
			{
			  throw new p2AppManagerException("Invalid Parameters. Error: ", p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR.NumVal);
			}
			a1 = new a(this, this, null);
			a1.ac = double.Parse(paramVarArgs[0]);
			a1.ad = int.Parse(paramVarArgs[1]);
			a1.c = 0;
			a1.d = 0;
			a1.e = p2Constants.INTER_SPEC_WL_CORR;
			a1.0f = 0;
			a1.af = int.Parse(paramVarArgs[2]);
			a1.ag = int.Parse(paramVarArgs[3]);
			a1.a = p2Enumerations.p2AppManagerState.SNR_Run;
			return a1;
		  case 12:
			if (p2AppManagerUtils.isEmptyString(paramVarArgs[0]) || p2AppManagerUtils.isEmptyString(paramVarArgs[1]) || p2AppManagerUtils.isEmptyString(paramVarArgs[2]) || p2AppManagerUtils.isEmptyString(paramVarArgs[3]) || p2AppManagerUtils.isEmptyString(paramVarArgs[4]) || p2AppManagerUtils.isEmptyString(paramVarArgs[5]))
			{
			  throw new p2AppManagerException("Invalid Parameters. Error: ", p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR.NumVal);
			}
			a1 = new a(this, this, null);
			a1.ac = double.Parse(paramVarArgs[0]);
			a1.ad = int.Parse(paramVarArgs[1]);
			a1.Y = paramVarArgs[2];
			a1.ae = int.Parse(paramVarArgs[3]);
			a1.c = 0;
			a1.d = 0;
			a1.e = p2Constants.INTER_SPEC_WL_CORR;
			a1.0f = 0;
			a1.af = int.Parse(paramVarArgs[4]);
			a1.ag = int.Parse(paramVarArgs[5]);
			a1.a = p2Enumerations.p2AppManagerState.StabilityRun;
			return a1;
		  case 13:
			if (p2AppManagerUtils.isEmptyString(paramVarArgs[0]) || p2AppManagerUtils.isEmptyString(paramVarArgs[1]) || p2AppManagerUtils.isEmptyString(paramVarArgs[2]))
			{
			  throw new p2AppManagerException("Invalid Parameters. Error: ", p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR.NumVal);
			}
			a1 = new a(this, this, null);
			a1.ac = double.Parse(paramVarArgs[0]);
			a1.c = 0;
			a1.d = 0;
			a1.e = p2Constants.INTER_SPEC_WL_CORR;
			a1.0f = 1;
			a1.af = int.Parse(paramVarArgs[1]);
			a1.ag = int.Parse(paramVarArgs[2]);
			a1.a = p2Enumerations.p2AppManagerState.selfCorr_Run;
			return a1;
		  case 14:
			if (p2AppManagerUtils.isEmptyString(paramVarArgs[0]) || p2AppManagerUtils.isEmptyString(paramVarArgs[1]) || p2AppManagerUtils.isEmptyString(paramVarArgs[2]) || p2AppManagerUtils.isEmptyString(paramVarArgs[3]) || p2AppManagerUtils.isEmptyString(paramVarArgs[4]) || p2AppManagerUtils.isEmptyString(paramVarArgs[5]) || p2AppManagerUtils.isEmptyString(paramVarArgs[6]) || p2AppManagerUtils.isEmptyString(paramVarArgs[7]) || p2AppManagerUtils.isEmptyString(paramVarArgs[9]) || p2AppManagerUtils.isEmptyString(paramVarArgs[10]) || p2AppManagerUtils.isEmptyString(paramVarArgs[11]) || p2AppManagerUtils.isEmptyString(paramVarArgs[12]) || p2AppManagerUtils.isEmptyString(paramVarArgs[13]) || p2AppManagerUtils.isEmptyString(paramVarArgs[14]) || p2AppManagerUtils.isEmptyString(paramVarArgs[15]) || p2AppManagerUtils.isEmptyString(paramVarArgs[16]))
			{
			  throw new p2AppManagerException("Invalid Parameters. Error: ", p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR.NumVal);
			}
			a1 = new a(this, this, null);
			a1.ac = double.Parse(paramVarArgs[0]);
			a1.h = bool.Parse(paramVarArgs[1]);
			a1.i = paramVarArgs[2];
			a1.j = double.Parse(paramVarArgs[3]);
			if (a1.h)
			{
			  a1.b = double.Parse(paramVarArgs[4]);
			  a1.m = double.Parse(paramVarArgs[7]);
			  a1.k = paramVarArgs[5];
			  a1.l = int.Parse(paramVarArgs[6]);
			  a1.n = double.Parse(paramVarArgs[8]);
			}
			else
			{
			  long l7 = this.O.b(i_Conflict.cD.a(), k_Conflict.cD.a(), j_Conflict.cD.a());
			  a1.b = l7 * 50.0D * Math.Pow(10.0D, 3.0D) / Math.Pow(2.0D, 14.0D);
			  a1.m = double.Parse(paramVarArgs[7]);
			}
			a1.t = double.Parse(paramVarArgs[9]);
			a1.u = int.Parse(paramVarArgs[10]);
			a1.v = int.Parse(paramVarArgs[11]);
			a1.w = paramVarArgs[12];
			a1.p = int.Parse(paramVarArgs[13]);
			a1.q = int.Parse(paramVarArgs[14]);
			a1.o = paramVarArgs[15];
			a1.r = bool.Parse(paramVarArgs[16]);
			a1.g = (int)a1.ac * c_Conflict.z;
			a1.a = p2Enumerations.p2AppManagerState.CalibrationCapVsTimeRun;
			a(a1.o, p2Constants.getPath(p2Constants.DETECTOR_AND_CURRENT_RANGE_OPTION_FILE_PATH));
			if (a1.h)
			{
			  a(a1.k, p2Constants.getPath(p2Constants.ACTUATION_DIRECTION_OPTION_FILE_PATH));
			  a(a1.i, p2Constants.getPath(p2Constants.WAVEFORM_OPTION_FILE_PATH));
			  long l7 = (long)Math.Round((a1.j * Math.Pow(2.0D, k_Conflict.cF.a()) - 1.0D) / 100.0D, MidpointRounding.AwayFromZero);
			  this.O.b(i_Conflict.cF.a(), l7, k_Conflict.cF.a(), j_Conflict.cF.a());
			  if (a1.i.contains("Square"))
			  {
				a1.b *= 2.0D;
			  }
			  long l8 = (long)(a1.b * Math.Pow(2.0D, 14.0D) / 50.0D * Math.Pow(10.0D, 3.0D));
			  this.O.b(i_Conflict.cD.a(), l8, k_Conflict.cD.a(), j_Conflict.cD.a());
			  a(a1.l.ToString(), p2Constants.getPath(p2Constants.SAMPLING_RATE_OPTION_FILE_PATH));
			  a(a1.m.ToString(), p2Constants.getPath(p2Constants.EXCITATION_VOLTAGE_OPTION_FILE_PATH));
			  a(a1.n.ToString(), p2Constants.getPath(p2Constants.C2V_GAIN_OPTION_FILE_PATH));
			}
			a(a1.p.ToString(), p2Constants.getPath(p2Constants.PGA1_OPTION_FILE_PATH));
			a(a1.q.ToString(), p2Constants.getPath(p2Constants.PGA2_OPTION_FILE_PATH));
			if (a1.r)
			{
			  this.O.b(i_Conflict.fD.a(), 1L, k_Conflict.fD.a(), j_Conflict.fD.a());
			}
			else
			{
			  this.O.b(i_Conflict.fD.a(), 0L, k_Conflict.fD.a(), j_Conflict.fD.a());
			}
			a(p2Enumerations.p2AppManagerState.CalibrationCapVsTimeRun);
			return a1;
		  case 15:
			if (p2AppManagerUtils.isEmptyString(paramVarArgs[0]) || p2AppManagerUtils.isEmptyString(paramVarArgs[1]) || p2AppManagerUtils.isEmptyString(paramVarArgs[2]) || p2AppManagerUtils.isEmptyString(paramVarArgs[3]) || p2AppManagerUtils.isEmptyString(paramVarArgs[4]) || p2AppManagerUtils.isEmptyString(paramVarArgs[5]) || p2AppManagerUtils.isEmptyString(paramVarArgs[6]) || p2AppManagerUtils.isEmptyString(paramVarArgs[7]) || p2AppManagerUtils.isEmptyString(paramVarArgs[8]))
			{
			  throw new p2AppManagerException("Invalid Parameters. Error: ", p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR.NumVal);
			}
			a1 = new a(this, this, null);
			a1.ac = double.Parse(paramVarArgs[0]);
			a1.o = paramVarArgs[1];
			a1.p = int.Parse(paramVarArgs[2]);
			a1.q = int.Parse(paramVarArgs[3]);
			a1.r = bool.Parse(paramVarArgs[4]);
			a1.h = bool.Parse(paramVarArgs[7]);
			a1.v = int.Parse(paramVarArgs[8]);
			if (a1.h)
			{
			  a1.b = double.Parse(paramVarArgs[5]);
			  a1.i = paramVarArgs[6];
			}
			else
			{
			  long l7 = this.O.b(i_Conflict.cD.a(), k_Conflict.cD.a(), j_Conflict.cD.a());
			  a1.b = l7 * 50.0D * Math.Pow(10.0D, 3.0D) / Math.Pow(2.0D, 14.0D);
			}
			a1.a = p2Enumerations.p2AppManagerState.CalibrationDelayCompensationRun;
			a(a1.o, p2Constants.getPath(p2Constants.DETECTOR_AND_CURRENT_RANGE_OPTION_FILE_PATH));
			if (a1.h)
			{
			  if (a1.i.contains("Square"))
			  {
				a1.b *= 2.0D;
			  }
			  long l7 = (long)(a1.b * Math.Pow(2.0D, 14.0D) / 50.0D * Math.Pow(10.0D, 3.0D));
			  this.O.b(i_Conflict.cD.a(), l7, k_Conflict.cD.a(), j_Conflict.cD.a());
			}
			a(a1.p.ToString(), p2Constants.getPath(p2Constants.PGA1_OPTION_FILE_PATH));
			a(a1.q.ToString(), p2Constants.getPath(p2Constants.PGA2_OPTION_FILE_PATH));
			if (a1.r)
			{
			  this.O.b(i_Conflict.fD.a(), 1L, k_Conflict.fD.a(), j_Conflict.fD.a());
			}
			else
			{
			  this.O.b(i_Conflict.fD.a(), 0L, k_Conflict.fD.a(), j_Conflict.fD.a());
			}
			this.O.b(i_Conflict.aW.a(), a1.v, k_Conflict.aW.a(), j_Conflict.aW.a());
			this.O.b(i_Conflict.gt.a(), a1.v, k_Conflict.gt.a(), j_Conflict.gt.a());
			a(p2Enumerations.p2AppManagerState.CalibrationDelayCompensationRun);
			return a1;
		  case 16:
			if (p2AppManagerUtils.isEmptyString(paramVarArgs[0]) || p2AppManagerUtils.isEmptyString(paramVarArgs[1]) || p2AppManagerUtils.isEmptyString(paramVarArgs[2]) || p2AppManagerUtils.isEmptyString(paramVarArgs[3]) || p2AppManagerUtils.isEmptyString(paramVarArgs[4]) || p2AppManagerUtils.isEmptyString(paramVarArgs[5]) || p2AppManagerUtils.isEmptyString(paramVarArgs[6]) || p2AppManagerUtils.isEmptyString(paramVarArgs[7]) || p2AppManagerUtils.isEmptyString(paramVarArgs[8]) || p2AppManagerUtils.isEmptyString(paramVarArgs[9]) || p2AppManagerUtils.isEmptyString(paramVarArgs[10]))
			{
			  throw new p2AppManagerException("Invalid Parameters. Error: ", p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR.NumVal);
			}
			a1 = new a(this, this, null);
			a1.ac = double.Parse(paramVarArgs[0]);
			a1.h = bool.Parse(paramVarArgs[7]);
			if (a1.h)
			{
			  a1.b = double.Parse(paramVarArgs[1]);
			  a1.i = paramVarArgs[5];
			}
			else
			{
			  long l7 = this.O.b(i_Conflict.cD.a(), k_Conflict.cD.a(), j_Conflict.cD.a());
			  a1.b = l7 * 50.0D * Math.Pow(10.0D, 3.0D) / Math.Pow(2.0D, 14.0D);
			}
			a1.y = bool.Parse(paramVarArgs[2]);
			a1.x = bool.Parse(paramVarArgs[3]);
			a1.z = bool.Parse(paramVarArgs[4]);
			a1.o = paramVarArgs[6];
			a1.p = int.Parse(paramVarArgs[8]);
			a1.q = int.Parse(paramVarArgs[9]);
			a1.v = int.Parse(paramVarArgs[10]);
			a1.a = p2Enumerations.p2AppManagerState.CalibrationCoreRun;
			if (a1.h)
			{
			  if (a1.i.contains("Square"))
			  {
				a1.b *= 2.0D;
			  }
			  long l7 = (long)(a1.b * Math.Pow(2.0D, 14.0D) / 50.0D * Math.Pow(10.0D, 3.0D));
			  this.O.b(i_Conflict.cD.a(), l7, k_Conflict.cD.a(), j_Conflict.cD.a());
			}
			a(a1.o, p2Constants.getPath(p2Constants.DETECTOR_AND_CURRENT_RANGE_OPTION_FILE_PATH));
			a(a1.p.ToString(), p2Constants.getPath(p2Constants.PGA1_OPTION_FILE_PATH));
			a(a1.q.ToString(), p2Constants.getPath(p2Constants.PGA2_OPTION_FILE_PATH));
			this.O.b(i_Conflict.aW.a(), a1.v, k_Conflict.aW.a(), j_Conflict.aW.a());
			this.O.b(i_Conflict.gt.a(), a1.v, k_Conflict.gt.a(), j_Conflict.gt.a());
			a(p2Enumerations.p2AppManagerState.CalibrationDelayCompensationRun);
			return a1;
		  case 17:
			if (p2AppManagerUtils.isEmptyString(paramVarArgs[0]) || p2AppManagerUtils.isEmptyString(paramVarArgs[1]) || p2AppManagerUtils.isEmptyString(paramVarArgs[2]) || p2AppManagerUtils.isEmptyString(paramVarArgs[3]) || p2AppManagerUtils.isEmptyString(paramVarArgs[4]) || p2AppManagerUtils.isEmptyString(paramVarArgs[5]) || p2AppManagerUtils.isEmptyString(paramVarArgs[6]) || p2AppManagerUtils.isEmptyString(paramVarArgs[7]) || p2AppManagerUtils.isEmptyString(paramVarArgs[8]) || p2AppManagerUtils.isEmptyString(paramVarArgs[9]) || p2AppManagerUtils.isEmptyString(paramVarArgs[10]) || p2AppManagerUtils.isEmptyString(paramVarArgs[11]) || p2AppManagerUtils.isEmptyString(paramVarArgs[12]) || p2AppManagerUtils.isEmptyString(paramVarArgs[13]) || p2AppManagerUtils.isEmptyString(paramVarArgs[14]) || p2AppManagerUtils.isEmptyString(paramVarArgs[15]))
			{
			  throw new p2AppManagerException("Invalid Parameters. Error: ", p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR.NumVal);
			}
			a1 = new a(this, this, null);
			a1.ac = double.Parse(paramVarArgs[0]);
			a1.h = bool.Parse(paramVarArgs[13]);
			if (a1.h)
			{
			  a1.b = double.Parse(paramVarArgs[1]);
			  a1.m = double.Parse(paramVarArgs[4]);
			  a1.n = double.Parse(paramVarArgs[11]);
			  a1.i = paramVarArgs[12];
			}
			else
			{
			  long l7 = this.O.b(i_Conflict.cD.a(), k_Conflict.cD.a(), j_Conflict.cD.a());
			  a1.b = l7 * 50.0D * Math.Pow(10.0D, 3.0D) / Math.Pow(2.0D, 14.0D);
			  a1.m = double.Parse(paramVarArgs[4]);
			}
			a1.A = bool.Parse(paramVarArgs[2]);
			a1.B = double.Parse(paramVarArgs[3]);
			a1.v = int.Parse(paramVarArgs[5]);
			a1.C = paramVarArgs[6];
			a1.D = paramVarArgs[7];
			if (paramVarArgs.Length == 17)
			{
			  if (p2AppManagerUtils.isEmptyString(paramVarArgs[16]))
			  {
				throw new p2AppManagerException("Invalid Parameters. Error: ", p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR.NumVal);
			  }
			  a1.t = double.Parse(paramVarArgs[16]);
			  a1.s = true;
			}
			else
			{
			  a1.s = false;
			}
			if (paramVarArgs.Length == 18)
			{
			  if (p2AppManagerUtils.isEmptyString(paramVarArgs[17]))
			  {
				throw new p2AppManagerException("Invalid Parameters. Error: ", p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR.NumVal);
			  }
			  a1.ah = paramVarArgs[17];
			}
			else
			{
			  a1.ah = null;
			}
			a1.p = int.Parse(paramVarArgs[8]);
			a1.q = int.Parse(paramVarArgs[9]);
			a1.o = paramVarArgs[10];
			a1.X = bool.Parse(paramVarArgs[14]);
			a1.Y = paramVarArgs[15];
			a1.e = p2Constants.CALIB_WL_CORR;
			a1.a = p2Enumerations.p2AppManagerState.CalibrationGeneration;
			if (a1.h)
			{
			  if (a1.i.contains("Square"))
			  {
				a1.b *= 2.0D;
			  }
			  long l7 = (long)(a1.b * Math.Pow(2.0D, 14.0D) / 50.0D * Math.Pow(10.0D, 3.0D));
			  this.O.b(i_Conflict.cD.a(), l7, k_Conflict.cD.a(), j_Conflict.cD.a());
			  a(a1.m.ToString(), p2Constants.getPath(p2Constants.EXCITATION_VOLTAGE_OPTION_FILE_PATH));
			  a(a1.n.ToString(), p2Constants.getPath(p2Constants.C2V_GAIN_OPTION_FILE_PATH));
			}
			a(a1.o, p2Constants.getPath(p2Constants.DETECTOR_AND_CURRENT_RANGE_OPTION_FILE_PATH));
			a(a1.p.ToString(), p2Constants.getPath(p2Constants.PGA1_OPTION_FILE_PATH));
			a(a1.q.ToString(), p2Constants.getPath(p2Constants.PGA2_OPTION_FILE_PATH));
			this.O.b(i_Conflict.aW.a(), a1.v, k_Conflict.aW.a(), j_Conflict.aW.a());
			this.O.b(i_Conflict.gt.a(), a1.v, k_Conflict.gt.a(), j_Conflict.gt.a());
			a(p2Enumerations.p2AppManagerState.CalibrationDelayCompensationRun);
			return a1;
		  case 18:
			if (p2AppManagerUtils.isEmptyString(paramVarArgs[0]) || p2AppManagerUtils.isEmptyString(paramVarArgs[1]) || p2AppManagerUtils.isEmptyString(paramVarArgs[2]) || p2AppManagerUtils.isEmptyString(paramVarArgs[3]) || p2AppManagerUtils.isEmptyString(paramVarArgs[4]) || p2AppManagerUtils.isEmptyString(paramVarArgs[5]) || p2AppManagerUtils.isEmptyString(paramVarArgs[6]) || p2AppManagerUtils.isEmptyString(paramVarArgs[7]) || p2AppManagerUtils.isEmptyString(paramVarArgs[9]) || p2AppManagerUtils.isEmptyString(paramVarArgs[10]) || p2AppManagerUtils.isEmptyString(paramVarArgs[11]) || p2AppManagerUtils.isEmptyString(paramVarArgs[12]))
			{
			  throw new p2AppManagerException("Invalid Parameters. Error: ", p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR.NumVal);
			}
			a1 = new a(this, this, null);
			a1.ac = double.Parse(paramVarArgs[0]);
			a1.h = bool.Parse(paramVarArgs[1]);
			a1.i = paramVarArgs[2];
			a1.j = double.Parse(paramVarArgs[3]);
			if (a1.h)
			{
			  a1.b = double.Parse(paramVarArgs[4]);
			  a1.m = double.Parse(paramVarArgs[11]);
			  a1.k = paramVarArgs[5];
			  a1.l = int.Parse(paramVarArgs[10]);
			  a1.n = double.Parse(paramVarArgs[12]);
			}
			else
			{
			  long l7 = this.O.b(i_Conflict.cD.a(), k_Conflict.cD.a(), j_Conflict.cD.a());
			  a1.b = l7 * 50.0D * Math.Pow(10.0D, 3.0D) / Math.Pow(2.0D, 14.0D);
			  a1.m = double.Parse(paramVarArgs[11]);
			}
			a1.o = paramVarArgs[6];
			a1.p = int.Parse(paramVarArgs[7]);
			a1.q = int.Parse(paramVarArgs[8]);
			a1.r = bool.Parse(paramVarArgs[9]);
			a1.g = (int)a1.ac * c_Conflict.z;
			a1.a = p2Enumerations.p2AppManagerState.CapCurrentRun;
			if (a1.h)
			{
			  a(a1.k, p2Constants.getPath(p2Constants.ACTUATION_DIRECTION_OPTION_FILE_PATH));
			  a(a1.i, p2Constants.getPath(p2Constants.WAVEFORM_OPTION_FILE_PATH));
			  long l7 = (long)Math.Round((a1.j * Math.Pow(2.0D, k_Conflict.cF.a()) - 1.0D) / 100.0D, MidpointRounding.AwayFromZero);
			  this.O.b(i_Conflict.cF.a(), l7, k_Conflict.cF.a(), j_Conflict.cF.a());
			  if (a1.i.contains("Square"))
			  {
				a1.b *= 2.0D;
			  }
			  long l8 = (long)(a1.b * Math.Pow(2.0D, 14.0D) / 50.0D * Math.Pow(10.0D, 3.0D));
			  this.O.b(i_Conflict.cD.a(), l8, k_Conflict.cD.a(), j_Conflict.cD.a());
			  a(a1.l.ToString(), p2Constants.getPath(p2Constants.SAMPLING_RATE_OPTION_FILE_PATH));
			  a(a1.m.ToString(), p2Constants.getPath(p2Constants.EXCITATION_VOLTAGE_OPTION_FILE_PATH));
			  a(a1.n.ToString(), p2Constants.getPath(p2Constants.C2V_GAIN_OPTION_FILE_PATH));
			}
			a(a1.o, p2Constants.getPath(p2Constants.DETECTOR_AND_CURRENT_RANGE_OPTION_FILE_PATH));
			a(a1.p.ToString(), p2Constants.getPath(p2Constants.PGA1_OPTION_FILE_PATH));
			a(a1.q.ToString(), p2Constants.getPath(p2Constants.PGA2_OPTION_FILE_PATH));
			if (a1.r)
			{
			  this.O.b(i_Conflict.fD.a(), 1L, k_Conflict.fD.a(), j_Conflict.fD.a());
			}
			else
			{
			  this.O.b(i_Conflict.fD.a(), 0L, k_Conflict.fD.a(), j_Conflict.fD.a());
			}
			a(p2Enumerations.p2AppManagerState.CapCurrentRun);
			return a1;
		  case 19:
			if (p2AppManagerUtils.isEmptyString(paramVarArgs[0]))
			{
			  throw new p2AppManagerException("Invalid Parameters. Error: ", p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR.NumVal);
			}
			a1 = new a(this, this, null);
			a1.C = paramVarArgs[0];
			a1.a = p2Enumerations.p2AppManagerState.SampleIDBurn;
			return a1;
		  case 20:
			a1 = new a(this, this, null);
			a1.a = p2Enumerations.p2AppManagerState.TempReading;
			return a1;
		  case 21:
			a1 = new a(this, this, null);
			a1.a = p2Enumerations.p2AppManagerState.ASICRegistersReading;
			return a1;
		  case 22:
			a1 = new a(this, this, null);
			a1.a = p2Enumerations.p2AppManagerState.SampleFoldersReading;
			return a1;
		  case 23:
			if (p2AppManagerUtils.isEmptyString(paramVarArgs[0]) || p2AppManagerUtils.isEmptyString(paramVarArgs[1]) || p2AppManagerUtils.isEmptyString(paramVarArgs[2]) || p2AppManagerUtils.isEmptyString(paramVarArgs[3]) || p2AppManagerUtils.isEmptyString(paramVarArgs[4]) || p2AppManagerUtils.isEmptyString(paramVarArgs[5]) || p2AppManagerUtils.isEmptyString(paramVarArgs[6]) || p2AppManagerUtils.isEmptyString(paramVarArgs[7]) || p2AppManagerUtils.isEmptyString(paramVarArgs[8]))
			{
			  throw new p2AppManagerException("Invalid Parameters. Error: ", p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR.NumVal);
			}
			a1 = new a(this, this, null);
			a1.ac = double.Parse(paramVarArgs[0]);
			a1.j = double.Parse(paramVarArgs[1]);
			a1.l = int.Parse(paramVarArgs[2]);
			a1.m = double.Parse(paramVarArgs[3]);
			a1.n = double.Parse(paramVarArgs[4]);
			a1.H = double.Parse(paramVarArgs[5]);
			a1.I = double.Parse(paramVarArgs[6]);
			a1.J = double.Parse(paramVarArgs[7]);
			a1.K = double.Parse(paramVarArgs[8]);
			a("Push-Pull", p2Constants.getPath(p2Constants.ACTUATION_DIRECTION_OPTION_FILE_PATH));
			a("Sine", p2Constants.getPath(p2Constants.WAVEFORM_OPTION_FILE_PATH));
			a1.g = (int)a1.ac * c_Conflict.z;
			a1.a = p2Enumerations.p2AppManagerState.ResponseCalculation;
			l1 = (long)Math.Round((a1.j * Math.Pow(2.0D, k_Conflict.cF.a()) - 1.0D) / 100.0D, MidpointRounding.AwayFromZero);
			this.O.b(i_Conflict.cF.a(), l1, k_Conflict.cF.a(), j_Conflict.cF.a());
			a1.b = a1.I;
			l2 = (long)(a1.b * Math.Pow(2.0D, 14.0D) / 50.0D * Math.Pow(10.0D, 3.0D));
			this.O.b(i_Conflict.cD.a(), l2, k_Conflict.cD.a(), j_Conflict.cD.a());
			a(a1.l.ToString(), p2Constants.getPath(p2Constants.SAMPLING_RATE_OPTION_FILE_PATH));
			a(a1.m.ToString(), p2Constants.getPath(p2Constants.EXCITATION_VOLTAGE_OPTION_FILE_PATH));
			a(a1.n.ToString(), p2Constants.getPath(p2Constants.C2V_GAIN_OPTION_FILE_PATH));
			a(p2Enumerations.p2AppManagerState.ResponseCalculation);
			return a1;
		  case 24:
			if (p2AppManagerUtils.isEmptyString(paramVarArgs[0]) || p2AppManagerUtils.isEmptyString(paramVarArgs[1]) || p2AppManagerUtils.isEmptyString(paramVarArgs[2]) || p2AppManagerUtils.isEmptyString(paramVarArgs[3]) || p2AppManagerUtils.isEmptyString(paramVarArgs[4]) || p2AppManagerUtils.isEmptyString(paramVarArgs[5]) || p2AppManagerUtils.isEmptyString(paramVarArgs[6]) || p2AppManagerUtils.isEmptyString(paramVarArgs[7]) || p2AppManagerUtils.isEmptyString(paramVarArgs[8]))
			{
			  throw new p2AppManagerException("Invalid Parameters. Error: ", p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR.NumVal);
			}
			a1 = new a(this, this, null);
			a1.ac = double.Parse(paramVarArgs[0]);
			this.A_Conflict = a1.ac;
			a1.j = double.Parse(paramVarArgs[1]);
			a1.l = int.Parse(paramVarArgs[2]);
			a1.m = double.Parse(paramVarArgs[3]);
			this.B_Conflict = a1.m;
			a1.n = double.Parse(paramVarArgs[4]);
			a1.H = double.Parse(paramVarArgs[5]);
			a1.I = double.Parse(paramVarArgs[6]);
			a1.J = double.Parse(paramVarArgs[7]);
			a1.K = double.Parse(paramVarArgs[8]);
			a1.g = (int)a1.ac * c_Conflict.z;
			a1.a = p2Enumerations.p2AppManagerState.ParametersCalculation;
			a("Push-Pull", p2Constants.getPath(p2Constants.ACTUATION_DIRECTION_OPTION_FILE_PATH));
			a("Sine", p2Constants.getPath(p2Constants.WAVEFORM_OPTION_FILE_PATH));
			this.O.b(i_Conflict.cH.a(), 3L, k_Conflict.cH.a(), j_Conflict.cH.a());
			this.O.b(i_Conflict.cJ.a(), 1L, k_Conflict.cJ.a(), j_Conflict.cJ.a());
			this.O.b(i_Conflict.cY.a(), 0L, k_Conflict.cY.a(), j_Conflict.cY.a());
			l3 = (long)Math.Round((a1.j * Math.Pow(2.0D, k_Conflict.cF.a()) - 1.0D) / 100.0D, MidpointRounding.AwayFromZero);
			this.O.b(i_Conflict.cF.a(), l3, k_Conflict.cF.a(), j_Conflict.cF.a());
			a1.b = 10.0D;
			l4 = (long)(a1.b * Math.Pow(2.0D, 14.0D) / 50.0D * Math.Pow(10.0D, 3.0D));
			this.O.b(i_Conflict.cD.a(), l4, k_Conflict.cD.a(), j_Conflict.cD.a());
			a(a1.l.ToString(), p2Constants.getPath(p2Constants.SAMPLING_RATE_OPTION_FILE_PATH));
			a(a1.m.ToString(), p2Constants.getPath(p2Constants.EXCITATION_VOLTAGE_OPTION_FILE_PATH));
			a(a1.n.ToString(), p2Constants.getPath(p2Constants.C2V_GAIN_OPTION_FILE_PATH));
			a(p2Enumerations.p2AppManagerState.ParametersCalculation);
			return a1;
		  case 25:
			if (p2AppManagerUtils.isEmptyString(paramVarArgs[0]) || p2AppManagerUtils.isEmptyString(paramVarArgs[1]) || p2AppManagerUtils.isEmptyString(paramVarArgs[2]) || p2AppManagerUtils.isEmptyString(paramVarArgs[3]) || p2AppManagerUtils.isEmptyString(paramVarArgs[4]) || p2AppManagerUtils.isEmptyString(paramVarArgs[5]) || p2AppManagerUtils.isEmptyString(paramVarArgs[6]) || p2AppManagerUtils.isEmptyString(paramVarArgs[7]) || p2AppManagerUtils.isEmptyString(paramVarArgs[8]))
			{
			  throw new p2AppManagerException("Invalid Parameters. Error: ", p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR.NumVal);
			}
			Console.WriteLine("Started coefficients trimming");
			a1 = new a(this, this, null);
			a1.L = double.Parse(paramVarArgs[0]);
			a1.M = double.Parse(paramVarArgs[1]);
			a1.N = double.Parse(paramVarArgs[2]);
			a1.O = double.Parse(paramVarArgs[3]);
			a1.P = double.Parse(paramVarArgs[4]);
			a1.Q = double.Parse(paramVarArgs[5]);
			a1.R = double.Parse(paramVarArgs[6]);
			a1.ac = double.Parse(paramVarArgs[7]);
			a1.m = double.Parse(paramVarArgs[8]);
			this.A_Conflict = a1.ac;
			this.B_Conflict = a1.m;
			a1.a = p2Enumerations.p2AppManagerState.CoefficientsTrimming;
			a(p2Enumerations.p2AppManagerState.CoefficientsTrimming);
			return a1;
		  case 26:
			if (p2AppManagerUtils.isEmptyString(paramVarArgs[0]) || p2AppManagerUtils.isEmptyString(paramVarArgs[1]) || p2AppManagerUtils.isEmptyString(paramVarArgs[2]) || p2AppManagerUtils.isEmptyString(paramVarArgs[3]) || p2AppManagerUtils.isEmptyString(paramVarArgs[4]) || p2AppManagerUtils.isEmptyString(paramVarArgs[5]) || p2AppManagerUtils.isEmptyString(paramVarArgs[6]))
			{
			  throw new p2AppManagerException("Invalid Parameters. Error: ", p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR.NumVal);
			}
			a1 = new a(this, this, null);
			a1.ac = this.A_Conflict;
			Console.WriteLine("Started phase trimming Run time of TrimPhase = " + this.A_Conflict);
			a1.g = (int)a1.ac * c_Conflict.z;
			a1.L = double.Parse(paramVarArgs[0]);
			a1.M = double.Parse(paramVarArgs[1]);
			a1.N = double.Parse(paramVarArgs[2]);
			a1.O = double.Parse(paramVarArgs[3]);
			a1.P = double.Parse(paramVarArgs[4]);
			a1.Q = double.Parse(paramVarArgs[5]);
			a1.R = double.Parse(paramVarArgs[6]);
			a1.a = p2Enumerations.p2AppManagerState.PhaseTrimming;
			l5 = this.O.b(i_Conflict.cD.a(), k_Conflict.cD.a(), j_Conflict.cD.a());
			a1.b = l5 * 50.0D * Math.Pow(10.0D, 3.0D) / Math.Pow(2.0D, 14.0D);
			a(p2Enumerations.p2AppManagerState.PhaseTrimming);
			return a1;
		  case 27:
			if (p2AppManagerUtils.isEmptyString(paramVarArgs[0]) || p2AppManagerUtils.isEmptyString(paramVarArgs[1]) || p2AppManagerUtils.isEmptyString(paramVarArgs[2]) || p2AppManagerUtils.isEmptyString(paramVarArgs[3]) || p2AppManagerUtils.isEmptyString(paramVarArgs[4]) || p2AppManagerUtils.isEmptyString(paramVarArgs[5]) || p2AppManagerUtils.isEmptyString(paramVarArgs[6]) || p2AppManagerUtils.isEmptyString(paramVarArgs[7]))
			{
			  throw new p2AppManagerException("Invalid Parameters. Error: ", p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR.NumVal);
			}
			a1 = new a(this, this, null);
			a1.ac = this.A_Conflict;
			Console.WriteLine("Started fast phase trimming Run time of TrimPhaseFast = " + this.A_Conflict);
			a1.g = (int)a1.ac * c_Conflict.z;
			a1.L = double.Parse(paramVarArgs[0]);
			a1.M = double.Parse(paramVarArgs[1]);
			a1.N = double.Parse(paramVarArgs[2]);
			a1.O = double.Parse(paramVarArgs[3]);
			a1.S = double.Parse(paramVarArgs[4]);
			a1.T = double.Parse(paramVarArgs[5]);
			a1.U = double.Parse(paramVarArgs[6]);
			a1.R = double.Parse(paramVarArgs[7]);
			a1.a = p2Enumerations.p2AppManagerState.FastPhaseTrimming;
			l6 = this.O.b(i_Conflict.cD.a(), k_Conflict.cD.a(), j_Conflict.cD.a());
			a1.b = l6 * 50.0D * Math.Pow(10.0D, 3.0D) / Math.Pow(2.0D, 14.0D);
			a(p2Enumerations.p2AppManagerState.FastPhaseTrimming);
			return a1;
		  case 28:
			if (p2AppManagerUtils.isEmptyString(paramVarArgs[0]))
			{
			  throw new p2AppManagerException("Invalid Parameters. Error: ", p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR.NumVal);
			}
			Console.WriteLine("Started stability checking");
			a1 = new a(this, this, null);
			a1.ac = double.Parse(paramVarArgs[1]);
			a1.g = (int)a1.ac * c_Conflict.z;
			a1.L = double.Parse(paramVarArgs[2]);
			a1.V = double.Parse(paramVarArgs[0]);
			a1.m = double.Parse(paramVarArgs[3]);
			a1.a = p2Enumerations.p2AppManagerState.StabilityCheck;
			a(p2Enumerations.p2AppManagerState.StabilityCheck);
			return a1;
		  case 29:
			if (p2AppManagerUtils.isEmptyString(paramVarArgs[0]))
			{
			  throw new p2AppManagerException("Invalid Parameters. Error: ", p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR.NumVal);
			}
			a1 = new a(this, this, null);
			a1.ac = double.Parse(paramVarArgs[1]);
			a1.g = (int)a1.ac * c_Conflict.z;
			a1.W = int.Parse(paramVarArgs[0]);
			a1.m = double.Parse(paramVarArgs[2]);
			a1.a = p2Enumerations.p2AppManagerState.WaveformPreview;
			a(p2Enumerations.p2AppManagerState.WaveformPreview);
			return a1;
		}
		return null;
	  }

	  private void a(p2Enumerations.p2DeviceAction paramp2DeviceAction, double[][] paramArrayOfDouble, p2Enumerations.p2AppManagerStatus paramp2AppManagerStatus)
	  {
		a(paramp2DeviceAction, paramArrayOfDouble);
		a(p2Enumerations.p2AppManagerState.Idle);
		p2DeviceNotificationResult p2DeviceNotificationResult = a(paramp2DeviceAction, paramp2AppManagerStatus);
		setChanged();
		notifyObservers(p2DeviceNotificationResult);
	  }

	  private void a(p2Enumerations.p2DeviceAction paramp2DeviceAction, double[][] paramArrayOfDouble)
	  {
		switch (null.a[paramp2DeviceAction.ordinal()])
		{
		  case 30:
			this.r_Conflict = (double[][])null;
			break;
		  case 1:
			this.k_Conflict = paramArrayOfDouble;
			break;
		  case 2:
			this.k_Conflict = paramArrayOfDouble;
			break;
		  case 3:
			this.e_Conflict = paramArrayOfDouble;
			break;
		  case 4:
			this.f_Conflict = paramArrayOfDouble;
			break;
		  case 5:
			this.e_Conflict = paramArrayOfDouble;
			break;
		  case 6:
			this.g_Conflict = paramArrayOfDouble;
			break;
		  case 8:
			this.h_Conflict = paramArrayOfDouble;
			break;
		  case 9:
			this.i_Conflict = paramArrayOfDouble;
			break;
		  case 10:
			this.j_Conflict = paramArrayOfDouble;
			break;
		  case 11:
			this.l_Conflict = paramArrayOfDouble;
			break;
		  case 12:
			this.m_Conflict = paramArrayOfDouble;
			break;
		  case 14:
			this.n_Conflict = paramArrayOfDouble;
			break;
		  case 17:
			this.o_Conflict = paramArrayOfDouble;
			break;
		  case 18:
			this.p_Conflict = paramArrayOfDouble;
			break;
		  case 20:
			this.q_Conflict = paramArrayOfDouble;
			break;
		  case 23:
			this.r_Conflict = paramArrayOfDouble;
			break;
		  case 24:
			this.s_Conflict = paramArrayOfDouble;
			break;
		  case 25:
			this.t_Conflict = paramArrayOfDouble;
			break;
		  case 26:
		  case 27:
			this.u_Conflict = paramArrayOfDouble;
			break;
		  case 28:
			this.v_Conflict = paramArrayOfDouble;
			break;
		  case 29:
			this.w_Conflict = paramArrayOfDouble;
			break;
		  case 13:
			this.k_Conflict = paramArrayOfDouble;
			if (paramArrayOfDouble != null)
			{
			  a(paramArrayOfDouble[4], new string[] {this.c_Conflict, this.G_Conflict});
			}
			break;
		}
	  }

	  public static void a(double[] paramArrayOfDouble, params string[] paramVarArgs)
	  {
		string[] arrayOfString = null;
		string str1 = paramVarArgs[0];
		string str2 = paramVarArgs[1];
		try
		{
		  if (!str1.Equals(""))
		  {
			string str = p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.CONFIG_SAMPLE_PATH_TEMPLATE), new object[] {str1 + Path.DirectorySeparatorChar + str2 + Path.DirectorySeparatorChar});
			File file = new File(str);
			File[] arrayOfFile = file.listFiles(new FileFilterAnonymousInnerClass());
			arrayOfString = new string[arrayOfFile.Length];
			for (sbyte b1 = 0; b1 < arrayOfFile.Length; b1++)
			{
			  arrayOfString[b1] = arrayOfFile[b1].Name;
			}
		  }
		  if (arrayOfString != null)
		  {
			foreach (string str in arrayOfString)
			{
			  p2AppManagerUtils.writeFileOfArray(paramArrayOfDouble, p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.CONFIG_SAMPLE_PROFILE_FILES_PATH_TEMPLATE), new object[] {str1, str2 + Path.DirectorySeparatorChar + str, "corr.cal"}), "\n");
			}
		  }
		}
		catch (Exception exception)
		{
		  b_Conflict.error(exception.Message);
		}
	  }

	  private class FileFilterAnonymousInnerClass : FileFilter
	  {
		  public bool accept(File param1File)
		  {
			  return (param1File.Directory && !param1File.Name.Equals(".svn"));
		  }
	  }

	  private p2DeviceNotificationResult a(p2Enumerations.p2DeviceAction paramp2DeviceAction, p2Enumerations.p2AppManagerStatus paramp2AppManagerStatus)
	  {
		p2DeviceNotificationResult p2DeviceNotificationResult = new p2DeviceNotificationResult();
		p2DeviceNotificationResult.Action = paramp2DeviceAction;
		p2DeviceNotificationResult.DeviceId = this.c_Conflict;
		p2DeviceNotificationResult.Status = paramp2AppManagerStatus;
		return p2DeviceNotificationResult;
	  }

	  private string a(string paramString)
	  {
		b_Conflict.info("selectProfileBasedOnTemp function started");
		string[] arrayOfString = p2AppManagerUtils.getFolderSubFoldersNames(p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.CONFIG_SAMPLE_PATH_TEMPLATE), new object[] {this.c_Conflict}), new List<object>(), false);
		if (arrayOfString == null || arrayOfString.Length == 0)
		{
		  throw new p2AppManagerException("No configuration foldres for this sample : " + this.c_Conflict, p2Enumerations.p2AppManagerStatus.NO_SAMPLE_CONFIG_FOLDERS_ERROR.NumVal);
		}
		SortedDictionary treeMap = new SortedDictionary();
		foreach (string str in arrayOfString)
		{
		  if (!str.Equals(".svn"))
		  {
			double? double = Convert.ToDouble(this.C_Conflict.a(this.c_Conflict, str + Path.DirectorySeparatorChar + paramString));
			if (double != null)
			{
			  treeMap[double] = str;
			}
		  }
		}
		if (treeMap.Count == 0)
		{
		  throw new p2AppManagerException("Failed to load all sample configuration floders for this sample : " + this.c_Conflict, p2Enumerations.p2AppManagerStatus.NO_VALID_SAMPLE_CONFIG_FOLDERS_ERROR.NumVal);
		}
		if (treeMap.Count == 1)
		{
		  return (string)treeMap[treeMap.Keys.ToArray()[0]];
		}
		System.Collections.IDictionary map = a(treeMap, paramString);
		long l1 = z();
		System.Collections.IEnumerator iterator = map.Keys.GetEnumerator();
		while (iterator.MoveNext())
		{
		  long l2 = ((long?)iterator.Current).Value;
		  if (l1 <= l2)
		  {
			b_Conflict.info("selectProfileBasedOnTemp function finished");
			return (string)treeMap[map[Convert.ToInt64(l2)]];
		  }
		}
		throw new p2AppManagerException("No Sample Profile matched with current temp  : " + this.c_Conflict, p2Enumerations.p2AppManagerStatus.NO_SAMPLE_PROFILE_SELECTED_ERROR.NumVal);
	  }

	  private IDictionary<long, double> a(IDictionary<double, string> paramMap, string paramString)
	  {
		b_Conflict.info("getTempBoundaries function started");
		Hashtable hashMap = new Hashtable();
		paramMap[Convert.ToDouble(1.34217727E8D)] = "";
		double?[] arrayOfDouble = (double?[])paramMap.Keys.toArray(new double?[paramMap.Count]);
		bool @bool = (!string.ReferenceEquals(this.E_Conflict, null)) ? 1 : 0;
		for (sbyte b1 = 0; b1 < arrayOfDouble.Length - 1; b1++)
		{
		  long l1 = (long)((arrayOfDouble[b1].Value + arrayOfDouble[b1 + true].Value) / 2.0D);
		  if (@bool)
		  {
			if (this.E_Conflict.Equals((string)paramMap[arrayOfDouble[b1]] + Path.DirectorySeparatorChar + paramString))
			{
			  l1 += 20L;
			}
			else if (this.E_Conflict.Equals((string)paramMap[arrayOfDouble[b1 + true]] + Path.DirectorySeparatorChar + paramString))
			{
			  l1 -= 20L;
			}
		  }
		  hashMap[Convert.ToInt64(l1)] = arrayOfDouble[b1];
		}
		b_Conflict.info("getTempBoundaries function finished");
		return hashMap;
	  }

	  private long z()
	  {
		b_Conflict.info("getBoardTemperature function started");
		long l1 = -1L;
		try
		{
		  l1 = this.O.d();
		}
		catch (Exception exception)
		{
		  b_Conflict.error(exception.Message);
		}
		b_Conflict.info("getBoardTemperature function finished");
		return l1;
	  }

	  private void A()
	  {
		short s1 = a(65408, 1).getShort(0);
		if (s1 == 1 || s1 == 0)
		{
		  a(true);
		}
		else if (s1 == 2)
		{
		  a(false);
		}
	  }

	  private void B()
	  {
		string str = p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.CONFIG_SAMPLE_PATH_TEMPLATE), new object[] {this.c_Conflict});
		p2AppManagerUtils.removeDir(str, true);
		a(true);
		F();
	  }

	  private void C()
	  {
		string str = p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.OPTICAL_SETTINGS_FILE_PATH), new object[] {this.c_Conflict});
		File file = new File(str);
		if (file.exists())
		{
		  file.delete();
		}
		b_Conflict(false);
	  }

	  private string[] D()
	  {
		short s1 = 0;
		List<object> arrayList = new List<object>();
		string[] arrayOfString = new string[1];
		if (a(s1, 1).getShort(0) == 1)
		{
		  s1 = ++s1 + a(s1, 1).getShort(0);
		  short s3 = a(++s1, 1).getShort(0);
		  s1++;
		  if (s3 >= 16)
		  {
			short s4 = a(s1, 2).getShort(0);
			s1 += 2;
			s1 += s4;
		  }
		  else
		  {
			s1 += a(s1, 1).getShort(0);
			s1++;
		  }
		}
		else
		{
		  s1++;
		}
		short s2 = a(s1, 1).getShort(0);
		s1++;
		for (sbyte b1 = 0; b1 < s2; b1++)
		{
		  s1 += a(s1, 1).getShort(0);
		  short s3 = a(++s1, 1).getShort(0);
		  s1++;
		  for (sbyte b2 = 0; b2 < s3; b2++)
		  {
			short s4 = a(s1, 1).getShort(0);
			arrayList.Add(new string(a(++s1, s4).array()));
			s1 += s4;
			short s5 = a(s1, 1).getShort(0);
			s1++;
			for (sbyte b3 = 0; b3 < s5; b3++)
			{
			  s1 += a(s1, 1).getShort(0);
			  short s6 = a(++s1, 1).getShort(0);
			  s1++;
			  if (s6 >= 16)
			  {
				short s7 = a(s1, 2).getShort(0);
				s1 += 2;
				s1 += s7;
			  }
			  else
			  {
				s1 += a(s1, 1).getShort(0);
				s1++;
			  }
			}
		  }
		}
		return (string[])arrayList.toArray(arrayOfString);
	  }

	  private int E()
	  {
		short s1 = 0;
		if (a(s1, 1).getShort(0) == 1)
		{
		  s1 = ++s1 + a(s1, 1).getShort(0);
		  short s3 = a(++s1, 1).getShort(0);
		  s1++;
		  if (s3 >= 16)
		  {
			short s4 = a(s1, 2).getShort(0);
			s1 += 2;
			s1 += s4;
		  }
		  else
		  {
			s1 += a(s1, 1).getShort(0);
			s1++;
		  }
		}
		else
		{
		  s1++;
		}
		short s2 = a(s1, 1).getShort(0);
		s1++;
		for (sbyte b1 = 0; b1 < s2; b1++)
		{
		  s1 += a(s1, 1).getShort(0);
		  short s3 = a(++s1, 1).getShort(0);
		  s1++;
		  for (sbyte b2 = 0; b2 < s3; b2++)
		  {
			s1 += a(s1, 1).getShort(0);
			short s4 = a(++s1, 1).getShort(0);
			s1++;
			for (sbyte b3 = 0; b3 < s4; b3++)
			{
			  s1 += a(s1, 1).getShort(0);
			  short s5 = a(++s1, 1).getShort(0);
			  s1++;
			  if (s5 >= 16)
			  {
				short s6 = a(s1, 2).getShort(0);
				s1 += 2;
				s1 += s6;
			  }
			  else
			  {
				s1 += a(s1, 1).getShort(0);
				s1++;
			  }
			}
		  }
		}
		this.GetType();
		if ((s1 & 0x1F) != 0)
		{
		  this.GetType();
		  s1 &= (short)(0x1F ^ 0xFFFFFFFF);
		  s1 += 32;
		}
		return s1;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void a(boolean paramBoolean) throws sws.p2AppManager.utils.p2AppManagerException
	  private void a(bool paramBoolean)
	  {
		try
		{
		  bool bool1 = false;
		  bool bool2 = false;
		  short s1 = 0;
		  short s2 = 0;
		  sbyte[] arrayOfByte1 = new sbyte[] {0};
		  sbyte[] arrayOfByte2 = new sbyte[] {0, 0};
		  short s3 = 0;
		  List<object> arrayList1 = new List<object>();
		  List<object> arrayList2 = new List<object>();
		  List<object> arrayList3 = new List<object>();
		  List<object> arrayList4 = new List<object>();
		  List<object> arrayList5 = new List<object>();
		  if (p2AppManagerUtils.isEmptyString(this.c_Conflict))
		  {
			throw new p2AppManagerException("Invalid sampleID. Error: ", p2Enumerations.p2AppManagerStatus.SAMPLE_ID_INVALID_ERROR.NumVal);
		  }
		  string str = p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.CONFIG_SAMPLE_PATH_TEMPLATE), new object[] {this.c_Conflict});
		  p2AppManagerUtils.createDir(str);
		  if (!p2AppManagerUtils.exist(p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.OPTICAL_SETTINGS_FILE_PATH), new object[] {this.c_Conflict})))
		  {
			bool2 = false;
			arrayList1.Add(new bool?(false));
		  }
		  else
		  {
			bool2 = true;
			arrayList1.Add(new bool?(true));
		  }
		  short s4 = a(s3, 1).getShort(0);
		  s3++;
		  if (s4 == 1)
		  {
			short s5 = a(s3, 1).getShort(0);
			string str1 = new string(a(++s3, s5).array());
			s3 += s5;
			if (!str1.Equals("savedOpticalSettings.txt"))
			{
			  b_Conflict.error("Optical gain settings file name is not common!");
			}
			arrayOfByte1 = a(s3, 1).array();
			bool @bool = false;
			short s6 = a(s3, 1).getShort(0);
			s3++;
			if (s6 >= 16)
			{
			  arrayOfByte1[0] = (sbyte)(arrayOfByte1[0] - 16);
			  @bool = true;
			}
			arrayOfByte2 = new sbyte[2];
			arrayOfByte2[0] = arrayOfByte1[0];
			arrayOfByte2[1] = 0;
			ByteBuffer byteBuffer = ByteBuffer.wrap(arrayOfByte2);
			byteBuffer.order(ByteOrder.nativeOrder());
			short s7 = byteBuffer.getShort(0);
			short s8 = 0;
			if (@bool)
			{
			  s8 = a(s3, 2).getShort(0);
			  s3 += 2;
			}
			else
			{
			  s8 = a(s3, 1).getShort(0);
			  s3++;
			}
			if (!bool2)
			{
			  arrayOfByte1 = a(s3, s8).array();
			}
			s3 += s8;
			if (!bool2)
			{
			  if (s7 == 2)
			  {
				List<object> arrayList = new List<object>();
				arrayList.Add(StringHelper.NewString(arrayOfByte1));
				StreamWriter bufferedWriter = new StreamWriter(p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.OPTICAL_SETTINGS_FILE_PATH), new object[] {this.c_Conflict}));
				bufferedWriter.Write((string)arrayList[0]);
				bufferedWriter.Close();
			  }
			  else
			  {
				b_Conflict.error("Wrong optical data data type!");
			  }
			}
		  }
		  s1 = a(s3, 1).getShort(0);
		  s3++;
		  for (sbyte b1 = 0; b1 < s1; b1++)
		  {
			short s5 = a(s3, 1).getShort(0);
			arrayList2.Add(new string(a(++s3, s5).array()));
			s3 += s5;
			arrayList3.Add(new List<object>());
			arrayList4.Add(new List<object>());
			arrayList5.Add(new List<object>());
			s2 = a(s3, 1).getShort(0);
			if (s1 * s2 > 8)
			{
			  throw new p2AppManagerException("Invalid number of profiles. Error: ", p2Enumerations.p2AppManagerStatus.SAMPLE_FOLDERS_NUMBER_ERROR.NumVal);
			}
			s3++;
			for (sbyte b2 = 0; b2 < s2; b2++)
			{
			  s5 = a(s3, 1).getShort(0);
			  arrayOfByte1 = a(++s3, s5).array();
			  ((List<object>)arrayList3[b1]).Add(StringHelper.NewString(arrayOfByte1));
			  s3 += s5;
			  ((List<object>)arrayList4[b1]).Add(new List<object>());
			  ((List<object>)arrayList5[b1]).Add(new List<object>());
			  str = p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.CONFIG_SAMPLE_PROFILE_PATH_TEMPLATE), new object[] {this.c_Conflict, (string)arrayList2[b1] + Path.DirectorySeparatorChar + StringHelper.NewString(arrayOfByte1)});
			  if (!p2AppManagerUtils.exist(str))
			  {
				bool1 = false;
				arrayList1.Add(new bool?(false));
			  }
			  else
			  {
				bool1 = true;
				arrayList1.Add(new bool?(true));
			  }
			  short s6 = a(s3, 1).getShort(0);
			  s3++;
			  sbyte b3;
			  for (b3 = 0; b3 < s6; b3++)
			  {
				s5 = a(s3, 1).getShort(0);
				s3++;
				if (!bool1)
				{
				  ((List<object>)((List<object>)arrayList4[b1])[b2]).Add(new string(a(s3, s5).array()));
				  ((List<object>)((List<object>)arrayList5[b1])[b2]).Add(new List<object>());
				}
				s3 += s5;
				arrayOfByte1 = a(s3, 1).array();
				bool @bool = false;
				short s7 = a(s3, 1).getShort(0);
				s3++;
				if (s7 >= 16)
				{
				  arrayOfByte1[0] = (sbyte)(arrayOfByte1[0] - 16);
				  @bool = true;
				}
				arrayOfByte2 = new sbyte[2];
				arrayOfByte2[0] = arrayOfByte1[0];
				arrayOfByte2[1] = 0;
				ByteBuffer byteBuffer = ByteBuffer.wrap(arrayOfByte2);
				byteBuffer.order(ByteOrder.nativeOrder());
				short s8 = byteBuffer.getShort(0);
				short s9 = 0;
				if (@bool)
				{
				  s9 = a(s3, 2).getShort(0);
				  s3 += 2;
				}
				else
				{
				  s9 = a(s3, 1).getShort(0);
				  s3++;
				}
				if (!bool1)
				{
				  arrayOfByte1 = new sbyte[s9];
				  try
				  {
					arrayOfByte1 = this.O.b(s3, s9);
				  }
				  catch (Exception)
				  {
					throw new p2AppManagerException("Invalid file contents. Error: ", p2Enumerations.p2AppManagerStatus.INVALID_FILE_DATA_ERROR.NumVal);
				  }
				}
				s3 += s9;
				if (!bool1)
				{
				  if (s8 == 0)
				  {
					sbyte b4;
					for (b4 = 0; b4 < s9; b4 += 8)
					{
					  byteBuffer = ByteBuffer.wrap(arrayOfByte1);
					  byteBuffer.order(ByteOrder.nativeOrder());
					  ((List<object>)((List<object>)((List<object>)arrayList5[b1])[b2])[b3]).Add(byteBuffer.getDouble(b4).ToString());
					}
				  }
				  else if (s8 == 1)
				  {
					sbyte b4;
					for (b4 = 0; b4 < s9; b4 += 4)
					{
					  byteBuffer = ByteBuffer.wrap(arrayOfByte1);
					  byteBuffer.order(ByteOrder.nativeOrder());
					  ((List<object>)((List<object>)((List<object>)arrayList5[b1])[b2])[b3]).Add(byteBuffer.getInt(b4).ToString());
					}
				  }
				  else if (s8 == 2)
				  {
					((List<object>)((List<object>)((List<object>)arrayList5[b1])[b2])[b3]).Add(StringHelper.NewString(arrayOfByte1));
				  }
				  else if (s8 == 3)
				  {
					sbyte b4;
					for (b4 = 0; b4 < s9; b4 += 4)
					{
					  byteBuffer = ByteBuffer.wrap(arrayOfByte1);
					  byteBuffer.order(ByteOrder.nativeOrder());
					  ((List<object>)((List<object>)((List<object>)arrayList5[b1])[b2])[b3]).Add(byteBuffer.getFloat(b4).ToString());
					}
				  }
				}
			  }
			  if (!bool1)
			  {
				b3 = b2;
				str = p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.CONFIG_SAMPLE_PROFILE_PATH_TEMPLATE), new object[] {this.c_Conflict, (string)arrayList2[b1] + Path.DirectorySeparatorChar + (string)((List<object>)arrayList3[b1])[b3]});
				if (!p2AppManagerUtils.exist(str))
				{
				  p2AppManagerUtils.createDir(str);
				}
				else
				{
				  File file = new File(str);
				  file.delete();
				  p2AppManagerUtils.createDir(str);
				}
				for (sbyte b4 = 0; b4 < ((List<object>)((List<object>)arrayList4[b1])[b3]).Count; b4++)
				{
				  StreamWriter bufferedWriter = new StreamWriter(p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.CONFIG_SAMPLE_PROFILE_FILES_PATH_TEMPLATE), new object[] {this.c_Conflict, (string)arrayList2[b1] + Path.DirectorySeparatorChar + (string)((List<object>)arrayList3[b1])[b3], ((List<object>)((List<object>)arrayList4[b1])[b3])[b4]}));
				  if (((string)((List<object>)((List<object>)arrayList4[b1])[b3])[b4]).Equals("t.reg"))
				  {
					bufferedWriter.Write((string)((List<object>)((List<object>)((List<object>)arrayList5[b1])[b3])[b4])[0]);
				  }
				  else if (((string)((List<object>)((List<object>)arrayList4[b1])[b3])[b4]).Equals("param.conf"))
				  {
					StreamReader bufferedReader = new StreamReader(p2Constants.getPath(p2Constants.PARAM_HEADER_FIE_PATH));
					List<object> arrayList = new List<object>();
					string str1;
					while (!string.ReferenceEquals((str1 = bufferedReader.ReadLine()), null))
					{
					  arrayList.Add(str1);
					}
					bufferedReader.Close();
					for (sbyte b5 = 0; b5 < ((List<object>)((List<object>)((List<object>)arrayList5[b1])[b3])[b4]).Count; b5++)
					{
					  bufferedWriter.BaseStream.WriteByte(((string)arrayList[b5]).Split(":", true)[0] + " : " + (string)((List<object>)((List<object>)((List<object>)arrayList5[b1])[b3])[b4])[b5] + "\n");
					}
				  }
				  else
				  {
					for (sbyte b5 = 0; b5 < ((List<object>)((List<object>)((List<object>)arrayList5[b1])[b3])[b4]).Count; b5++)
					{
					  bufferedWriter.Write((string)((List<object>)((List<object>)((List<object>)arrayList5[b1])[b3])[b4])[b5] + "\n");
					}
				  }
				  bufferedWriter.Close();
				}
			  }
			}
		  }
		  if (!paramBoolean)
		  {
			a(arrayList1);
		  }
		}
		catch (Exception exception)
		{
		  b_Conflict.error(exception.Message);
		  throw new p2AppManagerException("Exception occurred while reading profiles from ROM. Error: ", p2Enumerations.p2AppManagerStatus.READING_PROFILES_FROM_ROM_ERROR.NumVal);
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void b(boolean paramBoolean) throws sws.p2AppManager.utils.p2AppManagerException
//JAVA TO C# CONVERTER NOTE: Members cannot have the same name as their enclosing type:
	  private void b_Conflict(bool paramBoolean)
	  {
		try
		{
		  bool bool1 = false;
		  bool bool2 = false;
		  bool bool3 = false;
		  bool bool4 = false;
		  sbyte[] arrayOfByte1 = new sbyte[] {0};
		  sbyte[] arrayOfByte2 = new sbyte[] {0, 0};
		  int i1 = 0;
		  List<object> arrayList1 = new List<object>();
		  List<object> arrayList2 = new List<object>();
		  List<object> arrayList3 = new List<object>();
		  List<object> arrayList4 = new List<object>();
		  List<object> arrayList5 = new List<object>();
		  if (p2AppManagerUtils.isEmptyString(this.c_Conflict))
		  {
			throw new p2AppManagerException("Invalid sampleID. Error: ", p2Enumerations.p2AppManagerStatus.SAMPLE_ID_INVALID_ERROR.NumVal);
		  }
		  short s1 = a(i1, 1).getShort(0);
		  i1++;
		  if (s1 == 1)
		  {
			short s2 = a(i1, 1).getShort(0);
			string str = new string(a(++i1, s2).array());
			i1 += s2;
			if (!str.Equals("savedOpticalSettings.txt"))
			{
			  b_Conflict.error("Optical gain settings file name is not common!");
			}
			arrayOfByte1 = a(i1, 1).array();
			bool @bool = false;
			short s3 = a(i1, 1).getShort(0);
			i1++;
			if (s3 >= 16)
			{
			  arrayOfByte1[0] = (sbyte)(arrayOfByte1[0] - 16);
			  @bool = true;
			}
			arrayOfByte2 = new sbyte[2];
			arrayOfByte2[0] = arrayOfByte1[0];
			arrayOfByte2[1] = 0;
			ByteBuffer byteBuffer = ByteBuffer.wrap(arrayOfByte2);
			byteBuffer.order(ByteOrder.nativeOrder());
			short s4 = byteBuffer.getShort(0);
			short s5 = 0;
			if (@bool)
			{
			  s5 = a(i1, 2).getShort(0);
			  i1 += 2;
			}
			else
			{
			  s5 = a(i1, 1).getShort(0);
			  i1++;
			}
			if (!bool2)
			{
			  arrayOfByte1 = a(i1, s5).array();
			}
			i1 += s5;
			if (!bool2)
			{
			  if (s4 == 2)
			  {
				List<object> arrayList = new List<object>();
				arrayList.Add(StringHelper.NewString(arrayOfByte1));
				StreamWriter bufferedWriter = new StreamWriter(p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.OPTICAL_SETTINGS_FILE_PATH), new object[] {this.c_Conflict}));
				bufferedWriter.Write((string)arrayList[0]);
				bufferedWriter.Close();
			  }
			  else
			  {
				b_Conflict.error("Wrong optical data data type!");
			  }
			}
		  }
		  if (!paramBoolean)
		  {
			i1 = E();
			bool @bool = false;
			s1 = a(i1, 1).getShort(0);
			i1++;
			if (s1 == 1)
			{
			  short s2 = a(i1, 1).getShort(0);
			  string str = new string(a(++i1, s2).array());
			  i1 += s2;
			  if (!str.Equals("savedOpticalSettings.txt"))
			  {
				b_Conflict.error("Optical gain settings file name is not common!");
			  }
			  arrayOfByte1 = a(i1, 1).array();
			  bool bool5 = false;
			  short s3 = a(i1, 1).getShort(0);
			  i1++;
			  if (s3 >= 16)
			  {
				arrayOfByte1[0] = (sbyte)(arrayOfByte1[0] - 16);
				bool5 = true;
			  }
			  arrayOfByte2 = new sbyte[2];
			  arrayOfByte2[0] = arrayOfByte1[0];
			  arrayOfByte2[1] = 0;
			  ByteBuffer byteBuffer = ByteBuffer.wrap(arrayOfByte2);
			  byteBuffer.order(ByteOrder.nativeOrder());
			  short s4 = byteBuffer.getShort(0);
			  int i2 = 0;
			  if (bool5)
			  {
				i2 = a(i1, 2).getShort(0);
				i1 += 2;
			  }
			  else
			  {
				i2 = a(i1, 1).getShort(0);
				i1++;
			  }
			  arrayOfByte1 = a(i1, i2).array();
			  i1 += i2;
			  if (s4 == 2)
			  {
				List<object> arrayList = new List<object>();
				arrayList.Add(StringHelper.NewString(arrayOfByte1));
				StreamWriter bufferedWriter = new StreamWriter(p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.OPTICAL_SETTINGS_FILE_PATH), new object[] {this.c_Conflict}));
				bufferedWriter.Write((string)arrayList[0]);
				bufferedWriter.Close();
			  }
			  else
			  {
				b_Conflict.error("Wrong optical data data type!");
			  }
			}
		  }
		}
		catch (Exception exception)
		{
		  b_Conflict.error(exception.Message);
		  throw new p2AppManagerException("Exception occurred while reading profiles from ROM. Error: ", p2Enumerations.p2AppManagerStatus.READING_PROFILES_FROM_ROM_ERROR.NumVal);
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void a(java.util.ArrayList<bool> paramArrayList) throws sws.p2AppManager.utils.p2AppManagerException
	  private void a(List<bool> paramArrayList)
	  {
		try
		{
		  short s1 = 0;
		  short s2 = 0;
		  sbyte[] arrayOfByte = new sbyte[] {0};
		  int i1 = E();
		  sbyte b1 = 0;
		  List<object> arrayList1 = new List<object>();
		  List<object> arrayList2 = new List<object>();
		  List<object> arrayList3 = new List<object>();
		  List<object> arrayList4 = new List<object>();
		  short s3 = a(i1, 1).getShort(0);
		  i1++;
		  if (s3 == 1)
		  {
			short s4 = a(i1, 1).getShort(0);
			string str = new string(a(++i1, s4).array());
			i1 += s4;
			if (!str.Equals("savedOpticalSettings.txt"))
			{
			  b_Conflict.error("Optical gain settings file name is not common!");
			}
			arrayOfByte = a(i1, 1).array();
			bool @bool = false;
			short s5 = a(i1, 1).getShort(0);
			i1++;
			if (s5 >= 16)
			{
			  arrayOfByte[0] = (sbyte)(arrayOfByte[0] - 16);
			  @bool = true;
			}
			sbyte[] arrayOfByte1 = new sbyte[2];
			arrayOfByte1[0] = arrayOfByte[0];
			arrayOfByte1[1] = 0;
			ByteBuffer byteBuffer = ByteBuffer.wrap(arrayOfByte1);
			byteBuffer.order(ByteOrder.nativeOrder());
			short s6 = byteBuffer.getShort(0);
			int i2 = 0;
			if (@bool)
			{
			  i2 = a(i1, 2).getShort(0);
			  i1 += 2;
			}
			else
			{
			  i2 = a(i1, 1).getShort(0);
			  i1++;
			}
			arrayOfByte = a(i1, i2).array();
			i1 += i2;
			if (s6 == 2)
			{
			  List<object> arrayList = new List<object>();
			  arrayList.Add(StringHelper.NewString(arrayOfByte));
			  if (((bool?)paramArrayList[b1]).Equals(new bool?(false)))
			  {
				StreamWriter bufferedWriter = new StreamWriter(p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.OPTICAL_SETTINGS_FILE_PATH), new object[] {this.c_Conflict}));
				bufferedWriter.Write((string)arrayList[0]);
				bufferedWriter.Close();
			  }
			  b1++;
			}
			else
			{
			  b_Conflict.error("Wrong optical data data type!");
			}
		  }
		  s1 = a(i1, 1).getShort(0);
		  i1++;
		  for (sbyte b2 = 0; b2 < s1; b2++)
		  {
			short s4 = a(i1, 1).getShort(0);
			arrayList1.Add(new string(a(++i1, s4).array()));
			i1 += s4;
			arrayList2.Add(new List<object>());
			arrayList3.Add(new List<object>());
			arrayList4.Add(new List<object>());
			s2 = a(i1, 1).getShort(0);
			if (s1 * s2 > 8)
			{
			  throw new p2AppManagerException("Invalid number of profiles. Error: ", p2Enumerations.p2AppManagerStatus.SAMPLE_FOLDERS_NUMBER_ERROR.NumVal);
			}
			i1++;
			for (sbyte b3 = 0; b3 < s2; b3++)
			{
			  s4 = a(i1, 1).getShort(0);
			  ((List<object>)arrayList2[b2]).Add(new string(a(++i1, s4).array()));
			  i1 += s4;
			  ((List<object>)arrayList3[b2]).Add(new List<object>());
			  ((List<object>)arrayList4[b2]).Add(new List<object>());
			  short s5 = a(i1, 1).getShort(0);
			  i1++;
			  sbyte b4;
			  for (b4 = 0; b4 < s5; b4++)
			  {
				s4 = a(i1, 1).getShort(0);
				((List<object>)((List<object>)arrayList3[b2])[b3]).Add(new string(a(++i1, s4).array()));
				((List<object>)((List<object>)arrayList4[b2])[b3]).Add(new List<object>());
				i1 += s4;
				arrayOfByte = a(i1, 1).array();
				bool @bool = false;
				short s6 = a(i1, 1).getShort(0);
				i1++;
				if (s6 >= 16)
				{
				  arrayOfByte[0] = (sbyte)(arrayOfByte[0] - 16);
				  @bool = true;
				}
				sbyte[] arrayOfByte1 = new sbyte[2];
				arrayOfByte1[0] = arrayOfByte[0];
				arrayOfByte1[1] = 0;
				ByteBuffer byteBuffer = ByteBuffer.wrap(arrayOfByte1);
				byteBuffer.order(ByteOrder.nativeOrder());
				short s7 = byteBuffer.getShort(0);
				int i2 = 0;
				if (@bool)
				{
				  i2 = a(i1, 2).getShort(0);
				  i1 += 2;
				}
				else
				{
				  i2 = a(i1, 1).getShort(0);
				  i1++;
				}
				try
				{
				  arrayOfByte = a(i1, i2).array();
				}
				catch (Exception)
				{
				  throw new p2AppManagerException("Invalid file contents. Error: ", p2Enumerations.p2AppManagerStatus.INVALID_FILE_DATA_ERROR.NumVal);
				}
				i1 += i2;
				if (s7 == 0)
				{
				  sbyte b5;
				  for (b5 = 0; b5 < i2; b5 += 8)
				  {
					byteBuffer = ByteBuffer.wrap(arrayOfByte);
					byteBuffer.order(ByteOrder.nativeOrder());
					((List<object>)((List<object>)((List<object>)arrayList4[b2])[b3])[b4]).Add(byteBuffer.getDouble(b5).ToString());
				  }
				}
				else if (s7 == 1)
				{
				  sbyte b5;
				  for (b5 = 0; b5 < i2; b5 += 4)
				  {
					byteBuffer = ByteBuffer.wrap(arrayOfByte);
					byteBuffer.order(ByteOrder.nativeOrder());
					((List<object>)((List<object>)((List<object>)arrayList4[b2])[b3])[b4]).Add(byteBuffer.getInt(b5).ToString());
				  }
				}
				else if (s7 == 2)
				{
				  ((List<object>)((List<object>)((List<object>)arrayList4[b2])[b3])[b4]).Add(StringHelper.NewString(arrayOfByte));
				}
				else if (s7 == 3)
				{
				  sbyte b5;
				  for (b5 = 0; b5 < i2; b5 += 4)
				  {
					byteBuffer = ByteBuffer.wrap(arrayOfByte);
					byteBuffer.order(ByteOrder.nativeOrder());
					((List<object>)((List<object>)((List<object>)arrayList4[b2])[b3])[b4]).Add(byteBuffer.getFloat(b5).ToString());
				  }
				}
			  }
			  if (((bool?)paramArrayList[b1]).Equals(new bool?(false)))
			  {
				b4 = b3;
				string str = p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.CONFIG_SAMPLE_PROFILE_PATH_TEMPLATE), new object[] {this.c_Conflict, (string)arrayList1[b2] + Path.DirectorySeparatorChar + (string)((List<object>)arrayList2[b2])[b4]});
				if (!p2AppManagerUtils.exist(str))
				{
				  p2AppManagerUtils.createDir(str);
				}
				else
				{
				  File file = new File(str);
				  file.delete();
				  p2AppManagerUtils.createDir(str);
				}
				for (sbyte b5 = 0; b5 < ((List<object>)((List<object>)arrayList3[b2])[b4]).Count; b5++)
				{
				  StreamWriter bufferedWriter = new StreamWriter(p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.getPath(p2Constants.CONFIG_SAMPLE_PROFILE_FILES_PATH_TEMPLATE)), new object[] {this.c_Conflict, (string)arrayList1[b2] + Path.DirectorySeparatorChar + (string)((List<object>)arrayList2[b2])[b4], ((List<object>)((List<object>)arrayList3[b2])[b4])[b5]}));
				  if (((string)((List<object>)((List<object>)arrayList3[b2])[b4])[b5]).Equals("t.reg"))
				  {
					bufferedWriter.Write((string)((List<object>)((List<object>)((List<object>)arrayList4[b2])[b4])[b5])[0]);
				  }
				  else if (((string)((List<object>)((List<object>)arrayList3[b2])[b4])[b5]).Equals("param.conf"))
				  {
					StreamReader bufferedReader = new StreamReader(p2Constants.getPath(p2Constants.PARAM_HEADER_FIE_PATH));
					List<object> arrayList = new List<object>();
					string str1;
					while (!string.ReferenceEquals((str1 = bufferedReader.ReadLine()), null))
					{
					  arrayList.Add(str1);
					}
					bufferedReader.Close();
					for (sbyte b6 = 0; b6 < ((List<object>)((List<object>)((List<object>)arrayList4[b2])[b4])[b5]).Count; b6++)
					{
					  bufferedWriter.BaseStream.WriteByte(((string)arrayList[b6]).Split(":", true)[0] + " : " + (string)((List<object>)((List<object>)((List<object>)arrayList4[b2])[b4])[b5])[b6] + "\n");
					}
				  }
				  else
				  {
					for (sbyte b6 = 0; b6 < ((List<object>)((List<object>)((List<object>)arrayList4[b2])[b4])[b5]).Count; b6++)
					{
					  bufferedWriter.Write((string)((List<object>)((List<object>)((List<object>)arrayList4[b2])[b4])[b5])[b6] + "\n");
					}
				  }
				  bufferedWriter.Close();
				}
			  }
			  b1++;
			}
		  }
		}
		catch (Exception exception)
		{
		  b_Conflict.error(exception.Message);
		  throw new p2AppManagerException("Exception occurred while reading profiles from ROM. Error: ", p2Enumerations.p2AppManagerStatus.READING_PROFILES_FROM_ROM_ERROR.NumVal);
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void c(boolean paramBoolean) throws sws.p2AppManager.utils.p2AppManagerException
	  private void c(bool paramBoolean)
	  {
		if (paramBoolean)
		{
		  G();
		  return;
		}
		List<object> arrayList = new List<object>();
		try
		{
		  string[] arrayOfString1 = p2AppManagerUtils.getFolderSubFoldersNames(p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.CONFIG_SAMPLE_PATH_TEMPLATE), new object[] {this.c_Conflict}), new List<object>(), false);
		  List<object> arrayList1 = new List<object>();
		  foreach (string str in arrayOfString1)
		  {
			if (!str.Equals(".svn") && !str.Contains(".txt"))
			{
			  arrayList1.Add(str);
			}
		  }
		  if (arrayList1.Count == 0)
		  {
			throw new p2AppManagerException("Invalid number of tempreture folders to be burnt. Error: ", p2Enumerations.p2AppManagerStatus.TEMP_FOLDERS_ERROR.NumVal);
		  }
		  List<object> arrayList2 = new List<object>();
		  string[] arrayOfString2 = p2AppManagerUtils.getFolderSubFilesNames(p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.CONFIG_SAMPLE_PATH_TEMPLATE), new object[] {this.c_Conflict}), arrayList2);
		  if (arrayOfString2.Length != 0)
		  {
			arrayList.Add(Convert.ToSByte((sbyte)1));
			sbyte[] arrayOfByte3 = arrayOfString2[0].GetBytes();
			arrayList.Add(Convert.ToSByte((sbyte)arrayOfByte3.Length));
			foreach (sbyte b4 in arrayOfByte3)
			{
			  arrayList.Add(Convert.ToSByte(b4));
			}
			string[] arrayOfString = p2AppManagerUtils.readStringfile(p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.OPTICAL_SETTINGS_TEMP2_FILE_PATH), new object[] {this.c_Conflict}));
			StringBuilder stringBuilder = new StringBuilder();
			foreach (string str1 in arrayOfString)
			{
			  stringBuilder.Append(str1 + "\n");
			}
			string str = stringBuilder.ToString();
			sbyte[] arrayOfByte4 = str.GetBytes();
			bool bool1 = false;
			if (arrayOfByte4.Length <= 255)
			{
			  arrayList.Add(Convert.ToSByte((sbyte)2));
			}
			else
			{
			  arrayList.Add(Convert.ToSByte((sbyte)18));
			  bool1 = true;
			}
			sbyte[] arrayOfByte5 = ByteBuffer.allocate(4).order(ByteOrder.LITTLE_ENDIAN).putInt(arrayOfByte4.Length).array();
			arrayList.Add(Convert.ToSByte(arrayOfByte5[0]));
			if (bool1)
			{
			  arrayList.Add(Convert.ToSByte(arrayOfByte5[1]));
			}
			foreach (sbyte b4 in arrayOfByte4)
			{
			  arrayList.Add(Convert.ToSByte(b4));
			}
		  }
		  else
		  {
			arrayList.Add(Convert.ToSByte((sbyte)0));
		  }
		  short s1 = 0;
		  short s2 = 0;
		  sbyte[] arrayOfByte1 = new sbyte[] {0};
		  int i1 = E();
		  bool @bool = false;
		  List<object> arrayList3 = new List<object>();
		  List<object> arrayList4 = new List<object>();
		  List<object> arrayList5 = new List<object>();
		  List<object> arrayList6 = new List<object>();
		  short s3 = a(i1, 1).getShort(0);
		  i1++;
		  if (s3 == 1)
		  {
			short s4 = a(i1, 1).getShort(0);
			string str = new string(a(++i1, s4).array());
			i1 += s4;
			if (!str.Equals("savedOpticalSettings.txt"))
			{
			  b_Conflict.error("Optical gain settings file name is not common!");
			}
			arrayOfByte1 = a(i1, 1).array();
			bool bool1 = false;
			short s5 = a(i1, 1).getShort(0);
			i1++;
			if (s5 >= 16)
			{
			  arrayOfByte1[0] = (sbyte)(arrayOfByte1[0] - 16);
			  bool1 = true;
			}
			sbyte[] arrayOfByte = new sbyte[2];
			arrayOfByte[0] = arrayOfByte1[0];
			arrayOfByte[1] = 0;
			ByteBuffer byteBuffer = ByteBuffer.wrap(arrayOfByte);
			byteBuffer.order(ByteOrder.nativeOrder());
			short s6 = byteBuffer.getShort(0);
			int i4 = 0;
			if (bool1)
			{
			  i4 = a(i1, 2).getShort(0);
			  i1 += 2;
			}
			else
			{
			  i4 = a(i1, 1).getShort(0);
			  i1++;
			}
			arrayOfByte1 = a(i1, i4).array();
			i1 += i4;
		  }
		  int i2 = 0;
		  int i3 = i1;
		  s1 = a(i1, 1).getShort(0);
		  i1++;
		  i2++;
		  for (sbyte b1 = 0; b1 < s1; b1++)
		  {
			short s4 = a(i1, 1).getShort(0);
			i1++;
			i2++;
			arrayList3.Add(new string(a(i1, s4).array()));
			i1 += s4;
			i2++;
			arrayList4.Add(new List<object>());
			arrayList5.Add(new List<object>());
			arrayList6.Add(new List<object>());
			s2 = a(i1, 1).getShort(0);
			if (s1 * s2 > 8)
			{
			  throw new p2AppManagerException("Invalid number of profiles. Error: ", p2Enumerations.p2AppManagerStatus.SAMPLE_FOLDERS_NUMBER_ERROR.NumVal);
			}
			i1++;
			i2++;
			for (sbyte b4 = 0; b4 < s2; b4++)
			{
			  s4 = a(i1, 1).getShort(0);
			  i1++;
			  i2++;
			  ((List<object>)arrayList4[b1]).Add(new string(a(i1, s4).array()));
			  i1 += s4;
			  ((List<object>)arrayList5[b1]).Add(new List<object>());
			  ((List<object>)arrayList6[b1]).Add(new List<object>());
			  short s5 = a(i1, 1).getShort(0);
			  i1++;
			  i2++;
			  for (sbyte b5 = 0; b5 < s5; b5++)
			  {
				s4 = a(i1, 1).getShort(0);
				i1++;
				i2++;
				((List<object>)((List<object>)arrayList5[b1])[b4]).Add(new string(a(i1, s4).array()));
				((List<object>)((List<object>)arrayList6[b1])[b4]).Add(new List<object>());
				i1 += s4;
				i2 += s4;
				arrayOfByte1 = a(i1, 1).array();
				bool bool1 = false;
				short s6 = a(i1, 1).getShort(0);
				i1++;
				i2++;
				if (s6 >= 16)
				{
				  arrayOfByte1[0] = (sbyte)(arrayOfByte1[0] - 16);
				  bool1 = true;
				}
				sbyte[] arrayOfByte = new sbyte[2];
				arrayOfByte[0] = arrayOfByte1[0];
				arrayOfByte[1] = 0;
				ByteBuffer byteBuffer = ByteBuffer.wrap(arrayOfByte);
				byteBuffer.order(ByteOrder.nativeOrder());
				short s7 = byteBuffer.getShort(0);
				int i4 = 0;
				if (bool1)
				{
				  i4 = a(i1, 2).getShort(0);
				  i1 += 2;
				  i2 += 2;
				}
				else
				{
				  i4 = a(i1, 1).getShort(0);
				  i1++;
				  i2++;
				}
				try
				{
				  arrayOfByte1 = a(i1, i4).array();
				}
				catch (Exception)
				{
				  throw new p2AppManagerException("Invalid file contents. Error: ", p2Enumerations.p2AppManagerStatus.INVALID_FILE_DATA_ERROR.NumVal);
				}
				i1 += i4;
				i2 += i4;
			  }
			}
		  }
		  arrayOfByte1 = a(i3, i2).array();
		  sbyte[] arrayOfByte2 = new sbyte[arrayOfByte1.Length + arrayList.Count];
		  sbyte b2;
		  for (b2 = 0; b2 < arrayList.Count; b2++)
		  {
			arrayOfByte2[b2] = ((sbyte?)arrayList[b2]).Value;
		  }
		  for (b3 = 0; b3 < arrayOfByte1.Length; b3++)
		  {
			arrayOfByte2[b2] = arrayOfByte1[b3];
		  }
		  i1 = E();
		  if (arrayOfByte2.Length + i1 < 65408)
		  {
			try
			{
			  this.O.a(i1, arrayOfByte2.Length, arrayOfByte2);
			  arrayOfByte2 = new sbyte[1];
			  arrayOfByte2[0] = 2;
			  this.O.a(65408, arrayOfByte2.Length, arrayOfByte2);
			}
			catch (Exception)
			{
			  Exception exception;
			  throw new p2AppManagerException("Exception occurred while writing data to ROM. Error: ", p2Enumerations.p2AppManagerStatus.WRITING_PROFILES_TO_ROM_ERROR.NumVal);
			}
		  }
		}
		catch (Exception exception)
		{
		  b_Conflict.error(exception.Message);
		  throw new p2AppManagerException("Exception occurred while reading profiles from ROM. Error: ", p2Enumerations.p2AppManagerStatus.READING_PROFILES_FROM_ROM_ERROR.NumVal);
		}
	  }

	  public bool b(string[] paramArrayOfString)
	  {
		  if (!InstanceFieldsInitialized)
		  {
			  InitializeInstanceFields();
			  InstanceFieldsInitialized = true;
		  }
		try
		{
		  string str = p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.OPTICAL_SETTINGS_FILE_PATH), new object[] {this.c_Conflict});
		  List<object> arrayList = new List<object>();
		  File file1 = new File(str);
		  File file2 = new File(p2Constants.getPath(p2Constants.OPTICAL_SETTINGS_TEMP_FILE_PATH));
		  if (file1.exists() && file2.exists())
		  {
			bufferedWriter = null;
			bufferedReader1 = null;
			bufferedReader2 = null;
			try
			{
			  bufferedReader1 = new StreamReader(str);
			  bufferedReader2 = new StreamReader(p2Constants.getPath(p2Constants.OPTICAL_SETTINGS_TEMP_FILE_PATH));
			  bufferedWriter = new StreamWriter(p2Constants.getPath(p2Constants.OPTICAL_SETTINGS_TEMP2_FILE_PATH));
			  str1 = null;
			  string str2 = null;
			  while (!string.ReferenceEquals((str2 = bufferedReader2.readLine()), null))
			  {
				if (a(str2, paramArrayOfString))
				{
				  while (true)
				  {
					bufferedWriter.write(str2 + "\n");
					if (str2.StartsWith(".end", StringComparison.Ordinal))
					{
					  goto label49Continue;
					}
					if (string.ReferenceEquals((str2 = bufferedReader2.readLine()), null))
					{
					  goto label49Continue;
					}
				  }
				}
				  label49Continue:;
			  }
			  label49Break:
			  while ((str1 = bufferedReader1.readLine()) != null)
			  {
				if (a(str1, paramArrayOfString))
				{
				  do
				  {

				  } while ((str1 = bufferedReader1.readLine()) != null && !str1.StartsWith(".end"));
				  continue;
				}
				bufferedWriter.write(str1 + "\n");
			  }
			}
			catch (Exception)
			{
			  return false;
			}
			finally
			{
			  try
			  {
				bufferedReader1.close();
				bufferedReader2.close();
				bufferedWriter.close();
			  }
			  catch (Exception)
			  {
				return false;
			  }
			}
		  }
		}
		catch (Exception exception)
		{
		  b_Conflict.error(exception.Message);
		  return false;
		}
		return true;
	  }

	  public virtual bool a(string paramString, string[] paramArrayOfString)
	  {
		for (sbyte b1 = 0; b1 < paramArrayOfString.Length; b1++)
		{
		  if (paramString.Contains(paramArrayOfString[b1]))
		  {
			return true;
		  }
		}
		return false;
	  }

	  private void d(string[] paramArrayOfString)
	  {
		try
		{
		  if (paramArrayOfString == null)
		  {
			sbyte[] arrayOfByte1 = new sbyte[] {0, 0};
			try
			{
			  this.O.a(0, 2, arrayOfByte1);
			}
			catch (Exception)
			{
			  throw new p2AppManagerException("Writing 0 as the number of profiles failed. Error: ", p2Enumerations.p2AppManagerStatus.SAMPLE_FOLDERS_NUMBER_ERROR.NumVal);
			}
			sbyte[] arrayOfByte2 = new sbyte[] {0};
			try
			{
			  this.O.a(65408, 1, arrayOfByte2);
			}
			catch (Exception)
			{
			  throw new p2AppManagerException("Writing 0 as the version of Conf. files failed. Error: ", p2Enumerations.p2AppManagerStatus.WRITING_PROFILES_TO_ROM_ERROR.NumVal);
			}
			return;
		  }
		  List<object> arrayList1 = new List<object>();
		  string[] arrayOfString1 = p2AppManagerUtils.getFolderSubFoldersNames(p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.CONFIG_SAMPLE_PATH_TEMPLATE), new object[] {this.c_Conflict}), new List<object>(), false);
		  List<object> arrayList2 = new List<object>();
		  string[] arrayOfString2 = p2AppManagerUtils.getFolderSubFilesNames(p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.CONFIG_SAMPLE_PATH_TEMPLATE), new object[] {this.c_Conflict}), arrayList2);
		  bool @bool = false;
		  if (arrayOfString2.Length != 0)
		  {
			@bool = true;
			arrayList1.Add(Convert.ToSByte((sbyte)1));
			sbyte[] arrayOfByte1 = arrayOfString2[0].GetBytes();
			arrayList1.Add(Convert.ToSByte((sbyte)arrayOfByte1.Length));
			foreach (sbyte b3 in arrayOfByte1)
			{
			  arrayList1.Add(Convert.ToSByte(b3));
			}
			string[] arrayOfString = p2AppManagerUtils.readStringfile(p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.OPTICAL_SETTINGS_FILE_PATH), new object[] {this.c_Conflict}));
			StringBuilder stringBuilder = new StringBuilder();
			foreach (string str1 in arrayOfString)
			{
			  stringBuilder.Append(str1 + "\n");
			}
			string str = stringBuilder.ToString();
			sbyte[] arrayOfByte2 = str.GetBytes();
			bool bool1 = false;
			if (arrayOfByte2.Length <= 255)
			{
			  arrayList1.Add(Convert.ToSByte((sbyte)2));
			}
			else
			{
			  arrayList1.Add(Convert.ToSByte((sbyte)18));
			  bool1 = true;
			}
			sbyte[] arrayOfByte3 = ByteBuffer.allocate(4).order(ByteOrder.LITTLE_ENDIAN).putInt(arrayOfByte2.Length).array();
			arrayList1.Add(Convert.ToSByte(arrayOfByte3[0]));
			if (bool1)
			{
			  arrayList1.Add(Convert.ToSByte(arrayOfByte3[1]));
			}
			foreach (sbyte b3 in arrayOfByte2)
			{
			  arrayList1.Add(Convert.ToSByte(b3));
			}
		  }
		  if (!@bool)
		  {
			arrayList1.Add(Convert.ToSByte((sbyte)0));
		  }
		  List<object> arrayList3 = new List<object>();
		  foreach (string str in arrayOfString1)
		  {
			if (!str.Equals(".svn") && !str.Contains(".txt"))
			{
			  arrayList3.Add(str);
			}
		  }
		  if (arrayList3.Count == 0)
		  {
			throw new p2AppManagerException("Invalid number of tempreture folders to be burnt. Error: ", p2Enumerations.p2AppManagerStatus.TEMP_FOLDERS_ERROR.NumVal);
		  }
		  if (arrayList3.Count * paramArrayOfString.Length > 8)
		  {
			throw new p2AppManagerException("Invalid number of profiles to be burnt. Max is 8Profiles . Error: ", p2Enumerations.p2AppManagerStatus.SAMPLE_FOLDERS_NUMBER_ERROR.NumVal);
		  }
		  arrayList1.Add(Convert.ToSByte((sbyte)arrayList3.Count));
		  for (sbyte b1 = 0; b1 < arrayList3.Count; b1++)
		  {
			arrayList1.Add(Convert.ToSByte((sbyte)((string)arrayList3[b1]).GetBytes().length));
			sbyte[] arrayOfByte1 = ((string)arrayList3[b1]).GetBytes();
			foreach (sbyte b4 in arrayOfByte1)
			{
			  arrayList1.Add(Convert.ToSByte(b4));
			}
			arrayList1.Add(Convert.ToSByte((sbyte)paramArrayOfString.Length));
			for (sbyte b3 = 0; b3 < paramArrayOfString.Length; b3++)
			{
			  arrayList1.Add(Convert.ToSByte((sbyte)paramArrayOfString[b3].GetBytes().length));
			  arrayOfByte1 = paramArrayOfString[b3].GetBytes();
			  foreach (sbyte b5 in arrayOfByte1)
			  {
				arrayList1.Add(Convert.ToSByte(b5));
			  }
			  List<object> arrayList = new List<object>();
			  string[] arrayOfString = p2AppManagerUtils.getFolderSubFilesNames(p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.CONFIG_SAMPLE_PROFILE_PATH_TEMPLATE), new object[] {this.c_Conflict, (string)arrayList3[b1] + Path.DirectorySeparatorChar + paramArrayOfString[b3]}), arrayList);
			  arrayList1.Add(Convert.ToSByte((sbyte)arrayOfString.Length));
			  for (sbyte b4 = 0; b4 < arrayOfString.Length; b4++)
			  {
				sbyte[] arrayOfByte2 = arrayOfString[b4].GetBytes();
				arrayList1.Add(Convert.ToSByte((sbyte)arrayOfByte2.Length));
				foreach (sbyte b5 in arrayOfByte2)
				{
				  arrayList1.Add(Convert.ToSByte(b5));
				}
				if (arrayOfString[b4].Equals("t.reg"))
				{
				  string[] arrayOfString3 = p2AppManagerUtils.readStringfile(p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.CONFIG_SAMPLE_PROFILE_PATH_TEMPLATE), new object[] {this.c_Conflict, (string)arrayList3[b1] + Path.DirectorySeparatorChar + paramArrayOfString[b3]}) + Path.DirectorySeparatorChar + arrayOfString[b4]);
				  StringBuilder stringBuilder = new StringBuilder();
				  foreach (string str1 in arrayOfString3)
				  {
					stringBuilder.Append(str1 + "\n");
				  }
				  string str = stringBuilder.ToString();
				  sbyte[] arrayOfByte3 = str.GetBytes();
				  bool bool1 = false;
				  if (arrayOfByte3.Length <= 255)
				  {
					arrayList1.Add(Convert.ToSByte((sbyte)2));
				  }
				  else
				  {
					arrayList1.Add(Convert.ToSByte((sbyte)18));
					bool1 = true;
				  }
				  sbyte[] arrayOfByte4 = ByteBuffer.allocate(4).order(ByteOrder.LITTLE_ENDIAN).putInt(arrayOfByte3.Length).array();
				  arrayList1.Add(Convert.ToSByte(arrayOfByte4[0]));
				  if (bool1)
				  {
					arrayList1.Add(Convert.ToSByte(arrayOfByte4[1]));
				  }
				  foreach (sbyte b5 in arrayOfByte3)
				  {
					arrayList1.Add(Convert.ToSByte(b5));
				  }
				}
				else if (arrayOfString[b4].Equals("param.conf"))
				{
				  string[] arrayOfString3 = p2AppManagerUtils.readStringfile(p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.CONFIG_SAMPLE_PROFILE_PATH_TEMPLATE), new object[] {this.c_Conflict, (string)arrayList3[b1] + Path.DirectorySeparatorChar + paramArrayOfString[b3]}) + Path.DirectorySeparatorChar + arrayOfString[b4]);
				  double[] arrayOfDouble = new double[arrayOfString3.Length];
				  sbyte[] arrayOfByte3 = new sbyte[arrayOfDouble.Length * 8];
				  sbyte b5;
				  for (b5 = 0; b5 < arrayOfString3.Length; b5++)
				  {
					arrayOfDouble[b5] = double.Parse(arrayOfString3[b5].Split(":", true)[1]);
					sbyte[] arrayOfByte5 = ByteBuffer.allocate(8).order(ByteOrder.LITTLE_ENDIAN).putDouble(arrayOfDouble[b5]).array();
					arrayOfByte3[b5 * 8] = arrayOfByte5[0];
					arrayOfByte3[b5 * 8 + 1] = arrayOfByte5[1];
					arrayOfByte3[b5 * 8 + 2] = arrayOfByte5[2];
					arrayOfByte3[b5 * 8 + 3] = arrayOfByte5[3];
					arrayOfByte3[b5 * 8 + 4] = arrayOfByte5[4];
					arrayOfByte3[b5 * 8 + 5] = arrayOfByte5[5];
					arrayOfByte3[b5 * 8 + 6] = arrayOfByte5[6];
					arrayOfByte3[b5 * 8 + 7] = arrayOfByte5[7];
				  }
				  b5 = 0;
				  if (arrayOfByte3.Length <= 255)
				  {
					arrayList1.Add(Convert.ToSByte((sbyte)0));
				  }
				  else
				  {
					arrayList1.Add(Convert.ToSByte((sbyte)16));
					b5 = 1;
				  }
				  sbyte[] arrayOfByte4 = ByteBuffer.allocate(4).order(ByteOrder.LITTLE_ENDIAN).putInt(arrayOfByte3.Length).array();
				  arrayList1.Add(Convert.ToSByte(arrayOfByte4[0]));
				  if (b5 != 0)
				  {
					arrayList1.Add(Convert.ToSByte(arrayOfByte4[1]));
				  }
				  foreach (sbyte b6 in arrayOfByte3)
				  {
					arrayList1.Add(Convert.ToSByte(b6));
				  }
				}
				else if (arrayOfString[b4].Equals("C2x.cal"))
				{
				  string[] arrayOfString3 = p2AppManagerUtils.readStringfile(p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.CONFIG_SAMPLE_PROFILE_PATH_TEMPLATE), new object[] {this.c_Conflict, (string)arrayList3[b1] + Path.DirectorySeparatorChar + paramArrayOfString[b3]}) + Path.DirectorySeparatorChar + arrayOfString[b4]);
				  float[] arrayOfFloat = new float[arrayOfString3.Length];
				  sbyte[] arrayOfByte3 = new sbyte[arrayOfFloat.Length * 4];
				  sbyte b5;
				  for (b5 = 0; b5 < arrayOfString3.Length; b5++)
				  {
					arrayOfFloat[b5] = float.Parse(arrayOfString3[b5]);
					sbyte[] arrayOfByte5 = ByteBuffer.allocate(4).order(ByteOrder.LITTLE_ENDIAN).putFloat(arrayOfFloat[b5]).array();
					arrayOfByte3[b5 * 4] = arrayOfByte5[0];
					arrayOfByte3[b5 * 4 + 1] = arrayOfByte5[1];
					arrayOfByte3[b5 * 4 + 2] = arrayOfByte5[2];
					arrayOfByte3[b5 * 4 + 3] = arrayOfByte5[3];
				  }
				  b5 = 0;
				  if (arrayOfByte3.Length <= 255)
				  {
					arrayList1.Add(Convert.ToSByte((sbyte)3));
				  }
				  else
				  {
					arrayList1.Add(Convert.ToSByte((sbyte)19));
					b5 = 1;
				  }
				  sbyte[] arrayOfByte4 = ByteBuffer.allocate(4).order(ByteOrder.LITTLE_ENDIAN).putInt(arrayOfByte3.Length).array();
				  arrayList1.Add(Convert.ToSByte(arrayOfByte4[0]));
				  if (b5 != 0)
				  {
					arrayList1.Add(Convert.ToSByte(arrayOfByte4[1]));
				  }
				  foreach (sbyte b6 in arrayOfByte3)
				  {
					arrayList1.Add(Convert.ToSByte(b6));
				  }
				}
				else
				{
				  string[] arrayOfString3 = p2AppManagerUtils.readStringfile(p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.CONFIG_SAMPLE_PROFILE_PATH_TEMPLATE), new object[] {this.c_Conflict, (string)arrayList3[b1] + Path.DirectorySeparatorChar + paramArrayOfString[b3]}) + Path.DirectorySeparatorChar + arrayOfString[b4]);
				  double[] arrayOfDouble = new double[arrayOfString3.Length];
				  sbyte[] arrayOfByte3 = new sbyte[arrayOfDouble.Length * 8];
				  sbyte b5;
				  for (b5 = 0; b5 < arrayOfString3.Length; b5++)
				  {
					arrayOfDouble[b5] = double.Parse(arrayOfString3[b5]);
					sbyte[] arrayOfByte5 = ByteBuffer.allocate(8).order(ByteOrder.LITTLE_ENDIAN).putDouble(arrayOfDouble[b5]).array();
					arrayOfByte3[b5 * 8] = arrayOfByte5[0];
					arrayOfByte3[b5 * 8 + 1] = arrayOfByte5[1];
					arrayOfByte3[b5 * 8 + 2] = arrayOfByte5[2];
					arrayOfByte3[b5 * 8 + 3] = arrayOfByte5[3];
					arrayOfByte3[b5 * 8 + 4] = arrayOfByte5[4];
					arrayOfByte3[b5 * 8 + 5] = arrayOfByte5[5];
					arrayOfByte3[b5 * 8 + 6] = arrayOfByte5[6];
					arrayOfByte3[b5 * 8 + 7] = arrayOfByte5[7];
				  }
				  b5 = 0;
				  if (arrayOfByte3.Length <= 255)
				  {
					arrayList1.Add(Convert.ToSByte((sbyte)0));
				  }
				  else
				  {
					arrayList1.Add(Convert.ToSByte((sbyte)16));
					b5 = 1;
				  }
				  sbyte[] arrayOfByte4 = ByteBuffer.allocate(4).order(ByteOrder.LITTLE_ENDIAN).putInt(arrayOfByte3.Length).array();
				  arrayList1.Add(Convert.ToSByte(arrayOfByte4[0]));
				  if (b5 != 0)
				  {
					arrayList1.Add(Convert.ToSByte(arrayOfByte4[1]));
				  }
				  foreach (sbyte b6 in arrayOfByte3)
				  {
					arrayList1.Add(Convert.ToSByte(b6));
				  }
				}
			  }
			}
		  }
		  sbyte[] arrayOfByte = new sbyte[arrayList1.Count];
		  for (b2 = 0; b2 < arrayList1.Count; b2++)
		  {
			arrayOfByte[b2] = ((sbyte?)arrayList1[b2]).Value;
		  }
		  try
		  {
			this.O.a(0, arrayOfByte.Length, arrayOfByte);
			arrayOfByte = new sbyte[1];
			arrayOfByte[0] = 1;
			this.O.a(65408, arrayOfByte.Length, arrayOfByte);
		  }
		  catch (Exception)
		  {
			Exception exception;
			throw new p2AppManagerException("Exception occurred while writing data to ROM. Error: ", p2Enumerations.p2AppManagerStatus.WRITING_PROFILES_TO_ROM_ERROR.NumVal);
		  }
		}
		catch (Exception)
		{
		  throw new p2AppManagerException("Exception occurred while writing profiles to ROM. Error: ", p2Enumerations.p2AppManagerStatus.WRITING_PROFILES_TO_ROM_ERROR.NumVal);
		}
		F();
	  }

	  private void F()
	  {
		int i1 = E();
		string[] arrayOfString1 = D();
		List<object> arrayList1 = new List<object>();
		string[] arrayOfString2 = p2AppManagerUtils.getFolderSubFoldersNames(p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.CONFIG_SAMPLE_PATH_TEMPLATE), new object[] {this.c_Conflict}), new List<object>(), false);
		List<object> arrayList2 = new List<object>();
		foreach (string str in arrayOfString2)
		{
		  if (!str.Equals(".svn") && !str.Contains(".txt"))
		  {
			arrayList2.Add(str);
		  }
		}
		if (arrayList2.Count == 0)
		{
		  throw new p2AppManagerException("Invalid number of tempreture folders to be burnt. Error: ", p2Enumerations.p2AppManagerStatus.TEMP_FOLDERS_ERROR.NumVal);
		}
		List<object> arrayList3 = new List<object>();
		string[] arrayOfString3 = p2AppManagerUtils.getFolderSubFilesNames(p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.CONFIG_SAMPLE_PATH_TEMPLATE), new object[] {this.c_Conflict}), arrayList3);
		if (arrayOfString3.Length != 0)
		{
		  arrayList1.Add(Convert.ToSByte((sbyte)1));
		  sbyte[] arrayOfByte1 = arrayOfString3[0].GetBytes();
		  arrayList1.Add(Convert.ToSByte((sbyte)arrayOfByte1.Length));
		  foreach (sbyte b3 in arrayOfByte1)
		  {
			arrayList1.Add(Convert.ToSByte(b3));
		  }
		  string[] arrayOfString = p2AppManagerUtils.readStringfile(p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.OPTICAL_SETTINGS_FILE_PATH), new object[] {this.c_Conflict}));
		  StringBuilder stringBuilder = new StringBuilder();
		  foreach (string str1 in arrayOfString)
		  {
			stringBuilder.Append(str1 + "\n");
		  }
		  string str = stringBuilder.ToString();
		  sbyte[] arrayOfByte2 = str.GetBytes();
		  bool @bool = false;
		  if (arrayOfByte2.Length <= 255)
		  {
			arrayList1.Add(Convert.ToSByte((sbyte)2));
		  }
		  else
		  {
			arrayList1.Add(Convert.ToSByte((sbyte)18));
			@bool = true;
		  }
		  sbyte[] arrayOfByte3 = ByteBuffer.allocate(4).order(ByteOrder.LITTLE_ENDIAN).putInt(arrayOfByte2.Length).array();
		  arrayList1.Add(Convert.ToSByte(arrayOfByte3[0]));
		  if (@bool)
		  {
			arrayList1.Add(Convert.ToSByte(arrayOfByte3[1]));
		  }
		  foreach (sbyte b3 in arrayOfByte2)
		  {
			arrayList1.Add(Convert.ToSByte(b3));
		  }
		}
		else
		{
		  arrayList1.Add(Convert.ToSByte((sbyte)0));
		}
		arrayList1.Add(Convert.ToSByte((sbyte)arrayList2.Count));
		for (sbyte b1 = 0; b1 < arrayList2.Count; b1++)
		{
		  arrayList1.Add(Convert.ToSByte((sbyte)((string)arrayList2[b1]).GetBytes().length));
		  sbyte[] arrayOfByte1 = ((string)arrayList2[b1]).GetBytes();
		  foreach (sbyte b4 in arrayOfByte1)
		  {
			arrayList1.Add(Convert.ToSByte(b4));
		  }
		  arrayList1.Add(Convert.ToSByte((sbyte)arrayOfString1.Length));
		  for (sbyte b3 = 0; b3 < arrayOfString1.Length; b3++)
		  {
			arrayList1.Add(Convert.ToSByte((sbyte)arrayOfString1[b3].GetBytes().length));
			arrayOfByte1 = arrayOfString1[b3].GetBytes();
			foreach (sbyte b6 in arrayOfByte1)
			{
			  arrayList1.Add(Convert.ToSByte(b6));
			}
			List<object> arrayList = new List<object>();
			string[] arrayOfString = p2AppManagerUtils.getFolderSubFilesNames(p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.CONFIG_SAMPLE_PROFILE_PATH_TEMPLATE), new object[] {this.c_Conflict, (string)arrayList2[b1] + Path.DirectorySeparatorChar + arrayOfString1[b3]}), arrayList);
			sbyte b4 = 0;
			sbyte b5;
			for (b5 = 0; b5 < arrayOfString.Length; b5++)
			{
			  if (arrayOfString[b5].Equals("corr.cal") || arrayOfString[b5].Equals("wavelength_corr.cal"))
			  {
				b4++;
			  }
			}
			arrayList1.Add(Convert.ToSByte((sbyte)b4));
			for (b5 = 0; b5 < arrayOfString.Length; b5++)
			{
			  if (arrayOfString[b5].Equals("corr.cal") || arrayOfString[b5].Equals("wavelength_corr.cal"))
			  {
				sbyte[] arrayOfByte2 = arrayOfString[b5].GetBytes();
				arrayList1.Add(Convert.ToSByte((sbyte)arrayOfByte2.Length));
				foreach (sbyte b7 in arrayOfByte2)
				{
				  arrayList1.Add(Convert.ToSByte(b7));
				}
				string[] arrayOfString4 = p2AppManagerUtils.readStringfile(p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.CONFIG_SAMPLE_PROFILE_PATH_TEMPLATE), new object[] {this.c_Conflict, (string)arrayList2[b1] + Path.DirectorySeparatorChar + arrayOfString1[b3]}) + Path.DirectorySeparatorChar + arrayOfString[b5]);
				double[] arrayOfDouble = new double[arrayOfString4.Length];
				sbyte[] arrayOfByte3 = new sbyte[arrayOfDouble.Length * 8];
				sbyte b6;
				for (b6 = 0; b6 < arrayOfString4.Length; b6++)
				{
				  arrayOfDouble[b6] = double.Parse(arrayOfString4[b6]);
				  sbyte[] arrayOfByte5 = ByteBuffer.allocate(8).order(ByteOrder.LITTLE_ENDIAN).putDouble(arrayOfDouble[b6]).array();
				  arrayOfByte3[b6 * 8] = arrayOfByte5[0];
				  arrayOfByte3[b6 * 8 + 1] = arrayOfByte5[1];
				  arrayOfByte3[b6 * 8 + 2] = arrayOfByte5[2];
				  arrayOfByte3[b6 * 8 + 3] = arrayOfByte5[3];
				  arrayOfByte3[b6 * 8 + 4] = arrayOfByte5[4];
				  arrayOfByte3[b6 * 8 + 5] = arrayOfByte5[5];
				  arrayOfByte3[b6 * 8 + 6] = arrayOfByte5[6];
				  arrayOfByte3[b6 * 8 + 7] = arrayOfByte5[7];
				}
				b6 = 0;
				if (arrayOfByte3.Length <= 255)
				{
				  arrayList1.Add(Convert.ToSByte((sbyte)0));
				}
				else
				{
				  arrayList1.Add(Convert.ToSByte((sbyte)16));
				  b6 = 1;
				}
				sbyte[] arrayOfByte4 = ByteBuffer.allocate(4).order(ByteOrder.LITTLE_ENDIAN).putInt(arrayOfByte3.Length).array();
				arrayList1.Add(Convert.ToSByte(arrayOfByte4[0]));
				if (b6 != 0)
				{
				  arrayList1.Add(Convert.ToSByte(arrayOfByte4[1]));
				}
				foreach (sbyte b7 in arrayOfByte3)
				{
				  arrayList1.Add(Convert.ToSByte(b7));
				}
			  }
			}
		  }
		}
		sbyte[] arrayOfByte = new sbyte[arrayList1.Count];
		for (b2 = 0; b2 < arrayList1.Count; b2++)
		{
		  arrayOfByte[b2] = ((sbyte?)arrayList1[b2]).Value;
		}
		if (arrayOfByte.Length + i1 < 65408)
		{
		  try
		  {
			this.O.a(i1, arrayOfByte.Length, arrayOfByte);
			arrayOfByte = new sbyte[1];
			arrayOfByte[0] = 2;
			this.O.a(65408, arrayOfByte.Length, arrayOfByte);
		  }
		  catch (Exception)
		  {
			Exception exception;
			throw new p2AppManagerException("Exception occurred while writing data to ROM. Error: ", p2Enumerations.p2AppManagerStatus.WRITING_PROFILES_TO_ROM_ERROR.NumVal);
		  }
		}
		else
		{
		  throw new p2AppManagerException("Exception occurred while writing data to ROM. Error: ", p2Enumerations.p2AppManagerStatus.WRITING_PROFILES_TO_ROM_ERROR.NumVal);
		}
	  }

	  private void G()
	  {
		int i1 = E();
		string[] arrayOfString1 = D();
		List<object> arrayList1 = new List<object>();
		string[] arrayOfString2 = p2AppManagerUtils.getFolderSubFoldersNames(p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.CONFIG_SAMPLE_PATH_TEMPLATE), new object[] {this.c_Conflict}), new List<object>(), false);
		List<object> arrayList2 = new List<object>();
		foreach (string str in arrayOfString2)
		{
		  if (!str.Equals(".svn") && !str.Contains(".txt"))
		  {
			arrayList2.Add(str);
		  }
		}
		if (arrayList2.Count == 0)
		{
		  throw new p2AppManagerException("Invalid number of tempreture folders to be burnt. Error: ", p2Enumerations.p2AppManagerStatus.TEMP_FOLDERS_ERROR.NumVal);
		}
		List<object> arrayList3 = new List<object>();
		string[] arrayOfString3 = p2AppManagerUtils.getFolderSubFilesNames(p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.CONFIG_SAMPLE_PATH_TEMPLATE), new object[] {this.c_Conflict}), arrayList3);
		if (arrayOfString3.Length != 0)
		{
		  arrayList1.Add(Convert.ToSByte((sbyte)1));
		  sbyte[] arrayOfByte1 = arrayOfString3[0].GetBytes();
		  arrayList1.Add(Convert.ToSByte((sbyte)arrayOfByte1.Length));
		  foreach (sbyte b3 in arrayOfByte1)
		  {
			arrayList1.Add(Convert.ToSByte(b3));
		  }
		  string[] arrayOfString = p2AppManagerUtils.readStringfile(p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.getPath(p2Constants.OPTICAL_SETTINGS_TEMP2_FILE_PATH)), new object[] {this.c_Conflict}));
		  StringBuilder stringBuilder = new StringBuilder();
		  foreach (string str1 in arrayOfString)
		  {
			stringBuilder.Append(str1 + "\n");
		  }
		  string str = stringBuilder.ToString();
		  sbyte[] arrayOfByte2 = str.GetBytes();
		  bool @bool = false;
		  if (arrayOfByte2.Length <= 255)
		  {
			arrayList1.Add(Convert.ToSByte((sbyte)2));
		  }
		  else
		  {
			arrayList1.Add(Convert.ToSByte((sbyte)18));
			@bool = true;
		  }
		  sbyte[] arrayOfByte3 = ByteBuffer.allocate(4).order(ByteOrder.LITTLE_ENDIAN).putInt(arrayOfByte2.Length).array();
		  arrayList1.Add(Convert.ToSByte(arrayOfByte3[0]));
		  if (@bool)
		  {
			arrayList1.Add(Convert.ToSByte(arrayOfByte3[1]));
		  }
		  foreach (sbyte b3 in arrayOfByte2)
		  {
			arrayList1.Add(Convert.ToSByte(b3));
		  }
		}
		else
		{
		  arrayList1.Add(Convert.ToSByte((sbyte)0));
		}
		arrayList1.Add(Convert.ToSByte((sbyte)arrayList2.Count));
		for (sbyte b1 = 0; b1 < arrayList2.Count; b1++)
		{
		  arrayList1.Add(Convert.ToSByte((sbyte)((string)arrayList2[b1]).GetBytes().length));
		  sbyte[] arrayOfByte1 = ((string)arrayList2[b1]).GetBytes();
		  foreach (sbyte b4 in arrayOfByte1)
		  {
			arrayList1.Add(Convert.ToSByte(b4));
		  }
		  arrayList1.Add(Convert.ToSByte((sbyte)arrayOfString1.Length));
		  for (sbyte b3 = 0; b3 < arrayOfString1.Length; b3++)
		  {
			arrayList1.Add(Convert.ToSByte((sbyte)arrayOfString1[b3].GetBytes().length));
			arrayOfByte1 = arrayOfString1[b3].GetBytes();
			foreach (sbyte b6 in arrayOfByte1)
			{
			  arrayList1.Add(Convert.ToSByte(b6));
			}
			List<object> arrayList = new List<object>();
			string[] arrayOfString = p2AppManagerUtils.getFolderSubFilesNames(p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.CONFIG_SAMPLE_PROFILE_PATH_TEMPLATE), new object[] {this.c_Conflict, (string)arrayList2[b1] + Path.DirectorySeparatorChar + arrayOfString1[b3]}), arrayList);
			sbyte b4 = 0;
			sbyte b5;
			for (b5 = 0; b5 < arrayOfString.Length; b5++)
			{
			  if (arrayOfString[b5].Equals("corr.cal") || arrayOfString[b5].Equals("wavelength_corr.cal"))
			  {
				b4++;
			  }
			}
			arrayList1.Add(Convert.ToSByte((sbyte)b4));
			for (b5 = 0; b5 < arrayOfString.Length; b5++)
			{
			  if (arrayOfString[b5].Equals("corr.cal") || arrayOfString[b5].Equals("wavelength_corr.cal"))
			  {
				sbyte[] arrayOfByte2 = arrayOfString[b5].GetBytes();
				arrayList1.Add(Convert.ToSByte((sbyte)arrayOfByte2.Length));
				foreach (sbyte b7 in arrayOfByte2)
				{
				  arrayList1.Add(Convert.ToSByte(b7));
				}
				string[] arrayOfString4 = p2AppManagerUtils.readStringfile(p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.CONFIG_SAMPLE_PROFILE_PATH_TEMPLATE), new object[] {this.c_Conflict, (string)arrayList2[b1] + Path.DirectorySeparatorChar + arrayOfString1[b3]}) + Path.DirectorySeparatorChar + arrayOfString[b5]);
				double[] arrayOfDouble = new double[arrayOfString4.Length];
				sbyte[] arrayOfByte3 = new sbyte[arrayOfDouble.Length * 8];
				sbyte b6;
				for (b6 = 0; b6 < arrayOfString4.Length; b6++)
				{
				  arrayOfDouble[b6] = double.Parse(arrayOfString4[b6]);
				  sbyte[] arrayOfByte5 = ByteBuffer.allocate(8).order(ByteOrder.LITTLE_ENDIAN).putDouble(arrayOfDouble[b6]).array();
				  arrayOfByte3[b6 * 8] = arrayOfByte5[0];
				  arrayOfByte3[b6 * 8 + 1] = arrayOfByte5[1];
				  arrayOfByte3[b6 * 8 + 2] = arrayOfByte5[2];
				  arrayOfByte3[b6 * 8 + 3] = arrayOfByte5[3];
				  arrayOfByte3[b6 * 8 + 4] = arrayOfByte5[4];
				  arrayOfByte3[b6 * 8 + 5] = arrayOfByte5[5];
				  arrayOfByte3[b6 * 8 + 6] = arrayOfByte5[6];
				  arrayOfByte3[b6 * 8 + 7] = arrayOfByte5[7];
				}
				b6 = 0;
				if (arrayOfByte3.Length <= 255)
				{
				  arrayList1.Add(Convert.ToSByte((sbyte)0));
				}
				else
				{
				  arrayList1.Add(Convert.ToSByte((sbyte)16));
				  b6 = 1;
				}
				sbyte[] arrayOfByte4 = ByteBuffer.allocate(4).order(ByteOrder.LITTLE_ENDIAN).putInt(arrayOfByte3.Length).array();
				arrayList1.Add(Convert.ToSByte(arrayOfByte4[0]));
				if (b6 != 0)
				{
				  arrayList1.Add(Convert.ToSByte(arrayOfByte4[1]));
				}
				foreach (sbyte b7 in arrayOfByte3)
				{
				  arrayList1.Add(Convert.ToSByte(b7));
				}
			  }
			}
		  }
		}
		sbyte[] arrayOfByte = new sbyte[arrayList1.Count];
		for (b2 = 0; b2 < arrayList1.Count; b2++)
		{
		  arrayOfByte[b2] = ((sbyte?)arrayList1[b2]).Value;
		}
		if (arrayOfByte.Length + i1 < 65408)
		{
		  try
		  {
			this.O.a(i1, arrayOfByte.Length, arrayOfByte);
			arrayOfByte = new sbyte[1];
			arrayOfByte[0] = 2;
			this.O.a(65408, arrayOfByte.Length, arrayOfByte);
		  }
		  catch (Exception)
		  {
			Exception exception;
			throw new p2AppManagerException("Exception occurred while writing data to ROM. Error: ", p2Enumerations.p2AppManagerStatus.WRITING_PROFILES_TO_ROM_ERROR.NumVal);
		  }
		}
		else
		{
		  throw new p2AppManagerException("Exception occurred while writing data to ROM. Error: ", p2Enumerations.p2AppManagerStatus.WRITING_PROFILES_TO_ROM_ERROR.NumVal);
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private ByteBuffer a(int paramInt1, int paramInt2) throws sws.p2AppManager.utils.p2AppManagerException
	  private ByteBuffer a(int paramInt1, int paramInt2)
	  {
		sbyte[] arrayOfByte;
		ByteBuffer byteBuffer = null;
		try
		{
		  arrayOfByte = this.O.b(paramInt1, paramInt2);
		}
		catch (Exception)
		{
		  throw new p2AppManagerException("Invalid number of temp folders. Error: ", p2Enumerations.p2AppManagerStatus.TEMP_FOLDERS_ERROR.NumVal);
		}
		if (paramInt2 == 1)
		{
		  sbyte[] arrayOfByte1 = new sbyte[2];
		  arrayOfByte1[0] = arrayOfByte[0];
		  arrayOfByte1[1] = 0;
		  byteBuffer = ByteBuffer.wrap(arrayOfByte1);
		  byteBuffer.order(ByteOrder.nativeOrder());
		}
		else if (paramInt2 == 2)
		{
		  byteBuffer = ByteBuffer.wrap(arrayOfByte);
		  byteBuffer.order(ByteOrder.nativeOrder());
		}
		else
		{
		  byteBuffer = ByteBuffer.wrap(arrayOfByte);
		}
		return byteBuffer;
	  }

	  public virtual p2Enumerations.p2AppManagerStatus C(b paramb, params string[] paramVarArgs)
	  {
		a a1;
		if (paramVarArgs.Length != 9)
		{
		  return p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR;
		}
		if (p2Enumerations.p2AppManagerState.Idle != w())
		{
		  return p2Enumerations.p2AppManagerStatus.DEVICE_BUSY_ERROR;
		}
		bool bool1 = false;
		p2Enumerations.p2AppManagerStatus p2AppManagerStatus = y();
		if (p2Enumerations.p2AppManagerStatus.BOARD_DISTCONNECTED_ERROR == p2AppManagerStatus || p2Enumerations.p2AppManagerStatus.UNKNOWN_ERROR == p2AppManagerStatus)
		{
		  return p2AppManagerStatus;
		}
		if (p2Enumerations.p2AppManagerStatus.BOARD_NOT_INITIALIZED_ERROR == p2AppManagerStatus)
		{
		  bool1 = true;
		}
		this.E_Conflict = "";
		sws.p2AppManager.b.b.a("TAIFReg", this.O.f());
		try
		{
		  this.O.a(paramb.c());
		}
		catch (a_Conflict)
		{
		  b_Conflict.error("Loading register file failed");
		  return p2Enumerations.p2AppManagerStatus.ASIC_REGISTER_WRITING_ERROR;
		}
		this.r_Conflict = (double[][])null;
		try
		{
		  a1 = a(p2Enumerations.p2DeviceAction.CalculateResponse, paramVarArgs);
		}
		catch (Exception)
		{
		  return p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR;
		}
		bool bool2 = false;
		try
		{
		  bool2 = this.O.a(true);
		}
		catch (a_Conflict)
		{
		  return p2Enumerations.p2AppManagerStatus.ACTUATION_SETTING_ERROR;
		}
		if (!bool2)
		{
		  try
		  {
			this.O.a(true, true, (int)paramb.b()[48]);
			try
			{
			  Thread.Sleep((long)paramb.b()[12]);
			}
			catch (InterruptedException interruptedException)
			{
			  b_Conflict.error(interruptedException.Message);
			}
		  }
		  catch (a_Conflict)
		  {
			return p2Enumerations.p2AppManagerStatus.DEVICE_IS_TURNED_OFF_ERROR;
		  }
		}
		a(p2Enumerations.p2AppManagerState.ResponseCalculation);
		this.D_Conflict = paramb;
		a(a1, bool1);
		return p2Enumerations.p2AppManagerStatus.NO_ERROR;
	  }

	  public virtual double[][] o()
	  {
		if (p2Enumerations.p2AppManagerState.Idle != w())
		{
		  b_Conflict.error("p2Device is busy now");
		  return (double[][])null;
		}
		if (this.r_Conflict == null)
		{
		  b_Conflict.error("there is no Response data may be you don't have any successful Response runs");
		  return (double[][])null;
		}
		return this.r_Conflict;
	  }

	  public virtual p2Enumerations.p2AppManagerStatus D(b paramb, params string[] paramVarArgs)
	  {
		a a1;
		if (paramVarArgs.Length != 9)
		{
		  return p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR;
		}
		if (p2Enumerations.p2AppManagerState.Idle != w())
		{
		  return p2Enumerations.p2AppManagerStatus.DEVICE_BUSY_ERROR;
		}
		bool bool1 = false;
		p2Enumerations.p2AppManagerStatus p2AppManagerStatus = y();
		if (p2Enumerations.p2AppManagerStatus.BOARD_DISTCONNECTED_ERROR == p2AppManagerStatus || p2Enumerations.p2AppManagerStatus.UNKNOWN_ERROR == p2AppManagerStatus)
		{
		  return p2AppManagerStatus;
		}
		if (p2Enumerations.p2AppManagerStatus.BOARD_NOT_INITIALIZED_ERROR == p2AppManagerStatus)
		{
		  bool1 = true;
		}
		this.E_Conflict = "";
		sws.p2AppManager.b.b.a("TAIFReg", this.O.f());
		try
		{
		  this.O.a(paramb.c());
		}
		catch (a_Conflict)
		{
		  b_Conflict.error("Loading register file failed");
		  return p2Enumerations.p2AppManagerStatus.ASIC_REGISTER_WRITING_ERROR;
		}
		this.s_Conflict = (double[][])null;
		try
		{
		  a1 = a(p2Enumerations.p2DeviceAction.CalculateParameters, paramVarArgs);
		}
		catch (Exception)
		{
		  return p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR;
		}
		bool bool2 = false;
		try
		{
		  bool2 = this.O.a(true);
		}
		catch (a_Conflict)
		{
		  return p2Enumerations.p2AppManagerStatus.ACTUATION_SETTING_ERROR;
		}
		if (!bool2)
		{
		  try
		  {
			this.O.a(true, true, (int)paramb.b()[48]);
			try
			{
			  Thread.Sleep((long)paramb.b()[12]);
			}
			catch (InterruptedException interruptedException)
			{
			  b_Conflict.error(interruptedException.Message);
			}
		  }
		  catch (a_Conflict)
		  {
			return p2Enumerations.p2AppManagerStatus.DEVICE_IS_TURNED_OFF_ERROR;
		  }
		}
		a(p2Enumerations.p2AppManagerState.ParametersCalculation);
		this.D_Conflict = paramb;
		a(a1, bool1);
		return p2Enumerations.p2AppManagerStatus.NO_ERROR;
	  }

	  public virtual double[][] p()
	  {
		if (p2Enumerations.p2AppManagerState.Idle != w())
		{
		  b_Conflict.error("p2Device is busy now");
		  return (double[][])null;
		}
		if (this.s_Conflict == null)
		{
		  b_Conflict.error("there is no Parameters data may be you don't have any successful Parameters runs");
		  return (double[][])null;
		}
		return this.s_Conflict;
	  }

	  public virtual p2Enumerations.p2AppManagerStatus E(b paramb, params string[] paramVarArgs)
	  {
		a a1;
		if (paramVarArgs.Length != 9)
		{
		  return p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR;
		}
		if (p2Enumerations.p2AppManagerState.Idle != w())
		{
		  return p2Enumerations.p2AppManagerStatus.DEVICE_BUSY_ERROR;
		}
		bool @bool = false;
		p2Enumerations.p2AppManagerStatus p2AppManagerStatus = y();
		if (p2Enumerations.p2AppManagerStatus.BOARD_DISTCONNECTED_ERROR == p2AppManagerStatus || p2Enumerations.p2AppManagerStatus.UNKNOWN_ERROR == p2AppManagerStatus)
		{
		  return p2AppManagerStatus;
		}
		if (p2Enumerations.p2AppManagerStatus.BOARD_NOT_INITIALIZED_ERROR == p2AppManagerStatus)
		{
		  @bool = true;
		}
		this.t_Conflict = (double[][])null;
		try
		{
		  a1 = a(p2Enumerations.p2DeviceAction.TrimCoefficients, paramVarArgs);
		}
		catch (Exception)
		{
		  return p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR;
		}
		a(p2Enumerations.p2AppManagerState.CoefficientsTrimming);
		this.D_Conflict = paramb;
		b_Conflict(a1, @bool);
		return p2Enumerations.p2AppManagerStatus.NO_ERROR;
	  }

	  public virtual double[][] q()
	  {
		if (p2Enumerations.p2AppManagerState.Idle != w())
		{
		  b_Conflict.error("p2Device is busy now");
		  return (double[][])null;
		}
		if (this.t_Conflict == null)
		{
		  b_Conflict.error("there is no Coefficients data may be you don't have any successful Coefficients runs");
		  return (double[][])null;
		}
		return this.t_Conflict;
	  }

	  public virtual p2Enumerations.p2AppManagerStatus F(b paramb, params string[] paramVarArgs)
	  {
		a a1;
		if (paramVarArgs.Length != 7)
		{
		  return p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR;
		}
		if (p2Enumerations.p2AppManagerState.Idle != w())
		{
		  return p2Enumerations.p2AppManagerStatus.DEVICE_BUSY_ERROR;
		}
		bool @bool = false;
		p2Enumerations.p2AppManagerStatus p2AppManagerStatus = y();
		if (p2Enumerations.p2AppManagerStatus.BOARD_DISTCONNECTED_ERROR == p2AppManagerStatus || p2Enumerations.p2AppManagerStatus.UNKNOWN_ERROR == p2AppManagerStatus)
		{
		  return p2AppManagerStatus;
		}
		if (p2Enumerations.p2AppManagerStatus.BOARD_NOT_INITIALIZED_ERROR == p2AppManagerStatus)
		{
		  @bool = true;
		}
		this.E_Conflict = "";
		this.u_Conflict = (double[][])null;
		try
		{
		  a1 = a(p2Enumerations.p2DeviceAction.TrimPhase, paramVarArgs);
		}
		catch (Exception)
		{
		  return p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR;
		}
		try
		{
		  this.O.a(false, false, (int)paramb.b()[48]);
		}
		catch (a_Conflict)
		{
		  return p2Enumerations.p2AppManagerStatus.DEVICE_IS_TURNED_OFF_ERROR;
		}
		try
		{
		  this.O.a(true, false, (int)paramb.b()[48]);
		  try
		  {
			Thread.Sleep((long)paramb.b()[12]);
		  }
		  catch (InterruptedException interruptedException)
		  {
			b_Conflict.error(interruptedException.Message);
		  }
		}
		catch (a_Conflict)
		{
		  return p2Enumerations.p2AppManagerStatus.DEVICE_IS_TURNED_OFF_ERROR;
		}
		a(p2Enumerations.p2AppManagerState.PhaseTrimming);
		this.D_Conflict = paramb;
		c(a1, @bool);
		return p2Enumerations.p2AppManagerStatus.NO_ERROR;
	  }

	  public virtual p2Enumerations.p2AppManagerStatus G(b paramb, params string[] paramVarArgs)
	  {
		a a1;
		if (paramVarArgs.Length != 8)
		{
		  return p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR;
		}
		if (p2Enumerations.p2AppManagerState.Idle != w())
		{
		  return p2Enumerations.p2AppManagerStatus.DEVICE_BUSY_ERROR;
		}
		bool @bool = false;
		p2Enumerations.p2AppManagerStatus p2AppManagerStatus = y();
		if (p2Enumerations.p2AppManagerStatus.BOARD_DISTCONNECTED_ERROR == p2AppManagerStatus || p2Enumerations.p2AppManagerStatus.UNKNOWN_ERROR == p2AppManagerStatus)
		{
		  return p2AppManagerStatus;
		}
		if (p2Enumerations.p2AppManagerStatus.BOARD_NOT_INITIALIZED_ERROR == p2AppManagerStatus)
		{
		  @bool = true;
		}
		this.E_Conflict = "";
		this.u_Conflict = (double[][])null;
		try
		{
		  a1 = a(p2Enumerations.p2DeviceAction.TrimPhaseFast, paramVarArgs);
		}
		catch (Exception)
		{
		  return p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR;
		}
		try
		{
		  this.O.a(false, false, (int)paramb.b()[48]);
		}
		catch (a_Conflict)
		{
		  return p2Enumerations.p2AppManagerStatus.DEVICE_IS_TURNED_OFF_ERROR;
		}
		try
		{
		  this.O.a(true, false, (int)paramb.b()[48]);
		  try
		  {
			Thread.Sleep((long)paramb.b()[12]);
		  }
		  catch (InterruptedException interruptedException)
		  {
			b_Conflict.error(interruptedException.Message);
		  }
		}
		catch (a_Conflict)
		{
		  return p2Enumerations.p2AppManagerStatus.DEVICE_IS_TURNED_OFF_ERROR;
		}
		a(p2Enumerations.p2AppManagerState.FastPhaseTrimming);
		this.D_Conflict = paramb;
		c(a1, @bool);
		return p2Enumerations.p2AppManagerStatus.NO_ERROR;
	  }

	  public virtual double[][] r()
	  {
		if (p2Enumerations.p2AppManagerState.Idle != w())
		{
		  b_Conflict.error("p2Device is busy now");
		  return (double[][])null;
		}
		if (this.u_Conflict == null)
		{
		  b_Conflict.error("there is no Phase data may be you don't have any successful Phase runs");
		  return (double[][])null;
		}
		return this.u_Conflict;
	  }

	  public virtual p2Enumerations.p2AppManagerStatus H(b paramb, params string[] paramVarArgs)
	  {
		a a1;
		if (paramVarArgs.Length != 4)
		{
		  return p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR;
		}
		if (p2Enumerations.p2AppManagerState.Idle != w())
		{
		  return p2Enumerations.p2AppManagerStatus.DEVICE_BUSY_ERROR;
		}
		bool @bool = false;
		p2Enumerations.p2AppManagerStatus p2AppManagerStatus = y();
		if (p2Enumerations.p2AppManagerStatus.BOARD_DISTCONNECTED_ERROR == p2AppManagerStatus || p2Enumerations.p2AppManagerStatus.UNKNOWN_ERROR == p2AppManagerStatus)
		{
		  return p2AppManagerStatus;
		}
		if (p2Enumerations.p2AppManagerStatus.BOARD_NOT_INITIALIZED_ERROR == p2AppManagerStatus)
		{
		  @bool = true;
		}
		this.E_Conflict = "";
		try
		{
		  this.O.a(false, false, (int)paramb.b()[48]);
		}
		catch (a_Conflict)
		{
		  return p2Enumerations.p2AppManagerStatus.DEVICE_IS_TURNED_OFF_ERROR;
		}
		try
		{
		  this.O.a(true, false, (int)paramb.b()[48]);
		  try
		  {
			Thread.Sleep((long)paramb.b()[12]);
		  }
		  catch (InterruptedException)
		  {
			b_Conflict.error(a1.Message);
		  }
		}
		catch (a_Conflict)
		{
		  return p2Enumerations.p2AppManagerStatus.DEVICE_IS_TURNED_OFF_ERROR;
		}
		this.v_Conflict = (double[][])null;
		try
		{
		  a1 = a(p2Enumerations.p2DeviceAction.CheckStability, paramVarArgs);
		}
		catch (Exception)
		{
		  return p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR;
		}
		a(p2Enumerations.p2AppManagerState.StabilityCheck);
		this.D_Conflict = paramb;
		d(a1, @bool);
		return p2Enumerations.p2AppManagerStatus.NO_ERROR;
	  }

	  public virtual double[][] s()
	  {
		if (p2Enumerations.p2AppManagerState.Idle != w())
		{
		  b_Conflict.error("p2Device is busy now");
		  return (double[][])null;
		}
		if (this.v_Conflict == null)
		{
		  b_Conflict.error("there is no Stability data may be you don't have any successful Stability runs");
		  return (double[][])null;
		}
		return this.v_Conflict;
	  }

	  public virtual p2Enumerations.p2AppManagerStatus I(b paramb, params string[] paramVarArgs)
	  {
		a a1;
		if (paramVarArgs.Length != 3)
		{
		  return p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR;
		}
		if (p2Enumerations.p2AppManagerState.Idle != w())
		{
		  return p2Enumerations.p2AppManagerStatus.DEVICE_BUSY_ERROR;
		}
		bool @bool = false;
		p2Enumerations.p2AppManagerStatus p2AppManagerStatus = y();
		if (p2Enumerations.p2AppManagerStatus.BOARD_DISTCONNECTED_ERROR == p2AppManagerStatus || p2Enumerations.p2AppManagerStatus.UNKNOWN_ERROR == p2AppManagerStatus)
		{
		  return p2AppManagerStatus;
		}
		if (p2Enumerations.p2AppManagerStatus.BOARD_NOT_INITIALIZED_ERROR == p2AppManagerStatus)
		{
		  @bool = true;
		}
		this.E_Conflict = "";
		try
		{
		  this.O.a(false, false, (int)paramb.b()[48]);
		}
		catch (a_Conflict)
		{
		  return p2Enumerations.p2AppManagerStatus.DEVICE_IS_TURNED_OFF_ERROR;
		}
		try
		{
		  this.O.a(true, false, (int)paramb.b()[48]);
		  try
		  {
			Thread.Sleep((long)paramb.b()[12]);
		  }
		  catch (InterruptedException)
		  {
			b_Conflict.error(a1.Message);
		  }
		}
		catch (a_Conflict)
		{
		  return p2Enumerations.p2AppManagerStatus.DEVICE_IS_TURNED_OFF_ERROR;
		}
		this.w_Conflict = (double[][])null;
		try
		{
		  a1 = a(p2Enumerations.p2DeviceAction.RunWaveform, paramVarArgs);
		}
		catch (Exception)
		{
		  return p2Enumerations.p2AppManagerStatus.INVALID_RUN_PARAMETERS_ERROR;
		}
		a(p2Enumerations.p2AppManagerState.WaveformPreview);
		this.D_Conflict = paramb;
		a(a1, @bool);
		return p2Enumerations.p2AppManagerStatus.NO_ERROR;
	  }

	  public virtual double[][] t()
	  {
		if (p2Enumerations.p2AppManagerState.Idle != w())
		{
		  b_Conflict.error("p2Device is busy now");
		  return (double[][])null;
		}
		if (this.w_Conflict == null)
		{
		  b_Conflict.error("there is no Waveform data may be you don't have any successful Waveform runs");
		  return (double[][])null;
		}
		return this.w_Conflict;
	  }

	  public virtual bool c(string[] paramArrayOfString)
	  {
		if (!Directory.Exists(p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.OPTICAL_SETTINGS_FILE_PATH), new object[] {this.c_Conflict})) || File.Exists(p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.OPTICAL_SETTINGS_FILE_PATH), new object[] {this.c_Conflict})))
		{
		  try
		  {
			(new File(p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.OPTICAL_SETTINGS_FILE_PATH), new object[] {this.c_Conflict}))).createNewFile();
		  }
		  catch (Exception)
		  {
			return false;
		  }
		}
		List<object> arrayList = new List<object>(Arrays.asList(paramArrayOfString));
		string[] arrayOfString = p2AppManagerUtils.readStringfile(p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.OPTICAL_SETTINGS_FILE_PATH), new object[] {this.c_Conflict}));
		sbyte b1 = 0;
		for (sbyte b2 = 0; b2 < arrayOfString.Length; b2++)
		{
		  b1 = 0;
		  if (arrayOfString[b2].Equals(paramArrayOfString[0]))
		  {
			arrayOfString[b2 + b1] = "TO_BE_DELETED";
			while (b2 + ++b1 < arrayOfString.Length && !arrayOfString[b2 + b1].StartsWith(".option", StringComparison.Ordinal))
			{
			  arrayOfString[b2 + b1] = "TO_BE_DELETED";
			  b1++;
			}
		  }
		}
		arrayList.AddRange(Arrays.asList(arrayOfString));
//JAVA TO C# CONVERTER TODO TASK: There is no .NET equivalent to the java.util.Collection 'removeAll' method:
		arrayList.removeAll(Collections.singleton("TO_BE_DELETED"));
		bool @bool = p2AppManagerUtils.writeFileOfArray((string[])arrayList.ToArray(typeof(string)), p2AppManagerUtils.formatString(p2Constants.getPath(p2Constants.OPTICAL_SETTINGS_FILE_PATH), new object[] {this.c_Conflict}), "\n");
		return !(@bool != true);
	  }

	  private class a
	  {
		  private readonly b outerInstance;

//JAVA TO C# CONVERTER NOTE: Members cannot have the same name as their enclosing type:
		internal p2Enumerations.p2AppManagerState a_Conflict;

		internal double b;

		internal short c;

		internal short d;

		internal int e;

		internal short f;

		internal int g;

		internal bool h;

		internal string i;

		internal double j;

		internal string k;

		internal int l;

		internal double m;

		internal double n;

		internal string o;

		internal int p;

		internal int q;

		internal bool r;

		internal bool s;

		internal double t;

		internal int u;

		internal int v;

		internal string w;

		internal bool x;

		internal bool y;

		internal bool z;

		internal bool A;

		internal double B;

		internal string C;

		internal string D;

		internal long[] E;

		internal string[] F;

		internal string G;

		internal double H;

		internal double I;

		internal double J;

		internal double K;

		internal double L;

		internal double M;

		internal double N;

		internal double O;

		internal double P;

		internal double Q;

		internal double R;

		internal double S;

		internal double T;

		internal double U;

		internal double V;

		internal int W;

		internal bool X;

		internal string Y;

		internal int Z;

		internal int aa;

		internal int ab;

		internal double ac;

		internal int ad;

		internal int ae;

		internal int af;

		internal int ag;

		internal string ah;

		internal a(b outerInstance, b this$0)
		{
			this.outerInstance = outerInstance;
		}
	  }
	}


	/* Location:              D:\jobs\BalitTanah.SoilSensingKit\Decompile Driver\SDK v4.3\SDKv4.3\bin_win_x64\p2AppManager.jar!\sws\p2AppManager\b\b.class
	 * Java compiler version: 7 (51.0)
	 * JD-Core Version:       1.0.7
	 */
}