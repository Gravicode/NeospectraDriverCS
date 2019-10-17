using System;
using System.IO;

namespace sws.p2AppManager.utils
{

	public class p2Constants
	{
	  public static string APPLICATION_WORKING_DIRECTORY = System.getProperty("user.dir");

	  public static readonly string Original_APPLICATION_WORKING_DIRECTORY = System.getProperty("user.dir");

	  public static readonly string PARAM_HEADER_FIE_PATH = Original_APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "mems" + Path.DirectorySeparatorChar + "param.conf";

	  public static readonly string CONFIG_SAMPLE_PATH_TEMPLATE = Original_APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "Conf_Files" + Path.DirectorySeparatorChar + "{0}";

	  public static readonly string CONFIG_SAMPLE_PROFILE_PATH_TEMPLATE = Original_APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "Conf_Files" + Path.DirectorySeparatorChar + "{0}" + Path.DirectorySeparatorChar + "{1}";

	  public static readonly string TEMP_CONFIG_SAMPLE_PATH = Original_APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "Conf_Files" + Path.DirectorySeparatorChar + "TempConf";

	  public static readonly string CONFIG_SAMPLE_PROFILE_FILES_PATH_TEMPLATE = Original_APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "Conf_Files" + Path.DirectorySeparatorChar + "{0}" + Path.DirectorySeparatorChar + "{1}" + Path.DirectorySeparatorChar + "{2}";

	  public static readonly string GLOBAL_CONFIG_FILES_PATH = Original_APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "mems" + Path.DirectorySeparatorChar + "{0}";

	  public static readonly string GLOBAL_CONFIG_MEMS_PATH = Original_APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "mems";

	  public static readonly string REGISTERS_OPTIONS_FOLDER_PATH = Original_APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "mems" + Path.DirectorySeparatorChar + "Registers";

	  public const string CONF_FILES_FLODER = "Conf_Files";

	  public const string MEMS_FLODER = "mems";

	  public static readonly string WHITE_LIGHT_FILES_DIR = Original_APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "white Light";

	  public const string WHITE_LIGHT_FILE = "WhiteLight.xml";

	  public const string OPTICAL_SETTINGS_FILE_NAME = "savedOpticalSettings.txt";

	  public const string OPTICAL_SETTINGS_TEMP_FILE_NAME = "tempOpticalSettings.txt";

	  public const string OPTICAL_SETTINGS_TEMP_FILE_NAME2 = "tempOpticalSettings2.txt";

	  public static readonly string OPTICAL_SETTINGS_FILE_PATH = Original_APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "Conf_Files" + Path.DirectorySeparatorChar + "{0}" + Path.DirectorySeparatorChar + "savedOpticalSettings.txt";

	  public static readonly string OPTICAL_SETTINGS_TEMP_FILE_PATH = Original_APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "Conf_Files" + Path.DirectorySeparatorChar + "TempConf" + Path.DirectorySeparatorChar + "tempOpticalSettings.txt";

	  public static readonly string OPTICAL_SETTINGS_TEMP2_FILE_PATH = Original_APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "Conf_Files" + Path.DirectorySeparatorChar + "TempConf" + Path.DirectorySeparatorChar + "tempOpticalSettings2.txt";

	  public const string OPTICAL_SETTINGS_CURRENT_RANGE = "CURRENT_RANGE";

	  public const string OPTICAL_SETTINGS_PGA1 = "PGA1";

	  public const string OPTICAL_SETTINGS_PGA2 = "PGA2";

	  public const string STANDARD_CALIBRATORS_FOLDER_NAME = "standard_calibrators";

	  public const string PARAM_COFIG_FILE = "param.conf";

	  public const string TREG_COFIG_FILE = "t.reg";

	  public const string C2X_COFIG_FILE = "C2x.cal";

	  public const string CORR_COFIG_FILE = "corr.cal";

	  public const string WL_CORR_COFIG_FILE = "wl_corr.cal";

	  public const string WAVE_LENGTH_COFIG_FILE = "wavelength_corr.cal";

	  public const string CALIBRATION = "Calibration";

	  public const string REGISTERS = "Registers";

