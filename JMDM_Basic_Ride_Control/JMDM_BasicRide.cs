using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using MyJMDM_CylinderPortControl;
using TimingData;

namespace JMDM_Basic_Ride_Control
{
    public static class JMDM_BasicRide
    {
        public static void JMDM_BasicRide_Run(string Port, byte CylinderCount, string JMMovFilePath, int StartWait = 2000, int EndWait = 2000, Action ExtraAction = null)
        {
            PositionAndTimingDataModel PositionAndTiming = PositionAndTimingDataModel.DataLoadFromFile(JMMovFilePath);
            JMDM_CylinderPortControlUpdated CylinderControl = new JMDM_CylinderPortControlUpdated(Port, CylinderCount);

            if (CylinderCount > 6)
                CylinderCount = 6;

            CylinderControl.Open_Port();

            CylinderControl.ZeroAllCylinders();

            Thread.Sleep(StartWait);

            ExtraAction?.Invoke();

            foreach(MomentaryPositionAndTimingFrameDataModel Frame in PositionAndTiming)
            {
                for(byte i = 0; i < CylinderCount; i++)
                 CylinderControl.SetCylinderHeight(i, Frame.GetCylinder(i));
                Thread.Sleep((int)Frame.time);
            }

            CylinderControl.ZeroAllCylinders();

            Thread.Sleep(EndWait);
        }
    }
}
