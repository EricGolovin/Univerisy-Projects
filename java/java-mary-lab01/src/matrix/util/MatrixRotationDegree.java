package matrix.util;

public enum MatrixRotationDegree {
    ONE_ROTATION(90),
    TWO_ROTATIONS(180),
    THREE_ROTATIONS(270);

    public int value;

    MatrixRotationDegree(int degree) {
        value = degree;
    }
}