	  public static readonly string DETECTOR_AND_CURRENT_RANGE_OPTION_FILE_PATH = Original_APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "mems" + Path.DirectorySeparatorChar + "Registers" + Path.DirectorySeparatorChar + "OpticalPathSettings" + Path.DirectorySeparatorChar + "DetectorAndCurrentRange.txt";

	  public static readonly string PGA1_OPTION_FILE_PATH = Original_APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "mems" + Path.DirectorySeparatorChar + "Registers" + Path.DirectorySeparatorChar + "OpticalPathSettings" + Path.DirectorySeparatorChar + "PGA1.txt";

	  public static readonly string PGA2_OPTION_FILE_PATH = Original_APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "mems" + Path.DirectorySeparatorChar + "Registers" + Path.DirectorySeparatorChar + "OpticalPathSettings" + Path.DirectorySeparatorChar + "PGA2.txt";

	  public static readonly string ACTUATION_DIRECTION_OPTION_FILE_PATH = Original_APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "mems" + Path.DirectorySeparatorChar + "Registers" + Path.DirectorySeparatorChar + "OpenLoopSettings" + Path.DirectorySeparatorChar + "ActuationDirection.txt";

	  public static readonly string WAVEFORM_OPTION_FILE_PATH = Original_APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "mems" + Path.DirectorySeparatorChar + "Registers" + Path.DirectorySeparatorChar + "OpenLoopSettings" + Path.DirectorySeparatorChar + "Waveform.txt";

	  public static readonly string EXCITATION_VOLTAGE_OPTION_FILE_PATH = Original_APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "mems" + Path.DirectorySeparatorChar + "Registers" + Path.DirectorySeparatorChar + "CapSensingPathSettings" + Path.DirectorySeparatorChar + "ExcitationVoltage.txt";

	  public static readonly string SAMPLING_RATE_OPTION_FILE_PATH = Original_APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "mems" + Path.DirectorySeparatorChar + "Registers" + Path.DirectorySeparatorChar + "CapSensingPathSettings" + Path.DirectorySeparatorChar + "SamplingRate.txt";

	  public static readonly string C2V_GAIN_OPTION_FILE_PATH = Original_APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "mems" + Path.DirectorySeparatorChar + "Registers" + Path.DirectorySeparatorChar + "CapSensingPathSettings" + Path.DirectorySeparatorChar + "C2VGain.txt";

	  public static readonly string CLOSED_LOOP_GAIN_VS_FREQ_FILE_PATH = Original_APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "mems" + Path.DirectorySeparatorChar + "moduleSettings" + Path.DirectorySeparatorChar + "closedLoopSettings" + Path.DirectorySeparatorChar + "bpfGainVsFreq.txt";

	  public static readonly string STANDARD_CALIBRATORS_FOLDER_PATH = Original_APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "mems" + Path.DirectorySeparatorChar + "standard_calibrators";

	  public const string STANDARD_CALIBRATORS_FILE_EXT = ".txt";

	  public const string OPTICAL_PATH_SETTINGS_BLOCK = "OpticalPathSettings";

	  public const string DETECTOR_AND_CURRENT_RANGE_OPTION = "DetectorAndCurrentRange.txt";

	  public const string PGA1_OPTION = "PGA1.txt";

	  public const string PGA2_OPTION = "PGA2.txt";

	  public const string OPEN_LOOP_SETTINGS_BLOCK = "OpenLoopSettings";

	  public const string WAVEFORM_OPTION = "Waveform.txt";

	  public const string ACTUATION_DIRECTION_OPTION = "ActuationDirection.txt";

	  public const string CAP_SENSING_PATH_SETTINGS_BLOCK = "CapSensingPathSettings";

	  public const string EXCITATION_VOLTAGE_OPTION = "ExcitationVoltage.txt";

	  public const string SAMPLING_RATE_OPTION = "SamplingRate.txt";

	  public const string C2V_GAIN_OPTION = "C2VGain.txt";

	  public const string LASER_FILE = "sl";

	  public const string WL_FILE = "wl";

	  public const string METH_FILE = "mc";

