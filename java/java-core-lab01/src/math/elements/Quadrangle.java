package math.elements;

import math.elements.util.QuadrangleType;
import math.plate.Point;

public class Quadrangle {
    private Point upperLeftPoint;
    private Point upperRightPoint;
    private Point lowerLeftPoint;
    private Point lowerRightPoint;

    public Quadrangle(Point upperLeftPoint, Point upperRightPoint, Point lowerLeftPoint, Point lowerRightPoint) {
        this.upperLeftPoint = upperLeftPoint;
        this.upperRightPoint = upperRightPoint;
        this.lowerLeftPoint = lowerLeftPoint;
        this.lowerRightPoint = lowerRightPoint;
    }

    public Double getHeight() {
        Double result = Math.abs(lowerLeftPoint.getY()) - Math.abs(upperLeftPoint.getY());
        return result < 0 ? -result : result;
    }

    public Double getWidth() {
        Double result =  Math.abs(lowerLeftPoint.getX()) - Math.abs(lowerRightPoint.getX());
        return result < 0 ? -result : result;
    }

    public Double getPerimeter() {
        return getHeight() * 2 + getWidth() * 2;
    }

    public Double getArea() {
        return getHeight() * getWidth();
    }

    public QuadrangleType getType() {
        Double height = getHeight();
        Double width = getWidth();
        if (height < width) {
            return QuadrangleType.RECTANGLE;
        } else if (height == width) {
            return QuadrangleType.SQUARE;
        }
        return QuadrangleType.UNKNOWN;
    }

    @Override
    public String toString() {
        return String.format("|%s, %s|\n|%s, %s|", upperLeftPoint, upperRightPoint, lowerLeftPoint, lowerRightPoint);
    }
}
