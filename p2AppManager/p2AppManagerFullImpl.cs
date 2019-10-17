using System.IO;

namespace sws.p2AppManager
{
	using Logger = org.apache.log4j.Logger;
	using b = sws.p2AppManager.a.b;
	using a = sws.p2AppManager.b.a;
	using b = sws.p2AppManager.b.b;
	using p2AppManagerException = sws.p2AppManager.utils.p2AppManagerException;
	using p2AppManagerNotification = sws.p2AppManager.utils.p2AppManagerNotification;
	using p2AppManagerUtils = sws.p2AppManager.utils.p2AppManagerUtils;
	using p2Constants = sws.p2AppManager.utils.p2Constants;
	using p2DeviceNotificationResult = sws.p2AppManager.utils.p2DeviceNotificationResult;
	using p2Enumerations = sws.p2AppManager.utils.p2Enumerations;

	internal class p2AppManagerFullImpl : p2AppManager
	{
//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
	  private b a_Conflict;

//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
	  private a b_Conflict;

//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
	  private static Logger c_Conflict = Logger.getLogger(typeof(p2AppManagerImpl));

//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
	  private string d_Conflict = System.getProperty("user.dir");

	  public p2AppManagerFullImpl()
	  {
		p2Constants.APPLICATION_WORKING_DIRECTORY = this.d_Conflict;
		p2Enumerations.p2AppManagerStatus p2AppManagerStatus = a();
		if (p2AppManagerStatus != p2Enumerations.p2AppManagerStatus.NO_ERROR)
		{
			;
		}
	  }