	  public static readonly string CALIBRATION_FOLDER_PATH = Original_APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "Calibration";

	  public static readonly string LASER_FILE_PATH = Original_APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "Calibration" + Path.DirectorySeparatorChar + "sl";

	  public static readonly string WL_FILE_PATH = Original_APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "Calibration" + Path.DirectorySeparatorChar + "wl";

	  public static readonly string METH_FILE_PATH = Original_APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "Calibration" + Path.DirectorySeparatorChar + "mc";

	  public const string TWO_POINTS_CORR_CALIB_FOLDER_NAME = "two_points_corr";

	  public const string STANDARD_CALIBRATOR_DEFAULT_CHOISE = "Choose Material ...";

	  public static readonly int INTER_SPEC_WL_CORR = p2Enumerations.p2CorrectionType.Corrected.NumVal;

	  public const short INTER_SPEC_NORMALIZE_SPECTRUM = 0;

	  public const short INTER_SPEC_PHASE_CORRECTION = 0;

	  public const short SELF_CORRECTION_DISABLED = 0;

	  public const short SELF_CORRECTION_ENABLED = 1;

	  public const string INTER_SPEC_INTERFERO_DATA_FILE = "Interferogram";

	  public const string INTER_SPEC_SPECTRA_DATA_FILE = "Spectra";

	  public static readonly int SPEC_WL_CORR = p2Enumerations.p2CorrectionType.Corrected.NumVal;

	  public const short SPEC_NORMALIZE_SPECTRUM = 0;

	  public const short SPEC_PHASE_CORRECTION = 0;

	  public const string SPEC_SPECTRUM_DATA_FILE = "Spectrum";

	  public static readonly int BG_SPEC_WL_CORR = p2Enumerations.p2CorrectionType.Corrected.NumVal;

	  public const short BG_SPEC_NORMALIZE_SPECTRUM = 0;

	  public const short BG_SPEC_PHASE_CORRECTION = 0;

	  public static readonly int CALIB_WL_CORR = p2Enumerations.p2CorrectionType.Corrected.NumVal;

	  public const int OPTICAL_PATH_DIFFERENCE_INDEX = 0;

	  public const int I_INDEX = 1;

	  public const int WAVENUMBER_INDEX = 2;

	  public const int POWER_SPECTRAL_DENSITY_INDEX = 3;

	  public const int POWER_SPECTRAL_DENSITY_EXTENDED_INDEX = 5;

	  public const int CORR_FACTORS_INDEX = 4;

	  public const int DSP_DATA_LENGTH = 5;

	  public const int DSP_FINAL_DATA_LENGTH = 5;

	  public const int DSP_FFT_DATA_LENGTH = 4;

	  public const int DSP_CALIB_CAP_TIME_DATA_LENGTH = 7;

	  public const int DSP_CALIB_DELAY_COMP_DATA_LENGTH = 3;

	  public const int DSP_CALIB_DATA_LENGTH = 7;

	  public const int DSP_CAP_CURRENT_DATA_LENGTH = 12;

	  public const int DSP_WL_CORR_LENGTH = 10;

	  public const int DSP_DISPLAY_DATA_LENGTH = 4;

	  public const int DSP_SNR_DATA_LENGTH = 17;

	  public const int DSP_STABILITY_DATA_LENGTH = 8;

	  public const string DEFAULT_REG_FILE_FOLDER = "TAIFReg";

	  public const int REG_FILE_COUNT = 89;

	  public static double MAX_RUNTIME_MS = 10000.0D;

	  public const int MIN_RUNTIMR_MS = 10;

	  public const int MAX_NO_OF_SLICES_1000 = 16384000;

	  public static readonly int MAX_INT_THRESHOLD_CALIBRATION = (int)Math.Pow(2.0D, 11.0D);

	  public const int DMUX_MODE_CAPLPF = 15;

	  public const int DMUX_MODE_AMP = 23;

	  public const int DMUX_MODE_AACOUT = 27;

	  public const int MAX_NO_OF_PROFILES_ON_ROM = 8;

	  public const int MAX_LSB_WINDOW_CALIBRATION = 72000;

