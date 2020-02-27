package Percepton;

import javafx.scene.canvas.Canvas;
import javafx.scene.canvas.GraphicsContext;
import javafx.scene.layout.AnchorPane;
import javafx.scene.layout.Pane;
import javafx.scene.shape.StrokeType;
import javafx.scene.paint.Color;

import java.awt.*;

public class GraphicPane implements IGraphicPane {

    Canvas _Canvas;
    int _padding = 10;

    public GraphicPane(Canvas Canvas){
        _Canvas = Canvas;
        DrawTable();

    }
    public void DrawTable()
    {

        var gc =_Canvas.getGraphicsContext2D();
        gc.beginPath();
        gc.setStroke(Color.BLACK);
        gc.setLineWidth(5);
        gc.rect(0+ _padding,0 + _padding ,_Canvas.getWidth() - _padding, _Canvas.getHeight() - _padding);
        gc.closePath();
        gc.save();
    }
}
