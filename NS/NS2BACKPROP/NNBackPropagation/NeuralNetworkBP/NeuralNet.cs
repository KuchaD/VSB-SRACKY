using System;
using System.Collections.Generic;
using System.Linq;
using NeuralNetworkBP.Interfaces;

namespace NeuralNetworkBP
{
    public class NeuralNet
    {
        public List<NeuralLayer> Layers { get; set; }
        private double _learning_rate;
        private double[][] _expectedResult;

        void Create()
        {
            Layers = NNFactory.Create(2, new int[] {10}, 1,new Sigmoid());
        }

        public NeuralNet(int inputNeurons, int[] hiddenNeurons, int outputNeuorns,double learningRate, IActiovationFunction actiovationFunction)
        {
            _learning_rate = learningRate;
            Layers = NNFactory.Create(inputNeurons, hiddenNeurons, outputNeuorns,actiovationFunction);
        }

        public NeuralNet(List<NeuralLayer> layers,double learningRate)
        {
            Layers = layers;
            _learning_rate = learningRate;
        }
        public NeuralNet(double learningRate)
        {
            _learning_rate = learningRate;
            Create();
        }
        void SetInputValues(List<double> values)
        {
            var neurons = Layers.First().Neurons;
            
            if (values.Count() != neurons.Count)
                return;

            for (int i = 0; i < neurons.Count ; i++)
            {
                neurons[i].ChangeInputValue(values[i]);
            }
        }

        public double[] Forward(List<double> values)
        {
            SetInputValues(values);
            return Forward();
        }
        double[] Forward()
        {
            if(Layers == null)
                return null;
            
            Layers.ForEach(x => x.ExecuteOutput());

            var last = Layers.Last();
            return last.Neurons.Select(x => x.Output).ToArray();

        }

        public double CalculateTotalError(double[] expectedOutputs)
        {
            double totalError = 0;

            for (int i = 0; i < Layers.Last().Neurons.Count; i++)
            {
                totalError += Layers.Last().Neurons[i].CalculateError(expectedOutputs[i]);
            }

            return totalError;
        }
        
        private void ErrorOutputLayer(double[] expectedOutputs)
        {
            Layers.Last().Neurons.ForEach(neuron =>
            {
                neuron.Inputs.ForEach(connection =>
                {
                    var output = neuron.Output;
                    var netInput = connection.GetOutput();

                    var expectedOutput = expectedOutputs[Layers.Last().Neurons.IndexOf(neuron)];

                    var nodeDelta = neuron.CalculatePDEror(expectedOutput) * neuron.CalculatePDOutput();
                    var delta = -1 * netInput * nodeDelta;
                    
                    connection.UpdateWeight(_learning_rate, delta);

                    neuron.bias = -1 * nodeDelta;
                    neuron.PreviousPartialDerivate = nodeDelta;
                });
            });
        }
        
        private void ErrorHiddenLayers()
        {
            for (int k = Layers.Count - 2; k > 0; k--)
            {
                Layers[k].Neurons.ForEach(neuron =>
                {
                    neuron.Inputs.ForEach(connection =>
                    {
                        var netInput = connection.GetOutput();
                        double sumPartial = 0;

                        Layers[k + 1].Neurons
                            .ForEach(outputNeuron =>
                            {
                                outputNeuron.Inputs.Where(i => i.IsFromNeuron(neuron.id))
                                    .ToList()
                                    .ForEach(outConnection =>
                                    {
                                        sumPartial += outConnection.PreviousWeight * outputNeuron.PreviousPartialDerivate;
                                    });
                            });
                        
                        var delta = -1 * netInput * sumPartial * neuron.CalculatePDOutput();
                        neuron.bias = -1 * sumPartial * neuron.CalculatePDOutput();
                        connection.UpdateWeight(_learning_rate, delta);
                    });
                });
            }
        }
        public void Train(double[][] inputs,double[][] expectedOutputs, int numberOfEpochs)
        {
            double totalError = 0;
            _expectedResult = expectedOutputs;

            for(int i = 0; i < numberOfEpochs; i++)
            {
                for(int j = 0; j < inputs.GetLength(0); j ++)
                {
                    var outputs = Forward(inputs[j].ToList());

                    totalError = CalculateTotalError(expectedOutputs[j]);
                    ErrorOutputLayer(expectedOutputs[j]);
                    ErrorHiddenLayers();
                }
            }
        }
        
        public void Train(double[][] inputs,double[][] expectedOutputs)
        {
            double totalError = 0;
            _expectedResult = expectedOutputs;
            
                for(int j = 0; j < inputs.GetLength(0); j ++)
                {
                    var outputs = Forward(inputs[j].ToList());

                    totalError = CalculateTotalError(expectedOutputs[j]);
                    ErrorOutputLayer(expectedOutputs[j]);
                    ErrorHiddenLayers();
                }
            
        }

        public void ShowNeuralNetStructure()
        {
            string outt = "";
            foreach (var layer in Layers)
            {
                var neurons = layer.Neurons;
                
                foreach (var neuron in neurons)
                {
                    outt+=
                    outt += neuron.id + "    ";
                    

                }
                
                
            }
        }
    }
}