using System;

namespace NeuralNetworkBP
{
    public class RandomX
    {
        private Random _random;
        private RandomX()
        {
            _random = new Random();
        }

        public double NextDouble()
        {
            return _random.NextDouble();
        }
        private static RandomX instance = null; 
        public static RandomX Instance()
        {
            if (instance == null)
                instance = new RandomX();
            return instance;
        }
    }
}