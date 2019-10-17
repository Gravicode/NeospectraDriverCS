using System.Collections.Generic;

namespace sws.p2AppManager.utils
{
	public class p2Enumerations
	{
	  public sealed class p2AppManagerStatus
	  {
		public static readonly p2AppManagerStatus NO_ERROR = new p2AppManagerStatus("NO_ERROR", InnerEnum.NO_ERROR, 0);
		public static readonly p2AppManagerStatus DEVICE_BUSY_ERROR = new p2AppManagerStatus("DEVICE_BUSY_ERROR", InnerEnum.DEVICE_BUSY_ERROR, 1);
		public static readonly p2AppManagerStatus BOARD_DISTCONNECTED_ERROR = new p2AppManagerStatus("BOARD_DISTCONNECTED_ERROR", InnerEnum.BOARD_DISTCONNECTED_ERROR, 2);
		public static readonly p2AppManagerStatus BOARD_NOT_INITIALIZED_ERROR = new p2AppManagerStatus("BOARD_NOT_INITIALIZED_ERROR", InnerEnum.BOARD_NOT_INITIALIZED_ERROR, 3);
		public static readonly p2AppManagerStatus UNKNOWN_ERROR = new p2AppManagerStatus("UNKNOWN_ERROR", InnerEnum.UNKNOWN_ERROR, 4);
		public static readonly p2AppManagerStatus CONFIG_FILES_LOADING_ERROR = new p2AppManagerStatus("CONFIG_FILES_LOADING_ERROR", InnerEnum.CONFIG_FILES_LOADING_ERROR, 7);
		public static readonly p2AppManagerStatus CONFIG_PARAM_LENGTH_ERROR = new p2AppManagerStatus("CONFIG_PARAM_LENGTH_ERROR", InnerEnum.CONFIG_PARAM_LENGTH_ERROR, 8);
		public static readonly p2AppManagerStatus INVALID_RUN_TIME_ERROR = new p2AppManagerStatus("INVALID_RUN_TIME_ERROR", InnerEnum.INVALID_RUN_TIME_ERROR, 11);
		public static readonly p2AppManagerStatus CAP_FILE_CREATION_ERROR = new p2AppManagerStatus("CAP_FILE_CREATION_ERROR", InnerEnum.CAP_FILE_CREATION_ERROR, 12);
		public static readonly p2AppManagerStatus CURRENT_FILE_CREATION_ERROR = new p2AppManagerStatus("CURRENT_FILE_CREATION_ERROR", InnerEnum.CURRENT_FILE_CREATION_ERROR, 13);
		public static readonly p2AppManagerStatus ACT_FILE_CREATION_ERROR = new p2AppManagerStatus("ACT_FILE_CREATION_ERROR", InnerEnum.ACT_FILE_CREATION_ERROR, 14);
		public static readonly p2AppManagerStatus NO_SAMPLE_CONFIG_FOLDERS_ERROR = new p2AppManagerStatus("NO_SAMPLE_CONFIG_FOLDERS_ERROR", InnerEnum.NO_SAMPLE_CONFIG_FOLDERS_ERROR, 15);
		public static readonly p2AppManagerStatus NO_VALID_SAMPLE_CONFIG_FOLDERS_ERROR = new p2AppManagerStatus("NO_VALID_SAMPLE_CONFIG_FOLDERS_ERROR", InnerEnum.NO_VALID_SAMPLE_CONFIG_FOLDERS_ERROR, 16);
		public static readonly p2AppManagerStatus NO_SAMPLE_PROFILE_SELECTED_ERROR = new p2AppManagerStatus("NO_SAMPLE_PROFILE_SELECTED_ERROR", InnerEnum.NO_SAMPLE_PROFILE_SELECTED_ERROR, 17);
		public static readonly p2AppManagerStatus INAVLID_REG_FILE_FORMAT_ERROR = new p2AppManagerStatus("INAVLID_REG_FILE_FORMAT_ERROR", InnerEnum.INAVLID_REG_FILE_FORMAT_ERROR, 23);
		public static readonly p2AppManagerStatus NO_OF_SCANS_DSP_ERROR = new p2AppManagerStatus("NO_OF_SCANS_DSP_ERROR", InnerEnum.NO_OF_SCANS_DSP_ERROR, 24);
		public static readonly p2AppManagerStatus DSP_INTERFEROGRAM_POST_PROCESSING_ERROR = new p2AppManagerStatus("DSP_INTERFEROGRAM_POST_PROCESSING_ERROR", InnerEnum.DSP_INTERFEROGRAM_POST_PROCESSING_ERROR, 25);
		public static readonly p2AppManagerStatus DSP_INTERFEROGRAM_POST_EMPTY_DATA_ERROR = new p2AppManagerStatus("DSP_INTERFEROGRAM_POST_EMPTY_DATA_ERROR", InnerEnum.DSP_INTERFEROGRAM_POST_EMPTY_DATA_ERROR, 26);
		public static readonly p2AppManagerStatus DSP_INTERFEROGRAM_POST_BAD_DATA_ERROR = new p2AppManagerStatus("DSP_INTERFEROGRAM_POST_BAD_DATA_ERROR", InnerEnum.DSP_INTERFEROGRAM_POST_BAD_DATA_ERROR, 27);
		public static readonly p2AppManagerStatus UPDATE_CORR_FILE_ERROR = new p2AppManagerStatus("UPDATE_CORR_FILE_ERROR", InnerEnum.UPDATE_CORR_FILE_ERROR, 28);
		public static readonly p2AppManagerStatus WHITE_LIGHT_PROCESSING_ERROR = new p2AppManagerStatus("WHITE_LIGHT_PROCESSING_ERROR", InnerEnum.WHITE_LIGHT_PROCESSING_ERROR, 29);
		public static readonly p2AppManagerStatus DSP_INTERFEROGRAM_FFT_POST_PROCESSINF_ERROR = new p2AppManagerStatus("DSP_INTERFEROGRAM_FFT_POST_PROCESSINF_ERROR", InnerEnum.DSP_INTERFEROGRAM_FFT_POST_PROCESSINF_ERROR, 30);
		public static readonly p2AppManagerStatus INVALID_RUN_PARAMETERS_ERROR = new p2AppManagerStatus("INVALID_RUN_PARAMETERS_ERROR", InnerEnum.INVALID_RUN_PARAMETERS_ERROR, 31);
		public static readonly p2AppManagerStatus INVALID_RUN_TIME_NOT_EQUAL_BG_RUN_TIME_ERROR = new p2AppManagerStatus("INVALID_RUN_TIME_NOT_EQUAL_BG_RUN_TIME_ERROR", InnerEnum.INVALID_RUN_TIME_NOT_EQUAL_BG_RUN_TIME_ERROR, 32);
		public static readonly p2AppManagerStatus NO_VALID_BG_DATA_ERROR = new p2AppManagerStatus("NO_VALID_BG_DATA_ERROR", InnerEnum.NO_VALID_BG_DATA_ERROR, 33);
		public static readonly p2AppManagerStatus INTERFERO_FILE_CREATION_ERROR = new p2AppManagerStatus("INTERFERO_FILE_CREATION_ERROR", InnerEnum.INTERFERO_FILE_CREATION_ERROR, 34);
		public static readonly p2AppManagerStatus PSD_FILE_CREATION_ERROR = new p2AppManagerStatus("PSD_FILE_CREATION_ERROR", InnerEnum.PSD_FILE_CREATION_ERROR, 35);
		public static readonly p2AppManagerStatus SPECTRUM_FILE_CREATION_ERROR = new p2AppManagerStatus("SPECTRUM_FILE_CREATION_ERROR", InnerEnum.SPECTRUM_FILE_CREATION_ERROR, 36);
		public static readonly p2AppManagerStatus GRAPHS_FOLDER_CREATION_ERROR = new p2AppManagerStatus("GRAPHS_FOLDER_CREATION_ERROR", InnerEnum.GRAPHS_FOLDER_CREATION_ERROR, 37);
		public static readonly p2AppManagerStatus INITIATE_TAIFDRIVER_ERROR = new p2AppManagerStatus("INITIATE_TAIFDRIVER_ERROR", InnerEnum.INITIATE_TAIFDRIVER_ERROR, 42);
		public static readonly p2AppManagerStatus INVALID_BOARD_CONFIGURATION_ERROR = new p2AppManagerStatus("INVALID_BOARD_CONFIGURATION_ERROR", InnerEnum.INVALID_BOARD_CONFIGURATION_ERROR, 43);
		public static readonly p2AppManagerStatus DATA_STREAMING_TAIF_ERROR = new p2AppManagerStatus("DATA_STREAMING_TAIF_ERROR", InnerEnum.DATA_STREAMING_TAIF_ERROR, 50);
		public static readonly p2AppManagerStatus DATA_STREAMING_ERROR = new p2AppManagerStatus("DATA_STREAMING_ERROR", InnerEnum.DATA_STREAMING_ERROR, 51);
		public static readonly p2AppManagerStatus INVALID_NOTIFICATION_ERROR = new p2AppManagerStatus("INVALID_NOTIFICATION_ERROR", InnerEnum.INVALID_NOTIFICATION_ERROR, 52);
		public static readonly p2AppManagerStatus INVALID_ACTION_ERROR = new p2AppManagerStatus("INVALID_ACTION_ERROR", InnerEnum.INVALID_ACTION_ERROR, 53);
		public static readonly p2AppManagerStatus INVALID_DEVICE_ERROR = new p2AppManagerStatus("INVALID_DEVICE_ERROR", InnerEnum.INVALID_DEVICE_ERROR, 54);
		public static readonly p2AppManagerStatus THREADING_ERROR = new p2AppManagerStatus("THREADING_ERROR", InnerEnum.THREADING_ERROR, 55);
		public static readonly p2AppManagerStatus BOARD_ALREADY_INITIALIZED = new p2AppManagerStatus("BOARD_ALREADY_INITIALIZED", InnerEnum.BOARD_ALREADY_INITIALIZED, 56);
		public static readonly p2AppManagerStatus INITIALIZATION_IN_PROGRESS = new p2AppManagerStatus("INITIALIZATION_IN_PROGRESS", InnerEnum.INITIALIZATION_IN_PROGRESS, 57);
		public static readonly p2AppManagerStatus SW_DOESNOT_SUPPORT_THIS_FEATURE = new p2AppManagerStatus("SW_DOESNOT_SUPPORT_THIS_FEATURE", InnerEnum.SW_DOESNOT_SUPPORT_THIS_FEATURE, 58);
		public static readonly p2AppManagerStatus ACTUATION_SETTING_ERROR = new p2AppManagerStatus("ACTUATION_SETTING_ERROR", InnerEnum.ACTUATION_SETTING_ERROR, 60);
		public static readonly p2AppManagerStatus DEVICE_IS_TURNED_OFF_ERROR = new p2AppManagerStatus("DEVICE_IS_TURNED_OFF_ERROR", InnerEnum.DEVICE_IS_TURNED_OFF_ERROR, 61);
		public static readonly p2AppManagerStatus ASIC_REGISTER_WRITING_ERROR = new p2AppManagerStatus("ASIC_REGISTER_WRITING_ERROR", InnerEnum.ASIC_REGISTER_WRITING_ERROR, 62);
		public static readonly p2AppManagerStatus CALIBRATION_FOLDER_GEN_ERROR = new p2AppManagerStatus("CALIBRATION_FOLDER_GEN_ERROR", InnerEnum.CALIBRATION_FOLDER_GEN_ERROR, 63);
		public static readonly p2AppManagerStatus DATA_FILES_SAVING_ERROR = new p2AppManagerStatus("DATA_FILES_SAVING_ERROR", InnerEnum.DATA_FILES_SAVING_ERROR, 67);
		public static readonly p2AppManagerStatus DSP_CALIB_CAP_TIME_POST_PROCESSING_ERROR = new p2AppManagerStatus("DSP_CALIB_CAP_TIME_POST_PROCESSING_ERROR", InnerEnum.DSP_CALIB_CAP_TIME_POST_PROCESSING_ERROR, 68);
		public static readonly p2AppManagerStatus DSP_CALIB_CAP_TIME_POST_EMPTY_DATA_ERROR = new p2AppManagerStatus("DSP_CALIB_CAP_TIME_POST_EMPTY_DATA_ERROR", InnerEnum.DSP_CALIB_CAP_TIME_POST_EMPTY_DATA_ERROR, 69);
		public static readonly p2AppManagerStatus DSP_CALIB_CAP_TIME_POST_BAD_DATA_ERROR = new p2AppManagerStatus("DSP_CALIB_CAP_TIME_POST_BAD_DATA_ERROR", InnerEnum.DSP_CALIB_CAP_TIME_POST_BAD_DATA_ERROR, 70);
		public static readonly p2AppManagerStatus DSP_CALIB_DELAY_COMP_POST_PROCESSING_ERROR = new p2AppManagerStatus("DSP_CALIB_DELAY_COMP_POST_PROCESSING_ERROR", InnerEnum.DSP_CALIB_DELAY_COMP_POST_PROCESSING_ERROR, 71);
		public static readonly p2AppManagerStatus DSP_CALIB_DELAY_COMP_POST_EMPTY_DATA_ERROR = new p2AppManagerStatus("DSP_CALIB_DELAY_COMP_POST_EMPTY_DATA_ERROR", InnerEnum.DSP_CALIB_DELAY_COMP_POST_EMPTY_DATA_ERROR, 72);
		public static readonly p2AppManagerStatus DSP_CALIB_DELAY_COMP_POST_BAD_DATA_ERROR = new p2AppManagerStatus("DSP_CALIB_DELAY_COMP_POST_BAD_DATA_ERROR", InnerEnum.DSP_CALIB_DELAY_COMP_POST_BAD_DATA_ERROR, 73);
		public static readonly p2AppManagerStatus PARAM_CONF_NOT_EXIST_ERROR = new p2AppManagerStatus("PARAM_CONF_NOT_EXIST_ERROR", InnerEnum.PARAM_CONF_NOT_EXIST_ERROR, 74);
		public static readonly p2AppManagerStatus LASER_FILE_NOT_EXIST_ERROR = new p2AppManagerStatus("LASER_FILE_NOT_EXIST_ERROR", InnerEnum.LASER_FILE_NOT_EXIST_ERROR, 75);
		public static readonly p2AppManagerStatus WHITE_FILE_NOT_EXIST_ERROR = new p2AppManagerStatus("WHITE_FILE_NOT_EXIST_ERROR", InnerEnum.WHITE_FILE_NOT_EXIST_ERROR, 76);
		public static readonly p2AppManagerStatus METH_FILE_NOT_EXIST_ERROR = new p2AppManagerStatus("METH_FILE_NOT_EXIST_ERROR", InnerEnum.METH_FILE_NOT_EXIST_ERROR, 77);
		public static readonly p2AppManagerStatus CALIBRATION_GENERATION_ERROR = new p2AppManagerStatus("CALIBRATION_GENERATION_ERROR", InnerEnum.CALIBRATION_GENERATION_ERROR, 78);
		public static readonly p2AppManagerStatus DSP_CAP_CURRENT_POST_PROCESSING_ERROR = new p2AppManagerStatus("DSP_CAP_CURRENT_POST_PROCESSING_ERROR", InnerEnum.DSP_CAP_CURRENT_POST_PROCESSING_ERROR, 79);
		public static readonly p2AppManagerStatus DSP_CAP_CURRENT_POST_EMPTY_DATA_ERROR = new p2AppManagerStatus("DSP_CAP_CURRENT_POST_EMPTY_DATA_ERROR", InnerEnum.DSP_CAP_CURRENT_POST_EMPTY_DATA_ERROR, 80);
		public static readonly p2AppManagerStatus DSP_CAP_CURRENT_POST_BAD_DATA_ERROR = new p2AppManagerStatus("DSP_CAP_CURRENT_POST_BAD_DATA_ERROR", InnerEnum.DSP_CAP_CURRENT_POST_BAD_DATA_ERROR, 81);
		public static readonly p2AppManagerStatus SAMPLE_ID_INVALID_ERROR = new p2AppManagerStatus("SAMPLE_ID_INVALID_ERROR", InnerEnum.SAMPLE_ID_INVALID_ERROR, 82);
		public static readonly p2AppManagerStatus SAMPLE_FOLDERS_NUMBER_ERROR = new p2AppManagerStatus("SAMPLE_FOLDERS_NUMBER_ERROR", InnerEnum.SAMPLE_FOLDERS_NUMBER_ERROR, 83);
		public static readonly p2AppManagerStatus LENGTH_OF_FILE_NAME_ERROR = new p2AppManagerStatus("LENGTH_OF_FILE_NAME_ERROR", InnerEnum.LENGTH_OF_FILE_NAME_ERROR, 84);
		public static readonly p2AppManagerStatus INVALID_FILE_NAME_ERROR = new p2AppManagerStatus("INVALID_FILE_NAME_ERROR", InnerEnum.INVALID_FILE_NAME_ERROR, 85);
		public static readonly p2AppManagerStatus INVALID_NO_OF_FILES_ERROR = new p2AppManagerStatus("INVALID_NO_OF_FILES_ERROR", InnerEnum.INVALID_NO_OF_FILES_ERROR, 86);
		public static readonly p2AppManagerStatus LENGTH_OF_FOLDER_NAME_ERROR = new p2AppManagerStatus("LENGTH_OF_FOLDER_NAME_ERROR", InnerEnum.LENGTH_OF_FOLDER_NAME_ERROR, 87);
		public static readonly p2AppManagerStatus INVALID_FOLDER_NAME_ERROR = new p2AppManagerStatus("INVALID_FOLDER_NAME_ERROR", InnerEnum.INVALID_FOLDER_NAME_ERROR, 88);
		public static readonly p2AppManagerStatus TYPE_OF_FILE_ERROR = new p2AppManagerStatus("TYPE_OF_FILE_ERROR", InnerEnum.TYPE_OF_FILE_ERROR, 89);
		public static readonly p2AppManagerStatus INVALID_FILE_LENGTH_ERROR = new p2AppManagerStatus("INVALID_FILE_LENGTH_ERROR", InnerEnum.INVALID_FILE_LENGTH_ERROR, 90);
		public static readonly p2AppManagerStatus INVALID_FILE_DATA_ERROR = new p2AppManagerStatus("INVALID_FILE_DATA_ERROR", InnerEnum.INVALID_FILE_DATA_ERROR, 91);
		public static readonly p2AppManagerStatus READING_PROFILES_FROM_ROM_ERROR = new p2AppManagerStatus("READING_PROFILES_FROM_ROM_ERROR", InnerEnum.READING_PROFILES_FROM_ROM_ERROR, 92);
		public static readonly p2AppManagerStatus WRITING_PROFILES_TO_ROM_ERROR = new p2AppManagerStatus("WRITING_PROFILES_TO_ROM_ERROR", InnerEnum.WRITING_PROFILES_TO_ROM_ERROR, 93);
		public static readonly p2AppManagerStatus BURNING_SAMPLE_ID_ERROR = new p2AppManagerStatus("BURNING_SAMPLE_ID_ERROR", InnerEnum.BURNING_SAMPLE_ID_ERROR, 94);
		public static readonly p2AppManagerStatus READING_ASIC_REGISTERS_ERROR = new p2AppManagerStatus("READING_ASIC_REGISTERS_ERROR", InnerEnum.READING_ASIC_REGISTERS_ERROR, 95);
		public static readonly p2AppManagerStatus WRITING_ASIC_REGISTERS_ERROR = new p2AppManagerStatus("WRITING_ASIC_REGISTERS_ERROR", InnerEnum.WRITING_ASIC_REGISTERS_ERROR, 96);
		public static readonly p2AppManagerStatus READING_TEMP_ERROR = new p2AppManagerStatus("READING_TEMP_ERROR", InnerEnum.READING_TEMP_ERROR, 97);
		public static readonly p2AppManagerStatus TEMP_FOLDERS_ERROR = new p2AppManagerStatus("TEMP_FOLDERS_ERROR", InnerEnum.TEMP_FOLDERS_ERROR, 98);
		public static readonly p2AppManagerStatus OPTIONS_FOLDERS_ERROR = new p2AppManagerStatus("OPTIONS_FOLDERS_ERROR", InnerEnum.OPTIONS_FOLDERS_ERROR, 99);
		public static readonly p2AppManagerStatus INTERPOLATION_THRESHOLD_ERROR = new p2AppManagerStatus("INTERPOLATION_THRESHOLD_ERROR", InnerEnum.INTERPOLATION_THRESHOLD_ERROR, 100);
		public static readonly p2AppManagerStatus DELAY_COMP_MAX_COUNT_ERROR = new p2AppManagerStatus("DELAY_COMP_MAX_COUNT_ERROR", InnerEnum.DELAY_COMP_MAX_COUNT_ERROR, 101);
		public static readonly p2AppManagerStatus DSP_MEMS_RESPONSE_POST_PROCESSING_ERROR = new p2AppManagerStatus("DSP_MEMS_RESPONSE_POST_PROCESSING_ERROR", InnerEnum.DSP_MEMS_RESPONSE_POST_PROCESSING_ERROR, 102);
		public static readonly p2AppManagerStatus DSP_PARAMETERS_CALC_RES_FREQ_QUALITY_FACTOR_POST_PROCESSING_ERROR = new p2AppManagerStatus("DSP_PARAMETERS_CALC_RES_FREQ_QUALITY_FACTOR_POST_PROCESSING_ERROR", InnerEnum.DSP_PARAMETERS_CALC_RES_FREQ_QUALITY_FACTOR_POST_PROCESSING_ERROR, 103);
		public static readonly p2AppManagerStatus DSP_PARAMETERS_CALC_FORWARD_GAIN_POST_PROCESSING_ERROR = new p2AppManagerStatus("DSP_PARAMETERS_CALC_FORWARD_GAIN_POST_PROCESSING_ERROR", InnerEnum.DSP_PARAMETERS_CALC_FORWARD_GAIN_POST_PROCESSING_ERROR, 104);
		public static readonly p2AppManagerStatus DSP_COEFFICIENTS_CALC_POST_PROCESSING_ERROR = new p2AppManagerStatus("DSP_COEFFICIENTS_CALC_POST_PROCESSING_ERROR", InnerEnum.DSP_COEFFICIENTS_CALC_POST_PROCESSING_ERROR, 105);
		public static readonly p2AppManagerStatus DSP_PHASE_VALIDATION_POST_PROCESSING_ERROR = new p2AppManagerStatus("DSP_PHASE_VALIDATION_POST_PROCESSING_ERROR", InnerEnum.DSP_PHASE_VALIDATION_POST_PROCESSING_ERROR, 106);
		public static readonly p2AppManagerStatus DSP_STABILITY_CHECK_POST_PROCESSING_ERROR = new p2AppManagerStatus("DSP_STABILITY_CHECK_POST_PROCESSING_ERROR", InnerEnum.DSP_STABILITY_CHECK_POST_PROCESSING_ERROR, 107);
		public static readonly p2AppManagerStatus DSP_GAIN_MARGIN_CALC_POST_PROCESSING_ERROR = new p2AppManagerStatus("DSP_GAIN_MARGIN_CALC_POST_PROCESSING_ERROR", InnerEnum.DSP_GAIN_MARGIN_CALC_POST_PROCESSING_ERROR, 108);
		public static readonly p2AppManagerStatus CLOSED_LOOP_FILE_CREATION_ERROR = new p2AppManagerStatus("CLOSED_LOOP_FILE_CREATION_ERROR", InnerEnum.CLOSED_LOOP_FILE_CREATION_ERROR, 109);
		public static readonly p2AppManagerStatus FAILED_IN_ADAPTIVE_GAIN = new p2AppManagerStatus("FAILED_IN_ADAPTIVE_GAIN", InnerEnum.FAILED_IN_ADAPTIVE_GAIN, 110);
		public static readonly p2AppManagerStatus ASIC_REGISTER_READING_ERROR = new p2AppManagerStatus("ASIC_REGISTER_READING_ERROR", InnerEnum.ASIC_REGISTER_READING_ERROR, 111);
		public static readonly p2AppManagerStatus TWO_POINTS_CORR_CALIB_FOLDER_ERROR = new p2AppManagerStatus("TWO_POINTS_CORR_CALIB_FOLDER_ERROR", InnerEnum.TWO_POINTS_CORR_CALIB_FOLDER_ERROR, 112);
		public static readonly p2AppManagerStatus FAILED_TO_WRITE_OPTICAL_OPTION_TO_FILE = new p2AppManagerStatus("FAILED_TO_WRITE_OPTICAL_OPTION_TO_FILE", InnerEnum.FAILED_TO_WRITE_OPTICAL_OPTION_TO_FILE, 113);
		public static readonly p2AppManagerStatus FAILED_TO_CREATE_OPTICAL_SETTINGS_FILE = new p2AppManagerStatus("FAILED_TO_CREATE_OPTICAL_SETTINGS_FILE", InnerEnum.FAILED_TO_CREATE_OPTICAL_SETTINGS_FILE, 114);
		public static readonly p2AppManagerStatus STANDARD_CALIBRATOR_FILE_NOT_EXIST_ERROR = new p2AppManagerStatus("STANDARD_CALIBRATOR_FILE_NOT_EXIST_ERROR", InnerEnum.STANDARD_CALIBRATOR_FILE_NOT_EXIST_ERROR, 115);
		public static readonly p2AppManagerStatus WAVELENGTH_CALIBRATION_ERROR = new p2AppManagerStatus("WAVELENGTH_CALIBRATION_ERROR", InnerEnum.WAVELENGTH_CALIBRATION_ERROR, 116);
		public static readonly p2AppManagerStatus NO_VALID_OLD_MEASUREMENT_ERROR = new p2AppManagerStatus("NO_VALID_OLD_MEASUREMENT_ERROR", InnerEnum.NO_VALID_OLD_MEASUREMENT_ERROR, 117);
		public static readonly p2AppManagerStatus DSP_UPDATE_FFT_SETTINGS_ERROR = new p2AppManagerStatus("DSP_UPDATE_FFT_SETTINGS_ERROR", InnerEnum.DSP_UPDATE_FFT_SETTINGS_ERROR, 118);
		public static readonly p2AppManagerStatus GAIN_OPTIONS_ERROR = new p2AppManagerStatus("GAIN_OPTIONS_ERROR", InnerEnum.GAIN_OPTIONS_ERROR, 119);
		public static readonly p2AppManagerStatus DSP_COMMON_WAVENUMBER_GENERATION_ERROR = new p2AppManagerStatus("DSP_COMMON_WAVENUMBER_GENERATION_ERROR", InnerEnum.DSP_COMMON_WAVENUMBER_GENERATION_ERROR, 120);

