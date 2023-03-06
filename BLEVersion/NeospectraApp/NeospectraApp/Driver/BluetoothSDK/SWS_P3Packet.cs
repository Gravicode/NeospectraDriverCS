using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NeospectraApp.Driver.GlobalVariables;

namespace NeospectraApp.Driver
{
    public class SWS_P3Packet
    {


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
        private Dictionary<String, Byte> commandMap;
        private Dictionary<String, Byte> pointsCountMap;
        private Dictionary<String, Byte> opticalGainMap;
        private Dictionary<String, Byte> apodizationMap;
        private Dictionary<String, Byte> zeroPaddingMap;
        private Dictionary<String, Byte> runModeMap;
        private bool InterpolationMode = false;

        // =============================================================================================
        // Constructor
        // =============================================================================================
        public SWS_P3Packet()
        {
            // members initialization
            packetStream = new byte[packetSize];
            for (int i = 0; i < packetSize; ++i)
            {
                packetStream[i] = 0;
            }

            commandMap = new Dictionary<String, Byte>();
            pointsCountMap = new Dictionary<String, Byte>();
            opticalGainMap = new Dictionary<String, Byte>();
            apodizationMap = new Dictionary<String, Byte>();
            zeroPaddingMap = new Dictionary<String, Byte>();
            runModeMap = new Dictionary<String, Byte>();

            // initialize maps values
            initPacketMaps();
        }

        public SWS_P3Packet(int packetSize)
        {
            packetStream = new byte[packetSize];
            for (int i = 0; i < packetSize; ++i)
            {
                packetStream[i] = 0;
            }

        }



        void initPacketMaps()
        {
            // --> Commands Map
            commandMap.Add(command.Read_RunModule_ID, (byte)1);
            commandMap.Add(command.Run_PSD, (byte)3);
            commandMap.Add(command.Run_Background, (byte)4);
            commandMap.Add(command.Run_Absorbance, (byte)5);
            commandMap.Add(command.Run_GainAdjustment, (byte)6);
            commandMap.Add(command.Burn_Gain, (byte)7);
            commandMap.Add(command.Burn_Self, (byte)8);
            commandMap.Add(command.Burn_WLN, (byte)9);
            commandMap.Add(command.Run_SelfCorrection, (byte)10);
            commandMap.Add(command.Run_WavelengthCorrectionBackground, (byte)11);
            commandMap.Add(command.Run_WavelengthCorrection, (byte)12);
            commandMap.Add(command.Restore_Defaults, (byte)13);
            commandMap.Add(command.Set_Optical_Settings, (byte)27);
            commandMap.Add(command.Get_Calibration_Wells, (byte)90);
            commandMap.Add(command.Get_Calibration_Wells1, (byte)91);

            // ------------------------------------------------------------------------------------
            // --> Points Count Map
            pointsCountMap.Add(pointsCount.disable, (byte)0);
            pointsCountMap.Add(pointsCount.points_65, (byte)1);
            pointsCountMap.Add(pointsCount.points_129, (byte)2);
            pointsCountMap.Add(pointsCount.points_257, (byte)3);
            pointsCountMap.Add(pointsCount.points_513, (byte)4);
            pointsCountMap.Add(pointsCount.points_1024, (byte)5);
            pointsCountMap.Add(pointsCount.points_2048, (byte)6);
            pointsCountMap.Add(pointsCount.points_4096, (byte)7);

            // ------------------------------------------------------------------------------------
            // --> Optical Gain Map
            opticalGainMap.Add(opticalGain.UseSettingsSavedonDVK, (byte)0);
            opticalGainMap.Add(opticalGain.UseCalculatedSettings, (byte)1);
            opticalGainMap.Add(opticalGain.UseExternalSettings, (byte)2);

            // ------------------------------------------------------------------------------------
            // --> Apodization Map
            apodizationMap.Add(apodization.Boxcar, (byte)0);
            apodizationMap.Add(apodization.Gaussian, (byte)1);
            apodizationMap.Add(apodization.HappGenzel, (byte)2);
            apodizationMap.Add(apodization.Lorenz, (byte)3);

            // ------------------------------------------------------------------------------------
            // Zero Padding Map
            zeroPaddingMap.Add(zeroPadding.points_8k, (byte)1);
            zeroPaddingMap.Add(zeroPadding.points_16k, (byte)2);
            zeroPaddingMap.Add(zeroPadding.points_32k, (byte)3);

            // ------------------------------------------------------------------------------------
            // --> Run Mode Map
            runModeMap.Add(runMode.Single_Mode, (byte)0);
            runModeMap.Add(runMode.Continuous_Mode, (byte)1);

        }

