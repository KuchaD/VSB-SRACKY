using System;
using System.Collections.Generic;
using System.Linq;

namespace NNBackPropagation
{
    public class NNetwork
    {
        public List<NNLayer> hiddenLayers { get;}
        public NNLayer outputLayer { get; }
        public int numberInputs { get; }
        private double _learningRate;

        public NNetwork(int inputLeNumberInputs,int[] hiddenLayersNumber,int outputLayerNumber,double learningRate,IActivationFunction activationFunction)
        {
            _learningRate = learningRate;
            numberInputs = inputLeNumberInputs;
            
            hiddenLayers = new List<NNLayer>();
            int InputSize = inputLeNumberInputs;
            for(var i=0; i < hiddenLayersNumber.Length;i++)
            {
                hiddenLayers.Add(new NNLayer(hiddenLayersNumber[i],activationFunction,InputSize));
                InputSize = hiddenLayersNumber[i];
            }
            
            outputLayer = new NNLayer(outputLayerNumber,activationFunction,InputSize);
        }
        public List<double> Forward(List<double> inputs)
        {
            if(numberInputs != inputs.Count)
                
                throw new Exception("Inputs length is not acceptable");

            var NextInput = inputs;
            foreach (var nLayer in hiddenLayers)
            {
                NextInput = nLayer.Forward(NextInput);
            }

            return outputLayer.Forward(NextInput);
        }

        public void Train(List<double> inputs, List<double> outputs)
        {
            Forward(inputs);

            //OutputLayer
            for (int i = 0; i < outputLayer.Neurons.Count; i++)
            {
                for (int j = 0; j < outputLayer.Neurons[i].Weights.Count; j++)
                {
                    outputLayer.Neurons[i].ErrorWeight.Add(   outputLayer.Neurons[i].CalculatePDOutput() * 
                                                                    outputLayer.Neurons[i].CalculatePDEror(outputs[i]) *
                                                                    outputLayer.Neurons[i].CalculatePDWeight(j) );
                }
                
                outputLayer.Neurons[i].Error = outputLayer.Neurons[i].CalculatePDOutput() * outputLayer.Neurons[i].CalculatePDEror(outputs[i]);
            }
            
            //hidden
            NNLayer nextLayer = outputLayer;
            
            for (int k = hiddenLayers.Count-1; k >= 0; k--)
            {
                for (int j = 0; j < hiddenLayers[k].Neurons.Count; ++j)
                {
                    for (int l = 0; l < hiddenLayers[k].Neurons[j].Weights.Count; l++)
                    {
                        double d_error = 0;
                        for (int i = 0; i < nextLayer.Neurons.Count; ++i)
                        {
                            d_error += nextLayer.Neurons[i].ErrorWeight[l];
                        }
                        hiddenLayers[k].Neurons[j].ErrorWeight.Add(d_error * hiddenLayers[k].Neurons[j].CalculatePDOutput() * hiddenLayers[k].Neurons[j].CalculatePDWeight(l));
                    }

                    hiddenLayers[k].Neurons[j].Error = hiddenLayers[k].Neurons[j].CalculatePDOutput();
                }
                Console.Write("");
                nextLayer = hiddenLayers[k];
            }
            //output update W+
            for (int i = 0; i < outputLayer.Neurons.Count; i++)
            {
                for (int j = 0; j < outputLayer.Neurons[i].Weights.Count; j++)
                    outputLayer.Neurons[i].Weights[j] = outputLayer.Neurons[i].Weights[j] -
                                                        (_learningRate * (outputLayer.Neurons[i].ErrorWeight[j]));

                outputLayer.Neurons[i].bias -= outputLayer.Neurons[i].Error * _learningRate;
            }
            
            //hidden update w+
            
            for (int k = hiddenLayers.Count-1; k >= 0; k--)
            {
                for (int j = 0; j < hiddenLayers[k].Neurons.Count; ++j)
                {
                    for (int l = 0; l < hiddenLayers[k].Neurons[j].Weights.Count; l++)
                    {
                        
                        hiddenLayers[k].Neurons[j].Weights[l] = hiddenLayers[k].Neurons[j].Weights[l] -
                                                            (_learningRate * (hiddenLayers[k].Neurons[j].ErrorWeight[l]));
                    }

                   hiddenLayers[k].Neurons[j].bias -= hiddenLayers[k].Neurons[j].Error * _learningRate;
                }
            }
            
        }

        public override string ToString()
        {
            string s = "";
            s += "▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ \n";
            s += "▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ \n";
            s += "NEURAL NETWORK\n";
            s+= $"Inputs:  {numberInputs} \n";
            s += "######################################### \n";
            int i = 0;
            foreach (var layer in hiddenLayers)
            {
                s += $"HIDDEN LAYER {++i}  \n";
                s += layer.ToString();
                s += "######################################### \n";
            }
           
            s += $"Output LAYER \n";
            s += "" + outputLayer.ToString();

            s+= "▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ \n" ;
            s+= "▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ \n"; 

            return  s;
        }
    }
}