		private static readonly IList<p2AppManagerStatus> valueList = new List<p2AppManagerStatus>();

		static p2AppManagerStatus()
		{
			valueList.Add(NO_ERROR);
			valueList.Add(DEVICE_BUSY_ERROR);
			valueList.Add(BOARD_DISTCONNECTED_ERROR);
			valueList.Add(BOARD_NOT_INITIALIZED_ERROR);
			valueList.Add(UNKNOWN_ERROR);
			valueList.Add(CONFIG_FILES_LOADING_ERROR);
			valueList.Add(CONFIG_PARAM_LENGTH_ERROR);
			valueList.Add(INVALID_RUN_TIME_ERROR);
			valueList.Add(CAP_FILE_CREATION_ERROR);
			valueList.Add(CURRENT_FILE_CREATION_ERROR);
			valueList.Add(ACT_FILE_CREATION_ERROR);
			valueList.Add(NO_SAMPLE_CONFIG_FOLDERS_ERROR);
			valueList.Add(NO_VALID_SAMPLE_CONFIG_FOLDERS_ERROR);
			valueList.Add(NO_SAMPLE_PROFILE_SELECTED_ERROR);
			valueList.Add(INAVLID_REG_FILE_FORMAT_ERROR);
			valueList.Add(NO_OF_SCANS_DSP_ERROR);
			valueList.Add(DSP_INTERFEROGRAM_POST_PROCESSING_ERROR);
			valueList.Add(DSP_INTERFEROGRAM_POST_EMPTY_DATA_ERROR);
			valueList.Add(DSP_INTERFEROGRAM_POST_BAD_DATA_ERROR);
			valueList.Add(UPDATE_CORR_FILE_ERROR);
			valueList.Add(WHITE_LIGHT_PROCESSING_ERROR);
			valueList.Add(DSP_INTERFEROGRAM_FFT_POST_PROCESSINF_ERROR);
			valueList.Add(INVALID_RUN_PARAMETERS_ERROR);
			valueList.Add(INVALID_RUN_TIME_NOT_EQUAL_BG_RUN_TIME_ERROR);
			valueList.Add(NO_VALID_BG_DATA_ERROR);
			valueList.Add(INTERFERO_FILE_CREATION_ERROR);
			valueList.Add(PSD_FILE_CREATION_ERROR);
			valueList.Add(SPECTRUM_FILE_CREATION_ERROR);
			valueList.Add(GRAPHS_FOLDER_CREATION_ERROR);
			valueList.Add(INITIATE_TAIFDRIVER_ERROR);
			valueList.Add(INVALID_BOARD_CONFIGURATION_ERROR);
			valueList.Add(DATA_STREAMING_TAIF_ERROR);
			valueList.Add(DATA_STREAMING_ERROR);
			valueList.Add(INVALID_NOTIFICATION_ERROR);
			valueList.Add(INVALID_ACTION_ERROR);
			valueList.Add(INVALID_DEVICE_ERROR);
			valueList.Add(THREADING_ERROR);
			valueList.Add(BOARD_ALREADY_INITIALIZED);
			valueList.Add(INITIALIZATION_IN_PROGRESS);
			valueList.Add(SW_DOESNOT_SUPPORT_THIS_FEATURE);
			valueList.Add(ACTUATION_SETTING_ERROR);
			valueList.Add(DEVICE_IS_TURNED_OFF_ERROR);
			valueList.Add(ASIC_REGISTER_WRITING_ERROR);
			valueList.Add(CALIBRATION_FOLDER_GEN_ERROR);
			valueList.Add(DATA_FILES_SAVING_ERROR);
			valueList.Add(DSP_CALIB_CAP_TIME_POST_PROCESSING_ERROR);
			valueList.Add(DSP_CALIB_CAP_TIME_POST_EMPTY_DATA_ERROR);
			valueList.Add(DSP_CALIB_CAP_TIME_POST_BAD_DATA_ERROR);
			valueList.Add(DSP_CALIB_DELAY_COMP_POST_PROCESSING_ERROR);
			valueList.Add(DSP_CALIB_DELAY_COMP_POST_EMPTY_DATA_ERROR);
			valueList.Add(DSP_CALIB_DELAY_COMP_POST_BAD_DATA_ERROR);
			valueList.Add(PARAM_CONF_NOT_EXIST_ERROR);
			valueList.Add(LASER_FILE_NOT_EXIST_ERROR);
			valueList.Add(WHITE_FILE_NOT_EXIST_ERROR);
			valueList.Add(METH_FILE_NOT_EXIST_ERROR);
			valueList.Add(CALIBRATION_GENERATION_ERROR);
			valueList.Add(DSP_CAP_CURRENT_POST_PROCESSING_ERROR);
			valueList.Add(DSP_CAP_CURRENT_POST_EMPTY_DATA_ERROR);
			valueList.Add(DSP_CAP_CURRENT_POST_BAD_DATA_ERROR);
			valueList.Add(SAMPLE_ID_INVALID_ERROR);
			valueList.Add(SAMPLE_FOLDERS_NUMBER_ERROR);
			valueList.Add(LENGTH_OF_FILE_NAME_ERROR);
			valueList.Add(INVALID_FILE_NAME_ERROR);
			valueList.Add(INVALID_NO_OF_FILES_ERROR);
			valueList.Add(LENGTH_OF_FOLDER_NAME_ERROR);
			valueList.Add(INVALID_FOLDER_NAME_ERROR);
			valueList.Add(TYPE_OF_FILE_ERROR);
			valueList.Add(INVALID_FILE_LENGTH_ERROR);
			valueList.Add(INVALID_FILE_DATA_ERROR);
			valueList.Add(READING_PROFILES_FROM_ROM_ERROR);
			valueList.Add(WRITING_PROFILES_TO_ROM_ERROR);
			valueList.Add(BURNING_SAMPLE_ID_ERROR);
			valueList.Add(READING_ASIC_REGISTERS_ERROR);
			valueList.Add(WRITING_ASIC_REGISTERS_ERROR);
			valueList.Add(READING_TEMP_ERROR);
			valueList.Add(TEMP_FOLDERS_ERROR);
			valueList.Add(OPTIONS_FOLDERS_ERROR);
			valueList.Add(INTERPOLATION_THRESHOLD_ERROR);
			valueList.Add(DELAY_COMP_MAX_COUNT_ERROR);
			valueList.Add(DSP_MEMS_RESPONSE_POST_PROCESSING_ERROR);
			valueList.Add(DSP_PARAMETERS_CALC_RES_FREQ_QUALITY_FACTOR_POST_PROCESSING_ERROR);
			valueList.Add(DSP_PARAMETERS_CALC_FORWARD_GAIN_POST_PROCESSING_ERROR);
			valueList.Add(DSP_COEFFICIENTS_CALC_POST_PROCESSING_ERROR);
			valueList.Add(DSP_PHASE_VALIDATION_POST_PROCESSING_ERROR);
			valueList.Add(DSP_STABILITY_CHECK_POST_PROCESSING_ERROR);
			valueList.Add(DSP_GAIN_MARGIN_CALC_POST_PROCESSING_ERROR);
			valueList.Add(CLOSED_LOOP_FILE_CREATION_ERROR);
			valueList.Add(FAILED_IN_ADAPTIVE_GAIN);
			valueList.Add(ASIC_REGISTER_READING_ERROR);
			valueList.Add(TWO_POINTS_CORR_CALIB_FOLDER_ERROR);
			valueList.Add(FAILED_TO_WRITE_OPTICAL_OPTION_TO_FILE);
			valueList.Add(FAILED_TO_CREATE_OPTICAL_SETTINGS_FILE);
			valueList.Add(STANDARD_CALIBRATOR_FILE_NOT_EXIST_ERROR);
			valueList.Add(WAVELENGTH_CALIBRATION_ERROR);
			valueList.Add(NO_VALID_OLD_MEASUREMENT_ERROR);
			valueList.Add(DSP_UPDATE_FFT_SETTINGS_ERROR);
			valueList.Add(GAIN_OPTIONS_ERROR);
			valueList.Add(DSP_COMMON_WAVENUMBER_GENERATION_ERROR);
		}

