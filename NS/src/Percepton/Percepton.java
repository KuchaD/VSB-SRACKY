package Percepton;

import com.android.tools.idea.gradle.project.sync.ng.nosyncbuilder.proto.VariantProto;
import com.intellij.openapi.editor.CaretVisualAttributes;
import com.intellij.openapi.vcs.history.VcsRevisionNumber;
import com.siyeh.ig.performance.ArraysAsListWithZeroOrOneArgumentInspection;
import org.apache.commons.lang.ArrayUtils;

import java.util.ArrayList;
import java.util.List;

public class Percepton implements IPercepton {


    private ArrayList<Double> _Input;
    private ArrayList<Double> _Weight;
    private double _learning_rate;

    private List<PerceptonListener > listeners = new ArrayList<PerceptonListener>();

    public void addListener(PerceptonListener  toAdd) {
        listeners.add(toAdd);
    }
    public void Log(String text) {

        for (PerceptonListener hl : listeners)
            hl.printLog(text);
    }

    public Percepton(ArrayList<Double> Weight,double Learning_rate)
    {

        _Weight = Weight;
        _learning_rate = Learning_rate;


    }

    @Override
    public double GetProbabilities() throws Exception{
        if( _Input.size() != _Weight.size())
        {
            throw new Exception("Input size have different size like weight");
        }

        double probabilities = 0;
        for(int i =0;i < _Input.size();i++)
        {
            probabilities += _Input.get(i) * _Weight.get(i);

        }
        return probabilities;
    }

    @Override
    public int Predict() {

        try {
            double pb = GetProbabilities();
            double activation = 1/(1+Math.exp(-(pb)));

            if(activation >= 1)
            {
                return 1;
            }else
            {
                return 0;
            }
        }catch (Exception e) {
            e.printStackTrace();
        }

        return 1;
    }

    @Override
    public int[] Train(ArrayList<ArrayList<Double>> Inputs, ArrayList<Double> ExpectedOutput,int number_epoch) {

        Log("\n [Train] Start Preparing");
        for(int j=0; j < Inputs.size();j++)
        {
            for(int i=0;i < Inputs.get(j).size();i++)
            {
                Inputs.get(j).set(i,((Inputs.get(j).get(i))/10));
            }
            Inputs.get(j).add(0,1.0);
        }


        ArrayList<Integer> e_errors = new ArrayList<Integer>();
        for(int i = 0;i < number_epoch;i++)
        {
            Log("\n [Train] Epoch" + number_epoch);
            int errors = 0;

            for(int j=0; j < Inputs.size();j++)
            {
                SetInputs(Inputs.get(j));
                double predict = Predict();
                double expected = ExpectedOutput.get(j);
                double update = _learning_rate * (expected - predict);
                Log("\n [Train] update "+update);
                for(int w=0;w < _Weight.size();w++) {

                    double value = _Weight.get(w);
                    Log("\n [Train] weight "+ w +" "+ value +" ----->");
                    value += update * _Input.get(w);
                    Log(""+value);
                    _Weight.set(w,value);

                }
                errors += (update != 0) ?1: 0;
            }

            e_errors.add(errors);
        }

        return new int[2];
    }

    @Override
    public void SetInputs(ArrayList<Double> Inputs) {
        _Input = Inputs;

    }
}
