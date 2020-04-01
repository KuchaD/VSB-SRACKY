using System;
using NeuralNetworkBP.Interfaces;

namespace NeuralNetworkBP
{
    public class InputConnection : IConnection
    {
        public double Weight { get; set; }
        public double Output { get; set; }
        public double PreviousWeight { get; set; }
        public double GetOutput()
        {
            return Output;
        }
        public InputConnection(double value)
        {
            Output = value;
            Weight = 1;
            PreviousWeight = 1;
        }
        public bool IsFromNeuron(Guid fromNeuronId)
        {
            return false;
        }

        public void UpdateWeight(double learningRate, double delta)
        {
            throw new Exception("Invalid for InputConnections");
        }
    }
}