		public enum InnerEnum
		{
			NO_ERROR,
			DEVICE_BUSY_ERROR,
			BOARD_DISTCONNECTED_ERROR,
			BOARD_NOT_INITIALIZED_ERROR,
			UNKNOWN_ERROR,
			CONFIG_FILES_LOADING_ERROR,
			CONFIG_PARAM_LENGTH_ERROR,
			INVALID_RUN_TIME_ERROR,
			CAP_FILE_CREATION_ERROR,
			CURRENT_FILE_CREATION_ERROR,
			ACT_FILE_CREATION_ERROR,
			NO_SAMPLE_CONFIG_FOLDERS_ERROR,
			NO_VALID_SAMPLE_CONFIG_FOLDERS_ERROR,
			NO_SAMPLE_PROFILE_SELECTED_ERROR,
			INAVLID_REG_FILE_FORMAT_ERROR,
			NO_OF_SCANS_DSP_ERROR,
			DSP_INTERFEROGRAM_POST_PROCESSING_ERROR,
			DSP_INTERFEROGRAM_POST_EMPTY_DATA_ERROR,
			DSP_INTERFEROGRAM_POST_BAD_DATA_ERROR,
			UPDATE_CORR_FILE_ERROR,
			WHITE_LIGHT_PROCESSING_ERROR,
			DSP_INTERFEROGRAM_FFT_POST_PROCESSINF_ERROR,
			INVALID_RUN_PARAMETERS_ERROR,
			INVALID_RUN_TIME_NOT_EQUAL_BG_RUN_TIME_ERROR,
			NO_VALID_BG_DATA_ERROR,
			INTERFERO_FILE_CREATION_ERROR,
			PSD_FILE_CREATION_ERROR,
			SPECTRUM_FILE_CREATION_ERROR,
			GRAPHS_FOLDER_CREATION_ERROR,
			INITIATE_TAIFDRIVER_ERROR,
			INVALID_BOARD_CONFIGURATION_ERROR,
			DATA_STREAMING_TAIF_ERROR,
			DATA_STREAMING_ERROR,
			INVALID_NOTIFICATION_ERROR,
			INVALID_ACTION_ERROR,
			INVALID_DEVICE_ERROR,
			THREADING_ERROR,
			BOARD_ALREADY_INITIALIZED,
			INITIALIZATION_IN_PROGRESS,
			SW_DOESNOT_SUPPORT_THIS_FEATURE,
			ACTUATION_SETTING_ERROR,
			DEVICE_IS_TURNED_OFF_ERROR,
			ASIC_REGISTER_WRITING_ERROR,
			CALIBRATION_FOLDER_GEN_ERROR,
			DATA_FILES_SAVING_ERROR,
			DSP_CALIB_CAP_TIME_POST_PROCESSING_ERROR,
			DSP_CALIB_CAP_TIME_POST_EMPTY_DATA_ERROR,
			DSP_CALIB_CAP_TIME_POST_BAD_DATA_ERROR,
			DSP_CALIB_DELAY_COMP_POST_PROCESSING_ERROR,
			DSP_CALIB_DELAY_COMP_POST_EMPTY_DATA_ERROR,
			DSP_CALIB_DELAY_COMP_POST_BAD_DATA_ERROR,
			PARAM_CONF_NOT_EXIST_ERROR,
			LASER_FILE_NOT_EXIST_ERROR,
			WHITE_FILE_NOT_EXIST_ERROR,
			METH_FILE_NOT_EXIST_ERROR,
			CALIBRATION_GENERATION_ERROR,
			DSP_CAP_CURRENT_POST_PROCESSING_ERROR,
			DSP_CAP_CURRENT_POST_EMPTY_DATA_ERROR,
			DSP_CAP_CURRENT_POST_BAD_DATA_ERROR,
			SAMPLE_ID_INVALID_ERROR,
			SAMPLE_FOLDERS_NUMBER_ERROR,
			LENGTH_OF_FILE_NAME_ERROR,
			INVALID_FILE_NAME_ERROR,
			INVALID_NO_OF_FILES_ERROR,
			LENGTH_OF_FOLDER_NAME_ERROR,
			INVALID_FOLDER_NAME_ERROR,
			TYPE_OF_FILE_ERROR,
			INVALID_FILE_LENGTH_ERROR,
			INVALID_FILE_DATA_ERROR,
			READING_PROFILES_FROM_ROM_ERROR,
			WRITING_PROFILES_TO_ROM_ERROR,
			BURNING_SAMPLE_ID_ERROR,
			READING_ASIC_REGISTERS_ERROR,
			WRITING_ASIC_REGISTERS_ERROR,
			READING_TEMP_ERROR,
			TEMP_FOLDERS_ERROR,
			OPTIONS_FOLDERS_ERROR,
			INTERPOLATION_THRESHOLD_ERROR,
			DELAY_COMP_MAX_COUNT_ERROR,
			DSP_MEMS_RESPONSE_POST_PROCESSING_ERROR,
			DSP_PARAMETERS_CALC_RES_FREQ_QUALITY_FACTOR_POST_PROCESSING_ERROR,
			DSP_PARAMETERS_CALC_FORWARD_GAIN_POST_PROCESSING_ERROR,
			DSP_COEFFICIENTS_CALC_POST_PROCESSING_ERROR,
			DSP_PHASE_VALIDATION_POST_PROCESSING_ERROR,
			DSP_STABILITY_CHECK_POST_PROCESSING_ERROR,
			DSP_GAIN_MARGIN_CALC_POST_PROCESSING_ERROR,
			CLOSED_LOOP_FILE_CREATION_ERROR,
			FAILED_IN_ADAPTIVE_GAIN,
			ASIC_REGISTER_READING_ERROR,
			TWO_POINTS_CORR_CALIB_FOLDER_ERROR,
			FAILED_TO_WRITE_OPTICAL_OPTION_TO_FILE,
			FAILED_TO_CREATE_OPTICAL_SETTINGS_FILE,
			STANDARD_CALIBRATOR_FILE_NOT_EXIST_ERROR,
			WAVELENGTH_CALIBRATION_ERROR,
			NO_VALID_OLD_MEASUREMENT_ERROR,
			DSP_UPDATE_FFT_SETTINGS_ERROR,
			GAIN_OPTIONS_ERROR,
			DSP_COMMON_WAVENUMBER_GENERATION_ERROR
		}