	  public p2AppManagerFullImpl(string paramString)
	  {
		p2Constants.APPLICATION_WORKING_DIRECTORY = paramString;
		p2Enumerations.p2AppManagerStatus p2AppManagerStatus = a();
		if (p2AppManagerStatus != p2Enumerations.p2AppManagerStatus.NO_ERROR)
		{
		  throw new p2AppManagerException("Failed to initialize General Configurations", p2AppManagerStatus.NumVal);
		}
		p2AppManagerUtils.createDir(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs");
	  }

	  public override p2Enumerations.p2AppManagerStatus initializeCore(params string[] paramVarArgs)
	  {
		c_Conflict.info("start initializeCore method ");
		if (this.b_Conflict == null)
		{
		  this.b_Conflict = b();
		}
		return this.b_Conflict.a(this.a_Conflict, paramVarArgs);
	  }

	  public override p2Enumerations.p2AppManagerStatus checkDeviceStatus(params string[] paramVarArgs)
	  {
		if (this.b_Conflict == null)
		{
		  this.b_Conflict = b();
		}
		return this.b_Conflict.b(this.a_Conflict, paramVarArgs);
	  }

	  public override p2Enumerations.p2AppManagerStatus runSpec(params string[] paramVarArgs)
	  {
		c_Conflict.info("start runSpec method ");
		if (this.b_Conflict == null)
		{
		  this.b_Conflict = b();
		}
		return this.b_Conflict.c(this.a_Conflict, paramVarArgs);
	  }

	  public override p2Enumerations.p2AppManagerStatus wavelengthCalibrationBG(params string[] paramVarArgs)
	  {
		c_Conflict.info("start wavelengthCalibrationBG method ");
		if (this.b_Conflict == null)
		{
		  this.b_Conflict = b();
		}
		return this.b_Conflict.d(this.a_Conflict, paramVarArgs);
	  }

	  public override p2Enumerations.p2AppManagerStatus wavelengthCalibration(params string[] paramVarArgs)
	  {
		c_Conflict.info("start wavelengthCalibration method ");
		if (this.b_Conflict == null)
		{
		  this.b_Conflict = b();
		}
		return this.b_Conflict.e(this.a_Conflict, paramVarArgs);
	  }

	  public override double ErrorData
	  {
		  get
		  {
			c_Conflict.info("start getErrorData method ");
			return (this.b_Conflict == null) ? 1.0D : this.b_Conflict.b();
		  }
	  }

	  public override double[][] SpecData
	  {
		  get
		  {
			c_Conflict.info("start getSpecData method ");
			return (this.b_Conflict == null) ? (double[][])null : this.b_Conflict.c();
		  }
	  }

	  public override p2Enumerations.p2AppManagerStatus runInterSpecDSP(double[][] paramArrayOfDouble, params string[] paramVarArgs)
	  {
		c_Conflict.info("start runInterSpecDSP method ");
		if (this.b_Conflict == null)
		{
		  this.b_Conflict = b();
		}
		return this.b_Conflict.a(this.a_Conflict, paramArrayOfDouble, paramVarArgs);
	  }

	  public override p2Enumerations.p2AppManagerStatus runInterSpec(params string[] paramVarArgs)
	  {
		c_Conflict.info("start runInterSpec method ");
		if (this.b_Conflict == null)
		{
		  this.b_Conflict = b();
		}
		return this.b_Conflict.f(this.a_Conflict, paramVarArgs);
	  }

	  public override p2Enumerations.p2AppManagerStatus updateFFT_SettingsInterSpec(params string[] paramVarArgs)
	  {
		c_Conflict.info("start updateFFT_SettingsInterSpec method ");
		if (this.b_Conflict == null)
		{
		  this.b_Conflict = b();
		}
		return this.b_Conflict.g(this.a_Conflict, paramVarArgs);
	  }

	  public override p2Enumerations.p2AppManagerStatus updateFFT_SettingsSpec(params string[] paramVarArgs)
	  {
		c_Conflict.info("start updateFFT_SettingsSpec method ");
		if (this.b_Conflict == null)
		{
		  this.b_Conflict = b();
		}
		return this.b_Conflict.h(this.a_Conflict, paramVarArgs);
	  }

	  public override p2Enumerations.p2AppManagerStatus runSNR(params string[] paramVarArgs)
	  {
		c_Conflict.info("start runSNR method ");
		if (this.b_Conflict == null)
		{
		  this.b_Conflict = b();
		}
		return this.b_Conflict.i(this.a_Conflict, paramVarArgs);
	  }

	  public override p2Enumerations.p2AppManagerStatus runStability(params string[] paramVarArgs)
	  {
		c_Conflict.info("start runStability method ");
		if (this.b_Conflict == null)
		{
		  this.b_Conflict = b();
		}
		return this.b_Conflict.j(this.a_Conflict, paramVarArgs);
	  }

	  public override p2Enumerations.p2AppManagerStatus runCalibCorr(params string[] paramVarArgs)
	  {
		c_Conflict.info("start runCalibCorr method ");
		if (this.b_Conflict == null)
		{
		  this.b_Conflict = b();
		}
		return this.b_Conflict.k(this.a_Conflict, paramVarArgs);
	  }

	  public override p2Enumerations.p2AppManagerStatus runInterSpecGainAdj(params string[] paramVarArgs)
	  {
		c_Conflict.info("start runInterSpecGainAdj method ");
		if (this.b_Conflict == null)
		{
		  this.b_Conflict = b();
		}
		return this.b_Conflict.l(this.a_Conflict, paramVarArgs);
	  }

	  public override p2Enumerations.p2AppManagerStatus runSpecGainAdjBG(params string[] paramVarArgs)
	  {
		c_Conflict.info("start runSpecGainAdjBG method ");
		if (this.b_Conflict == null)
		{
		  this.b_Conflict = b();
		}
		return this.b_Conflict.m(this.a_Conflict, paramVarArgs);
	  }

	  public override p2Enumerations.p2AppManagerStatus saveInterSpecGainSettings(string paramString, double[][] paramArrayOfDouble)
	  {
		c_Conflict.info("start saveInterSpecGainSettings method ");
		return this.b_Conflict.a(paramString, paramArrayOfDouble);
	  }

	  public override p2Enumerations.p2AppManagerStatus saveSpecGainSettings(string paramString, double[][] paramArrayOfDouble)
	  {
		c_Conflict.info("start saveSpecGainSettings method ");
		return this.b_Conflict.b(paramString, paramArrayOfDouble);
	  }

	  public override p2Enumerations.p2AppManagerStatus runSpecGainAdjSample(params string[] paramVarArgs)
	  {
		c_Conflict.info("start runSpecGainAdjSample method ");
		if (this.b_Conflict == null)
		{
		  this.b_Conflict = b();
		}
		return this.b_Conflict.n(this.a_Conflict, paramVarArgs);
	  }

	  public override double[][] RawData
	  {
		  get
		  {
			c_Conflict.info("start getRawData method ");
			return (this.b_Conflict == null) ? (double[][])null : this.b_Conflict.d();
		  }
	  }

	  public override double[][] InterSpecData
	  {
		  get
		  {
			c_Conflict.info("start getInterSpecData method ");
			return (this.b_Conflict == null) ? (double[][])null : this.b_Conflict.e();
		  }
	  }

	  public override double[][] GainAdjustInterSpecData
	  {
		  get
		  {
			c_Conflict.info("start getGainAdjustInterSpecData method ");
			return (this.b_Conflict == null) ? (double[][])null : this.b_Conflict.f();
		  }
	  }

	  public override double[][] GainAdjustSpecData
	  {
		  get
		  {
			c_Conflict.info("start getGainAdjustSpecData method ");
			return (this.b_Conflict == null) ? (double[][])null : this.b_Conflict.g();
		  }
	  }

	  public override double[][] SNR_Data
	  {
		  get
		  {
			c_Conflict.info("start getSNR_Data method ");
			return (this.b_Conflict == null) ? (double[][])null : this.b_Conflict.h();
		  }
	  }

	  public override double[][] StabilityData
	  {
		  get
		  {
			c_Conflict.info("start getStabilityData method ");
			return (this.b_Conflict == null) ? (double[][])null : this.b_Conflict.i();
		  }
	  }

	  public override p2Enumerations.p2AppManagerStatus runCapTime_Calibration(params string[] paramVarArgs)
	  {
		c_Conflict.info("start runCapTime_Calibration method ");
		if (this.b_Conflict == null)
		{
		  this.b_Conflict = b();
		}
		return this.b_Conflict.o(this.a_Conflict, paramVarArgs);
	  }

	  public override double[][] CapTimeData
	  {
		  get
		  {
			c_Conflict.info("start getCapTimeData method ");
			return (this.b_Conflict == null) ? (double[][])null : this.b_Conflict.j();
		  }
	  }

	  public override p2Enumerations.p2AppManagerStatus runDelayCompensation_Calibration(params string[] paramVarArgs)
	  {
		c_Conflict.info("start runDelayCompensation_Calibration method ");
		if (this.b_Conflict == null)
		{
		  this.b_Conflict = b();
		}
		return this.b_Conflict.p(this.a_Conflict, paramVarArgs);
	  }

	  public override p2Enumerations.p2AppManagerStatus runCalibrationCore_Calibration(params string[] paramVarArgs)
	  {
		c_Conflict.info("start runCalibrationCore_Calibration method ");
		if (this.b_Conflict == null)
		{
		  this.b_Conflict = b();
		}
		return this.b_Conflict.q(this.a_Conflict, paramVarArgs);
	  }

	  public override p2Enumerations.p2AppManagerStatus generateCalibration(params string[] paramVarArgs)
	  {
		c_Conflict.info("start generateCalibration method ");
		if (this.b_Conflict == null)
		{
		  this.b_Conflict = b();
		}
		return this.b_Conflict.r(this.a_Conflict, paramVarArgs);
	  }

	  public override double[][] CalibrationData
	  {
		  get
		  {
			c_Conflict.info("start getCalibrationData method ");
			return (this.b_Conflict == null) ? (double[][])null : this.b_Conflict.k();
		  }
	  }

	  public override p2Enumerations.p2AppManagerStatus runCapCurrent(params string[] paramVarArgs)
	  {
		c_Conflict.info("start runCapCurrent method ");
		if (this.b_Conflict == null)
		{
		  this.b_Conflict = b();
		}
		return this.b_Conflict.s(this.a_Conflict, paramVarArgs);
	  }

	  public override double[][] CapCurrentData
	  {
		  get
		  {
			c_Conflict.info("start getCapCurrentData method ");
			return (this.b_Conflict == null) ? (double[][])null : this.b_Conflict.l();
		  }
	  }

	  public override p2Enumerations.p2AppManagerStatus burnSampleID(params string[] paramVarArgs)
	  {
		c_Conflict.info("start burnSampleID method ");
		if (this.b_Conflict == null)
		{
		  this.b_Conflict = b();
		}
		return this.b_Conflict.v(this.a_Conflict, paramVarArgs);
	  }

	  public override p2Enumerations.p2AppManagerStatus burnSampleFolders(string[] paramArrayOfString)
	  {
		c_Conflict.info("start burnSampleFolders method ");
		if (this.b_Conflict == null)
		{
		  this.b_Conflict = b();
		}
		return this.b_Conflict.w(this.a_Conflict, paramArrayOfString);
	  }

	  public override p2Enumerations.p2AppManagerStatus restoreDefaultSettings(params string[] paramVarArgs)
	  {
		c_Conflict.info("start restoreDefaultSettings method ");
		if (this.b_Conflict == null)
		{
		  this.b_Conflict = b();
		}
		return this.b_Conflict.x(this.a_Conflict, paramVarArgs);
	  }

	  public override p2Enumerations.p2AppManagerStatus burnSettings(params string[] paramVarArgs)
	  {
		c_Conflict.info("start restoreDefaultSettings method ");
		if (this.b_Conflict == null)
		{
		  this.b_Conflict = b();
		}
		return this.b_Conflict.y(this.a_Conflict, paramVarArgs);
	  }

	  public override p2Enumerations.p2AppManagerStatus burnSpecificSettings(params string[] paramVarArgs)
	  {
		c_Conflict.info("start restoreDefaultSettings method ");
		if (this.b_Conflict == null)
		{
		  this.b_Conflict = b();
		}
		return this.b_Conflict.J(this.a_Conflict, paramVarArgs);
	  }

	  public override p2Enumerations.p2AppManagerStatus readSampleFolders(params string[] paramVarArgs)
	  {
		c_Conflict.info("start readSampleFolders method ");
		if (this.b_Conflict == null)
		{
		  this.b_Conflict = b();
		}
		return this.b_Conflict.z(this.a_Conflict, paramVarArgs);
	  }

	  public override p2Enumerations.p2AppManagerStatus readTemp(params string[] paramVarArgs)
	  {
		c_Conflict.info("start readTemp method ");
		if (this.b_Conflict == null)
		{
		  this.b_Conflict = b();
		}
		return this.b_Conflict.A(this.a_Conflict, paramVarArgs);
	  }

	  public override double[][] TempData
	  {
		  get
		  {
			c_Conflict.info("start getTempData method ");
			return (this.b_Conflict == null) ? (double[][])null : this.b_Conflict.m();
		  }
	  }

	  public override p2Enumerations.p2AppManagerStatus readASICRegisters(params string[] paramVarArgs)
	  {
		c_Conflict.info("start readASICRegisters method ");
		if (this.b_Conflict == null)
		{
		  this.b_Conflict = b();
		}
		return this.b_Conflict.B(this.a_Conflict, paramVarArgs);
	  }

	  public override p2Enumerations.p2AppManagerStatus writeASICRegisters(long[] paramArrayOfLong)
	  {
		c_Conflict.info("start writeASICRegisters method ");
		if (this.b_Conflict == null)
		{
		  this.b_Conflict = b();
		}
		return this.b_Conflict.a(this.a_Conflict, paramArrayOfLong);
	  }

	  public override long[] ASICRegisters
	  {
		  get
		  {
			c_Conflict.info("start getASICRegisters method ");
			return (this.b_Conflict == null) ? null : this.b_Conflict.n();
		  }
	  }

	  public override p2Enumerations.p2AppManagerStatus switchDevice(params string[] paramVarArgs)
	  {
		c_Conflict.info("start setActuation method ");
		if (this.b_Conflict == null)
		{
		  this.b_Conflict = b();
		}
		return this.b_Conflict.t(this.a_Conflict, paramVarArgs);
	  }

	  public override params string[] Settings
	  {
		  set
		  {
			c_Conflict.info("start setSampleFolder method ");
			if (this.b_Conflict == null)
			{
			  this.b_Conflict = b();
			}
			this.b_Conflict.u(this.a_Conflict, value);
		  }
	  }

	  public override params string[] OpticalSettings
	  {
		  set
		  {
			c_Conflict.info("start setOpticalSettings method ");
			if (this.b_Conflict == null)
			{
			  this.b_Conflict = b();
			}
			this.b_Conflict.a(value);
		  }
	  }

	  public override string DeviceId
	  {
		  get
		  {
			  return this.b_Conflict.a();
		  }
	  }

	  public override string SDKVersion
	  {
		  get
		  {
			  return "4.3";
		  }
	  }

	  public override p2Enumerations.p2AppManagerStatus calculateResponse_ClosedLoop(params string[] paramVarArgs)
	  {
		c_Conflict.info("start calculateResponse_ClosedLoop method ");
		if (this.b_Conflict == null)
		{
		  this.b_Conflict = b();
		}
		return this.b_Conflict.C(this.a_Conflict, paramVarArgs);
	  }

	  public override double[][] ResponseData
	  {
		  get
		  {
			c_Conflict.info("start getResponseData method ");
			return (this.b_Conflict == null) ? (double[][])null : this.b_Conflict.o();
		  }
	  }

	  public override p2Enumerations.p2AppManagerStatus calculateParameters_ClosedLoop(params string[] paramVarArgs)
	  {
		c_Conflict.info("start calculateParameters_ClosedLoop method ");
		if (this.b_Conflict == null)
		{
		  this.b_Conflict = b();
		}
		return this.b_Conflict.D(this.a_Conflict, paramVarArgs);
	  }

	  public override double[][] ParametersData
	  {
		  get
		  {
			c_Conflict.info("start getParametersData method ");
			return (this.b_Conflict == null) ? (double[][])null : this.b_Conflict.p();
		  }
	  }

	  public override p2Enumerations.p2AppManagerStatus CoefficientsTrimming_ClosedLoop(params string[] paramVarArgs)
	  {
		c_Conflict.info("start CoefficientsTrimming_ClosedLoop method ");
		if (this.b_Conflict == null)
		{
		  this.b_Conflict = b();
		}
		return this.b_Conflict.E(this.a_Conflict, paramVarArgs);
	  }

	  public override double[][] CoefficientsTrimmingData
	  {
		  get
		  {
			c_Conflict.info("start getCoefficientsTrimmingData method ");
			return (this.b_Conflict == null) ? (double[][])null : this.b_Conflict.q();
		  }
	  }

	  public override p2Enumerations.p2AppManagerStatus PhaseTrimming_ClosedLoop(params string[] paramVarArgs)
	  {
		c_Conflict.info("start PhaseTrimming_ClosedLoop method ");
		if (this.b_Conflict == null)
		{
		  this.b_Conflict = b();
		}
		return this.b_Conflict.F(this.a_Conflict, paramVarArgs);
	  }

	  public override p2Enumerations.p2AppManagerStatus PhaseTrimmingFast_ClosedLoop(params string[] paramVarArgs)
	  {
		c_Conflict.info("start PhaseTrimmingFast_ClosedLoop method ");
		if (this.b_Conflict == null)
		{
		  this.b_Conflict = b();
		}
		return this.b_Conflict.G(this.a_Conflict, paramVarArgs);
	  }

	  public override double[][] PhaseTrimmingData
	  {
		  get
		  {
			c_Conflict.info("start getPhaseTrimmingData method ");
			return (this.b_Conflict == null) ? (double[][])null : this.b_Conflict.r();
		  }
	  }

	  public override p2Enumerations.p2AppManagerStatus StabilityCheck_ClosedLoop(params string[] paramVarArgs)
	  {
		c_Conflict.info("start StabilityCheck_ClosedLoop method ");
		if (this.b_Conflict == null)
		{
		  this.b_Conflict = b();
		}
		return this.b_Conflict.H(this.a_Conflict, paramVarArgs);
	  }

	  public override double[][] StabilityCheckData
	  {
		  get
		  {
			c_Conflict.info("start getStabilityCheckData method ");
			return (this.b_Conflict == null) ? (double[][])null : this.b_Conflict.s();
		  }
	  }

	  public override p2Enumerations.p2AppManagerStatus WaveformPreview_ClosedLoop(params string[] paramVarArgs)
	  {
		c_Conflict.info("start WaveformPreview_ClosedLoop method ");
		if (this.b_Conflict == null)
		{
		  this.b_Conflict = b();
		}
		return this.b_Conflict.I(this.a_Conflict, paramVarArgs);
	  }

	  public override double[][] WaveformPreviewData
	  {
		  get
		  {
			c_Conflict.info("start getWaveformPreviewData method ");
			return (this.b_Conflict == null) ? (double[][])null : this.b_Conflict.t();
		  }
	  }

	  public virtual void update(Observable paramObservable, object paramObject)
	  {
		c_Conflict.info("start update method ");
		if (paramObject == null || !(paramObject is p2DeviceNotificationResult))
		{
		  setChanged();
		  notifyObservers(new p2AppManagerNotification(-1, p2Enumerations.p2AppManagerStatus.INVALID_NOTIFICATION_ERROR.NumVal, null));
		}
		p2DeviceNotificationResult p2DeviceNotificationResult = (p2DeviceNotificationResult)paramObject;
		p2Enumerations.p2DeviceAction p2DeviceAction = p2DeviceNotificationResult.Action;
		if (p2DeviceAction == null)
		{
		  setChanged();
		  notifyObservers(new p2AppManagerNotification(-1, p2Enumerations.p2AppManagerStatus.INVALID_ACTION_ERROR.NumVal, null));
		}
		string str = p2DeviceNotificationResult.DeviceId;
		if (p2AppManagerUtils.isEmptyString(str))
		{
		  setChanged();
		  notifyObservers(new p2AppManagerNotification(-1, p2Enumerations.p2AppManagerStatus.INVALID_DEVICE_ERROR.NumVal, null));
		}
		switch (null.a[p2DeviceAction.ordinal()])
		{
		  case 1:
			c_Conflict.info("initialize core....");
			a(str, p2DeviceNotificationResult.Status);
			return;
		  case 2:
			c_Conflict.info("run inter spec....");
			b(str, p2DeviceNotificationResult.Status);
			return;
		  case 3:
			c_Conflict.info("run FFT settings inter spec....");
			c(str, p2DeviceNotificationResult.Status);
			return;
		  case 4:
			c_Conflict.info("run FFT settings spec....");
			d(str, p2DeviceNotificationResult.Status);
			return;
		  case 5:
			c_Conflict.info("run Gain Adjustment InterSpec....");
			e(str, p2DeviceNotificationResult.Status);
			return;
		  case 6:
			c_Conflict.info("run Gain Adjustment Spec BG....");
			f(str, p2DeviceNotificationResult.Status);
			return;
		  case 7:
			c_Conflict.info("run Gain Adjustment Spec Sample....");
			g(str, p2DeviceNotificationResult.Status);
			return;
		  case 8:
			c_Conflict.info("run background ....");
			k(str, p2DeviceNotificationResult.Status);
			return;
		  case 9:
			c_Conflict.info("run spectrocopy ....");
			l(str, p2DeviceNotificationResult.Status);
			return;
		  case 10:
			c_Conflict.info("run BG wavelength calibration ....");
			m(str, p2DeviceNotificationResult.Status);
			return;
		  case 11:
			c_Conflict.info("run wavelength calibration ....");
			n(str, p2DeviceNotificationResult.Status);
			return;
		  case 12:
			c_Conflict.info("run SNR ....");
			h(str, p2DeviceNotificationResult.Status);
			return;
		  case 13:
			c_Conflict.info("run Stability ....");
			i(str, p2DeviceNotificationResult.Status);
			return;
		  case 14:
			c_Conflict.info("run Interferogram Corr ....");
			j(str, p2DeviceNotificationResult.Status);
			return;
		  case 15:
			c_Conflict.info("Setting Actuation....");
			o(str, p2DeviceNotificationResult.Status);
			return;
		  case 16:
			c_Conflict.info("Run CapTime Calibration....");
			p(str, p2DeviceNotificationResult.Status);
			return;
		  case 17:
			c_Conflict.info("Run DelayCompensation Calibration....");
			q(str, p2DeviceNotificationResult.Status);
			return;
		  case 18:
			c_Conflict.info("Run Core Calibration....");
			r(str, p2DeviceNotificationResult.Status);
			return;
		  case 19:
			c_Conflict.info("Generate Calibration....");
			s(str, p2DeviceNotificationResult.Status);
			return;
		  case 20:
			c_Conflict.info("Run Cap Current....");
			t(str, p2DeviceNotificationResult.Status);
			return;
		  case 21:
			c_Conflict.info("Burn SampleID....");
			u(str, p2DeviceNotificationResult.Status);
			return;
		  case 22:
			c_Conflict.info("Burn Sample Folders....");
			v(str, p2DeviceNotificationResult.Status);
			return;
		  case 23:
			c_Conflict.info("Read Sample Folders....");
			y(str, p2DeviceNotificationResult.Status);
			return;
		  case 24:
			c_Conflict.info("Read Temp....");
			z(str, p2DeviceNotificationResult.Status);
			return;
		  case 25:
			c_Conflict.info("Read ASIC Registers....");
			A(str, p2DeviceNotificationResult.Status);
			return;
		  case 26:
			c_Conflict.info("Write ASIC Registers....");
			B(str, p2DeviceNotificationResult.Status);
			return;
		  case 27:
			c_Conflict.info("Calculate Response....");
			C(str, p2DeviceNotificationResult.Status);
			return;
		  case 28:
			c_Conflict.info("Calculate Parameters....");
			D(str, p2DeviceNotificationResult.Status);
			return;
		  case 29:
			c_Conflict.info("Trim Coefficients....");
			E(str, p2DeviceNotificationResult.Status);
			return;
		  case 30:
			c_Conflict.info("Trim Phase....");
			F(str, p2DeviceNotificationResult.Status);
			return;
		  case 31:
			c_Conflict.info("Trim Phase....");
			G(str, p2DeviceNotificationResult.Status);
			return;
		  case 32:
			c_Conflict.info("Check Stability....");
			H(str, p2DeviceNotificationResult.Status);
			return;
		  case 33:
			c_Conflict.info("Run Waveform....");
			I(str, p2DeviceNotificationResult.Status);
			return;
		  case 34:
			c_Conflict.info("Burn Working Settings....");
			x(str, p2DeviceNotificationResult.Status);
			return;
		  case 35:
			c_Conflict.info("Restore Default Settings");
			w(str, p2DeviceNotificationResult.Status);
			return;
		}
		setChanged();
		notifyObservers(new p2AppManagerNotification(-1, p2Enumerations.p2AppManagerStatus.INVALID_ACTION_ERROR.NumVal, null));
	  }

	  private p2Enumerations.p2AppManagerStatus a()
	  {
		this.a_Conflict = new b();
		return this.a_Conflict.d();
	  }

	  private a b()
	  {
		b b1 = new b();
		b1.addObserver(this);
		return b1;
	  }

	  private void a(string paramString, p2Enumerations.p2AppManagerStatus paramp2AppManagerStatus)
	  {
		c_Conflict.info("lynxinitializeCoreFinished");
		setChanged();
		notifyObservers(new p2AppManagerNotification(p2Enumerations.p2DeviceAction.initializeCore.NumVal, paramp2AppManagerStatus.NumVal, paramString));
	  }

	  private void b(string paramString, p2Enumerations.p2AppManagerStatus paramp2AppManagerStatus)
	  {
		c_Conflict.info("RunInterSpecFinished with status : " + paramp2AppManagerStatus);
		setChanged();
		notifyObservers(new p2AppManagerNotification(p2Enumerations.p2DeviceAction.RunInterSpec.NumVal, paramp2AppManagerStatus.NumVal, paramString));
	  }

	  private void c(string paramString, p2Enumerations.p2AppManagerStatus paramp2AppManagerStatus)
	  {
		c_Conflict.info("RunUpdateFFT_InterSpecFinished with status : " + paramp2AppManagerStatus);
		setChanged();
		notifyObservers(new p2AppManagerNotification(p2Enumerations.p2DeviceAction.RunUpdateFFT_SettingsInterSpec.NumVal, paramp2AppManagerStatus.NumVal, paramString));
	  }

	  private void d(string paramString, p2Enumerations.p2AppManagerStatus paramp2AppManagerStatus)
	  {
		c_Conflict.info("RunUpdateFFT_SpecFinished with status : " + paramp2AppManagerStatus);
		setChanged();
		notifyObservers(new p2AppManagerNotification(p2Enumerations.p2DeviceAction.RunUpdateFFT_SettingsSpec.NumVal, paramp2AppManagerStatus.NumVal, paramString));
	  }

	  private void e(string paramString, p2Enumerations.p2AppManagerStatus paramp2AppManagerStatus)
	  {
		c_Conflict.info("RunAdaptiveGainFinished with status : " + paramp2AppManagerStatus);
		setChanged();
		notifyObservers(new p2AppManagerNotification(p2Enumerations.p2DeviceAction.RunGainAdjustInterSpec.NumVal, paramp2AppManagerStatus.NumVal, paramString));
	  }

	  private void f(string paramString, p2Enumerations.p2AppManagerStatus paramp2AppManagerStatus)
	  {
		c_Conflict.info("RunGainAdjustSpecBG_Finished with status : " + paramp2AppManagerStatus);
		setChanged();
		notifyObservers(new p2AppManagerNotification(p2Enumerations.p2DeviceAction.RunGainAdjustSpecBG.NumVal, paramp2AppManagerStatus.NumVal, paramString));
	  }

	  private void g(string paramString, p2Enumerations.p2AppManagerStatus paramp2AppManagerStatus)
	  {
		c_Conflict.info("RunGainAdjustSpecSampleFinished with status : " + paramp2AppManagerStatus);
		setChanged();
		notifyObservers(new p2AppManagerNotification(p2Enumerations.p2DeviceAction.RunGainAdjustSpecSample.NumVal, paramp2AppManagerStatus.NumVal, paramString));
	  }

	  private void h(string paramString, p2Enumerations.p2AppManagerStatus paramp2AppManagerStatus)
	  {
		c_Conflict.info("RunSNR_Finished with status : " + paramp2AppManagerStatus);
		setChanged();
		notifyObservers(new p2AppManagerNotification(p2Enumerations.p2DeviceAction.RunSNR.NumVal, paramp2AppManagerStatus.NumVal, paramString));
	  }

	  private void i(string paramString, p2Enumerations.p2AppManagerStatus paramp2AppManagerStatus)
	  {
		c_Conflict.info("RunStabilityFinished with status : " + paramp2AppManagerStatus);
		setChanged();
		notifyObservers(new p2AppManagerNotification(p2Enumerations.p2DeviceAction.RunStability.NumVal, paramp2AppManagerStatus.NumVal, paramString));
	  }

	  private void j(string paramString, p2Enumerations.p2AppManagerStatus paramp2AppManagerStatus)
	  {
		c_Conflict.info("RunInterferogramCorr_Finished with status : " + paramp2AppManagerStatus);
		setChanged();
		notifyObservers(new p2AppManagerNotification(p2Enumerations.p2DeviceAction.RunSelfCorr.NumVal, paramp2AppManagerStatus.NumVal, paramString));
	  }

	  private void k(string paramString, p2Enumerations.p2AppManagerStatus paramp2AppManagerStatus)
	  {
		c_Conflict.info("RunSpecBackgroundeFinished with status : " + paramp2AppManagerStatus);
		setChanged();
		notifyObservers(new p2AppManagerNotification(p2Enumerations.p2DeviceAction.RunSpecBackground.NumVal, paramp2AppManagerStatus.NumVal, paramString));
	  }

	  private void l(string paramString, p2Enumerations.p2AppManagerStatus paramp2AppManagerStatus)
	  {
		c_Conflict.info("RunSpecSampleFinished with status : " + paramp2AppManagerStatus);
		setChanged();
		notifyObservers(new p2AppManagerNotification(p2Enumerations.p2DeviceAction.RunSpecSample.NumVal, paramp2AppManagerStatus.NumVal, paramString));
	  }

	  private void m(string paramString, p2Enumerations.p2AppManagerStatus paramp2AppManagerStatus)
	  {
		c_Conflict.info("RunWavelengthCalibrationBG_Finished with status : " + paramp2AppManagerStatus);
		setChanged();
		notifyObservers(new p2AppManagerNotification(p2Enumerations.p2DeviceAction.RunWavelengthCalibrationBG.NumVal, paramp2AppManagerStatus.NumVal, paramString));
	  }

	  private void n(string paramString, p2Enumerations.p2AppManagerStatus paramp2AppManagerStatus)
	  {
		c_Conflict.info("RunWavelengthCalibrationFinished with status : " + paramp2AppManagerStatus);
		setChanged();
		notifyObservers(new p2AppManagerNotification(p2Enumerations.p2DeviceAction.RunWavelengthCalibration.NumVal, paramp2AppManagerStatus.NumVal, paramString));
	  }

	  private void o(string paramString, p2Enumerations.p2AppManagerStatus paramp2AppManagerStatus)
	  {
		c_Conflict.info("SetActuationFinished with status : " + paramp2AppManagerStatus);
		setChanged();
		notifyObservers(new p2AppManagerNotification(p2Enumerations.p2DeviceAction.SetActuation.NumVal, paramp2AppManagerStatus.NumVal, paramString));
	  }

	  private void p(string paramString, p2Enumerations.p2AppManagerStatus paramp2AppManagerStatus)
	  {
		c_Conflict.info("RunCapTime_Calibration_Finished with status : " + paramp2AppManagerStatus);
		setChanged();
		notifyObservers(new p2AppManagerNotification(p2Enumerations.p2DeviceAction.RunCapTimeCalibration.NumVal, paramp2AppManagerStatus.NumVal, paramString));
	  }

	  private void q(string paramString, p2Enumerations.p2AppManagerStatus paramp2AppManagerStatus)
	  {
		c_Conflict.info("RunDelayCompensation_Calibration_Finished with status : " + paramp2AppManagerStatus);
		setChanged();
		notifyObservers(new p2AppManagerNotification(p2Enumerations.p2DeviceAction.RunDelayCompensation.NumVal, paramp2AppManagerStatus.NumVal, paramString));
	  }

	  private void r(string paramString, p2Enumerations.p2AppManagerStatus paramp2AppManagerStatus)
	  {
		c_Conflict.info("RunCore_Calibration_Finished with status : " + paramp2AppManagerStatus);
		setChanged();
		notifyObservers(new p2AppManagerNotification(p2Enumerations.p2DeviceAction.RunCalibration.NumVal, paramp2AppManagerStatus.NumVal, paramString));
	  }

	  private void s(string paramString, p2Enumerations.p2AppManagerStatus paramp2AppManagerStatus)
	  {
		c_Conflict.info("GenerateCalibrationFinished with status : " + paramp2AppManagerStatus);
		setChanged();
		notifyObservers(new p2AppManagerNotification(p2Enumerations.p2DeviceAction.GenerateCalibration.NumVal, paramp2AppManagerStatus.NumVal, paramString));
	  }

	  private void t(string paramString, p2Enumerations.p2AppManagerStatus paramp2AppManagerStatus)
	  {
		c_Conflict.info("RunCapCurrentFinished with status : " + paramp2AppManagerStatus);
		setChanged();
		notifyObservers(new p2AppManagerNotification(p2Enumerations.p2DeviceAction.RunCapCurrent.NumVal, paramp2AppManagerStatus.NumVal, paramString));
	  }

	  private void u(string paramString, p2Enumerations.p2AppManagerStatus paramp2AppManagerStatus)
	  {
		c_Conflict.info("BurnSampleIDFinished with status : " + paramp2AppManagerStatus);
		setChanged();
		notifyObservers(new p2AppManagerNotification(p2Enumerations.p2DeviceAction.BurnSampleID.NumVal, paramp2AppManagerStatus.NumVal, paramString));
	  }

	  private void v(string paramString, p2Enumerations.p2AppManagerStatus paramp2AppManagerStatus)
	  {
		c_Conflict.info("BurnSampleFoldersFinished with status : " + paramp2AppManagerStatus);
		setChanged();
		notifyObservers(new p2AppManagerNotification(p2Enumerations.p2DeviceAction.BurnSampleFolders.NumVal, paramp2AppManagerStatus.NumVal, paramString));
	  }

	  private void w(string paramString, p2Enumerations.p2AppManagerStatus paramp2AppManagerStatus)
	  {
		c_Conflict.info("RestoreDefaultSettingsFinished with status : " + paramp2AppManagerStatus);
		setChanged();
		notifyObservers(new p2AppManagerNotification(p2Enumerations.p2DeviceAction.RestoreDefaultSettings.NumVal, paramp2AppManagerStatus.NumVal, paramString));
	  }

	  private void x(string paramString, p2Enumerations.p2AppManagerStatus paramp2AppManagerStatus)
	  {
		c_Conflict.info("BurnSettingsFinished with status : " + paramp2AppManagerStatus);
		setChanged();
		notifyObservers(new p2AppManagerNotification(p2Enumerations.p2DeviceAction.BurnWorkingSettings.NumVal, paramp2AppManagerStatus.NumVal, paramString));
	  }

	  private void y(string paramString, p2Enumerations.p2AppManagerStatus paramp2AppManagerStatus)
	  {
		c_Conflict.info("ReadSampleFoldersFinished with status : " + paramp2AppManagerStatus);
		setChanged();
		notifyObservers(new p2AppManagerNotification(p2Enumerations.p2DeviceAction.ReadSampleFolders.NumVal, paramp2AppManagerStatus.NumVal, paramString));
	  }

	  private void z(string paramString, p2Enumerations.p2AppManagerStatus paramp2AppManagerStatus)
	  {
		c_Conflict.info("readTempFinished with status : " + paramp2AppManagerStatus);
		setChanged();
		notifyObservers(new p2AppManagerNotification(p2Enumerations.p2DeviceAction.ReadTemp.NumVal, paramp2AppManagerStatus.NumVal, paramString));
	  }

	  private void A(string paramString, p2Enumerations.p2AppManagerStatus paramp2AppManagerStatus)
	  {
		c_Conflict.info("ReadASICRegistersFinished with status : " + paramp2AppManagerStatus);
		setChanged();
		notifyObservers(new p2AppManagerNotification(p2Enumerations.p2DeviceAction.ReadASICRegisters.NumVal, paramp2AppManagerStatus.NumVal, paramString));
	  }

	  private void B(string paramString, p2Enumerations.p2AppManagerStatus paramp2AppManagerStatus)
	  {
		c_Conflict.info("WriteASICRegistersFinished with status : " + paramp2AppManagerStatus);
		setChanged();
		notifyObservers(new p2AppManagerNotification(p2Enumerations.p2DeviceAction.WriteASICRegisters.NumVal, paramp2AppManagerStatus.NumVal, paramString));
	  }

	  private void C(string paramString, p2Enumerations.p2AppManagerStatus paramp2AppManagerStatus)
	  {
		c_Conflict.info("CalculateResponseFinished with status : " + paramp2AppManagerStatus);
		setChanged();
		notifyObservers(new p2AppManagerNotification(p2Enumerations.p2DeviceAction.CalculateResponse.NumVal, paramp2AppManagerStatus.NumVal, paramString));
	  }

	  private void D(string paramString, p2Enumerations.p2AppManagerStatus paramp2AppManagerStatus)
	  {
		c_Conflict.info("CalculateParametersFinished with status : " + paramp2AppManagerStatus);
		setChanged();
		notifyObservers(new p2AppManagerNotification(p2Enumerations.p2DeviceAction.CalculateParameters.NumVal, paramp2AppManagerStatus.NumVal, paramString));
	  }

	  private void E(string paramString, p2Enumerations.p2AppManagerStatus paramp2AppManagerStatus)
	  {
		c_Conflict.info("TrimCoefficientsFinished with status : " + paramp2AppManagerStatus);
		setChanged();
		notifyObservers(new p2AppManagerNotification(p2Enumerations.p2DeviceAction.TrimCoefficients.NumVal, paramp2AppManagerStatus.NumVal, paramString));
	  }

	  private void F(string paramString, p2Enumerations.p2AppManagerStatus paramp2AppManagerStatus)
	  {
		c_Conflict.info("TrimPhaseFinished with status : " + paramp2AppManagerStatus);
		setChanged();
		notifyObservers(new p2AppManagerNotification(p2Enumerations.p2DeviceAction.TrimPhase.NumVal, paramp2AppManagerStatus.NumVal, paramString));
	  }

	  private void G(string paramString, p2Enumerations.p2AppManagerStatus paramp2AppManagerStatus)
	  {
		c_Conflict.info("TrimPhaseFastFinished with status : " + paramp2AppManagerStatus);
		setChanged();
		notifyObservers(new p2AppManagerNotification(p2Enumerations.p2DeviceAction.TrimPhaseFast.NumVal, paramp2AppManagerStatus.NumVal, paramString));
	  }

	  private void H(string paramString, p2Enumerations.p2AppManagerStatus paramp2AppManagerStatus)
	  {
		c_Conflict.info("CheckStabilityFinished with status : " + paramp2AppManagerStatus);
		setChanged();
		notifyObservers(new p2AppManagerNotification(p2Enumerations.p2DeviceAction.CheckStability.NumVal, paramp2AppManagerStatus.NumVal, paramString));
	  }

	  private void I(string paramString, p2Enumerations.p2AppManagerStatus paramp2AppManagerStatus)
	  {
		c_Conflict.info("RunWaveformFinished with status : " + paramp2AppManagerStatus);
		setChanged();
		notifyObservers(new p2AppManagerNotification(p2Enumerations.p2DeviceAction.RunWaveform.NumVal, paramp2AppManagerStatus.NumVal, paramString));
	  }

	  public override string WorkingDirectory
	  {
		  set
		  {
			this.d_Conflict = value;
			p2Constants.APPLICATION_WORKING_DIRECTORY = value;
			p2Enumerations.p2AppManagerStatus p2AppManagerStatus = a();
			if (p2AppManagerStatus != p2Enumerations.p2AppManagerStatus.NO_ERROR)
			{
			  throw new p2AppManagerException("Failed to initialize General Configurations", p2AppManagerStatus.NumVal);
			}
			if (this.b_Conflict == null)
			{
			  this.b_Conflict = b();
			}
			this.b_Conflict.u();
			p2AppManagerUtils.createDir(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs");
		  }
		  get
		  {
			  return this.d_Conflict;
		  }
	  }

	}


	/* Location:              D:\jobs\BalitTanah.SoilSensingKit\Decompile Driver\SDK v4.3\SDKv4.3\bin_win_x64\p2AppManager.jar!\sws\p2AppManager\p2AppManagerFullImpl.class
	 * Java compiler version: 7 (51.0)
	 * JD-Core Version:       1.0.7
	 */
}