using System;
using System.Collections.Generic;
using System.IO;
using NeuralNetworkBP;

namespace TestApp
{
    public class LoadCSVMNIST
    {
        public List<Tuple< double[], string>> Images { get; set; }
        
        public LoadCSVMNIST()
        {
            Images = new List<Tuple<double[], string>>();
        }
        public void Read(string path)
        {
            using(var reader = new StreamReader(path))
            {
                List<string> pixels = new List<string>();

                int k = 0;
                while (!reader.EndOfStream)
                {
                    k++;
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    
                    if(k == 1)
                        continue;
                    
                    List<double> val = new List<double>();
                    for (int i = 1; i < values.Length; i++)
                    {
                        val.Add( NeuralNet.ConverMaxMin( UInt32.Parse(values[i]),0,255,0,1));
                    }
                        
                    Images.Add(new Tuple<double[], string>(val.ToArray(),values[0]));
                    
                }
            }

        }
    }
}