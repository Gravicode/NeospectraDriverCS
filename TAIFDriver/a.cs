using System;
using System.IO;
using System.Threading;

namespace sws.TAIFDriver
{
	using Logger = org.apache.log4j.Logger;
	using a = sws.TAIFDriver.ClassA.aa;
	using b = sws.TAIFDriver.ClassA.ab;
	using c = sws.TAIFDriver.ClassA.ac;
	using d = sws.TAIFDriver.ClassA.ad;
	using e = sws.TAIFDriver.ClassA.ae;
	using i = sws.TAIFDriver.ClassA.ai;
	using j = sws.TAIFDriver.ClassA.aj;
	using k = sws.TAIFDriver.ClassA.ak;
	using a = sws.TAIFDriver.ClassB.ba;
	using a = sws.TAIFDriver.ClassC.ca;

	public class a
	{
	  private static Logger i = Logger.getLogger(typeof(a));

	  private TAIFBoard j;

//JAVA TO C# CONVERTER NOTE: Members cannot have the same name as their enclosing type:
	  public static bool a_Conflict = false;

//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
	  public static bool b_Conflict = false;

//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
	  public static bool c_Conflict = false;

//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
	  public static int d_Conflict = 5;

//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
	  public static int e_Conflict = 5;

//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
	  public static bool f_Conflict = false;

	  public static bool g = false;

	  public static bool h = false;

	  private static int k = 1;

	  private int l = 0;

	  private int m = 0;

	  public a(int paramInt)
	  {
		  this.j = new TAIFBoard(paramInt);
	  }

