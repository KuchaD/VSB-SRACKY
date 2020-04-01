using System;
using System.Collections.Generic;
using NeuralNetworkBP.Interfaces;

namespace NeuralNetworkBP
{
    public class BiasNeuron : INeuron
    {
        public Guid id { get; set; }
        public double Output
        {
            get { return _output; }
        }
        public double bias { get; set; }
        private double _output;
        public List<IConnection> Inputs { get; set; }
        public List<IConnection> Outputs { get; set; }
        public double PreviousPartialDerivate { get; set; }
        private IActiovationFunction _actiovation;
        
        public BiasNeuron(IActiovationFunction actiovationFunction)
        {
            id = Guid.NewGuid();
            _actiovation = actiovationFunction;

            Inputs = new List<IConnection>();
            Outputs = new List<IConnection>();
        }
        public double CalculateOutput()
        {
            return 1;
        }

        public void Execute()
        {
            _output = 1;
        }

        public void AddOutputNeuron(INeuron neuron)
        {
            Connection connection = new Connection(this,neuron);
            Outputs.Add(connection);
            neuron.Inputs.Add(connection);
        }

        public void AddInputNeuron(INeuron neuron)
        {
            throw new NotImplementedException();
        }


        public void AddInputConnection(double value)
        {
            throw new NotImplementedException();
        }

        public void ChangeInputValue(double value)
        {
            throw new NotImplementedException();
        }
        
        public double CalculateError(double expectedOutput) {
            throw new NotImplementedException();
        }

        public double CalculatePDEror(double expectedOutput)
        {
            throw new NotImplementedException();
        }
        public double CalculatePDOutput()
        {
            return _actiovation.Derivation(Output);
        }
        
    }
}