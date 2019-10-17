using System;
using System.IO;
using System.Runtime.InteropServices;

namespace sws.p2AppManager.dspAPI
{
	using p2Constants = sws.p2AppManager.utils.p2Constants;

	public class p2SpectroDSP
	{
//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
	  public static string a_Conflict = "DSP_Pre_Interferogram_param_conf.in";

//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
	  public static string b_Conflict = "DSP_Post_Calib_wl_calib_data.out";

	  private static p2SpectroDSP f;

	  private static bool g = false;

//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
	  public const int c_Conflict = 4;

	  public const int d = 17;

	  public const int e = 22;

	  private bool h = true;

	  private p2SpectroDSP()
	  {
		try
		{
		  spectro_spectrometerDSP_init();
		}
		catch (UnsatisfiedLinkError)
		{
		  Console.WriteLine("UnsatisfiedLinkError error in spectrometerDSP_init()");
		}
	  }

	  public static p2SpectroDSP a()
	  {
		if (f == null)
		{
		  f = new p2SpectroDSP();
		}
		return f;
	  }

//JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
	  [DllImport("unknown")]
	  private extern boolean spectro_spectrometerDSP_init();

//JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
	  [DllImport("unknown")]
	  private extern boolean spectrometerDSP_clean();

//JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
	  [DllImport("unknown")]
	  private extern boolean interferogram_initialization(double[] paramArrayOfDouble1, int paramInt1, bool paramBoolean1, bool paramBoolean2, bool paramBoolean3, double[] paramArrayOfDouble2, int paramInt2);

//JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
	  [DllImport("unknown")]
	  private extern boolean interferogram_preprocessing(int paramInt1, int paramInt2, double[] paramArrayOfDouble1, double[] paramArrayOfDouble2, double[] paramArrayOfDouble3, double[] paramArrayOfDouble4);

//JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
	  [DllImport("unknown")]
	  private extern boolean interferogram_capToDistance(double[] paramArrayOfDouble1, double[] paramArrayOfDouble2, double[] paramArrayOfDouble3, int paramInt, double[] paramArrayOfDouble4, double[] paramArrayOfDouble5);

//JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
	  [DllImport("unknown")]
	  private extern boolean interferogram_interpolation(double[] paramArrayOfDouble1, double[] paramArrayOfDouble2, double[] paramArrayOfDouble3, double[] paramArrayOfDouble4, double[] paramArrayOfDouble5, double[] paramArrayOfDouble6);

//JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
	  [DllImport("unknown")]
	  private extern int interferogram_findLPF_Length();

//JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
	  [DllImport("unknown")]
	  private extern int interferogram_findLPF_Index();

//JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
	  [DllImport("unknown")]
	  private extern boolean interferogram_removeMovingAverage(double[] paramArrayOfDouble1, int paramInt1, double[] paramArrayOfDouble2, int paramInt2, double[] paramArrayOfDouble3, double[] paramArrayOfDouble4);

//JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
	  [DllImport("unknown")]
	  private extern boolean interferogram_wavelengthSelfCorrection(double[] paramArrayOfDouble1, double[] paramArrayOfDouble2, double[] paramArrayOfDouble3, double[] paramArrayOfDouble4, double[] paramArrayOfDouble5, double[] paramArrayOfDouble6, int[] paramArrayOfInt1, int[] paramArrayOfInt2, double[] paramArrayOfDouble7);

//JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
	  [DllImport("unknown")]
	  private extern int interferogram_apodizationGetSize();

//JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
	  [DllImport("unknown")]
	  private extern int interferogram_findFFT_Length(int paramInt1, int paramInt2);

//JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
	  [DllImport("unknown")]
	  private extern boolean interferogram_apodization(double[] paramArrayOfDouble1, double[] paramArrayOfDouble2, int paramInt, double[] paramArrayOfDouble3);

//JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
	  [DllImport("unknown")]
	  private extern boolean interferogram_powerSpectralDensityCalculation(double[] paramArrayOfDouble1, double[] paramArrayOfDouble2, int paramInt, double[] paramArrayOfDouble3, double[] paramArrayOfDouble4, int[] paramArrayOfInt);

//JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
	  [DllImport("unknown")]
	  private extern boolean interferogram_integration(bool paramBoolean1, bool paramBoolean2, bool paramBoolean3, double[] paramArrayOfDouble1, int paramInt1, double[] paramArrayOfDouble2, int paramInt2, double[] paramArrayOfDouble3, int paramInt3, double[] paramArrayOfDouble4, int paramInt4, int paramInt5, double[] paramArrayOfDouble5, double[] paramArrayOfDouble6, int paramInt6, int paramInt7, int paramInt8, double[] paramArrayOfDouble7, double[] paramArrayOfDouble8, double[] paramArrayOfDouble9, double[] paramArrayOfDouble10, double[] paramArrayOfDouble11, double[] paramArrayOfDouble12, int[] paramArrayOfInt1, double[] paramArrayOfDouble13, double[] paramArrayOfDouble14, double[] paramArrayOfDouble15, double[] paramArrayOfDouble16, int[] paramArrayOfInt2, int[] paramArrayOfInt3, int[] paramArrayOfInt4);

//JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
	  [DllImport("unknown")]
	  private extern boolean interferogram_endFFT(bool paramBoolean1, bool paramBoolean2, bool paramBoolean3, double[] paramArrayOfDouble1, int paramInt1, double[] paramArrayOfDouble2, int paramInt2, double[] paramArrayOfDouble3, double[] paramArrayOfDouble4, int paramInt3, double[] paramArrayOfDouble5, int paramInt4, double[] paramArrayOfDouble6, double[] paramArrayOfDouble7, double[] paramArrayOfDouble8);

//JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
	  [DllImport("unknown")]
	  private extern boolean capInterp(double[] paramArrayOfDouble1, int paramInt1, double[] paramArrayOfDouble2, int paramInt2, int paramInt3, double paramDouble1, double paramDouble2, double[] paramArrayOfDouble3, double[] paramArrayOfDouble4, double[] paramArrayOfDouble5, double[] paramArrayOfDouble6, double[] paramArrayOfDouble7, double[] paramArrayOfDouble8, double[] paramArrayOfDouble9);

//JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
	  [DllImport("unknown")]
	  private extern boolean delayCompSearching(double[] paramArrayOfDouble1, double[] paramArrayOfDouble2, int paramInt1, double[] paramArrayOfDouble3, int paramInt2, double[] paramArrayOfDouble4, int paramInt3, int paramInt4, int paramInt5, bool paramBoolean, int paramInt6, int[] paramArrayOfInt1, int[] paramArrayOfInt2, bool[] paramArrayOfBoolean);

//JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
	  [DllImport("unknown")]
	  private extern boolean SpectrometerDSP_Calib(double[] paramArrayOfDouble1, int paramInt1, double[] paramArrayOfDouble2, int paramInt2, double[] paramArrayOfDouble3, double[] paramArrayOfDouble4, int paramInt3, double[] paramArrayOfDouble5, double[] paramArrayOfDouble6, int paramInt4, double[] paramArrayOfDouble7, int paramInt5, double[] paramArrayOfDouble8, int paramInt6, double[] paramArrayOfDouble9, int paramInt7, double[] paramArrayOfDouble10, int paramInt8, double[] paramArrayOfDouble11, int paramInt9, double paramDouble1, double paramDouble2, double paramDouble3, bool paramBoolean1, double paramDouble4, double paramDouble5, double paramDouble6, double paramDouble7, int paramInt10, int paramInt11, double paramDouble8, bool paramBoolean2, double[] paramArrayOfDouble12, int paramInt12, int paramInt13, int paramInt14, int paramInt15, double[] paramArrayOfDouble13, double[] paramArrayOfDouble14, double[] paramArrayOfDouble15, double[] paramArrayOfDouble16, double[] paramArrayOfDouble17, double[] paramArrayOfDouble18, int[] paramArrayOfInt, double[] paramArrayOfDouble19, double[] paramArrayOfDouble20);

//JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
	  [DllImport("unknown")]
	  private extern boolean SpectrometerDSP_capAndCurrent(double[] paramArrayOfDouble1, int paramInt1, double[] paramArrayOfDouble2, int paramInt2, double[] paramArrayOfDouble3, int paramInt3, double paramDouble1, double paramDouble2, double paramDouble3, double paramDouble4, double[] paramArrayOfDouble4, double[] paramArrayOfDouble5, double[] paramArrayOfDouble6, double[] paramArrayOfDouble7, double[] paramArrayOfDouble8, double[] paramArrayOfDouble9, double[] paramArrayOfDouble10, double[] paramArrayOfDouble11, double[] paramArrayOfDouble12, double[] paramArrayOfDouble13);

//JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
	  [DllImport("unknown")]
	  private extern boolean abstractClosedLoop_closedLoop_initialization(double[] paramArrayOfDouble, int paramInt);

//JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
	  [DllImport("unknown")]
	  private extern boolean abstractClosedLoop_closedLoop_capAmpCalc(double[] paramArrayOfDouble1, int paramInt, double[] paramArrayOfDouble2);

//JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
	  [DllImport("unknown")]
	  private extern boolean abstractClosedLoop_closedLoop_signalPreprocessing(int paramInt, double paramDouble1, double paramDouble2, double paramDouble3, double paramDouble4, double[] paramArrayOfDouble);

//JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
	  [DllImport("unknown")]
	  private extern boolean abstractClosedLoop_closedLoop_memsParametersDetection(double[] paramArrayOfDouble1, int paramInt, double[] paramArrayOfDouble2, double[] paramArrayOfDouble3);

//JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
	  [DllImport("unknown")]
	  private extern boolean abstractClosedLoop_closedLoop_fwdGainCalc(double[] paramArrayOfDouble1, int paramInt, double paramDouble1, double paramDouble2, double paramDouble3, double paramDouble4, double[] paramArrayOfDouble2);

//JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
	  [DllImport("unknown")]
	  private extern boolean abstractClosedLoop_closedLoop_loopCoefficientsCalc(double paramDouble1, double paramDouble2, double paramDouble3, double paramDouble4, double[] paramArrayOfDouble1, double[] paramArrayOfDouble2, int paramInt, double paramDouble5, double[] paramArrayOfDouble3, double[] paramArrayOfDouble4, double[] paramArrayOfDouble5, double[] paramArrayOfDouble6, double[] paramArrayOfDouble7, double[] paramArrayOfDouble8, double[] paramArrayOfDouble9, double[] paramArrayOfDouble10, double[] paramArrayOfDouble11, double[] paramArrayOfDouble12, double[] paramArrayOfDouble13, double[] paramArrayOfDouble14, double[] paramArrayOfDouble15, double[] paramArrayOfDouble16);

//JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
	  [DllImport("unknown")]
	  private extern boolean abstractClosedLoop_closedLoop_phaseConversion(double paramDouble1, double paramDouble2, double[] paramArrayOfDouble);

//JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
	  [DllImport("unknown")]
	  private extern boolean abstractClosedLoop_closedLoop_phaseValidation(double[] paramArrayOfDouble1, int paramInt1, double[] paramArrayOfDouble2, int paramInt2, double paramDouble, double[] paramArrayOfDouble3);

//JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
	  [DllImport("unknown")]
	  private extern boolean abstractClosedLoop_closedLoop_optimumPhaseDetection(double[] paramArrayOfDouble1, double[] paramArrayOfDouble2, double[] paramArrayOfDouble3, int paramInt, double[] paramArrayOfDouble4, double[] paramArrayOfDouble5, int[] paramArrayOfInt, double[] paramArrayOfDouble6);

//JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
	  [DllImport("unknown")]
	  private extern boolean abstractClosedLoop_closedLoop_optimumPhaseDetectionFast(double[] paramArrayOfDouble1, double[] paramArrayOfDouble2, int paramInt, double[] paramArrayOfDouble3, double[] paramArrayOfDouble4, int[] paramArrayOfInt, double[] paramArrayOfDouble5);

//JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
	  [DllImport("unknown")]
	  private extern boolean abstractClosedLoop_closedLoop_settingsCheck(double[] paramArrayOfDouble1, int paramInt1, double[] paramArrayOfDouble2, int paramInt2, double paramDouble1, double paramDouble2, double paramDouble3, double paramDouble4, double[] paramArrayOfDouble3, double[] paramArrayOfDouble4, double[] paramArrayOfDouble5, double[] paramArrayOfDouble6, double[] paramArrayOfDouble7, double[] paramArrayOfDouble8, double[] paramArrayOfDouble9);

//JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
	  [DllImport("unknown")]
	  private extern boolean abstractClosedLoop_closedLoop_calculateKdigFromRegisterValue(double paramDouble, double[] paramArrayOfDouble);

//JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
	  [DllImport("unknown")]
	  private extern boolean abstractClosedLoop_closedLoop_gainMarginCalc(double[] paramArrayOfDouble1, int paramInt1, double paramDouble1, int paramInt2, double paramDouble2, double[] paramArrayOfDouble2, double[] paramArrayOfDouble3, double[] paramArrayOfDouble4, double[] paramArrayOfDouble5, double[] paramArrayOfDouble6);

//JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
	  [DllImport("unknown")]
	  private extern boolean interferogram_SNR_Measurement(double[] paramArrayOfDouble1, double[] paramArrayOfDouble2, int paramInt1, int paramInt2, double paramDouble1, double paramDouble2, double paramDouble3, int paramInt3, double paramDouble4, double[] paramArrayOfDouble3, double[] paramArrayOfDouble4, double[] paramArrayOfDouble5, double[] paramArrayOfDouble6, double[] paramArrayOfDouble7, double[] paramArrayOfDouble8, double[] paramArrayOfDouble9, double[] paramArrayOfDouble10, double[] paramArrayOfDouble11, double[] paramArrayOfDouble12, double[] paramArrayOfDouble13, double[] paramArrayOfDouble14, double[] paramArrayOfDouble15, double[] paramArrayOfDouble16, double[] paramArrayOfDouble17, double[] paramArrayOfDouble18, double[] paramArrayOfDouble19);

//JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
	  [DllImport("unknown")]
	  private extern boolean interferogram_wavelengthCorrect(double[] paramArrayOfDouble1, double[] paramArrayOfDouble2, int paramInt1, double[] paramArrayOfDouble3, int paramInt2, int paramInt3, int paramInt4, double[] paramArrayOfDouble4, double[] paramArrayOfDouble5);

//JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
	  [DllImport("unknown")]
	  private extern boolean interferogram_repeatabilityAndStability(double[] paramArrayOfDouble1, int paramInt1, int paramInt2, double[] paramArrayOfDouble2, double[] paramArrayOfDouble3, int paramInt3, int paramInt4, double[] paramArrayOfDouble4, double[] paramArrayOfDouble5, double[] paramArrayOfDouble6, double[] paramArrayOfDouble7, double[] paramArrayOfDouble8);

//JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
	  [DllImport("unknown")]
	  private extern boolean interferogram_commonWavenumberGeneration(double paramDouble1, double paramDouble2, int paramInt1, double[] paramArrayOfDouble1, double[] paramArrayOfDouble2, int paramInt2, double[] paramArrayOfDouble3, double[] paramArrayOfDouble4);

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public double[][] a(double[] paramArrayOfDouble1, double[] paramArrayOfDouble2, double[] paramArrayOfDouble3, int paramInt, double[] paramArrayOfDouble4) throws a
	  public virtual double[][] a(double[] paramArrayOfDouble1, double[] paramArrayOfDouble2, double[] paramArrayOfDouble3, int paramInt, double[] paramArrayOfDouble4)
	  {
		try
		{
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_UpdateFFT_param_conf.in");
			for (sbyte b1 = 0; b1 < paramArrayOfDouble1.Length; b1++)
			{
			  bufferedWriter.Write(paramArrayOfDouble1[b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_UpdateFFT_X_Vector.in");
			for (sbyte b1 = 0; b1 < paramArrayOfDouble2.Length; b1++)
			{
			  bufferedWriter.Write(paramArrayOfDouble2[b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_UpdateFFT_I_Vector.in");
			for (sbyte b1 = 0; b1 < paramArrayOfDouble3.Length; b1++)
			{
			  bufferedWriter.Write(paramArrayOfDouble3[b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_UpdateFFT_normalizeSpectrum.in");
			bufferedWriter.Write(paramInt + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_UpdateFFT_INT_wl_corr.in");
			for (sbyte b1 = 0; b1 < paramArrayOfDouble4.Length; b1++)
			{
			  bufferedWriter.Write(paramArrayOfDouble4[b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  int i = interferogram_findFFT_Length((int)paramArrayOfDouble1[22], (int)paramArrayOfDouble1[17]);
		  int j = i / 2;
		  double[] arrayOfDouble1 = new double[j];
		  double[] arrayOfDouble2 = new double[j];
		  int[] arrayOfInt = new int[] {0};
		  bool bool1 = false;
		  bool bool2 = false;
		  bool bool3 = false;
		  if (paramInt == 1)
		  {
			bool2 = true;
		  }
		  else
		  {
			bool2 = false;
		  }
		  bool bool4 = interferogram_initialization(paramArrayOfDouble1, paramArrayOfDouble1.Length, bool1, bool2, bool3, paramArrayOfDouble4, paramArrayOfDouble4.Length);
		  if (bool4 == true)
		  {
			spectrometerDSP_clean();
			throw new Exception("An error occurred in interferogram_initialization function! Please contact your vendor for support.");
		  }
		  double[] arrayOfDouble3 = new double[paramArrayOfDouble2.Length];
		  bool4 = interferogram_apodization(paramArrayOfDouble2, paramArrayOfDouble3, paramArrayOfDouble2.Length, arrayOfDouble3);
		  if (bool4 == true)
		  {
			spectrometerDSP_clean();
			throw new Exception("An error occurred in interferogram_apodization function! Please contact your vendor for support.");
		  }
		  bool4 = interferogram_powerSpectralDensityCalculation(paramArrayOfDouble2, arrayOfDouble3, paramArrayOfDouble2.Length, arrayOfDouble1, arrayOfDouble2, arrayOfInt);
		  if (bool4 == true)
		  {
			spectrometerDSP_clean();
			throw new Exception("An error occurred in interferogram_powerSpectralDensityCalculation function! Please contact your vendor for support.");
		  }
		  arrayOfDouble3 = null;
		  double[][] arrayOfDouble = new double[2][];
		  arrayOfDouble[0] = new double[arrayOfInt[0]];
		  Array.Copy(arrayOfDouble1, 0, arrayOfDouble[0], 0, arrayOfInt[0]);
		  arrayOfDouble[1] = new double[arrayOfInt[0]];
		  Array.Copy(arrayOfDouble2, 0, arrayOfDouble[1], 0, arrayOfInt[0]);
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_UpdateFFT_v.out");
			for (sbyte b1 = 0; b1 < arrayOfDouble1.Length; b1++)
			{
			  bufferedWriter.Write(arrayOfDouble1[b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_UpdateFFT_b.out");
			for (sbyte b1 = 0; b1 < arrayOfDouble2.Length; b1++)
			{
			  bufferedWriter.Write(arrayOfDouble2[b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  arrayOfDouble1 = null;
		  arrayOfDouble2 = null;
		  arrayOfInt = null;
		  return arrayOfDouble;
		}
		catch (Exception exception)
		{
		  a a1 = new a();
		  a1.a_Conflict = exception;
		  throw a1;
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public double[][] a(double[] paramArrayOfDouble1, int paramInt1, int paramInt2, int paramInt3, int paramInt4, double[] paramArrayOfDouble2, double[] paramArrayOfDouble3, double[] paramArrayOfDouble4, double[] paramArrayOfDouble5, double[] paramArrayOfDouble6, int paramInt5, double[] paramArrayOfDouble7, double[] paramArrayOfDouble8) throws a
	  public virtual double[][] a(double[] paramArrayOfDouble1, int paramInt1, int paramInt2, int paramInt3, int paramInt4, double[] paramArrayOfDouble2, double[] paramArrayOfDouble3, double[] paramArrayOfDouble4, double[] paramArrayOfDouble5, double[] paramArrayOfDouble6, int paramInt5, double[] paramArrayOfDouble7, double[] paramArrayOfDouble8)
	  {
		try
		{
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + a_Conflict);
			for (sbyte b1 = 0; b1 < paramArrayOfDouble1.Length; b1++)
			{
			  bufferedWriter.Write(paramArrayOfDouble1[b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_INT_noSlices.in");
			bufferedWriter.Write(paramInt1 + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_INT_avgShiftBits.in");
			bufferedWriter.Write(paramInt2 + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_Interferogram_c2x_cal.in");
			for (sbyte b1 = 0; b1 < paramArrayOfDouble2.Length; b1++)
			{
			  bufferedWriter.Write(paramArrayOfDouble2[b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_Interferogram_opticalLPF1.in");
			for (sbyte b1 = 0; b1 < paramArrayOfDouble3.Length; b1++)
			{
			  bufferedWriter.Write(paramArrayOfDouble3[b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_Interferogram_opticalLPF2.in");
			for (sbyte b1 = 0; b1 < paramArrayOfDouble4.Length; b1++)
			{
			  bufferedWriter.Write(paramArrayOfDouble4[b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_Interferogram_wl_corr_cal.in");
			for (sbyte b1 = 0; b1 < paramArrayOfDouble5.Length; b1++)
			{
			  bufferedWriter.Write(paramArrayOfDouble5[b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_Interferogram_corr_cal.in");
			for (sbyte b1 = 0; b1 < paramArrayOfDouble6.Length; b1++)
			{
			  bufferedWriter.Write(paramArrayOfDouble6[b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_INT_Corrected_Uncorrected.in");
			bufferedWriter.Write(paramInt5 + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_Interferogram_I_sliceWhiteNeg.in");
			for (sbyte b1 = 0; b1 < paramArrayOfDouble7.Length; b1++)
			{
			  bufferedWriter.Write(paramArrayOfDouble7[b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_Interferogram_I_sliceWhitePos.in");
			for (sbyte b1 = 0; b1 < paramArrayOfDouble8.Length; b1++)
			{
			  bufferedWriter.Write(paramArrayOfDouble8[b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  int i = interferogram_findFFT_Length((int)paramArrayOfDouble1[22], (int)paramArrayOfDouble1[17]);
		  int j = i / 2;
		  double[] arrayOfDouble1 = new double[(int)paramArrayOfDouble1[17]];
		  double[] arrayOfDouble2 = new double[(int)paramArrayOfDouble1[17]];
		  double[] arrayOfDouble3 = new double[(int)paramArrayOfDouble1[17]];
		  double[] arrayOfDouble4 = new double[j];
		  double[] arrayOfDouble5 = new double[j];
		  double[] arrayOfDouble6 = new double[j];
		  double[] arrayOfDouble7 = new double[j];
		  int[] arrayOfInt1 = new int[] {0};
		  int[] arrayOfInt2 = new int[] {0};
		  int[] arrayOfInt3 = new int[] {0};
		  int[] arrayOfInt4 = new int[] {0};
		  bool bool1 = false;
		  bool bool2 = false;
		  bool bool3 = false;
		  if (paramInt4 == 1)
		  {
			bool3 = true;
		  }
		  else
		  {
			bool3 = false;
		  }
		  if (paramInt3 == 1)
		  {
			bool2 = true;
		  }
		  else
		  {
			bool2 = false;
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_Interferogram_uiConf.in");
			bufferedWriter.Write("0\n");
			bufferedWriter.Write("0\n");
			bufferedWriter.BaseStream.WriteByte(bool1 + "\n");
			bufferedWriter.BaseStream.WriteByte(bool2 + "\n");
			bufferedWriter.BaseStream.WriteByte(bool3 + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  double[] arrayOfDouble8 = new double[] {paramArrayOfDouble6[0]};
		  double[] arrayOfDouble9 = new double[] {paramArrayOfDouble6[1]};
		  bool bool4 = interferogram_integration(bool1, bool2, bool3, paramArrayOfDouble2, paramArrayOfDouble2.Length, paramArrayOfDouble5, paramArrayOfDouble5.Length, paramArrayOfDouble3, paramArrayOfDouble3.Length, paramArrayOfDouble4, paramArrayOfDouble4.Length, paramArrayOfDouble1.Length, paramArrayOfDouble7, paramArrayOfDouble8, paramArrayOfDouble7.Length, paramInt1, paramInt2, paramArrayOfDouble1, arrayOfDouble8, arrayOfDouble9, arrayOfDouble1, arrayOfDouble2, arrayOfDouble3, arrayOfInt1, arrayOfDouble4, arrayOfDouble5, arrayOfDouble6, arrayOfDouble7, arrayOfInt2, arrayOfInt3, arrayOfInt4);
		  paramArrayOfDouble6[0] = arrayOfDouble8[0];
		  paramArrayOfDouble6[1] = arrayOfDouble9[0];
		  if (bool4 == true)
		  {
			spectrometerDSP_clean();
			throw new Exception("An error occurred in interferogram_integration function! Please contact your vendor for support.");
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_Interferogram_corr_cal.out");
			for (sbyte b1 = 0; b1 < paramArrayOfDouble6.Length; b1++)
			{
			  bufferedWriter.Write(paramArrayOfDouble6[b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_Interferogram_xs.out");
			for (sbyte b1 = 0; b1 < arrayOfInt1[0]; b1++)
			{
			  bufferedWriter.Write(arrayOfDouble1[b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_Interferogram_Is_intensityVector.out");
			for (sbyte b1 = 0; b1 < arrayOfInt1[0]; b1++)
			{
			  bufferedWriter.Write(arrayOfDouble2[b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_Interferogram_I_lin_intensityVectorCorrected.out");
			for (sbyte b1 = 0; b1 < arrayOfInt1[0]; b1++)
			{
			  bufferedWriter.Write(arrayOfDouble3[b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_Interferogram_intensityVectorCorrectedLength.out");
			bufferedWriter.Write(arrayOfInt1[0] + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_Interferogram_powerSpectralVectorsLength.out");
			bufferedWriter.Write(arrayOfInt2[0] + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_Interferogram_leftZeros");
			bufferedWriter.Write(arrayOfInt3[0] + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_Interferogram_rightZeros");
			bufferedWriter.Write(arrayOfInt4[0] + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_Interferogram_v_waveNumberVector.out");
			for (sbyte b1 = 0; b1 < arrayOfInt2[0]; b1++)
			{
			  bufferedWriter.Write(arrayOfDouble4[b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_Interferogram_v_lin_waveNumberVectorCorrected.out");
			for (sbyte b1 = 0; b1 < arrayOfInt2[0]; b1++)
			{
			  bufferedWriter.Write(arrayOfDouble5[b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_Interferogram_B_powerSpectralDensity.out");
			for (sbyte b1 = 0; b1 < arrayOfInt2[0]; b1++)
			{
			  bufferedWriter.Write(arrayOfDouble6[b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_Interferogram_B_lin_powerSpectralDensityCorrected.out");
			for (sbyte b1 = 0; b1 < arrayOfInt2[0]; b1++)
			{
			  bufferedWriter.Write(arrayOfDouble7[b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  double[][] arrayOfDouble = new double[5][];
		  arrayOfDouble[0] = new double[arrayOfInt1[0]];
		  Array.Copy(arrayOfDouble1, 0, arrayOfDouble[0], 0, arrayOfInt1[0]);
		  arrayOfDouble[1] = new double[arrayOfInt1[0]];
		  arrayOfDouble[3] = new double[arrayOfInt2[0]];
		  arrayOfDouble[2] = new double[arrayOfInt2[0]];
		  if (paramInt5 == 0)
		  {
			Array.Copy(arrayOfDouble3, 0, arrayOfDouble[1], 0, arrayOfInt1[0]);
			Array.Copy(arrayOfDouble7, 0, arrayOfDouble[3], 0, arrayOfInt2[0]);
		  }
		  else
		  {
			Array.Copy(arrayOfDouble2, 0, arrayOfDouble[1], 0, arrayOfInt1[0]);
			Array.Copy(arrayOfDouble6, 0, arrayOfDouble[3], 0, arrayOfInt2[0]);
		  }
		  Array.Copy(arrayOfDouble5, 0, arrayOfDouble[2], 0, arrayOfInt2[0]);
		  arrayOfDouble[4] = paramArrayOfDouble6;
		  arrayOfDouble1 = null;
		  arrayOfDouble2 = null;
		  arrayOfDouble3 = null;
		  arrayOfDouble4 = null;
		  arrayOfDouble5 = null;
		  arrayOfDouble6 = null;
		  arrayOfDouble7 = null;
		  return arrayOfDouble;
		}
		catch (Exception exception)
		{
		  a a1 = new a();
		  a1.a_Conflict = exception;
		  throw a1;
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public double[][] a(double[] paramArrayOfDouble, double[][] paramArrayOfDouble1, double paramDouble1, double paramDouble2, double paramDouble3, int paramInt, double paramDouble4) throws a
	  public virtual double[][] a(double[] paramArrayOfDouble, double[][] paramArrayOfDouble1, double paramDouble1, double paramDouble2, double paramDouble3, int paramInt, double paramDouble4)
	  {
		try
		{
		  double[] arrayOfDouble1 = new double[paramArrayOfDouble1.Length * paramArrayOfDouble.Length];
		  double[] arrayOfDouble2 = new double[paramArrayOfDouble.Length];
		  double[] arrayOfDouble3 = new double[paramArrayOfDouble.Length * (paramArrayOfDouble1.Length - 1)];
		  double[] arrayOfDouble4 = new double[paramArrayOfDouble.Length];
		  double[] arrayOfDouble5 = new double[1];
		  double[] arrayOfDouble6 = new double[1];
		  double[] arrayOfDouble7 = new double[1];
		  double[] arrayOfDouble8 = new double[1];
		  double[] arrayOfDouble9 = new double[1];
		  double[] arrayOfDouble10 = new double[1];
		  double[] arrayOfDouble11 = new double[1];
		  double[] arrayOfDouble12 = new double[1];
		  double[] arrayOfDouble13 = new double[1];
		  double[] arrayOfDouble14 = new double[1];
		  double[] arrayOfDouble15 = new double[1];
		  double[] arrayOfDouble16 = new double[1];
		  double[] arrayOfDouble17 = new double[1];
		  double[] arrayOfDouble18 = new double[1];
		  for (i = 0; i < paramArrayOfDouble1.Length; i++)
		  {
			Array.Copy(paramArrayOfDouble1[i], 0, arrayOfDouble1, i * paramArrayOfDouble1[i].Length, paramArrayOfDouble1[i].Length);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_SNR_waveNumVector_Ptr.in");
			for (sbyte b1 = 0; b1 < paramArrayOfDouble.Length; b1++)
			{
			  bufferedWriter.Write(paramArrayOfDouble[b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException)
		  {
			IOException iOException;
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_SNR_spectrumArray_Ptr.in");
			for (sbyte b1 = 0; b1 < arrayOfDouble1.Length; b1++)
			{
			  bufferedWriter.Write(arrayOfDouble1[b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException)
		  {
			IOException iOException;
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_SNR_lambdaMin.in");
			bufferedWriter.Write(paramDouble1 + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException)
		  {
			IOException iOException;
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_SNR_lambdaMax.in");
			bufferedWriter.Write(paramDouble2 + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException)
		  {
			IOException iOException;
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_SNR_scanningWindowSize.in");
			bufferedWriter.Write(paramDouble3 + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException)
		  {
			IOException iOException;
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_SNR_noRefWavelengths.in");
			bufferedWriter.Write(paramInt + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException)
		  {
			IOException iOException;
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  bool @bool = interferogram_SNR_Measurement(paramArrayOfDouble, arrayOfDouble1, arrayOfDouble1.Length / paramArrayOfDouble.Length, paramArrayOfDouble.Length, paramDouble1, paramDouble2, paramDouble3, paramInt, paramDouble4, arrayOfDouble2, arrayOfDouble3, arrayOfDouble4, arrayOfDouble5, arrayOfDouble6, arrayOfDouble7, arrayOfDouble8, arrayOfDouble9, arrayOfDouble10, arrayOfDouble11, arrayOfDouble12, arrayOfDouble13, arrayOfDouble14, arrayOfDouble15, arrayOfDouble16, arrayOfDouble17, arrayOfDouble18);
		  if (@bool == true)
		  {
			spectrometerDSP_clean();
			throw new Exception("An error occurred in interferogram_SNR_Measurement function! Please contact your vendor for support.");
		  }
		  double[][] arrayOfDouble = new double[17][];
		  arrayOfDouble[0] = arrayOfDouble2;
		  arrayOfDouble[1] = arrayOfDouble3;
		  arrayOfDouble[2] = arrayOfDouble4;
		  arrayOfDouble[3] = arrayOfDouble5;
		  arrayOfDouble[4] = arrayOfDouble6;
		  arrayOfDouble[5] = arrayOfDouble7;
		  arrayOfDouble[6] = arrayOfDouble8;
		  arrayOfDouble[7] = arrayOfDouble9;
		  arrayOfDouble[8] = arrayOfDouble10;
		  arrayOfDouble[9] = arrayOfDouble11;
		  arrayOfDouble[10] = arrayOfDouble12;
		  arrayOfDouble[11] = arrayOfDouble13;
		  arrayOfDouble[12] = arrayOfDouble14;
		  arrayOfDouble[13] = arrayOfDouble15;
		  arrayOfDouble[14] = arrayOfDouble16;
		  arrayOfDouble[15] = arrayOfDouble17;
		  arrayOfDouble[16] = arrayOfDouble18;
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_SNR_waveLengthOutput_Ptr.out");
			for (sbyte b1 = 0; b1 < arrayOfDouble[0].Length; b1++)
			{
			  bufferedWriter.Write(arrayOfDouble[0][b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  for (j = 0; j < paramArrayOfDouble1.Length - 1; j++)
		  {
			try
			{
			  StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_SNR_lines100[" + j + "]_Ptr.out");
			  for (int k = 0; k < paramArrayOfDouble.Length; k++)
			  {
				bufferedWriter.Write(arrayOfDouble[1][j * paramArrayOfDouble.Length + k] + "\n");
			  }
			  bufferedWriter.Close();
			}
			catch (IOException iOException)
			{
			  Console.WriteLine(iOException.ToString());
			  Console.Write(iOException.StackTrace);
			}
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_SNR_SNR_Ptr.out");
			for (sbyte b1 = 0; b1 < arrayOfDouble[2].Length; b1++)
			{
			  bufferedWriter.Write(arrayOfDouble[2][b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException)
		  {
			IOException iOException;
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_SNR_outputs.out");
			bufferedWriter.Write("maxSNR_Ptr : " + arrayOfDouble[3][0] + "\n");
			bufferedWriter.Write("SNR_AT_2p1_Ptr : " + arrayOfDouble[4][0] + "\n");
			bufferedWriter.Write("SNR_AT_1p9_Ptr : " + arrayOfDouble[5][0] + "\n");
			bufferedWriter.Write("SNR_Spread_Ptr : " + arrayOfDouble[6][0] + "\n");
			bufferedWriter.Write("waveRange_10_dB_Ptr : " + arrayOfDouble[7][0] + "\n");
			bufferedWriter.Write("waveRange_3_dB_Ptr : " + arrayOfDouble[8][0] + "\n");
			bufferedWriter.Write("waveRange_100_SNR_Ptr : " + arrayOfDouble[9][0] + "\n");
			bufferedWriter.Write("lambda_2_10_dB_Ptr : " + arrayOfDouble[10][0] + "\n");
			bufferedWriter.Write("lambda_1_10_dB_Ptr : " + arrayOfDouble[11][0] + "\n");
			bufferedWriter.Write("lambda_2_3_dB_Ptr : " + arrayOfDouble[12][0] + "\n");
			bufferedWriter.Write("lambda_1_3_dB_Ptr : " + arrayOfDouble[13][0] + "\n");
			bufferedWriter.Write("lambda_2_100_dB_Ptr : " + arrayOfDouble[14][0] + "\n");
			bufferedWriter.Write("lambda_1_100_dB_Ptr : " + arrayOfDouble[15][0] + "\n");
			bufferedWriter.Write("PSD_2p1_1p2_Ratio_Ptr : " + arrayOfDouble[16][0] + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException)
		  {
			IOException iOException;
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  return arrayOfDouble;
		}
		catch (Exception exception)
		{
		  a a1 = new a();
		  a1.a_Conflict = exception;
		  throw a1;
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public double[][] a(double[] paramArrayOfDouble1, double[][] paramArrayOfDouble, double[] paramArrayOfDouble2, int paramInt) throws a
	  public virtual double[][] a(double[] paramArrayOfDouble1, double[][] paramArrayOfDouble, double[] paramArrayOfDouble2, int paramInt)
	  {
		try
		{
		  double[] arrayOfDouble1 = new double[paramArrayOfDouble.Length * paramArrayOfDouble1.Length];
		  double[] arrayOfDouble2 = new double[paramArrayOfDouble1.Length];
		  double[] arrayOfDouble3 = new double[paramArrayOfDouble.Length];
		  double[] arrayOfDouble4 = new double[paramArrayOfDouble2.Length * paramArrayOfDouble.Length];
		  double[] arrayOfDouble5 = new double[paramArrayOfDouble2.Length * paramArrayOfDouble.Length];
		  double[] arrayOfDouble6 = new double[paramArrayOfDouble2.Length];
		  double[] arrayOfDouble7 = new double[paramArrayOfDouble2.Length];
		  double[] arrayOfDouble8 = new double[paramArrayOfDouble2.Length];
		  for (i = 0; i < paramArrayOfDouble.Length; i++)
		  {
			Array.Copy(paramArrayOfDouble[i], 0, arrayOfDouble1, i * paramArrayOfDouble[i].Length, paramArrayOfDouble[i].Length);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_stability_waveNumVector_Ptr.in");
			for (sbyte b2 = 0; b2 < paramArrayOfDouble1.Length; b2++)
			{
			  bufferedWriter.Write(paramArrayOfDouble1[b2] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException)
		  {
			IOException iOException;
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_stability_spectrumArray_Ptr.in");
			for (sbyte b2 = 0; b2 < arrayOfDouble1.Length; b2++)
			{
			  bufferedWriter.Write(arrayOfDouble1[b2] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException)
		  {
			IOException iOException;
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_stability_referenceWavelengths_Ptr.in");
			for (sbyte b2 = 0; b2 < paramArrayOfDouble2.Length; b2++)
			{
			  bufferedWriter.Write(paramArrayOfDouble2[b2] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException)
		  {
			IOException iOException;
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_stability_wavenumberCorrectionSelection.in");
			bufferedWriter.Write(paramInt + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException)
		  {
			IOException iOException;
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  bool @bool = interferogram_repeatabilityAndStability(arrayOfDouble1, paramArrayOfDouble.Length, paramArrayOfDouble1.Length, paramArrayOfDouble1, paramArrayOfDouble2, paramArrayOfDouble2.Length, paramInt, arrayOfDouble2, arrayOfDouble4, arrayOfDouble5, arrayOfDouble7, arrayOfDouble8);
		  if (@bool == true)
		  {
			spectrometerDSP_clean();
			throw new Exception("An error occurred in interferogram_repeatabilityAndStability function! Please contact your vendor for support.");
		  }
		  double[][] arrayOfDouble = new double[8][];
		  for (b1 = 0; b1 < paramArrayOfDouble.Length; b1++)
		  {
			arrayOfDouble3[b1] = (b1 + true);
		  }
		  Array.Copy(paramArrayOfDouble2, 0, arrayOfDouble6, 0, paramArrayOfDouble2.Length);
		  arrayOfDouble[0] = arrayOfDouble2;
		  arrayOfDouble[1] = arrayOfDouble1;
		  arrayOfDouble[2] = arrayOfDouble3;
		  arrayOfDouble[3] = arrayOfDouble4;
		  arrayOfDouble[4] = arrayOfDouble5;
		  arrayOfDouble[5] = arrayOfDouble6;
		  arrayOfDouble[6] = arrayOfDouble7;
		  arrayOfDouble[7] = arrayOfDouble8;
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_stability_waveLengthOutput_Ptr.out");
			for (sbyte b2 = 0; b2 < arrayOfDouble[0].Length; b2++)
			{
			  bufferedWriter.Write(arrayOfDouble[0][b2] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException)
		  {
			IOException iOException;
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_stability_measNum_Ptr.out");
			for (sbyte b2 = 0; b2 < arrayOfDouble[2].Length; b2++)
			{
			  bufferedWriter.Write(arrayOfDouble[2][b2] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException)
		  {
			IOException iOException;
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_stability_lambdaLines_Ptr.out");
			for (sbyte b2 = 0; b2 < arrayOfDouble[3].Length; b2++)
			{
			  bufferedWriter.Write(arrayOfDouble[3][b2] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException)
		  {
			IOException iOException;
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_stability_B_Lines_Ptr.out");
			for (sbyte b2 = 0; b2 < arrayOfDouble[4].Length; b2++)
			{
			  bufferedWriter.Write(arrayOfDouble[4][b2] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException)
		  {
			IOException iOException;
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_stability_wavelengthError_Ptr.out");
			for (sbyte b2 = 0; b2 < arrayOfDouble[6].Length; b2++)
			{
			  bufferedWriter.Write(arrayOfDouble[6][b2] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException)
		  {
			IOException iOException;
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_stability_absorbanceError_Ptr.out");
			for (sbyte b2 = 0; b2 < arrayOfDouble[7].Length; b2++)
			{
			  bufferedWriter.Write(arrayOfDouble[7][b2] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException)
		  {
			IOException iOException;
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  return arrayOfDouble;
		}
		catch (Exception exception)
		{
		  a a1 = new a();
		  a1.a_Conflict = exception;
		  throw a1;
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public double[][] a(double[] paramArrayOfDouble1, int paramInt1, int paramInt2, int paramInt3, double[] paramArrayOfDouble2, double[] paramArrayOfDouble3, double[] paramArrayOfDouble4, double[] paramArrayOfDouble5) throws a
	  public virtual double[][] a(double[] paramArrayOfDouble1, int paramInt1, int paramInt2, int paramInt3, double[] paramArrayOfDouble2, double[] paramArrayOfDouble3, double[] paramArrayOfDouble4, double[] paramArrayOfDouble5)
	  {
		try
		{
		  double[] arrayOfDouble1 = new double[paramArrayOfDouble4.Length];
		  double[] arrayOfDouble2 = new double[paramArrayOfDouble2.Length];
		  double[] arrayOfDouble3 = new double[paramArrayOfDouble2.Length];
		  bool bool1 = false;
		  bool bool2 = false;
		  bool bool3 = false;
		  if (paramInt3 == 1)
		  {
			bool3 = false;
		  }
		  else
		  {
			bool3 = true;
		  }
		  if (paramInt2 == 1)
		  {
			bool2 = true;
		  }
		  else
		  {
			bool2 = false;
		  }
		  bool bool4 = interferogram_endFFT(bool1, bool2, bool3, paramArrayOfDouble1, paramArrayOfDouble1.Length, paramArrayOfDouble5, paramArrayOfDouble5.Length, paramArrayOfDouble2, paramArrayOfDouble3, paramArrayOfDouble2.Length, paramArrayOfDouble4, paramArrayOfDouble4.Length, arrayOfDouble2, arrayOfDouble3, arrayOfDouble1);
		  if (bool4 == true)
		  {
			spectrometerDSP_clean();
			throw new Exception("An error occurred in interferogram_endFFT function! Please contact your vendor for support.");
		  }
		  double[][] arrayOfDouble = new double[4][];
		  arrayOfDouble[0] = paramArrayOfDouble4;
		  arrayOfDouble[1] = arrayOfDouble1;
		  arrayOfDouble[2] = arrayOfDouble2;
		  arrayOfDouble[3] = arrayOfDouble3;
		  arrayOfDouble1 = null;
		  arrayOfDouble2 = null;
		  arrayOfDouble3 = null;
		  return arrayOfDouble;
		}
		catch (Exception exception)
		{
		  a a1 = new a();
		  a1.a_Conflict = exception;
		  throw a1;
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public double[] a(double[] paramArrayOfDouble1, double[] paramArrayOfDouble2, int paramInt, double paramDouble1, double paramDouble2) throws a
	  public virtual double[] a(double[] paramArrayOfDouble1, double[] paramArrayOfDouble2, int paramInt, double paramDouble1, double paramDouble2)
	  {
		try
		{
		  double[] arrayOfDouble1 = new double[1];
		  double[] arrayOfDouble2 = new double[1];
		  double[] arrayOfDouble3 = new double[1];
		  double[] arrayOfDouble4 = new double[1];
		  double[] arrayOfDouble5 = new double[1];
		  double[] arrayOfDouble6 = new double[1];
		  double[] arrayOfDouble7 = new double[1];
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_capInterp_xADC_Ptr.in");
			for (sbyte b1 = 0; b1 < paramArrayOfDouble1.Length; b1++)
			{
			  bufferedWriter.Write(paramArrayOfDouble1[b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_capInterp_paramConf_Ptr.in");
			for (sbyte b1 = 0; b1 < paramArrayOfDouble2.Length; b1++)
			{
			  bufferedWriter.Write(paramArrayOfDouble2[b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_capInterp_NPS_interpReg.in");
			bufferedWriter.Write(paramInt + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_capInterp_interpThreshold.in");
			bufferedWriter.Write(paramDouble1 + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_capInterp_interpOffset.in");
			bufferedWriter.Write(paramDouble2 + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  bool @bool = capInterp(paramArrayOfDouble1, paramArrayOfDouble1.Length, paramArrayOfDouble2, paramArrayOfDouble2.Length, paramInt, paramDouble1, paramDouble2, arrayOfDouble1, arrayOfDouble2, arrayOfDouble3, arrayOfDouble4, arrayOfDouble5, arrayOfDouble6, arrayOfDouble7);
		  if (@bool == true)
		  {
			spectrometerDSP_clean();
			throw new Exception("An error occurred in capInterp function! Please contact your vendor for support.");
		  }
		  double[] arrayOfDouble8 = new double[7];
		  arrayOfDouble8[0] = arrayOfDouble1[0];
		  arrayOfDouble8[1] = arrayOfDouble2[0];
		  arrayOfDouble8[2] = arrayOfDouble3[0];
		  arrayOfDouble8[3] = arrayOfDouble4[0];
		  arrayOfDouble8[4] = arrayOfDouble5[0];
		  arrayOfDouble8[5] = arrayOfDouble6[0];
		  arrayOfDouble8[6] = arrayOfDouble7[0];
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_capInterp_threshold1_Ptr.out");
			bufferedWriter.Write(arrayOfDouble1[0] + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_capInterp_threshold2_Ptr.out");
			bufferedWriter.Write(arrayOfDouble2[0] + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_capInterp_threshold3_Ptr.out");
			bufferedWriter.Write(arrayOfDouble3[0] + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_capInterp_threshold4_Ptr.out");
			bufferedWriter.Write(arrayOfDouble4[0] + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_capInterp_xInitial_Ptr.out");
			bufferedWriter.Write(arrayOfDouble5[0] + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_capInterp_xStep_Ptr.out");
			bufferedWriter.Write(arrayOfDouble6[0] + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_capInterp_xFinal_Ptr.out");
			bufferedWriter.Write(arrayOfDouble7[0] + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  return arrayOfDouble8;
		}
		catch (Exception exception)
		{
		  a a1 = new a();
		  a1.a_Conflict = exception;
		  throw a1;
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public double[] a(double[] paramArrayOfDouble1, double[] paramArrayOfDouble2, double[] paramArrayOfDouble3, double[] paramArrayOfDouble4, int paramInt1, int paramInt2, boolean paramBoolean, int paramInt3) throws a
	  public virtual double[] a(double[] paramArrayOfDouble1, double[] paramArrayOfDouble2, double[] paramArrayOfDouble3, double[] paramArrayOfDouble4, int paramInt1, int paramInt2, bool paramBoolean, int paramInt3)
	  {
		try
		{
		  int[] arrayOfInt1 = new int[1];
		  int[] arrayOfInt2 = new int[1];
		  bool[] arrayOfBoolean = new bool[1];
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_delay_whiteLightPos.in");
			for (sbyte b1 = 0; b1 < paramArrayOfDouble1.Length; b1++)
			{
			  bufferedWriter.Write(paramArrayOfDouble1[b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_delay_whiteLightNeg.in");
			for (sbyte b1 = 0; b1 < paramArrayOfDouble2.Length; b1++)
			{
			  bufferedWriter.Write(paramArrayOfDouble2[b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_delay_opticalLPF1_Coeff_Ptr.in");
			for (sbyte b1 = 0; b1 < paramArrayOfDouble3.Length; b1++)
			{
			  bufferedWriter.Write(paramArrayOfDouble3[b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_delay_opticalLPF2_Coeff_Ptr.in");
			for (sbyte b1 = 0; b1 < paramArrayOfDouble4.Length; b1++)
			{
			  bufferedWriter.Write(paramArrayOfDouble4[b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_delay_progDlyPrev.in");
			bufferedWriter.Write(paramInt1 + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_delay_zpdSignPrev.in");
			bufferedWriter.Write(paramInt2 + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_delay_binarySearch.in");
			bufferedWriter.BaseStream.WriteByte(paramBoolean + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_delay_currentCount.in");
			bufferedWriter.Write(paramInt3 + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  bool @bool = delayCompSearching(paramArrayOfDouble1, paramArrayOfDouble2, paramArrayOfDouble1.Length, paramArrayOfDouble3, paramArrayOfDouble3.Length, paramArrayOfDouble4, paramArrayOfDouble4.Length, paramInt1, paramInt2, paramBoolean, paramInt3, arrayOfInt1, arrayOfInt2, arrayOfBoolean);
		  if (@bool == true)
		  {
			spectrometerDSP_clean();
			throw new Exception("An error occurred in delayCompSearching function! Please contact your vendor for support.");
		  }
		  double[] arrayOfDouble = new double[3];
		  arrayOfDouble[0] = arrayOfInt1[0];
		  arrayOfDouble[1] = arrayOfInt2[0];
		  if (arrayOfBoolean[0] == true)
		  {
			arrayOfDouble[2] = 1.0D;
		  }
		  else
		  {
			arrayOfDouble[2] = 0.0D;
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_delay_progDlyRegister_Ptr.out");
			bufferedWriter.Write(arrayOfInt1[0] + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_delay_zpdSign_Ptr.out");
			bufferedWriter.Write(arrayOfInt2[0] + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_delay_compFlag_Ptr.out");
			bufferedWriter.BaseStream.WriteByte(arrayOfBoolean[0] + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  return arrayOfDouble;
		}
		catch (Exception exception)
		{
		  a a1 = new a();
		  a1.a_Conflict = exception;
		  throw a1;
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public double[][] a(double[] paramArrayOfDouble1, double[] paramArrayOfDouble2, double[] paramArrayOfDouble3, double[] paramArrayOfDouble4, double[] paramArrayOfDouble5, double[] paramArrayOfDouble6, double[] paramArrayOfDouble7, double[] paramArrayOfDouble8, double[] paramArrayOfDouble9, double[] paramArrayOfDouble10, double[] paramArrayOfDouble11, double paramDouble1, double paramDouble2, double paramDouble3, boolean paramBoolean1, double paramDouble4, double paramDouble5, double paramDouble6, double paramDouble7, int paramInt1, int paramInt2, double paramDouble8, double[] paramArrayOfDouble12, boolean paramBoolean2, double[] paramArrayOfDouble13, int paramInt3) throws a
	  public virtual double[][] a(double[] paramArrayOfDouble1, double[] paramArrayOfDouble2, double[] paramArrayOfDouble3, double[] paramArrayOfDouble4, double[] paramArrayOfDouble5, double[] paramArrayOfDouble6, double[] paramArrayOfDouble7, double[] paramArrayOfDouble8, double[] paramArrayOfDouble9, double[] paramArrayOfDouble10, double[] paramArrayOfDouble11, double paramDouble1, double paramDouble2, double paramDouble3, bool paramBoolean1, double paramDouble4, double paramDouble5, double paramDouble6, double paramDouble7, int paramInt1, int paramInt2, double paramDouble8, double[] paramArrayOfDouble12, bool paramBoolean2, double[] paramArrayOfDouble13, int paramInt3)
	  {
		try
		{
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_Calib_laserReadingPos_Ptr.in");
			for (sbyte b1 = 0; b1 < paramArrayOfDouble1.Length; b1++)
			{
			  bufferedWriter.Write(paramArrayOfDouble1[b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_Calib_laserReadingPosLength.in");
			bufferedWriter.Write(paramArrayOfDouble1.Length + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_Calib_laserReadingNeg_Ptr.in");
			for (sbyte b1 = 0; b1 < paramArrayOfDouble2.Length; b1++)
			{
			  bufferedWriter.Write(paramArrayOfDouble2[b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_Calib_laserReadingNegLength.in");
			bufferedWriter.Write(paramArrayOfDouble2.Length + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_Calib_whiteLightReadingPos_Ptr.in");
			for (sbyte b1 = 0; b1 < paramArrayOfDouble3.Length; b1++)
			{
			  bufferedWriter.Write(paramArrayOfDouble3[b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_Calib_whiteLightReadingLength_Ptr.in");
			bufferedWriter.Write(paramArrayOfDouble3.Length + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_Calib_whiteLightReadingNeg_Ptr.in");
			for (sbyte b1 = 0; b1 < paramArrayOfDouble4.Length; b1++)
			{
			  bufferedWriter.Write(paramArrayOfDouble4[b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_Calib_MC_ReadingPos_Ptr.in");
			for (sbyte b1 = 0; b1 < paramArrayOfDouble5.Length; b1++)
			{
			  bufferedWriter.Write(paramArrayOfDouble5[b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_Calib_MC_ReadingLength_Ptr.in");
			bufferedWriter.Write(paramArrayOfDouble5.Length + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_Calib_MC_ReadingNeg_Ptr.in");
			for (sbyte b1 = 0; b1 < paramArrayOfDouble6.Length; b1++)
			{
			  bufferedWriter.Write(paramArrayOfDouble6[b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_Calib_numFIR_OptInterp_Ptr.in");
			for (sbyte b1 = 0; b1 < paramArrayOfDouble7.Length; b1++)
			{
			  bufferedWriter.Write(paramArrayOfDouble7[b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_Calib_calibrationLPF.in");
			for (sbyte b1 = 0; b1 < paramArrayOfDouble8.Length; b1++)
			{
			  bufferedWriter.Write(paramArrayOfDouble8[b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_Calib_calibrationLPF_Wide.in");
			for (sbyte b1 = 0; b1 < paramArrayOfDouble9.Length; b1++)
			{
			  bufferedWriter.Write(paramArrayOfDouble9[b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_Calib_opticalLPF1_Coeff_Ptr.in");
			for (sbyte b1 = 0; b1 < paramArrayOfDouble10.Length; b1++)
			{
			  bufferedWriter.Write(paramArrayOfDouble10[b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_Calib_opticalLPF2_Coeff_Ptr.in");
			for (sbyte b1 = 0; b1 < paramArrayOfDouble11.Length; b1++)
			{
			  bufferedWriter.Write(paramArrayOfDouble11[b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "successfulPath_SkipMC_DelayComp.config");
			bufferedWriter.Write("input[double]\tDSP_Pre_Calib_laserReadingNeg_Ptr.in\n");
			bufferedWriter.Write("input[double]\tDSP_Pre_Calib_laserReadingPos_Ptr.in\n");
			bufferedWriter.Write("input[double]\tDSP_Pre_Calib_whiteLightReadingNeg_Ptr.in\n");
			bufferedWriter.Write("input[double]\tDSP_Pre_Calib_whiteLightReadingPos_Ptr.in\n");
			bufferedWriter.Write("input[double]\tDSP_Pre_Calib_MC_ReadingNeg_Ptr.in\n");
			bufferedWriter.Write("input[double]\tDSP_Pre_Calib_MC_ReadingPos_Ptr.in\n");
			bufferedWriter.Write("input[double]\tDSP_Pre_Calib_numFIR_OptInterp_Ptr.in\n");
			bufferedWriter.Write("input[double]\tDSP_Pre_Calib_calibrationLPF.in\n");
			bufferedWriter.Write("input[double]\tDSP_Pre_Calib_calibrationLPF_Wide.in\n");
			bufferedWriter.Write("input[double]\tDSP_Pre_Calib_opticalLPF1_Coeff_Ptr.in\n");
			bufferedWriter.Write("input[double]\tDSP_Pre_Calib_opticalLPF2_Coeff_Ptr.in\n");
			bufferedWriter.Write("input[double]\tDSP_Pre_Calib_calibratorWavelengths_Ptr.in\n");
			bufferedWriter.Write("input[double]\tDSP_Pre_Calib_paramConf_Ptr.in\n\n\n");
			bufferedWriter.Write("input(double)\tact_Freq\t" + paramDouble1 + "\n");
			bufferedWriter.Write("input(double)\tI_adc_gain\t\t" + paramDouble2 + "\n");
			bufferedWriter.Write("input(double)\tLambda\t\t" + paramDouble3 + "\n");
			bufferedWriter.Write("input(int)\tSkipMC\t\t" + paramBoolean1 + "\n");
			bufferedWriter.Write("input(double)\tC2VVolt\t\t" + paramDouble4 + "\n");
			bufferedWriter.Write("input(double)\tC2VCFB1\t\t" + paramDouble5 + "\n");
			bufferedWriter.Write("input(double)\tC2VCFB2\t\t" + paramDouble6 + "\n");
			bufferedWriter.Write("input(double)\tNPs_interp_reg\t\t" + paramDouble7 + "\n");
			bufferedWriter.Write("input(int)\tn_slices\t\t" + paramInt1 + "\n");
			bufferedWriter.Write("input(int)\tavg_shift\t\t" + paramInt2 + "\n");
			bufferedWriter.Write("input(double)\tI_X_delay\t\t" + paramDouble8 + "\n");
			bufferedWriter.Write("input(int)\ttwoBurstsEnable\t\t" + paramBoolean2 + "\n");
			bufferedWriter.Write("input(int)\tcorrected_uncorrected\t\t" + paramInt3 + "\n");
			bufferedWriter.Write("input(int)\twl_calib_data_length\t\t10\n\n\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_Calib_paramConf_Ptr.in");
			for (sbyte b1 = 0; b1 < paramArrayOfDouble12.Length; b1++)
			{
			  bufferedWriter.Write(paramArrayOfDouble12[b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_Calib_paramConfLength.in");
			bufferedWriter.Write(paramArrayOfDouble12.Length + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_Calib_calibratorWavelengths_Ptr.in");
			for (sbyte b1 = 0; b1 < paramArrayOfDouble13.Length; b1++)
			{
			  bufferedWriter.Write(paramArrayOfDouble13[b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  double[] arrayOfDouble1 = new double[(int)paramArrayOfDouble12[17] / 2];
		  double[] arrayOfDouble2 = new double[(int)paramArrayOfDouble12[17] / 2];
		  double[] arrayOfDouble3 = new double[(int)paramArrayOfDouble12[17] / 2];
		  double[] arrayOfDouble4 = new double[(int)paramArrayOfDouble12[17] / 2];
		  double[] arrayOfDouble5 = new double[10];
		  double[] arrayOfDouble6 = new double[] {1.0D};
		  double[] arrayOfDouble7 = new double[] {0.0D};
		  int[] arrayOfInt = new int[] {0};
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_Calib_wlCorrectionLength.in");
			bufferedWriter.Write(arrayOfDouble5.Length + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  bool @bool = SpectrometerDSP_Calib(paramArrayOfDouble1, paramArrayOfDouble1.Length, paramArrayOfDouble2, paramArrayOfDouble2.Length, paramArrayOfDouble4, paramArrayOfDouble3, paramArrayOfDouble3.Length, paramArrayOfDouble6, paramArrayOfDouble5, paramArrayOfDouble5.Length, paramArrayOfDouble7, paramArrayOfDouble7.Length, paramArrayOfDouble8, paramArrayOfDouble8.Length, paramArrayOfDouble9, paramArrayOfDouble9.Length, paramArrayOfDouble10, paramArrayOfDouble10.Length, paramArrayOfDouble11, paramArrayOfDouble11.Length, paramDouble1, paramDouble2, paramDouble3, paramBoolean1, paramDouble4, paramDouble5, paramDouble6, paramDouble7, paramInt1, paramInt2, paramDouble8, paramBoolean2, paramArrayOfDouble13, paramArrayOfDouble13.Length, paramInt3, paramArrayOfDouble12.Length, arrayOfDouble5.Length, paramArrayOfDouble12, arrayOfDouble5, arrayOfDouble1, arrayOfDouble2, arrayOfDouble3, arrayOfDouble4, arrayOfInt, arrayOfDouble6, arrayOfDouble7);
		  if (@bool == true)
		  {
			spectrometerDSP_clean();
			throw new Exception("An error occurred in SpectrometerDSP_Calib function! Please contact your vendor for support.");
		  }
		  double[][] arrayOfDouble = new double[7][];
		  arrayOfDouble[0] = new double[arrayOfInt[0]];
		  arrayOfDouble[1] = new double[arrayOfInt[0]];
		  arrayOfDouble[2] = new double[arrayOfInt[0]];
		  arrayOfDouble[3] = new double[arrayOfInt[0]];
		  arrayOfDouble[4] = new double[arrayOfDouble5.Length];
		  arrayOfDouble[5] = new double[arrayOfDouble6.Length + arrayOfDouble7.Length];
		  arrayOfDouble[6] = new double[paramArrayOfDouble12.Length];
		  Array.Copy(arrayOfDouble1, 0, arrayOfDouble[0], 0, arrayOfInt[0]);
		  Array.Copy(arrayOfDouble2, 0, arrayOfDouble[1], 0, arrayOfInt[0]);
		  Array.Copy(arrayOfDouble3, 0, arrayOfDouble[2], 0, arrayOfInt[0]);
		  Array.Copy(arrayOfDouble4, 0, arrayOfDouble[3], 0, arrayOfInt[0]);
		  Array.Copy(arrayOfDouble5, 0, arrayOfDouble[4], 0, arrayOfDouble5.Length);
		  arrayOfDouble[5][0] = arrayOfDouble6[0];
		  arrayOfDouble[5][1] = arrayOfDouble7[0];
		  Array.Copy(paramArrayOfDouble12, 0, arrayOfDouble[6], 0, paramArrayOfDouble12.Length);
		  arrayOfDouble1 = null;
		  arrayOfDouble2 = null;
		  arrayOfDouble3 = null;
		  arrayOfDouble4 = null;
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "successfulPath_SkipMC_DelayComp.config", true));
			bufferedWriter.Write("output[double]\t\tDSP_Post_Calib_param_conf.out\n");
			bufferedWriter.Write("output[double]\t" + b_Conflict + "\n");
			bufferedWriter.Write("output[double]\tDSP_Post_Calib_x_vect.out\n");
			bufferedWriter.Write("output[double]\tDSP_Post_Calib_C_vneg_vect.out\n");
			bufferedWriter.Write("output[double]\tDSP_Post_Calib_C_vpos_vect.out\n");
			bufferedWriter.Write("output[double]\tDSP_Post_Calib_C_diff_vect.out\n");
			bufferedWriter.Write("output(int)\tDSP_Post_Calib_calib_vector_length\t" + arrayOfDouble[1].Length + "\n");
			bufferedWriter.Write("output(double)\tDSP_Post_Calib_calib_A_Corr\t" + arrayOfDouble[5][0] + "\n");
			bufferedWriter.Write("output(double)\tDSP_Post_Calib_calib_B_Corr\t" + arrayOfDouble[5][1] + "\n");
			bufferedWriter.Write("error[rms]\t0.001\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_Calib_x_vect.out");
			for (sbyte b1 = 0; b1 < arrayOfDouble[0].Length; b1++)
			{
			  bufferedWriter.Write(arrayOfDouble[0][b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_Calib_C_vneg_vect.out");
			for (sbyte b1 = 0; b1 < arrayOfDouble[1].Length; b1++)
			{
			  bufferedWriter.Write(arrayOfDouble[1][b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_Calib_C_vpos_vect.out");
			for (sbyte b1 = 0; b1 < arrayOfDouble[2].Length; b1++)
			{
			  bufferedWriter.Write(arrayOfDouble[2][b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_Calib_C_diff_vect.out");
			for (sbyte b1 = 0; b1 < arrayOfDouble[3].Length; b1++)
			{
			  bufferedWriter.Write(arrayOfDouble[3][b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + b_Conflict);
			for (sbyte b1 = 0; b1 < arrayOfDouble[4].Length; b1++)
			{
			  bufferedWriter.Write(arrayOfDouble[4][b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_Calib_Corr.out");
			for (sbyte b1 = 0; b1 < arrayOfDouble[5].Length; b1++)
			{
			  bufferedWriter.Write(arrayOfDouble[5][b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_Calib_param_conf.out");
			for (sbyte b1 = 0; b1 < arrayOfDouble[6].Length; b1++)
			{
			  bufferedWriter.Write(arrayOfDouble[6][b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  return arrayOfDouble;
		}
		catch (Exception exception)
		{
		  a a1 = new a();
		  a1.a_Conflict = exception;
		  throw a1;
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public double[][] a(double[] paramArrayOfDouble1, double[] paramArrayOfDouble2, double[] paramArrayOfDouble3, double paramDouble1, double paramDouble2, double paramDouble3, double paramDouble4) throws a
	  public virtual double[][] a(double[] paramArrayOfDouble1, double[] paramArrayOfDouble2, double[] paramArrayOfDouble3, double paramDouble1, double paramDouble2, double paramDouble3, double paramDouble4)
	  {
		try
		{
		  double[] arrayOfDouble1 = new double[paramArrayOfDouble1.Length];
		  double[] arrayOfDouble2 = new double[paramArrayOfDouble1.Length];
		  double[] arrayOfDouble3 = new double[paramArrayOfDouble2.Length];
		  double[] arrayOfDouble4 = new double[paramArrayOfDouble2.Length];
		  double[] arrayOfDouble5 = new double[paramArrayOfDouble1.Length / 2];
		  double[] arrayOfDouble6 = new double[paramArrayOfDouble1.Length / 2];
		  double[] arrayOfDouble7 = new double[paramArrayOfDouble2.Length / 2];
		  double[] arrayOfDouble8 = new double[paramArrayOfDouble2.Length / 2];
		  double[] arrayOfDouble9 = new double[paramArrayOfDouble1.Length];
		  double[] arrayOfDouble10 = new double[paramArrayOfDouble1.Length];
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_Cap_x_adc_Ptr.in");
			for (sbyte b1 = 0; b1 < paramArrayOfDouble1.Length; b1++)
			{
			  bufferedWriter.Write(paramArrayOfDouble1[b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_Cap_I_adc_Ptr.in");
			for (sbyte b1 = 0; b1 < paramArrayOfDouble2.Length; b1++)
			{
			  bufferedWriter.Write(paramArrayOfDouble2[b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_Cap_paramConf_Ptr.in");
			for (sbyte b1 = 0; b1 < paramArrayOfDouble3.Length; b1++)
			{
			  bufferedWriter.Write(paramArrayOfDouble3[b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_Cap_I_ADC_gain.in");
			bufferedWriter.Write(paramDouble1 + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_Cap_C2VExcVoltage.in");
			bufferedWriter.Write(paramDouble2 + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_Cap_C2VCFB1.in");
			bufferedWriter.Write(paramDouble3 + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_Cap_C2VCFB2.in");
			bufferedWriter.Write(paramDouble4 + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  bool @bool = SpectrometerDSP_capAndCurrent(paramArrayOfDouble1, paramArrayOfDouble1.Length, paramArrayOfDouble2, paramArrayOfDouble2.Length, paramArrayOfDouble3, paramArrayOfDouble3.Length, paramDouble1, paramDouble2, paramDouble3, paramDouble4, arrayOfDouble1, arrayOfDouble2, arrayOfDouble3, arrayOfDouble4, arrayOfDouble5, arrayOfDouble6, arrayOfDouble7, arrayOfDouble8, arrayOfDouble9, arrayOfDouble10);
		  if (@bool == true)
		  {
			spectrometerDSP_clean();
			throw new Exception("An error occurred in SpectrometerDSP_capAndCurrent function! Please contact your vendor for support.");
		  }
		  double[][] arrayOfDouble = new double[12][];
		  arrayOfDouble[0] = arrayOfDouble2;
		  arrayOfDouble[1] = paramArrayOfDouble1;
		  arrayOfDouble[2] = arrayOfDouble4;
		  arrayOfDouble[3] = paramArrayOfDouble2;
		  arrayOfDouble[4] = arrayOfDouble6;
		  arrayOfDouble[5] = arrayOfDouble5;
		  arrayOfDouble[6] = arrayOfDouble8;
		  arrayOfDouble[7] = arrayOfDouble7;
		  arrayOfDouble[8] = arrayOfDouble10;
		  arrayOfDouble[9] = arrayOfDouble9;
		  arrayOfDouble[10] = arrayOfDouble1;
		  arrayOfDouble[11] = arrayOfDouble3;
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_Cap_0.out");
			for (sbyte b1 = 0; b1 < arrayOfDouble[0].Length; b1++)
			{
			  bufferedWriter.Write(arrayOfDouble[0][b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_Cap_1.out");
			for (sbyte b1 = 0; b1 < arrayOfDouble[1].Length; b1++)
			{
			  bufferedWriter.Write(arrayOfDouble[1][b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_Cap_2.out");
			for (sbyte b1 = 0; b1 < arrayOfDouble[2].Length; b1++)
			{
			  bufferedWriter.Write(arrayOfDouble[2][b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_Cap_3.out");
			for (sbyte b1 = 0; b1 < arrayOfDouble[3].Length; b1++)
			{
			  bufferedWriter.Write(arrayOfDouble[3][b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_Cap_4.out");
			for (sbyte b1 = 0; b1 < arrayOfDouble[4].Length; b1++)
			{
			  bufferedWriter.Write(arrayOfDouble[4][b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_Cap_5.out");
			for (sbyte b1 = 0; b1 < arrayOfDouble[5].Length; b1++)
			{
			  bufferedWriter.Write(arrayOfDouble[5][b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_Cap_6.out");
			for (sbyte b1 = 0; b1 < arrayOfDouble[6].Length; b1++)
			{
			  bufferedWriter.Write(arrayOfDouble[6][b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_Cap_7.out");
			for (sbyte b1 = 0; b1 < arrayOfDouble[7].Length; b1++)
			{
			  bufferedWriter.Write(arrayOfDouble[7][b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_Cap_8.out");
			for (sbyte b1 = 0; b1 < arrayOfDouble[8].Length; b1++)
			{
			  bufferedWriter.Write(arrayOfDouble[8][b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_Cap_9.out");
			for (sbyte b1 = 0; b1 < arrayOfDouble[9].Length; b1++)
			{
			  bufferedWriter.Write(arrayOfDouble[9][b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_Cap_10.out");
			for (sbyte b1 = 0; b1 < arrayOfDouble[10].Length; b1++)
			{
			  bufferedWriter.Write(arrayOfDouble[10][b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_Cap_11.out");
			for (sbyte b1 = 0; b1 < arrayOfDouble[11].Length; b1++)
			{
			  bufferedWriter.Write(arrayOfDouble[11][b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  return arrayOfDouble;
		}
		catch (Exception exception)
		{
		  a a1 = new a();
		  a1.a_Conflict = exception;
		  throw a1;
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void a(double[] paramArrayOfDouble) throws a
	  public virtual void a(double[] paramArrayOfDouble)
	  {
		try
		{
		  if (!g)
		  {
			try
			{
			  StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_CL_Initialization_paramConf_Ptr.in");
			  for (sbyte b1 = 0; b1 < paramArrayOfDouble.Length; b1++)
			  {
				bufferedWriter.Write(paramArrayOfDouble[b1] + "\n");
			  }
			  bufferedWriter.Close();
			}
			catch (IOException iOException)
			{
			  Console.WriteLine(iOException.ToString());
			  Console.Write(iOException.StackTrace);
			}
			bool @bool = abstractClosedLoop_closedLoop_initialization(paramArrayOfDouble, paramArrayOfDouble.Length);
			if (@bool == true)
			{
			  spectrometerDSP_clean();
			  throw new Exception("An error occurred in abstractClosedLoop_closedLoop_initialization function! Please contact your vendor for support.");
			}
			g = true;
		  }
		  return;
		}
		catch (Exception exception)
		{
		  a a1 = new a();
		  a1.a_Conflict = exception;
		  throw a1;
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public double[][] b(double[] paramArrayOfDouble) throws a
	  public virtual double[][] b(double[] paramArrayOfDouble)
	  {
		try
		{
		  double[] arrayOfDouble = new double[1];
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_CL_MEMSResponse_CapLpf_Ptr.in");
			for (sbyte b1 = 0; b1 < paramArrayOfDouble.Length; b1++)
			{
			  bufferedWriter.Write(paramArrayOfDouble[b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  bool @bool = abstractClosedLoop_closedLoop_capAmpCalc(paramArrayOfDouble, paramArrayOfDouble.Length, arrayOfDouble);
		  if (@bool == true)
		  {
			spectrometerDSP_clean();
			throw new Exception("An error occurred in abstractClosedLoop_closedLoop_capAmpCalc function! Please contact your vendor for support.");
		  }
		  double[][] arrayOfDouble1 = {new double[1]};
		  arrayOfDouble1[0][0] = arrayOfDouble[0];
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_CL_MEMSResponse_CapAmp_Ptr.out");
			bufferedWriter.Write(arrayOfDouble[0] + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  return arrayOfDouble1;
		}
		catch (Exception exception)
		{
		  a a1 = new a();
		  a1.a_Conflict = exception;
		  throw a1;
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public double[][] a(double[] paramArrayOfDouble, double paramDouble1, double paramDouble2, double paramDouble3, double paramDouble4) throws a
	  public virtual double[][] a(double[] paramArrayOfDouble, double paramDouble1, double paramDouble2, double paramDouble3, double paramDouble4)
	  {
		try
		{
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_CL_PreProcessing_CapLpf_Ptr.in");
			for (sbyte b1 = 0; b1 < paramArrayOfDouble.Length; b1++)
			{
			  bufferedWriter.Write(paramArrayOfDouble[b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_CL_PreProcessing_V_reference.in");
			bufferedWriter.Write(paramDouble1 + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_CL_PreProcessing_CFB1.in");
			bufferedWriter.Write(paramDouble2 + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_CL_PreProcessing_CFB2.in");
			bufferedWriter.Write(paramDouble3 + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_CL_PreProcessing_opticalADC_gain.in");
			bufferedWriter.Write(paramDouble4 + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  bool @bool = abstractClosedLoop_closedLoop_signalPreprocessing(paramArrayOfDouble.Length, paramDouble4, paramDouble1, paramDouble2, paramDouble3, paramArrayOfDouble);
		  if (@bool == true)
		  {
			spectrometerDSP_clean();
			throw new Exception("An error occurred in abstractClosedLoop_closedLoop_signalPreprocessing function! Please contact your vendor for support.");
		  }
		  double[][] arrayOfDouble = new double[1][];
		  arrayOfDouble[0] = paramArrayOfDouble;
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_CL_PreProcessing_NormCapLpf_Ptr.out");
			bufferedWriter.Write(paramArrayOfDouble[0] + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  return arrayOfDouble;
		}
		catch (Exception exception)
		{
		  a a1 = new a();
		  a1.a_Conflict = exception;
		  throw a1;
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public double[][] c(double[] paramArrayOfDouble) throws a
	  public virtual double[][] c(double[] paramArrayOfDouble)
	  {
		try
		{
		  double[] arrayOfDouble1 = new double[1];
		  double[] arrayOfDouble2 = new double[1];
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_CL_ParametersCalc_ResFreqAndQualityFactor_stepResponse_Ptr.in");
			for (sbyte b1 = 0; b1 < paramArrayOfDouble.Length; b1++)
			{
			  bufferedWriter.Write(paramArrayOfDouble[b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  bool @bool = abstractClosedLoop_closedLoop_memsParametersDetection(paramArrayOfDouble, paramArrayOfDouble.Length, arrayOfDouble1, arrayOfDouble2);
		  if (@bool == true)
		  {
			spectrometerDSP_clean();
			throw new Exception("An error occurred in abstractClosedLoop_closedLoop_memsParametersDetection function! Please contact your vendor for support.");
		  }
		  double[][] arrayOfDouble = {new double[1], new double[1]};
		  arrayOfDouble[0][0] = arrayOfDouble1[0];
		  arrayOfDouble[1][0] = arrayOfDouble2[0];
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_CL_ParametersCalc_ResFreqAndQualityFactor_fres_Ptr.out");
			bufferedWriter.Write(arrayOfDouble1[0] + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_CL_ParametersCalc_ResFreqAndQualityFactor_qualityFactor_Ptr.out");
			bufferedWriter.Write(arrayOfDouble2[0] + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  return arrayOfDouble;
		}
		catch (Exception exception)
		{
		  a a1 = new a();
		  a1.a_Conflict = exception;
		  throw a1;
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public double[][] b(double[] paramArrayOfDouble, double paramDouble1, double paramDouble2, double paramDouble3, double paramDouble4) throws a
	  public virtual double[][] b(double[] paramArrayOfDouble, double paramDouble1, double paramDouble2, double paramDouble3, double paramDouble4)
	  {
		try
		{
		  double[] arrayOfDouble = new double[1];
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_CL_ParametersCalc_ForwardGain_x_adc_Ptr.in");
			for (sbyte b1 = 0; b1 < paramArrayOfDouble.Length; b1++)
			{
			  bufferedWriter.Write(paramArrayOfDouble[b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_CL_ParametersCalc_ForwardGain_V_reference.in");
			bufferedWriter.Write(paramDouble1 + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_CL_ParametersCalc_ForwardGain_CFB1.in");
			bufferedWriter.Write(paramDouble3 + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_CL_ParametersCalc_ForwardGain_CFB2.in");
			bufferedWriter.Write(paramDouble4 + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  bool @bool = abstractClosedLoop_closedLoop_fwdGainCalc(paramArrayOfDouble, paramArrayOfDouble.Length, paramDouble1, paramDouble3, paramDouble4, paramDouble2, arrayOfDouble);
		  if (@bool == true)
		  {
			spectrometerDSP_clean();
			throw new Exception("An error occurred in abstractClosedLoop_closedLoop_fwdGainCalc function! Please contact your vendor for support.");
		  }
		  double[][] arrayOfDouble1 = {new double[1]};
		  arrayOfDouble1[0][0] = arrayOfDouble[0];
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_CL_ParametersCalc_ForwardGain_fwdGain_Ptr.out");
			bufferedWriter.Write(arrayOfDouble[0] + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  return arrayOfDouble1;
		}
		catch (Exception exception)
		{
		  a a1 = new a();
		  a1.a_Conflict = exception;
		  throw a1;
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public double[][] a(double paramDouble1, double paramDouble2, double paramDouble3, double paramDouble4, double[] paramArrayOfDouble1, double[] paramArrayOfDouble2, double paramDouble5) throws a
	  public virtual double[][] a(double paramDouble1, double paramDouble2, double paramDouble3, double paramDouble4, double[] paramArrayOfDouble1, double[] paramArrayOfDouble2, double paramDouble5)
	  {
		try
		{
		  double[] arrayOfDouble1 = new double[1];
		  double[] arrayOfDouble2 = new double[1];
		  double[] arrayOfDouble3 = new double[1];
		  double[] arrayOfDouble4 = new double[1];
		  double[] arrayOfDouble5 = new double[1];
		  double[] arrayOfDouble6 = new double[1];
		  double[] arrayOfDouble7 = new double[1];
		  double[] arrayOfDouble8 = new double[1];
		  double[] arrayOfDouble9 = new double[1];
		  double[] arrayOfDouble10 = new double[1];
		  double[] arrayOfDouble11 = new double[1];
		  double[] arrayOfDouble12 = new double[1];
		  double[] arrayOfDouble13 = new double[1];
		  double[] arrayOfDouble14 = new double[1];
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_CL_CoefficientsCalculation_targetCap.in");
			bufferedWriter.Write(paramDouble1 + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_CL_CoefficientsCalculation_fres.in");
			bufferedWriter.Write(paramDouble2 + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_CL_CoefficientsCalculation_fwdGain.in");
			bufferedWriter.Write(paramDouble4 + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_CL_CoefficientsCalculation_freqVal_Ptr.in");
			for (sbyte b1 = 0; b1 < paramArrayOfDouble1.Length; b1++)
			{
			  bufferedWriter.Write(paramArrayOfDouble1[b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_CL_CoefficientsCalculation_gainVal_Ptr.in");
			for (sbyte b1 = 0; b1 < paramArrayOfDouble2.Length; b1++)
			{
			  bufferedWriter.Write(paramArrayOfDouble2[b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_CL_CoefficientsCalculation_V_reference.in");
			bufferedWriter.Write(paramDouble5 + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  bool @bool = abstractClosedLoop_closedLoop_loopCoefficientsCalc(paramDouble1, paramDouble2, paramDouble3, paramDouble4, paramArrayOfDouble1, paramArrayOfDouble2, paramArrayOfDouble1.Length, paramDouble5, arrayOfDouble1, arrayOfDouble2, arrayOfDouble3, arrayOfDouble4, arrayOfDouble5, arrayOfDouble6, arrayOfDouble7, arrayOfDouble8, arrayOfDouble9, arrayOfDouble10, arrayOfDouble11, arrayOfDouble12, arrayOfDouble13, arrayOfDouble14);
		  if (@bool == true)
		  {
			spectrometerDSP_clean();
			throw new Exception("An error occurred in abstractClosedLoop_closedLoop_loopCoefficientsCalc function! Please contact your vendor for support.");
		  }
//JAVA TO C# CONVERTER NOTE: The following call to the 'RectangularArrays' helper class reproduces the rectangular array initialization that is automatic in Java:
//ORIGINAL LINE: double[][] arrayOfDouble = new double[14][1];
		  double[][] arrayOfDouble = RectangularArrays.RectangularDoubleArray(14, 1);
		  arrayOfDouble[0][0] = arrayOfDouble1[0];
		  arrayOfDouble[1][0] = arrayOfDouble2[0];
		  arrayOfDouble[2][0] = arrayOfDouble3[0];
		  arrayOfDouble[3][0] = arrayOfDouble4[0];
		  arrayOfDouble[4][0] = arrayOfDouble5[0];
		  arrayOfDouble[5][0] = arrayOfDouble6[0];
		  arrayOfDouble[6][0] = arrayOfDouble7[0];
		  arrayOfDouble[7][0] = arrayOfDouble8[0];
		  arrayOfDouble[8][0] = arrayOfDouble9[0];
		  arrayOfDouble[9][0] = arrayOfDouble10[0];
		  arrayOfDouble[10][0] = arrayOfDouble11[0];
		  arrayOfDouble[11][0] = arrayOfDouble12[0];
		  arrayOfDouble[12][0] = arrayOfDouble13[0];
		  arrayOfDouble[13][0] = arrayOfDouble14[0];
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_CL_CoefficientsCalculation_Kp_Ptr.out");
			bufferedWriter.Write(arrayOfDouble1[0] + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_CL_CoefficientsCalculation_Ki_Ptr.out");
			bufferedWriter.Write(arrayOfDouble2[0] + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_CL_CoefficientsCalculation_phaseInitRegVal_Ptr.out");
			bufferedWriter.Write(arrayOfDouble3[0] + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_CL_CoefficientsCalculation_c2vcfb1RegVal_Ptr.out");
			bufferedWriter.Write(arrayOfDouble4[0] + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_CL_CoefficientsCalculation_c2vcfb2RegVal_Ptr.out");
			bufferedWriter.Write(arrayOfDouble5[0] + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_CL_CoefficientsCalculation_actualC2vGain_Ptr.out");
			bufferedWriter.Write(arrayOfDouble6[0] + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_CL_CoefficientsCalculation_drvAmpRegVal_Ptr.out");
			bufferedWriter.Write(arrayOfDouble7[0] + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_CL_CoefficientsCalculation_drvAmp_Ptr.out");
			bufferedWriter.Write(arrayOfDouble8[0] + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_CL_CoefficientsCalculation_envDetLpfRegVal_Ptr.out");
			bufferedWriter.Write(arrayOfDouble9[0] + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_CL_CoefficientsCalculation_envDetLpfBw_Ptr.out");
			bufferedWriter.Write(arrayOfDouble10[0] + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_CL_CoefficientsCalculation_KpRegVal_Ptr.out");
			bufferedWriter.Write(arrayOfDouble11[0] + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_CL_CoefficientsCalculation_KdigRegVal_Ptr.out");
			bufferedWriter.Write(arrayOfDouble12[0] + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_CL_CoefficientsCalculation_Kdig_Ptr.out");
			bufferedWriter.Write(arrayOfDouble13[0] + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_CL_CoefficientsCalculation_KiRegVal_Ptr.out");
			bufferedWriter.Write(arrayOfDouble14[0] + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  return arrayOfDouble;
		}
		catch (Exception exception)
		{
		  a a1 = new a();
		  a1.a_Conflict = exception;
		  throw a1;
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public double[][] a(double paramDouble1, double paramDouble2) throws a
	  public virtual double[][] a(double paramDouble1, double paramDouble2)
	  {
		try
		{
		  double[] arrayOfDouble = new double[1];
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_CL_PhaseTrimming_PhaseConversion_inPhase.in");
			bufferedWriter.Write(paramDouble1 + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_CL_PhaseTrimming_PhaseConversion_fres.in");
			bufferedWriter.Write(paramDouble2 + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  bool @bool = abstractClosedLoop_closedLoop_phaseConversion(paramDouble1, paramDouble2, arrayOfDouble);
		  if (@bool == true)
		  {
			spectrometerDSP_clean();
			throw new Exception("An error occurred in abstractClosedLoop_closedLoop_phaseConversion function! Please contact your vendor for support.");
		  }
		  double[][] arrayOfDouble1 = {new double[1]};
		  arrayOfDouble1[0][0] = arrayOfDouble[0];
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_CL_PhaseTrimming_PhaseConversion_phaseShiftRegVal_Ptr.out");
			bufferedWriter.Write(arrayOfDouble[0] + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  return arrayOfDouble1;
		}
		catch (Exception exception)
		{
		  a a1 = new a();
		  a1.a_Conflict = exception;
		  throw a1;
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public double[][] a(double[] paramArrayOfDouble1, double[] paramArrayOfDouble2, double paramDouble) throws a
	  public virtual double[][] a(double[] paramArrayOfDouble1, double[] paramArrayOfDouble2, double paramDouble)
	  {
		try
		{
		  double[] arrayOfDouble = new double[1];
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_CL_PhaseTrimming_PhaseValidation_aacOut_Ptr.in");
			for (sbyte b1 = 0; b1 < paramArrayOfDouble1.Length; b1++)
			{
			  bufferedWriter.Write(paramArrayOfDouble1[b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_CL_PhaseTrimming_PhaseValidation_capLpf_Ptr.in");
			for (sbyte b1 = 0; b1 < paramArrayOfDouble2.Length; b1++)
			{
			  bufferedWriter.Write(paramArrayOfDouble2[b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  bool @bool = abstractClosedLoop_closedLoop_phaseValidation(paramArrayOfDouble1, paramArrayOfDouble1.Length, paramArrayOfDouble2, paramArrayOfDouble2.Length, paramDouble, arrayOfDouble);
		  if (@bool == true)
		  {
			spectrometerDSP_clean();
			throw new Exception("An error occurred in abstractClosedLoop_closedLoop_phaseValidation function! Please contact your vendor for support.");
		  }
		  double[][] arrayOfDouble1 = {new double[1]};
		  arrayOfDouble1[0][0] = arrayOfDouble[0];
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_CL_PhaseTrimming_PhaseValidation_validPhase_Ptr.out");
			bufferedWriter.Write(arrayOfDouble[0] + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  return arrayOfDouble1;
		}
		catch (Exception exception)
		{
		  a a1 = new a();
		  a1.a_Conflict = exception;
		  throw a1;
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public double[][] a(double[] paramArrayOfDouble1, double[] paramArrayOfDouble2, double[] paramArrayOfDouble3) throws a
	  public virtual double[][] a(double[] paramArrayOfDouble1, double[] paramArrayOfDouble2, double[] paramArrayOfDouble3)
	  {
		try
		{
		  double[][] arrayOfDouble;
		  double[] arrayOfDouble1 = new double[paramArrayOfDouble2.Length];
		  double[] arrayOfDouble2 = new double[paramArrayOfDouble2.Length];
		  int[] arrayOfInt = new int[1];
		  double[] arrayOfDouble3 = new double[1];
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_CL_PhaseTrimming_OptimumPhaseDetection_phaseReq_Ptr.in");
			for (sbyte b1 = 0; b1 < paramArrayOfDouble1.Length; b1++)
			{
			  bufferedWriter.Write(paramArrayOfDouble1[b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_CL_PhaseTrimming_OptimumPhaseDetection_aacOut_Ptr.in");
			for (sbyte b1 = 0; b1 < paramArrayOfDouble2.Length; b1++)
			{
			  bufferedWriter.Write(paramArrayOfDouble2[b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_CL_PhaseTrimming_OptimumPhaseDetection_phasePattern_Ptr.in");
			for (sbyte b1 = 0; b1 < paramArrayOfDouble3.Length; b1++)
			{
			  bufferedWriter.Write(paramArrayOfDouble3[b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  bool @bool = abstractClosedLoop_closedLoop_optimumPhaseDetection(paramArrayOfDouble1, paramArrayOfDouble2, paramArrayOfDouble3, paramArrayOfDouble2.Length, arrayOfDouble1, arrayOfDouble2, arrayOfInt, arrayOfDouble3);
		  if (@bool == true)
		  {
			spectrometerDSP_clean();
			throw new Exception("An error occurred in abstractClosedLoop_closedLoop_optimumPhaseDetection function! Please contact your vendor for support.");
		  }
		  if (arrayOfInt[0] == 0)
		  {
			arrayOfDouble = {new double[1], new double[1], new double[1]};
			arrayOfDouble[0][0] = arrayOfDouble3[0];
			arrayOfDouble[1][0] = 0.0D;
			arrayOfDouble[2][0] = 0.0D;
		  }
		  else
		  {
			arrayOfDouble = {new double[arrayOfInt[0]], new double[arrayOfInt[0]], new double[arrayOfInt[0]]};
			arrayOfDouble[0][0] = arrayOfDouble3[0];
			for (sbyte b1 = 0; b1 < arrayOfInt[0]; b1++)
			{
			  arrayOfDouble[1][b1] = arrayOfDouble1[b1];
			  arrayOfDouble[2][b1] = arrayOfDouble2[b1];
			}
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_CL_PhaseTrimming_OptimumPhaseDetection_validPhases_Ptr.out");
			for (sbyte b1 = 0; b1 < arrayOfInt[0]; b1++)
			{
			  bufferedWriter.Write(arrayOfDouble1[b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_CL_PhaseTrimming_OptimumPhaseDetection_validAACOUT_Ptr.out");
			for (sbyte b1 = 0; b1 < arrayOfInt[0]; b1++)
			{
			  bufferedWriter.Write(arrayOfDouble2[b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_CL_PhaseTrimming_OptimumPhaseDetection_optimumPhase_Ptr.out");
			bufferedWriter.Write(arrayOfDouble3[0] + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  return arrayOfDouble;
		}
		catch (Exception exception)
		{
		  a a1 = new a();
		  a1.a_Conflict = exception;
		  throw a1;
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public double[][] a(double[] paramArrayOfDouble1, double[] paramArrayOfDouble2) throws a
	  public virtual double[][] a(double[] paramArrayOfDouble1, double[] paramArrayOfDouble2)
	  {
		try
		{
		  double[][] arrayOfDouble;
		  double[] arrayOfDouble1 = new double[1000];
		  double[] arrayOfDouble2 = new double[1000];
		  int[] arrayOfInt = new int[1];
		  double[] arrayOfDouble3 = new double[1];
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_CL_FastPhaseTrimming_OptimumPhaseDetection_phaseReq_Ptr.in");
			for (sbyte b1 = 0; b1 < paramArrayOfDouble1.Length; b1++)
			{
			  bufferedWriter.Write(paramArrayOfDouble1[b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_CL_FastPhaseTrimming_OptimumPhaseDetection_aacOut_Ptr.in");
			for (sbyte b1 = 0; b1 < paramArrayOfDouble2.Length; b1++)
			{
			  bufferedWriter.Write(paramArrayOfDouble2[b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  bool @bool = abstractClosedLoop_closedLoop_optimumPhaseDetectionFast(paramArrayOfDouble1, paramArrayOfDouble2, paramArrayOfDouble2.Length, arrayOfDouble1, arrayOfDouble2, arrayOfInt, arrayOfDouble3);
		  if (@bool == true)
		  {
			spectrometerDSP_clean();
			throw new Exception("An error occurred in abstractClosedLoop_closedLoop_optimumPhaseDetectionFast function! Please contact your vendor for support.");
		  }
		  if (arrayOfInt[0] == 0)
		  {
			arrayOfDouble = {new double[1], new double[1], new double[1]};
			arrayOfDouble[0][0] = arrayOfDouble3[0];
			arrayOfDouble[1][0] = 0.0D;
			arrayOfDouble[2][0] = 0.0D;
		  }
		  else
		  {
			arrayOfDouble = {new double[arrayOfInt[0]], new double[arrayOfInt[0]], new double[arrayOfInt[0]]};
			arrayOfDouble[0][0] = arrayOfDouble3[0];
			for (sbyte b1 = 0; b1 < arrayOfInt[0]; b1++)
			{
			  arrayOfDouble[1][b1] = arrayOfDouble1[b1];
			  arrayOfDouble[2][b1] = arrayOfDouble2[b1];
			}
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_CL_FastPhaseTrimming_OptimumPhaseDetection_validPhases_Ptr.out");
			for (sbyte b1 = 0; b1 < arrayOfInt[0]; b1++)
			{
			  bufferedWriter.Write(arrayOfDouble1[b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_CL_FastPhaseTrimming_OptimumPhaseDetection_validAACOUT_Ptr.out");
			for (sbyte b1 = 0; b1 < arrayOfInt[0]; b1++)
			{
			  bufferedWriter.Write(arrayOfDouble2[b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_CL_FastPhaseTrimming_OptimumPhaseDetection_optimumPhase_Ptr.out");
			bufferedWriter.Write(arrayOfDouble3[0] + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  return arrayOfDouble;
		}
		catch (Exception exception)
		{
		  a a1 = new a();
		  a1.a_Conflict = exception;
		  throw a1;
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public double[][] a(double[] paramArrayOfDouble1, double[] paramArrayOfDouble2, double paramDouble1, double paramDouble2, double paramDouble3, double paramDouble4) throws a
	  public virtual double[][] a(double[] paramArrayOfDouble1, double[] paramArrayOfDouble2, double paramDouble1, double paramDouble2, double paramDouble3, double paramDouble4)
	  {
		try
		{
		  double[] arrayOfDouble1 = new double[1];
		  double[] arrayOfDouble2 = new double[1];
		  double[] arrayOfDouble3 = new double[1];
		  double[] arrayOfDouble4 = new double[1];
		  double[] arrayOfDouble5 = new double[1];
		  double[] arrayOfDouble6 = new double[1];
		  double[] arrayOfDouble7 = new double[1];
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_CL_StabilityCheck_aacOut_Ptr.in");
			for (sbyte b1 = 0; b1 < paramArrayOfDouble1.Length; b1++)
			{
			  bufferedWriter.Write(paramArrayOfDouble1[b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_CL_StabilityCheck_capLpf_Ptr.in");
			for (sbyte b1 = 0; b1 < paramArrayOfDouble2.Length; b1++)
			{
			  bufferedWriter.Write(paramArrayOfDouble2[b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_CL_StabilityCheck_V_Reference.in");
			bufferedWriter.Write(paramDouble1 + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_CL_StabilityCheck_targetCap.in");
			bufferedWriter.Write(paramDouble2 + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  bool @bool = abstractClosedLoop_closedLoop_settingsCheck(paramArrayOfDouble1, paramArrayOfDouble1.Length, paramArrayOfDouble2, paramArrayOfDouble2.Length, paramDouble1, paramDouble2, paramDouble3, paramDouble4, arrayOfDouble1, arrayOfDouble2, arrayOfDouble3, arrayOfDouble4, arrayOfDouble5, arrayOfDouble6, arrayOfDouble7);
		  if (@bool == true)
		  {
			spectrometerDSP_clean();
			throw new Exception("An error occurred in abstractClosedLoop_closedLoop_settingsCheck function! Please contact your vendor for support.");
		  }
//JAVA TO C# CONVERTER NOTE: The following call to the 'RectangularArrays' helper class reproduces the rectangular array initialization that is automatic in Java:
//ORIGINAL LINE: double[][] arrayOfDouble = new double[7][1];
		  double[][] arrayOfDouble = RectangularArrays.RectangularDoubleArray(7, 1);
		  arrayOfDouble[0][0] = arrayOfDouble1[0];
		  arrayOfDouble[1][0] = arrayOfDouble2[0];
		  arrayOfDouble[2][0] = arrayOfDouble3[0];
		  arrayOfDouble[3][0] = arrayOfDouble4[0];
		  arrayOfDouble[4][0] = arrayOfDouble5[0];
		  arrayOfDouble[5][0] = arrayOfDouble6[0];
		  arrayOfDouble[6][0] = arrayOfDouble7[0];
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_CL_StabilityCheck_errorFlag_Ptr.out");
			bufferedWriter.Write(arrayOfDouble1[0] + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_CL_StabilityCheck_instabilityFlag_Ptr.out");
			bufferedWriter.Write(arrayOfDouble2[0] + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_CL_StabilityCheck_saturationFlag_Ptr.out");
			bufferedWriter.Write(arrayOfDouble3[0] + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_CL_StabilityCheck_amplitudeFlag_Ptr.out");
			bufferedWriter.Write(arrayOfDouble4[0] + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_CL_StabilityCheck_stabilityStatus_Ptr.out");
			bufferedWriter.Write(arrayOfDouble5[0] + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_CL_StabilityCheck_saturationStatus_Ptr.out");
			bufferedWriter.Write(arrayOfDouble6[0] + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_CL_StabilityCheck_capStatus_Ptr.out");
			bufferedWriter.Write(arrayOfDouble7[0] + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  return arrayOfDouble;
		}
		catch (Exception exception)
		{
		  a a1 = new a();
		  a1.a_Conflict = exception;
		  throw a1;
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public double a(long paramLong) throws a
	  public virtual double a(long paramLong)
	  {
		try
		{
		  double[] arrayOfDouble = new double[1];
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_CL_calculateKdig_kdigRegVal.in");
			bufferedWriter.Write(paramLong + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  bool @bool = abstractClosedLoop_closedLoop_calculateKdigFromRegisterValue(paramLong, arrayOfDouble);
		  if (@bool == true)
		  {
			spectrometerDSP_clean();
			throw new Exception("An error occurred in abstractClosedLoop_closedLoop_calculateKdigFromRegisterValue function! Please contact your vendor for support.");
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_CL_calculateKdig_Kdig_Ptr.out");
			bufferedWriter.Write(arrayOfDouble[0] + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  return arrayOfDouble[0];
		}
		catch (Exception exception)
		{
		  a a1 = new a();
		  a1.a_Conflict = exception;
		  throw a1;
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public double[][] a(double[] paramArrayOfDouble, double paramDouble1, int paramInt, double paramDouble2) throws a
	  public virtual double[][] a(double[] paramArrayOfDouble, double paramDouble1, int paramInt, double paramDouble2)
	  {
		try
		{
		  double[] arrayOfDouble1 = new double[1];
		  double[] arrayOfDouble2 = new double[1];
		  double[] arrayOfDouble3 = new double[1];
		  double[] arrayOfDouble4 = new double[1];
		  double[] arrayOfDouble5 = new double[1];
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_CL_GainMarginCalc_capLpf_Ptr.in");
			for (sbyte b1 = 0; b1 < paramArrayOfDouble.Length; b1++)
			{
			  bufferedWriter.Write(paramArrayOfDouble[b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_CL_GainMarginCalc_KdigIncPer.in");
			bufferedWriter.Write(paramDouble1 + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_CL_GainMarginCalc_iteration.in");
			bufferedWriter.Write(paramInt + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_CL_GainMarginCalc_tempKdig.in");
			bufferedWriter.Write(paramDouble2 + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  bool @bool = abstractClosedLoop_closedLoop_gainMarginCalc(paramArrayOfDouble, paramArrayOfDouble.Length, paramDouble1, paramInt, paramDouble2, arrayOfDouble1, arrayOfDouble2, arrayOfDouble3, arrayOfDouble4, arrayOfDouble5);
		  if (@bool == true)
		  {
			spectrometerDSP_clean();
			throw new Exception("An error occurred in abstractClosedLoop_closedLoop_gainMarginCalc function! Please contact your vendor for support.");
		  }
//JAVA TO C# CONVERTER NOTE: The following call to the 'RectangularArrays' helper class reproduces the rectangular array initialization that is automatic in Java:
//ORIGINAL LINE: double[][] arrayOfDouble = new double[5][1];
		  double[][] arrayOfDouble = RectangularArrays.RectangularDoubleArray(5, 1);
		  arrayOfDouble[0][0] = arrayOfDouble1[0];
		  arrayOfDouble[1][0] = arrayOfDouble2[0];
		  arrayOfDouble[2][0] = arrayOfDouble3[0];
		  arrayOfDouble[3][0] = arrayOfDouble4[0];
		  arrayOfDouble[4][0] = arrayOfDouble5[0];
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_CL_GainMarginCalc_Kdig_Ptr.out");
			bufferedWriter.Write(arrayOfDouble1[0] + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_CL_GainMarginCalc_gainMargin_Ptr.out");
			bufferedWriter.Write(arrayOfDouble2[0] + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_CL_GainMarginCalc_KdigRegVal_Ptr.out");
			bufferedWriter.Write(arrayOfDouble3[0] + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_CL_GainMarginCalc_checkEnd_Ptr.out");
			bufferedWriter.Write(arrayOfDouble4[0] + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_CL_GainMarginCalc_errorFlag_Ptr.out");
			bufferedWriter.Write(arrayOfDouble5[0] + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  return arrayOfDouble;
		}
		catch (Exception exception)
		{
		  a a1 = new a();
		  a1.a_Conflict = exception;
		  throw a1;
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public double[][] a(double[] paramArrayOfDouble1, double[] paramArrayOfDouble2, double[] paramArrayOfDouble3, int paramInt1, int paramInt2) throws a
	  public virtual double[][] a(double[] paramArrayOfDouble1, double[] paramArrayOfDouble2, double[] paramArrayOfDouble3, int paramInt1, int paramInt2)
	  {
		try
		{
		  double[] arrayOfDouble1 = new double[1];
		  double[] arrayOfDouble2 = new double[1];
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_wavelengthCorr_Wavenumbers_Ptr.in");
			for (sbyte b1 = 0; b1 < paramArrayOfDouble1.Length; b1++)
			{
			  bufferedWriter.Write(paramArrayOfDouble1[b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_wavelengthCorr_B_Ptr.in");
			for (sbyte b1 = 0; b1 < paramArrayOfDouble2.Length; b1++)
			{
			  bufferedWriter.Write(paramArrayOfDouble2[b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_wavelengthCorr_refWavelengths_Ptr.in");
			for (sbyte b1 = 0; b1 < paramArrayOfDouble3.Length; b1++)
			{
			  bufferedWriter.Write(paramArrayOfDouble3[b1] + "\n");
			}
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Pre_wavelengthCorr_WavenumberCorrSelect.in");
			bufferedWriter.Write(paramInt2 + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  bool @bool = interferogram_wavelengthCorrect(paramArrayOfDouble1, paramArrayOfDouble2, paramArrayOfDouble1.Length, paramArrayOfDouble3, paramArrayOfDouble3.Length, paramInt1, paramInt2, arrayOfDouble1, arrayOfDouble2);
		  if (@bool == true)
		  {
			spectrometerDSP_clean();
			throw new Exception("An error occurred in abstractClosedLoop_closedLoop_gainMarginCalc function! Please contact your vendor for support.");
		  }
		  double[][] arrayOfDouble = {new double[2]};
		  arrayOfDouble[0][0] = arrayOfDouble1[0];
		  arrayOfDouble[0][1] = arrayOfDouble2[0];
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_wavelengthCorr_A_Corr_Ptr.out");
			bufferedWriter.Write(arrayOfDouble1[0] + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  try
		  {
			StreamWriter bufferedWriter = new StreamWriter(p2Constants.APPLICATION_WORKING_DIRECTORY + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "DSP_Post_wavelengthCorr_B_Corr_Ptr.out");
			bufferedWriter.Write(arrayOfDouble2[0] + "\n");
			bufferedWriter.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  return arrayOfDouble;
		}
		catch (Exception exception)
		{
		  a a1 = new a();
		  a1.a_Conflict = exception;
		  throw a1;
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public double[][] a(double paramDouble1, double paramDouble2, int paramInt, double[][] paramArrayOfDouble) throws a
	  public virtual double[][] a(double paramDouble1, double paramDouble2, int paramInt, double[][] paramArrayOfDouble)
	  {
		try
		{
		  double[][] arrayOfDouble = paramArrayOfDouble;
		  double[] arrayOfDouble1 = new double[paramInt];
		  double[] arrayOfDouble2 = new double[paramInt];
		  bool @bool = interferogram_commonWavenumberGeneration(paramDouble1, paramDouble2, paramInt, paramArrayOfDouble[2], paramArrayOfDouble[3], paramArrayOfDouble[3].Length, arrayOfDouble1, arrayOfDouble2);
		  if (@bool == true)
		  {
			spectrometerDSP_clean();
			throw new Exception("An error occurred in abstractClosedLoop_closedLoop_gainMarginCalc function! Please contact your vendor for support.");
		  }
		  arrayOfDouble[2] = arrayOfDouble1;
		  arrayOfDouble[3] = arrayOfDouble2;
		  return arrayOfDouble;
		}
		catch (Exception exception)
		{
		  a a1 = new a();
		  a1.a_Conflict = exception;
		  throw a1;
		}
	  }

	  static p2SpectroDSP()
	  {
//JAVA TO C# CONVERTER TODO TASK: The library is specified in the 'DllImport' attribute for .NET:
//		System.loadLibrary("spectrometerDSP");
	  }
	}


	/* Location:              D:\jobs\BalitTanah.SoilSensingKit\Decompile Driver\SDK v4.3\SDKv4.3\bin_win_x64\p2AppManager.jar!\sws\p2AppManager\dspAPI\p2SpectroDSP.class
	 * Java compiler version: 7 (51.0)
	 * JD-Core Version:       1.0.7
	 */
}