	  public a(int paramInt, string paramString)
	  {
		  this.j = new TAIFBoard(paramInt, paramString);
	  }

//JAVA TO C# CONVERTER NOTE: Members cannot have the same name as their enclosing type:
	  public virtual void a_Conflict(string paramString)
	  {
		  this.j.a_Conflict = paramString;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void a(boolean... paramVarArgs) throws a
//JAVA TO C# CONVERTER NOTE: Members cannot have the same name as their enclosing type:
	  public virtual void a_Conflict(params bool[] paramVarArgs)
	  {
		i.info("initiateTAIF method :: Start");
		try
		{
		  a_Conflict();
		  this.j.d();
		}
		catch (Exception)
		{
		}
		try
		{
		  this.j.d();
		}
		catch (Exception)
		{
		}
		this.j.a(paramVarArgs);
		i.info("initiateTAIF method :: End");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public int a() throws a
	  public int a()
	  {
		i.info("checkBoardStatus method :: Start");
		int n = this.j.a();
		i.info("checkBoardStatus method :: End with status: " + n);
		return n;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void a(long[] paramArrayOfLong) throws a
//JAVA TO C# CONVERTER NOTE: Members cannot have the same name as their enclosing type:
	  public virtual void a_Conflict(long[] paramArrayOfLong)
	  {
		a_Conflict(c_Conflict.U.a(), 0L, e_Conflict.U.a(), d_Conflict.U.a());
		this.j.a(paramArrayOfLong);
		this.j.b(i.c.a(), 1L, k.c.a(), j.c.a());
		this.j.b(i.c.a(), 0L, k.c.a(), j.c.a());
		try
		{
		  Thread.Sleep(100L);
		}
		catch (InterruptedException interruptedException)
		{
		  Console.WriteLine(interruptedException.ToString());
		  Console.Write(interruptedException.StackTrace);
		}
		a_Conflict(c_Conflict.U.a(), 1L, e_Conflict.U.a(), d_Conflict.U.a());
		try
		{
		  Thread.Sleep(100L);
		}
		catch (InterruptedException interruptedException)
		{
		  Console.WriteLine(interruptedException.ToString());
		  Console.Write(interruptedException.StackTrace);
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public long[] b() throws a
	  public virtual long[] b()
	  {
		  return this.j.c();
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public long a(int paramInt1, int paramInt2, int paramInt3) throws a
	  public long a(int paramInt1, int paramInt2, int paramInt3)
	  {
		  return this.j.a(paramInt1, paramInt2, paramInt3);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void a(int paramInt1, long paramLong, int paramInt2, int paramInt3) throws a
//JAVA TO C# CONVERTER NOTE: Members cannot have the same name as their enclosing type:
	  public virtual void a_Conflict(int paramInt1, long paramLong, int paramInt2, int paramInt3)
	  {
		  this.j.a(paramInt1, paramLong, paramInt2, paramInt3);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void c() throws a
	  public virtual void c()
	  {
		  this.j.b();
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public byte[] a(int paramInt1, int paramInt2) throws a
	  public sbyte[] a(int paramInt1, int paramInt2)
	  {
		int n = 512 * paramInt1;
		return this.j.c(n, paramInt2);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public long b(int paramInt1, int paramInt2, int paramInt3) throws a
	  public virtual long b(int paramInt1, int paramInt2, int paramInt3)
	  {
		  return this.j.b(paramInt1, paramInt2, paramInt3);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void b(int paramInt1, long paramLong, int paramInt2, int paramInt3) throws a
	  public virtual void b(int paramInt1, long paramLong, int paramInt2, int paramInt3)
	  {
		  this.j.b(paramInt1, paramLong, paramInt2, paramInt3);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public long d() throws a
	  public virtual long d()
	  {
		this.j.b(i.gY.a(), 0L, k.gY.a(), j.gY.a());
		this.j.b(i.u.a(), 0L, k.u.a(), j.u.a());
		this.j.b(i.bU.a(), 1L, k.bU.a(), j.bU.a());
		this.j.b(i.gX.a(), 1L, k.gX.a(), j.gX.a());
		this.j.b(i.eS.a(), 1L, k.eS.a(), j.eS.a());
		this.j.b(i.eR.a(), 1L, k.eR.a(), j.eR.a());
		try
		{
		  Thread.Sleep(30L);
		}
		catch (InterruptedException interruptedException)
		{
		  i.error(interruptedException.Message);
		}
		long l1 = this.j.b(i.gS.a(), k.gS.a(), j.gS.a());
		this.j.b(i.bU.a(), 0L, k.bU.a(), j.bU.a());
		this.j.b(i.u.a(), 1L, k.u.a(), j.u.a());
		return l1;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public String e() throws a, InterruptedException
	  public virtual string e()
	  {
		i.info("TAIFDriver readROMID method :: Start");
		sbyte b1 = 8;
		sbyte b2 = this.j.a(b1);
		if (b2 >= 56)
		{
		  return "Error! ID isn't valid";
		}
		sbyte[] arrayOfByte = this.j.a(b1 + 1, b2);
		i.info("TAIFDriver readROMID method :: END");
		return StringHelper.NewString(arrayOfByte, Charset.forName("US-ASCII"));
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void a(byte[] paramArrayOfByte) throws a, InterruptedException
//JAVA TO C# CONVERTER NOTE: Members cannot have the same name as their enclosing type:
	  public virtual void a_Conflict(sbyte[] paramArrayOfByte)
	  {
		i.info("TAIFDriver writeROMID(byte[] value) :: Start");
		sbyte b1 = 8;
		if (paramArrayOfByte.Length >= 56)
		{
		  i.error("TAIFDriver WriteTAIFID(byte[] value) :: " + b_Conflict.ae);
		  throw new a("TAIFDriver WriteTAIFID(byte[] value) :: " + b_Conflict.ae, b_Conflict.ae);
		}
		this.j.a(b1, (sbyte)paramArrayOfByte.Length);
		this.j.a(b1 + 1, paramArrayOfByte.Length, paramArrayOfByte);
		i.info("writeROMID method :: END");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public byte[] b(int paramInt1, int paramInt2) throws a
	  public virtual sbyte[] b(int paramInt1, int paramInt2)
	  {
		i.info("readROMData method :: Start");
		b_Conflict b1 = b_Conflict.a;
		if (64 + paramInt1 + paramInt2 > 65536)
		{
		  b1 = b_Conflict.ae;
		  i.error("readTAIFData method :: Error : " + b1);
		  throw new a("readTAIFData method :: Error : " + b1, b1);
		}
		sbyte[] arrayOfByte = this.j.a(64 + paramInt1, paramInt2);
		i.info("readROMData method :: END");
		return arrayOfByte;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void a(int paramInt1, int paramInt2, byte[] paramArrayOfByte) throws a, InterruptedException
//JAVA TO C# CONVERTER NOTE: Members cannot have the same name as their enclosing type:
	  public virtual void a_Conflict(int paramInt1, int paramInt2, sbyte[] paramArrayOfByte)
	  {
		i.info("writeROMData method :: Start");
		b_Conflict b1 = b_Conflict.a;
		if (64 + paramInt1 + paramInt2 > 65536)
		{
		  b1 = b_Conflict.ae;
		  throw new a("Exception in writeTAIFData, error code: " + b1, b1);
		}
		this.j.a(64 + paramInt1, paramInt2, paramArrayOfByte);
		i.info("writeROMData method :: End");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void a(boolean paramBoolean1, boolean paramBoolean2, int paramInt) throws a
//JAVA TO C# CONVERTER NOTE: Members cannot have the same name as their enclosing type:
	  public virtual void a_Conflict(bool paramBoolean1, bool paramBoolean2, int paramInt)
	  {
		i.info("setupActuation method :: Start");
		if (paramBoolean2)
		{
		  if (paramBoolean1)
		  {
			this.j.b(i.cI.a(), 0L, k.cI.a(), j.cI.a());
			this.j.b(i.k.a(), 1L, k.k.a(), j.k.a());
			this.j.b(i.cX.a(), 1L, k.cX.a(), j.cX.a());
		  }
		  else
		  {
			this.j.b(i.cI.a(), 0L, k.cI.a(), j.cI.a());
			this.j.b(i.k.a(), 1L, k.k.a(), j.k.a());
			this.j.b(i.cX.a(), 0L, k.cX.a(), j.cX.a());
		  }
		}
		else if (paramBoolean1)
		{
		  this.j.b(i.cI.a(), 0L, k.cI.a(), j.cI.a());
		  this.j.b(i.k.a(), 1L, k.k.a(), j.k.a());
		  this.j.b(i.cX.a(), 0L, k.cX.a(), j.cX.a());
		  this.j.b(i.da.a(), 0L, k.da.a(), j.da.a());
		  this.j.b(i.k.a(), 0L, k.k.a(), j.k.a());
		  this.j.b(i.cI.a(), 1L, k.cI.a(), j.cI.a());
		  try
		  {
			Thread.Sleep(100L);
		  }
		  catch (InterruptedException)
		  {
		  }
		  this.j.b(i.da.a(), 1L, k.da.a(), j.da.a());
		  long l1 = this.j.b(i.dj.a(), k.dj.a(), j.dj.a());
		  this.j.b(i.dj.a(), l1 * paramInt, k.dj.a(), j.dj.a());
		  try
		  {
			Thread.Sleep(500L);
		  }
		  catch (InterruptedException)
		  {
		  }
		  this.j.b(i.dj.a(), l1, k.dj.a(), j.dj.a());
		}
		else
		{
		  this.j.b(i.cX.a(), 0L, k.cX.a(), j.cX.a());
		  this.j.b(i.cI.a(), 0L, k.cI.a(), j.cI.a());
		  this.j.b(i.k.a(), 1L, k.k.a(), j.k.a());
		}
		i.info("setupActuation method :: End");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public boolean a(boolean paramBoolean) throws a
	  public bool a(bool paramBoolean)
	  {
		if (paramBoolean)
		{
		  long l2 = this.j.b(i.cX.a(), k.cX.a(), j.cX.a());
		  return (l2 == 1L);
		}
		long l1 = this.j.b(i.k.a(), k.k.a(), j.k.a());
		return !(l1 == 1L);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public int[][] c(int paramInt1, int paramInt2, int paramInt3) throws a
	  public virtual int[][] c(int paramInt1, int paramInt2, int paramInt3)
	  {
		i.info("streamInterpolation method :: Start");
		try
		{
		  if (h == true)
		  {
			long[] arrayOfLong = this.j.c();
			this.j.a(arrayOfLong, "t_before_run.reg");
		  }
		  c(paramInt1, paramInt2);
		  sbyte[] arrayOfByte = a(paramInt3);
		  int[][] arrayOfInt = b(arrayOfByte);
		  this.j.b();
		  i.info("streamInterpolation method :: End");
		  if (g == true)
		  {
			File file = new File(this.j.a_Conflict + Path.DirectorySeparatorChar + k.ToString());
			file.mkdirs();
			try
			{
			  StreamWriter bufferedWriter = new StreamWriter(this.j.a_Conflict + Path.DirectorySeparatorChar + k.ToString() + Path.DirectorySeparatorChar + "I1.txt");
			  sbyte b1;
			  for (b1 = 0; b1 < arrayOfInt[0].Length; b1++)
			  {
				bufferedWriter.Write(arrayOfInt[0][b1] + "\n");
			  }
			  bufferedWriter.Close();
			  bufferedWriter = new StreamWriter(this.j.a_Conflict + Path.DirectorySeparatorChar + k.ToString() + Path.DirectorySeparatorChar + "I2.txt");
			  for (b1 = 0; b1 < arrayOfInt[1].Length; b1++)
			  {
				bufferedWriter.Write(arrayOfInt[1][b1] + "\n");
			  }
			  bufferedWriter.Close();
			}
			catch (IOException iOException)
			{
			  i.error(iOException.Message);
			}
			k++;
		  }
		  this.m = 0;
		  return arrayOfInt;
		}
		catch (Exception exception)
		{
		  i.error("An exception has occurred in streamInterpolation function.", exception);
		  this.m++;
		  if (this.m > e_Conflict)
		  {
			throw new a(exception, b_Conflict.ac);
		  }
		  int[][] arrayOfInt = c(paramInt1, paramInt2, paramInt3);
		  this.m = 0;
		  return arrayOfInt;
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public int[][] d(int paramInt1, int paramInt2, int paramInt3) throws a
	  public virtual int[][] d(int paramInt1, int paramInt2, int paramInt3)
	  {
		i.info("streamADCs method :: Start");
		try
		{
		  int n = paramInt2 / 8;
		  long l1 = (long)Math.Ceiling(n / 24.0D);
		  a_Conflict(paramInt1, l1);
		  sbyte[] arrayOfByte = a(l1, paramInt3);
		  int[][] arrayOfInt = a(arrayOfByte, paramInt2, paramInt1);
		  this.j.b();
		  i.info("streamADCs method :: End");
		  this.l = 0;
		  return arrayOfInt;
		}
		catch (Exception exception)
		{
		  i.error("An exception has occurred in streamADCs function.", exception);
		  this.l++;
		  if (this.l > d_Conflict)
		  {
			throw new a(exception, b_Conflict.ac);
		  }
		  int[][] arrayOfInt = d(paramInt1, paramInt2, paramInt3);
		  this.l = 0;
		  return arrayOfInt;
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public int[][] e(int paramInt1, int paramInt2, int paramInt3) throws a
	  public virtual int[][] e(int paramInt1, int paramInt2, int paramInt3)
	  {
		i.info("streamActualDMUX method :: Start");
		int n = paramInt2 / 8;
		long l1 = (long)Math.Ceiling(n / 24.0D);
		b(paramInt1, l1);
		sbyte[] arrayOfByte = b(l1, paramInt3);
		int[][] arrayOfInt = b(arrayOfByte, paramInt2, paramInt1);
		this.j.b();
		i.info("streamActualDMUX method :: End");
		this.l = 0;
		return arrayOfInt;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public int f() throws a
	  public virtual int f()
	  {
		  return 89;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void c(int paramInt1, int paramInt2) throws a
	  private void c(int paramInt1, int paramInt2)
	  {
		i.info("setupInterpolationRegisters method :: Start");
		this.j.b(i.cy.a(), 0L, k.cy.a(), j.cy.a());
		this.j.a(c_Conflict.V.a(), 0L, e_Conflict.V.a(), d_Conflict.V.a());
		this.j.b(i.aX.a(), (paramInt1 - 1), k.aX.a(), j.aX.a());
		this.j.b(i.gu.a(), (paramInt1 - 1), k.gu.a(), j.gu.a());
		this.j.b(i.bk.a(), paramInt2, k.bk.a(), j.bk.a());
		this.j.b(i.gH.a(), paramInt2, k.gH.a(), j.gH.a());
		this.j.b(i.dA.a(), 0L, k.dA.a(), j.dA.a());
		this.j.b(i.dB.a(), 0L, k.dB.a(), j.dB.a());
		this.j.b(i.U.a(), 1L, k.U.a(), j.U.a());
		if (b_Conflict == true)
		{
		  this.j.a(c_Conflict.C.a(), 1L, e_Conflict.C.a(), d_Conflict.C.a());
		}
		this.j.a(c_Conflict.V.a(), 1L, e_Conflict.V.a(), d_Conflict.V.a());
		if (c_Conflict == true)
		{
		  long l1 = 0L;
		  long l2 = 0L;
		  l1 = this.j.b(i.aU.a(), k.aU.a(), j.aU.a());
		  l2 = this.j.b(i.gr.a(), k.gr.a(), j.gr.a());
		  this.j.b(i.aM.a(), 0L, k.aM.a(), j.aM.a());
		  this.j.b(i.aM.a(), 1L, k.aM.a(), j.aM.a());
		  this.j.b(i.aN.a(), 0L, k.aN.a(), j.aN.a());
		  this.j.b(i.aN.a(), 1L, k.aN.a(), j.aN.a());
		  do
		  {
			if (l1 == 0L)
			{
			  l1 = this.j.b(i.aU.a(), k.aU.a(), j.aU.a());
			}
			if (l2 != 0L)
			{
			  continue;
			}
			l2 = this.j.b(i.gr.a(), k.gr.a(), j.gr.a());
		  } while (l1 == 0L || l2 == 0L);
		  this.j.b(i.aL.a(), 1L, k.aL.a(), j.aL.a());
		  this.j.b(i.gk.a(), 1L, k.gk.a(), j.gk.a());
		  long l3 = 0L;
		  long l4 = 0L;
		  try
		  {
			StreamWriter bufferedWriter1 = new StreamWriter(this.j.a_Conflict + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "streamingASIC_INT1.txt");
			StreamWriter bufferedWriter2 = new StreamWriter(this.j.a_Conflict + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "streamingASIC_INT2.txt");
			for (sbyte b1 = 0; b1 < (sbyte)'က'; b1++)
			{
			  l3 = this.j.b(i.aQ.a(), k.aQ.a(), j.aQ.a());
			  l4 = this.j.b(i.gn.a(), k.gn.a(), j.gn.a());
			  bufferedWriter1.Write(l3 + "\n");
			  bufferedWriter2.Write(l4 + "\n");
			}
			bufferedWriter1.Close();
			bufferedWriter2.Close();
		  }
		  catch (IOException iOException)
		  {
			i.error(iOException.Message);
		  }
		  l1 = this.j.b(i.aU.a(), k.aU.a(), j.aU.a());
		  l2 = this.j.b(i.gr.a(), k.gr.a(), j.gr.a());
		  long l5 = this.j.b(i.aI.a(), k.aI.a(), j.aI.a());
		  long l6 = this.j.b(i.aJ.a(), k.aJ.a(), j.aJ.a());
		  Console.WriteLine("---I1_MASK_INT1_DRDY = " + l5);
		  Console.WriteLine("---I1_MASK_INT2_DRDY = " + l6);
		  l5 = this.j.b(i.S.a(), k.S.a(), j.S.a());
		  l6 = this.j.b(i.U.a(), k.U.a(), j.U.a());
		  Console.WriteLine("---I1_EN = " + l5);
		  Console.WriteLine("---I2_EN = " + l6);
		  l5 = this.j.b(i.Z.a(), k.Z.a(), j.Z.a());
		  Console.WriteLine("---I1_source = " + l5);
		}
		i.info("setupInterpolationRegisters method :: End");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void a(int paramInt, long paramLong) throws a
//JAVA TO C# CONVERTER NOTE: Members cannot have the same name as their enclosing type:
	  private void a_Conflict(int paramInt, long paramLong)
	  {
		i.info("setupADCsRegisters method :: Start");
		int n = 0;
		int i1 = 0;
		sbyte[] arrayOfByte1 = new sbyte[4];
		sbyte[] arrayOfByte2 = new sbyte[4];
		arrayOfByte1[2] = 0;
		arrayOfByte1[3] = 0;
		arrayOfByte2[2] = 0;
		arrayOfByte2[3] = 0;
		sbyte[] arrayOfByte3 = a_Conflict.a(paramLong);
		if (arrayOfByte3.Length > 0)
		{
		  arrayOfByte1[0] = arrayOfByte3[0];
		}
		else
		{
		  arrayOfByte1[0] = 0;
		}
		if (arrayOfByte3.Length > 1)
		{
		  arrayOfByte1[1] = arrayOfByte3[1];
		}
		else
		{
		  arrayOfByte1[1] = 0;
		}
		if (arrayOfByte3.Length > 2)
		{
		  arrayOfByte2[0] = arrayOfByte3[2];
		}
		else
		{
		  arrayOfByte2[0] = 0;
		}
		if (arrayOfByte3.Length > 3)
		{
		  arrayOfByte2[1] = arrayOfByte3[3];
		}
		else
		{
		  arrayOfByte2[1] = 0;
		}
		ByteBuffer byteBuffer = ByteBuffer.wrap(arrayOfByte1);
		byteBuffer.order(ByteOrder.nativeOrder());
		n = byteBuffer.getInt(0);
		byteBuffer = ByteBuffer.wrap(arrayOfByte2);
		byteBuffer.order(ByteOrder.nativeOrder());
		i1 = byteBuffer.getInt(0);
		this.j.a(c_Conflict.w.a(), 0L, e_Conflict.w.a(), d_Conflict.w.a());
		this.j.b(i.eQ.a(), 15L, k.eQ.a(), j.eQ.a());
		this.j.b(i.dD.a(), paramInt, k.dD.a(), j.dD.a());
		this.j.b(i.dA.a(), 1L, k.dA.a(), j.dA.a());
		this.j.b(i.dB.a(), 1L, k.dB.a(), j.dB.a());
		this.j.a(c_Conflict.e.a(), i1, e_Conflict.e.a(), d_Conflict.e.a());
		this.j.a(c_Conflict.f.a(), n, e_Conflict.f.a(), d_Conflict.f.a());
		try
		{
		  StreamReader bufferedReader = new StreamReader("mems" + Path.DirectorySeparatorChar + "sampleRate" + Path.DirectorySeparatorChar + "test.txt");
		  f_Conflict = bool.Parse(bufferedReader.ReadLine());
		  bufferedReader.Close();
		}
		catch (IOException)
		{
		  f_Conflict = false;
		}
		if (f_Conflict == true)
		{
		  Console.WriteLine("Test mode = " + f_Conflict);
		  int i2 = 48;
		  try
		  {
			StreamReader bufferedReader = new StreamReader("mems" + Path.DirectorySeparatorChar + "sampleRate" + Path.DirectorySeparatorChar + "rate.txt");
			i2 = int.Parse(bufferedReader.ReadLine());
			bufferedReader.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  Console.WriteLine("Sample rate = " + i2);
		  this.j.a(c_Conflict.d.a(), 1L, e_Conflict.d.a(), d_Conflict.d.a());
		  this.j.a(c_Conflict.p.a(), i2, e_Conflict.p.a(), d_Conflict.p.a());
		}
		try
		{
		  StreamReader bufferedReader = new StreamReader("mems" + Path.DirectorySeparatorChar + "SPI" + Path.DirectorySeparatorChar + "test.txt");
		  a_Conflict = bool.Parse(bufferedReader.ReadLine());
		  bufferedReader.Close();
		}
		catch (IOException)
		{
		  a_Conflict = false;
		}
		if (a_Conflict == true)
		{
		  try
		  {
			long l1 = 0L;
			try
			{
			  StreamReader bufferedReader = new StreamReader("mems" + Path.DirectorySeparatorChar + "SPI" + Path.DirectorySeparatorChar + "count.txt");
			  l1 = long.Parse(bufferedReader.ReadLine());
			  bufferedReader.Close();
			}
			catch (IOException iOException)
			{
			  Console.WriteLine(iOException.ToString());
			  Console.Write(iOException.StackTrace);
			}
			StreamWriter bufferedWriter1 = new StreamWriter(new StreamWriter("mems" + Path.DirectorySeparatorChar + "SPI" + Path.DirectorySeparatorChar + "Output_Log.txt", false));
			StreamWriter bufferedWriter2 = new StreamWriter(new StreamWriter("mems" + Path.DirectorySeparatorChar + "SPI" + Path.DirectorySeparatorChar + "Output_Failure_Counts.txt", false));
			sbyte b1 = 0;
			long l2;
			for (l2 = 0L; l2 < l1; l2++)
			{
			  long l3 = (long)(2.147483647E9D * GlobalRandom.NextDouble);
			  this.j.b(i.b.a(), l3, k.b.a(), j.b.a());
			  long l4 = this.j.b(i.b.a(), k.b.a(), j.b.a());
			  if (l3 != l4)
			  {
				bufferedWriter2.Write("Error occurred at loop index " + l2 + ". total number of errors so far is " + ++b1 + "\n");
			  }
			  bufferedWriter1.Write("Current count is " + l2 + " out of " + l1 + ". value written is " + l3 + " and value read is " + l4 + ". total number of errors so far is " + b1 + "\n");
			  Console.WriteLine("Current count is " + l2 + " out of " + l1 + ". value written is " + l3 + " and value read is " + l4 + ". total number of errors so far is " + b1 + "\n");
			}
			bufferedWriter1.Close();
			bufferedWriter2.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  a_Conflict = false;
		}
		this.j.a(c_Conflict.w.a(), 1L, e_Conflict.w.a(), d_Conflict.w.a());
		i.info("setupADCsRegisters method :: End");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void b(int paramInt, long paramLong) throws a
	  private void b(int paramInt, long paramLong)
	  {
		i.info("setupActualDMuxRegisters method :: Start");
		int n = 0;
		int i1 = 0;
		sbyte[] arrayOfByte1 = new sbyte[4];
		sbyte[] arrayOfByte2 = new sbyte[4];
		arrayOfByte1[2] = 0;
		arrayOfByte1[3] = 0;
		arrayOfByte2[2] = 0;
		arrayOfByte2[3] = 0;
		sbyte[] arrayOfByte3 = a_Conflict.a(paramLong);
		if (arrayOfByte3.Length > 0)
		{
		  arrayOfByte1[0] = arrayOfByte3[0];
		}
		else
		{
		  arrayOfByte1[0] = 0;
		}
		if (arrayOfByte3.Length > 1)
		{
		  arrayOfByte1[1] = arrayOfByte3[1];
		}
		else
		{
		  arrayOfByte1[1] = 0;
		}
		if (arrayOfByte3.Length > 2)
		{
		  arrayOfByte2[0] = arrayOfByte3[2];
		}
		else
		{
		  arrayOfByte2[0] = 0;
		}
		if (arrayOfByte3.Length > 3)
		{
		  arrayOfByte2[1] = arrayOfByte3[3];
		}
		else
		{
		  arrayOfByte2[1] = 0;
		}
		ByteBuffer byteBuffer = ByteBuffer.wrap(arrayOfByte1);
		byteBuffer.order(ByteOrder.nativeOrder());
		n = byteBuffer.getInt(0);
		byteBuffer = ByteBuffer.wrap(arrayOfByte2);
		byteBuffer.order(ByteOrder.nativeOrder());
		i1 = byteBuffer.getInt(0);
		this.j.a(c_Conflict.v.a(), 0L, e_Conflict.v.a(), d_Conflict.v.a());
		this.j.b(i.eQ.a(), 15L, k.eQ.a(), j.eQ.a());
		this.j.b(i.dD.a(), paramInt, k.dD.a(), j.dD.a());
		this.j.b(i.dA.a(), 1L, k.dA.a(), j.dA.a());
		this.j.b(i.dB.a(), 1L, k.dB.a(), j.dB.a());
		this.j.a(c_Conflict.e.a(), i1, e_Conflict.e.a(), d_Conflict.e.a());
		this.j.a(c_Conflict.f.a(), n, e_Conflict.f.a(), d_Conflict.f.a());
		try
		{
		  StreamReader bufferedReader = new StreamReader("mems" + Path.DirectorySeparatorChar + "sampleRate" + Path.DirectorySeparatorChar + "test.txt");
		  f_Conflict = bool.Parse(bufferedReader.ReadLine());
		  bufferedReader.Close();
		}
		catch (IOException)
		{
		  f_Conflict = false;
		}
		if (f_Conflict == true)
		{
		  Console.WriteLine("Test mode = " + f_Conflict);
		  int i2 = 48;
		  try
		  {
			StreamReader bufferedReader = new StreamReader("mems" + Path.DirectorySeparatorChar + "sampleRate" + Path.DirectorySeparatorChar + "rate.txt");
			i2 = int.Parse(bufferedReader.ReadLine());
			bufferedReader.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  Console.WriteLine("Sample rate = " + i2);
		  this.j.a(c_Conflict.d.a(), 1L, e_Conflict.d.a(), d_Conflict.d.a());
		  this.j.a(c_Conflict.p.a(), i2, e_Conflict.p.a(), d_Conflict.p.a());
		}
		try
		{
		  StreamReader bufferedReader = new StreamReader("mems" + Path.DirectorySeparatorChar + "SPI" + Path.DirectorySeparatorChar + "test.txt");
		  a_Conflict = bool.Parse(bufferedReader.ReadLine());
		  bufferedReader.Close();
		}
		catch (IOException)
		{
		  a_Conflict = false;
		}
		if (a_Conflict == true)
		{
		  try
		  {
			long l1 = 0L;
			try
			{
			  StreamReader bufferedReader = new StreamReader("mems" + Path.DirectorySeparatorChar + "SPI" + Path.DirectorySeparatorChar + "count.txt");
			  l1 = long.Parse(bufferedReader.ReadLine());
			  bufferedReader.Close();
			}
			catch (IOException iOException)
			{
			  Console.WriteLine(iOException.ToString());
			  Console.Write(iOException.StackTrace);
			}
			StreamWriter bufferedWriter1 = new StreamWriter(new StreamWriter("mems" + Path.DirectorySeparatorChar + "SPI" + Path.DirectorySeparatorChar + "Output_Log.txt", false));
			StreamWriter bufferedWriter2 = new StreamWriter(new StreamWriter("mems" + Path.DirectorySeparatorChar + "SPI" + Path.DirectorySeparatorChar + "Output_Failure_Counts.txt", false));
			sbyte b1 = 0;
			long l2;
			for (l2 = 0L; l2 < l1; l2++)
			{
			  long l3 = (long)(2.147483647E9D * GlobalRandom.NextDouble);
			  this.j.b(i.b.a(), l3, k.b.a(), j.b.a());
			  long l4 = this.j.b(i.b.a(), k.b.a(), j.b.a());
			  if (l3 != l4)
			  {
				bufferedWriter2.Write("Error occurred at loop index " + l2 + ". total number of errors so far is " + ++b1 + "\n");
			  }
			  bufferedWriter1.Write("Current count is " + l2 + " out of " + l1 + ". value written is " + l3 + " and value read is " + l4 + ". total number of errors so far is " + b1 + "\n");
			  Console.WriteLine("Current count is " + l2 + " out of " + l1 + ". value written is " + l3 + " and value read is " + l4 + ". total number of errors so far is " + b1 + "\n");
			}
			bufferedWriter1.Close();
			bufferedWriter2.Close();
		  }
		  catch (IOException iOException)
		  {
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		  a_Conflict = false;
		}
		this.j.a(c_Conflict.v.a(), 1L, e_Conflict.v.a(), d_Conflict.v.a());
		i.info("setupActualDMuxRegisters method :: End");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private byte[] a(int paramInt) throws a
	  private sbyte[] a(int paramInt)
	  {
		i.info("startStreamingInterpolation method :: Start");
		sbyte b1 = 50;
		i.info("async in packets count: " + b1);
		char c1 = (char)(b1 * 'Ȁ');
		i.info("asyncDataInLength " + c1);
		sbyte[] arrayOfByte = this.j.b(c1, paramInt);
		i.info("startStreamingInterpolation method :: End");
		return arrayOfByte;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private byte[] a(long paramLong, int paramInt) throws a
	  private sbyte[] a(long paramLong, int paramInt)
	  {
		i.info("startStreamingADCs method :: Start");
		int n = (int)paramLong;
		i.info("async in packets count: " + n);
		int i1 = n * 512;
		i.info("asyncDataInLength " + i1);
		sbyte[] arrayOfByte = this.j.d(i1, paramInt);
		i.info("startStreamingADCs method :: End");
		return arrayOfByte;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private byte[] b(long paramLong, int paramInt) throws a
	  private sbyte[] b(long paramLong, int paramInt)
	  {
		i.info("startStreamingADCs method :: Start");
		int n = (int)paramLong;
		i.info("async in packets count: " + n);
		int i1 = n * 512;
		i.info("asyncDataInLength " + i1);
		sbyte[] arrayOfByte = this.j.e(i1, paramInt);
		i.info("startStreamingADCs method :: End");
		return arrayOfByte;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private int[][] b(byte[] paramArrayOfByte) throws a
	  private int[][] b(sbyte[] paramArrayOfByte)
	  {
		i.info("changeByteToSampleInterpolation method :: Start");
		sbyte[] arrayOfByte = new sbyte[4];
		sbyte b1 = 0;
		int[][] arrayOfInt = new int[2][];
		arrayOfInt[0] = new int[4096];
		arrayOfInt[1] = new int[4096];
		try
		{
		  StreamWriter bufferedWriter = new StreamWriter(this.j.a_Conflict + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + "packets_raw_data.txt");
		  for (sbyte b2 = 0; b2 < paramArrayOfByte.Length; b2++)
		  {
			bufferedWriter.Write(paramArrayOfByte[b2] + " \n");
		  }
		  bufferedWriter.Close();
		}
		catch (IOException iOException)
		{
		  Console.WriteLine(iOException.ToString());
		  Console.Write(iOException.StackTrace);
		}
		char c1;
		for (c1 = char.MinValue; b1 < arrayOfInt[0].Length && c1 < (char)(paramArrayOfByte.Length / 2); c1++)
		{
		  sbyte b2;
		  for (b2 = 0; b1 < arrayOfInt[0].Length && b2 < unchecked((sbyte)164); b2++)
		  {
			arrayOfByte[3] = paramArrayOfByte[c1++];
			arrayOfByte[2] = paramArrayOfByte[c1++];
			arrayOfByte[1] = paramArrayOfByte[c1++];
			arrayOfByte[0] = 0;
			ByteBuffer byteBuffer = ByteBuffer.wrap(arrayOfByte);
			byteBuffer.order(ByteOrder.nativeOrder());
			arrayOfInt[0][b1++] = byteBuffer.getInt(0) >> 8;
		  }
		  if (b1 == arrayOfInt[0].Length)
		  {
			for (b2 = 0; b2 < 18; b2++)
			{
			  c1++;
			}
		  }
		  else
		  {
			for (b2 = 0; b2 < 6; b2++)
			{
			  c1++;
			}
		  }
		  b2 = paramArrayOfByte[c1++];
		  if (!b_Conflict)
		  {
			if ((b2 & (sbyte)a_Conflict.a.a()) != 0)
			{
			  i.error("I2_STAT_INT1_END_TIMEOUT in sample no. " + (b1 - 1) + "-- original value: " + (b2 & (sbyte)a_Conflict.a.a()));
			}
			if ((b2 & (sbyte)a_Conflict.b.a()) != 0)
			{
			  i.error("I2_STAT_INT1_END_INVALID in sample no. " + (b1 - 1) + "-- original value: " + (b2 & (sbyte)a_Conflict.b.a()));
			}
			if ((b2 & (sbyte)a_Conflict.c.a()) != 0)
			{
			  i.error("I2_STAT_INT1_AVG_OVERFLOW in sample no. " + (b1 - 1) + "-- original value: " + (b2 & (sbyte)a_Conflict.c.a()));
			}
			if ((b2 & (sbyte)a_Conflict.d.a()) != 0)
			{
			  i.error("I2_STAT_INT1_CORE_INVALID_REGION in sample no. " + (b1 - 1) + "-- original value: " + (b2 & (sbyte)a_Conflict.d.a()));
			}
			if ((b2 & (sbyte)a_Conflict.e.a()) != 0)
			{
			  i.error("I2_STAT_INT1_CORE_TIMEOUT in sample no. " + (b1 - 1) + "-- original value: " + (b2 & (sbyte)a_Conflict.e.a()));
			}
			if ((b2 & (sbyte)a_Conflict.f.a()) != 0)
			{
			  i.error("I2_STAT_INT1_CORE_OVERFLOW in sample no. " + (b1 - 1) + "-- original value: " + (b2 & (sbyte)a_Conflict.f.a()));
			}
			if ((b2 & (sbyte)a_Conflict.g.a()) != 0)
			{
			  i.error("I2_STAT_INT1_START_TIMEOUT in sample no. " + (b1 - 1) + "-- original value: " + (b2 & (sbyte)a_Conflict.g.a()));
			}
			if ((b2 & (sbyte)a_Conflict.h.a()) != 0)
			{
			  i.error("I2_STAT_INT1_RUN_FAILED in sample no. " + (b1 - 1) + "-- original value: " + (b2 & (sbyte)a_Conflict.h.a()));
			  long[] arrayOfLong = this.j.c();
			  this.j.a(arrayOfLong, "t_after_error.reg");
			  throw new a(b_Conflict.aI);
			}
		  }
		}
		b1 = 0;
		c1 = 'ピ';
		while (b1 < arrayOfInt[1].Length && c1 < (char)paramArrayOfByte.Length)
		{
		  sbyte b2;
		  for (b2 = 0; b1 < arrayOfInt[1].Length && b2 < unchecked((sbyte)164); b2++)
		  {
			arrayOfByte[3] = paramArrayOfByte[c1++];
			arrayOfByte[2] = paramArrayOfByte[c1++];
			arrayOfByte[1] = paramArrayOfByte[c1++];
			arrayOfByte[0] = 0;
			ByteBuffer byteBuffer = ByteBuffer.wrap(arrayOfByte);
			byteBuffer.order(ByteOrder.nativeOrder());
			arrayOfInt[1][b1++] = byteBuffer.getInt(0) >> 8;
		  }
		  if (b1 == arrayOfInt[1].Length)
		  {
			for (b2 = 0; b2 < 18; b2++)
			{
			  c1++;
			}
		  }
		  else
		  {
			for (b2 = 0; b2 < 6; b2++)
			{
			  c1++;
			}
		  }
		  c1++;
		  b2 = paramArrayOfByte[++c1];
		  if (!b_Conflict)
		  {
			if ((b2 & (sbyte)a_Conflict.a.a()) != 0)
			{
			  i.error("I2_STAT_INT2_END_TIMEOUT in sample no. " + (b1 - 1) + "-- original value: " + (b2 & (sbyte)a_Conflict.a.a()));
			}
			if ((b2 & (sbyte)a_Conflict.b.a()) != 0)
			{
			  i.error("I2_STAT_INT2_END_INVALID in sample no. " + (b1 - 1) + "-- original value: " + (b2 & (sbyte)a_Conflict.b.a()));
			}
			if ((b2 & (sbyte)a_Conflict.c.a()) != 0)
			{
			  i.error("I2_STAT_INT2_AVG_OVERFLOW in sample no. " + (b1 - 1) + "-- original value: " + (b2 & (sbyte)a_Conflict.c.a()));
			}
			if ((b2 & (sbyte)a_Conflict.d.a()) != 0)
			{
			  i.error("I2_STAT_INT2_CORE_INVALID_REGION in sample no. " + (b1 - 1) + "-- original value: " + (b2 & (sbyte)a_Conflict.d.a()));
			}
			if ((b2 & (sbyte)a_Conflict.e.a()) != 0)
			{
			  i.error("I2_STAT_INT2_CORE_TIMEOUT in sample no. " + (b1 - 1) + "-- original value: " + (b2 & (sbyte)a_Conflict.e.a()));
			}
			if ((b2 & (sbyte)a_Conflict.f.a()) != 0)
			{
			  i.error("I2_STAT_INT2_CORE_OVERFLOW in sample no. " + (b1 - 1) + "-- original value: " + (b2 & (sbyte)a_Conflict.f.a()));
			}
			if ((b2 & (sbyte)a_Conflict.g.a()) != 0)
			{
			  i.error("I2_STAT_INT2_START_TIMEOUT in sample no. " + (b1 - 1) + "-- original value: " + (b2 & (sbyte)a_Conflict.g.a()));
			}
			if ((b2 & (sbyte)a_Conflict.h.a()) != 0)
			{
			  i.error("I2_STAT_INT2_RUN_FAILED in sample no. " + (b1 - 1) + "-- original value: " + (b2 & (sbyte)a_Conflict.h.a()));
			  long[] arrayOfLong = this.j.c();
			  this.j.a(arrayOfLong, "t_after_error.reg");
			  throw new a(b_Conflict.aQ);
			}
		  }
		}
		i.info("changeByteToSampleInterpolation method :: END");
		return arrayOfInt;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private int[][] a(byte[] paramArrayOfByte, int paramInt1, int paramInt2) throws a
	  private int[][] a(sbyte[] paramArrayOfByte, int paramInt1, int paramInt2)
	  {
		i.info("changeByteToSampleADCs method :: Start");
		sbyte[] arrayOfByte = new sbyte[4];
		sbyte b1 = 0;
		sbyte b2 = 0;
		sbyte b3 = 0;
		int n = paramInt1 / 8;
		int i1 = n * 8 + n * 1 + n * 1;
		int[][] arrayOfInt = new int[3][];
		arrayOfInt[0] = new int[n * 1];
		arrayOfInt[1] = new int[n * 1];
		arrayOfInt[2] = new int[n * 8];
		for (sbyte b4 = 0; b1 + b2 + b3 < i1 && b4 < paramArrayOfByte.Length; b4 += 20)
		{
		  for (sbyte b5 = 0; b5 < 24 && b1 + b2 + b3 < i1; b5++)
		  {
			if (paramInt2 == 15)
			{
			  sbyte b7;
			  for (b7 = 0; b7 < 1; b7++)
			  {
				arrayOfByte[3] = paramArrayOfByte[b4++];
				arrayOfByte[2] = paramArrayOfByte[b4++];
				arrayOfByte[1] = 0;
				arrayOfByte[0] = 0;
				ByteBuffer byteBuffer = ByteBuffer.wrap(arrayOfByte);
				byteBuffer.order(ByteOrder.nativeOrder());
				arrayOfInt[0][b1++] = byteBuffer.getInt(0) >> 16;
			  }
			  for (b7 = 0; b7 < 1; b7++)
			  {
				arrayOfByte[3] = paramArrayOfByte[b4++];
				arrayOfByte[2] = paramArrayOfByte[b4++];
				arrayOfByte[1] = 0;
				arrayOfByte[0] = 0;
				ByteBuffer byteBuffer = ByteBuffer.wrap(arrayOfByte);
				byteBuffer.order(ByteOrder.nativeOrder());
				arrayOfInt[1][b2++] = byteBuffer.getInt(0) >> 16;
			  }
			}
			else
			{
			  sbyte b7;
			  for (b7 = 0; b7 < 1; b7++)
			  {
				arrayOfByte[3] = paramArrayOfByte[b4++];
				arrayOfByte[2] = paramArrayOfByte[b4++];
				arrayOfByte[1] = paramArrayOfByte[b4++];
				arrayOfByte[0] = paramArrayOfByte[b4++];
				ByteBuffer byteBuffer = ByteBuffer.wrap(arrayOfByte);
				byteBuffer.order(ByteOrder.nativeOrder());
				arrayOfInt[0][b1++] = byteBuffer.getInt(0);
			  }
			  for (b7 = 0; b7 < 1; b7++)
			  {
				arrayOfByte[3] = 0;
				arrayOfByte[2] = 0;
				arrayOfByte[1] = 0;
				arrayOfByte[0] = 0;
				ByteBuffer byteBuffer = ByteBuffer.wrap(arrayOfByte);
				byteBuffer.order(ByteOrder.nativeOrder());
				arrayOfInt[1][b2++] = byteBuffer.getInt(0);
			  }
			}
			for (sbyte b6 = 0; b6 < 8; b6++)
			{
			  arrayOfByte[3] = paramArrayOfByte[b4++];
			  arrayOfByte[2] = paramArrayOfByte[b4++];
			  arrayOfByte[1] = 0;
			  arrayOfByte[0] = 0;
			  ByteBuffer byteBuffer = ByteBuffer.wrap(arrayOfByte);
			  byteBuffer.order(ByteOrder.nativeOrder());
			  arrayOfInt[2][b3++] = byteBuffer.getInt(0) >> 16;
			}
		  }
		}
		i.info("changeByteToSampleADCs method :: END");
		return arrayOfInt;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private int[][] b(byte[] paramArrayOfByte, int paramInt1, int paramInt2) throws a
	  private int[][] b(sbyte[] paramArrayOfByte, int paramInt1, int paramInt2)
	  {
		i.info("changeByteToSampleActualDMux method :: Start");
		sbyte[] arrayOfByte = new sbyte[4];
		sbyte b1 = 0;
		sbyte b2 = 0;
		sbyte b3 = 0;
		int n = paramInt1 / 8;
		int i1 = n * 8 + n * 1 + n * 1;
		int[][] arrayOfInt = new int[2][];
		arrayOfInt[0] = new int[n * 1];
		arrayOfInt[1] = new int[n * 1];
		for (sbyte b4 = 0; b1 + b2 + b3 < i1 && b4 < paramArrayOfByte.Length; b4 += 8)
		{
		  for (sbyte b5 = 0; b5 < 82 && b1 + b2 + b3 < i1; b5++)
		  {
			if (paramInt2 == 15)
			{
			  sbyte b6;
			  for (b6 = 0; b6 < 1; b6++)
			  {
				arrayOfByte[3] = paramArrayOfByte[b4++];
				arrayOfByte[2] = paramArrayOfByte[b4++];
				arrayOfByte[1] = 0;
				arrayOfByte[0] = 0;
				ByteBuffer byteBuffer = ByteBuffer.wrap(arrayOfByte);
				byteBuffer.order(ByteOrder.nativeOrder());
				arrayOfInt[0][b1++] = byteBuffer.getInt(0) >> 16;
			  }
			  for (b6 = 0; b6 < 1; b6++)
			  {
				arrayOfByte[3] = paramArrayOfByte[b4++];
				arrayOfByte[2] = paramArrayOfByte[b4++];
				arrayOfByte[1] = 0;
				arrayOfByte[0] = 0;
				ByteBuffer byteBuffer = ByteBuffer.wrap(arrayOfByte);
				byteBuffer.order(ByteOrder.nativeOrder());
				arrayOfInt[1][b2++] = byteBuffer.getInt(0) >> 16;
			  }
			}
			else
			{
			  sbyte b6;
			  for (b6 = 0; b6 < 1; b6++)
			  {
				arrayOfByte[3] = paramArrayOfByte[b4++];
				arrayOfByte[2] = paramArrayOfByte[b4++];
				arrayOfByte[1] = paramArrayOfByte[b4++];
				arrayOfByte[0] = paramArrayOfByte[b4++];
				ByteBuffer byteBuffer = ByteBuffer.wrap(arrayOfByte);
				byteBuffer.order(ByteOrder.nativeOrder());
				arrayOfInt[0][b1++] = byteBuffer.getInt(0);
			  }
			  for (b6 = 0; b6 < 1; b6++)
			  {
				arrayOfByte[3] = 0;
				arrayOfByte[2] = 0;
				arrayOfByte[1] = 0;
				arrayOfByte[0] = 0;
				ByteBuffer byteBuffer = ByteBuffer.wrap(arrayOfByte);
				byteBuffer.order(ByteOrder.nativeOrder());
				arrayOfInt[1][b2++] = byteBuffer.getInt(0);
			  }
			}
			b4++;
			b4++;
			b3++;
			b3++;
		  }
		}
		i.info("changeByteToSampleActualDMux method :: END");
		return arrayOfInt;
	  }
	}


	/* Location:              D:\jobs\BalitTanah.SoilSensingKit\Decompile Driver\SDK v4.3\SDKv4.3\bin_win_x64\TAIFDriver.jar!\sws\TAIFDriver\a.class
	 * Java compiler version: 7 (51.0)
	 * JD-Core Version:       1.0.7
	 */
}