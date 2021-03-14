package math.operation.error;

public class IncorrectLengthException extends Exception {
    public IncorrectLengthException() {
        super("ERROR: Size of three collections does not equal");
    }
}
