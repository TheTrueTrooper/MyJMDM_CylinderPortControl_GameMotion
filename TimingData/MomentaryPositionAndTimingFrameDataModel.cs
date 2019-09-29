using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TimingData
{
    /// <summary>
    /// this holds all the motion data for a key frame in an intervol
    /// </summary>
    //[Serializable]
    [StructLayout(LayoutKind.Explicit, Size = 30, Pack = 1)]
    public struct MomentaryPositionAndTimingFrameDataModel
    {
        /// <summary>
        /// the wait time before the next move in ticks for miliseconds
        /// </summary>
        [FieldOffset(0)]
        public UInt64 time;
        /// <summary>
        /// the postion to set cylinder 1 to
        /// </summary>
        [FieldOffset(8)]
        public byte C1;
        /// <summary>
        /// the postion to set cylinder 2 to
        /// </summary>
        [FieldOffset(9)]
        public byte C2;
        /// <summary>
        /// the postion to set cylinder 3 to
        /// </summary>
        [FieldOffset(10)]
        public byte C3;
        /// <summary>
        /// the postion to set cylinder 4 to
        /// </summary>
        [FieldOffset(11)]
        public byte C4;
        /// <summary>
        /// the postion to set cylinder 5 to
        /// </summary>
        [FieldOffset(12)]
        public byte C5;
        /// <summary>
        /// the postion to set cylinder 6 to
        /// </summary>
        [FieldOffset(13)]
        public byte C6;
        /// <summary>
        /// Some machines have effects to apply for the time this is for 'SweepingLegs1'
        /// </summary>
        [FieldOffset(14)]
        public bool Snowflakes;
        /// <summary>
        /// Some machines have effects to apply for the time this is for 'Snowflakes'
        /// </summary>
        [FieldOffset(15)]
        public bool SweepingLegs1;
        /// <summary>
        /// Some machines have effects to apply for the time this is for 'Wind'
        /// </summary>
        [FieldOffset(16)]
        public bool Wind;
        /// <summary>
        /// Some machines have effects to apply for the time this is for 'Rain'
        /// </summary>
        [FieldOffset(17)]
        public bool Rain;
        /// <summary>
        /// Some machines have effects to apply for the time this is for 'Smoke'
        /// </summary>
        [FieldOffset(18)]
        public bool Smoke;
        /// <summary>
        /// Some machines have effects to apply for the time this is for 'Bubbles'
        /// </summary>
        [FieldOffset(19)]
        public bool Bubbles;
        /// <summary>
        /// Some machines have effects to apply for the time this is for 'lightning'
        /// </summary>
        [FieldOffset(20)]
        public bool Lightning;
        /// <summary>
        /// Some machines have effects to apply for the time this is for 'flame'
        /// </summary>
        [FieldOffset(21)]
        public bool Flame;
        /// <summary>
        /// Some machines have effects to apply for the time this is for 'jet'
        /// </summary>
        [FieldOffset(22)]
        public bool Jet;
        /// <summary>
        /// Some machines have effects to apply for the time this is for 'sweepingLegs2'
        /// </summary>
        [FieldOffset(23)]
        public bool SweepingLegs2;
        /// <summary>
        /// Some machines have effects to apply for the time this is for 'waterSpray'
        /// </summary>
        [FieldOffset(24)]
        public bool WaterSpray;
        /// <summary>
        /// Some machines have effects to apply for the time this is for 'vibration'
        /// </summary>
        [FieldOffset(25)]
        public bool Vibration;
        /// <summary>
        /// Some machines have effects to apply for the time this is for 'Wind'
        /// </summary>
        [FieldOffset(26)]
        public bool Back;
        /// <summary>
        /// Some machines have effects to apply for the time this effect is unset and reserved for future use
        /// </summary>
        [FieldOffset(27)]
        public bool Spare1;
        /// <summary>
        /// Some machines have effects to apply for the time this effect is unset and reserved for future use
        /// </summary>
        [FieldOffset(28)]
        public bool Spare2;
        /// <summary>
        /// Some machines have effects to apply for the time this effect is unset and reserved for future use
        /// </summary>
        [FieldOffset(29)]
        public bool Spare3;

        public byte GetCylinder(byte CylinderNumber)
        {
            switch(CylinderNumber)
            {
                case 0:
                    return C1;
                case 1:
                    return C2;
                case 2:
                    return C3;
                case 3:
                    return C4;
                case 4:
                    return C5;
                case 5:
                    return C6;
                default:
                    throw new IndexOutOfRangeException("That is not a valid number there are 6 cilis. make a 0 based selection.");
            }
        }

        internal static MomentaryPositionAndTimingFrameDataModel LoadFromBuffer(byte[] Buffer, ref int Pos)
        {
            MomentaryPositionAndTimingFrameDataModel Return = new MomentaryPositionAndTimingFrameDataModel();

            Return.time = BitConverter.ToUInt64(Buffer, Pos + 0);
            Return.C1 = Buffer[Pos + 8];
            Return.C2 = Buffer[Pos + 9];
            Return.C3 = Buffer[Pos + 10];
            Return.C4 = Buffer[Pos + 11];
            Return.C5 = Buffer[Pos + 12];
            Return.C6 = Buffer[Pos + 13];
            Return.Snowflakes = Buffer[Pos + 14] == 1;
            Return.SweepingLegs1 = Buffer[Pos + 15] == 1;
            Return.Wind = Buffer[Pos + 16] == 1;
            Return.Rain = Buffer[Pos + 17] == 1;
            Return.Smoke = Buffer[Pos + 18] == 1;
            Return.Bubbles = Buffer[Pos + 19] == 1;
            Return.Lightning = Buffer[Pos + 20] == 1;
            Return.Flame = Buffer[Pos + 21] == 1;
            Return.Jet = Buffer[Pos + 22] == 1;
            Return.SweepingLegs2 = Buffer[Pos + 23] == 1;
            Return.WaterSpray = Buffer[Pos + 24] == 1;
            Return.Vibration = Buffer[Pos + 25] == 1;
            Return.Back = Buffer[Pos + 26] == 1;
            Return.Spare1 = Buffer[Pos + 27] == 1;
            Return.Spare2 = Buffer[Pos + 28] == 1;
            Return.Spare3 = Buffer[Pos + 29] == 1;

            Pos += 30;

            return Return;
        }

        internal void SaveToBuffer(byte[] Buffer, ref int Pos)
        {
            byte[] Temp = BitConverter.GetBytes(time);
            Array.Copy(Temp, 0, Buffer, Pos, Temp.Length);
            Buffer[Pos + 8] = C1;
            Buffer[Pos + 9] = C2;
            Buffer[Pos + 10] = C3;
            Buffer[Pos + 11] = C4;
            Buffer[Pos + 12] = C5;
            Buffer[Pos + 13] = C6;
            Buffer[Pos + 14] = BitConverter.GetBytes(Snowflakes)[0];
            Buffer[Pos + 15] = BitConverter.GetBytes(SweepingLegs1)[0];
            Buffer[Pos + 16] = BitConverter.GetBytes(Wind)[0];
            Buffer[Pos + 17] = BitConverter.GetBytes(Rain)[0];
            Buffer[Pos + 18] = BitConverter.GetBytes(Smoke)[0];
            Buffer[Pos + 19] = BitConverter.GetBytes(Bubbles)[0];
            Buffer[Pos + 20] = BitConverter.GetBytes(Lightning)[0];
            Buffer[Pos + 21] = BitConverter.GetBytes(Flame)[0];
            Buffer[Pos + 22] = BitConverter.GetBytes(Jet)[0];
            Buffer[Pos + 23] = BitConverter.GetBytes(SweepingLegs2)[0];
            Buffer[Pos + 24] = BitConverter.GetBytes(WaterSpray)[0];
            Buffer[Pos + 25] = BitConverter.GetBytes(Vibration)[0];
            Buffer[Pos + 26] = BitConverter.GetBytes(Back)[0];
            Buffer[Pos + 27] = BitConverter.GetBytes(Spare1)[0];
            Buffer[Pos + 28] = BitConverter.GetBytes(Spare2)[0];
            Buffer[Pos + 29] = BitConverter.GetBytes(Spare3)[0];

            Pos += 30;
        }
    }
}
