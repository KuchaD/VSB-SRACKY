using System;
using System.Collections.Generic;
using System.Linq;
using NeuralNetworkBP.Interfaces;

namespace NeuralNetworkBP
{
    [Serializable]
    public class NeuralLayer
    {
        public List<INeuron> Neurons;

        public NeuralLayer(){}
        public NeuralLayer(List<INeuron> neurons)
        {
            Neurons = neurons;
        }

        public void ExecuteOutput()
        {
            Neurons.ForEach(x => x.Execute());
        }
        public void ConnectWithLayer(NeuralLayer neuralLayer)
        {
           
            foreach (var nNeuron in Neurons)
            {

                foreach (var nInputNeurons in neuralLayer.Neurons)
                {

                    nNeuron.AddInputNeuron(nInputNeurons);
                }
                
            }
        }
    }
}