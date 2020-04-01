using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NeuralNetworkBP;
using NeuralNetworkBP.Interfaces;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;
using Neuron = NeuralNetworkBP.Neuron;

namespace Tests
{
    
    [TestClass]
    public class Tests
    {
        private NeuralNetworkBP.NeuralNet NN;
        [SetUp]
        public void Setup()
        {
            //Outputs
            var activation = new Sigmoid();
            
            
            List<INeuron> outputNeurons = new List<INeuron>();
            Neuron n1 = new Neuron(activation,0.60);
            Neuron n2 = new Neuron(activation,0.60);
            
            
            List<INeuron> hiddenNeurons = new List<INeuron>();
            Neuron h1 = new Neuron(activation,0.35);
            Neuron h2 = new Neuron(activation,0.35);
            
            Connection h1n1 = new Connection(h1,n1,0.4);
            Connection h1n2 = new Connection(h1,n2,0.50);
            Connection h2n1 = new Connection(h2,n1,0.45);
            Connection h2n2 = new Connection(h2,n2,0.55);
            
            n1.Inputs.Add(h1n1);
            n1.Inputs.Add(h2n1);
            
            n2.Inputs.Add(h1n2);
            n2.Inputs.Add(h2n2);
            
            h1.Outputs.Add(h1n1);
            h1.Outputs.Add(h1n2);
            
            h2.Outputs.Add(h2n1);
            h2.Outputs.Add(h2n2);
            
            List<INeuron> inputNeurons = new List<INeuron>();
            Neuron i1 = new Neuron(activation,0.0);
            Neuron i2 = new Neuron(activation,0.0);
            
            Connection i1h1 = new Connection(i1,h1,0.15);
            Connection i1h2 = new Connection(i1,h2,0.25);
            Connection i2h1 = new Connection(i2,h1,0.20);
            Connection i2h2 = new Connection(i2,h2,0.30);
            
            h1.Inputs.Add(i1h1);
            h1.Inputs.Add(i2h1);
            
            h2.Inputs.Add(i1h2);
            h2.Inputs.Add(i2h2);
            
            i1.Outputs.Add(i1h1);
            i1.Outputs.Add(i1h2);
            
            i2.Outputs.Add(i2h1);
            i2.Outputs.Add(i2h2);
            
            InputConnection In1 = new InputConnection(0.05);
            InputConnection In2 = new InputConnection(0.10);
            
            i1.Inputs.Add(In1);
            i2.Inputs.Add(In2);

            
            outputNeurons.Add(n1);
            outputNeurons.Add(n2);
            
            hiddenNeurons.Add(h1);
            hiddenNeurons.Add(h2);
            
            inputNeurons.Add(i1);
            inputNeurons.Add(i2);
            
            NeuralLayer Output = new NeuralLayer(outputNeurons);
            NeuralLayer Hidden = new NeuralLayer(hiddenNeurons);
            NeuralLayer Input = new NeuralLayer(inputNeurons);
            
            List<NeuralLayer> layers = new List<NeuralLayer>();
            
            layers.Add(Input);
            layers.Add(Hidden);
            layers.Add(Output);
            NN = new NeuralNet(layers,0.5);
        }

        [Test]
        public void Test1()
        {
            List<double[]> training_set = new List<double[]>();
            training_set.Add(new double[2]{0.05,0.10});
            
            List<double[]> R = new List<double[]>();
            R.Add(new double[] {0.01,0.99});
            
            var output = NN.Forward(new double[] {0.05, 0.10}.ToList());
            //NN.Train(training_set.ToArray(),R.ToArray());
            
            Assert.True(output[0].ToString("F") == "0.75");
            Assert.True(output[1].ToString("F") == "0.77");
        }
    }
}