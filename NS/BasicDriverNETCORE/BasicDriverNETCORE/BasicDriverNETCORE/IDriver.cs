using System;
using System.Collections.Generic;

namespace BasicDriverNETCORE
{
    public interface IDriver
    {
        public void Train(string xmlPath,int numEpochs);
        
        public void Train(string xmlPath,int numEpochs,string savePath);
        public void Load(string path);
        public void Save(string path);
        Dictionary<String, float> drive(Dictionary<String, float> values);
    }
}