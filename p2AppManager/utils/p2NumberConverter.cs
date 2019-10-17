using System;

namespace sws.p2AppManager.utils
{

	public class p2NumberConverter
	{
	  public static double toDouble(sbyte[] paramArrayOfByte, int paramInt)
	  {
		try
		{
		  ByteBuffer byteBuffer = ByteBuffer.wrap(paramArrayOfByte, paramInt, 8);
		  byteBuffer.order(ByteOrder.nativeOrder());
		  return byteBuffer.Double;
		}
		catch (Exception)
		{
		  return 0.0D;
		}
	  }

	  public static float ToSingle(sbyte[] paramArrayOfByte, int paramInt)
	  {
		try
		{
		  ByteBuffer byteBuffer = ByteBuffer.wrap(paramArrayOfByte, paramInt, 4);
		  byteBuffer.order(ByteOrder.nativeOrder());
		  return byteBuffer.Float;
		}
		catch (Exception)
		{
		  return 0.0F;
		}
	  }

	  public static short ToShort(sbyte[] paramArrayOfByte, int paramInt)
	  {
		try
		{
		  ByteBuffer byteBuffer = ByteBuffer.wrap(paramArrayOfByte, paramInt, 2);
		  byteBuffer.order(ByteOrder.nativeOrder());
		  return byteBuffer.Short;
		}
		catch (Exception)
		{
		  return 0;
		}
	  }

	  public static int ToInt(sbyte[] paramArrayOfByte, int paramInt)
	  {
		try
		{
		  ByteBuffer byteBuffer = ByteBuffer.wrap(paramArrayOfByte, paramInt, 4);
		  byteBuffer.order(ByteOrder.nativeOrder());
		  return byteBuffer.Int;
		}
		catch (Exception)
		{
		  return 0;
		}
	  }

	  public static int byteToNo(sbyte[] paramArrayOfByte, int paramInt)
	  {
		try
		{
		  return paramArrayOfByte[0];
		}
		catch (Exception)
		{
		  return 0;
		}
	  }
	}


	/* Location:              D:\jobs\BalitTanah.SoilSensingKit\Decompile Driver\SDK v4.3\SDKv4.3\bin_win_x64\p2AppManager.jar!\sws\p2AppManage\\utils\p2NumberConverter.class
	 * Java compiler version: 7 (51.0)
	 * JD-Core Version:       1.0.7
	 */
}