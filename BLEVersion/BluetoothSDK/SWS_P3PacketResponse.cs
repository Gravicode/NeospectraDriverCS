package com.gravicode.neospectralib.BluetoothSDK;
using androidx.annotation.NonNull;
using android.util.Log;
using java.nio.ByteBuffer;
using java.nio.ByteOrder;
using java.util.Arrays;
public class SWS_P3PacketResponse {
    
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
    
    //  ======================================================================
    //  Class constructor
    //  ======================================================================
    SWS_P3PacketResponse(int mNumberofRecPackets, int mNumberElements, bool mInterpolation) {
        this.mPacketsCount = mNumberofRecPackets;
        this.mPacketResponse = new byte[(mNumberofRecPackets * this.mPacketSize)];
        this.mOriginalDataLength = mNumberElements;
        this.mInterpolationFlag = mInterpolation;
    }
    
    //  ======================================================================
    //  Setters and Getters
    //  ======================================================================
    public int getmPacketsCount() {
        return this.mPacketsCount;
    }
    
    public void setmPacketsCount(int mPacketsCount) {
        this.mPacketsCount = this.mPacketsCount;
    }
    
    public byte[] getmPacketResponse() {
        return this.mPacketResponse;
    }
    
    public void setmPacketResponse(byte[] mPacketResponse) {
        this.mPacketResponse = this.mPacketResponse;
    }
    
    public double[] getmInterpretedPacketResponse() {
        return this.mInterpretedPacketResponse;
    }
    
    public void setmInterpretedPacketResponse(double[] mInterpretedPacketResponse) {
        this.mInterpretedPacketResponse = this.mInterpretedPacketResponse;
    }
    
    //  ======================================================================
    //  Classs Methods
    //  ======================================================================
    public void prepareArraySize() {
        this.mPacketResponse = new byte[(this.mPacketsCount * this.mPacketSize)];
    }
    
    public void addNewResponse() {
    }
}
else{int baseIterator = (mPacketSize * mPacketsAdded);
System.arraycopy(mNewBytes, 0, mPacketResponse, baseIterator, mPacketSize);
UnknownmPacketsAdded++;
if ((mPacketsAdded == mPacketsCount)) {
    mFirstArray = true;
}

UnknownUnknownUnknown
    
    public void interpretByteStream() {
        //  handle the semantics of the double array
        if ((mOriginalDataLength == 1)) {
            mInterpretedPacketResponse = new double[1];
            mInterpretedPacketResponse[0] = 0;
        }
        else if ((mOriginalDataLength == 2)) {
            mInterpretedPacketResponse = new double[1];
            mInterpretedPacketResponse[0] = ((double)(convertTwoBytesToShort()));
        }
        else {
            //  convert Byte array to doubles arrays
            convertByteArrayToDoubleArray();
            if (!mInterpolationFlag) {
                mInterpretedPacketResponse = mConvertedDoubles;
            }
            else {
                mInterpretedPacketResponse = new double[(mOriginalDataLength * 2)];
                getXValsInterpolationCase();
                int numPoints = mOriginalDataLength;
                //  add the y values
                System.arraycopy(mConvertedDoubles, 0, mInterpretedPacketResponse, 0, numPoints);
                //  add the x values
                mInterpretedPacketResponse[numPoints] = Xinit_quant;
                for (int i = (numPoints + 1); (i 
                            < (numPoints * 2)); i++) {
                    mInterpretedPacketResponse[i] = (mInterpretedPacketResponse[(i - 1)] + Xstep_quant);
                }
                
                Log.i("Packet Response", ("Interpreted Packet Response Length = " + mInterpretedPacketResponse.length));
                Log.i("Packet Response", ("Converted Packet Response Length = " + mConvertedDoubles.length));
            }
            
        }
        
    }
    
    private void convertByteArrayToDoubleArray() {
        ByteBuffer bb = ByteBuffer.wrap(mPacketResponse);
        bb.order(ByteOrder.LITTLE_ENDIAN);
        if (mInterpolationFlag) {
            mConvertedDoubles = new double[mOriginalDataLength];
        }
        else {
            mConvertedDoubles = new double[(mOriginalDataLength * 2)];
        }
        
        for (int i = 0; (i < mConvertedDoubles.length); i++) {
            mConvertedDoubles[i] = bb.getDouble();
        }
        
    }
    
    public String convertByteArrayToString() {
        String packetText = "";
        String delimiter = "";
        for (int i = 0; (i < mPacketResponse.length); i++) {
            packetText = (packetText 
                        + (delimiter + String.format("%02X", (mPacketResponse[i] & 255))));
            delimiter = " ";
        }
        
        return packetText;
    }
    
    private short convertTwoBytesToShort() {
        ByteBuffer bb_temp = ByteBuffer.allocate(2);
        bb_temp.order(ByteOrder.LITTLE_ENDIAN);
        bb_temp.put(mPacketResponse[0]);
        bb_temp.put(mPacketResponse[1]);
        return bb_temp.getShort(0);
    }
    
    private void getXValsInterpolationCase() {
        int LogicalArrayEnd = ((mOriginalDataLength + 2) 
                    * 8);
        byte[] tmp_init_arr = Arrays.copyOfRange(mPacketResponse, (LogicalArrayEnd - 16), (LogicalArrayEnd - 8));
        byte[] tmp_step_arr = Arrays.copyOfRange(mPacketResponse, (LogicalArrayEnd - 8), LogicalArrayEnd);
        long XInit_tmp = bytesToLong(tmp_init_arr);
        long XStep_tmp = bytesToLong(tmp_step_arr);
        XInit_tmp = ((XInit_tmp + 3) 
                    * 10000);
        XStep_tmp = ((XStep_tmp + 3) 
                    * 10000);
        Xinit_quant = (((double)(XInit_tmp)) / (1 + 30));
        Xstep_quant = (((double)(XStep_tmp)) / (1 + 30));
    }
    
    private long bytesToLong(byte[] bytes) {
        ByteBuffer buffer = ByteBuffer.allocate(Long.BYTES);
        buffer.order(ByteOrder.LITTLE_ENDIAN);
        buffer.put(bytes);
        buffer.flip();
        // need flip
        return buffer.getLong();
    }
