package com.gravicode.neospectralib.BluetoothSDK;

import androidx.annotation.NonNull;
import android.util.Log;

import java.nio.ByteBuffer;
import java.nio.ByteOrder;
import java.util.Arrays;

/**
 *
 */

public class SWS_P3PacketResponse {

    private byte[] mPacketResponse;
    private double[] mInterpretedPacketResponse;
    private double[] mConvertedDoubles;
    private boolean mFirstArray = true;
    private int mPacketsCount = 0;
    private int mPacketsAdded = 0;
    private int mPacketSize = 20;
    private int mOriginalDataLength;
    private boolean mInterpolationFlag;


    private double Xstep_quant = 0;
    private double Xinit_quant = 0;


    // ======================================================================
    // Class constructor
    // ======================================================================
    SWS_P3PacketResponse(int mNumberofRecPackets, int mNumberElements, boolean mInterpolation) {
        mPacketsCount = mNumberofRecPackets;
        mPacketResponse = new byte[mNumberofRecPackets * mPacketSize];
        mOriginalDataLength = mNumberElements;
        mInterpolationFlag = mInterpolation;
    }


    // ======================================================================
    // Setters and Getters
    // ======================================================================
    public int getmPacketsCount() {
        return mPacketsCount;
    }

    public void setmPacketsCount(int mPacketsCount) {
        this.mPacketsCount = mPacketsCount;
    }


    public byte[] getmPacketResponse() {
        return mPacketResponse;
    }

    public void setmPacketResponse(byte[] mPacketResponse) {
        this.mPacketResponse = mPacketResponse;
    }

    public double[] getmInterpretedPacketResponse() {
        return mInterpretedPacketResponse;
    }

    public void setmInterpretedPacketResponse(double[] mInterpretedPacketResponse) {
        this.mInterpretedPacketResponse = mInterpretedPacketResponse;
    }

    // ======================================================================
    // Classs Methods
    // ======================================================================
    public void prepareArraySize() {
        mPacketResponse = new byte[mPacketsCount * mPacketSize];
    }

    public void addNewResponse(@NonNull byte[] mNewBytes) {
        if (mNewBytes.length == mPacketSize) {
            if (mFirstArray) {
                System.arraycopy(mNewBytes, 0, mPacketResponse, 0, mPacketSize);

                mFirstArray = false;
                mPacketsAdded = 0;
            } else {

                int baseIterator = mPacketSize * mPacketsAdded;

                System.arraycopy(mNewBytes, 0, mPacketResponse, baseIterator, mPacketSize);

            }

            mPacketsAdded++;

            if (mPacketsAdded == mPacketsCount) {
                mFirstArray = true;
            }
        }
    }

    public void interpretByteStream() {
        // handle the semantics of the double array
        if (mOriginalDataLength == 1) {
            mInterpretedPacketResponse = new double[1];
            mInterpretedPacketResponse[0] = 0.0;
        } else if (mOriginalDataLength == 2) {
            mInterpretedPacketResponse = new double[1];
            mInterpretedPacketResponse[0] = (double) convertTwoBytesToShort();
        } else {
            // convert Byte array to doubles arrays
            convertByteArrayToDoubleArray();

            if (!mInterpolationFlag) {
                mInterpretedPacketResponse = mConvertedDoubles;
            } else {
                mInterpretedPacketResponse = new double[mOriginalDataLength * 2];

                getXValsInterpolationCase();

                int numPoints = mOriginalDataLength;

                // add the y values
                System.arraycopy(mConvertedDoubles, 0, mInterpretedPacketResponse, 0, numPoints);

                // add the x values
                mInterpretedPacketResponse[numPoints] = Xinit_quant;
                for (int i = numPoints + 1; i < numPoints * 2; i++) {
                    mInterpretedPacketResponse[i] = mInterpretedPacketResponse[i - 1] + Xstep_quant;
                }


                Log.i("Packet Response", "Interpreted Packet Response Length = " + mInterpretedPacketResponse.length);
                Log.i("Packet Response", "Converted Packet Response Length = " + mConvertedDoubles.length);
            }
        }
    }

    private void convertByteArrayToDoubleArray() {
        ByteBuffer bb = ByteBuffer.wrap(mPacketResponse);
        bb.order(ByteOrder.LITTLE_ENDIAN);
        if (mInterpolationFlag) {
            mConvertedDoubles = new double[mOriginalDataLength];
        } else {
            mConvertedDoubles = new double[mOriginalDataLength * 2];
        }
        for (int i = 0; i < mConvertedDoubles.length; i++) {
            mConvertedDoubles[i] = bb.getDouble();
        }
    }

    public String convertByteArrayToString() {
        String packetText = "";
        String delimiter = "";
        for (int i = 0; i < mPacketResponse.length; ++i) {
            packetText += (delimiter + String.format("%02X", mPacketResponse[i] & 0xFF));
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
        int LogicalArrayEnd = (mOriginalDataLength + 2) * 8;

        byte[] tmp_init_arr = Arrays.copyOfRange(mPacketResponse, LogicalArrayEnd - 16, LogicalArrayEnd - 8);
        byte[] tmp_step_arr = Arrays.copyOfRange(mPacketResponse, LogicalArrayEnd - 8, LogicalArrayEnd);
        long XInit_tmp = bytesToLong(tmp_init_arr);
        long XStep_tmp = bytesToLong(tmp_step_arr);

        XInit_tmp = (XInit_tmp >> 3) * 10000;
        XStep_tmp = (XStep_tmp >> 3) * 10000;

        Xinit_quant = ((double) XInit_tmp) / (1 << 30);
        Xstep_quant = ((double) XStep_tmp) / (1 << 30);
    }

    private long bytesToLong(byte[] bytes) {
        ByteBuffer buffer = ByteBuffer.allocate(Long.BYTES);
        buffer.order(ByteOrder.LITTLE_ENDIAN);
        buffer.put(bytes);
        buffer.flip();//need flip
        return buffer.getLong();
    }
}
