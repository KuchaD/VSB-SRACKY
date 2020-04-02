using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Transactions;
using NeuralNetworkBP;
using NNBackPropagation;

namespace BasicDriverNETCORE
{
    public class DriverTrainer
    {
        private NNetwork NN;
        private LoadXML xml;
        public DriverTrainer()
        {
            NN = new  NNetwork(28,new int[]{10,10},2,0.4,new SigmoidFunction());
        }
        
        public DriverTrainer( NNetwork NNa)
        {
            NN = NNa;
        }

        public void Train(string pathFile,int numEpoch)
        {
            xml = new LoadXML();
            xml.ReadXML(pathFile);
           
            Dictionary<string,double> dict = new Dictionary<string, double>();
            List<double[]> outt = new List<double[]>();
            
            for (int i = 0; i < xml._trainSet.Count; i++)
            {
                dict = new Dictionary<string, double>();
                
                for (int j = 0; j < xml._trainSet[i].Length; j++)
                {
                    dict.Add(xml._names[j], xml._trainSet[i][j]);
                }
                
                var list = dict.Keys.ToList();
                list.Sort();

                var sdict = new SortedDictionary<string, double>();
                
                foreach (var key in list)
                {
                    sdict.Add(key, dict[key]);
                }
                
                sdict.Values.ToList();
                var d = sdict.Select(x => x.Value).ToArray(); 
                outt.Add(d);
            }
            
            for (int i = 0; i < numEpoch; i++)
            {
                for (int k = 0; k < outt.Count; k++)
                    NN.Train(outt[k].ToList(), xml._trainOutput[k].ToList());
                Console.Clear();
                Console.WriteLine($"Epochs {i}/{numEpoch} == Total Error  {NN.TotalError} ");
            }
            /*
            var test = NN.Forward(outt.ToArray()[0].ToList());
            var ex = xml._trainOutput.ToArray()[0];
            
            var test1 = NN.Forward(outt.ToArray()[1].ToList());
            var ex1 = xml._trainOutput.ToArray()[1];
            
            var test2 = NN.Forward(outt.ToArray()[2].ToList());
            var ex2 = xml._trainOutput.ToArray()[2];
            */
            
        }

        public void Train(string pathFile, int numEpoch,string savePath)
        {
            xml = new LoadXML();
            xml.ReadXML(pathFile);

            Dictionary<string, double> dict = new Dictionary<string, double>();
            List<double[]> outt = new List<double[]>();

            for (int i = 0; i < xml._trainSet.Count; i++)
            {
                dict = new Dictionary<string, double>();

                for (int j = 0; j < xml._trainSet[i].Length; j++)
                {
                    dict.Add(xml._names[j], xml._trainSet[i][j]);
                }

                var list = dict.Keys.ToList();
                list.Sort();

                var sdict = new SortedDictionary<string, double>();

                foreach (var key in list)
                {
                    sdict.Add(key, dict[key]);
                }

                sdict.Values.ToList();
                var d = sdict.Select(x => x.Value).ToArray();
                outt.Add(d);
            }

            for (int i = 0; i < numEpoch; i++)
            {
                for (int k = 0; k < outt.Count; k++)
                    NN.Train(outt[k].ToList(), xml._trainOutput[k].ToList());
                Console.Clear();
                Console.WriteLine($"Epochs {i}/{numEpoch} == Total Error  {NN.TotalError} ");
            }
            
            NNetwork.SerializeBin(savePath,NN);
            Console.WriteLine($"Save Net {savePath} ");
        }

    }
}