		public readonly InnerEnum innerEnumValue;
		private readonly string nameValue;
		private readonly int ordinalValue;
		private static int nextOrdinal = 0;

		internal readonly int a;

		internal p2AppManagerStatus(string name, InnerEnum innerEnum, int param1Int1)
		{
			this.a = param1Int1;

			nameValue = name;
			ordinalValue = nextOrdinal++;
			innerEnumValue = innerEnum;
		}

		public int NumVal
		{
			get
			{
				return this.a;
			}
		}

		public static p2AppManagerStatus getAppManagerStatusByCode(int param1Int)
		{
		  foreach (p2AppManagerStatus p2AppManagerStatus1 in values())
		  {
			if (p2AppManagerStatus1.NumVal == param1Int)
			{
			  return p2AppManagerStatus1;
			}
		  }
		  return UNKNOWN_ERROR;
		}

		  public static IList<p2AppManagerStatus> values()
		  {
			  return valueList;
		  }

		  public int ordinal()
		  {
			  return ordinalValue;
		  }

		  public override string ToString()
		  {
			  return nameValue;
		  }

		  public static p2AppManagerStatus valueOf(string name)
		  {
			  foreach (p2AppManagerStatus enumInstance in p2AppManagerStatus.valueList)
			  {
				  if (enumInstance.nameValue == name)
				  {
					  return enumInstance;
				  }
			  }
			  throw new System.ArgumentException(name);
		  }
	  }

