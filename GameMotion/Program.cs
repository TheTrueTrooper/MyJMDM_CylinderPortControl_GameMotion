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
            //-Com:6 -File:"C:\\Users\\Angelo's Tower PC\\Desktop\\Game Move Data\\CXV.Files\\3 dof suitable all 3dof machine\\03-Birth of baby_3DOF.JMMov" -StartWait:4000 -EndWait:4000 -NumberOfCylinder:6
            //this line is in here for testing to skip the start phase
            //JMDM_BasicRide.JMDM_BasicRide_Run("COM6", 6, "C:\\Users\\Angelo's Tower PC\\Desktop\\Game Move Data\\CXV.Files\\3 dof suitable all 3dof machine\\03-Birth of baby_3DOF.JMMov");

            string Port = args?.FirstOrDefault(x=>x.StartsWith("-Com"));
            string DataFile = args?.FirstOrDefault(x => x.StartsWith("-File:"));
            string StartWaitInput = args?.FirstOrDefault(x => x.StartsWith("-StartWait:"));
            string EndWaitInput = args?.FirstOrDefault(x => x.StartsWith("-EndWait:"));
            string NumberOfCylindersInput = args?.FirstOrDefault(x => x.StartsWith("-NumberOfCylinder:"));

            if (args.Length == 0 || Port == null)
            {
                Console.WriteLine("Please enter a port to use.");
                Port = Console.ReadLine();
            }
            else
            {
                Port = Port.Replace(":", "").Replace("-", "").ToUpper();
            }

            if (args.Length == 0 || DataFile == null)
            {
                Console.WriteLine("Please enter a data file to use.");
                DataFile = Console.ReadLine();
            }
            else
            {
                DataFile = DataFile.Replace("-File:", "").Replace("\"", "");
            }

            if (args.Length == 0 || NumberOfCylindersInput == null)
            {
                Console.WriteLine("Please enter the number of cylinders the machine uses.");
                NumberOfCylindersInput = Console.ReadLine();
            }
            else
            {
                NumberOfCylindersInput = NumberOfCylindersInput.Replace("-NumberOfCylinder:", "").Replace("-", "").ToUpper();
            }

            if (args.Length == 0 || StartWaitInput == null)
            {
                Console.WriteLine("Please enter a period to wait at start for syncing.");
                StartWaitInput = Console.ReadLine();
            }
            else
            {
                StartWaitInput = StartWaitInput.Replace("-StartWait:", "").ToUpper();
            }

            if (args.Length == 0 || EndWaitInput == null)
            {
                Console.WriteLine("Please enter a period to wait at end for syncing.");
                EndWaitInput = Console.ReadLine();
            }
            else
            {
                EndWaitInput = EndWaitInput.Replace("-EndWait:", "").ToUpper();
            }

            try
            {
                int StartWait, EndWait;
                byte NumberOfCylinders;

                try
                {
                    StartWait = int.Parse(StartWaitInput);
                }
                catch (Exception e)
                {
                    throw new Exception("The Start Wait was not pressent or ont a valid whole number.", e);
                }

                try
                {
                    EndWait = int.Parse(EndWaitInput);
                }
                catch(Exception e)
                {
                    throw new Exception("The End Wait was not pressent or ont a valid whole number.", e);
                }

                try
                {
                    NumberOfCylinders = byte.Parse(NumberOfCylindersInput);
                }
                catch(Exception e)
                {
                    throw new Exception("The number of Cylinders was not pressent or ont a valid whole number.", e);
                }

                //string[] ports = SerialPort.GetPortNames();

                //while(!ports.Contains(Port))
                //{
                //    Console.WriteLine("Opps that port doesnt exist.\nPlease pick another port");
                //    Port = Console.ReadLine();
                //}

                JMDM_BasicRide.JMDM_BasicRide_Run(Port, NumberOfCylinders, DataFile, StartWait, EndWait);
            }
            catch(Exception e)
            {
                Console.WriteLine("There has been the following exception.");
                Console.WriteLine("\t" + e.Message);
                Console.WriteLine("\t\tHere is the following stack trace");
                Console.WriteLine(e);
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
            }

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
