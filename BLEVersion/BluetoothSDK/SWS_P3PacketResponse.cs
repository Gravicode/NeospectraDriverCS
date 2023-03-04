using System;
using System.Linq;
using System.Text;

namespace Com.Gravicode.Neospectralib.BluetoothSDK
{
    public class SWS_P3PacketResponse
    {
        private byte[] mPacketResponse;
        private double[] mInterpretedPacketResponse;
        private double[] mConvertedDoubles;
        private bool mFirstArray = true;
        private int mPacketsCount = 0;
        private int mPacketsAdded = 0;
        private int mPacketSize = 20;
        private int mOriginalDataLength;
        private bool mInterpolationFlag;

        private double Xstep_quant = 0;
        private double Xinit_quant = 0;

        // Class constructor
        public SWS_P3PacketResponse(int mNumberofRecPackets, int mNumberElements, bool mInterpolation)
        {
            mPacketsCount = mNumberofRecPackets;
            mPacketResponse = new byte[mNumberofRecPackets * mPacketSize];
            mOriginalDataLength = mNumberElements;
            mInterpolationFlag = mInterpolation;
        }

        // Setters and Getters
        public int GetPacketsCount()
        {
            return mPacketsCount;
        }

        public void SetPacketsCount(int mPacketsCount)
        {
            this.mPacketsCount = mPacketsCount;
        }

        public byte[] GetPacketResponse()
        {
            return mPacketResponse;
        }

        public void SetPacketResponse(byte[] mPacketResponse)
        {
            this.mPacketResponse = mPacketResponse;
        }

        public double[] GetInterpretedPacketResponse()
        {
            return mInterpretedPacketResponse;
        }

        public void SetInterpretedPacketResponse(double[] mInterpretedPacketResponse)
        {
            this.mInterpretedPacketResponse = mInterpretedPacketResponse;
        }

        // Class methods
        public void PrepareArraySize()
        {
            mPacketResponse = new byte[mPacketsCount * mPacketSize];
        }

        public void AddNewResponse(byte[] mNewBytes)
        {
            if (mNewBytes.Length == mPacketSize)
            {
                if (mFirstArray)
                {
                    Array.Copy(mNewBytes, 0, mPacketResponse, 0, mPacketSize);

                    mFirstArray = false;
                    mPacketsAdded = 0;
                }
                else
                {
                    int baseIterator = mPacketSize * mPacketsAdded;

                    Array.Copy(mNewBytes, 0, mPacketResponse, baseIterator, mPacketSize);
                }

                mPacketsAdded++;

                if (mPacketsAdded == mPacketsCount)
                {
                    mFirstArray = true;
                }
            }
        }

       public void InterpretByteStream()
{
    if (mOriginalDataLength == 1)
    {
        mInterpretedPacketResponse = new double[1];
        mInterpretedPacketResponse[0] = 0.0;
    }
    else if (mOriginalDataLength == 2)
    {
        mInterpretedPacketResponse = new double[1];
        mInterpretedPacketResponse[0] = (double)ConvertTwoBytesToShort();
    }
    else
    {
        ConvertByteArrayToDoubleArray();

        if (!mInterpolationFlag)
        {
            mInterpretedPacketResponse = mConvertedDoubles;
        }
        else
        {
            mInterpretedPacketResponse = new double[mOriginalDataLength * 2];

            GetXValsInterpolationCase();

            int numPoints = mOriginalDataLength;

            Array.Copy(mConvertedDoubles, 0, mInterpretedPacketResponse, 0, numPoints);

            mInterpretedPacketResponse[numPoints] = Xinit_quant;
            for (int i = numPoints + 1; i < numPoints * 2; i++)
            {
                mInterpretedPacketResponse[i] = mInterpretedPacketResponse[i - 1] + Xstep_quant;
            }

            Console.WriteLine("Interpreted Packet Response Length = " + mInterpretedPacketResponse.Length);
            Console.WriteLine("Converted Packet Response Length = " + mConvertedDoubles.Length);
        }
    }
}

private void ConvertByteArrayToDoubleArray()
{
    ByteBuffer bb = ByteBuffer.Wrap(mPacketResponse);
    bb.Order(ByteOrder.LittleEndian);
    if (mInterpolationFlag)
    {
        mConvertedDoubles = new double[mOriginalDataLength];
    }
    else
    {
        mConvertedDoubles = new double[mOriginalDataLength * 2];
    }
    for (int i = 0; i < mConvertedDoubles.Length; i++)
    {
        mConvertedDoubles[i] = bb.GetDouble();
    }
}

public string ConvertByteArrayToString()
{
    string packetText = "";
    string delimiter = "";
    for (int i = 0; i < mPacketResponse.Length; ++i)
    {
        packetText += (delimiter + String.Format("{0:X2}", mPacketResponse[i] & 0xFF));
        delimiter = " ";
    }
    return packetText;
}

private short ConvertTwoBytesToShort()
{
    ByteBuffer bb_temp = ByteBuffer.Allocate(2);
    bb_temp.Order(ByteOrder.LittleEndian);
    bb_temp.Put(mPacketResponse[0]);
    bb_temp.Put(mPacketResponse[1]);

    return bb_temp.GetShort(0);
}

private void GetXValsInterpolationCase()
{
    int LogicalArrayEnd = (mOriginalDataLength + 2) * 8;

    byte[] tmp_init_arr = Arrays.CopyOfRange(mPacketResponse, LogicalArrayEnd - 16, LogicalArrayEnd - 8);
    byte[] tmp_step_arr = Arrays.CopyOfRange(mPacketResponse, LogicalArrayEnd - 8, LogicalArrayEnd);
    long XInit_tmp = BytesToLong(tmp_init_arr);
    long XStep_tmp = BytesToLong(tmp_step_arr);

    XInit_tmp = (XInit_tmp >> 3) * 10000;
    XStep_tmp = (XStep_tmp >> 3) * 10000;

    Xinit_quant = ((double)XInit_tmp) / (1 << 30);
    Xstep_quant = ((double)XStep_tmp) / (1 << 30);
}
private long BytesToLong(byte[] bytes)
{
    ByteBuffer buffer = ByteBuffer.Allocate(Long.BYTES);
    buffer.Order(ByteOrder.LittleEndian);
    buffer.Put(bytes);
    buffer.Flip(); // need flip
    return buffer.GetLong();
}
    }
}