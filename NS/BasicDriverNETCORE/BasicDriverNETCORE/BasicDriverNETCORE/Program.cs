using System;
using System.Collections.Generic;
using NNBackPropagation;

namespace BasicDriverNETCORE
{
    class Program
    {
        static void Main(string[] args)
        {
            String host = "localhost";
            int port = 9461;
            String raceName = "test";
            String driverName = "basic_client";
            String carType = null;
            RaceConnector raceConnector = null;
            bool start = false;
            
            raceConnector = new RaceConnector(host, port, null);
            raceConnector.setDriver(new NetDriver());
            
            while (!start)
            {
                Console.WriteLine("Driver Manager");
                Console.WriteLine($"Setting Host: {host} , Port: {port}, race name {raceName} , cartype{carType ?? " not set"}");
                Console.WriteLine();
                Console.WriteLine("1. Start");
                Console.WriteLine("2. Train");
                Console.WriteLine("3. Set");
                Console.WriteLine("4. Load Trained Model");
                Console.WriteLine("5. Exit");
                var result = Console.ReadLine();
                Console.Clear();
                switch (result)
                {
                    case "1":
                        start = true;
                        raceConnector.setServerName(host);
                        raceConnector.setPort(port);
                        break;
                    case "2":
                        var trainxml = YesNoResultMenu("Set xmlPath? ", "/Users/dave/Desktop/testauto2.txt");
                        if (trainxml == null)
                        {
                            Console.WriteLine("Bad Path");
                            break;
                        }
                        int numberEpoch = int.Parse(YesNoResultMenu("Set Epoch. ", "25000") ?? "25000");
                        raceConnector.getDriver().Train(trainxml,numberEpoch);
                        var savePath = YesNoResultMenu("Do you want save model?", "/Users/dave/Desktop/model.bin");
                        if (savePath != null)
                        {
                            raceConnector.getDriver().Save(savePath);
                            Console.WriteLine("Save "+ savePath);
                        }

                        break;
                    case "3":
                        host = YesNoResultMenu("Do you want set Host?", "localhost") ?? host;
                        port = int.Parse(YesNoResultMenu("Do you want set Port?" ,"9460") ?? port.ToString());
                        raceName = YesNoResultMenu("Do you want set race name ?", "test") ?? raceName;
                        driverName = YesNoResultMenu("Do you want set driveName?", "basic_client") ?? driverName;
                        break;
                    case "4":
                        var modelpath = YesNoResultMenu("Do you want load modelPath? ", "/Users/dave/Desktop/model.bin");
                        if (modelpath == null)
                            break;
                        else
                            raceConnector.getDriver().Load(modelpath);
                        break;
                    case "5":
                        return;
                        break;
                    
                }
            }
            
            
            
          
            raceConnector.start(raceName, driverName, carType);
            
        }

        static string YesNoResultMenu(string text,string xdefault)
        {
            Console.Clear();
            Console.WriteLine(text+ $"Defautl: {xdefault} " + "Y/N");
            var result = Console.ReadLine();
            if (result == "y" || result == "yes" ||  result == "Y")
            {
                Console.Clear();
                Console.WriteLine($"Set it:  Default: {xdefault}");
                result = Console.ReadLine();

                if (result == "")
                {
                    return xdefault;
                }
                return result;
            }

            return null;
        }
    }
}