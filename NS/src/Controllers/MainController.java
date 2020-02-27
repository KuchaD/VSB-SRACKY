package Controllers;
import java.io.File;
import java.net.URL;
import java.util.ArrayList;
import java.util.ResourceBundle;

import Percepton.Percepton;
import com.intellij.lexer._XmlLexer;
import javafx.application.Platform;
import javafx.beans.property.SimpleStringProperty;
import javafx.beans.value.ObservableValue;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.scene.canvas.Canvas;
import javafx.scene.control.*;
import javafx.scene.layout.Pane;
import javafx.stage.FileChooser;
import javafx.stage.Stage;
import javafx.util.Callback;
import sample.XML;
import Percepton.PerceptonListener;
import Percepton.GraphicPane;

public class MainController {

    private static class PerceptonLog implements PerceptonListener {
        private TextArea _Area;

        public PerceptonLog(TextArea a) {
            _Area = a;
        }

        @Override
        public void printLog(String text) {

            if (Platform.isFxApplicationThread()) {
                _Area.appendText(text);
            } else {
                Platform.runLater(() -> _Area.appendText(text));
            }
        }
    }


    @FXML
    // The reference of inputText will be injected by the FXML loader
    private TextField inputLearningRate;

    @FXML
    private Canvas Canvas;

    @FXML
    private TableView<ObservableList> TableTrain;


    @FXML
    private TableView TableTest;

    @FXML
    private TableView TableWeight;

    @FXML
    private TextArea TextAreaInfo;
    private PerceptonLog PLog ;

    @FXML
    private URL location;
    @FXML
    private ResourceBundle resources;

    @FXML
    private Menu MenuLoadXML;

    @FXML
    private Button ButtonLoad;
    @FXML
    private Button ButtonStart;

    @FXML
    private TitledPane TitlePane1;

    private Stage MainStage;

    final FileChooser fileChooser = new FileChooser();
    private XML XMLParser;
    private ObservableList<ObservableList> dataTrain;
    private ObservableList<ObservableList> dataTest;
    private ObservableList<ObservableList> dataWeight;
    private GraphicPane _graphic;

    private Percepton _percepton;

