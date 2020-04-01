using System;
using NeuralNetworkBP.Interfaces;

namespace NeuralNetworkBP
{
    public class Sigmoid : IActiovationFunction
    {
        public double Activation(double Input)
        {
            return 1.0 / (1.0 +  Math.Exp(-Input));
        }

        public double Derivation(double Output)
        {
            
            return Output * (1 - Output);
        }

        public static Sigmoid Create()
        {
            return new Sigmoid();
        }

    }
}