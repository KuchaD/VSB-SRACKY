using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace NS
{
    public class LoadXML
    {
        public double _learning {get;set;}
        public List<double> _max { get; set;}
        public List<double> _min { get; set; }

        public List<string> _names { get; set; }
        public List<double> _weights { get; set; }

        public List<List<double>> _testSet { get; set; }

        public List<List<double>> _trainSet { get; set; }
        public List<double> _trainOutput { get; set; }

        public LoadXML()
        {
            _max = new List<double>();
            _min = new List<double>();
            _weights = new List<double>();
            _names = new List<string>();
            
            _testSet = new List<List<double>>();
            _trainSet = new List<List<double>>();
            _trainOutput = new List<double>();

        }

        public void ReadXML(String fileName) 
        {
            try{
                XmlDocument doc = new XmlDocument();
                doc.Load(fileName);

                XmlNodeList MaxNodes = doc.DocumentElement.SelectNodes("/perceptronTask/perceptron/inputDescriptions/maximum");

                foreach (XmlNode nNode in MaxNodes)
                {                 
                    string Text = nNode.InnerText;
                    _max.Add(Double.Parse(Text, CultureInfo.InvariantCulture));
                }

                XmlNodeList MinNodes = doc.DocumentElement.SelectNodes("/perceptronTask/perceptron/inputDescriptions/minimum");

                foreach (XmlNode nNode in MinNodes)
                {
                    string Text = nNode.InnerText;
                    _min.Add(Double.Parse(Text, CultureInfo.InvariantCulture));
                }

                XmlNodeList NameNodes = doc.DocumentElement.SelectNodes("/perceptronTask/perceptron/inputDescriptions/name");

                foreach (XmlNode nNode in NameNodes)
                {
                    string Text = nNode.InnerText;
                    _names.Add(Text);
                }

                XmlNodeList WeightNodes = doc.DocumentElement.SelectNodes("/perceptronTask/perceptron/weights/weight");

                foreach (XmlNode nNode in WeightNodes)
                {
                    string Text = nNode.InnerText;
                    _weights.Add(Double.Parse(Text, CultureInfo.InvariantCulture));
                }

                XmlNodeList TestInputNodes = doc.DocumentElement.SelectNodes("/perceptronTask/TestSet/element/inputs");

                foreach (XmlNode nNode in TestInputNodes)
                {
                    var TestValueNodes = nNode.ChildNodes;
                    List<double> Values = new List<double>();
                    foreach (XmlNode value in TestValueNodes)
                    {
                        Values.Add(Double.Parse(value.InnerText, CultureInfo.InvariantCulture));


                    }
                    _testSet.Add(Values);
                }

                XmlNodeList TrainInputNodes = doc.DocumentElement.SelectNodes("/perceptronTask/TrainSet/element/inputs");

                foreach (XmlNode nNode in TrainInputNodes)
                {
                    var TraintValueNodes = nNode.ChildNodes;
                    List<double> Values = new List<double>();
                    foreach (XmlNode value in TraintValueNodes)
                    {
                        Values.Add(Double.Parse(value.InnerText, CultureInfo.InvariantCulture));
                      
                    }
                    _trainSet.Add(Values);
                }

                XmlNodeList TrainOutputInputNodes = doc.DocumentElement.SelectNodes("/perceptronTask/TrainSet/element/output");

                foreach (XmlNode nNode in TrainOutputInputNodes)
                {
                    _trainOutput.Add(Double.Parse(nNode.InnerText, CultureInfo.InvariantCulture));
                }

                XmlNode Elearn = doc.DocumentElement.SelectSingleNode("/perceptronTask/perceptron/lerningRate");

                _learning = Double.Parse(Elearn.InnerText, CultureInfo.InvariantCulture);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }


    }
}