	  public const int TEMPERATURE_WINDOW = 20;

	  public const double MAX_TEMP_LSB = 1.34217727E8D;

	  public static readonly string[] apodizationOptions = new string[] {"Rectangular", "Tukey .25"};

	  public const int apodizationDefaultIndex = 0;

	  public static readonly string[] paddingOptions = new string[] {"0", "1", "3", "7"};

	  public const int paddingDefaultIndex = 1;

	  public const int SUB_PANELS_DIMENTION = 300;

	  public const int MAX_WIDTH_OF_FIELD = 110;

	  public const int PARAM_CONF_INDEX_interpolationThreshold = 1;

	  public const int PARAM_CONF_INDEX_I_adc_gain = 9;

	  public const int PARAM_CONF_INDEX_act_freq = 11;

	  public const int PARAM_CONF_INDEX_time_initialdly = 12;

	  public const int PARAM_CONF_INDEX_xinterp_lim_min = 14;

	  public const int PARAM_CONF_INDEX_xinterp_lim_max = 15;

	  public const int PARAM_CONF_INDEX_NPs_interp = 17;

	  public const int PARAM_CONF_INDEX_closedLoop = 47;

	  public const int PARAM_CONF_INDEX_KiStartUpFactor = 48;

	  public const int PARAM_CONF_INDEX_OpticalGainMargin = 49;

	  public const int PARAM_CONF_INDEX_LambdaMin = 23;

	  public const int PARAM_CONF_INDEX_LambdaMax = 24;

	  public const int PARAM_CONF_INDEX_CUSTOMER_CORR_SELECT = 56;

	  public const int PARAM_CONF_INDEX_Apodization = 19;

	  public const int PARAM_CONF_INDEX_ZeroPadding = 22;

	  public const int PARAM_CONF_INDEX_saturationThr = 44;

	  public const int PARAM_CONF_INDEX_Wavenumber_Corr_select = 54;

	  public const int PARAM_CONF_INDEX_COMMON_WAVENUMBER_EN = 57;

	  public const int PARAM_CONF_INDEX_WAVENUMBER_VECTOR_LENGTH = 55;

	  public const double adaptiveGainRunTime = 10.0D;

	  public const double adaptiveGain_OPT_ADC_REF = 1.35D;

	  public const double adaptiveGain_OPT_ADC_FULL_SCALE = 512.0D;

	  public static readonly string[] currentRanges = new string[] {"Detector1->1uA", "Detector1->2.5uA", "Detector1->5uA", "Detector1->10uA", "Detector1->20uA", "Detector1->40uA", "Detector1->80uA"};

	  public static readonly int[] PGA1_values = new int[] {1, 2, 4, 6, 8, 10};

	  public static readonly int[] PGA2_values = new int[] {1, 2, 4, 6, 8, 10};

	  public const string InterSpecPrefix = "_InterSpec_";

	  public const string SpecPrefix = "_Spec_";

	  public const int OPEN_LOOP_SAMPLE_FOLDERS_VERSION = 0;

	  public const int CLOSED_LOOP_SAMPLE_FOLDERS_VERSION = 0;

	  public const int UNKNOWN_SAMPLE_FOLDERS_VERSION = 0;

	  public const int ADAPTIVE_GAIN_SAMPLE_FOLDERS_VERSION = 1;

	  public const int RESTORE_DEFAULT_SAMPLE_FOLDERS_VERSION = 2;

	  public const int FALLING_NEGATIVE_DIRECTION = 0;

	  public const int RISING_POSITIVE_DIRECTION = 1;

	  public const string SDK_VERSION_NO = "4.3";

	  public static string getPath(string paramString)
	  {
		  return paramString.Replace(Original_APPLICATION_WORKING_DIRECTORY, APPLICATION_WORKING_DIRECTORY);
	  }
	}


	/* Location:              D:\jobs\BalitTanah.SoilSensingKit\Decompile Driver\SDK v4.3\SDKv4.3\bin_win_x64\p2AppManager.jar!\sws\p2AppManage\\utils\p2Constants.class
	 * Java compiler version: 7 (51.0)
	 * JD-Core Version:       1.0.7
	 */
}