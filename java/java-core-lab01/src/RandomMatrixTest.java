import matrix.RandomMatrix;
import org.junit.jupiter.api.Test;
import services.NumberGeneratorService;

import static org.junit.jupiter.api.Assertions.*;

class RandomMatrixTest {
    private int matrixSizeConst = 20;
    private int minBoundConst = -10;
    private int maxBoundConst = 10;

    @Test
    public void testPositiveRandomMatrixWithoutBoundsCreation() {
        RandomMatrix newPositiveRandomMatrix = new RandomMatrix(matrixSizeConst, true);

        for (int[] row : newPositiveRandomMatrix.getElementsGrid()) {
            for (int columnElement : row) {
                assertTrue(columnElement >= 0);
            }
            assertEquals(matrixSizeConst, row.length);
        }

        assertEquals(matrixSizeConst, newPositiveRandomMatrix.getElementsGrid().length);
    }

    @Test
    public void testNegativeRandomMatrixWithoutBoundsCreation() {
        RandomMatrix newPositiveRandomMatrix = new RandomMatrix(matrixSizeConst, false);

        for (int[] row : newPositiveRandomMatrix.getElementsGrid()) {
            for (int columnElement : row) {
                assertTrue(columnElement < 0);
            }
            assertEquals(matrixSizeConst, row.length);
        }

        assertEquals(matrixSizeConst, newPositiveRandomMatrix.getElementsGrid().length);
    }

    @Test
    public void testRandomMatrixWithBoundsCreation() {
        RandomMatrix newPositiveRandomMatrix = new RandomMatrix(matrixSizeConst, minBoundConst, maxBoundConst);

        for (int[] row : newPositiveRandomMatrix.getElementsGrid()) {
            for (int columnElement : row) {
                assertTrue(columnElement >= minBoundConst && columnElement <= maxBoundConst);
            }
            assertEquals(matrixSizeConst, row.length);
        }

        assertEquals(matrixSizeConst, newPositiveRandomMatrix.getElementsGrid().length);
    }
}