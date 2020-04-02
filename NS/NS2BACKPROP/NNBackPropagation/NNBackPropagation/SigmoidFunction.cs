using System;

namespace NNBackPropagation
{
    [Serializable]
    public class SigmoidFunction : IActivationFunction
    {
        public double Activation(double Input)
        {
            return 1.0 / (1.0 +  Math.Exp(-Input));
        }

        public double Derivation(double Output)
        {
            return Output * (1 - Output);
        }
    }
}