using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NS.Percepton
{
    public class Percepton
    {

        public List<double> weights { get; set; }
        public double bias { get; set; }
        public double learning { get; set; }

        public Percepton() { }

        public Percepton( List<double> Weights,double learning)
        {
            bias = Weights[0];
            weights = new List<double>();
            for(int i = 1;i < Weights.Count; i++)
            {
                weights.Add(Weights[i]);
            }

            this.bias = bias;
            this.learning = learning;
        }
        public int Predict(List<double> Input)
        {
            double sum = 0;
            for (int i = 0; i < weights.Count; i++)
            {
                sum += weights[i] * Input[i];
            }
            sum += bias;

            return sum < 0 ? 0 : 1;
        }

        public void Train(List<double> Input, int Target)
        {
            var guess = Predict(Input);
            var error = Target - guess;
            
            for(int i = 0;i < Input.Count; i++)
            {
                weights[i] = weights[i] + error * (Input[i] * learning);
            }

            this.bias = this.bias + error * learning;

        }


        public static double ConverMaxMin(double Input, double InputLow, double InputHigh, double OutputLow, double OutputHigh)
        {

            return ((Input - InputLow) / (InputHigh - InputLow)) * (OutputHigh - OutputLow) + OutputLow;
        }
    }
}
