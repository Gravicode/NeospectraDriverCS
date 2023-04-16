using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeospectraApp.Driver
{
    public class CommonVariables
    {
        private static int ScanningState = 0;

        public static int getScanningState()
        {
            return ScanningState;
        }

        public static void setScanningState(int scanningState)
        {
            ScanningState = scanningState;
        }
    }
}
