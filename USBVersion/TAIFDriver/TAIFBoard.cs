using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using log4net.Repository.Hierarchy;
using sws.TAIFDriver.ClassA;

namespace sws.TAIFDriver
{
    //using a =  sws.TAIFDriver.ClassA.aa;
    //using b =  sws.TAIFDriver.ClassA.ab;
    //using c =  sws.TAIFDriver.ClassA.ac;
    //using d =  sws.TAIFDriver.ClassA.ad;
    //using e =  sws.TAIFDriver.ClassA.ae;
    //using f =  sws.TAIFDriver.ClassA.af;
    //using ag = sws.TAIFDriver.ClassA.ag;
    //using h =  sws.TAIFDriver.ClassA.ah;
    //using i =  sws.TAIFDriver.ClassA.ai;
    //using j =  sws.TAIFDriver.ClassA.aj;
    //using k =  sws.TAIFDriver.ClassA.ak;
    //using a =sws.TAIFDriver.ClassB.ba;
    //using a =sws.TAIFDriver.ClassC.ca;

    public class TAIFBoard
    {
        static sws.TAIFDriver.ClassA.aa objAA;
        static sws.TAIFDriver.ClassA.ab objAB;
        static sws.TAIFDriver.ClassA.ac objAC;
        static sws.TAIFDriver.ClassA.ad objAD;
        static sws.TAIFDriver.ClassA.ae objAE;
        static sws.TAIFDriver.ClassA.af objAF;
        static sws.TAIFDriver.ClassA.ag objAG;
        static sws.TAIFDriver.ClassA.ah objAH;
        static sws.TAIFDriver.ClassA.ai objAI;
        static sws.TAIFDriver.ClassA.aj objAJ;
        static sws.TAIFDriver.ClassA.ak objAK;
        static sws.TAIFDriver.ClassB.ba objBA;
        static sws.TAIFDriver.ClassC.ca objCA;

        private static readonly log4net.ILog b_Conflict = log4net.LogManager.GetLogger(typeof(TAIFBoard));

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
        [DllImport("cyDriver.dll")]
        private static extern int cyDriver_init();

        //JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
        [DllImport("cyDriver.dll")]
        private static extern int cyDriver_connect(short paramShort, sbyte[] paramArrayOfByte);

        //JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
        [DllImport("cyDriver.dll")]
        private static extern int cyDriver_close();

        //JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
        [DllImport("cyDriver.dll")]
        private static extern int cyDriver_dataOutTransfer(int paramInt1, int paramInt2, int paramInt3, sbyte[] paramArrayOfByte);

        //JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
        [DllImport("cyDriver.dll")]
        private static extern int cyDriver_asyncDataOutTransfer(int paramInt1, int paramInt2, int paramInt3, sbyte[] paramArrayOfByte);

        //JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
        [DllImport("cyDriver.dll")]
        private static extern int cyDriver_dataInTransfer(int paramInt1, int paramInt2, int paramInt3, sbyte[] paramArrayOfByte);

        //JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
        [DllImport("cyDriver.dll")]
        private static extern int cyDriver_asyncDataInTransfer(int paramInt1, int paramInt2, int paramInt3);

        //JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
        [DllImport("cyDriver.dll")]
        private static extern int cyDriver_asyncDataInGetData(sbyte[] paramArrayOfByte);

        //JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
        [DllImport("cyDriver.dll")]
        private static extern int cyDriver_controlOutTransfer(int paramInt1, int paramInt2, int paramInt3, sbyte[] paramArrayOfByte);

        //JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
        [DllImport("cyDriver.dll")]
        private static extern int cyDriver_controlInTransfer(int paramInt1, int paramInt2, int paramInt3, sbyte[] paramArrayOfByte);

        //JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
        [DllImport("cyDriver.dll")]
        private static extern int cyDriver_selfTest();

        //JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
        [DllImport("cyDriver.dll")]
        private static extern double cyDriver_getDataInProgress();

        //JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
        [DllImport("cyDriver.dll")]
        private static extern double cyDriver_getDataOutProgress();

        //JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
        [DllImport("cyDriver.dll")]
        private static extern double cyDriver_getControlInProgress();

        //JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
        [DllImport("cyDriver.dll")]
        private static extern double cyDriver_getControlOutProgress();

        //JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
        [DllImport("cyDriver.dll")]
        private static extern byte cyDriver_isAsyncDataInDone();

        //JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
        [DllImport("cyDriver.dll")]
        private static extern byte cyDriver_isAsyncDataOutDone();

        //JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
        [DllImport("cyDriver.dll")]
        private static extern int cyDriver_getAsyncDataInErrorCode();

        //JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
        [DllImport("cyDriver.dll")]
        private static extern int cyDriver_getAsyncDataOutErrorCode();

        //JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
        [DllImport("cyDriver.dll")]
        private static extern int cyDriver_resetDevice();

        //JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
        [DllImport("cyDriver.dll")]
        private static extern int cyDriver_checkDeviceStatus(short paramShort);

        //JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
        [DllImport("cyDriver.dll")]
        private static extern void cyDriver_setDataTimeoutMilliSec(int paramInt);

        //JAVA TO C# CONVERTER TODO TASK: Replace 'unknown' with the appropriate dll name:
        [DllImport("cyDriver.dll")]
        private static extern void cyDriver_setControlTimeoutMilliSec(short paramShort);

        public TAIFBoard(int paramInt)
        {
            this.e_Conflict = paramInt;
            this.a_Conflict = FileHelpers.GetAbsolutePath("/");//System.getProperty("user.dir");
            cyDriver_init();
        }