	  public sealed class p2DeviceAction
	  {
		public static readonly p2DeviceAction initializeCore = new p2DeviceAction("initializeCore", InnerEnum.initializeCore, 0);
		public static readonly p2DeviceAction RunInterSpec = new p2DeviceAction("RunInterSpec", InnerEnum.RunInterSpec, 1);
		public static readonly p2DeviceAction RunSpecBackground = new p2DeviceAction("RunSpecBackground", InnerEnum.RunSpecBackground, 2);
		public static readonly p2DeviceAction RunSpecSample = new p2DeviceAction("RunSpecSample", InnerEnum.RunSpecSample, 3);
		public static readonly p2DeviceAction SetActuation = new p2DeviceAction("SetActuation", InnerEnum.SetActuation, 4);
		public static readonly p2DeviceAction CheckBoardStatus = new p2DeviceAction("CheckBoardStatus", InnerEnum.CheckBoardStatus, 5);
		public static readonly p2DeviceAction RunCapCurrent = new p2DeviceAction("RunCapCurrent", InnerEnum.RunCapCurrent, 6);
		public static readonly p2DeviceAction RunCapTimeCalibration = new p2DeviceAction("RunCapTimeCalibration", InnerEnum.RunCapTimeCalibration, 7);
		public static readonly p2DeviceAction RunDelayCompensation = new p2DeviceAction("RunDelayCompensation", InnerEnum.RunDelayCompensation, 8);
		public static readonly p2DeviceAction RunCalibration = new p2DeviceAction("RunCalibration", InnerEnum.RunCalibration, 9);
		public static readonly p2DeviceAction GenerateCalibration = new p2DeviceAction("GenerateCalibration", InnerEnum.GenerateCalibration, 10);
		public static readonly p2DeviceAction BurnSampleID = new p2DeviceAction("BurnSampleID", InnerEnum.BurnSampleID, 11);
		public static readonly p2DeviceAction BurnSampleFolders = new p2DeviceAction("BurnSampleFolders", InnerEnum.BurnSampleFolders, 12);
		public static readonly p2DeviceAction ReadTemp = new p2DeviceAction("ReadTemp", InnerEnum.ReadTemp, 13);
		public static readonly p2DeviceAction ReadASICRegisters = new p2DeviceAction("ReadASICRegisters", InnerEnum.ReadASICRegisters, 14);
		public static readonly p2DeviceAction WriteASICRegisters = new p2DeviceAction("WriteASICRegisters", InnerEnum.WriteASICRegisters, 15);
		public static readonly p2DeviceAction ReadSampleFolders = new p2DeviceAction("ReadSampleFolders", InnerEnum.ReadSampleFolders, 16);
		public static readonly p2DeviceAction CalculateResponse = new p2DeviceAction("CalculateResponse", InnerEnum.CalculateResponse, 17);
		public static readonly p2DeviceAction CalculateParameters = new p2DeviceAction("CalculateParameters", InnerEnum.CalculateParameters, 18);
		public static readonly p2DeviceAction TrimCoefficients = new p2DeviceAction("TrimCoefficients", InnerEnum.TrimCoefficients, 19);
		public static readonly p2DeviceAction TrimPhase = new p2DeviceAction("TrimPhase", InnerEnum.TrimPhase, 20);
		public static readonly p2DeviceAction CheckStability = new p2DeviceAction("CheckStability", InnerEnum.CheckStability, 21);
		public static readonly p2DeviceAction RunWaveform = new p2DeviceAction("RunWaveform", InnerEnum.RunWaveform, 22);
		public static readonly p2DeviceAction RunGainAdjustInterSpec = new p2DeviceAction("RunGainAdjustInterSpec", InnerEnum.RunGainAdjustInterSpec, 23);
		public static readonly p2DeviceAction RunSNR = new p2DeviceAction("RunSNR", InnerEnum.RunSNR, 24);
		public static readonly p2DeviceAction RunSelfCorr = new p2DeviceAction("RunSelfCorr", InnerEnum.RunSelfCorr, 25);
		public static readonly p2DeviceAction RunWavelengthCalibration = new p2DeviceAction("RunWavelengthCalibration", InnerEnum.RunWavelengthCalibration, 26);
		public static readonly p2DeviceAction RunStability = new p2DeviceAction("RunStability", InnerEnum.RunStability, 27);
		public static readonly p2DeviceAction RunGainAdjustSpecBG = new p2DeviceAction("RunGainAdjustSpecBG", InnerEnum.RunGainAdjustSpecBG, 28);
		public static readonly p2DeviceAction RunGainAdjustSpecSample = new p2DeviceAction("RunGainAdjustSpecSample", InnerEnum.RunGainAdjustSpecSample, 29);
		public static readonly p2DeviceAction RunWavelengthCalibrationBG = new p2DeviceAction("RunWavelengthCalibrationBG", InnerEnum.RunWavelengthCalibrationBG, 30);
		public static readonly p2DeviceAction RunUpdateFFT_SettingsInterSpec = new p2DeviceAction("RunUpdateFFT_SettingsInterSpec", InnerEnum.RunUpdateFFT_SettingsInterSpec, 31);
		public static readonly p2DeviceAction RunUpdateFFT_SettingsSpec = new p2DeviceAction("RunUpdateFFT_SettingsSpec", InnerEnum.RunUpdateFFT_SettingsSpec, 32);
		public static readonly p2DeviceAction RestoreDefaultSettings = new p2DeviceAction("RestoreDefaultSettings", InnerEnum.RestoreDefaultSettings, 33);
		public static readonly p2DeviceAction BurnWorkingSettings = new p2DeviceAction("BurnWorkingSettings", InnerEnum.BurnWorkingSettings, 34);
		public static readonly p2DeviceAction TrimPhaseFast = new p2DeviceAction("TrimPhaseFast", InnerEnum.TrimPhaseFast, 35);

