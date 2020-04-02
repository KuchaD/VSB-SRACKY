using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace NNBackPropagation
{

    [Serializable]
    public class NNLayer
    {

        public List<Neuron> Neurons { get; private set; }


        public NNLayer(int numberOfNeurons,int inputSize)
        {
            Neurons = new List<Neuron>();
            
            Random random = new Random();
            for (int i = 0; i < numberOfNeurons; i++)
            {
                IActivationFunction activationFunction = new SigmoidFunction();
                Neurons.Add(new Neuron(random.NextDouble(),activationFunction,inputSize));
            }

        }
        
        public NNLayer(int numberOfNeurons,IActivationFunction activationFunction,int inputSize)
        {
            Neurons = new List<Neuron>();
            Random random = new Random();
            for (int i = 0; i < numberOfNeurons; i++)
            {
                Neurons.Add(new Neuron(random.NextDouble(), activationFunction,inputSize));
            }
        }
        
        public List<double> Forward(List<double> Inputs)
        {
            List<double> Outputs = new List<double>();
            
            for(int i = 0;i < Neurons.Count;i++) 
                Outputs.Add(Neurons[i].NeuronOutput(Inputs) );

            return Outputs;
        }

        public List<double> GetOutputs()
        {
            List<double> Outputs = new List<double>();

            foreach (var nItem in Neurons)
            {
                Outputs.Add(nItem.Output);
            }
            
            return Outputs;
        }

        public override string ToString()
        {
            string s = "";
            s += "▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ \n";
            s += "▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ \n";
            s += $"Num Neurons: {Neurons.Count}\n";
            s += "═══════════════════════════ \n";
            int i=0;
            foreach(var nItem in Neurons )
            {
                s += $"    Neuron {++i}  \n";
                s += $"----------------------------\n";

                var weight = nItem.Weights;
                for (int j = 0; j < weight.Count ; ++j) {
                    s += $"        Weight  {j}  {weight[j]} \n";
                }
                s += $"Bias {nItem.bias} \n" ;
            }

            s += "▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ \n";

            return s;
        }
        
        
    }
}