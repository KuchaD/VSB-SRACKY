using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Serialization;
using Binaron.Serializer;
using ExtendedXmlSerializer;
using ExtendedXmlSerializer.Configuration;
using NeuralNetworkBP.Interfaces;

namespace NeuralNetworkBP
{
    [Serializable]
    public class NeuralNet
    {
        public List<NeuralLayer> Layers { get; set; }
        [XmlElement]
        private double _learning_rate;

        public double LastLearningRate { get; set; } = 0.1;

        public double lastTotalError;
        public NeuralNet(){}
        public NeuralNet(int inputNeurons, int[] hiddenNeurons, int outputNeuorns,double learningRate, IActiovationFunction actiovationFunction)
        {
            _learning_rate = learningRate;
            Layers = NNFactory.Create(inputNeurons, hiddenNeurons, outputNeuorns,actiovationFunction);
        }

        public NeuralNet(List<NeuralLayer> layers,double learningRate)
        {
            Layers = layers;
            _learning_rate = learningRate;
        }
        
        void SetInputValues(IEnumerable<double> values)
        {
            var neurons = Layers.First().Neurons;
            
            if (values.Count() != neurons.Count)
                return;

            for (int i = 0; i < neurons.Count ; i++)
            {
                neurons[i].ChangeInputValue(values.ElementAt(i));
            }
        }

        public double[] Forward(IEnumerable<double> values)
        {
            SetInputValues(values);
            return Forward();
        }
        double[] Forward()
        {
            if(Layers == null)
                return null;
            
            Layers.ForEach(x => x.ExecuteOutput());

            var last = Layers.Last();
            return last.Neurons.Select(x => x.Output).ToArray();

        }

        public double CalculateTotalError(double[] expectedOutputs)
        {
            double totalError = 0;

            for (int i = 0; i < Layers.Last().Neurons.Count; i++)
            {
                totalError += Layers.Last().Neurons[i].CalculateError(expectedOutputs[i]);
            }

            return totalError;
        }
        
        private void ErrorOutputLayer(double[] expectedOutputs)
        {
            Layers.Last().Neurons.ForEach(neuron =>
            {
                neuron.Inputs.ForEach(connection =>
                {
                    var weightPD = connection.GetOutput();

                    var expectedOutput = expectedOutputs[Layers.Last().Neurons.IndexOf(neuron)];

                    var nodeDelta = neuron.CalculatePDEror(expectedOutput) * neuron.CalculatePDOutput();
                    var delta = -1 * weightPD * nodeDelta;
                    
                    connection.UpdateWeight(_learning_rate, delta);

                    neuron.bias = -1 * nodeDelta * _learning_rate;
                    neuron.PreviousPD = nodeDelta;
                });
            });
        }
        
        private void ErrorHiddenLayers()
        {
            for (int k = Layers.Count - 2; k > 0; k--)
            {
                Layers[k].Neurons.ForEach(neuron =>
                {
                    neuron.Inputs.ForEach(connection =>
                    {
                        var weightPD = connection.GetOutput();
                        double sumPartial = 0;

                        Layers[k + 1].Neurons
                            .ForEach(outputNeuron =>
                            {
                                outputNeuron.Inputs.Where(i => i.IsFromNeuron(neuron.id))
                                    .ToList()
                                    .ForEach(outConnection =>
                                    {
                                        sumPartial += outConnection.PreviousWeight * outputNeuron.PreviousPD;
                                    });
                            });
                        
                        var delta = -1 * weightPD * sumPartial * neuron.CalculatePDOutput();
                        neuron.bias += -1 * neuron.CalculatePDOutput() * _learning_rate;
                        connection.UpdateWeight(_learning_rate, delta);
                    });
                    
                });
            }
        }
        public void Train(double[][] inputs,double[][] expectedOutputs, int numberOfEpochs)
        {
            double totalError = 0;

            for(int i = 0; i < numberOfEpochs; i++)
            {
                for(int j = 0; j < inputs.GetLength(0); j ++)
                {
                    var outputs = Forward(inputs[j]);

                    totalError = CalculateTotalError(expectedOutputs[j]);
                    ErrorOutputLayer(expectedOutputs[j]);
                    ErrorHiddenLayers();
                }
            }
        }
        
        public void Train(double[][] inputs,double[][] expectedOutputs)
        {
            double totalError = 0;

            for(int j = 0; j < inputs.GetLength(0); j ++)
            {
                    var outputs = Forward(inputs[j]);
                    
                    totalError = CalculateTotalError(expectedOutputs[j]);
                    
                    ErrorOutputLayer(expectedOutputs[j]);
                    ErrorHiddenLayers();
            }
            
                lastTotalError = totalError;

        }
        public void TrainOne(double[] inputs,double[] expectedOutputs)
        {
            double totalError = 0;
            
            var outputs = Forward(inputs);

                totalError = CalculateTotalError(expectedOutputs);
                ErrorOutputLayer(expectedOutputs);
                ErrorHiddenLayers();
            
            
        }
        public static double ConverMaxMin(double Input, double InputLow, double InputHigh, double OutputLow, double OutputHigh)
        {

            return ((Input - InputLow) / (InputHigh - InputLow)) * (OutputHigh - OutputLow) + OutputLow;
        }
        public static void SerializeBin(string path,NeuralNet net)
        {
            try 
            {
               
                IFormatter formatter = new BinaryFormatter();  
                Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);  
                formatter.Serialize(stream, net);  
                stream.Close();  


            }
            catch (SerializationException e) 
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                
            }
            
        }

        public static NeuralNet DeserializeBin(string path)
        {
           
            try 
            {
                IFormatter formatter = new BinaryFormatter();  
                Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);  
                NeuralNet obj = (NeuralNet) formatter.Deserialize(stream);  
                stream.Close();
                return obj;
            }
            catch (SerializationException e) 
            {
                Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
              
            }

            return null;
        }
        public void SerializationToXML(string path)
        {
            try
            {
                
                IExtendedXmlSerializer serializer = new ConfigurationContainer().UseAutoFormatting()
                    .UseOptimizedNamespaces()
                    .EnableImplicitTyping(typeof(NeuralNet))
                    .Create();

                
                var document = serializer.Serialize(new XmlWriterSettings {Indent = true},
                    this);
                TextWriter writer = new StreamWriter(path);
                writer.Write(document);
                writer.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void DeserializeFromXML(string path)
        {
            IExtendedXmlSerializer serializer = new ConfigurationContainer().UseAutoFormatting()
                .UseOptimizedNamespaces()
                .EnableReferences()
                .EnableImplicitTyping(typeof(NeuralNet))
                .Create();
            var document = File.ReadAllText(path);
            NeuralNet deserialize = serializer.Deserialize<NeuralNet>(document);
            _learning_rate = deserialize._learning_rate;
            this.Layers = deserialize.Layers;
        }
    }
}