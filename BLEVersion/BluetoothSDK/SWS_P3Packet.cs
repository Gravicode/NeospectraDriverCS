package com.gravicode.neospectralib.BluetoothSDK;
using androidx.annotation.NonNull;
using com.gravicode.neospectralib.Global.GlobalVariables;
using com.gravicode.neospectralib.Global.GlobalVariables.command;
using com.gravicode.neospectralib.Global.GlobalVariables.pointsCount;
using com.gravicode.neospectralib.Global.GlobalVariables.opticalGain;
using com.gravicode.neospectralib.Global.GlobalVariables.apodization;
using com.gravicode.neospectralib.Global.GlobalVariables.zeroPadding;
using com.gravicode.neospectralib.Global.GlobalVariables.runMode;
using java.text.DecimalFormat;
using java.util.HashMap;
using java.util.Map;
public class SWS_P3Packet {
    
    //  =============================================================================================
    //  Class Members
    //  =============================================================================================
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
    
    private bool InterpolationMode = false;
    
    //  =============================================================================================
    //  Constructor
    //  =============================================================================================
    public SWS_P3Packet() {
        //  members initialization
        this.packetStream = new byte[this.packetSize];
        for (int i = 0; (i < this.packetSize); i++) {
            this.packetStream[i] = 0;
        }
        
        this.commandMap = new HashMap<String, Byte>();
        this.pointsCountMap = new HashMap<String, Byte>();
        this.opticalGainMap = new HashMap<String, Byte>();
        this.apodizationMap = new HashMap<String, Byte>();
        this.zeroPaddingMap = new HashMap<String, Byte>();
        this.runModeMap = new HashMap<String, Byte>();
        //  initialize maps values
        this.initPacketMaps();
    }
    
    public SWS_P3Packet(int packetSize) {
        this.packetStream = new byte[this.packetSize];
        for (int i = 0; (i < this.packetSize); i++) {
            this.packetStream[i] = 0;
        }
        
    }
    
    void initPacketMaps() {
        //  --> Commands Map
        this.commandMap.put(command.Read_RunModule_ID.toString(), ((byte)(1)));
        this.commandMap.put(command.Run_PSD.toString(), ((byte)(3)));
        this.commandMap.put(command.Run_Background.toString(), ((byte)(4)));
        this.commandMap.put(command.Run_Absorbance.toString(), ((byte)(5)));
        this.commandMap.put(command.Run_GainAdjustment.toString(), ((byte)(6)));
        this.commandMap.put(command.Burn_Gain.toString(), ((byte)(7)));
        this.commandMap.put(command.Burn_Self.toString(), ((byte)(8)));
        this.commandMap.put(command.Burn_WLN.toString(), ((byte)(9)));
        this.commandMap.put(command.Run_SelfCorrection.toString(), ((byte)(10)));
        this.commandMap.put(command.Run_WavelengthCorrectionBackground.toString(), ((byte)(11)));
        this.commandMap.put(command.Run_WavelengthCorrection.toString(), ((byte)(12)));
        this.commandMap.put(command.Restore_Defaults.toString(), ((byte)(13)));
        this.commandMap.put(command.Set_Optical_Settings.toString(), ((byte)(27)));
        this.commandMap.put(command.Get_Calibration_Wells.toString(), ((byte)(90)));
        this.commandMap.put(command.Get_Calibration_Wells1.toString(), ((byte)(91)));
        //  ------------------------------------------------------------------------------------
        //  --> Points Count Map
        this.pointsCountMap.put(pointsCount.disable.toString(), ((byte)(0)));
        this.pointsCountMap.put(pointsCount.points_65.toString(), ((byte)(1)));
        this.pointsCountMap.put(pointsCount.points_129.toString(), ((byte)(2)));
        this.pointsCountMap.put(pointsCount.points_257.toString(), ((byte)(3)));
        this.pointsCountMap.put(pointsCount.points_513.toString(), ((byte)(4)));
        this.pointsCountMap.put(pointsCount.points_1024.toString(), ((byte)(5)));
        this.pointsCountMap.put(pointsCount.points_2048.toString(), ((byte)(6)));
        this.pointsCountMap.put(pointsCount.points_4096.toString(), ((byte)(7)));
        //  ------------------------------------------------------------------------------------
        //  --> Optical Gain Map
        this.opticalGainMap.put(opticalGain.UseSettingsSavedonDVK.toString(), ((byte)(0)));
        this.opticalGainMap.put(opticalGain.UseCalculatedSettings.toString(), ((byte)(1)));
        this.opticalGainMap.put(opticalGain.UseExternalSettings.toString(), ((byte)(2)));
        //  ------------------------------------------------------------------------------------
        //  --> Apodization Map
        this.apodizationMap.put(apodization.Boxcar.toString(), ((byte)(0)));
        this.apodizationMap.put(apodization.Gaussian.toString(), ((byte)(1)));
        this.apodizationMap.put(apodization.HappGenzel.toString(), ((byte)(2)));
        this.apodizationMap.put(apodization.Lorenz.toString(), ((byte)(3)));
        //  ------------------------------------------------------------------------------------
        //  Zero Padding Map
        this.zeroPaddingMap.put(zeroPadding.points_8k.toString(), ((byte)(1)));
        this.zeroPaddingMap.put(zeroPadding.points_16k.toString(), ((byte)(2)));
        this.zeroPaddingMap.put(zeroPadding.points_32k.toString(), ((byte)(3)));
        //  ------------------------------------------------------------------------------------
        //  --> Run Mode Map
        this.runModeMap.put(runMode.Single_Mode.toString(), ((byte)(0)));
        this.runModeMap.put(runMode.Continuous_Mode.toString(), ((byte)(1)));
    }
    
