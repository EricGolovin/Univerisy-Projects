package math.plate;

import components.Pair;

public class Point {
    private Pair<Double, Double> coordinates;

    public Point(Pair<Double, Double> coordinates) {
        this.coordinates = coordinates;
    }

    public Double getX() {
        return coordinates.first;
    }

    public Double getY() {
        return coordinates.second;
    }

    @Override
    public boolean equals(Object obj) {
        if (!(obj instanceof Point)) { return false; }
        if (((Point) obj).coordinates.first == coordinates.first && ((Point) obj).coordinates.second == coordinates.second) {
            return true;
        }
        return false;
    }

    @Override
    public String toString() {
        return String.format("(x:%s, y:%s)", coordinates.first, coordinates.second);
    }
}