        // ==================================================================================
        // Parameters encoding and decoding for sending/receiving
        // ==================================================================================
        public void preparePacketContent()
        {
            // Convert requestSensorReading time to array of bytes
            byte[] scanTimeArr = IntToThreeBytes(int.Parse(SWS_P3Packet_ScanTime));

            // Handle field by field and fill in the stream of bytes
            packetStream[0] = commandMap[SWS_P3Packet_Command];
            packetStream[1] = scanTimeArr[2];
            packetStream[2] = scanTimeArr[1];
            packetStream[3] = scanTimeArr[0];
            packetStream[4] = pointsCountMap[SWS_P3Packet_PointsCount];
            packetStream[5] = opticalGainMap[SWS_P3Packet_OpticalGain];
            packetStream[6] = apodizationMap[SWS_P3Packet_Apodization];
            packetStream[7] = zeroPaddingMap[SWS_P3Packet_ZeroPadding];
            packetStream[8] = runModeMap[SWS_P3Packet_RunMode];

            InterpolationMode = packetStream[4] != (byte)0;
        }

        // ==================================================================================
        // Parameters encoding and decoding for sending/receiving the packet
        // ==================================================================================
        public void preparePacketContent(String command)
        {
            byte[] bytesToBeSent = hexStringToByteArray(command);

            for (int i = 0; i < bytesToBeSent.Length; ++i)
            {
                packetStream[i] = bytesToBeSent[i];
            }
        }

        public static byte[] hexStringToByteArray(String s)
        {
            String[] bytes = s.Split(" ");
            byte[] b = new byte[bytes.Length];
            for (int i = 0; i < b.Length; i++)
            {
                int v = int.Parse(bytes[i]);//, 16);
                b[i] = (byte)v;
            }
            return b;
        }


        public String getPacketAsText()
        {
            String pattern = "##";
            //DecimalFormat decimalFormat = new DecimalFormat(pattern);

            String packetText = "P:";

            for (int i = 0; i < 9; i++)
            {
                packetText += (" " + String.Format("%02X", packetStream[i] & 0xFF));
            }

            return packetText;
        }


        public static byte[] IntToThreeBytes(int i)
        {
            byte[] result = new byte[3];

            result[0] = (byte)(i >> 16);
            result[1] = (byte)(i >> 8);
            result[2] = (byte)(i);


            return result;
        }

        // =============================================================================================
        // Setters and Getters
        // =============================================================================================
        public String getSWS_P3Packet_Command()
        {
            return SWS_P3Packet_Command;
        }

        public void setSWS_P3Packet_Command(String SWS_P3Packet_Command)
        {
            this.SWS_P3Packet_Command = SWS_P3Packet_Command;
        }

        public String getSWS_P3Packet_ScanTime()
        {
            return SWS_P3Packet_ScanTime;
        }

        public void setSWS_P3Packet_ScanTime(String SWS_P3Packet_ScanTime)
        {
            this.SWS_P3Packet_ScanTime = SWS_P3Packet_ScanTime;
        }

        public String getSWS_P3Packet_PointsCount()
        {
            return SWS_P3Packet_PointsCount;
        }

        public void setSWS_P3Packet_PointsCount(String SWS_P3Packet_PointsCount)
        {
            this.SWS_P3Packet_PointsCount = SWS_P3Packet_PointsCount;
        }

        public String getSWS_P3Packet_OpticalGain()
        {
            return SWS_P3Packet_OpticalGain;
        }

        public void setSWS_P3Packet_OpticalGain(String SWS_P3Packet_OpticalGain)
        {
            this.SWS_P3Packet_OpticalGain = SWS_P3Packet_OpticalGain;
        }

        public String getSWS_P3Packet_Apodization()
        {
            return SWS_P3Packet_Apodization;
        }

        public void setSWS_P3Packet_Apodization(String SWS_P3Packet_Apodization)
        {
            this.SWS_P3Packet_Apodization = SWS_P3Packet_Apodization;
        }

        public String getSWS_P3Packet_ZeroPadding()
        {
            return SWS_P3Packet_ZeroPadding;
        }

        public void setSWS_P3Packet_ZeroPadding(String SWS_P3Packet_ZeroPadding)
        {
            this.SWS_P3Packet_ZeroPadding = SWS_P3Packet_ZeroPadding;
        }

        public String getSWS_P3Packet_RunMode()
        {
            return SWS_P3Packet_RunMode;
        }

        public void setSWS_P3Packet_RunMode(String SWS_P3Packet_RunMode)
        {
            this.SWS_P3Packet_RunMode = SWS_P3Packet_RunMode;
        }

        public byte[] getPacketStream()
        {
            return packetStream;
        }

        public void setPacketStream(byte[] packetStream)
        {
            Array.Copy(packetStream, 0, this.packetStream, 0, packetStream.Length);
        }

        public bool isInterpolationMode()
        {
            return InterpolationMode;
        }

        public void setInterpolationMode(bool interpolationMode)
        {
            InterpolationMode = interpolationMode;
        }

    }
}
