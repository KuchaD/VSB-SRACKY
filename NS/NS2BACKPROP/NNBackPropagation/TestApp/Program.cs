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
            Test();

  
            Console.ReadLine();
        }

        static void Test()
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
          
  
            //NNetwork NN = new NNetwork(2,new int[]{2},1,0.5,new SigmoidFunction());
            NeuralNetworkBP.NeuralNet NN = new NeuralNet(2,new int[]{2},1,0.5,new Sigmoid());
             
            
            
            for (int i = 0; i < 1000000; ++i)
            {
                //for(int j=0;j < training_set.Count;j++)
                //    NN.Train(training_set[j].ToList(),R[j].ToList());
                
                NN.Train(training_set.ToArray(),R.ToArray());   

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
    }
}