		private static readonly IList<p2DeviceAction> valueList = new List<p2DeviceAction>();

		static p2DeviceAction()
		{
			valueList.Add(initializeCore);
			valueList.Add(RunInterSpec);
			valueList.Add(RunSpecBackground);
			valueList.Add(RunSpecSample);
			valueList.Add(SetActuation);
			valueList.Add(CheckBoardStatus);
			valueList.Add(RunCapCurrent);
			valueList.Add(RunCapTimeCalibration);
			valueList.Add(RunDelayCompensation);
			valueList.Add(RunCalibration);
			valueList.Add(GenerateCalibration);
			valueList.Add(BurnSampleID);
			valueList.Add(BurnSampleFolders);
			valueList.Add(ReadTemp);
			valueList.Add(ReadASICRegisters);
			valueList.Add(WriteASICRegisters);
			valueList.Add(ReadSampleFolders);
			valueList.Add(CalculateResponse);
			valueList.Add(CalculateParameters);
			valueList.Add(TrimCoefficients);
			valueList.Add(TrimPhase);
			valueList.Add(CheckStability);
			valueList.Add(RunWaveform);
			valueList.Add(RunGainAdjustInterSpec);
			valueList.Add(RunSNR);
			valueList.Add(RunSelfCorr);
			valueList.Add(RunWavelengthCalibration);
			valueList.Add(RunStability);
			valueList.Add(RunGainAdjustSpecBG);
			valueList.Add(RunGainAdjustSpecSample);
			valueList.Add(RunWavelengthCalibrationBG);
			valueList.Add(RunUpdateFFT_SettingsInterSpec);
			valueList.Add(RunUpdateFFT_SettingsSpec);
			valueList.Add(RestoreDefaultSettings);
			valueList.Add(BurnWorkingSettings);
			valueList.Add(TrimPhaseFast);
		}

		public enum InnerEnum
		{
			initializeCore,
			RunInterSpec,
			RunSpecBackground,
			RunSpecSample,
			SetActuation,
			CheckBoardStatus,
			RunCapCurrent,
			RunCapTimeCalibration,
			RunDelayCompensation,
			RunCalibration,
			GenerateCalibration,
			BurnSampleID,
			BurnSampleFolders,
			ReadTemp,
			ReadASICRegisters,
			WriteASICRegisters,
			ReadSampleFolders,
			CalculateResponse,
			CalculateParameters,
			TrimCoefficients,
			TrimPhase,
			CheckStability,
			RunWaveform,
			RunGainAdjustInterSpec,
			RunSNR,
			RunSelfCorr,
			RunWavelengthCalibration,
			RunStability,
			RunGainAdjustSpecBG,
			RunGainAdjustSpecSample,
			RunWavelengthCalibrationBG,
			RunUpdateFFT_SettingsInterSpec,
			RunUpdateFFT_SettingsSpec,
			RestoreDefaultSettings,
			BurnWorkingSettings,
			TrimPhaseFast
		}

		public readonly InnerEnum innerEnumValue;
		private readonly string nameValue;
		private readonly int ordinalValue;
		private static int nextOrdinal = 0;

		internal readonly int a;

		internal p2DeviceAction(string name, InnerEnum innerEnum, int param1Int1)
		{
			this.a = param1Int1;

			nameValue = name;
			ordinalValue = nextOrdinal++;
			innerEnumValue = innerEnum;
		}

		public int NumVal
		{
			get
			{
				return this.a;
			}
		}

		  public static IList<p2DeviceAction> values()
		  {
			  return valueList;
		  }

		  public int ordinal()
		  {
			  return ordinalValue;
		  }

		  public override string ToString()
		  {
			  return nameValue;
		  }

		  public static p2DeviceAction valueOf(string name)
		  {
			  foreach (p2DeviceAction enumInstance in p2DeviceAction.valueList)
			  {
				  if (enumInstance.nameValue == name)
				  {
					  return enumInstance;
				  }
			  }
			  throw new System.ArgumentException(name);
		  }
	  }

