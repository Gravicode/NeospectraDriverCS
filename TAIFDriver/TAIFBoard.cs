﻿using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace sws.TAIFDriver
{
	using Logger = org.apache.log4j.Logger;
	using a = sws.TAIFDriver.a.a;
	using b = sws.TAIFDriver.a.b;
	using c = sws.TAIFDriver.a.c;
	using d = sws.TAIFDriver.a.d;
	using e = sws.TAIFDriver.a.e;
	using f = sws.TAIFDriver.a.f;
	using g = sws.TAIFDriver.a.g;
	using h = sws.TAIFDriver.a.h;
	using i = sws.TAIFDriver.a.i;
	using j = sws.TAIFDriver.a.j;
	using k = sws.TAIFDriver.a.k;
	using a = sws.TAIFDriver.b.a;
	using a = sws.TAIFDriver.c.a;

	public class TAIFBoard
	{
//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
	  private static Logger b_Conflict = Logger.getLogger(typeof(TAIFBoard));

//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
	  private string c_Conflict;

//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
	  private int d_Conflict;

//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
	  private int e_Conflict;

//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
	  private bool f_Conflict = false;

//JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods:
	  public string a_Conflict;

//JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
	  [DllImport("unknown")]
	  private extern int cyDriver_init();

//JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
	  [DllImport("unknown")]
	  private extern int cyDriver_connect(short paramShort, sbyte[] paramArrayOfByte);

//JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
	  [DllImport("unknown")]
	  private extern int cyDriver_close();

//JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
	  [DllImport("unknown")]
	  private extern int cyDriver_dataOutTransfer(int paramInt1, int paramInt2, int paramInt3, sbyte[] paramArrayOfByte);

//JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
	  [DllImport("unknown")]
	  private extern int cyDriver_asyncDataOutTransfer(int paramInt1, int paramInt2, int paramInt3, sbyte[] paramArrayOfByte);

//JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
	  [DllImport("unknown")]
	  private extern int cyDriver_dataInTransfer(int paramInt1, int paramInt2, int paramInt3, sbyte[] paramArrayOfByte);

//JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
	  [DllImport("unknown")]
	  private extern int cyDriver_asyncDataInTransfer(int paramInt1, int paramInt2, int paramInt3);

//JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
	  [DllImport("unknown")]
	  private extern int cyDriver_asyncDataInGetData(sbyte[] paramArrayOfByte);

//JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
	  [DllImport("unknown")]
	  private extern int cyDriver_controlOutTransfer(int paramInt1, int paramInt2, int paramInt3, sbyte[] paramArrayOfByte);

//JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
	  [DllImport("unknown")]
	  private extern int cyDriver_controlInTransfer(int paramInt1, int paramInt2, int paramInt3, sbyte[] paramArrayOfByte);

//JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
	  [DllImport("unknown")]
	  private extern int cyDriver_selfTest();

//JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
	  [DllImport("unknown")]
	  private extern double cyDriver_getDataInProgress();

//JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
	  [DllImport("unknown")]
	  private extern double cyDriver_getDataOutProgress();

//JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
	  [DllImport("unknown")]
	  private extern double cyDriver_getControlInProgress();

//JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
	  [DllImport("unknown")]
	  private extern double cyDriver_getControlOutProgress();

//JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
	  [DllImport("unknown")]
	  private extern byte cyDriver_isAsyncDataInDone();

//JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
	  [DllImport("unknown")]
	  private extern byte cyDriver_isAsyncDataOutDone();

//JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
	  [DllImport("unknown")]
	  private extern int cyDriver_getAsyncDataInErrorCode();

//JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
	  [DllImport("unknown")]
	  private extern int cyDriver_getAsyncDataOutErrorCode();

//JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
	  [DllImport("unknown")]
	  private extern int cyDriver_resetDevice();

//JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
	  [DllImport("unknown")]
	  private extern int cyDriver_checkDeviceStatus(short paramShort);

//JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
	  [DllImport("unknown")]
	  private extern void cyDriver_setDataTimeoutMilliSec(int paramInt);

//JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
	  [DllImport("unknown")]
	  private extern void cyDriver_setControlTimeoutMilliSec(short paramShort);

	  public TAIFBoard(int paramInt)
	  {
		this.e_Conflict = paramInt;
		this.a_Conflict = System.getProperty("user.dir");
		cyDriver_init();
	  }

	  public TAIFBoard(int paramInt, string paramString)
	  {
		this.e_Conflict = paramInt;
		this.a_Conflict = paramString;
		cyDriver_init();
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void a(boolean... paramVarArgs) throws a
	  public virtual void a(params bool[] paramVarArgs)
	  {
		b_Conflict.info("initiateBoard method :: Start");
		long l = 0L;
		try
		{
		  if (paramVarArgs == null)
		  {
			l = a(c_Conflict.i.a(), e_Conflict.i.a(), d_Conflict.i.a());
		  }
		  else if (paramVarArgs[0] == true)
		  {
			l = 0L;
		  }
		  else
		  {
			l = a(c_Conflict.i.a(), e_Conflict.i.a(), d_Conflict.i.a());
		  }
		  if (l == 0L)
		  {
			this.f_Conflict = false;
			throw new Exception();
		  }
		  this.f_Conflict = true;
		}
		catch (Exception)
		{
		  this.f_Conflict = false;
		  e();
		  cyDriver_close();
		  sbyte[] arrayOfByte = new sbyte[this.a_Conflict.GetBytes(Encoding.ASCII).length + 1];
		  Array.Copy(this.a_Conflict.GetBytes(Encoding.ASCII), 0, arrayOfByte, 0, this.a_Conflict.GetBytes(Encoding.ASCII).length);
		  arrayOfByte[arrayOfByte.Length - 1] = 0;
		  int i = cyDriver_connect((short)this.e_Conflict, arrayOfByte);
		  if (i != b_Conflict.a.a())
		  {
			b_Conflict b1 = b_Conflict.a(i);
			b_Conflict.error("calling cyDriver_connect has failed with error code returned" + b1);
			throw new a("calling cyDriver_connect has failed with error code returned" + b1, b1);
		  }
		  int j = cyDriver_selfTest();
		  if (j == b_Conflict.a.a())
		  {
			f();
			try
			{
			  if (paramVarArgs[1] == true)
			  {
				Console.WriteLine("Stopping initialization after loading FW");
				return;
			  }
			}
			catch (Exception)
			{
			}
			h();
			this.f_Conflict = true;
		  }
		  else
		  {
			b_Conflict b1 = b_Conflict.a(j);
			b_Conflict.error("calling cyDriver_selfTest() has failed with error code " + b1);
			throw new a("calling cyDriver_selfTest() has failed with error code " + b1, b1);
		  }
		}
		b_Conflict.info("initiateBoard method :: END");
	  }

	  public virtual int a()
	  {
		int i = cyDriver_checkDeviceStatus((short)this.e_Conflict);
		b_Conflict.info(Convert.ToInt32(i));
		b_Conflict.info(Convert.ToBoolean(this.f_Conflict));
		if (i == b_Conflict.a.a() && !this.f_Conflict)
		{
		  b_Conflict.error("check board status succeeded from cyDriver side, but the initialization from TAIFBoardDriver side has failed ");
		  i = b_Conflict.aa.a();
		}
		if (i != b_Conflict.a.a() && i != b_Conflict.aa.a() && i != b_Conflict.g.a())
		{
		  b_Conflict b1 = b_Conflict.a(i);
		  b_Conflict.error("Calling cyDriver_checkDeviceStatus() method has returned unexpected error code " + b1);
		  throw new a("Calling cyDriver_checkDeviceStatus() method has returned unexpected error code " + b1, b1);
		}
		if (i == b_Conflict.aa.a() || i == b_Conflict.g.a())
		{
		  this.f_Conflict = false;
		}
		return i;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public byte a(int paramInt) throws a, InterruptedException
	  public virtual sbyte a(int paramInt)
	  {
		b_Conflict.info("TAIFBoard - readEEPROM(int address) :: Start :: address = " + paramInt);
		int i = b_Conflict.a.a();
		sbyte[] arrayOfByte1 = a(g.a);
		sbyte[] arrayOfByte2 = a(g.a);
		arrayOfByte1[1] = (sbyte)f_Conflict.e.a();
		arrayOfByte1[2] = a_Conflict.a(paramInt)[0];
		arrayOfByte1[3] = a_Conflict.a(paramInt)[1];
		if (arrayOfByte1[3] == 0 && (arrayOfByte1[2] == 0 || arrayOfByte1[2] == 1 || arrayOfByte1[2] == 2 || arrayOfByte1[2] == 3 || arrayOfByte1[2] == 4 || arrayOfByte1[2] == 5 || arrayOfByte1[2] == 6 || arrayOfByte1[2] == 7))
		{
		  b_Conflict.error("TAIFBoard - readEEPROM(int address):: Error : illegalMemoryWritingAddress");
		  throw new a("TAIFBoard - readEEPROM(int address):: Error : illegalMemoryWritingAddress", b_Conflict.ae);
		}
		i = cyDriver_controlOutTransfer(64, 64, 1, arrayOfByte1);
		if (i != b_Conflict.a.a())
		{
		  b_Conflict b3 = b_Conflict.a(i);
		  b_Conflict.error("TAIFBoard - readEEPROM(int address):: Error : " + b3);
		  throw new a("TAIFBoard - readEEPROM(int address):: Error : " + b3, b3);
		}
		Thread.Sleep(5L);
		i = cyDriver_controlInTransfer(64, 64, 1, arrayOfByte2);
		if (i != b_Conflict.a.a())
		{
		  b_Conflict b3 = b_Conflict.a(i);
		  b_Conflict.error("TAIFBoard - readEEPROM(int address):: Error : " + b3);
		  throw new a("TAIFBoard - readEEPROM(int address):: Error : " + b3, b3);
		}
		for (sbyte b2 = 0; b2 < 12; b2++)
		{
		  if (arrayOfByte2[b2] != arrayOfByte1[b2])
		  {
			b_Conflict.error("TAIFBoard - readEEPROM(int address):: Error: out packet and in packet headers don't match");
			throw new a("TAIFBoard - readEEPROM(int address):: Error: out packet and in packet headers don't match", b_Conflict.ab);
		  }
		}
		sbyte b1 = arrayOfByte2[12];
		b_Conflict.info("TAIFBoard - readEEPROM(int address) :: END :: value = " + b1);
		return b1;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public byte[] a(int paramInt1, int paramInt2) throws a, InterruptedException
	  public virtual sbyte[] a(int paramInt1, int paramInt2)
	  {
		int k;
		int j;
		sbyte b1;
		b_Conflict.info("TAIFBoard - readEEPROM(int address, int size) :: START :: address= " + paramInt1 + ", size=" + paramInt2);
		int i = b_Conflict.a.a();
		sbyte[] arrayOfByte = new sbyte[paramInt2];
		if (paramInt2 <= 32)
		{
		  b1 = 0;
		  k = 1;
		  j = paramInt2;
		}
		else
		{
		  b1 = 32;
		  k = (int)Math.Ceiling(paramInt2 / 32.0D);
		  j = 32 - k * 32 - paramInt2;
		}
		b_Conflict.info("TAIFBoard - readEEPROM(int address, int size) :: dataSizePerPacket= " + b1 + ", noPackets=" + k + ", dataSizePerLastPacket= " + j);
		int m = paramInt1;
		for (sbyte b2 = 0; b2 < k; b2++)
		{
		  int n;
		  b_Conflict.info("TAIFBoard - readEEPROM(int address, int size) :: packet " + b2);
		  sbyte[] arrayOfByte1 = a(g.a);
		  sbyte[] arrayOfByte2 = a(g.a);
		  arrayOfByte1[1] = (sbyte)f_Conflict.e.a();
		  arrayOfByte1[2] = a_Conflict.a(m)[0];
		  arrayOfByte1[3] = a_Conflict.a(m)[1];
		  if (arrayOfByte1[3] == 0 && (arrayOfByte1[2] == 0 || arrayOfByte1[2] == 1 || arrayOfByte1[2] == 2 || arrayOfByte1[2] == 3 || arrayOfByte1[2] == 4 || arrayOfByte1[2] == 5 || arrayOfByte1[2] == 6 || arrayOfByte1[2] == 7))
		  {
			b_Conflict.error("TAIFBoard - readEEPROM(int address, int size) :: Illegal Memory Writing Address");
			throw new a("TAIFBoard - readEEPROM(int address, int size) :: Illegal Memory Writing Address", b_Conflict.ae);
		  }
		  if (b2 < k - 1)
		  {
			n = b1;
		  }
		  else
		  {
			n = j;
		  }
		  m += n;
		  arrayOfByte1[4] = a_Conflict.a(n)[0];
		  i = cyDriver_controlOutTransfer(64, 64, 1, arrayOfByte1);
		  if (i != b_Conflict.a.a())
		  {
			b_Conflict b4 = b_Conflict.a(i);
			b_Conflict.error("TAIFBoard - readEEPROM(int address, int size) :: " + b4);
			throw new a("TAIFBoard - readEEPROM(int address, int size) :: " + b4, b4);
		  }
		  Thread.Sleep(5L);
		  i = cyDriver_controlInTransfer(64, 64, 1, arrayOfByte2);
		  if (i != b_Conflict.a.a())
		  {
			b_Conflict b4 = b_Conflict.a(i);
			b_Conflict.error("TAIFBoard - readEEPROM(int address, int size) :: " + b4);
			throw new a("TAIFBoard - readEEPROM(int address, int size) :: " + b4, b4);
		  }
		  sbyte b3;
		  for (b3 = 0; b3 < 12; b3++)
		  {
			if (arrayOfByte2[b3] != arrayOfByte1[b3])
			{
			  b_Conflict.error("TAIFBoard - readEEPROM(int address, int size) :: OUT and IN packets have Difffenet headers");
			  throw new a("TAIFBoard - readEEPROM(int address, int size) :: OUT and IN packets have Difffenet headers", b_Conflict.ab);
			}
		  }
		  for (b3 = 0; b3 < n; b3++)
		  {
			arrayOfByte[b2 * b1 + b3] = arrayOfByte2[12 + b3];
		  }
		}
		b_Conflict.info("TAIFBoard - readEEPROM(int address, int size) :: END : value = " + StringHelper.NewString(arrayOfByte, Charset.forName("US-ASCII")));
		return arrayOfByte;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void a(int paramInt, byte paramByte) throws a, InterruptedException
	  public virtual void a(int paramInt, sbyte paramByte)
	  {
		b_Conflict.info("TAIFBoard - writeEEPROM(int address, byte value) :: START : address = " + paramInt + ", value = " + paramByte);
		int i = b_Conflict.a.a();
		sbyte[] arrayOfByte1 = a(g.a);
		sbyte[] arrayOfByte2 = a(g.a);
		arrayOfByte1[1] = (sbyte)f_Conflict.d.a();
		sbyte[] arrayOfByte3 = a_Conflict.a(paramInt);
		arrayOfByte1[2] = arrayOfByte3[0];
		arrayOfByte1[3] = arrayOfByte3[1];
		arrayOfByte1[12] = paramByte;
		if (arrayOfByte1[3] == 0 && (arrayOfByte1[2] == 0 || arrayOfByte1[2] == 1 || arrayOfByte1[2] == 2 || arrayOfByte1[2] == 3 || arrayOfByte1[2] == 4 || arrayOfByte1[2] == 5 || arrayOfByte1[2] == 6 || arrayOfByte1[2] == 7))
		{
		  b_Conflict.error("TAIFBoard - writeEEPROM(int address, byte value) :: " + b_Conflict.ae);
		  throw new a("TAIFBoard - writeEEPROM(int address, byte value) :: " + b_Conflict.ae, b_Conflict.ae);
		}
		i = cyDriver_controlOutTransfer(64, 64, 1, arrayOfByte1);
		if (i != b_Conflict.a.a())
		{
		  b_Conflict b2 = b_Conflict.a(i);
		  b_Conflict.error("TAIFBoard - writeEEPROM(int address, byte value) :: " + b2);
		  throw new a("TAIFBoard - writeEEPROM(int address, byte value) :: " + b2, b2);
		}
		Thread.Sleep(5L);
		i = cyDriver_controlInTransfer(64, 64, 1, arrayOfByte2);
		if (i != b_Conflict.a.a())
		{
		  b_Conflict b2 = b_Conflict.a(i);
		  b_Conflict.error("TAIFBoard - writeEEPROM(int address, byte value) :: " + b2);
		  throw new a("TAIFBoard - writeEEPROM(int address, byte value) :: " + b2, b2);
		}
		for (sbyte b1 = 0; b1 < 12; b1++)
		{
		  if (arrayOfByte2[b1] != arrayOfByte1[b1])
		  {
			b_Conflict.error("TAIFBoard - writeEEPROM(int address, byte value) :: OUT and IN packets have different headers");
			throw new a("TAIFBoard - writeEEPROM(int address, byte value) :: OUT and IN packets have different headers", b_Conflict.ab);
		  }
		}
		b_Conflict.info("TAIFBoard - writeEEPROM(int address, byte value :: END");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void a(int paramInt1, int paramInt2, byte[] paramArrayOfByte) throws a, InterruptedException
	  public virtual void a(int paramInt1, int paramInt2, sbyte[] paramArrayOfByte)
	  {
		int k;
		int j;
		sbyte b1;
		b_Conflict.info("TAIFBoard - writeEEPROM(int pAddress, int size, byte[] value) :: START : address = " + paramInt1 + ", size = " + paramInt2 + ", value = " + StringHelper.NewString(paramArrayOfByte, Charset.forName("US-ASCII")));
		int i = b_Conflict.a.a();
		if (paramInt2 <= 32)
		{
		  b1 = 0;
		  k = 1;
		  j = paramInt2;
		}
		else
		{
		  b1 = 32;
		  k = (int)Math.Ceiling(paramInt2 / 32.0D);
		  j = 32 - k * 32 - paramInt2;
		}
		int m = paramInt1;
		for (sbyte b2 = 0; b2 < k; b2++)
		{
		  int n;
		  sbyte[] arrayOfByte1 = a(g.a);
		  sbyte[] arrayOfByte2 = a(g.a);
		  sbyte[] arrayOfByte3 = a(g.a);
		  sbyte[] arrayOfByte4 = a(g.a);
		  arrayOfByte1[1] = (sbyte)f_Conflict.d.a();
		  arrayOfByte3[1] = (sbyte)f_Conflict.e.a();
		  sbyte[] arrayOfByte5 = a_Conflict.a(m);
		  arrayOfByte1[2] = arrayOfByte5[0];
		  arrayOfByte1[3] = arrayOfByte5[1];
		  arrayOfByte3[2] = arrayOfByte5[0];
		  arrayOfByte3[3] = arrayOfByte5[1];
		  if (arrayOfByte1[3] == 0 && (arrayOfByte1[2] == 0 || arrayOfByte1[2] == 1 || arrayOfByte1[2] == 2 || arrayOfByte1[2] == 3 || arrayOfByte1[2] == 4 || arrayOfByte1[2] == 5 || arrayOfByte1[2] == 6 || arrayOfByte1[2] == 7))
		  {
			b_Conflict.error("TAIFBoard - WriteEEPROM(int pAddress, int size, byte[] value) :: " + b_Conflict.ae);
			throw new a("TAIFBoard - WriteEEPROM(int pAddress, int size, byte[] value) :: " + b_Conflict.ae, b_Conflict.ae);
		  }
		  if (arrayOfByte1[3] == 0 && (arrayOfByte1[2] == 0 || arrayOfByte1[2] == 1 || arrayOfByte1[2] == 2 || arrayOfByte1[2] == 3 || arrayOfByte1[2] == 4 || arrayOfByte1[2] == 5 || arrayOfByte1[2] == 6 || arrayOfByte1[2] == 7))
		  {
			b_Conflict.error("TAIFBoard - WriteEEPROM(int pAddress, int size, byte[] value) :: " + b_Conflict.ae);
			throw new a("TAIFBoard - WriteEEPROM(int pAddress, int size, byte[] value) :: " + b_Conflict.ae, b_Conflict.ae);
		  }
		  if (b2 < k - 1)
		  {
			n = b1;
		  }
		  else
		  {
			n = j;
		  }
		  if (arrayOfByte1[3] != a_Conflict.a(m + n - 1)[1] || (arrayOfByte1[2] & 0xC0) != (a_Conflict.a(m + n - 1)[0] & 0xC0))
		  {
			b_Conflict.error("TAIFBoard - WriteEEPROM(int pAddress, int size, byte[] value) :: " + b_Conflict.ae);
			throw new a("TAIFBoard - WriteEEPROM(int pAddress, int size, byte[] value) :: " + b_Conflict.ae, b_Conflict.ae);
		  }
		  arrayOfByte1[4] = a_Conflict.a(n)[0];
		  arrayOfByte3[4] = a_Conflict.a(n)[0];
		  sbyte b3;
		  for (b3 = 0; b3 < n; b3++)
		  {
			arrayOfByte1[12 + b3] = paramArrayOfByte[b2 * b1 + b3];
		  }
		  i = cyDriver_controlOutTransfer(64, 64, 1, arrayOfByte1);
		  if (i != b_Conflict.a.a())
		  {
			b_Conflict b4 = b_Conflict.a(i);
			b_Conflict.error("TAIFBoard - WriteEEPROM(int pAddress, int size, byte[] value) :: " + b4);
			throw new a("TAIFBoard - WriteEEPROM(int pAddress, int size, byte[] value) :: " + b4, b4);
		  }
		  Thread.Sleep(5L);
		  i = cyDriver_controlInTransfer(64, 64, 1, arrayOfByte2);
		  if (i != b_Conflict.a.a())
		  {
			b_Conflict b4 = b_Conflict.a(i);
			b_Conflict.error("TAIFBoard - WriteEEPROM(int pAddress, int size, byte[] value) :: " + b4);
			throw new a("TAIFBoard - WriteEEPROM(int pAddress, int size, byte[] value) :: " + b4, b4);
		  }
		  for (b3 = 0; b3 < 12; b3++)
		  {
			if (arrayOfByte2[b3] != arrayOfByte1[b3])
			{
			  b_Conflict.error("TAIFBoard - WriteEEPROM(int pAddress, int size, byte[] value) :: " + b_Conflict.ab);
			  throw new a("TAIFBoard - WriteEEPROM(int pAddress, int size, byte[] value) :: " + b_Conflict.ab, b_Conflict.ab);
			}
		  }
		  Thread.Sleep(5L);
		  cyDriver_controlOutTransfer(64, 64, 1, arrayOfByte3);
		  if (i != b_Conflict.a.a())
		  {
			b_Conflict b4 = b_Conflict.a(i);
			b_Conflict.error("TAIFBoard - WriteEEPROM(int pAddress, int size, byte[] value) :: " + b4);
			throw new a("TAIFBoard - WriteEEPROM(int pAddress, int size, byte[] value) :: " + b4, b4);
		  }
		  Thread.Sleep(5L);
		  cyDriver_controlInTransfer(64, 64, 1, arrayOfByte4);
		  if (i != b_Conflict.a.a())
		  {
			b_Conflict b4 = b_Conflict.a(i);
			b_Conflict.error("TAIFBoard - WriteEEPROM(int pAddress, int size, byte[] value) :: " + b4);
			throw new a("TAIFBoard - WriteEEPROM(int pAddress, int size, byte[] value) :: " + b4, b4);
		  }
		  for (b3 = 0; b3 < 12; b3++)
		  {
			if (arrayOfByte4[b3] != arrayOfByte3[b3])
			{
			  b_Conflict.error("TAIFBoard - WriteEEPROM(int pAddress, int size, byte[] value) :: " + b_Conflict.ab);
			  throw new a("TAIFBoard - WriteEEPROM(int pAddress, int size, byte[] value) :: " + b_Conflict.ab, b_Conflict.ab);
			}
		  }
		  for (b3 = 0; b3 < n; b3++)
		  {
			if (arrayOfByte4[12 + b3] != paramArrayOfByte[b2 * b1 + b3])
			{
			  b_Conflict.error("TAIFBoard - WriteEEPROM(int pAddress, int size, byte[] value) :: " + b_Conflict.am);
			  throw new a("TAIFBoard - WriteEEPROM(int pAddress, int size, byte[] value) :: " + b_Conflict.am, b_Conflict.am);
			}
		  }
		  m += n;
		}
		b_Conflict.info("TAIFBoard - writeEEPROM(int pAddress, int size, byte[] value) :: END");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void b() throws a
	  public virtual void b()
	  {
		sbyte[] arrayOfByte1 = a(g.b);
		sbyte[] arrayOfByte2 = a(g.b);
		arrayOfByte1[1] = (sbyte)f_Conflict.k.a();
		int i = cyDriver_dataOutTransfer(arrayOfByte1.Length, arrayOfByte1.Length, 1, arrayOfByte1);
		if (i != b_Conflict.a.a())
		{
		  b_Conflict b1 = b_Conflict.a(i);
		  b_Conflict.error("calling cyDriver_dataOutTransfer() has failed with error code " + b1);
		  throw new a("calling cyDriver_dataOutTransfer() has failed with error code " + b1, b1);
		}
		i = cyDriver_dataInTransfer(arrayOfByte2.Length, arrayOfByte2.Length, 1, arrayOfByte2);
		if (i != b_Conflict.a.a())
		{
		  b_Conflict b1 = b_Conflict.a(i);
		  b_Conflict.error("calling cyDriver_dataInTransfer() has failed with error code " + b1);
		  throw new a("calling cyDriver_dataInTransfer() has failed with error code " + b1, b1);
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public long a(int paramInt1, int paramInt2, int paramInt3) throws a
	  public virtual long a(int paramInt1, int paramInt2, int paramInt3)
	  {
		b_Conflict.info("readFPGARegister method :: Start");
		long l1 = c(paramInt1);
		long l2 = a(l1, paramInt2, paramInt3);
		b_Conflict.info("readFPGARegister method :: End");
		return l2;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void a(int paramInt1, long paramLong, int paramInt2, int paramInt3) throws a
	  public virtual void a(int paramInt1, long paramLong, int paramInt2, int paramInt3)
	  {
		b_Conflict.info("writeFPGARegister method :: Start");
		long l1 = c(paramInt1);
		long l2 = a(l1, paramLong, paramInt2, paramInt3);
		a(paramInt1, l2);
		b_Conflict.info("writeFPGARegister method :: End");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public long b(int paramInt1, int paramInt2, int paramInt3) throws a
	  public virtual long b(int paramInt1, int paramInt2, int paramInt3)
	  {
		b_Conflict.info("readASICRegister method :: Start");
		int i = b(paramInt1);
		long l1 = d(i);
		long l2 = a(l1, paramInt2, paramInt3);
		b_Conflict.info("readASICRegister method :: END");
		return l2;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void b(int paramInt1, long paramLong, int paramInt2, int paramInt3) throws a
	  public virtual void b(int paramInt1, long paramLong, int paramInt2, int paramInt3)
	  {
		b_Conflict.info("writeASICRegister method :: Start");
		int i = b(paramInt1);
		long l1 = d(i);
		long l2 = a(l1, paramLong, paramInt2, paramInt3);
		b(i, l2);
		b_Conflict.info("writeASICRegister method :: END");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void a(long[] paramArrayOfLong) throws a
	  public virtual void a(long[] paramArrayOfLong)
	  {
		b_Conflict.info("writeAllASICRegisters method :: Start");
		for (sbyte b1 = 0; b1 < 89; b1++)
		{
		  int i = b(b1);
		  b(i, paramArrayOfLong[b1]);
		}
		b_Conflict.info("writeAllASICRegisters method :: END");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public long[] c() throws a
	  public virtual long[] c()
	  {
		b_Conflict.info("readAllASICRegisters method :: Start");
		long[] arrayOfLong = new long[89];
		for (sbyte b1 = 0; b1 < 89; b1++)
		{
		  int i = b(b1);
		  arrayOfLong[b1] = d(i);
		}
		b_Conflict.info("readAllASICRegisters method :: END");
		return arrayOfLong;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void d() throws a
	  public virtual void d()
	  {
		b_Conflict.info("resetFIFOs method :: Start");
		i();
		b();
		b_Conflict.info("resetFIFOs method :: End");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public byte[] b(int paramInt1, int paramInt2) throws a, InterruptedException
	  public virtual sbyte[] b(int paramInt1, int paramInt2)
	  {
		b_Conflict.info("streamIn method :: Start");
		b();
		cyDriver_setDataTimeoutMilliSec(paramInt2 + 5000);
		int i = cyDriver_asyncDataInTransfer(paramInt1, 512, 50);
		if (i != b_Conflict.a.a())
		{
		  b_Conflict b1 = b_Conflict.a(i);
		  b_Conflict.error("calling cyDriver_asyncDataInTransfer() has failed with error code " + b1);
		  throw new a("calling cyDriver_asyncDataInTransfer() has failed with error code " + b1, b1);
		}
		p();
		b_Conflict.info("Finish submit in transfers");
		while (cyDriver_isAsyncDataInDone() == 0)
		{
		  b_Conflict.info("wait for transfers to finish");
		}
		b_Conflict.info("streaming finished");
		b();
		sbyte[] arrayOfByte1 = new sbyte[paramInt1];
		i = cyDriver_asyncDataInGetData(arrayOfByte1);
		if (i != b_Conflict.a.a())
		{
		  b_Conflict b1 = b_Conflict.a(i);
		  b_Conflict.error("calling cyDriver_asyncDataInGetData() has failed with error code " + b1);
		  throw new a("calling cyDriver_asyncDataInGetData() has failed with error code " + b1, b1);
		}
		a(c_Conflict.V.a(), 0L, e_Conflict.V.a(), d_Conflict.V.a());
		sbyte[] arrayOfByte2 = a(arrayOfByte1);
		b_Conflict.info("streamIn method :: End");
		b_Conflict.info("handleStreamInCompletedAction finished");
		return arrayOfByte2;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public byte[] c(int paramInt1, int paramInt2) throws a, InterruptedException
	  public virtual sbyte[] c(int paramInt1, int paramInt2)
	  {
		b_Conflict.info("streamIn method :: Start");
		cyDriver_setDataTimeoutMilliSec(paramInt2 + 5000);
		int i = cyDriver_asyncDataInTransfer(paramInt1, 512, 50);
		if (i != b_Conflict.a.a())
		{
		  b_Conflict b1 = b_Conflict.a(i);
		  b_Conflict.error("calling cyDriver_asyncDataInTransfer() has failed with error code " + b1);
		  throw new a("calling cyDriver_asyncDataInTransfer() has failed with error code " + b1, b1);
		}
		p();
		b_Conflict.info("Finish submit in transfers");
		while (cyDriver_isAsyncDataInDone() == 0)
		{
		  b_Conflict.info("wait for transfers to finish");
		}
		b_Conflict.info("streaming finished");
		sbyte[] arrayOfByte = new sbyte[paramInt1];
		i = cyDriver_asyncDataInGetData(arrayOfByte);
		if (i != b_Conflict.a.a())
		{
		  b_Conflict b1 = b_Conflict.a(i);
		  b_Conflict.error("calling cyDriver_asyncDataInGetData() has failed with error code " + b1);
		  throw new a("calling cyDriver_asyncDataInGetData() has failed with error code " + b1, b1);
		}
		return arrayOfByte;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public byte[] d(int paramInt1, int paramInt2) throws a, InterruptedException
	  public virtual sbyte[] d(int paramInt1, int paramInt2)
	  {
		b_Conflict.info("streamIn method :: Start");
		b();
		cyDriver_setDataTimeoutMilliSec(paramInt2 + 5000);
		int i = cyDriver_asyncDataInTransfer(paramInt1, 512, 512);
		if (i != b_Conflict.a.a())
		{
		  b_Conflict b1 = b_Conflict.a(i);
		  b_Conflict.error("calling cyDriver_asyncDataInTransfer() has failed with error code " + b1);
		  throw new a("calling cyDriver_asyncDataInTransfer() has failed with error code " + b1, b1);
		}
		p();
		b_Conflict.info("Finish submit in transfers");
		while (cyDriver_isAsyncDataInDone() == 0)
		{
		  b_Conflict.info("wait for transfers to finish");
		}
		b_Conflict.info("streaming finished");
		b();
		sbyte[] arrayOfByte1 = new sbyte[paramInt1];
		i = cyDriver_asyncDataInGetData(arrayOfByte1);
		if (i != b_Conflict.a.a())
		{
		  b_Conflict b1 = b_Conflict.a(i);
		  b_Conflict.error("calling cyDriver_asyncDataInGetData() has failed with error code " + b1);
		  throw new a("calling cyDriver_asyncDataInGetData() has failed with error code " + b1, b1);
		}
		a(c_Conflict.w.a(), 0L, e_Conflict.w.a(), d_Conflict.w.a());
		sbyte[] arrayOfByte2 = a(arrayOfByte1);
		b_Conflict.info("streamIn method :: End");
		b_Conflict.info("handleStreamInCompletedAction finished");
		return arrayOfByte2;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public byte[] e(int paramInt1, int paramInt2) throws a, InterruptedException
	  public virtual sbyte[] e(int paramInt1, int paramInt2)
	  {
		b_Conflict.info("streamInActualDMux method :: Start");
		b();
		cyDriver_setDataTimeoutMilliSec(paramInt2 + 5000);
		int i = cyDriver_asyncDataInTransfer(paramInt1, 512, 512);
		if (i != b_Conflict.a.a())
		{
		  b_Conflict b1 = b_Conflict.a(i);
		  b_Conflict.error("calling cyDriver_asyncDataInTransfer() has failed with error code " + b1);
		  throw new a("calling cyDriver_asyncDataInTransfer() has failed with error code " + b1, b1);
		}
		p();
		b_Conflict.info("Finish submit in transfers");
		while (cyDriver_isAsyncDataInDone() == 0)
		{
		  b_Conflict.info("wait for transfers to finish");
		}
		b_Conflict.info("streaming finished");
		b();
		sbyte[] arrayOfByte1 = new sbyte[paramInt1];
		i = cyDriver_asyncDataInGetData(arrayOfByte1);
		if (i != b_Conflict.a.a())
		{
		  b_Conflict b1 = b_Conflict.a(i);
		  b_Conflict.error("calling cyDriver_asyncDataInGetData() has failed with error code " + b1);
		  throw new a("calling cyDriver_asyncDataInGetData() has failed with error code " + b1, b1);
		}
		a(c_Conflict.v.a(), 0L, e_Conflict.v.a(), d_Conflict.v.a());
		sbyte[] arrayOfByte2 = a(arrayOfByte1);
		b_Conflict.info("streamIn method :: End");
		b_Conflict.info("handleStreamInCompletedAction finished");
		return arrayOfByte2;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void e() throws a
	  private void e()
	  {
		string str = this.a_Conflict;
		int i = 0;
		try
		{
		  StreamReader bufferedReader = new StreamReader(str + Path.DirectorySeparatorChar + "Data" + Path.DirectorySeparatorChar + "LargeBinary.dat");
		  i = int.Parse(bufferedReader.ReadLine());
		  bufferedReader.Close();
		}
		catch (IOException iOException)
		{
		  b_Conflict.error(iOException.Message);
		}
		if (i == 1)
		{
		  b_Conflict.info("Loading large binary file from directory: " + str);
		  this.c_Conflict = str + Path.DirectorySeparatorChar + "TAIF_Binary" + Path.DirectorySeparatorChar + "carma_top_large.bin";
		  this.d_Conflict = 464196;
		}
		else
		{
		  b_Conflict.info("Loading small binary file from directory: " + str);
		  this.c_Conflict = str + Path.DirectorySeparatorChar + "TAIF_Binary" + Path.DirectorySeparatorChar + "carma_top.bin";
		  this.d_Conflict = 169216;
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void f() throws a
	  private void f()
	  {
		sbyte b1 = g();
		if (b1 != 3)
		{
		  b_Conflict.error("Firmware version mismatch, FW version read from cyDriver " + b1 + " doesn't match " + '\x0003');
		  throw new a("Firmware version mismatch", b_Conflict.ag);
		}
	  }

	  private sbyte g()
	  {
		sbyte b1 = 0;
		sbyte[] arrayOfByte1 = a(g.a);
		sbyte[] arrayOfByte2 = a(g.a);
		arrayOfByte1[1] = (sbyte)f_Conflict.f.a();
		int i = cyDriver_controlOutTransfer(arrayOfByte1.Length, arrayOfByte1.Length, 1, arrayOfByte1);
		if (i != b_Conflict.a.a())
		{
		  b_Conflict b3 = b_Conflict.a(i);
		  b_Conflict.error("calling cyDriver_controlOutTransfer() has failed with error code" + b3);
		  throw new a("calling cyDriver_controlOutTransfer() has failed with error code" + b3, b3);
		}
		i = cyDriver_controlInTransfer(arrayOfByte2.Length, arrayOfByte2.Length, 1, arrayOfByte2);
		if (i != b_Conflict.a.a())
		{
		  b_Conflict b3 = b_Conflict.a(i);
		  b_Conflict.error("calling cyDriver_controlInTransfer() has failed with error code " + b3);
		  throw new a("calling cyDriver_controlInTransfer() has failed with error code " + b3, b3);
		}
		for (sbyte b2 = 0; b2 < 12; b2++)
		{
		  if (arrayOfByte2[b2] != arrayOfByte1[b2])
		  {
			b_Conflict.error("readFWVersion() :: out packet and in packet headers don't match");
			throw new a("readFWVersion() :: out packet and in packet headers don't match", b_Conflict.ab);
		  }
		}
		b1 = arrayOfByte2[12];
		b_Conflict.info("FW Version returned from cyDriver library: " + b1);
		return b1;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private byte[] a(sws.TAIFDriver.a.g paramg) throws a
	  private sbyte[] a(g paramg)
	  {
		sbyte[] arrayOfByte = null;
		switch (null.a[paramg.ordinal()])
		{
		  case 1:
			arrayOfByte = new sbyte[64];
			arrayOfByte[0] = (sbyte)g.a.a();
			return arrayOfByte;
		  case 2:
			arrayOfByte = new sbyte[64];
			arrayOfByte[0] = (sbyte)g.b.a();
			return arrayOfByte;
		  case 3:
			arrayOfByte = new sbyte[512];
			arrayOfByte[0] = (sbyte)g.c.a();
			return arrayOfByte;
		}
		b_Conflict.error("unexpected packet type : " + paramg + ", failed to create packet");
		throw new a("unexpected packet type : " + paramg + ", failed to create packet", b_Conflict.ar);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void h() throws a
	  private void h()
	  {
		int i = (int)Math.Ceiling(this.d_Conflict / 500.0D);
		i();
		sbyte[] arrayOfByte1 = j();
		int j = (int)(Math.Ceiling(i / 3.0D) * 3.0D);
		sbyte[] arrayOfByte2 = a(g.a);
		sbyte[] arrayOfByte3 = a(g.a);
		sbyte[] arrayOfByte4 = a_Conflict.a(j);
		arrayOfByte2[1] = (sbyte)f_Conflict.a.a();
		arrayOfByte2[2] = arrayOfByte4[0];
		arrayOfByte2[3] = arrayOfByte4[1];
		int k = cyDriver_controlOutTransfer(arrayOfByte2.Length, arrayOfByte2.Length, 1, arrayOfByte2);
		if (k != b_Conflict.a.a())
		{
		  b_Conflict b5 = b_Conflict.a(k);
		  b_Conflict.error("calling cyDriver_controlOutTransfer() has failed with error code " + b5);
		  throw new a("calling cyDriver_controlOutTransfer() has failed with error code " + b5, b5);
		}
		k = cyDriver_controlInTransfer(arrayOfByte3.Length, arrayOfByte3.Length, 1, arrayOfByte3);
		if (k != b_Conflict.a.a())
		{
		  b_Conflict b5 = b_Conflict.a(k);
		  b_Conflict.error("calling cyDriver_controlInTransfer() has failed with error code " + b5);
		  throw new a("calling cyDriver_controlInTransfer() has failed with error code " + b5, b5);
		}
		int m;
		for (m = 0; m < 12; m++)
		{
		  if (arrayOfByte3[m] != arrayOfByte2[m])
		  {
			b_Conflict.error("programFpga() :: out packet and in packet headers don't match");
			throw new a("programFpga() :: out packet and in packet headers don't match", b_Conflict.ab);
		  }
		}
		m = j * 512;
		sbyte[] arrayOfByte5 = new sbyte[m];
		sbyte b1 = 0;
		sbyte b2 = 0;
		sbyte b3 = 0;
		for (sbyte b4 = 0; b4 < i; b4++)
		{
		  sbyte[] arrayOfByte = a_Conflict.a(b3);
		  arrayOfByte5[b2 + false] = (sbyte)g.c.a();
		  arrayOfByte5[b2 + true] = (sbyte)f_Conflict.o.a();
		  arrayOfByte5[b2 + 2] = arrayOfByte[0];
		  arrayOfByte5[b2 + 3] = arrayOfByte[1];
		  arrayOfByte5[b2 + 4] = arrayOfByte[2];
		  b2 += true;
		  for (sbyte b5 = 0; b5 < (sbyte)'Ǵ' && b1 < arrayOfByte1.Length; b5++)
		  {
			arrayOfByte5[b2++] = arrayOfByte1[b1++];
		  }
		  b3++;
		}
		arrayOfByte1 = null;
		k = cyDriver_dataOutTransfer(arrayOfByte5.Length, 512, 3, arrayOfByte5);
		if (k != b_Conflict.a.a())
		{
		  b_Conflict b5 = b_Conflict.a(k);
		  b_Conflict.error("calling cyDriver_dataOutTransfer() has failed with error code " + b5);
		  throw new a("calling cyDriver_dataOutTransfer() has failed with error code " + b5, b5);
		}
		k();
		m();
		l();
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void i() throws a
	  private void i()
	  {
		sbyte[] arrayOfByte1 = a(g.a);
		sbyte[] arrayOfByte2 = a(g.a);
		arrayOfByte1[1] = (sbyte)f_Conflict.i.a();
		int i = cyDriver_controlOutTransfer(arrayOfByte1.Length, arrayOfByte1.Length, 1, arrayOfByte1);
		if (i != b_Conflict.a.a())
		{
		  b_Conflict b2 = b_Conflict.a(i);
		  b_Conflict.error("calling cyDriver_controlOutTransfer() has failed with error code " + b2);
		  throw new a("calling cyDriver_controlOutTransfer() has failed with error code " + b2, b2);
		}
		i = cyDriver_controlInTransfer(arrayOfByte2.Length, arrayOfByte2.Length, 1, arrayOfByte2);
		if (i != b_Conflict.a.a())
		{
		  b_Conflict b2 = b_Conflict.a(i);
		  b_Conflict.error("calling cyDriver_controlInTransfer() has failed with error code " + b2);
		  throw new a("calling cyDriver_controlInTransfer() has failed with error code " + b2, b2);
		}
		for (sbyte b1 = 0; b1 < 12; b1++)
		{
		  if (arrayOfByte2[b1] != arrayOfByte1[b1])
		  {
			b_Conflict.error("resetMCUFifo() :: out packet and in packet headers don't match");
			throw new a("resetMCUFifo() :: out packet and in packet headers don't match", b_Conflict.ab);
		  }
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private byte[] j() throws a
	  private sbyte[] j()
	  {
		sbyte[] arrayOfByte;
		File file = new File(this.c_Conflict);
		if (file.exists())
		{
		  if (file.length() != this.d_Conflict)
		  {
			b_Conflict.error("Bad FPGA binary file. FPGA configuration failed.");
			throw new a("Bad FPGA binary file. FPGA configuration failed.", b_Conflict.af);
		  }
		  arrayOfByte = new sbyte[(int)file.length()];
		  try
		  {
			FileStream fileInputStream = new FileStream(file, FileMode.Open, FileAccess.Read);
			fileInputStream.Read(arrayOfByte, 0, arrayOfByte.Length);
			fileInputStream.Close();
		  }
		  catch (IOException iOException)
		  {
			b_Conflict.error("An exception has occurred while reading FPGA binary file " + this.c_Conflict, iOException);
			throw new a(iOException, b_Conflict.ac);
		  }
		}
		else
		{
		  b_Conflict.error("FPGA binary file " + this.c_Conflict + "doesn't exist");
		  throw new a("File doesn't exist in this location: " + this.c_Conflict, b_Conflict.ad);
		}
		return arrayOfByte;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void k() throws a
	  private void k()
	  {
		sbyte[] arrayOfByte = a(g.a);
		int i = cyDriver_controlInTransfer(arrayOfByte.Length, arrayOfByte.Length, 1, arrayOfByte);
		if (i != b_Conflict.a.a())
		{
		  b_Conflict b1 = b_Conflict.a(i);
		  b_Conflict.error("calling cyDriver_controlInTransfer() has failed with error code " + b1);
		  throw new a("calling cyDriver_controlInTransfer() has failed with error code " + b1, b1);
		}
		if (arrayOfByte[1] != (sbyte)f_Conflict.c.a())
		{
		  b_Conflict.error("inpacket[1] doesn't match " + f_Conflict.c);
		  throw new a("inpacket[1] doesn't match " + f_Conflict.c, b_Conflict.ab);
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void l() throws a
	  private void l()
	  {
		a(c_Conflict.q.a(), 5L, e_Conflict.q.a(), d_Conflict.q.a());
		a(c_Conflict.c.a(), 287L, e_Conflict.c.a(), d_Conflict.c.a());
		a(c_Conflict.Z.a(), 287L, e_Conflict.Z.a(), d_Conflict.Z.a());
		b(i.cy.a(), 0L, k.cy.a(), j.cy.a());
		a(c_Conflict.aa.a(), 0L, e_Conflict.aa.a(), d_Conflict.aa.a());
		a(c_Conflict.ab.a(), 50L, e_Conflict.ab.a(), d_Conflict.ab.a());
		a(c_Conflict.e.a(), 0L, e_Conflict.e.a(), d_Conflict.e.a());
		a(c_Conflict.f.a(), 50L, e_Conflict.f.a(), d_Conflict.f.a());
		a(c_Conflict.U.a(), 1L, e_Conflict.U.a(), d_Conflict.U.a());
		a(c_Conflict.T.a(), 1L, e_Conflict.T.a(), d_Conflict.T.a());
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void m() throws a
	  private void m()
	  {
		n();
		d();
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void n() throws a
	  private void n()
	  {
		sbyte[] arrayOfByte1 = a(g.a);
		sbyte[] arrayOfByte2 = a(g.a);
		arrayOfByte1[1] = (sbyte)f_Conflict.b.a();
		int i = cyDriver_controlOutTransfer(arrayOfByte1.Length, arrayOfByte1.Length, 1, arrayOfByte1);
		if (i != b_Conflict.a.a())
		{
		  b_Conflict b2 = b_Conflict.a(i);
		  b_Conflict.error("calling cyDriver_controlOutTransfer() has failed with error code " + b2);
		  throw new a("calling cyDriver_controlOutTransfer() has failed with error code " + b2, b2);
		}
		i = cyDriver_controlInTransfer(arrayOfByte2.Length, arrayOfByte2.Length, 1, arrayOfByte2);
		if (i != b_Conflict.a.a())
		{
		  b_Conflict b2 = b_Conflict.a(i);
		  b_Conflict.error("calling cyDriver_controlInTransfer() has failed with error code " + b2);
		  throw new a("calling cyDriver_controlInTransfer() has failed with error code " + b2, b2);
		}
		for (sbyte b1 = 0; b1 < 12; b1++)
		{
		  if (arrayOfByte2[b1] != arrayOfByte1[b1])
		  {
			b_Conflict.error("checkDone() :: out packet and in packet headers don't match");
			throw new a("checkDone() :: out packet and in packet headers don't match", b_Conflict.ab);
		  }
		}
		if (arrayOfByte2[12] != 1)
		{
		  b_Conflict.error("incoming packet error,inPacket[12] = " + arrayOfByte2[12] + " " + b_Conflict.ai);
		  throw new a("incoming packet error,inPacket[12]  = " + arrayOfByte2[12] + " " + b_Conflict.ai, b_Conflict.ai);
		}
	  }

	  private long a(long paramLong, int paramInt1, int paramInt2)
	  {
		b_Conflict.info("readMask method :: Start");
		long l1 = paramLong;
		long l2 = l1 >> paramInt2;
		long l3 = (1L << paramInt1) - 1L;
		l2 &= l3;
		l2 &= 0xFFFFFFFFL;
		b_Conflict.info("readMask method :: End");
		return l2;
	  }

	  private long a(long paramLong1, long paramLong2, int paramInt1, int paramInt2)
	  {
		b_Conflict.info("writeMask method :: Start");
		long l1 = paramLong1;
		long l2 = paramLong2;
		long l3 = (1L << (int)(paramInt1 + paramInt2)) - (1L << (int)paramInt2) ^ 0xFFFFFFFFFFFFFFFFL;
		l1 &= l3;
		l2 <<= paramInt2;
		l2 |= l1;
		l2 &= 0xFFFFFFFFL;
		b_Conflict.info("writeMask method :: End");
		return l2;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private int b(int paramInt) throws a
	  private int b(int paramInt)
	  {
		b_Conflict.info("getAbsAddressAndSetPage method :: Start");
		long l1 = (paramInt * 4);
		long l2 = l1 >> 7;
		long l3 = d(i.cy.a() * 4);
		long l4 = a(l3, l2, k.cy.a(), j.cy.a());
		b(i.cy.a() * 4, l4);
		long l5 = -129L;
		l1 &= l5;
		b_Conflict.info("getAbsAddressAndSetPage method :: End");
		return (int)l1;
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private long c(int paramInt) throws a
	  private long c(int paramInt)
	  {
		b_Conflict.info("readFPGARow method :: Start");
		sbyte[] arrayOfByte1 = a(g.b);
		sbyte[] arrayOfByte2 = a(g.b);
		arrayOfByte1[1] = (sbyte)f_Conflict.m.a();
		sbyte[] arrayOfByte3 = a_Conflict.a(paramInt);
		arrayOfByte1[2] = arrayOfByte3[0];
		arrayOfByte1[3] = arrayOfByte3[1];
		arrayOfByte1[4] = arrayOfByte3[2];
		arrayOfByte1[5] = arrayOfByte3[3];
		int i = cyDriver_dataOutTransfer(arrayOfByte1.Length, arrayOfByte1.Length, 1, arrayOfByte1);
		if (i != b_Conflict.a.a())
		{
		  b_Conflict b2 = b_Conflict.a(i);
		  b_Conflict.error("calling cyDriver_dataOutTransfer() has failed with error code " + b2);
		  throw new a("calling cyDriver_dataOutTransfer() has failed with error code " + b2, b2);
		}
		i = cyDriver_dataInTransfer(arrayOfByte2.Length, arrayOfByte2.Length, 1, arrayOfByte2);
		if (i != b_Conflict.a.a())
		{
		  b_Conflict b2 = b_Conflict.a(i);
		  b_Conflict.error("calling cyDriver_dataInTransfer() has failed with error code " + b2);
		  throw new a("calling cyDriver_dataInTransfer() has failed with error code " + b2, b2);
		}
		for (sbyte b1 = 0; b1 < 12; b1++)
		{
		  if (arrayOfByte2[b1] != arrayOfByte1[b1])
		  {
			b_Conflict.error("readFPGARow(regAddress) :: out packet and in packet headers don't match");
			throw new a("readFPGARow(regAddress) :: out packet and in packet headers don't match", b_Conflict.ab);
		  }
		}
		sbyte[] arrayOfByte4 = new sbyte[8];
		arrayOfByte4[0] = arrayOfByte2[12];
		arrayOfByte4[1] = arrayOfByte2[13];
		arrayOfByte4[2] = arrayOfByte2[14];
		arrayOfByte4[3] = arrayOfByte2[15];
		arrayOfByte4[4] = 0;
		arrayOfByte4[5] = 0;
		arrayOfByte4[6] = 0;
		arrayOfByte4[7] = 0;
		ByteBuffer byteBuffer = ByteBuffer.wrap(arrayOfByte4);
		byteBuffer.order(ByteOrder.nativeOrder());
		b_Conflict.info("readFPGARow method :: End");
		return byteBuffer.getLong(0);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void a(int paramInt, long paramLong) throws a
	  private void a(int paramInt, long paramLong)
	  {
		b_Conflict.info("writeFPGARow method :: Start");
		sbyte[] arrayOfByte1 = a(g.b);
		sbyte[] arrayOfByte2 = a(g.b);
		arrayOfByte1[1] = (sbyte)f_Conflict.l.a();
		sbyte[] arrayOfByte3 = a_Conflict.a(paramInt);
		arrayOfByte1[2] = arrayOfByte3[0];
		arrayOfByte1[3] = arrayOfByte3[1];
		arrayOfByte1[4] = arrayOfByte3[2];
		arrayOfByte1[5] = arrayOfByte3[3];
		sbyte[] arrayOfByte4 = a_Conflict.a(paramLong);
		arrayOfByte1[12] = arrayOfByte4[0];
		arrayOfByte1[13] = arrayOfByte4[1];
		arrayOfByte1[14] = arrayOfByte4[2];
		arrayOfByte1[15] = arrayOfByte4[3];
		int i = cyDriver_dataOutTransfer(arrayOfByte1.Length, arrayOfByte1.Length, 1, arrayOfByte1);
		if (i != b_Conflict.a.a())
		{
		  b_Conflict b2 = b_Conflict.a(i);
		  b_Conflict.error("calling cyDriver_dataOutTransfer() has failed with error code " + b2);
		  throw new a("calling cyDriver_dataOutTransfer() has failed with error code " + b2, b2);
		}
		i = cyDriver_dataInTransfer(arrayOfByte2.Length, arrayOfByte2.Length, 1, arrayOfByte2);
		if (i != b_Conflict.a.a())
		{
		  b_Conflict b2 = b_Conflict.a(i);
		  b_Conflict.error("calling cyDriver_dataInTransfer() has failed with error code " + b2);
		  throw new a("calling cyDriver_dataInTransfer() has failed with error code " + b2, b2);
		}
		for (sbyte b1 = 0; b1 < 12; b1++)
		{
		  if (arrayOfByte2[b1] != arrayOfByte1[b1])
		  {
			b_Conflict.error("writeFPGARow(regAddress,data) :: out packet and in packet headers don't match");
			throw new a("writeFPGARow(regAddress,data) :: out packet and in packet headers don't match", b_Conflict.ab);
		  }
		}
		b_Conflict.info("writeFPGARow method :: End");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private long d(int paramInt) throws a
	  private long d(int paramInt)
	  {
		b_Conflict.info("readASICRow method :: Start");
		long l1 = 127L;
		long l2 = 128L;
		long l3 = paramInt;
		l3 &= l1;
		long l4 = h.a.a() << 7;
		l4 &= l2;
		long l5 = l4 | l3;
		a(c_Conflict.G.a(), l5, e_Conflict.G.a(), d_Conflict.G.a());
		a(c_Conflict.L.a(), 0L, e_Conflict.L.a(), d_Conflict.L.a());
		a(c_Conflict.L.a(), 1L, e_Conflict.L.a(), d_Conflict.L.a());
		long l6 = 0L;
		sbyte b1 = 0;
		do
		{
		  l6 = a(c_Conflict.F.a(), e_Conflict.F.a(), d_Conflict.F.a());
		  b1++;
		} while (l6 == 0L && b1 < 10);
		sbyte[] arrayOfByte1 = new sbyte[8];
		long l7 = a(c_Conflict.M.a(), e_Conflict.M.a(), d_Conflict.M.a());
		long l8 = a(c_Conflict.N.a(), e_Conflict.N.a(), d_Conflict.N.a());
		long l9 = a(c_Conflict.O.a(), e_Conflict.O.a(), d_Conflict.O.a());
		sbyte[] arrayOfByte2 = a_Conflict.a(l7);
		sbyte[] arrayOfByte3 = a_Conflict.a(l8);
		sbyte[] arrayOfByte4 = a_Conflict.a(l9);
		arrayOfByte1[0] = arrayOfByte2[1];
		arrayOfByte1[1] = arrayOfByte3[0];
		arrayOfByte1[2] = arrayOfByte3[1];
		arrayOfByte1[3] = arrayOfByte4[0];
		arrayOfByte1[4] = 0;
		arrayOfByte1[5] = 0;
		arrayOfByte1[6] = 0;
		arrayOfByte1[7] = 0;
		ByteBuffer byteBuffer = ByteBuffer.wrap(arrayOfByte1);
		byteBuffer.order(ByteOrder.nativeOrder());
		b_Conflict.info("readASICRow method :: End");
		return byteBuffer.getLong(0);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void b(int paramInt, long paramLong) throws a
	  private void b(int paramInt, long paramLong)
	  {
		b_Conflict.info("writeASICRow method :: Start");
		long l1 = 0L;
		sbyte b1 = 0;
		do
		{
		  l1 = a(c_Conflict.F.a(), e_Conflict.F.a(), d_Conflict.F.a());
		  b1++;
		} while (l1 == 0L && b1 < 10);
		sbyte[] arrayOfByte = a_Conflict.a(paramLong);
		long l2 = 65280L;
		long l3 = 255L;
		long l4 = 127L;
		long l5 = paramInt;
		l5 &= l4;
		long l6 = arrayOfByte[0] << 8;
		l6 &= l2;
		long l7 = l6 | l5;
		a(c_Conflict.G.a(), l7, e_Conflict.G.a(), d_Conflict.G.a());
		l5 = arrayOfByte[1];
		l5 &= l3;
		l6 = arrayOfByte[2] << 8;
		l6 &= l2;
		long l8 = l6 | l5;
		a(c_Conflict.H.a(), l8, e_Conflict.H.a(), d_Conflict.H.a());
		l5 = arrayOfByte[3];
		l5 &= l3;
		long l9 = l5;
		a(c_Conflict.I.a(), l9, e_Conflict.I.a(), d_Conflict.I.a());
		a(c_Conflict.L.a(), 0L, e_Conflict.L.a(), d_Conflict.L.a());
		a(c_Conflict.L.a(), 1L, e_Conflict.L.a(), d_Conflict.L.a());
		b_Conflict.info("writeASICRow method :: End");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void o() throws a
	  private void o()
	  {
		b_Conflict.info("resetTAIFController method :: Start");
		a(c_Conflict.S.a(), 0L, e_Conflict.S.a(), d_Conflict.S.a());
		a(c_Conflict.S.a(), 1L, e_Conflict.S.a(), d_Conflict.S.a());
		b_Conflict.info("resetTAIFController method :: End");
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void p() throws a
	  private void p()
	  {
		sbyte[] arrayOfByte = a(g.b);
		arrayOfByte[1] = (sbyte)f_Conflict.j.a();
		int i = cyDriver_dataOutTransfer(arrayOfByte.Length, arrayOfByte.Length, 1, arrayOfByte);
		if (i != b_Conflict.a.a())
		{
		  b_Conflict b1 = b_Conflict.a(i);
		  b_Conflict.error("calling cyDriver_dataOutTransfer() has failed with error code " + b1);
		  throw new a("calling cyDriver_dataOutTransfer() has failed with error code " + b1, b1);
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private byte[] a(byte[] paramArrayOfByte) throws a
	  private sbyte[] a(sbyte[] paramArrayOfByte)
	  {
		int i = cyDriver_getAsyncDataInErrorCode();
		if (i == b_Conflict.a.a())
		{
		  b(paramArrayOfByte);
		  b_Conflict.info("Async data headers validations is finished");
		  return c(paramArrayOfByte);
		}
		b_Conflict b1 = b_Conflict.a(i);
		b_Conflict.error("calling cyDriver_getAsyncDataInErrorCode() has failed with error code " + b1);
		throw new a("calling cyDriver_getAsyncDataInErrorCode() has failed with error code " + b1, b1);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private void b(byte[] paramArrayOfByte) throws a
	  private void b(sbyte[] paramArrayOfByte)
	  {
		sbyte b1 = 1;
		b_Conflict.info("Data received from TAIF has length: " + paramArrayOfByte.Length);
		d();
		for (sbyte b2 = 0; b2 < paramArrayOfByte.Length; b2 += unchecked((sbyte)512))
		{
		  if (paramArrayOfByte[b2 + false] != (sbyte)g.c.a())
		  {
			b_Conflict.error("Error in validating async in packets header, ASYNC_IN_PACKET_TYPE_ERROR index: " + b2);
			a(paramArrayOfByte, "errorStreamingBytes.txt");
			throw new a("Error in validating async in packets header, ASYNC_IN_PACKET_TYPE_ERROR index: " + b2, b_Conflict.at);
		  }
		  if (paramArrayOfByte[b2 + 1] != (sbyte)f_Conflict.p.a())
		  {
			b_Conflict.error("Error in validating async in packets header, ASYNC_IN_PACKET_ID_ERROR index: " + b2);
			a(paramArrayOfByte, "errorStreamingBytes.txt");
			throw new a("Error in validating async in packets header, ASYNC_IN_PACKET_ID_ERROR index: " + b2, b_Conflict.au);
		  }
		  sbyte[] arrayOfByte = a_Conflict.a(b1);
		  if (paramArrayOfByte[b2 + 2] != arrayOfByte[0] || paramArrayOfByte[b2 + 3] != arrayOfByte[1] || paramArrayOfByte[b2 + 4] != arrayOfByte[2])
		  {
			b_Conflict.error("Error in validating async in packets header, ASYNC_IN_PACKET_INDEX_ERROR index: " + b2);
			a(paramArrayOfByte, "errorStreamingBytes.txt");
			throw new a("Error in validating async in packets header, ASYNC_IN_PACKET_INDEX_ERROR index: " + b2, b_Conflict.av);
		  }
		  if (paramArrayOfByte[b2 + 5] != 0)
		  {
			if ((paramArrayOfByte[b2 + 5] & (sbyte)a_Conflict.a.a()) != 0)
			{
			  b_Conflict.error("Error in validating async in packets header, ASYNC_IN_EP2_FULL index: " + b2);
			}
			if ((paramArrayOfByte[b2 + 5] & (sbyte)a_Conflict.b.a()) != 0)
			{
			  b_Conflict.error("Error in validating async in packets header, ASYNC_IN_FPGA_FIFO_FULL index: " + b2);
			  a(paramArrayOfByte, "errorStreamingBytes.txt");
			  throw new a(b_Conflict.ax);
			}
		  }
		  b1++;
		}
		if (a_Conflict.h == true)
		{
		  long[] arrayOfLong = c();
		  a(arrayOfLong, "t_after_run.reg");
		}
	  }

	  private void a(sbyte[] paramArrayOfByte, string paramString)
	  {
		try
		{
		  StreamWriter bufferedWriter = new StreamWriter(this.a_Conflict + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + paramString);
		  for (b1 = 0; b1 < paramArrayOfByte.Length; b1++)
		  {
			bufferedWriter.Write(paramArrayOfByte[b1] + "\n");
		  }
		  bufferedWriter.Close();
		  try
		  {
				  using (FileStream null = new FileStream(this.a_Conflict + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + paramString + ".hex", true))
				  {
				fileOutputStream.write(paramArrayOfByte);
				fileOutputStream.close();
				  }
		  }
		  catch (IOException)
		  {
			IOException iOException;
			Console.WriteLine(iOException.ToString());
			Console.Write(iOException.StackTrace);
		  }
		}
		catch (IOException iOException)
		{
		  b_Conflict.error(iOException.Message);
		}
	  }

	  public virtual void a(long[] paramArrayOfLong, string paramString)
	  {
		try
		{
		  StreamWriter bufferedWriter = new StreamWriter(this.a_Conflict + Path.DirectorySeparatorChar + "logs" + Path.DirectorySeparatorChar + paramString);
		  for (sbyte b1 = 0; b1 < paramArrayOfLong.Length; b1++)
		  {
			bufferedWriter.BaseStream.WriteByte(paramArrayOfLong[b1].ToString("x") + "\n");
		  }
		  bufferedWriter.Close();
		}
		catch (IOException iOException)
		{
		  b_Conflict.error(iOException.Message);
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private byte[] c(byte[] paramArrayOfByte) throws a
	  private sbyte[] c(sbyte[] paramArrayOfByte)
	  {
		sbyte b2 = 0;
		sbyte[] arrayOfByte = new sbyte[paramArrayOfByte.Length];
		for (sbyte b1 = 12; b2 < arrayOfByte.Length && b1 < paramArrayOfByte.Length; b1 += 12)
		{
		  for (sbyte b3 = 0; b3 < (sbyte)'Ǵ' && b2 < arrayOfByte.Length; b3++)
		  {
			arrayOfByte[b2++] = paramArrayOfByte[b1++];
		  }
		}
		return arrayOfByte;
	  }

	  static TAIFBoard()
	  {
		try
		{
//JAVA TO C# CONVERTER TODO TASK: The library is specified in the 'DllImport' attribute for .NET:
//		  System.loadLibrary("cyDriver");
		}
		catch (Exception exception)
		{
		  b_Conflict.error("An exception is thrown while loading cyDriver library.", exception);
		}
	  }
	}


	/* Location:              D:\jobs\BalitTanah.SoilSensingKit\Decompile Driver\SDK v4.3\SDKv4.3\bin_win_x64\TAIFDriver.jar!\sws\TAIFDriver\TAIFBoard.class
	 * Java compiler version: 7 (51.0)
	 * JD-Core Version:       1.0.7
	 */
}