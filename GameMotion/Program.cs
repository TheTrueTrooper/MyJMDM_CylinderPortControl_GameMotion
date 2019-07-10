using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.IO;
using JMDM_Basic_Ride_Control;

namespace GameMotion
{
    class Program
    {
        static void Main(string[] args)
        {
            string Port = args.FirstOrDefault(x=>x.StartsWith("-Com"));
            string DataFile = args.FirstOrDefault(x => x.StartsWith("-File:"));

            if (args.Length != 0 && Port == null)
            {
                Console.WriteLine("Please enter a port to use.");
                Port = Console.ReadLine();
            }
            else
            {
                Port = Port.Replace(":", "").Replace("-", "").ToUpper();
            }

            if (args.Length != 0 && Port == null)
            {
                Console.WriteLine("Please enter a data file to use.");
                DataFile = Console.ReadLine();
            }
            else
            {
                DataFile = DataFile.Remove(0, 6).Replace("\"", "");
            }

            string[] ports = SerialPort.GetPortNames();

            while(!ports.Contains(Port))
            {
                Console.WriteLine("Opps that port doesnt exist.\nPlease pick another port");
                Port = Console.ReadLine();
            }

            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            //Console.WriteLine("Game Starting");
            try
            {
                using (StreamReader CommandData = new StreamReader(DataFile))
                {
                    JMDM_BasicRide.JMDM_BasicRide_Run(Port, CommandData);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Game motion data or port failed to load.\n"+e);
            }


            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
