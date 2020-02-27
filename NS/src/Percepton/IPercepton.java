package Percepton;
import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.stage.Stage;

import java.util.ArrayList;


public interface IPercepton {
    double GetProbabilities() throws Exception;
    int Predict();
    int[] Train(ArrayList<ArrayList<Double>> Inputs,ArrayList<Double> ExpectedOutput,int number_epoch);
    void SetInputs(ArrayList<Double> Inputs);
}
