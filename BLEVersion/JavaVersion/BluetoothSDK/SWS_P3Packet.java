package com.gravicode.neospectralib.BluetoothSDK;

import androidx.annotation.NonNull;

import com.gravicode.neospectralib.Global.GlobalVariables;
import com.gravicode.neospectralib.Global.GlobalVariables.command;
import com.gravicode.neospectralib.Global.GlobalVariables.pointsCount;
import com.gravicode.neospectralib.Global.GlobalVariables.opticalGain;
import com.gravicode.neospectralib.Global.GlobalVariables.apodization;
import com.gravicode.neospectralib.Global.GlobalVariables.zeroPadding;
import com.gravicode.neospectralib.Global.GlobalVariables.runMode;

import java.text.DecimalFormat;
import java.util.HashMap;
import java.util.Map;

/**
 *
 */

public class SWS_P3Packet {

    // =============================================================================================
    // Class Members
    // =============================================================================================
    private int packetSize = 20;
    private String SWS_P3Packet_Command;
    private String SWS_P3Packet_ScanTime;
    private String SWS_P3Packet_PointsCount;
    private String SWS_P3Packet_OpticalGain;
    private String SWS_P3Packet_Apodization;
    private String SWS_P3Packet_ZeroPadding;
    private String SWS_P3Packet_RunMode;
    private byte[] packetStream;
    private Map<String, Byte> commandMap;
    private Map<String, Byte> pointsCountMap;
    private Map<String, Byte> opticalGainMap;
    private Map<String, Byte> apodizationMap;
    private Map<String, Byte> zeroPaddingMap;
    private Map<String, Byte> runModeMap;
    private boolean InterpolationMode = false;

    // =============================================================================================
    // Constructor
    // =============================================================================================
    public SWS_P3Packet()
    {
        // members initialization
        packetStream = new byte[packetSize];
        for (int i=0; i<packetSize; ++i) {
            packetStream[i] = 0;
        }

        commandMap          = new HashMap<String, Byte>();
        pointsCountMap      = new HashMap<String, Byte>();
        opticalGainMap      = new HashMap<String, Byte>();
        apodizationMap      = new HashMap<String, Byte>();
        zeroPaddingMap      = new HashMap<String, Byte>();
        runModeMap          = new HashMap<String, Byte>();

        // initialize maps values
        initPacketMaps();
    }

    public SWS_P3Packet(int packetSize)
    {
        packetStream = new byte[packetSize];
        for (int i=0; i<packetSize; ++i) {
            packetStream[i] = 0;
        }

    }



    void initPacketMaps()
    {
        // --> Commands Map
        commandMap.put(command.Read_RunModule_ID.toString(), (byte)1);
        commandMap.put(command.Run_PSD.toString(), (byte)3);
        commandMap.put(command.Run_Background.toString(), (byte)4);
        commandMap.put(command.Run_Absorbance.toString(), (byte)5);
        commandMap.put(command.Run_GainAdjustment.toString(), (byte)6);
        commandMap.put(command.Burn_Gain.toString(), (byte)7);
        commandMap.put(command.Burn_Self.toString(), (byte)8);
        commandMap.put(command.Burn_WLN.toString(), (byte)9);
        commandMap.put(command.Run_SelfCorrection.toString(), (byte)10);
        commandMap.put(command.Run_WavelengthCorrectionBackground.toString(), (byte)11);
        commandMap.put(command.Run_WavelengthCorrection.toString(), (byte)12);
        commandMap.put(command.Restore_Defaults.toString(), (byte)13);
        commandMap.put(command.Set_Optical_Settings.toString(), (byte)27);
        commandMap.put(command.Get_Calibration_Wells.toString(), (byte)90);
        commandMap.put(command.Get_Calibration_Wells1.toString(), (byte)91);

        // ------------------------------------------------------------------------------------
        // --> Points Count Map
        pointsCountMap.put(pointsCount.disable.toString(), (byte)0);
        pointsCountMap.put(pointsCount.points_65.toString(), (byte)1);
        pointsCountMap.put(pointsCount.points_129.toString(), (byte)2);
        pointsCountMap.put(pointsCount.points_257.toString(), (byte)3);
        pointsCountMap.put(pointsCount.points_513.toString(), (byte)4);
        pointsCountMap.put(pointsCount.points_1024.toString(), (byte)5);
        pointsCountMap.put(pointsCount.points_2048.toString(), (byte)6);
        pointsCountMap.put(pointsCount.points_4096.toString(), (byte)7);

        // ------------------------------------------------------------------------------------
        // --> Optical Gain Map
        opticalGainMap.put(opticalGain.UseSettingsSavedonDVK.toString(), (byte)0);
        opticalGainMap.put(opticalGain.UseCalculatedSettings.toString(), (byte)1);
        opticalGainMap.put(opticalGain.UseExternalSettings.toString(), (byte)2);

        // ------------------------------------------------------------------------------------
        // --> Apodization Map
        apodizationMap.put(apodization.Boxcar.toString(), (byte)0);
        apodizationMap.put(apodization.Gaussian.toString(), (byte)1);
        apodizationMap.put(apodization.HappGenzel.toString(), (byte)2);
        apodizationMap.put(apodization.Lorenz.toString(), (byte)3);

        // ------------------------------------------------------------------------------------
        // Zero Padding Map
        zeroPaddingMap.put(zeroPadding.points_8k.toString(), (byte)1);
        zeroPaddingMap.put(zeroPadding.points_16k.toString(), (byte)2);
        zeroPaddingMap.put(zeroPadding.points_32k.toString(), (byte)3);

        // ------------------------------------------------------------------------------------
        // --> Run Mode Map
        runModeMap.put(runMode.Single_Mode.toString(), (byte)0);
        runModeMap.put(runMode.Continuous_Mode.toString(), (byte)1);

    }

