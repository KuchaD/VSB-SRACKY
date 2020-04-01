using System;

namespace NeuralNetworkBP.Interfaces
{
    public interface IConnection
    {
        double Weight { get; set; }
        double PreviousWeight { get; set; }
        
        double GetOutput();
        
        bool IsFromNeuron(Guid fromNeuronId);
        void UpdateWeight(double learningRate, double delta);
    }
}