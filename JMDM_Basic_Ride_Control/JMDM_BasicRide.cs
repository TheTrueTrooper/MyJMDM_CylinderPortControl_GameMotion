using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using MyJMDM_CylinderPortControl;

namespace JMDM_Basic_Ride_Control
{
    public static class JMDM_BasicRide
    {
        public static void JMDM_BasicRide_Run(string Port, StreamReader CommandData, Action ExtraAction = null)
        {
            List<CommandSetLine> LineCommands = CommandSetLine.LoadLineCommandsFromTextStream(CommandData);
            JMDM_CylinderPortControl CylinderControl = new JMDM_CylinderPortControl(Port, LineCommands[0].CylinderHeights.Count());

            CylinderControl.Open_Port();

            Thread.Sleep(2000);

            for (int i = 1; i < LineCommands.Count; i++)
            {
                CylinderControl.SetAllCylinders(LineCommands[i].CylinderHeights);
                ExtraAction?.Invoke();
                Thread.Sleep(LineCommands[i].WaitTime);
            }

            CylinderControl.ZeroAllCylinders();
            Thread.Sleep(2000);
        }
    }
}
