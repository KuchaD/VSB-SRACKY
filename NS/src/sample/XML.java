package sample;

import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.parsers.DocumentBuilder;

import b.j.n.P;
import com.intellij.xdebugger.breakpoints.XBreakpointListener;
import groovy.lang.Tuple;
import org.junit.Test;
import org.w3c.dom.Document;
import org.w3c.dom.NodeList;
import org.w3c.dom.Node;
import org.w3c.dom.Element;

import java.awt.*;
import java.io.File;
import java.util.ArrayList;

public class XML {


    public ArrayList<Double> _max;
    public ArrayList<Double> _min;
    public ArrayList<String> _names;
    public double _learn;
    public ArrayList<Double> _weight;


    public ArrayList<ArrayList<Double>> TestSet;
    public ArrayList<ArrayList<Double>> TrainSet;
    public ArrayList<Double> TrainSetOutputs;

    public XML()
    {
        _max = new ArrayList<Double>();
        _min = new ArrayList<Double>();
        _weight = new ArrayList<Double>();
        _names= new ArrayList<String>();

        TestSet = new ArrayList<>();
        TrainSet = new ArrayList<>();
        TrainSetOutputs = new ArrayList<>();
    }
    public void ReadXML(String FileName)
    {
        try {

            File fXmlFile = new File(FileName);
            DocumentBuilderFactory dbFactory = DocumentBuilderFactory.newInstance();
            DocumentBuilder dBuilder = dbFactory.newDocumentBuilder();
            Document doc = dBuilder.parse(fXmlFile);

            //doc.getDocumentElement().normalize();

            //System.out.println("Root element :" + doc.getDocumentElement().getNodeName());

            NodeList nList = doc.getElementsByTagName("inputDescriptions");
            for (int temp = 0; temp < nList.getLength(); temp++) {
                Node nNode = nList.item(temp);

                if (nNode.getNodeType() == Node.ELEMENT_NODE) {
                    Element eElement = (Element) nNode;

                    double max = Double.parseDouble(eElement.getElementsByTagName("maximum").item(0).getTextContent());
                    double min = Double.parseDouble(eElement.getElementsByTagName("minimum").item(0).getTextContent());
                    String name = eElement.getElementsByTagName("name").item(0).getTextContent();

                    _max.add(max);
                    _min.add(min);
                    _names.add(name);

                }
            }

            _learn = Double.parseDouble(doc.getElementsByTagName("lerningRate").item(0).getTextContent());

            NodeList nListWeights = doc.getElementsByTagName("weight");
            for (int temp = 0; temp < nListWeights.getLength(); temp++) {
                Node nNode = nListWeights.item(temp);
                _weight.add(Double.parseDouble(nNode.getTextContent()));

            }


            // TestSet ===============================
            {
                NodeList nListTest = doc.getElementsByTagName("TestSet");

                Element Test = (Element) (nListTest.item(0));
                NodeList nListElement = Test.getElementsByTagName("inputs");

                for (int i = 0; i < nListElement.getLength(); i++) {
                    Node nNode = nListElement.item(i);
                    Element eElement = (Element) nNode;
                    NodeList nListInput = eElement.getElementsByTagName("value");
                    ArrayList<Double> eInput = new ArrayList<>();

                    for (int j = 0; j < nListInput.getLength(); j++) {
                        eInput.add(Double.parseDouble(nListInput.item(j).getTextContent()));
                    }
                    TestSet.add(eInput);
                }
            }
            // Train ===============================

            NodeList nListTest = doc.getElementsByTagName("TrainSet");

            Element Test = (Element)(nListTest.item(0));
            NodeList nListElement = Test.getElementsByTagName("element");
            for (int i= 0; i < nListElement.getLength(); i++) {
                Node nNode = nListElement.item(i);
                Element eElement = (Element) nNode;
                NodeList nListInputs = eElement.getElementsByTagName("value");

                ArrayList<Double> eInput = new ArrayList<>();
                for (int j = 0; j < nListInputs.getLength(); j++) {
                    eInput.add(Double.parseDouble(nListInputs.item(j).getTextContent()));
                }
                TrainSet.add(eInput);
                TrainSetOutputs.add(Double.parseDouble(eElement.getElementsByTagName("output").item(0).getTextContent()));
            }



        } catch (Exception e) {
            e.printStackTrace();
        }

    }
}
