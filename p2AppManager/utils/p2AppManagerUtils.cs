using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace sws.p2AppManager.utils
{
	using Logger = org.apache.log4j.Logger;

	public class p2AppManagerUtils
	{
	  private static Logger a = Logger.getLogger(typeof(p2AppManagerUtils));

	  public static bool isFilenameValid(string paramString)
	  {
		foreach (char c in paramString.ToCharArray())
		{
		  switch (c)
		  {
			case '\x0000':
			case '\t':
			case '\n':
			case '\f':
			case '\r':
			case '"':
			case '*':
			case '/':
			case ':':
			case '<':
			case '>':
			case '?':
			case '\\':
			case '`':
			case '|':
			  return false;
		  }
		}
		return true;
	  }

	  public static bool createDir(string paramString)
	  {
		File file = new File(paramString);
		return !file.exists() ? file.mkdirs() : 1;
	  }

	  public static bool removeDir(string paramString)
	  {
		File file = new File(paramString);
		if (file.exists())
		{
		  string[] arrayOfString = file.list();
		  foreach (string str in arrayOfString)
		  {
			File file1 = new File(file.Path, str);
			file1.delete();
		  }
		  return file.delete();
		}
		return true;
	  }

	  public static bool removeDir(string paramString, bool paramBoolean)
	  {
		File file = new File(paramString);
		if (file.exists())
		{
		  string[] arrayOfString = file.list();
		  foreach (string str in arrayOfString)
		  {
			File file1 = new File(file.Path, str);
			if (file1.Directory && paramBoolean)
			{
			  removeDir(file1.Path, true);
			}
			file1.delete();
		  }
		  return file.delete();
		}
		return true;
	  }

	  public static bool exist(string paramString)
	  {
		File file = new File(paramString);
		return file.exists();
	  }

	  public static string[] getFolderSubFoldersNames(string paramString, List<string> paramArrayList, bool paramBoolean)
	  {
		File file = new File(paramString);
		File[] arrayOfFile = file.listFiles();
		foreach (File file1 in arrayOfFile)
		{
		  if (file1.Directory && !file1.Hidden)
		  {
			paramArrayList.Add(file1.Name);
			if (paramBoolean)
			{
			  getFolderSubFoldersNames(file1.AbsolutePath, paramArrayList, true);
			}
		  }
		}
		return (string[])paramArrayList.ToArray();
	  }

	  public static string[] getFolderSubFilesNames(string paramString, List<string> paramArrayList)
	  {
		File file = new File(paramString);
		File[] arrayOfFile = file.listFiles();
		foreach (File file1 in arrayOfFile)
		{
		  if (!file1.Directory && !file1.Hidden)
		  {
			paramArrayList.Add(file1.Name);
		  }
		}
		return (string[])paramArrayList.ToArray();
	  }

	  public static bool isEmptyString(string paramString)
	  {
		  return (string.ReferenceEquals(paramString, null) || "".Equals(paramString));
	  }

	  public static string formatString(string paramString, params object[] paramVarArgs)
	  {
		  return MessageFormat.format(paramString, paramVarArgs);
	  }

	  public static double[] loadParamFile(string paramString)
	  {
		List<object> arrayList = new List<object>();
		bufferedReader = null;
		try
		{
		  bufferedReader = new StreamReader(paramString);
		  str = null;
		  while ((str = bufferedReader.readLine()) != null)
		  {
			string[] arrayOfString = str.Split(":");
			if (arrayOfString.Length == 2)
			{
			  arrayList.Add(Convert.ToDouble(double.Parse(arrayOfString[1])));
			}
		  }
		}
		catch (Exception exception)
		{
		  a.error(exception.Message);
		  return null;
		}
		finally
		{
		  try
		  {
			bufferedReader.close();
		  }
		  catch (Exception exception)
		  {
			a.error(exception.Message);
		  }
		}
		double[] arrayOfDouble = new double[arrayList.Count];
		for (sbyte b = 0; b < arrayOfDouble.Length; b++)
		{
		  arrayOfDouble[b] = ((double?)arrayList[b]).Value;
		}
		return arrayOfDouble;
	  }

	  public static double[] loadRawDataFile(string paramString)
	  {
		List<object> arrayList = new List<object>();
		bufferedReader = null;
		try
		{
		  bufferedReader = new StreamReader(paramString);
		  str = null;
		  while ((str = bufferedReader.readLine()) != null)
		  {
			arrayList.Add(Convert.ToDouble(double.Parse(str)));
		  }
		}
		catch (Exception exception)
		{
		  a.error(exception.Message);
		  return null;
		}
		finally
		{
		  try
		  {
			bufferedReader.close();
		  }
		  catch (Exception exception)
		  {
			a.error(exception.Message);
		  }
		}
		double[] arrayOfDouble = new double[arrayList.Count];
		for (sbyte b = 0; b < arrayOfDouble.Length; b++)
		{
		  arrayOfDouble[b] = ((double?)arrayList[b]).Value;
		}
		return arrayOfDouble;
	  }

	  public static double[] concatenateMultipleArraysIntoOne(params double[][] paramVarArgs)
	  {
		try
		{
		  int i = 0;
		  foreach (double[] arrayOfDouble1 in paramVarArgs)
		  {
			i += arrayOfDouble1.Length + 1;
		  }
		  double[] arrayOfDouble = new double[i];
		  int j = 0;
		  foreach (double[] arrayOfDouble1 in paramVarArgs)
		  {
			arrayOfDouble[j] = arrayOfDouble1.Length;
			Array.Copy(arrayOfDouble1, 0, arrayOfDouble, j + true, (int)arrayOfDouble[j]);
			j += arrayOfDouble1.Length + 1;
		  }
		  return arrayOfDouble;
		}
		catch (Exception exception)
		{
		  a.error(exception.Message);
		  return null;
		}
	  }

	  public static IList<string> decodeBytesToValues(int paramInt, sbyte[] paramArrayOfByte)
	  {
		sbyte b;
		List<object> arrayList = new List<object>();
		switch (paramInt)
		{
		  case 0:
			for (b = 0; b < paramArrayOfByte.Length; b += 8)
			{
			  arrayList.Add((new double?(p2NumberConverter.toDouble(paramArrayOfByte, b))).ToString());
			}
			return arrayList;
		  case 1:
			for (b = 0; b < paramArrayOfByte.Length; b += 4)
			{
			  arrayList.Add((new int?(p2NumberConverter.ToInt(paramArrayOfByte, b))).ToString());
			}
			return arrayList;
		  case 2:
			arrayList.Add(StringHelper.NewString(paramArrayOfByte, StandardCharsets.US_ASCII));
			return arrayList;
		  case 3:
			for (b = 0; b < paramArrayOfByte.Length; b += 4)
			{
			  arrayList.Add((new float?(p2NumberConverter.ToSingle(paramArrayOfByte, b))).ToString());
			}
			return arrayList;
		}
		a.error("invalid data type ");
		return null;
	  }

	  public static string[] readStringfile(string paramString)
	  {
		List<object> arrayList = new List<object>();
		bufferedReader = null;
		try
		{
		  bufferedReader = new StreamReader(paramString);
		  str = null;
		  while ((str = bufferedReader.readLine()) != null)
		  {
			arrayList.Add(str);
		  }
		}
		catch (Exception exception)
		{
		  a.error(exception.Message);
		  return null;
		}
		finally
		{
		  try
		  {
			bufferedReader.close();
		  }
		  catch (Exception exception)
		  {
			a.error(exception.Message);
		  }
		}
		return (string[])arrayList.ToArray(typeof(string));
	  }

	  public static bool writeFileOfArray(int[] paramArrayOfInt, string paramString1, string paramString2)
	  {
		bufferedWriter = null;
		bool @bool = (!string.ReferenceEquals(paramString2, null)) ? 1 : 0;
		try
		{
		  bufferedWriter = new StreamWriter(paramString1);
		  foreach (int i in paramArrayOfInt)
		  {
			bufferedWriter.write(Convert.ToString(i));
			if (@bool)
			{
			  bufferedWriter.write(paramString2);
			}
		  }
		  bufferedWriter.close();
		  return true;
		}
		catch (IOException iOException)
		{
		  a.error(iOException.Message);
		  return false;
		}
		finally
		{
		  try
		  {
			bufferedWriter.close();
		  }
		  catch (Exception exception)
		  {
			a.error(exception.Message);
		  }
		}
	  }

	  public static bool writeFileOfArray(double[] paramArrayOfDouble, string paramString1, string paramString2)
	  {
		bufferedWriter = null;
		bool @bool = (!string.ReferenceEquals(paramString2, null)) ? 1 : 0;
		try
		{
		  bufferedWriter = new StreamWriter(paramString1);
		  foreach (double d in paramArrayOfDouble)
		  {
			bufferedWriter.write(Convert.ToString(d));
			if (@bool)
			{
			  bufferedWriter.write(paramString2);
			}
		  }
		  bufferedWriter.close();
		  return true;
		}
		catch (IOException iOException)
		{
		  a.error(iOException.Message);
		  return false;
		}
		finally
		{
		  try
		  {
			bufferedWriter.close();
		  }
		  catch (Exception exception)
		  {
			a.error(exception.Message);
		  }
		}
	  }

	  public static bool writeFileOfArray(string[] paramArrayOfString, string paramString1, string paramString2)
	  {
		bufferedWriter = null;
		bool @bool = (!string.ReferenceEquals(paramString2, null)) ? 1 : 0;
		try
		{
		  bufferedWriter = new StreamWriter(new FileStream(paramString1, FileMode.Create, FileAccess.Write), Encoding.UTF8);
		  foreach (string str in paramArrayOfString)
		  {
			bufferedWriter.write(str);
			if (@bool)
			{
			  bufferedWriter.write(paramString2);
			}
		  }
		  return true;
		}
		catch (IOException iOException)
		{
		  a.error(iOException.Message);
		  return false;
		}
		finally
		{
		  try
		  {
			bufferedWriter.close();
		  }
		  catch (Exception exception)
		  {
			a.error(exception.Message);
		  }
		}
	  }
	}


	/* Location:              D:\jobs\BalitTanah.SoilSensingKit\Decompile Driver\SDK v4.3\SDKv4.3\bin_win_x64\p2AppManager.jar!\sws\p2AppManage\\utils\p2AppManagerUtils.class
	 * Java compiler version: 7 (51.0)
	 * JD-Core Version:       1.0.7
	 */
}