    // ==================================================================================
    // Parameters encoding and decoding for sending/receiving
    // ==================================================================================
    public void preparePacketContent()
    {
        // Convert requestSensorReading time to array of bytes
        byte[] scanTimeArr = IntToThreeBytes(Integer.parseInt(SWS_P3Packet_ScanTime));

        // Handle field by field and fill in the stream of bytes
        packetStream[0] = commandMap.get(SWS_P3Packet_Command);
        packetStream[1] = scanTimeArr[2];
        packetStream[2] = scanTimeArr[1];
        packetStream[3] = scanTimeArr[0];
        packetStream[4] = pointsCountMap.get(SWS_P3Packet_PointsCount);
        packetStream[5] = opticalGainMap.get(SWS_P3Packet_OpticalGain);
        packetStream[6] = apodizationMap.get(SWS_P3Packet_Apodization);
        packetStream[7] = zeroPaddingMap.get(SWS_P3Packet_ZeroPadding);
        packetStream[8] = runModeMap.get(SWS_P3Packet_RunMode);

        InterpolationMode = packetStream[4] != (byte) 0;
    }

    // ==================================================================================
    // Parameters encoding and decoding for sending/receiving the packet
    // ==================================================================================
    public void preparePacketContent(String command) {
        byte[] bytesToBeSent = hexStringToByteArray(command);

        for(int i = 0; i < bytesToBeSent.length; ++i) {
            packetStream[i] = bytesToBeSent[i];
        }
    }

    public static byte[] hexStringToByteArray(String s) {
        String[] bytes = s.split(" ");
        byte[] b = new byte[bytes.length];
        for (int i = 0; i < b.length; i++) {
            int v = Integer.parseInt(bytes[i], 16);
            b[i] = (byte) v;
        }
        return b;
    }

    @NonNull
    public String getPacketAsText()
    {
        String pattern = "##";
        DecimalFormat decimalFormat = new DecimalFormat(pattern);

        String packetText = "P:";

        for(int i=0 ; i<9 ; i++)
        {
            packetText += (" " + String.format("%02X", packetStream[i] & 0xFF));
        }

        return packetText;
    }

    @NonNull
    public static byte[] IntToThreeBytes(int i)
    {
        byte[] result = new byte[3];

        result[0] = (byte) (i >> 16);
        result[1] = (byte) (i >> 8);
        result[2] = (byte) (i);


        return result;
    }

    // =============================================================================================
    // Setters and Getters
    // =============================================================================================
    public String getSWS_P3Packet_Command() {
        return SWS_P3Packet_Command;
    }

    public void setSWS_P3Packet_Command(String SWS_P3Packet_Command) {
        this.SWS_P3Packet_Command = SWS_P3Packet_Command;
    }

    public String getSWS_P3Packet_ScanTime() {
        return SWS_P3Packet_ScanTime;
    }

    public void setSWS_P3Packet_ScanTime(String SWS_P3Packet_ScanTime) {
        this.SWS_P3Packet_ScanTime = SWS_P3Packet_ScanTime;
    }

    public String getSWS_P3Packet_PointsCount() {
        return SWS_P3Packet_PointsCount;
    }

    public void setSWS_P3Packet_PointsCount(String SWS_P3Packet_PointsCount) {
        this.SWS_P3Packet_PointsCount = SWS_P3Packet_PointsCount;
    }

    public String getSWS_P3Packet_OpticalGain() {
        return SWS_P3Packet_OpticalGain;
    }

    public void setSWS_P3Packet_OpticalGain(String SWS_P3Packet_OpticalGain) {
        this.SWS_P3Packet_OpticalGain = SWS_P3Packet_OpticalGain;
    }

    public String getSWS_P3Packet_Apodization() {
        return SWS_P3Packet_Apodization;
    }

    public void setSWS_P3Packet_Apodization(String SWS_P3Packet_Apodization) {
        this.SWS_P3Packet_Apodization = SWS_P3Packet_Apodization;
    }

    public String getSWS_P3Packet_ZeroPadding() {
        return SWS_P3Packet_ZeroPadding;
    }

    public void setSWS_P3Packet_ZeroPadding(String SWS_P3Packet_ZeroPadding) {
        this.SWS_P3Packet_ZeroPadding = SWS_P3Packet_ZeroPadding;
    }

    public String getSWS_P3Packet_RunMode() {
        return SWS_P3Packet_RunMode;
    }

    public void setSWS_P3Packet_RunMode(String SWS_P3Packet_RunMode) {
        this.SWS_P3Packet_RunMode = SWS_P3Packet_RunMode;
    }

    public byte[] getPacketStream() {
        return packetStream;
    }

    public void setPacketStream(byte[] packetStream) {
        System.arraycopy(packetStream, 0, this.packetStream, 0, packetStream.length);
    }

    public boolean isInterpolationMode() {
        return InterpolationMode;
    }

    public void setInterpolationMode(boolean interpolationMode) {
        InterpolationMode = interpolationMode;
    }


}
