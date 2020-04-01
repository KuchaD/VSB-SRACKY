using System;
using System.Collections.Generic;

namespace NNBackPropagation
{
    public class Neuron
    {
        public List<double> Weights { get; private set; } = new List<double>();
        private List<double> _inputs;
        public double bias { get; set; }
        public double Output{ get; private set; }
        private IActivationFunction _activationFunction;
        public double Error { get; set; }
        public List<double> ErrorWeight { get; set; } = new List<double>();

        
        
        public Neuron(int numInput)
        {
            _activationFunction = new SigmoidFunction();
            Random random = new Random();
            bias = random.NextDouble();

            for (int i = 0; i < numInput; i++)
            {
                Weights.Add(random.NextDouble());
            }
        }
        public Neuron(double Bias, IActivationFunction ActivationFunction, int numInput)
        {
            bias = Bias;
            _activationFunction = ActivationFunction;
            
            Random random = new Random();
            for (int i = 0; i < numInput; i++)
            {
                Weights.Add(random.NextDouble());
            }
        }
        
        public Neuron(double Bias, List<double> starWeights,IActivationFunction ActivationFunction)
        {
            bias = Bias;
            _activationFunction = ActivationFunction;
            Weights = starWeights;
        }

       
        private double CalculateNeuronOutput()
        {
            if (_inputs.Count != Weights.Count)
            {
                throw new Exception("Input Size have different size than weigth");
            }

            double sum = 0;
            for (int i = 0; i < _inputs.Count; i++)
            {
                sum += _inputs[i] * Weights[i];
            }

            return sum+ bias;
        }

     
        public double NeuronOutput(List<double> Inputs)
        {
            _inputs = Inputs;
            if(_activationFunction == null)
                throw new Exception("Activation function is null");
            
            Output = _activationFunction.Activation(CalculateNeuronOutput());
            return Output;
        }
        
        public double CalculateErorr(double targetOutput) {
            return 0.5 * Math.Pow((targetOutput - Output),2);
        }

        public double CalculatePDEror(double targetOutput)
        {
            return  - (targetOutput - Output);
        }

        public double CalculatePDOutput()
        {
            return _activationFunction.Derivation(Output);
        }
        
        public double CalculatePDWeight(int index) {
            return  _inputs[index];
        }
    }
}