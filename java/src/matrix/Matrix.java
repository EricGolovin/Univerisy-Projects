package matrix;

import matrix.util.MatrixRotationDegree;
import services.NumberGeneratorService;

public class Matrix {
    protected int[][] elementsGrid;
    private int[][] initialElementsGrid = null;

    public Matrix(int size) {
        elementsGrid = new int[size][size];
    }

    @Override
    public String toString() {
        String result = "";
        for (int[] row : elementsGrid) {
            for (int element : row) {
                if (element >= 0 && element < 10) {
                    result += String.format("%d  ", element);
                } else {
                    result += String.format("%d ", element);
                }
            }
            result += "\n";
        }
        return result;
    }

    public void rotateBy(MatrixRotationDegree degree) {
        if (initialElementsGrid == null) { initialElementsGrid = elementsGrid; }
        switch (degree) {
            case ONE_ROTATION:
                rotateByOne();
                break;
            case TWO_ROTATIONS:
                for (int i = 0; i < 2; i++) {
                    rotateByOne();
                }
                break;
            case THREE_ROTATIONS:
                for (int i = 0; i < 3; i++) {
                    rotateByOne();
                }
                break;
            default:
                break;
        }
    }

    private void rotateByOne() {
        int gridLength = elementsGrid.length;
        for (int i = 0; i < gridLength; i++) {
            for (int j = i; j < gridLength - 1; j++) {
                int temp = elementsGrid[i][j];
                elementsGrid[i][j] = elementsGrid[gridLength - 1 - j][i];
                elementsGrid[gridLength - 1 - j][i] = elementsGrid[gridLength - 1 - i][gridLength - 1 - j];
                elementsGrid[gridLength - 1 - i][gridLength - 1 - j] = elementsGrid[j][gridLength - 1 - i];
                elementsGrid[j][gridLength - 1 - i] = temp;
            }
        }
    }

    public void resetRotation() {
        elementsGrid = initialElementsGrid;
    }
}
