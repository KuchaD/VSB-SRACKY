using System;
using System.Collections.Generic;
using System.Linq;
using NeuralNetworkBP;
using NNBackPropagation;

namespace BasicDriverNETCORE
{
    public class NetDriver : IDriver
    {
        private NNetwork NN;
        private DriverTrainer _driverTrainer;
        public NetDriver()
        {
            NN = new NNetwork(28,new int []{10,10},2,0.1,new SigmoidFunction());
            
            _driverTrainer = new DriverTrainer(NN);
        }

        public void Train(string xmlPath, int numEpochs)
        {
            _driverTrainer.Train(xmlPath,numEpochs);
        }
        
        public void Train(string xmlPath, int numEpoch,string savePath)
        {
            _driverTrainer.Train(xmlPath,numEpoch,savePath);
        }

        public void Load(string path)
        {
            NN = NNetwork.DeserializeBin(path);
        }

        public void Save(string path)
        {
            NNetwork.SerializeBin(path,NN);
        }

        public Dictionary<string, float> drive(Dictionary<string, float> values)
        {
            
            Dictionary<String, float> responses = new Dictionary<String, float>();

            var list = values.Keys.ToList();
            list.Sort();

            var sdict = new SortedDictionary<string, double>();
                
            foreach (var key in list)
            {
                sdict.Add(key, values[key]);
            }
            
            var val = sdict.Select(x => (double) x.Value).ToArray();
            var res = NN.Forward(val.ToList());
            
            responses.Add("acc", (float)res[1]);
            responses.Add("wheel", (float)res[0]);
            
            
            return responses;
            
        }
    }
}