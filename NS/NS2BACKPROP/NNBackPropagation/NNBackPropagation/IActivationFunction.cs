namespace NNBackPropagation
{
    public interface IActivationFunction
    {
        double Activation(double Input);

        double Derivation(double Input);
    }
}