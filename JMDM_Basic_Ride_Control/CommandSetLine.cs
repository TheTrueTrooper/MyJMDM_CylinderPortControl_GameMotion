using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace JMDM_Basic_Ride_Control
{
    class CommandSetLine
    {
        public byte?[] CylinderHeights { get; private set; }
        public int WaitTime { get; private set; }

        public static List<CommandSetLine> LoadLineCommandsFromTextStream(StreamReader Stream)
        {
            List<CommandSetLine> LineCommands = new List<CommandSetLine>();
            int LineValueCount = 0;
            while(!Stream.EndOfStream)
            {
                string CommandLine = Stream.ReadLine();

                List<string> CSValues = CommandLine.Split(',').ToList();

                if (LineValueCount == 0)
                    LineValueCount = CSValues.Count;

                if (LineValueCount != CSValues.Count)
                    throw new Exception(" CommandLines are inconsistent");

                byte?[] CylinderHeights = new byte?[LineValueCount - 1];

                for (int i = 0; i < CylinderHeights.Count(); i ++)
                {
                    try
                    {
                        CylinderHeights[i] = byte.Parse(CSValues[i]);
                    }
                    catch
                    {
                        CylinderHeights[i] = null;
                    }
                }

                int WaitTime = int.Parse(CSValues[CSValues.Count - 1]);

                LineCommands.Add(new CommandSetLine() { CylinderHeights = CylinderHeights, WaitTime = WaitTime });
            }

            return LineCommands;
        }
    }
}
