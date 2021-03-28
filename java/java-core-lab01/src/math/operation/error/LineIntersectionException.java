package math.operation.error;

public class LineIntersectionException extends Exception {
    public LineIntersectionException() {
        super("ERROR: Line are parallel and do not intersect");
    }
}
