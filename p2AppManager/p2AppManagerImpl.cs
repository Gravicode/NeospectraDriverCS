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

	public class p2AppManagerImpl : p2AppManager
	{
	  private b globalSampleConfiguration;

	  private a device;

	  private static Logger logger = Logger.getLogger(typeof(p2AppManagerImpl));

	  private string workingDirectory = System.getProperty("user.dir");

	  public p2AppManagerImpl()
	  {
		p2Constants.APPLICATION_WORKING_DIRECTORY = this.workingDirectory;
		p2Enumerations.p2AppManagerStatus p2AppManagerStatus = a();
		if (p2AppManagerStatus != p2Enumerations.p2AppManagerStatus.NO_ERROR)
		{
			;
		}
	  }

	  public p2AppManagerImpl(string paramString)
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
		logger.info("start initializeCore method ");
		if (this.device == null)
		{
		  this.device = b();
		}
		return this.device.a(this.globalSampleConfiguration, paramVarArgs);
	  }

	  public override p2Enumerations.p2AppManagerStatus checkDeviceStatus(params string[] paramVarArgs)
	  {
		if (this.device == null)
		{
		  this.device = b();
		}
		return this.device.b(this.globalSampleConfiguration, paramVarArgs);
	  }

	  public override p2Enumerations.p2AppManagerStatus runSpec(params string[] paramVarArgs)
	  {
		logger.info("start runSpec method ");
		if (this.device == null)
		{
		  this.device = b();
		}
		return this.device.c(this.globalSampleConfiguration, paramVarArgs);
	  }

	  public override p2Enumerations.p2AppManagerStatus wavelengthCalibrationBG(params string[] paramVarArgs)
	  {
		logger.info("start wavelengthCalibrationBG method ");
		if (this.device == null)
		{
		  this.device = b();
		}
		return this.device.d(this.globalSampleConfiguration, paramVarArgs);
	  }

	  public override p2Enumerations.p2AppManagerStatus wavelengthCalibration(params string[] paramVarArgs)
	  {
		logger.info("start wavelengthCalibration method ");
		if (this.device == null)
		{
		  this.device = b();
		}
		return this.device.e(this.globalSampleConfiguration, paramVarArgs);
	  }

	  public override double ErrorData
	  {
		  get
		  {
			logger.info("start getErrorData method ");
			return (this.device == null) ? 1.0D : this.device.b();
		  }
	  }

	  public override double[][] SpecData
	  {
		  get
		  {
			logger.info("start getSpecData method ");
			return (this.device == null) ? (double[][])null : this.device.c();
		  }
	  }

	  public override p2Enumerations.p2AppManagerStatus runInterSpecDSP(double[][] paramArrayOfDouble, params string[] paramVarArgs)
	  {
		  return p2Enumerations.p2AppManagerStatus.SW_DOESNOT_SUPPORT_THIS_FEATURE;
	  }

	  public override p2Enumerations.p2AppManagerStatus runInterSpec(params string[] paramVarArgs)
	  {
		logger.info("start runInterSpec method ");
		if (this.device == null)
		{
		  this.device = b();
		}
		return this.device.f(this.globalSampleConfiguration, paramVarArgs);
	  }

	  public override p2Enumerations.p2AppManagerStatus updateFFT_SettingsInterSpec(params string[] paramVarArgs)
	  {
		logger.info("start updateFFT_SettingsInterSpec method ");
		if (this.device == null)
		{
		  this.device = b();
		}
		return this.device.g(this.globalSampleConfiguration, paramVarArgs);
	  }

	  public override p2Enumerations.p2AppManagerStatus updateFFT_SettingsSpec(params string[] paramVarArgs)
	  {
		logger.info("start updateFFT_SettingsSpec method ");
		if (this.device == null)
		{
		  this.device = b();
		}
		return this.device.h(this.globalSampleConfiguration, paramVarArgs);
	  }

	  public override p2Enumerations.p2AppManagerStatus runSNR(params string[] paramVarArgs)
	  {
		  return p2Enumerations.p2AppManagerStatus.SW_DOESNOT_SUPPORT_THIS_FEATURE;
	  }

	  public override p2Enumerations.p2AppManagerStatus runStability(params string[] paramVarArgs)
	  {
		  return p2Enumerations.p2AppManagerStatus.SW_DOESNOT_SUPPORT_THIS_FEATURE;
	  }

	  public override p2Enumerations.p2AppManagerStatus runCalibCorr(params string[] paramVarArgs)
	  {
		logger.info("start runCalibCorr method ");
		if (this.device == null)
		{
		  this.device = b();
		}
		return this.device.k(this.globalSampleConfiguration, paramVarArgs);
	  }

	  public override p2Enumerations.p2AppManagerStatus runInterSpecGainAdj(params string[] paramVarArgs)
	  {
		logger.info("start runInterSpecGainAdj method ");
		if (this.device == null)
		{
		  this.device = b();
		}
		return this.device.l(this.globalSampleConfiguration, paramVarArgs);
	  }

	  public override p2Enumerations.p2AppManagerStatus runSpecGainAdjBG(params string[] paramVarArgs)
	  {
		logger.info("start runSpecGainAdjBG method ");
		if (this.device == null)
		{
		  this.device = b();
		}
		return this.device.m(this.globalSampleConfiguration, paramVarArgs);
	  }

	  public override p2Enumerations.p2AppManagerStatus saveInterSpecGainSettings(string paramString, double[][] paramArrayOfDouble)
	  {
		logger.info("start saveInterSpecGainSettings method ");
		return this.device.a(paramString, paramArrayOfDouble);
	  }

	  public override p2Enumerations.p2AppManagerStatus saveSpecGainSettings(string paramString, double[][] paramArrayOfDouble)
	  {
		logger.info("start saveSpecGainSettings method ");
		return this.device.b(paramString, paramArrayOfDouble);
	  }

	  public override p2Enumerations.p2AppManagerStatus runSpecGainAdjSample(params string[] paramVarArgs)
	  {
		logger.info("start runSpecGainAdjSample method ");
		if (this.device == null)
		{
		  this.device = b();
		}
		return this.device.n(this.globalSampleConfiguration, paramVarArgs);
	  }

	  public override double[][] RawData
	  {
		  get
		  {
			  return (double[][])null;
		  }
	  }

	  public override double[][] InterSpecData
	  {
		  get
		  {
			logger.info("start getInterSpecData method ");
			return (this.device == null) ? (double[][])null : this.device.e();
		  }
	  }

	  public override double[][] GainAdjustInterSpecData
	  {
		  get
		  {
			logger.info("start getGainAdjustInterSpecData method ");
			return (this.device == null) ? (double[][])null : this.device.f();
		  }
	  }

	  public override double[][] GainAdjustSpecData
	  {
		  get
		  {
			logger.info("start getGainAdjustSpecData method ");
			return (this.device == null) ? (double[][])null : this.device.g();
		  }
	  }

	  public override double[][] SNR_Data
	  {
		  get
		  {
			  return (double[][])null;
		  }
	  }

	  public override double[][] StabilityData
	  {
		  get
		  {
			  return (double[][])null;
		  }
	  }

	  public override p2Enumerations.p2AppManagerStatus switchDevice(params string[] paramVarArgs)
	  {
		logger.info("start setActuation method ");
		if (this.device == null)
		{
		  this.device = b();
		}
		return this.device.t(this.globalSampleConfiguration, paramVarArgs);
	  }

	  public override params string[] Settings
	  {
		  set
		  {
			logger.info("start setSampleFolder method ");
			if (this.device == null)
			{
			  this.device = b();
			}
			this.device.u(this.globalSampleConfiguration, value);
		  }
	  }

	  public override params string[] OpticalSettings
	  {
		  set
		  {
			logger.info("start setOpticalSettings method ");
			if (this.device == null)
			{
			  this.device = b();
			}
			this.device.a_Conflict(value);
		  }
	  }

	  public override string DeviceId
	  {
		  get
		  {
			  return this.device.a();
		  }
	  }

	  public override string SDKVersion
	  {
		  get
		  {
			  return "4.3";
		  }
	  }

	  public virtual void update(Observable paramObservable, object paramObject)
	  {
		logger.info("start update method ");
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
			logger.info("initialize core....");
			a(str, p2DeviceNotificationResult.Status);
			return;
		  case 2:
			logger.info("run inter spec....");
			b(str, p2DeviceNotificationResult.Status);
			return;
		  case 3:
			logger.info("run FFT settings inter spec....");
			c(str, p2DeviceNotificationResult.Status);
			return;
		  case 4:
			logger.info("run FFT settings spec....");
			d(str, p2DeviceNotificationResult.Status);
			return;
		  case 5:
			logger.info("run Gain Adjustment InterSpec....");
			e(str, p2DeviceNotificationResult.Status);
			return;
		  case 6:
			logger.info("run Gain Adjustment Spec BG....");
			f(str, p2DeviceNotificationResult.Status);
			return;
		  case 7:
			logger.info("run Gain Adjustment Spec Sample....");
			g(str, p2DeviceNotificationResult.Status);
			return;
		  case 8:
			logger.info("run background ....");
			h(str, p2DeviceNotificationResult.Status);
			return;
		  case 9:
			logger.info("run spectrocopy ....");
			i(str, p2DeviceNotificationResult.Status);
			return;
		  case 10:
			logger.info("run BG wavelength calibration ....");
			j(str, p2DeviceNotificationResult.Status);
			return;
		  case 11:
			logger.info("run wavelength calibration ....");
			k(str, p2DeviceNotificationResult.Status);
			return;
		  case 12:
			logger.info("Setting Actuation....");
			l(str, p2DeviceNotificationResult.Status);
			return;
		  case 13:
			logger.info("Burn Working Settings....");
			o(str, p2DeviceNotificationResult.Status);
			return;
		  case 14:
			logger.info("Restore Default Settings");
			m(str, p2DeviceNotificationResult.Status);
			return;
		  case 15:
			logger.info("run Interferogram Corr ....");
			n(str, p2DeviceNotificationResult.Status);
			return;
		}
		setChanged();
		notifyObservers(new p2AppManagerNotification(-1, p2Enumerations.p2AppManagerStatus.INVALID_ACTION_ERROR.NumVal, null));
	  }

	  private p2Enumerations.p2AppManagerStatus a()
	  {
		this.globalSampleConfiguration = new b();
		return this.globalSampleConfiguration.d();
	  }

	  private a b()
	  {
		b b1 = new b();
		b1.addObserver(this);
		return b1;
	  }

	  private void a(string paramString, p2Enumerations.p2AppManagerStatus paramp2AppManagerStatus)
	  {
		logger.info("lynxinitializeCoreFinished");
		setChanged();
		notifyObservers(new p2AppManagerNotification(p2Enumerations.p2DeviceAction.initializeCore.NumVal, paramp2AppManagerStatus.NumVal, paramString));
	  }

	  private void b(string paramString, p2Enumerations.p2AppManagerStatus paramp2AppManagerStatus)
	  {
		logger.info("RunInterSpecFinished with status : " + paramp2AppManagerStatus);
		setChanged();
		notifyObservers(new p2AppManagerNotification(p2Enumerations.p2DeviceAction.RunInterSpec.NumVal, paramp2AppManagerStatus.NumVal, paramString));
	  }

	  private void c(string paramString, p2Enumerations.p2AppManagerStatus paramp2AppManagerStatus)
	  {
		logger.info("RunUpdateFFT_InterSpecFinished with status : " + paramp2AppManagerStatus);
		setChanged();
		notifyObservers(new p2AppManagerNotification(p2Enumerations.p2DeviceAction.RunUpdateFFT_SettingsInterSpec.NumVal, paramp2AppManagerStatus.NumVal, paramString));
	  }

	  private void d(string paramString, p2Enumerations.p2AppManagerStatus paramp2AppManagerStatus)
	  {
		logger.info("RunUpdateFFT_SpecFinished with status : " + paramp2AppManagerStatus);
		setChanged();
		notifyObservers(new p2AppManagerNotification(p2Enumerations.p2DeviceAction.RunUpdateFFT_SettingsSpec.NumVal, paramp2AppManagerStatus.NumVal, paramString));
	  }

	  private void e(string paramString, p2Enumerations.p2AppManagerStatus paramp2AppManagerStatus)
	  {
		logger.info("RunGainAdjustInterSpecFinished with status : " + paramp2AppManagerStatus);
		setChanged();
		notifyObservers(new p2AppManagerNotification(p2Enumerations.p2DeviceAction.RunGainAdjustInterSpec.NumVal, paramp2AppManagerStatus.NumVal, paramString));
	  }

	  private void f(string paramString, p2Enumerations.p2AppManagerStatus paramp2AppManagerStatus)
	  {
		logger.info("RunGainAdjustSpecBG_Finished with status : " + paramp2AppManagerStatus);
		setChanged();
		notifyObservers(new p2AppManagerNotification(p2Enumerations.p2DeviceAction.RunGainAdjustSpecBG.NumVal, paramp2AppManagerStatus.NumVal, paramString));
	  }

	  private void g(string paramString, p2Enumerations.p2AppManagerStatus paramp2AppManagerStatus)
	  {
		logger.info("RunGainAdjustSpecSampleFinished with status : " + paramp2AppManagerStatus);
		setChanged();
		notifyObservers(new p2AppManagerNotification(p2Enumerations.p2DeviceAction.RunGainAdjustSpecSample.NumVal, paramp2AppManagerStatus.NumVal, paramString));
	  }

	  private void h(string paramString, p2Enumerations.p2AppManagerStatus paramp2AppManagerStatus)
	  {
		logger.info("RunSpecBackgroundeFinished with status : " + paramp2AppManagerStatus);
		setChanged();
		notifyObservers(new p2AppManagerNotification(p2Enumerations.p2DeviceAction.RunSpecBackground.NumVal, paramp2AppManagerStatus.NumVal, paramString));
	  }

	  private void i(string paramString, p2Enumerations.p2AppManagerStatus paramp2AppManagerStatus)
	  {
		logger.info("RunSpecSampleFinished with status : " + paramp2AppManagerStatus);
		setChanged();
		notifyObservers(new p2AppManagerNotification(p2Enumerations.p2DeviceAction.RunSpecSample.NumVal, paramp2AppManagerStatus.NumVal, paramString));
	  }

	  private void j(string paramString, p2Enumerations.p2AppManagerStatus paramp2AppManagerStatus)
	  {
		logger.info("RunWavelengthCalibrationBG_Finished with status : " + paramp2AppManagerStatus);
		setChanged();
		notifyObservers(new p2AppManagerNotification(p2Enumerations.p2DeviceAction.RunWavelengthCalibrationBG.NumVal, paramp2AppManagerStatus.NumVal, paramString));
	  }

	  private void k(string paramString, p2Enumerations.p2AppManagerStatus paramp2AppManagerStatus)
	  {
		logger.info("RunWavelengthCalibrationFinished with status : " + paramp2AppManagerStatus);
		setChanged();
		notifyObservers(new p2AppManagerNotification(p2Enumerations.p2DeviceAction.RunWavelengthCalibration.NumVal, paramp2AppManagerStatus.NumVal, paramString));
	  }

	  private void l(string paramString, p2Enumerations.p2AppManagerStatus paramp2AppManagerStatus)
	  {
		logger.info("SetActuationFinished with status : " + paramp2AppManagerStatus);
		setChanged();
		notifyObservers(new p2AppManagerNotification(p2Enumerations.p2DeviceAction.SetActuation.NumVal, paramp2AppManagerStatus.NumVal, paramString));
	  }

	  public override p2Enumerations.p2AppManagerStatus runCapTime_Calibration(params string[] paramVarArgs)
	  {
		  return p2Enumerations.p2AppManagerStatus.SW_DOESNOT_SUPPORT_THIS_FEATURE;
	  }

	  public override double[][] CapTimeData
	  {
		  get
		  {
			  return (double[][])null;
		  }
	  }

	  public override p2Enumerations.p2AppManagerStatus runDelayCompensation_Calibration(params string[] paramVarArgs)
	  {
		  return p2Enumerations.p2AppManagerStatus.SW_DOESNOT_SUPPORT_THIS_FEATURE;
	  }

	  public override p2Enumerations.p2AppManagerStatus runCalibrationCore_Calibration(params string[] paramVarArgs)
	  {
		  return p2Enumerations.p2AppManagerStatus.SW_DOESNOT_SUPPORT_THIS_FEATURE;
	  }

	  public override p2Enumerations.p2AppManagerStatus generateCalibration(params string[] paramVarArgs)
	  {
		  return p2Enumerations.p2AppManagerStatus.SW_DOESNOT_SUPPORT_THIS_FEATURE;
	  }

	  public override double[][] CalibrationData
	  {
		  get
		  {
			  return (double[][])null;
		  }
	  }

	  public override p2Enumerations.p2AppManagerStatus runCapCurrent(params string[] paramVarArgs)
	  {
		  return p2Enumerations.p2AppManagerStatus.SW_DOESNOT_SUPPORT_THIS_FEATURE;
	  }

	  public override double[][] CapCurrentData
	  {
		  get
		  {
			  return (double[][])null;
		  }
	  }

	  public override p2Enumerations.p2AppManagerStatus burnSampleID(params string[] paramVarArgs)
	  {
		  return p2Enumerations.p2AppManagerStatus.SW_DOESNOT_SUPPORT_THIS_FEATURE;
	  }

	  public override p2Enumerations.p2AppManagerStatus burnSampleFolders(string[] paramArrayOfString)
	  {
		  return p2Enumerations.p2AppManagerStatus.SW_DOESNOT_SUPPORT_THIS_FEATURE;
	  }

	  private void m(string paramString, p2Enumerations.p2AppManagerStatus paramp2AppManagerStatus)
	  {
		logger.info("RestoreDefaultSettingsFinished with status : " + paramp2AppManagerStatus);
		setChanged();
		notifyObservers(new p2AppManagerNotification(p2Enumerations.p2DeviceAction.RestoreDefaultSettings.NumVal, paramp2AppManagerStatus.NumVal, paramString));
	  }

	  private void n(string paramString, p2Enumerations.p2AppManagerStatus paramp2AppManagerStatus)
	  {
		logger.info("RunInterferogramCorr_Finished with status : " + paramp2AppManagerStatus);
		setChanged();
		notifyObservers(new p2AppManagerNotification(p2Enumerations.p2DeviceAction.RunSelfCorr.NumVal, paramp2AppManagerStatus.NumVal, paramString));
	  }

	  private void o(string paramString, p2Enumerations.p2AppManagerStatus paramp2AppManagerStatus)
	  {
		logger.info("BurnSettingsFinished with status : " + paramp2AppManagerStatus);
		setChanged();
		notifyObservers(new p2AppManagerNotification(p2Enumerations.p2DeviceAction.BurnWorkingSettings.NumVal, paramp2AppManagerStatus.NumVal, paramString));
	  }

	  public override p2Enumerations.p2AppManagerStatus restoreDefaultSettings(params string[] paramVarArgs)
	  {
		logger.info("start restoreDefaultSettings method ");
		if (this.device == null)
		{
		  this.device = b();
		}
		return this.device.x(this.globalSampleConfiguration, paramVarArgs);
	  }

	  public override p2Enumerations.p2AppManagerStatus burnSettings(params string[] paramVarArgs)
	  {
		logger.info("start restoreDefaultSettings method ");
		if (this.device == null)
		{
		  this.device = b();
		}
		return this.device.y(this.globalSampleConfiguration, paramVarArgs);
	  }

	  public override p2Enumerations.p2AppManagerStatus burnSpecificSettings(params string[] paramVarArgs)
	  {
		logger.info("start restoreDefaultSettings method ");
		if (this.device == null)
		{
		  this.device = b();
		}
		return this.device.J(this.globalSampleConfiguration, paramVarArgs);
	  }

	  public override p2Enumerations.p2AppManagerStatus readTemp(params string[] paramVarArgs)
	  {
		  return p2Enumerations.p2AppManagerStatus.SW_DOESNOT_SUPPORT_THIS_FEATURE;
	  }

	  public override double[][] TempData
	  {
		  get
		  {
			  return (double[][])null;
		  }
	  }

	  public override p2Enumerations.p2AppManagerStatus readASICRegisters(params string[] paramVarArgs)
	  {
		  return p2Enumerations.p2AppManagerStatus.SW_DOESNOT_SUPPORT_THIS_FEATURE;
	  }

	  public override p2Enumerations.p2AppManagerStatus writeASICRegisters(long[] paramArrayOfLong)
	  {
		  return p2Enumerations.p2AppManagerStatus.SW_DOESNOT_SUPPORT_THIS_FEATURE;
	  }

	  public override long[] ASICRegisters
	  {
		  get
		  {
			  return null;
		  }
	  }

	  public override p2Enumerations.p2AppManagerStatus readSampleFolders(params string[] paramVarArgs)
	  {
		  return p2Enumerations.p2AppManagerStatus.SW_DOESNOT_SUPPORT_THIS_FEATURE;
	  }

	  public override p2Enumerations.p2AppManagerStatus calculateResponse_ClosedLoop(params string[] paramVarArgs)
	  {
		  return p2Enumerations.p2AppManagerStatus.SW_DOESNOT_SUPPORT_THIS_FEATURE;
	  }

	  public override double[][] ResponseData
	  {
		  get
		  {
			  return (double[][])null;
		  }
	  }

	  public override p2Enumerations.p2AppManagerStatus calculateParameters_ClosedLoop(params string[] paramVarArgs)
	  {
		  return p2Enumerations.p2AppManagerStatus.SW_DOESNOT_SUPPORT_THIS_FEATURE;
	  }

	  public override double[][] ParametersData
	  {
		  get
		  {
			  return (double[][])null;
		  }
	  }

	  public override p2Enumerations.p2AppManagerStatus CoefficientsTrimming_ClosedLoop(params string[] paramVarArgs)
	  {
		  return p2Enumerations.p2AppManagerStatus.SW_DOESNOT_SUPPORT_THIS_FEATURE;
	  }

	  public override double[][] CoefficientsTrimmingData
	  {
		  get
		  {
			  return (double[][])null;
		  }
	  }

	  public override p2Enumerations.p2AppManagerStatus PhaseTrimming_ClosedLoop(params string[] paramVarArgs)
	  {
		  return p2Enumerations.p2AppManagerStatus.SW_DOESNOT_SUPPORT_THIS_FEATURE;
	  }

	  public override p2Enumerations.p2AppManagerStatus PhaseTrimmingFast_ClosedLoop(params string[] paramVarArgs)
	  {
		  return p2Enumerations.p2AppManagerStatus.SW_DOESNOT_SUPPORT_THIS_FEATURE;
	  }

	  public override double[][] PhaseTrimmingData
	  {
		  get
		  {
			  return (double[][])null;
		  }
	  }

	  public override p2Enumerations.p2AppManagerStatus StabilityCheck_ClosedLoop(params string[] paramVarArgs)
	  {
		  return p2Enumerations.p2AppManagerStatus.SW_DOESNOT_SUPPORT_THIS_FEATURE;
	  }

	  public override double[][] StabilityCheckData
	  {
		  get
		  {
			  return (double[][])null;
		  }
	  }

	  public override p2Enumerations.p2AppManagerStatus WaveformPreview_ClosedLoop(params string[] paramVarArgs)
	  {
		  return p2Enumerations.p2AppManagerStatus.SW_DOESNOT_SUPPORT_THIS_FEATURE;
	  }

	  public override double[][] WaveformPreviewData
	  {
		  get
		  {
			  return (double[][])null;
		  }
	  }

	  public override string WorkingDirectory
	  {
		  set
		  {
			this.workingDirectory = value;
			p2Constants.APPLICATION_WORKING_DIRECTORY = value;
			p2Enumerations.p2AppManagerStatus p2AppManagerStatus = a();
			if (p2AppManagerStatus != p2Enumerations.p2AppManagerStatus.NO_ERROR)
			{
			  throw new p2AppManagerException("Failed to initialize General Configurations", p2AppManagerStatus.NumVal);
			}
			if (this.device == null)
			{
			  this.device = b();
			}
			this.device.u();
			p2AppManagerUtils.createDir(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs");
		  }
		  get
		  {
			  return this.workingDirectory;
		  }
	  }

	}


	/* Location:              D:\jobs\BalitTanah.SoilSensingKit\Decompile Driver\SDK v4.3\SDKv4.3\bin_win_x64\p2AppManager.jar!\sws\p2AppManager\p2AppManagerImpl.class
	 * Java compiler version: 7 (51.0)
	 * JD-Core Version:       1.0.7
	 */
}