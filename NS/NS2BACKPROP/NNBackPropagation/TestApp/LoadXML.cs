using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;

namespace TestApp
{
    public class LoadXML
    {
        public double _learning {get;set;}
        public List<double> _max { get; set;}
        public List<double> _min { get; set; }

        public List<string> _names { get; set; }
        public List<double> _weights { get; set; }

        public List<double[]> _testSet { get; set; }

        public List<double[]> _trainSet { get; set; }
        public List<double[]> _trainOutput { get; set; }
        
        public int InputNeurons { get; set; }
        public List<int> LayersNeurons { get; set; }
        

        public List<string> outputNames { get; set; }
        
        public LoadXML()
        {
            _max = new List<double>();
            _min = new List<double>();
            _weights = new List<double>();
            _names = new List<string>();
            
            _testSet = new List<double[]>();
            _trainSet = new List<double[]>();
            _trainOutput = new List<double[]>();
            LayersNeurons = new List<int>();
            outputNames = new List<string>();

        }

        public void ReadXML(String fileName) 
        {
            try{
                XmlDocument doc = new XmlDocument();
                doc.Load(fileName);

                XmlNodeList MaxNodes = doc.DocumentElement.SelectNodes("/backpropagationNeuronNet/inputDescriptions/inputDescription/maximum");

                foreach (XmlNode nNode in MaxNodes)
                {                 
                    string Text = nNode.InnerText;
                    _max.Add(Double.Parse(Text, CultureInfo.InvariantCulture));
                }

                XmlNodeList MinNodes = doc.DocumentElement.SelectNodes("/backpropagationNeuronNet/inputDescriptions/inputDescription/minimum");

                foreach (XmlNode nNode in MinNodes)
                {
                    string Text = nNode.InnerText;
                    _min.Add(Double.Parse(Text, CultureInfo.InvariantCulture));
                }

                XmlNodeList NameNodes = doc.DocumentElement.SelectNodes("/backpropagationNeuronNet/inputDescriptions/inputDescription/name");

                foreach (XmlNode nNode in NameNodes)
                {
                    string Text = nNode.InnerText;
                    _names.Add(Text);
                }


                XmlNodeList TestInputNodes = doc.DocumentElement.SelectNodes("/backpropagationNeuronNet/testSet/testSetElement/inputs");

                foreach (XmlNode nNode in TestInputNodes)
                {
                    var TestValueNodes = nNode.ChildNodes;
                    List<double> Values = new List<double>();
                    foreach (XmlNode value in TestValueNodes)
                    {
                        Values.Add(Double.Parse(value.InnerText, CultureInfo.InvariantCulture));


                    }
                    _testSet.Add(Values.ToArray());
                }

                XmlNodeList TrainInputNodes = doc.DocumentElement.SelectNodes("/backpropagationNeuronNet/trainSet/trainSetElement/inputs");

                foreach (XmlNode nNode in TrainInputNodes)
                {
                    var TraintValueNodes = nNode.ChildNodes;
                    List<double> Values = new List<double>();
                    foreach (XmlNode value in TraintValueNodes)
                    {
                        Values.Add(Double.Parse(value.InnerText, CultureInfo.InvariantCulture));
                      
                    }
                    _trainSet.Add(Values.ToArray());
                }
                
                XmlNodeList TrainOutputNodes = doc.DocumentElement.SelectNodes("/backpropagationNeuronNet/trainSet/trainSetElement/outputs");

                foreach (XmlNode nNode in TrainOutputNodes)
                {
                    var TraintValueNodes = nNode.ChildNodes;
                    List<double> Values = new List<double>();
                    foreach (XmlNode value in TraintValueNodes)
                    {
                        Values.Add(Double.Parse(value.InnerText, CultureInfo.InvariantCulture));
                      
                    }
                    _trainOutput.Add(Values.ToArray());
                }
                
                XmlNode Elearn = doc.DocumentElement.SelectSingleNode("/backpropagationNeuronNet/learningRate");
                _learning = Double.Parse(Elearn.InnerText, CultureInfo.InvariantCulture);
                
                XmlNode outNeurons = doc.DocumentElement.SelectSingleNode("/backpropagationNeuronNet/inputsCount");
                InputNeurons = Int32.Parse(outNeurons.InnerText, CultureInfo.InvariantCulture);
                 
                XmlNodeList LayersNodes = doc.DocumentElement.SelectNodes("/backpropagationNeuronNet/neuronInLayersCount/neuronInLayerCount");
                
                foreach (XmlNode nNode in LayersNodes)
                {
                    string Text = nNode.InnerText;
                    LayersNeurons.Add(Int32.Parse(Text, CultureInfo.InvariantCulture));
                }
                XmlNodeList LayersNodesNames = doc.DocumentElement.SelectNodes("/backpropagationNeuronNet/outputDescriptions/outputDescription");
                
                foreach (XmlNode nNode in LayersNodesNames)
                {
                    string Text = nNode.InnerText;
                    outputNames.Add(Text);
                }
             
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}