	  public sealed class p2AppManagerState
	  {
		public static readonly p2AppManagerState Idle = new p2AppManagerState("Idle", InnerEnum.Idle, 0);
		public static readonly p2AppManagerState Initialize = new p2AppManagerState("Initialize", InnerEnum.Initialize, 1, p2Enumerations.p2DeviceAction.initializeCore);
		public static readonly p2AppManagerState InterferogramRun = new p2AppManagerState("InterferogramRun", InnerEnum.InterferogramRun, 2, p2Enumerations.p2DeviceAction.RunInterSpec);
		public static readonly p2AppManagerState SpectroscopySampleRun = new p2AppManagerState("SpectroscopySampleRun", InnerEnum.SpectroscopySampleRun, 3, p2Enumerations.p2DeviceAction.RunSpecSample);
		public static readonly p2AppManagerState SpectroscopyBackgroundRun = new p2AppManagerState("SpectroscopyBackgroundRun", InnerEnum.SpectroscopyBackgroundRun, 4, p2Enumerations.p2DeviceAction.RunSpecBackground);
		public static readonly p2AppManagerState ActuationProfileSetting = new p2AppManagerState("ActuationProfileSetting", InnerEnum.ActuationProfileSetting, 5, p2Enumerations.p2DeviceAction.SetActuation);
		public static readonly p2AppManagerState CheckingDeviceStatus = new p2AppManagerState("CheckingDeviceStatus", InnerEnum.CheckingDeviceStatus, 6, p2Enumerations.p2DeviceAction.CheckBoardStatus);
		public static readonly p2AppManagerState CapCurrentRun = new p2AppManagerState("CapCurrentRun", InnerEnum.CapCurrentRun, 7, p2Enumerations.p2DeviceAction.RunCapCurrent);
		public static readonly p2AppManagerState CalibrationCapVsTimeRun = new p2AppManagerState("CalibrationCapVsTimeRun", InnerEnum.CalibrationCapVsTimeRun, 8, p2Enumerations.p2DeviceAction.RunCapTimeCalibration);
		public static readonly p2AppManagerState CalibrationDelayCompensationRun = new p2AppManagerState("CalibrationDelayCompensationRun", InnerEnum.CalibrationDelayCompensationRun, 9, p2Enumerations.p2DeviceAction.RunDelayCompensation);
		public static readonly p2AppManagerState CalibrationCoreRun = new p2AppManagerState("CalibrationCoreRun", InnerEnum.CalibrationCoreRun, 10, p2Enumerations.p2DeviceAction.RunCalibration);
		public static readonly p2AppManagerState CalibrationGeneration = new p2AppManagerState("CalibrationGeneration", InnerEnum.CalibrationGeneration, 11, p2Enumerations.p2DeviceAction.GenerateCalibration);
		public static readonly p2AppManagerState SampleIDBurn = new p2AppManagerState("SampleIDBurn", InnerEnum.SampleIDBurn, 12, p2Enumerations.p2DeviceAction.BurnSampleID);
		public static readonly p2AppManagerState SampleFoldersBurn = new p2AppManagerState("SampleFoldersBurn", InnerEnum.SampleFoldersBurn, 13, p2Enumerations.p2DeviceAction.BurnSampleFolders);
		public static readonly p2AppManagerState TempReading = new p2AppManagerState("TempReading", InnerEnum.TempReading, 14, p2Enumerations.p2DeviceAction.ReadTemp);
		public static readonly p2AppManagerState ASICRegistersReading = new p2AppManagerState("ASICRegistersReading", InnerEnum.ASICRegistersReading, 15, p2Enumerations.p2DeviceAction.ReadASICRegisters);
		public static readonly p2AppManagerState ASICRegistersWriting = new p2AppManagerState("ASICRegistersWriting", InnerEnum.ASICRegistersWriting, 16, p2Enumerations.p2DeviceAction.WriteASICRegisters);
		public static readonly p2AppManagerState SampleFoldersReading = new p2AppManagerState("SampleFoldersReading", InnerEnum.SampleFoldersReading, 17, p2Enumerations.p2DeviceAction.ReadSampleFolders);
		public static readonly p2AppManagerState ResponseCalculation = new p2AppManagerState("ResponseCalculation", InnerEnum.ResponseCalculation, 18, p2Enumerations.p2DeviceAction.CalculateResponse);
		public static readonly p2AppManagerState ParametersCalculation = new p2AppManagerState("ParametersCalculation", InnerEnum.ParametersCalculation, 19, p2Enumerations.p2DeviceAction.CalculateParameters);
		public static readonly p2AppManagerState CoefficientsTrimming = new p2AppManagerState("CoefficientsTrimming", InnerEnum.CoefficientsTrimming, 20, p2Enumerations.p2DeviceAction.TrimCoefficients);
		public static readonly p2AppManagerState PhaseTrimming = new p2AppManagerState("PhaseTrimming", InnerEnum.PhaseTrimming, 21, p2Enumerations.p2DeviceAction.TrimPhase);
		public static readonly p2AppManagerState StabilityCheck = new p2AppManagerState("StabilityCheck", InnerEnum.StabilityCheck, 22, p2Enumerations.p2DeviceAction.CheckStability);
		public static readonly p2AppManagerState WaveformPreview = new p2AppManagerState("WaveformPreview", InnerEnum.WaveformPreview, 23, p2Enumerations.p2DeviceAction.RunWaveform);
		public static readonly p2AppManagerState gainAdjustInterSpecRun = new p2AppManagerState("gainAdjustInterSpecRun", InnerEnum.gainAdjustInterSpecRun, 24, p2Enumerations.p2DeviceAction.RunGainAdjustInterSpec);
		public static readonly p2AppManagerState SNR_Run = new p2AppManagerState("SNR_Run", InnerEnum.SNR_Run, 25, p2Enumerations.p2DeviceAction.RunSNR);
		public static readonly p2AppManagerState selfCorr_Run = new p2AppManagerState("selfCorr_Run", InnerEnum.selfCorr_Run, 26, p2Enumerations.p2DeviceAction.RunSelfCorr);
		public static readonly p2AppManagerState wavelengthCalibration_Run = new p2AppManagerState("wavelengthCalibration_Run", InnerEnum.wavelengthCalibration_Run, 27, p2Enumerations.p2DeviceAction.RunWavelengthCalibration);
		public static readonly p2AppManagerState StabilityRun = new p2AppManagerState("StabilityRun", InnerEnum.StabilityRun, 28, p2Enumerations.p2DeviceAction.RunStability);
		public static readonly p2AppManagerState gainAdjustSpecBG_Run = new p2AppManagerState("gainAdjustSpecBG_Run", InnerEnum.gainAdjustSpecBG_Run, 29, p2Enumerations.p2DeviceAction.RunGainAdjustSpecBG);
		public static readonly p2AppManagerState gainAdjustSpecSampleRun = new p2AppManagerState("gainAdjustSpecSampleRun", InnerEnum.gainAdjustSpecSampleRun, 30, p2Enumerations.p2DeviceAction.RunGainAdjustSpecSample);
		public static readonly p2AppManagerState wavelengthCalibrationBG_Run = new p2AppManagerState("wavelengthCalibrationBG_Run", InnerEnum.wavelengthCalibrationBG_Run, 31, p2Enumerations.p2DeviceAction.RunWavelengthCalibrationBG);
		public static readonly p2AppManagerState updateFFT_SettingsInterSpecRun = new p2AppManagerState("updateFFT_SettingsInterSpecRun", InnerEnum.updateFFT_SettingsInterSpecRun, 32, p2Enumerations.p2DeviceAction.RunUpdateFFT_SettingsInterSpec);
		public static readonly p2AppManagerState updateFFT_SettingsSpecRun = new p2AppManagerState("updateFFT_SettingsSpecRun", InnerEnum.updateFFT_SettingsSpecRun, 33, p2Enumerations.p2DeviceAction.RunUpdateFFT_SettingsSpec);
		public static readonly p2AppManagerState RestoreDefault = new p2AppManagerState("RestoreDefault", InnerEnum.RestoreDefault, 34, p2Enumerations.p2DeviceAction.RestoreDefaultSettings);
		public static readonly p2AppManagerState BurnSettings = new p2AppManagerState("BurnSettings", InnerEnum.BurnSettings, 35, p2Enumerations.p2DeviceAction.BurnWorkingSettings);
		public static readonly p2AppManagerState FastPhaseTrimming = new p2AppManagerState("FastPhaseTrimming", InnerEnum.FastPhaseTrimming, 36, p2Enumerations.p2DeviceAction.TrimPhaseFast);

		private static readonly IList<p2AppManagerState> valueList = new List<p2AppManagerState>();