    public MainController() {
        XMLParser = new XML();

    }
    private void handleButtonAction(ActionEvent event) {
        Stage stage = (Stage) TitlePane1.getScene().getWindow();
        File file = fileChooser.showOpenDialog(stage);
        if (file != null) {
            XMLParser.ReadXML(file.getPath());
        }

        /*
        TableWeight.getColumns().clear();
        TableWeight.getItems().clear();

        TableTrain.getColumns().clear();
        TableTrain.getItems().clear();

        TableTest.getColumns().clear();
        TableTest.getItems().clear();
*/
        dataTrain = FXCollections.observableArrayList();
        /**********************************
         * TABLE COLUMN ADDED DYNAMICALLY *
         **********************************/

        for(int i=0 ; i<XMLParser.TrainSet.get(0).size()+1; i++) {
            //We are using non property style for making dynamic table
            final int j = i;
            TableColumn col;
            if(i >= XMLParser.TrainSet.get(0).size()) {
               col = new TableColumn("Expected");

                col.setCellValueFactory(new Callback<TableColumn.CellDataFeatures<ObservableList, String>, ObservableValue<String>>() {
                    public ObservableValue<String> call(TableColumn.CellDataFeatures<ObservableList, String> param) {
                        return new SimpleStringProperty(param.getValue().get(j).toString());
                    }
                });
            }else{
                col = new TableColumn("Input " + (i + 1));

                col.setCellValueFactory(new Callback<TableColumn.CellDataFeatures<ObservableList, String>, ObservableValue<String>>() {
                    public ObservableValue<String> call(TableColumn.CellDataFeatures<ObservableList, String> param) {
                        return new SimpleStringProperty(param.getValue().get(j).toString());
                    }
                });
            }
            TableTrain.getColumns().addAll(col);
        }


        /********************************
         * Data added to ObservableList *
         ********************************/
        for(int k=0;k < XMLParser.TrainSet.size();k++){

            ObservableList<String> row = FXCollections.observableArrayList();
            for(int l=0 ; l < XMLParser.TrainSet.get(k).size(); l++){
                double t = XMLParser.TrainSet.get(k).get(l);
                row.add( String.valueOf(t));
            }

            row.add(String.valueOf((double)XMLParser.TrainSetOutputs.get(k)));
            dataTrain.add(row);

        }

        //FINALLY ADDED TO TableView
        TableTrain.setItems(dataTrain);

        //TEST TABLE

        dataTest = FXCollections.observableArrayList();
        /**********************************
         * TABLE COLUMN ADDED DYNAMICALLY *
         **********************************/

        for(int i=0 ; i<XMLParser.TestSet.get(0).size(); i++) {
            //We are using non property style for making dynamic table
            final int j = i;
            TableColumn col;

            col = new TableColumn("Input " + (i + 1));

            col.setCellValueFactory(new Callback<TableColumn.CellDataFeatures<ObservableList, String>, ObservableValue<String>>() {
                public ObservableValue<String> call(TableColumn.CellDataFeatures<ObservableList, String> param) {
                    return new SimpleStringProperty(param.getValue().get(j).toString());
                }
            });

            TableTest.getColumns().addAll(col);
        }


        /********************************
         * Data added to ObservableList *
         ********************************/
        for(int k=0;k < XMLParser.TestSet.size();k++){

            ObservableList<String> row = FXCollections.observableArrayList();
            for(int l=0 ; l < XMLParser.TestSet.get(k).size(); l++){
                double t = XMLParser.TestSet.get(k).get(l);
                row.add( String.valueOf(t));
            }

            dataTest.add(row);

        }

        //FINALLY ADDED TO TableView
        TableTest.setItems(dataTest);

        inputLearningRate.setText(String.valueOf(XMLParser._learn));


        dataWeight = FXCollections.observableArrayList();

        /**********************************
         * TABLE COLUMN ADDED DYNAMICALLY *
         **********************************/

        for(int i=0 ; i<1; i++) {
            //We are using non property style for making dynamic table
            final int j = i;
            TableColumn col;

            col = new TableColumn("Weight ");

            col.setCellValueFactory(new Callback<TableColumn.CellDataFeatures<ObservableList, String>, ObservableValue<String>>() {
                public ObservableValue<String> call(TableColumn.CellDataFeatures<ObservableList, String> param) {
                    return new SimpleStringProperty(param.getValue().get(j).toString());
                }
            });

            TableWeight.getColumns().addAll(col);
        }


        /********************************
         * Data added to ObservableList *
         ********************************/
        for(int k=0;k < XMLParser._weight.size();k++){

            ObservableList<String> row = FXCollections.observableArrayList();
            double t = XMLParser._weight.get(k);
            row.add( String.valueOf(t));

            dataWeight.add(row);

        }

        //FINALLY ADDED TO TableView
        TableWeight.setItems(dataWeight);

        inputLearningRate.setText(String.valueOf(XMLParser._learn));

        var oldText = TextAreaInfo.getText()+"\n";
        for(int i = 0;i < XMLParser._max.size();i++)
        {
            oldText += XMLParser._names.get(i) + " -- Max: " + XMLParser._max.get(i) + "Min: " + XMLParser._min.get(i) + "\n";
        }
        TextAreaInfo.setText(oldText);

        _percepton = new Percepton(XMLParser._weight,XMLParser._learn);
        _percepton.addListener(PLog);
    }
    private void handleButtonStartAction(ActionEvent event)
    {
        _percepton.Train(XMLParser.TrainSet,XMLParser.TrainSetOutputs,100);
    }
    @FXML
    private void initialize() {
        inputLearningRate.setText("0.0");
        ButtonLoad.setOnAction(this::handleButtonAction);
        ButtonStart.setOnAction(this::handleButtonStartAction);
        PLog = new PerceptonLog(TextAreaInfo);
        _graphic = new GraphicPane(Canvas);
    }

}




