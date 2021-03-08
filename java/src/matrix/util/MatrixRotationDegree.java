package matrix.util;

public enum MatrixRotationDegree {
    ONE_ROTATION(90),
    TWO_ROTATIONS(180),
    THREE_ROTATIONS(270);

    public int value;

    private MatrixRotationDegree(int degree) {
        value = degree;
    }
}
