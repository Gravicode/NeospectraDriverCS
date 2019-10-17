namespace sws.TAIFDriver.c
{

	public class a
	{
	  public static sbyte[] a(long paramLong)
	  {
		ByteBuffer byteBuffer = ByteBuffer.allocate(8);
		byteBuffer.order(ByteOrder.nativeOrder());
		byteBuffer.putLong(paramLong);
		return byteBuffer.array();
	  }

	  public static sbyte[] a(int paramInt)
	  {
		ByteBuffer byteBuffer = ByteBuffer.allocate(4);
		byteBuffer.order(ByteOrder.nativeOrder());
		byteBuffer.putInt(paramInt);
		return byteBuffer.array();
	  }

	  public static sbyte[] a(short paramShort)
	  {
		ByteBuffer byteBuffer = ByteBuffer.allocate(2);
		byteBuffer.order(ByteOrder.nativeOrder());
		byteBuffer.putShort(paramShort);
		return byteBuffer.array();
	  }
	}


	/* Location:              D:\jobs\BalitTanah.SoilSensingKit\Decompile Driver\SDK v4.3\SDKv4.3\bin_win_x64\TAIFDriver.jar!\sws\TAIFDriver\c\a.class
	 * Java compiler version: 7 (51.0)
	 * JD-Core Version:       1.0.7
	 */
}