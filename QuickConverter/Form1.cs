using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using TimingData;

namespace QuickConverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FolderSelector = new FolderBrowserDialog();
            if(FolderSelector.ShowDialog() == DialogResult.OK)
            {
                
                string[] FilePaths = Directory.GetFiles(FolderSelector.SelectedPath, "*.csv");
                foreach(string Path in FilePaths)
                {
                    PositionAndTimingDataModel FullData = new PositionAndTimingDataModel();
                    List<MomentaryPositionAndTimingFrameDataModel> FrameData = new List<MomentaryPositionAndTimingFrameDataModel>();
                    using (StreamReader SR = new StreamReader(Path))
                    {
                        string SCVFram = null;
                        string[] SCVLastFrameData = null;
                        string[] SCVFrameData = null;
                        SR.ReadLine();
                        while (!SR.EndOfStream)
                        {
                            if (SCVFram != null)
                                SCVLastFrameData = SCVFrameData;
                            else
                                SCVLastFrameData = new string[] {"0", "0", };

                            SCVFram = SR.ReadLine();
                            SCVFrameData = SCVFram.Split(',');

                            FrameData.Add(new MomentaryPositionAndTimingFrameDataModel()
                            {
                                time = Convert.ToUInt64(float.Parse(SCVFrameData[1])* 1000.0f) - Convert.ToUInt64(float.Parse(SCVLastFrameData[1]) * 1000.0f),
                                C1 = byte.Parse(SCVFrameData[2]),
                                C2 = byte.Parse(SCVFrameData[3]),
                                C3 = byte.Parse(SCVFrameData[4]),
                                C4 = byte.Parse(SCVFrameData[5]),
                                C5 = byte.Parse(SCVFrameData[6]),
                                C6 = byte.Parse(SCVFrameData[7]),
                                Snowflakes = SCVFrameData[8] == "1",
                                SweepingLegs1 = SCVFrameData[9] == "1",
                                Wind = SCVFrameData[10] == "1",
                                Rain = SCVFrameData[11] == "1",
                                Smoke = SCVFrameData[12] == "1",
                                Bubbles = SCVFrameData[13] == "1",
                                Lightning = SCVFrameData[14] == "1",
                                Flame = SCVFrameData[15] == "1",
                                Jet = SCVFrameData[16] == "1",
                                SweepingLegs2 = SCVFrameData[17] == "1",
                                WaterSpray = SCVFrameData[18] == "1",
                                Vibration = SCVFrameData[19] == "1",
                                Back = SCVFrameData[20] == "1",
                                Spare1 = SCVFrameData[21] == "1",
                                Spare2 = SCVFrameData[22] == "1",
                                Spare3 = SCVFrameData[23] == "1",
                            });
                        }
                    }
                    FullData.PostionsAndTimings = FrameData.ToArray();
                    FullData.SaveDataToFile(Path.Replace(".csv", ".JMMov"));
                }
            }
        }
    }
}
