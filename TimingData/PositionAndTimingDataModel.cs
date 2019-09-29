using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace TimingData
{
    public struct PositionAndTimingDataModel : IEnumerable<MomentaryPositionAndTimingFrameDataModel>
    {
        /// <summary>
        /// this is a collection of all of the data for a 
        /// </summary>
        public MomentaryPositionAndTimingFrameDataModel[] PostionsAndTimings;


        public static PositionAndTimingDataModel DataLoadFromFile(string FilePath)
        {
            byte[] Buffer;
            int Pos = 0;
            List<MomentaryPositionAndTimingFrameDataModel> DeserilizedData = new List<MomentaryPositionAndTimingFrameDataModel>();
            using (FileStream Stream = File.Open(FilePath, FileMode.Open))
            {
                Buffer = new byte[Stream.Length];
                Task<int> Read = Stream.ReadAsync(Buffer, 0, (int)Stream.Length);
                int status = Read.Result;
                Stream.Flush();
                Stream.Close();
            }
            while (Pos < Buffer.Length)
                DeserilizedData.Add(MomentaryPositionAndTimingFrameDataModel.LoadFromBuffer(Buffer, ref Pos));
            return new PositionAndTimingDataModel() { PostionsAndTimings = DeserilizedData.ToArray() };
        }

        public void SaveDataToFile(string FilePath)
        {
            int Pos = 0;
            byte[] Data = new byte[PostionsAndTimings.Count() * 30];
            foreach (MomentaryPositionAndTimingFrameDataModel FameToSave in PostionsAndTimings)
            {
                FameToSave.SaveToBuffer(Data, ref Pos);
            }
            using (FileStream Stream = File.Create(FilePath))
            {
                Task Write = Stream.WriteAsync(Data, 0, Data.Length);
                Write.Wait();
                Stream.Flush();
                Stream.Close();
            }
        }

        public IEnumerator<MomentaryPositionAndTimingFrameDataModel> GetEnumerator()
        {
            foreach (MomentaryPositionAndTimingFrameDataModel Frame in PostionsAndTimings)
                yield return Frame;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (MomentaryPositionAndTimingFrameDataModel Frame in PostionsAndTimings)
                yield return Frame;
        }
        //CautionNJ84 
    }
}
