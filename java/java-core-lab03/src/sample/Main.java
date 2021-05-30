package sample;

import javafx.application.Application;
import javafx.scene.Scene;
import javafx.scene.Group;
import javafx.scene.shape.Circle;
import javafx.scene.shape.Polygon;
import javafx.stage.Stage;
import javafx.animation.AnimationTimer;
import javafx.scene.paint.Color;

public class Main extends Application {
    static Circle circle1 = new Circle(60,60, 60);
    static Circle circle2 = new Circle(60 * 3,60, 60);
    static Circle circle3 = new Circle(60 * 5,60, 60);
    static Circle circle4 = new Circle(60 * 7,60, 60);
    static Circle circle5 = new Circle(60 * 9,60, 60);

    static int numberOfCorners = 4;

    static Color someCircleColor = Color.DARKSLATEBLUE;
    static Color somePolygonColor = Color.GRAY;

    @Override
    public void start(Stage stage) {
        Polygon polygon = new Polygon();


        polygon.getPoints().addAll(new Double[]{
                300.0, 50.0,
                450.0, 150.0,
                300.0, 250.0,
                150.0, 150.0,
        });

        new AnimationTimer() {
            @Override
            public void handle(long currentTime) {
                Main.circle1.setCenterY(Main.circle1.getCenterY() + 1);
                Main.circle2.setCenterY(Main.circle2.getCenterY() + 1);
                Main.circle3.setCenterY(Main.circle3.getCenterY() + 1);
                Main.circle4.setCenterY(Main.circle4.getCenterY() + 1);
                Main.circle5.setCenterY(Main.circle5.getCenterY() + 1);

                Main.circle1.setFill(someCircleColor);
                Main.circle2.setFill(someCircleColor);
                Main.circle3.setFill(someCircleColor);
                Main.circle4.setFill(someCircleColor);
                Main.circle5.setFill(someCircleColor);

                polygon.setFill(somePolygonColor);
            }
        }.start();

        Group root = new Group(circle1,
                circle2,
                circle3,
                circle4,
                circle5,
                polygon);
        Scene scene = new Scene(root, 600, 600);
        stage.setTitle("Mary-Lab03");
        stage.setScene(scene);
        stage.show();

    }
    public static void main(String[] args) {
        launch(args);
    }
}