        public TAIFBoard(int paramInt, string paramString)
        {
            //sws.TAIFDriver.ClassA
  
            this.e_Conflict = paramInt;
            this.a_Conflict = paramString;
            cyDriver_init();
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: public void a(boolean... paramVarArgs) throws a
        public virtual void a(params bool[] paramVarArgs)
        {
            b_Conflict.Info("initiateBoard method :: Start");
            long l = 0L;
            try
            {
                if (paramVarArgs == null)
                {
                    l = a(ac.i.getValue(), ae.i.getValue(), ad.i.getValue());
                }
                else if (paramVarArgs[0] == true)
                {
                    l = 0L;
                }
                else
                {
                    l = a(ac.i.getValue(), ae.i.getValue(), ad.i.getValue());
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
                sbyte[] arrayOfByte = new sbyte[this.a_Conflict.GetBytes(Encoding.ASCII).Length + 1];
                Array.Copy(this.a_Conflict.GetBytes(Encoding.ASCII), 0, arrayOfByte, 0, this.a_Conflict.GetBytes(Encoding.ASCII).Length);
                arrayOfByte[arrayOfByte.Length - 1] = 0;
                int i = cyDriver_connect((short)this.e_Conflict, arrayOfByte);
                if (i != ab.a.getValue())
                {
                    ab b1 = ab.aa(i);
                    b_Conflict.Error("calling cyDriver_connect has failed with error code returned" + b1);
                    throw new Exception("calling cyDriver_connect has failed with error code returned" + b1);
                }
                int j = cyDriver_selfTest();
                if (j == ab.a.getValue())
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
                    ab b1 = ab.aa(j);
                    b_Conflict.Error("calling cyDriver_selfTest() has failed with error code " + b1);
                    throw new Exception("calling cyDriver_selfTest() has failed with error code " + b1);
                }
            }
            b_Conflict.Info("initiateBoard method :: END");
        }

        public virtual int a()
        {
            int i = cyDriver_checkDeviceStatus((short)this.e_Conflict);
            b_Conflict.Info(Convert.ToInt32(i));
            b_Conflict.Info(Convert.ToBoolean(this.f_Conflict));
            if (i == ab.a.getValue() && !this.f_Conflict)
            {
                b_Conflict.Error("check board status succeeded from cyDriver side, but the initialization from TAIFBoardDriver side has failed ");
                i = ab.aa_.getValue();//b.aa.a();
            }
            if (i != ab.a.getValue() && i != ab.aa_.getValue() && i != ab.g.getValue())
            {
                ab b1 = ab.aa(i);
                b_Conflict.Error("Calling cyDriver_checkDeviceStatus() method has returned unexpected error code " + b1);
                throw new Exception("Calling cyDriver_checkDeviceStatus() method has returned unexpected error code " + b1);
            }
            if (i == ab.aa_.getValue() || i == ab.g.getValue())
            {
                this.f_Conflict = false;
            }
            return i;
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: public byte a(int paramInt) throws a, InterruptedException
        public virtual sbyte a(int paramInt)
        {
            b_Conflict.Info("TAIFBoard - readEEPROM(int address) :: Start :: address = " + paramInt);
            int i = ab.a.getValue();
            sbyte[] arrayOfByte1 = a(ag.a);
            sbyte[] arrayOfByte2 = a(ag.a);
            arrayOfByte1[1] = (sbyte)af.e.getValue();
            arrayOfByte1[2] = a_Conflict.a(paramInt)[0];
            arrayOfByte1[3] = a_Conflict.a(paramInt)[1];
            if (arrayOfByte1[3] == 0 && (arrayOfByte1[2] == 0 || arrayOfByte1[2] == 1 || arrayOfByte1[2] == 2 || arrayOfByte1[2] == 3 || arrayOfByte1[2] == 4 || arrayOfByte1[2] == 5 || arrayOfByte1[2] == 6 || arrayOfByte1[2] == 7))
            {
                b_Conflict.Error("TAIFBoard - readEEPROM(int address):: Error : illegalMemoryWritingAddress");
                throw new Exception("TAIFBoard - readEEPROM(int address):: Error : illegalMemoryWritingAddress");
            }
            i = cyDriver_controlOutTransfer(64, 64, 1, arrayOfByte1);
            if (i != ab.a.getValue())
            {
                ab b3 = ab.aa(i);
                b_Conflict.Error("TAIFBoard - readEEPROM(int address):: Error : " + b3);
                throw new Exception("TAIFBoard - readEEPROM(int address):: Error : " + b3);
            }
            Thread.Sleep(5);
            i = cyDriver_controlInTransfer(64, 64, 1, arrayOfByte2);
            if (i != ab.a.getValue())
            {
                ab b3 = ab.aa(i);
                b_Conflict.Error("TAIFBoard - readEEPROM(int address):: Error : " + b3);
                throw new Exception("TAIFBoard - readEEPROM(int address):: Error : " + b3);
            }
            for (sbyte b2 = 0; b2 < 12; b2++)
            {
                if (arrayOfByte2[b2] != arrayOfByte1[b2])
                {
                    b_Conflict.Error("TAIFBoard - readEEPROM(int address):: Error: out packet and in packet headers don't match");
                    throw new Exception ("TAIFBoard - readEEPROM(int address):: Error: out packet and in packet headers don't match");
                }
            }
            sbyte b1 = arrayOfByte2[12];
            b_Conflict.Info("TAIFBoard - readEEPROM(int address) :: END :: value = " + b1);
            return b1;
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: public byte[] a(int paramInt1, int paramInt2) throws a, InterruptedException
        public virtual sbyte[] a(int paramInt1, int paramInt2)
        {
            int k;
            int j;
            sbyte b1;
            b_Conflict.Info("TAIFBoard - readEEPROM(int address, int size) :: START :: address= " + paramInt1 + ", size=" + paramInt2);
            int i = ab.a.getValue();
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
            b_Conflict.Info("TAIFBoard - readEEPROM(int address, int size) :: dataSizePerPacket= " + b1 + ", noPackets=" + k + ", dataSizePerLastPacket= " + j);
            int m = paramInt1;
            for (sbyte b2 = 0; b2 < k; b2++)
            {
                int n;
                b_Conflict.Info("TAIFBoard - readEEPROM(int address, int size) :: packet " + b2);
                sbyte[] arrayOfByte1 = a(g.a);
                sbyte[] arrayOfByte2 = a(g.a);
                arrayOfByte1[1] = (sbyte)af.e.getValue();
                arrayOfByte1[2] = a_Conflict.a(m)[0];
                arrayOfByte1[3] = a_Conflict.a(m)[1];
                if (arrayOfByte1[3] == 0 && (arrayOfByte1[2] == 0 || arrayOfByte1[2] == 1 || arrayOfByte1[2] == 2 || arrayOfByte1[2] == 3 || arrayOfByte1[2] == 4 || arrayOfByte1[2] == 5 || arrayOfByte1[2] == 6 || arrayOfByte1[2] == 7))
                {
                    b_Conflict.Error("TAIFBoard - readEEPROM(int address, int size) :: Illegal Memory Writing Address");
                    throw new Exception ("TAIFBoard - readEEPROM(int address, int size) :: Illegal Memory Writing Address");
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
                if (i != ab.a.getValue())
                {
                    ab b4 = ab.aa(i);
                    b_Conflict.Error("TAIFBoard - readEEPROM(int address, int size) :: " + b4);
                    throw new Exception ("TAIFBoard - readEEPROM(int address, int size) :: " + b4);
                }
                Thread.Sleep(5);
                i = cyDriver_controlInTransfer(64, 64, 1, arrayOfByte2);
                if (i != ab.a.getValue())
                {
                    ab b4 = ab.aa(i);
                    b_Conflict.Error("TAIFBoard - readEEPROM(int address, int size) :: " + b4);
                    throw new Exception("TAIFBoard - readEEPROM(int address, int size) :: " + b4);
                }
                sbyte b3;
                for (b3 = 0; b3 < 12; b3++)
                {
                    if (arrayOfByte2[b3] != arrayOfByte1[b3])
                    {
                        b_Conflict.Error("TAIFBoard - readEEPROM(int address, int size) :: OUT and IN packets have Difffenet headers");
                        throw new Exception("TAIFBoard - readEEPROM(int address, int size) :: OUT and IN packets have Difffenet headers", b_Conflict.ab);
                    }
                }
                for (b3 = 0; b3 < n; b3++)
                {
                    arrayOfByte[b2 * b1 + b3] = arrayOfByte2[12 + b3];
                }
            }
            b_Conflict.Info("TAIFBoard - readEEPROM(int address, int size) :: END : value = " + StringHelper.NewString(arrayOfByte, "US-ASCII"));//forName("US-ASCII")
            return arrayOfByte;
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: public void a(int paramInt, byte paramByte) throws a, InterruptedException
        public virtual void a(int paramInt, sbyte paramByte)
        {
            b_Conflict.Info("TAIFBoard - writeEEPROM(int address, byte value) :: START : address = " + paramInt + ", value = " + paramByte);
            int i = ab.a.getValue();
            sbyte[] arrayOfByte1 = a(g.a);
            sbyte[] arrayOfByte2 = a(g.a);
            arrayOfByte1[1] = (sbyte)af.d.getValue();
            sbyte[] arrayOfByte3 = a_Conflict.a(paramInt);
            arrayOfByte1[2] = arrayOfByte3[0];
            arrayOfByte1[3] = arrayOfByte3[1];
            arrayOfByte1[12] = paramByte;
            if (arrayOfByte1[3] == 0 && (arrayOfByte1[2] == 0 || arrayOfByte1[2] == 1 || arrayOfByte1[2] == 2 || arrayOfByte1[2] == 3 || arrayOfByte1[2] == 4 || arrayOfByte1[2] == 5 || arrayOfByte1[2] == 6 || arrayOfByte1[2] == 7))
            {
                b_Conflict.Error("TAIFBoard - writeEEPROM(int address, byte value) :: " + ab.ae);
                throw new Exception("TAIFBoard - writeEEPROM(int address, byte value) :: " + ab.ae);
            }
            i = cyDriver_controlOutTransfer(64, 64, 1, arrayOfByte1);
            if (i != ab.a.getValue())
            {
                ab b2 = ab.aa(i);
                b_Conflict.Error("TAIFBoard - writeEEPROM(int address, byte value) :: " + b2);
                throw new Exception("TAIFBoard - writeEEPROM(int address, byte value) :: " + b2);
            }
            Thread.Sleep(5);
            i = cyDriver_controlInTransfer(64, 64, 1, arrayOfByte2);
            if (i != ab.a.getValue())
            {
                ab b2 = ab.aa(i);
                b_Conflict.Error("TAIFBoard - writeEEPROM(int address, byte value) :: " + b2);
                throw new Exception("TAIFBoard - writeEEPROM(int address, byte value) :: " + b2);
            }
            for (sbyte b1 = 0; b1 < 12; b1++)
            {
                if (arrayOfByte2[b1] != arrayOfByte1[b1])
                {
                    b_Conflict.Error("TAIFBoard - writeEEPROM(int address, byte value) :: OUT and IN packets have different headers");
                    throw new Exception("TAIFBoard - writeEEPROM(int address, byte value) :: OUT and IN packets have different headers");
                }
            }
            b_Conflict.Info("TAIFBoard - writeEEPROM(int address, byte value :: END");
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: public void a(int paramInt1, int paramInt2, byte[] paramArrayOfByte) throws a, InterruptedException
        public virtual void a(int paramInt1, int paramInt2, sbyte[] paramArrayOfByte)
        {
            int k;
            int j;
            sbyte b1;
            b_Conflict.Info("TAIFBoard - writeEEPROM(int pAddress, int size, byte[] value) :: START : address = " + paramInt1 + ", size = " + paramInt2 + ", value = " + StringHelper.NewString(paramArrayOfByte, Charset.forName("US-ASCII")));
            int i = ab.a.getValue();
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
                arrayOfByte1[1] = (sbyte)af.d.getValue();
                arrayOfByte3[1] = (sbyte)af.e.getValue();
                sbyte[] arrayOfByte5 = a_Conflict.a(m);
                arrayOfByte1[2] = arrayOfByte5[0];
                arrayOfByte1[3] = arrayOfByte5[1];
                arrayOfByte3[2] = arrayOfByte5[0];
                arrayOfByte3[3] = arrayOfByte5[1];
                if (arrayOfByte1[3] == 0 && (arrayOfByte1[2] == 0 || arrayOfByte1[2] == 1 || arrayOfByte1[2] == 2 || arrayOfByte1[2] == 3 || arrayOfByte1[2] == 4 || arrayOfByte1[2] == 5 || arrayOfByte1[2] == 6 || arrayOfByte1[2] == 7))
                {
                    b_Conflict.Error("TAIFBoard - WriteEEPROM(int pAddress, int size, byte[] value) :: " + ab.ae);
                    throw new Exception("TAIFBoard - WriteEEPROM(int pAddress, int size, byte[] value) :: " + ab.ae);
                }
                if (arrayOfByte1[3] == 0 && (arrayOfByte1[2] == 0 || arrayOfByte1[2] == 1 || arrayOfByte1[2] == 2 || arrayOfByte1[2] == 3 || arrayOfByte1[2] == 4 || arrayOfByte1[2] == 5 || arrayOfByte1[2] == 6 || arrayOfByte1[2] == 7))
                {
                    b_Conflict.Error("TAIFBoard - WriteEEPROM(int pAddress, int size, byte[] value) :: " + ab.ae);
                    throw new Exception("TAIFBoard - WriteEEPROM(int pAddress, int size, byte[] value) :: " + ab.ae);
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
                    b_Conflict.Error("TAIFBoard - WriteEEPROM(int pAddress, int size, byte[] value) :: " + ab.ae);
                    throw new Exception("TAIFBoard - WriteEEPROM(int pAddress, int size, byte[] value) :: " + ab.ae);
                }
                arrayOfByte1[4] = a_Conflict.a(n)[0];
                arrayOfByte3[4] = a_Conflict.a(n)[0];
                sbyte b3;
                for (b3 = 0; b3 < n; b3++)
                {
                    arrayOfByte1[12 + b3] = paramArrayOfByte[b2 * b1 + b3];
                }
                i = cyDriver_controlOutTransfer(64, 64, 1, arrayOfByte1);
                if (i != ab.a.getValue())
                {
                    ab b4 = ab.aa(i);
                    b_Conflict.Error("TAIFBoard - WriteEEPROM(int pAddress, int size, byte[] value) :: " + b4);
                    throw new Exception("TAIFBoard - WriteEEPROM(int pAddress, int size, byte[] value) :: " + b4);
                }
                Thread.Sleep(5);
                i = cyDriver_controlInTransfer(64, 64, 1, arrayOfByte2);
                if (i != ab.a.getValue())
                {
                    ab b4 = ab.aa(i);
                    b_Conflict.Error("TAIFBoard - WriteEEPROM(int pAddress, int size, byte[] value) :: " + b4);
                    throw new Exception("TAIFBoard - WriteEEPROM(int pAddress, int size, byte[] value) :: " + b4);
                }
                for (b3 = 0; b3 < 12; b3++)
                {
                    if (arrayOfByte2[b3] != arrayOfByte1[b3])
                    {
                        b_Conflict.Error("TAIFBoard - WriteEEPROM(int pAddress, int size, byte[] value) :: " + ab.ab_);
                        throw new Exception("TAIFBoard - WriteEEPROM(int pAddress, int size, byte[] value) :: " + ab.ab_);
                    }
                }
                Thread.Sleep(5);
                cyDriver_controlOutTransfer(64, 64, 1, arrayOfByte3);
                if (i != ab.a.getValue())
                {
                    ab b4 = ab.aa(i);
                    b_Conflict.Error("TAIFBoard - WriteEEPROM(int pAddress, int size, byte[] value) :: " + b4);
                    throw new Exception("TAIFBoard - WriteEEPROM(int pAddress, int size, byte[] value) :: " + b4);
                }
                Thread.Sleep(5);
                cyDriver_controlInTransfer(64, 64, 1, arrayOfByte4);
                if (i != ab.a.getValue())
                {
                    ab b4 = ab.aa(i);
                    b_Conflict.Error("TAIFBoard - WriteEEPROM(int pAddress, int size, byte[] value) :: " + b4);
                    throw new Exception("TAIFBoard - WriteEEPROM(int pAddress, int size, byte[] value) :: " + b4);
                }
                for (b3 = 0; b3 < 12; b3++)
                {
                    if (arrayOfByte4[b3] != arrayOfByte3[b3])
                    {
                        b_Conflict.Error("TAIFBoard - WriteEEPROM(int pAddress, int size, byte[] value) :: " + ab.ab_);
                        throw new Exception("TAIFBoard - WriteEEPROM(int pAddress, int size, byte[] value) :: " + ab.ab_);
                    }
                }
                for (b3 = 0; b3 < n; b3++)
                {
                    if (arrayOfByte4[12 + b3] != paramArrayOfByte[b2 * b1 + b3])
                    {
                        b_Conflict.Error("TAIFBoard - WriteEEPROM(int pAddress, int size, byte[] value) :: " + ab.am);
                        throw new Exception("TAIFBoard - WriteEEPROM(int pAddress, int size, byte[] value) :: " + ab.am);
                    }
                }
                m += n;
            }
            b_Conflict.Info("TAIFBoard - writeEEPROM(int pAddress, int size, byte[] value) :: END");
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: public void b() throws a
        public virtual void b()
        {
            sbyte[] arrayOfByte1 = a(g.b);
            sbyte[] arrayOfByte2 = a(g.b);
            arrayOfByte1[1] = (sbyte)af.k.getValue();
            int i = cyDriver_dataOutTransfer(arrayOfByte1.Length, arrayOfByte1.Length, 1, arrayOfByte1);
            if (i != ab.a.getValue())
            {
                ab b1 = ab.aa(i);
                b_Conflict.Error("calling cyDriver_dataOutTransfer() has failed with error code " + b1);
                throw new Exception("calling cyDriver_dataOutTransfer() has failed with error code " + b1);
            }
            i = cyDriver_dataInTransfer(arrayOfByte2.Length, arrayOfByte2.Length, 1, arrayOfByte2);
            if (i != ab.a.getValue())
            {
                ab b1 = ab.aa(i);
                b_Conflict.Error("calling cyDriver_dataInTransfer() has failed with error code " + b1);
                throw new Exception("calling cyDriver_dataInTransfer() has failed with error code " + b1);
            }
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: public long a(int paramInt1, int paramInt2, int paramInt3) throws a
        public virtual long a(int paramInt1, int paramInt2, int paramInt3)
        {
            b_Conflict.Info("readFPGARegister method :: Start");
            long l1 = c(paramInt1);
            long l2 = a(l1, paramInt2, paramInt3);
            b_Conflict.Info("readFPGARegister method :: End");
            return l2;
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: public void a(int paramInt1, long paramLong, int paramInt2, int paramInt3) throws a
        public virtual void a(int paramInt1, long paramLong, int paramInt2, int paramInt3)
        {
            b_Conflict.Info("writeFPGARegister method :: Start");
            long l1 = c(paramInt1);
            long l2 = a(l1, paramLong, paramInt2, paramInt3);
            a(paramInt1, l2);
            b_Conflict.Info("writeFPGARegister method :: End");
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: public long b(int paramInt1, int paramInt2, int paramInt3) throws a
        public virtual long b(int paramInt1, int paramInt2, int paramInt3)
        {
            b_Conflict.Info("readASICRegister method :: Start");
            int i = b(paramInt1);
            long l1 = d(i);
            long l2 = a(l1, paramInt2, paramInt3);
            b_Conflict.Info("readASICRegister method :: END");
            return l2;
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: public void b(int paramInt1, long paramLong, int paramInt2, int paramInt3) throws a
        public virtual void b(int paramInt1, long paramLong, int paramInt2, int paramInt3)
        {
            b_Conflict.Info("writeASICRegister method :: Start");
            int i = b(paramInt1);
            long l1 = d(i);
            long l2 = a(l1, paramLong, paramInt2, paramInt3);
            b(i, l2);
            b_Conflict.Info("writeASICRegister method :: END");
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: public void a(long[] paramArrayOfLong) throws a
        public virtual void a(long[] paramArrayOfLong)
        {
            b_Conflict.Info("writeAllASICRegisters method :: Start");
            for (sbyte b1 = 0; b1 < 89; b1++)
            {
                int i = b(b1);
                b(i, paramArrayOfLong[b1]);
            }
            b_Conflict.Info("writeAllASICRegisters method :: END");
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: public long[] c() throws a
        public virtual long[] c()
        {
            b_Conflict.Info("readAllASICRegisters method :: Start");
            long[] arrayOfLong = new long[89];
            for (sbyte b1 = 0; b1 < 89; b1++)
            {
                int i = b(b1);
                arrayOfLong[b1] = d(i);
            }
            b_Conflict.Info("readAllASICRegisters method :: END");
            return arrayOfLong;
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: public void d() throws a
        public virtual void d()
        {
            b_Conflict.Info("resetFIFOs method :: Start");
            i();
            b();
            b_Conflict.Info("resetFIFOs method :: End");
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: public byte[] b(int paramInt1, int paramInt2) throws a, InterruptedException
        public virtual sbyte[] b(int paramInt1, int paramInt2)
        {
            b_Conflict.Info("streamIn method :: Start");
            b();
            cyDriver_setDataTimeoutMilliSec(paramInt2 + 5000);
            int i = cyDriver_asyncDataInTransfer(paramInt1, 512, 50);
            if (i != ab.a.getValue())
            {
                ab b1 = ab.aa(i);
                b_Conflict.Error("calling cyDriver_asyncDataInTransfer() has failed with error code " + b1);
                throw new Exception("calling cyDriver_asyncDataInTransfer() has failed with error code " + b1);
            }
            p();
            b_Conflict.Info("Finish submit in transfers");
            while (cyDriver_isAsyncDataInDone() == 0)
            {
                b_Conflict.Info("wait for transfers to finish");
            }
            b_Conflict.Info("streaming finished");
            b();
            sbyte[] arrayOfByte1 = new sbyte[paramInt1];
            i = cyDriver_asyncDataInGetData(arrayOfByte1);
            if (i != ab.a.getValue())
            {
                ab b1 = ab.aa(i);
                b_Conflict.Error("calling cyDriver_asyncDataInGetData() has failed with error code " + b1);
                throw new Exception("calling cyDriver_asyncDataInGetData() has failed with error code " + b1);
            }
            a(ac.V.getValue(), 0L, ae.V.getValue(), ad.V.getValue());
            sbyte[] arrayOfByte2 = a(arrayOfByte1);
            b_Conflict.Info("streamIn method :: End");
            b_Conflict.Info("handleStreamInCompletedAction finished");
            return arrayOfByte2;
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: public byte[] c(int paramInt1, int paramInt2) throws a, InterruptedException
        public virtual sbyte[] c(int paramInt1, int paramInt2)
        {
            b_Conflict.Info("streamIn method :: Start");
            cyDriver_setDataTimeoutMilliSec(paramInt2 + 5000);
            int i = cyDriver_asyncDataInTransfer(paramInt1, 512, 50);
            if (i != ab.a.getValue())
            {
                ab b1 = ab.aa(i);
                b_Conflict.Error("calling cyDriver_asyncDataInTransfer() has failed with error code " + b1);
                throw new Exception("calling cyDriver_asyncDataInTransfer() has failed with error code " + b1);
            }
            p();
            b_Conflict.Info("Finish submit in transfers");
            while (cyDriver_isAsyncDataInDone() == 0)
            {
                b_Conflict.Info("wait for transfers to finish");
            }
            b_Conflict.Info("streaming finished");
            sbyte[] arrayOfByte = new sbyte[paramInt1];
            i = cyDriver_asyncDataInGetData(arrayOfByte);
            if (i != ab.a.getValue())
            {
                ab b1 = ab.aa(i);
                b_Conflict.Error("calling cyDriver_asyncDataInGetData() has failed with error code " + b1);
                throw new Exception("calling cyDriver_asyncDataInGetData() has failed with error code " + b1);
            }
            return arrayOfByte;
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: public byte[] d(int paramInt1, int paramInt2) throws a, InterruptedException
        public virtual sbyte[] d(int paramInt1, int paramInt2)
        {
            b_Conflict.Info("streamIn method :: Start");
            b();
            cyDriver_setDataTimeoutMilliSec(paramInt2 + 5000);
            int i = cyDriver_asyncDataInTransfer(paramInt1, 512, 512);
            if (i != ab.a.getValue())
            {
                ab b1 = ab.aa(i);
                b_Conflict.Error("calling cyDriver_asyncDataInTransfer() has failed with error code " + b1);
                throw new Exception("calling cyDriver_asyncDataInTransfer() has failed with error code " + b1);
            }
            p();
            b_Conflict.Info("Finish submit in transfers");
            while (cyDriver_isAsyncDataInDone() == 0)
            {
                b_Conflict.Info("wait for transfers to finish");
            }
            b_Conflict.Info("streaming finished");
            b();
            sbyte[] arrayOfByte1 = new sbyte[paramInt1];
            i = cyDriver_asyncDataInGetData(arrayOfByte1);
            if (i != ab.a.getValue())
            {
                ab b1 = ab.aa(i);
                b_Conflict.Error("calling cyDriver_asyncDataInGetData() has failed with error code " + b1);
                throw new Exception("calling cyDriver_asyncDataInGetData() has failed with error code " + b1);
            }
            a(ac.w.getValue(), 0L, ae.w.getValue(), ad.w.getValue());
            sbyte[] arrayOfByte2 = a(arrayOfByte1);
            b_Conflict.Info("streamIn method :: End");
            b_Conflict.Info("handleStreamInCompletedAction finished");
            return arrayOfByte2;
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: public byte[] e(int paramInt1, int paramInt2) throws a, InterruptedException
        public virtual sbyte[] e(int paramInt1, int paramInt2)
        {
            b_Conflict.Info("streamInActualDMux method :: Start");
            b();
            cyDriver_setDataTimeoutMilliSec(paramInt2 + 5000);
            int i = cyDriver_asyncDataInTransfer(paramInt1, 512, 512);
            if (i != ab.a.getValue())
            {
                ab b1 = ab.aa(i);
                b_Conflict.Error("calling cyDriver_asyncDataInTransfer() has failed with error code " + b1);
                throw new Exception("calling cyDriver_asyncDataInTransfer() has failed with error code " + b1);
            }
            p();
            b_Conflict.Info("Finish submit in transfers");
            while (cyDriver_isAsyncDataInDone() == 0)
            {
                b_Conflict.Info("wait for transfers to finish");
            }
            b_Conflict.Info("streaming finished");
            b();
            sbyte[] arrayOfByte1 = new sbyte[paramInt1];
            i = cyDriver_asyncDataInGetData(arrayOfByte1);
            if (i != ab.a.getValue())
            {
                ab b1 = ab.aa(i);
                b_Conflict.Error("calling cyDriver_asyncDataInGetData() has failed with error code " + b1);
                throw new Exception("calling cyDriver_asyncDataInGetData() has failed with error code " + b1);
            }
            a(ac.v.getValue(), 0L, ae.v.getValue(), ad.v.getValue());
            sbyte[] arrayOfByte2 = a(arrayOfByte1);
            b_Conflict.Info("streamIn method :: End");
            b_Conflict.Info("handleStreamInCompletedAction finished");
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
                b_Conflict.Error(iOException.Message);
            }
            if (i == 1)
            {
                b_Conflict.Info("Loading large binary file from directory: " + str);
                this.c_Conflict = str + Path.DirectorySeparatorChar + "TAIF_Binary" + Path.DirectorySeparatorChar + "carma_top_large.bin";
                this.d_Conflict = 464196;
            }
            else
            {
                b_Conflict.Info("Loading small binary file from directory: " + str);
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
                b_Conflict.Error("Firmware version mismatch, FW version read from cyDriver " + b1 + " doesn't match " + '\x0003');
                throw new Exception("Firmware version mismatch");
            }
        }

        private sbyte g()
        {
            sbyte b1 = 0;
            sbyte[] arrayOfByte1 = a(g.a);
            sbyte[] arrayOfByte2 = a(g.a);
            arrayOfByte1[1] = (sbyte)af.f.getValue();
            int i = cyDriver_controlOutTransfer(arrayOfByte1.Length, arrayOfByte1.Length, 1, arrayOfByte1);
            if (i != ab.a.getValue())
            {
                ab b3 = ab.aa(i);
                b_Conflict.Error("calling cyDriver_controlOutTransfer() has failed with error code" + b3);
                throw new Exception("calling cyDriver_controlOutTransfer() has failed with error code" + b3);
            }
            i = cyDriver_controlInTransfer(arrayOfByte2.Length, arrayOfByte2.Length, 1, arrayOfByte2);
            if (i != ab.a.getValue())
            {
                ab b3 = ab.aa(i);
                b_Conflict.Error("calling cyDriver_controlInTransfer() has failed with error code " + b3);
                throw new Exception("calling cyDriver_controlInTransfer() has failed with error code " + b3);
            }
            for (sbyte b2 = 0; b2 < 12; b2++)
            {
                if (arrayOfByte2[b2] != arrayOfByte1[b2])
                {
                    b_Conflict.Error("readFWVersion() :: out packet and in packet headers don't match");
                    throw new Exception("readFWVersion() :: out packet and in packet headers don't match");
                }
            }
            b1 = arrayOfByte2[12];
            b_Conflict.Info("FW Version returned from cyDriver library: " + b1);
            return b1;
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: private byte[] a(sws.TAIFDriver.ClassA.g paramg) throws a
        private sbyte[] a(ag paramg)
        {
            sbyte[] arrayOfByte = null;
            switch (null.a[paramg.ordinal()])
            {
                case 1:
                    arrayOfByte = new sbyte[64];
                    arrayOfByte[0] = (sbyte)ag.a.getValue();
                    return arrayOfByte;
                case 2:
                    arrayOfByte = new sbyte[64];
                    arrayOfByte[0] = (sbyte)ag.b.getValue();
                    return arrayOfByte;
                case 3:
                    arrayOfByte = new sbyte[512];
                    arrayOfByte[0] = (sbyte)ag.c.getValue();
                    return arrayOfByte;
            }
            b_Conflict.Error("unexpected packet type : " + paramg + ", failed to create packet");
            throw new Exception("unexpected packet type : " + paramg + ", failed to create packet");
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: private void h() throws a
        private void h()
        {
            int n = (int)Math.Ceiling(this.d_Conflict / 500.0D);
            i();
            sbyte[] arrayOfByte1 = j();
            int xx = (int)(Math.Ceiling(n / 3.0D) * 3.0D);
            sbyte[] arrayOfByte2 = a(ag.a);
            sbyte[] arrayOfByte3 = a(ag.a);
            sbyte[] arrayOfByte4 = a_Conflict.a(xx);
            arrayOfByte2[1] = (sbyte)af.a.getValue();
            arrayOfByte2[2] = arrayOfByte4[0];
            arrayOfByte2[3] = arrayOfByte4[1];
            int k = cyDriver_controlOutTransfer(arrayOfByte2.Length, arrayOfByte2.Length, 1, arrayOfByte2);
            if (k != ab.a.getValue())
            {
                ab b5 = ab.aa(k);
                b_Conflict.Error("calling cyDriver_controlOutTransfer() has failed with error code " + b5);
                throw new Exception("calling cyDriver_controlOutTransfer() has failed with error code " + b5);
            }
            k = cyDriver_controlInTransfer(arrayOfByte3.Length, arrayOfByte3.Length, 1, arrayOfByte3);
            if (k != ab.a.getValue())
            {
                ab b5 = ab.aa(k);
                b_Conflict.Error("calling cyDriver_controlInTransfer() has failed with error code " + b5);
                throw new Exception("calling cyDriver_controlInTransfer() has failed with error code " + b5);
            }
            int m;
            for (m = 0; m < 12; m++)
            {
                if (arrayOfByte3[m] != arrayOfByte2[m])
                {
                    b_Conflict.Error("programFpga() :: out packet and in packet headers don't match");
                    throw new Exception("programFpga() :: out packet and in packet headers don't match");
                }
            }
            m = xx * 512;
            sbyte[] arrayOfByte5 = new sbyte[m];
            sbyte b1 = 0;
            sbyte b2 = 0;
            sbyte b3 = 0;
            for (sbyte b4 = 0; b4 < n; b4++)
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
            if (k != ab.a.getValue())
            {
                ab b5 = ab.aa(k);
                b_Conflict.Error("calling cyDriver_dataOutTransfer() has failed with error code " + b5);
                throw new Exception("calling cyDriver_dataOutTransfer() has failed with error code " + b5, b5);
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
            arrayOfByte1[1] = (sbyte)af.i.getValue();
            int i = cyDriver_controlOutTransfer(arrayOfByte1.Length, arrayOfByte1.Length, 1, arrayOfByte1);
            if (i != ab.a.getValue())
            {
                ab b2 = ab.aa(i);
                b_Conflict.Error("calling cyDriver_controlOutTransfer() has failed with error code " + b2);
                throw new Exception("calling cyDriver_controlOutTransfer() has failed with error code " + b2, b2);
            }
            i = cyDriver_controlInTransfer(arrayOfByte2.Length, arrayOfByte2.Length, 1, arrayOfByte2);
            if (i != ab.a.getValue())
            {
                ab b2 = ab.aa(i);
                b_Conflict.Error("calling cyDriver_controlInTransfer() has failed with error code " + b2);
                throw new Exception("calling cyDriver_controlInTransfer() has failed with error code " + b2, b2);
            }
            for (sbyte b1 = 0; b1 < 12; b1++)
            {
                if (arrayOfByte2[b1] != arrayOfByte1[b1])
                {
                    b_Conflict.Error("resetMCUFifo() :: out packet and in packet headers don't match");
                    throw new Exception("resetMCUFifo() :: out packet and in packet headers don't match");
                }
            }
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: private byte[] j() throws a
        private byte[] j()
        {
            byte[] arrayOfByte;
            FileInfo file = new FileInfo(c_Conflict);
            if (file.Exists)
            {
                if (file.Length != this.d_Conflict)
                {
                    b_Conflict.Error("Bad FPGA binary file. FPGA configuration failed.");
                    throw new Exception("Bad FPGA binary file. FPGA configuration failed.");
                }
                arrayOfByte = new byte[(int)file.Length];
                try
                {
                    FileStream fileInputStream = new FileStream(file.FullName, FileMode.Open, FileAccess.Read);
                    fileInputStream.Read(arrayOfByte, 0, arrayOfByte.Length);
                    fileInputStream.Close();
                }
                catch (IOException iOException)
                {
                    b_Conflict.Error("An exception has occurred while reading FPGA binary file " + this.c_Conflict, iOException);
                    throw new Exception(iOException.Message);
                }
            }
            else
            {
                b_Conflict.Error("FPGA binary file " + this.c_Conflict + "doesn't exist");
                throw new Exception("File doesn't exist in this location: " + this.c_Conflict);
            }
            return arrayOfByte;
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: private void k() throws a
        private void k()
        {
            sbyte[] arrayOfByte = a(g.a);
            int i = cyDriver_controlInTransfer(arrayOfByte.Length, arrayOfByte.Length, 1, arrayOfByte);
            if (i != ab.a.getValue())
            {
                ab b1 = ab.aa(i);
                b_Conflict.Error("calling cyDriver_controlInTransfer() has failed with error code " + b1);
                throw new Exception("calling cyDriver_controlInTransfer() has failed with error code " + b1, b1);
            }
            if (arrayOfByte[1] != (sbyte)f_Conflict.c.a())
            {
                b_Conflict.Error("inpacket[1] doesn't match " + af.c);
                throw new Exception("inpacket[1] doesn't match " + af.c);
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
            if (i != ab.a.getValue())
            {
                ab b2 = ab.aa(i);
                b_Conflict.Error("calling cyDriver_controlOutTransfer() has failed with error code " + b2);
                throw new Exception("calling cyDriver_controlOutTransfer() has failed with error code " + b2);
            }
            i = cyDriver_controlInTransfer(arrayOfByte2.Length, arrayOfByte2.Length, 1, arrayOfByte2);
            if (i != ab.a.getValue())
            {
                ab b2 = ab.aa(i);
                b_Conflict.Error("calling cyDriver_controlInTransfer() has failed with error code " + b2);
                throw new Exception("calling cyDriver_controlInTransfer() has failed with error code " + b2);
            }
            for (sbyte b1 = 0; b1 < 12; b1++)
            {
                if (arrayOfByte2[b1] != arrayOfByte1[b1])
                {
                    b_Conflict.Error("checkDone() :: out packet and in packet headers don't match");
                    throw new Exception("checkDone() :: out packet and in packet headers don't match");
                }
            }
            if (arrayOfByte2[12] != 1)
            {
                b_Conflict.Error("incoming packet error,inPacket[12] = " + arrayOfByte2[12] + " " + ab.ai);
                throw new Exception("incoming packet error,inPacket[12]  = " + arrayOfByte2[12] + " " + ab.ai);
            }
        }

        private long a(long paramLong, int paramInt1, int paramInt2)
        {
            b_Conflict.Info("readMask method :: Start");
            long l1 = paramLong;
            long l2 = l1 >> paramInt2;
            long l3 = (1L << paramInt1) - 1L;
            l2 &= l3;
            l2 &= 0xFFFFFFFFL;
            b_Conflict.Info("readMask method :: End");
            return l2;
        }

        private long a(long paramLong1, long paramLong2, int paramInt1, int paramInt2)
        {
            b_Conflict.Info("writeMask method :: Start");
            long l1 = paramLong1;
            long l2 = paramLong2;
            long l3 = (1L << (int)(paramInt1 + paramInt2)) - (1L << (int)paramInt2) ^ 0xFFFFFFFFFFFFFFFFL;
            l1 &= l3;
            l2 <<= paramInt2;
            l2 |= l1;
            l2 &= 0xFFFFFFFFL;
            b_Conflict.Info("writeMask method :: End");
            return l2;
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: private int b(int paramInt) throws a
        private int b(int paramInt)
        {
            b_Conflict.Info("getAbsAddressAndSetPage method :: Start");
            long l1 = (paramInt * 4);
            long l2 = l1 >> 7;
            long l3 = d(ai.cy.getValue() * 4);
            long l4 = a(l3, l2, ak.cy.getValue(), aj.cy.getValue());
            b(ai.cy.getValue() * 4, l4);
            long l5 = -129L;
            l1 &= l5;
            b_Conflict.Info("getAbsAddressAndSetPage method :: End");
            return (int)l1;
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: private long c(int paramInt) throws a
        private long c(int paramInt)
        {
            b_Conflict.Info("readFPGARow method :: Start");
            sbyte[] arrayOfByte1 = a(g.b);
            sbyte[] arrayOfByte2 = a(g.b);
            arrayOfByte1[1] = (sbyte)af.m.getValue();
            sbyte[] arrayOfByte3 = a_Conflict.a(paramInt);
            arrayOfByte1[2] = arrayOfByte3[0];
            arrayOfByte1[3] = arrayOfByte3[1];
            arrayOfByte1[4] = arrayOfByte3[2];
            arrayOfByte1[5] = arrayOfByte3[3];
            int i = cyDriver_dataOutTransfer(arrayOfByte1.Length, arrayOfByte1.Length, 1, arrayOfByte1);
            if (i != ab.a.getValue())
            {
                ab b2 = ab.aa(i);
                b_Conflict.Error("calling cyDriver_dataOutTransfer() has failed with error code " + b2);
                throw new Exception("calling cyDriver_dataOutTransfer() has failed with error code " + b2);
            }
            i = cyDriver_dataInTransfer(arrayOfByte2.Length, arrayOfByte2.Length, 1, arrayOfByte2);
            if (i != ab.a.getValue())
            {
                ab b2 = ab.aa(i);
                b_Conflict.Error("calling cyDriver_dataInTransfer() has failed with error code " + b2);
                throw new Exception("calling cyDriver_dataInTransfer() has failed with error code " + b2);
            }
            for (sbyte b1 = 0; b1 < 12; b1++)
            {
                if (arrayOfByte2[b1] != arrayOfByte1[b1])
                {
                    b_Conflict.Error("readFPGARow(regAddress) :: out packet and in packet headers don't match");
                    throw new Exception("readFPGARow(regAddress) :: out packet and in packet headers don't match");
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
            b_Conflict.Info("readFPGARow method :: End");
            return byteBuffer.getLong(0);
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: private void a(int paramInt, long paramLong) throws a
        private void a(int paramInt, long paramLong)
        {
            b_Conflict.Info("writeFPGARow method :: Start");
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
            if (i != ab.a.getValue())
            {
                b_Conflict b2 = ab.aa(i);
                b_Conflict.Error("calling cyDriver_dataOutTransfer() has failed with error code " + b2);
                throw new Exception("calling cyDriver_dataOutTransfer() has failed with error code " + b2, b2);
            }
            i = cyDriver_dataInTransfer(arrayOfByte2.Length, arrayOfByte2.Length, 1, arrayOfByte2);
            if (i != ab.a.getValue())
            {
                b_Conflict b2 = ab.aa(i);
                b_Conflict.Error("calling cyDriver_dataInTransfer() has failed with error code " + b2);
                throw new Exception("calling cyDriver_dataInTransfer() has failed with error code " + b2, b2);
            }
            for (sbyte b1 = 0; b1 < 12; b1++)
            {
                if (arrayOfByte2[b1] != arrayOfByte1[b1])
                {
                    b_Conflict.Error("writeFPGARow(regAddress,data) :: out packet and in packet headers don't match");
                    throw new Exception("writeFPGARow(regAddress,data) :: out packet and in packet headers don't match", b_Conflict.ab);
                }
            }
            b_Conflict.Info("writeFPGARow method :: End");
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: private long d(int paramInt) throws a
        private long d(int paramInt)
        {
            b_Conflict.Info("readASICRow method :: Start");
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
            b_Conflict.Info("readASICRow method :: End");
            return byteBuffer.getLong(0);
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: private void b(int paramInt, long paramLong) throws a
        private void b(int paramInt, long paramLong)
        {
            b_Conflict.Info("writeASICRow method :: Start");
            long l1 = 0L;
            sbyte b1 = 0;
            do
            {
                l1 = a(ac.F.getValue(), ae.F.getValue(), ad.F.getValue());
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
            a(ac.G.getValue(), l7, ae.G.getValue(), ad.G.getValue());
            l5 = arrayOfByte[1];
            l5 &= l3;
            l6 = arrayOfByte[2] << 8;
            l6 &= l2;
            long l8 = l6 | l5;
            a(ac.H.getValue(), l8, ae.H.getValue(), ad.H.getValue());
            l5 = arrayOfByte[3];
            l5 &= l3;
            long l9 = l5;
            a(ac.I.getValue(), l9, ae.I.getValue(), ad.I.getValue());
            a(ac.L.getValue(), 0L, ae.L.getValue(), ad.L.getValue());
            a(ac.L.getValue(), 1L, ae.L.getValue(), ad.L.getValue());
            b_Conflict.Info("writeASICRow method :: End");
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: private void o() throws a
        private void o()
        {
            b_Conflict.Info("resetTAIFController method :: Start");
            a(ac.S.getValue(), 0L, ae.S.getValue(), ad.S.getValue());
            a(ac.S.getValue(), 1L, ae.S.getValue(), ad.S.getValue());
            b_Conflict.Info("resetTAIFController method :: End");
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: private void p() throws a
        private void p()
        {
            sbyte[] arrayOfByte = a(g.b);
            arrayOfByte[1] = (sbyte)f_Conflict.j.a();
            int i = cyDriver_dataOutTransfer(arrayOfByte.Length, arrayOfByte.Length, 1, arrayOfByte);
            if (i != ab.a.getValue())
            {
                ab b1 = ab.aa(i);
                b_Conflict.Error("calling cyDriver_dataOutTransfer() has failed with error code " + b1);
                throw new Exception("calling cyDriver_dataOutTransfer() has failed with error code " + b1);
            }
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: private byte[] a(byte[] paramArrayOfByte) throws a
        private sbyte[] a(sbyte[] paramArrayOfByte)
        {
            int i = cyDriver_getAsyncDataInErrorCode();
            if (i == ab.a.getValue())
            {
                b(paramArrayOfByte);
                b_Conflict.Info("Async data headers validations is finished");
                return c(paramArrayOfByte);
            }
            ab b1 = ab.aa(i);
            b_Conflict.Error("calling cyDriver_getAsyncDataInErrorCode() has failed with error code " + b1);
            throw new Exception("calling cyDriver_getAsyncDataInErrorCode() has failed with error code " + b1, b1);
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: private void b(byte[] paramArrayOfByte) throws a
        private void b(sbyte[] paramArrayOfByte)
        {
            sbyte b1 = 1;
            b_Conflict.Info("Data received from TAIF has length: " + paramArrayOfByte.Length);
            d();
            for (sbyte b2 = 0; b2 < paramArrayOfByte.Length; b2 += unchecked((sbyte)512))
            {
                if (paramArrayOfByte[b2 + false] != (sbyte)g.c.a())
                {
                    b_Conflict.Error("Error in validating async in packets header, ASYNC_IN_PACKET_TYPE_ERROR index: " + b2);
                    a(paramArrayOfByte, "errorStreamingBytes.txt");
                    throw new Exception("Error in validating async in packets header, ASYNC_IN_PACKET_TYPE_ERROR index: " + b2);
                }
                if (paramArrayOfByte[b2 + 1] != (sbyte)f_Conflict.p.a())
                {
                    b_Conflict.Error("Error in validating async in packets header, ASYNC_IN_PACKET_ID_ERROR index: " + b2);
                    a(paramArrayOfByte, "errorStreamingBytes.txt");
                    throw new Exception("Error in validating async in packets header, ASYNC_IN_PACKET_ID_ERROR index: " + b2);
                }
                sbyte[] arrayOfByte = a_Conflict.a(b1);
                if (paramArrayOfByte[b2 + 2] != arrayOfByte[0] || paramArrayOfByte[b2 + 3] != arrayOfByte[1] || paramArrayOfByte[b2 + 4] != arrayOfByte[2])
                {
                    b_Conflict.Error("Error in validating async in packets header, ASYNC_IN_PACKET_INDEX_ERROR index: " + b2);
                    a(paramArrayOfByte, "errorStreamingBytes.txt");
                    throw new Exception("Error in validating async in packets header, ASYNC_IN_PACKET_INDEX_ERROR index: " + b2);
                }
                if (paramArrayOfByte[b2 + 5] != 0)
                {
                    if ((paramArrayOfByte[b2 + 5] & (sbyte)aa.a.getValue()) != 0)
                    {
                        b_Conflict.Error("Error in validating async in packets header, ASYNC_IN_EP2_FULL index: " + b2);
                    }
                    if ((paramArrayOfByte[b2 + 5] & (sbyte)aa.b.getValue()) != 0)
                    {
                        b_Conflict.Error("Error in validating async in packets header, ASYNC_IN_FPGA_FIFO_FULL index: " + b2);
                        a(paramArrayOfByte, "errorStreamingBytes.txt");
                        throw new Exception(ab.ax.ToString());
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
                b_Conflict.Error(iOException.Message);
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
                b_Conflict.Error(iOException.Message);
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
                b_Conflict.Error("An exception is thrown while loading cyDriver library.", exception);
            }
        }
    }


    /* Location:              D:\jobs\BalitTanah.SoilSensingKit\Decompile Driver\SDK v4.3\SDKv4.3\bin_win_x64\TAIFDriver.jar!\sws\TAIFDriver\TAIFBoard.class
	 * Java compiler version: 7 (51.0)
	 * JD-Core Version:       1.0.7
	 */
}