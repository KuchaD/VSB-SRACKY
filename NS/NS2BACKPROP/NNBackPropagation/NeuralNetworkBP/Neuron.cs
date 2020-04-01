using System;
using System.Collections.Generic;
using System.Linq;
using NeuralNetworkBP.Interfaces;

namespace NeuralNetworkBP
{
    public class Neuron : INeuron
    {
        public Guid id { get; set; }
        private double _output;
        public double bias { get; set; }
        public double Output
        {
            get { return _output; }
        }
       
        public List<IConnection> Inputs { get; set; }
        public List<IConnection> Outputs { get; set; }
        public double PreviousPartialDerivate { get; set; }
        
        private IActiovationFunction _actiovation;

        public Neuron(IActiovationFunction actiovationFunction)
        {
            id = Guid.NewGuid();
            _actiovation = actiovationFunction;
            bias = RandomX.Instance().NextDouble();
            Inputs = new List<IConnection>();
            Outputs = new List<IConnection>();
        }
        public Neuron(IActiovationFunction actiovationFunction,double bias)
        {
            id = Guid.NewGuid();
            _actiovation = actiovationFunction;
            this.bias = bias;
            Inputs = new List<IConnection>();
            Outputs = new List<IConnection>();
        }
        public double CalculateOutput()
        {
            if (bias == 0)
                return Inputs.Select(x => x.Weight * x.GetOutput()).Sum();
            
            return _actiovation.Activation(Inputs.Select(x => x.Weight * x.GetOutput()).Sum()+bias);
        }

        public void Execute()
        {
            _output = CalculateOutput();
        }

        public void AddOutputNeuron(INeuron neuron)
        {
            Connection connection = new Connection(this,neuron);
            Outputs.Add(connection);
            neuron.Inputs.Add(connection);
        }

        public void AddInputNeuron(INeuron neuron)
        {
            Connection connection = new Connection(neuron,this);
            Inputs.Add(connection);
            neuron.Outputs.Add(connection);
        }

        public void AddInputConnection(double value)
        {
            InputConnection inputConnection = new InputConnection(value);
            Inputs.Add(inputConnection);
            bias = 0;
        }

        public void ChangeInputValue(double value)
        {
            if(Inputs.First() is InputConnection)
                ((InputConnection)Inputs.First()).Output = value;
            bias = 0;
        }
        
        public double CalculateError(double expectedOutput) {
            return 0.5 * Math.Pow((expectedOutput - _output),2);
        }

        public double CalculatePDEror(double expectedOutput)
        {
            return -(expectedOutput - Output);
        }
        public double CalculatePDOutput()
        {
            return _actiovation.Derivation(Output);
        }
    }
}