using System;
using System.Collections.Generic;
using System.Linq;
using NeuralNetworkBP;
using NeuralNetworkBP.Interfaces;
using NNBackPropagation;
using Neuron = NeuralNetworkBP.Neuron;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Lekar();
            //TestXOR();
            MNIST();
            Console.ReadLine();
        }

        static void TestXOR()
        {
            List<double[]> training_set = new List<double[]>();
            training_set.Add(new double[2]{0,0});
            training_set.Add(new double[2]{0,1});
            training_set.Add(new double[2]{1,0});
            training_set.Add(new double[2]{1,1});
            
            
            
            List<double[]> R = new List<double[]>();
            R.Add(new double[] {0});
            R.Add(new double[] {1});
            R.Add(new double[] {1});
            R.Add(new double[] {0});
          
  
            NNetwork NN = new NNetwork(2,new int[]{5},1,0.4,new SigmoidFunction());
            //NeuralNetworkBP.NeuralNet NN = new NeuralNet(2,new int[]{2},1,0.5,new Sigmoid());
             
            
            
            for (int i = 0; i < 1000000; ++i)
            {
                for(int j=0;j < training_set.Count;j++)
                    NN.Train(training_set[j].ToList(),R[j].ToList());
                
                //NN.Train(training_set.ToArray(),R.ToArray());   

                string s = "";
                foreach (var nItem in NN.Forward(new double[2] {0, 0}.ToList()))
                {
                    s += $"0 0 = {nItem.ToString("F")}  \n";
                    
                }
                
                foreach (var nItem in NN.Forward(new double[2] {0, 1}.ToList()))
                {
                    s += $"0 1 = {nItem.ToString("F")}  \n";
                }
                
                foreach (var nItem in NN.Forward(new double[2] {1, 0}.ToList()))
                {
                    s += $"1 0 = {nItem.ToString("F")}  \n";
                }

                foreach (var nItem in NN.Forward(new double[2] {1, 1}.ToList()))
                {
                    s += $"1 1 = {nItem.ToString("F")}  \n";
                }

                
                Console.Write(s);
            }
        }

        static void Lekar()
        {
            LoadXML xml = new LoadXML();
            xml.ReadXML("lekar.xml");

            var hidden = new int[] { 4};

            var outputsNeurons = xml.LayersNeurons.Last();
            
           
            
            NNetwork NN = new NNetwork(xml.InputNeurons,hidden.ToArray(),outputsNeurons,xml._learning,new SigmoidFunction());
            
            List<double[]> inputConv = new List<double[]>();
            for (int i = 0; i < xml._trainSet.Count; i++)
            {
                List<double> Input = new List<double>();
                for (int j = 0; j < xml._trainSet[i].Length; j++)
                    Input.Add(NeuralNet.ConverMaxMin(xml._trainSet[i][j], xml._min[j], xml._max[j], 0, 1));
                
                inputConv.Add(Input.ToArray());
                
                
            }
            
            for (int j = 0; j < 1000000; ++j)
            {
                for (int k = 0; k < inputConv.Count; ++k)
                    NN.Train(inputConv[k].ToList(), xml._trainOutput[k].ToList());

                
                if(j%100 == 0){}
                for (int i = 0; i < xml._trainSet.Count; i++)
                {
                    var outputs = NN.Forward(xml._trainSet[i].ToList());

                    foreach (var output in outputs)
                    {
                        Console.Write(" " + output.ToString("F"));
                    }

                    Console.Write(" == ");
                    foreach (var output in xml._trainOutput[i].ToList())
                    {
                        Console.Write(" " + output);
                    }

                    Console.Write(" \n");
                }
            }

        }

        static void MNIST()
        {
            LoadCSVMNIST csv = new LoadCSVMNIST();
            csv.Read("train.csv");
            
            NNetwork NN = new NNetwork(784,new int[]{50},10,0.1,new SigmoidFunction());
            
            for (int j = 0; j < 1000; ++j)
            {
                for (int k = 0; k < csv.Images.Count; ++k)
                    NN.Train(csv.Images[k].Item1.ToList(), new double[]{0,0}.ToList());
            }
            
                for (int i = 0; i < 10; i++)
                {
                    var outputs = NN.Forward(csv.Images[i].Item1.ToList());
                    
                    Console.Write(" == ");
                    foreach (var output in csv.Images[i].Item2)
                    {
                        Console.Write(" " + output);
                    }

                    Console.Write(" \n");
                }
                
            


        }
    }
}