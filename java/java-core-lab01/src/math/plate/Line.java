package math.plate;

import components.IntegerPair;
import math.operation.error.LineIntersectionException;

public class Line {

    public static Boolean linesParallel(Line first, Line second) {
        Integer firstA = first.secondCoordinate.second - first.firstCoordinate.second;
        Integer firstB = first.firstCoordinate.first - first.firstCoordinate.first;
        Integer firstC = firstA * (first.firstCoordinate.first) + firstB * (first.firstCoordinate.second);

        Integer secondA = second.secondCoordinate.second - second.firstCoordinate.second;
        Integer secondB = second.firstCoordinate.first - second.firstCoordinate.first;
        Integer secondC = secondA * (second.firstCoordinate.first) + secondB * (second.firstCoordinate.second);

        Integer determinant = firstA * secondB - secondA * firstB;

        return determinant == 0;
    }

    public static IntegerPair linesIntersectionPoint(Line first, Line second) throws LineIntersectionException {
        Integer firstA = first.secondCoordinate.second - first.firstCoordinate.second;
        Integer firstB = first.firstCoordinate.first - first.firstCoordinate.first;
        Integer firstC = firstA * (first.firstCoordinate.first) + firstB * (first.firstCoordinate.second);

        Integer secondA = second.secondCoordinate.second - second.firstCoordinate.second;
        Integer secondB = second.firstCoordinate.first - second.firstCoordinate.first;
        Integer secondC = secondA * (second.firstCoordinate.first) + secondB * (second.firstCoordinate.second);

        Integer determinant = firstA * secondB - secondA * firstB;

        if (determinant == 0) { throw new LineIntersectionException(); }

        Integer xPoint = (secondB * firstC - firstB * secondC) / determinant;
        Integer yPoint = (firstA * secondC - secondA * firstC) / determinant;

        return new IntegerPair(xPoint, yPoint);
    }

    public IntegerPair firstCoordinate;
    public IntegerPair secondCoordinate;

    public Line(IntegerPair firstCoordinate, IntegerPair secondCoordinate) {
        this.firstCoordinate = firstCoordinate;
        this.secondCoordinate = secondCoordinate;
    }

    @Override
    public String toString() {
        return String.format("(%d, %d)---(%d, %d)",
                firstCoordinate.first,
                firstCoordinate.second,
                secondCoordinate.first,
                secondCoordinate.second
        );
    }
}