		static p2AppManagerState()
		{
			valueList.Add(Idle);
			valueList.Add(Initialize);
			valueList.Add(InterferogramRun);
			valueList.Add(SpectroscopySampleRun);
			valueList.Add(SpectroscopyBackgroundRun);
			valueList.Add(ActuationProfileSetting);
			valueList.Add(CheckingDeviceStatus);
			valueList.Add(CapCurrentRun);
			valueList.Add(CalibrationCapVsTimeRun);
			valueList.Add(CalibrationDelayCompensationRun);
			valueList.Add(CalibrationCoreRun);
			valueList.Add(CalibrationGeneration);
			valueList.Add(SampleIDBurn);
			valueList.Add(SampleFoldersBurn);
			valueList.Add(TempReading);
			valueList.Add(ASICRegistersReading);
			valueList.Add(ASICRegistersWriting);
			valueList.Add(SampleFoldersReading);
			valueList.Add(ResponseCalculation);
			valueList.Add(ParametersCalculation);
			valueList.Add(CoefficientsTrimming);
			valueList.Add(PhaseTrimming);
			valueList.Add(StabilityCheck);
			valueList.Add(WaveformPreview);
			valueList.Add(gainAdjustInterSpecRun);
			valueList.Add(SNR_Run);
			valueList.Add(selfCorr_Run);
			valueList.Add(wavelengthCalibration_Run);
			valueList.Add(StabilityRun);
			valueList.Add(gainAdjustSpecBG_Run);
			valueList.Add(gainAdjustSpecSampleRun);
			valueList.Add(wavelengthCalibrationBG_Run);
			valueList.Add(updateFFT_SettingsInterSpecRun);
			valueList.Add(updateFFT_SettingsSpecRun);
			valueList.Add(RestoreDefault);
			valueList.Add(BurnSettings);
			valueList.Add(FastPhaseTrimming);
		}

		public enum InnerEnum
		{
			Idle,
			Initialize,
			InterferogramRun,
			SpectroscopySampleRun,
			SpectroscopyBackgroundRun,
			ActuationProfileSetting,
			CheckingDeviceStatus,
			CapCurrentRun,
			CalibrationCapVsTimeRun,
			CalibrationDelayCompensationRun,
			CalibrationCoreRun,
			CalibrationGeneration,
			SampleIDBurn,
			SampleFoldersBurn,
			TempReading,
			ASICRegistersReading,
			ASICRegistersWriting,
			SampleFoldersReading,
			ResponseCalculation,
			ParametersCalculation,
			CoefficientsTrimming,
			PhaseTrimming,
			StabilityCheck,
			WaveformPreview,
			gainAdjustInterSpecRun,
			SNR_Run,
			selfCorr_Run,
			wavelengthCalibration_Run,
			StabilityRun,
			gainAdjustSpecBG_Run,
			gainAdjustSpecSampleRun,
			wavelengthCalibrationBG_Run,
			updateFFT_SettingsInterSpecRun,
			updateFFT_SettingsSpecRun,
			RestoreDefault,
			BurnSettings,
			FastPhaseTrimming
		}

		public readonly InnerEnum innerEnumValue;
		private readonly string nameValue;
		private readonly int ordinalValue;
		private static int nextOrdinal = 0;

		internal readonly int a;

		internal readonly p2Enumerations.p2DeviceAction b;

		internal p2AppManagerState(string name, InnerEnum innerEnum, int param1Int1)
		{
		  this.a = param1Int1;
		  this.b = null;

			nameValue = name;
			ordinalValue = nextOrdinal++;
			innerEnumValue = innerEnum;
		}

		internal p2AppManagerState(string name, InnerEnum innerEnum, p2Enumerations.p2DeviceAction param1p2DeviceAction1, p2Enumerations.p2DeviceAction param1p2DeviceAction2)
		{
		  this.a = param1p2DeviceAction1;
		  this.b = param1p2DeviceAction2;

			nameValue = name;
			ordinalValue = nextOrdinal++;
			innerEnumValue = innerEnum;
		}

		public int NumVal
		{
			get
			{
				return this.a;
			}
		}

		public p2Enumerations.p2DeviceAction DeviceAtion
		{
			get
			{
				return this.b;
			}
		}

		  public static IList<p2AppManagerState> values()
		  {
			  return valueList;
		  }

		  public int ordinal()
		  {
			  return ordinalValue;
		  }

		  public override string ToString()
		  {
			  return nameValue;
		  }

		  public static p2AppManagerState valueOf(string name)
		  {
			  foreach (p2AppManagerState enumInstance in p2AppManagerState.valueList)
			  {
				  if (enumInstance.nameValue == name)
				  {
					  return enumInstance;
				  }
			  }
			  throw new System.ArgumentException(name);
		  }
	  }

	  public sealed class p2CorrectionType
	  {
		public static readonly p2CorrectionType Corrected = new p2CorrectionType("Corrected", InnerEnum.Corrected, 0);
		public static readonly p2CorrectionType Uncorrected = new p2CorrectionType("Uncorrected", InnerEnum.Uncorrected, 1);

		private static readonly IList<p2CorrectionType> valueList = new List<p2CorrectionType>();

		static p2CorrectionType()
		{
			valueList.Add(Corrected);
			valueList.Add(Uncorrected);
		}

		public enum InnerEnum
		{
			Corrected,
			Uncorrected
		}

		public readonly InnerEnum innerEnumValue;
		private readonly string nameValue;
		private readonly int ordinalValue;
		private static int nextOrdinal = 0;

		internal readonly int a;

		internal p2CorrectionType(string name, InnerEnum innerEnum, int param1Int1)
		{
			this.a = param1Int1;

			nameValue = name;
			ordinalValue = nextOrdinal++;
			innerEnumValue = innerEnum;
		}

		public int NumVal
		{
			get
			{
				return this.a;
			}
		}

		  public static IList<p2CorrectionType> values()
		  {
			  return valueList;
		  }

		  public int ordinal()
		  {
			  return ordinalValue;
		  }

		  public override string ToString()
		  {
			  return nameValue;
		  }

		  public static p2CorrectionType valueOf(string name)
		  {
			  foreach (p2CorrectionType enumInstance in p2CorrectionType.valueList)
			  {
				  if (enumInstance.nameValue == name)
				  {
					  return enumInstance;
				  }
			  }
			  throw new System.ArgumentException(name);
		  }
	  }

	  public sealed class RestoreOptionsEnum
	  {
		public static readonly RestoreOptionsEnum OPTICAL_GAIN_SETTINGS = new RestoreOptionsEnum("OPTICAL_GAIN_SETTINGS", InnerEnum.OPTICAL_GAIN_SETTINGS, 0, "Optical gain settings");
		public static readonly RestoreOptionsEnum CORRECTION_SETTINGS = new RestoreOptionsEnum("CORRECTION_SETTINGS", InnerEnum.CORRECTION_SETTINGS, 1, "Correction settings");
		public static readonly RestoreOptionsEnum ALL = new RestoreOptionsEnum("ALL", InnerEnum.ALL, 3, "All");

		private static readonly IList<RestoreOptionsEnum> valueList = new List<RestoreOptionsEnum>();

		static RestoreOptionsEnum()
		{
			valueList.Add(OPTICAL_GAIN_SETTINGS);
			valueList.Add(CORRECTION_SETTINGS);
			valueList.Add(ALL);
		}

		public enum InnerEnum
		{
			OPTICAL_GAIN_SETTINGS,
			CORRECTION_SETTINGS,
			ALL
		}

		public readonly InnerEnum innerEnumValue;
		private readonly string nameValue;
		private readonly int ordinalValue;
		private static int nextOrdinal = 0;

		internal readonly int a;

		internal readonly string b;

		internal RestoreOptionsEnum(string name, InnerEnum innerEnum, string param1String1, string param1String2)
		{
		  this.a = param1String1;
		  this.b = param1String2;

			nameValue = name;
			ordinalValue = nextOrdinal++;
			innerEnumValue = innerEnum;
		}

		public int NumVal
		{
			get
			{
				return this.a;
			}
		}

		public string StringVal
		{
			get
			{
				return this.b;
			}
		}

		  public static IList<RestoreOptionsEnum> values()
		  {
			  return valueList;
		  }

		  public int ordinal()
		  {
			  return ordinalValue;
		  }

		  public override string ToString()
		  {
			  return nameValue;
		  }

		  public static RestoreOptionsEnum valueOf(string name)
		  {
			  foreach (RestoreOptionsEnum enumInstance in RestoreOptionsEnum.valueList)
			  {
				  if (enumInstance.nameValue == name)
				  {
					  return enumInstance;
				  }
			  }
			  throw new System.ArgumentException(name);
		  }
	  }
	}


	/* Location:              D:\jobs\BalitTanah.SoilSensingKit\Decompile Driver\SDK v4.3\SDKv4.3\bin_win_x64\p2AppManager.jar!\sws\p2AppManage\\utils\p2Enumerations.class
	 * Java compiler version: 7 (51.0)
	 * JD-Core Version:       1.0.7
	 */
}