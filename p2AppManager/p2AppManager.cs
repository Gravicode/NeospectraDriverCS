namespace sws.p2AppManager
{
	using p2Enumerations = sws.p2AppManager.utils.p2Enumerations;

	public abstract class p2AppManager : Observable, Observer
	{
	  public abstract string WorkingDirectory {set;get;}


	  public abstract string DeviceId {get;}

	  public abstract string SDKVersion {get;}

	  public abstract p2Enumerations.p2AppManagerStatus initializeCore(params string[] paramVarArgs);

	  public abstract p2Enumerations.p2AppManagerStatus checkDeviceStatus(params string[] paramVarArgs);

	  public abstract p2Enumerations.p2AppManagerStatus runSpec(params string[] paramVarArgs);

	  public abstract p2Enumerations.p2AppManagerStatus wavelengthCalibration(params string[] paramVarArgs);

	  public abstract p2Enumerations.p2AppManagerStatus wavelengthCalibrationBG(params string[] paramVarArgs);

	  public abstract double[][] SpecData {get;}

	  public abstract double ErrorData {get;}

	  public abstract p2Enumerations.p2AppManagerStatus runInterSpecDSP(double[][] paramArrayOfDouble, params string[] paramVarArgs);

	  public abstract p2Enumerations.p2AppManagerStatus runInterSpec(params string[] paramVarArgs);

	  public abstract p2Enumerations.p2AppManagerStatus updateFFT_SettingsInterSpec(params string[] paramVarArgs);

	  public abstract p2Enumerations.p2AppManagerStatus updateFFT_SettingsSpec(params string[] paramVarArgs);

	  public abstract p2Enumerations.p2AppManagerStatus saveInterSpecGainSettings(string paramString, double[][] paramArrayOfDouble);

	  public abstract p2Enumerations.p2AppManagerStatus saveSpecGainSettings(string paramString, double[][] paramArrayOfDouble);

	  public abstract p2Enumerations.p2AppManagerStatus runSNR(params string[] paramVarArgs);

	  public abstract p2Enumerations.p2AppManagerStatus runStability(params string[] paramVarArgs);

	  public abstract p2Enumerations.p2AppManagerStatus runCalibCorr(params string[] paramVarArgs);

	  public abstract p2Enumerations.p2AppManagerStatus runInterSpecGainAdj(params string[] paramVarArgs);

	  public abstract p2Enumerations.p2AppManagerStatus runSpecGainAdjBG(params string[] paramVarArgs);

	  public abstract p2Enumerations.p2AppManagerStatus runSpecGainAdjSample(params string[] paramVarArgs);

	  public abstract double[][] RawData {get;}

	  public abstract double[][] InterSpecData {get;}

	  public abstract double[][] GainAdjustInterSpecData {get;}

	  public abstract double[][] GainAdjustSpecData {get;}

	  public abstract double[][] SNR_Data {get;}

	  public abstract double[][] StabilityData {get;}

	  public abstract p2Enumerations.p2AppManagerStatus runCapTime_Calibration(params string[] paramVarArgs);

	  public abstract double[][] CapTimeData {get;}

	  public abstract p2Enumerations.p2AppManagerStatus runDelayCompensation_Calibration(params string[] paramVarArgs);

	  public abstract p2Enumerations.p2AppManagerStatus runCalibrationCore_Calibration(params string[] paramVarArgs);

	  public abstract p2Enumerations.p2AppManagerStatus generateCalibration(params string[] paramVarArgs);

	  public abstract double[][] CalibrationData {get;}

	  public abstract p2Enumerations.p2AppManagerStatus runCapCurrent(params string[] paramVarArgs);

	  public abstract double[][] CapCurrentData {get;}

	  public abstract p2Enumerations.p2AppManagerStatus switchDevice(params string[] paramVarArgs);

	  public abstract params string[] Settings {set;}

	  public abstract params string[] OpticalSettings {set;}

	  public abstract p2Enumerations.p2AppManagerStatus burnSampleID(params string[] paramVarArgs);

	  public abstract p2Enumerations.p2AppManagerStatus burnSampleFolders(string[] paramArrayOfString);

	  public abstract p2Enumerations.p2AppManagerStatus restoreDefaultSettings(params string[] paramVarArgs);

	  public abstract p2Enumerations.p2AppManagerStatus burnSettings(params string[] paramVarArgs);

	  public abstract p2Enumerations.p2AppManagerStatus burnSpecificSettings(params string[] paramVarArgs);

	  public abstract p2Enumerations.p2AppManagerStatus readSampleFolders(params string[] paramVarArgs);

	  public abstract p2Enumerations.p2AppManagerStatus readTemp(params string[] paramVarArgs);

	  public abstract double[][] TempData {get;}

	  public abstract p2Enumerations.p2AppManagerStatus readASICRegisters(params string[] paramVarArgs);

	  public abstract p2Enumerations.p2AppManagerStatus writeASICRegisters(long[] paramArrayOfLong);

	  public abstract long[] ASICRegisters {get;}

	  public abstract p2Enumerations.p2AppManagerStatus calculateResponse_ClosedLoop(params string[] paramVarArgs);

	  public abstract double[][] ResponseData {get;}

	  public abstract p2Enumerations.p2AppManagerStatus calculateParameters_ClosedLoop(params string[] paramVarArgs);

	  public abstract double[][] ParametersData {get;}

	  public abstract p2Enumerations.p2AppManagerStatus CoefficientsTrimming_ClosedLoop(params string[] paramVarArgs);

	  public abstract double[][] CoefficientsTrimmingData {get;}

	  public abstract p2Enumerations.p2AppManagerStatus PhaseTrimming_ClosedLoop(params string[] paramVarArgs);

	  public abstract p2Enumerations.p2AppManagerStatus PhaseTrimmingFast_ClosedLoop(params string[] paramVarArgs);

	  public abstract double[][] PhaseTrimmingData {get;}

	  public abstract p2Enumerations.p2AppManagerStatus StabilityCheck_ClosedLoop(params string[] paramVarArgs);

	  public abstract double[][] StabilityCheckData {get;}

	  public abstract p2Enumerations.p2AppManagerStatus WaveformPreview_ClosedLoop(params string[] paramVarArgs);

	  public abstract double[][] WaveformPreviewData {get;}
	}


	/* Location:              D:\jobs\BalitTanah.SoilSensingKit\Decompile Driver\SDK v4.3\SDKv4.3\bin_win_x64\p2AppManager.jar!\sws\p2AppManager\p2AppManager.class
	 * Java compiler version: 7 (51.0)
	 * JD-Core Version:       1.0.7
	 */
}