    //  ==================================================================================
    //  Parameters encoding and decoding for sending/receiving
    //  ==================================================================================
    public void preparePacketContent() {
        //  Convert requestSensorReading time to array of bytes
        byte[] scanTimeArr = SWS_P3Packet.IntToThreeBytes(Integer.parseInt(this.SWS_P3Packet_ScanTime));
        //  Handle field by field and fill in the stream of bytes
        this.packetStream[0] = this.commandMap.get(this.SWS_P3Packet_Command);
        this.packetStream[1] = scanTimeArr[2];
        this.packetStream[2] = scanTimeArr[1];
        this.packetStream[3] = scanTimeArr[0];
        this.packetStream[4] = this.pointsCountMap.get(this.SWS_P3Packet_PointsCount);
        this.packetStream[5] = this.opticalGainMap.get(this.SWS_P3Packet_OpticalGain);
        this.packetStream[6] = this.apodizationMap.get(this.SWS_P3Packet_Apodization);
        this.packetStream[7] = this.zeroPaddingMap.get(this.SWS_P3Packet_ZeroPadding);
        this.packetStream[8] = this.runModeMap.get(this.SWS_P3Packet_RunMode);
        this.InterpolationMode = (this.packetStream[4] != ((byte)(0)));
    }
    
    //  ==================================================================================
    //  Parameters encoding and decoding for sending/receiving the packet
    //  ==================================================================================
    public void preparePacketContent(String command) {
        byte[] bytesToBeSent = SWS_P3Packet.hexStringToByteArray(command);
        for (int i = 0; (i < bytesToBeSent.length); i++) {
            this.packetStream[i] = bytesToBeSent[i];
        }
        
    }
    
    public static byte[] hexStringToByteArray(String s) {
        String[] bytes = s.split(" ");
        byte[] b = new byte[bytes.length];
        for (int i = 0; (i < b.length); i++) {
            int v = Integer.parseInt(bytes[i], 16);
            b[i] = ((byte)(v));
        }
        
        return b;
    }
    
    [NonNull()]
    public String getPacketAsText() {
        String pattern = "##";
        DecimalFormat decimalFormat = new DecimalFormat(pattern);
        String packetText = "P:";
        for (int i = 0; (i < 9); i++) {
            packetText = (packetText + (" " + String.format("%02X", (this.packetStream[i] & 255))));
        }
        
        return packetText;
    }
    
    [NonNull()]
    public static byte[] IntToThreeBytes(int i) {
        byte[] result = new byte[3];
        result[0] = ((byte)((i + 16)));
        result[1] = ((byte)((i + 8)));
        return result;
    }
    
    //  =============================================================================================
    //  Setters and Getters
    //  =============================================================================================
    public String getSWS_P3Packet_Command() {
        return this.SWS_P3Packet_Command;
    }
    
    public void setSWS_P3Packet_Command(String SWS_P3Packet_Command) {
        this.SWS_P3Packet_Command = this.SWS_P3Packet_Command;
    }
    
    public String getSWS_P3Packet_ScanTime() {
        return this.SWS_P3Packet_ScanTime;
    }
    
    public void setSWS_P3Packet_ScanTime(String SWS_P3Packet_ScanTime) {
        this.SWS_P3Packet_ScanTime = this.SWS_P3Packet_ScanTime;
    }
    
    public String getSWS_P3Packet_PointsCount() {
        return this.SWS_P3Packet_PointsCount;
    }
    
    public void setSWS_P3Packet_PointsCount(String SWS_P3Packet_PointsCount) {
        this.SWS_P3Packet_PointsCount = this.SWS_P3Packet_PointsCount;
    }
    
    public String getSWS_P3Packet_OpticalGain() {
        return this.SWS_P3Packet_OpticalGain;
    }
    
    public void setSWS_P3Packet_OpticalGain(String SWS_P3Packet_OpticalGain) {
        this.SWS_P3Packet_OpticalGain = this.SWS_P3Packet_OpticalGain;
    }
    
    public String getSWS_P3Packet_Apodization() {
        return this.SWS_P3Packet_Apodization;
    }
    
    public void setSWS_P3Packet_Apodization(String SWS_P3Packet_Apodization) {
        this.SWS_P3Packet_Apodization = this.SWS_P3Packet_Apodization;
    }
    
    public String getSWS_P3Packet_ZeroPadding() {
        return this.SWS_P3Packet_ZeroPadding;
    }
    
    public void setSWS_P3Packet_ZeroPadding(String SWS_P3Packet_ZeroPadding) {
        this.SWS_P3Packet_ZeroPadding = this.SWS_P3Packet_ZeroPadding;
    }
    
    public String getSWS_P3Packet_RunMode() {
        return this.SWS_P3Packet_RunMode;
    }
    
    public void setSWS_P3Packet_RunMode(String SWS_P3Packet_RunMode) {
        this.SWS_P3Packet_RunMode = this.SWS_P3Packet_RunMode;
    }
    
    public byte[] getPacketStream() {
        return this.packetStream;
    }
    
    public void setPacketStream(byte[] packetStream) {
        System.arraycopy(this.packetStream, 0, this.packetStream, 0, this.packetStream.length);
    }
    
    public bool isInterpolationMode() {
        return this.InterpolationMode;
    }
    
    public void setInterpolationMode(bool interpolationMode) {
        this.InterpolationMode = interpolationMode;
    }
}
