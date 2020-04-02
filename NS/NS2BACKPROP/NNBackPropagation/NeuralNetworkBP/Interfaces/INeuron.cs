using System;
using System.Collections.Generic;

namespace NeuralNetworkBP.Interfaces
{
    public interface INeuron
    {
        Guid id { get; set; }
        
        double Output { get;}
        List<IConnection> Inputs { get; set; }
        List<IConnection> Outputs { get; set; }
        double bias { get; set; }
        double PreviousPD { get; set; }
        double CalculatePDOutput();
        double CalculateOutput();
        void Execute();
        void AddOutputNeuron(INeuron neuron);
        void AddInputNeuron(INeuron neuron);

        void AddInputConnection(double value);
        void ChangeInputValue(double value);
        double CalculateError(double expectedOutput);
        double CalculatePDEror(double expectedOutput);

    }
}