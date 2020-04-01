namespace NeuralNetworkBP.Interfaces
{
    public interface IActiovationFunction
    {
        double Activation(double Input);
        double Derivation(double Input);
    }
}