using System.Collections.Generic;
using NeuralNetworkBP.Interfaces;

namespace NeuralNetworkBP
{
    public static class NNFactory
    {
        static IActiovationFunction _actiovationFunction = new Sigmoid();
        public static List<NeuralLayer> Create(int inputNeurons, int[] hiddentNeurons, int outputNeurons,IActiovationFunction actiovationFunction)
        {
            _actiovationFunction = actiovationFunction;
            List<NeuralLayer> neuralLayers = new List<NeuralLayer>();
            var prev = CreateInputLayer(inputNeurons);
            neuralLayers.Add(prev);

            foreach (var nValue in hiddentNeurons)
            {
                var layer = CreateHiddenLayer(nValue);
                layer.ConnectWithLayer(prev);
                neuralLayers.Add(layer);
                prev = layer;
            }

            var outputLayer = CreateOutputLayer(outputNeurons);
            outputLayer.ConnectWithLayer(prev);
            neuralLayers.Add(outputLayer);

            return neuralLayers;
        }

        private static NeuralLayer CreateInputLayer(int numNeurons)
        {
            List<INeuron> neurons = new List<INeuron>();

            for (int i = 0; i < numNeurons; i++)
            {   
                Neuron newInputNeuron = new Neuron(_actiovationFunction);
                newInputNeuron.AddInputConnection(0);
                neurons.Add(newInputNeuron);
            }
            
            //neurons.Add(new BiasNeuron(_actiovationFunction));
            
            return new NeuralLayer(neurons);
        }

        private static NeuralLayer CreateHiddenLayer(int numNeurons)
        {
            List<INeuron> neurons = new List<INeuron>();

            for (int i = 0; i < numNeurons; i++)
            {   
                neurons.Add(new Neuron(_actiovationFunction));
            }
            //neurons.Add(new BiasNeuron(_actiovationFunction));
            return new NeuralLayer(neurons);
        }
        
        private static NeuralLayer CreateOutputLayer(int numNeurons)
        {
            List<INeuron> neurons = new List<INeuron>();

            for (int i = 0; i < numNeurons; i++)
            {   
                neurons.Add(new Neuron(_actiovationFunction));
            }
            
            return new NeuralLayer(neurons);
        }
        
        
        
        
    }
}