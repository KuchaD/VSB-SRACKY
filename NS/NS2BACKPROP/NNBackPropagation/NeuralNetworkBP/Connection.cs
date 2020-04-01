using System;
using NeuralNetworkBP.Interfaces;

namespace NeuralNetworkBP
{
    public class Connection : IConnection
    {
        private INeuron _fromNeuron;
        private INeuron _toNeuron;

        public double Weight { get; set; }
        public double PreviousWeight { get; set; }

        public Connection(INeuron from, INeuron to)
        {
            _fromNeuron = from;
            _toNeuron = to;
            Weight = RandomX.Instance().NextDouble();
            PreviousWeight = 0;
        }
        
        public Connection(INeuron from, INeuron to,double weight)
        {
            _fromNeuron = from;
            _toNeuron = to;
            Weight = weight;
            PreviousWeight = 0;
        }


        public double GetOutput()
        {
            return _fromNeuron.Output;
        }

        public bool IsFromNeuron(Guid fromNeuronId)
        {
            return _fromNeuron.id.Equals(fromNeuronId);
        }

        public void UpdateWeight(double learningRate, double delta)
        {
            PreviousWeight = Weight;
            Weight += learningRate * delta;
        }
    }
}