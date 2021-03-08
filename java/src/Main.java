import components.Pair;
import matrix.RandomMatrix;
import matrix.util.MatrixRotationDegree;

import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        int matrixSize;
        RandomMatrix randomMatrix;
        Scanner defaultScanner = new Scanner(System.in);

        System.out.println("Enter matrix size: ");
        matrixSize = defaultScanner.nextInt();

        randomMatrix = new RandomMatrix(matrixSize, true);
        System.out.println(randomMatrix);

        randomMatrix.rotateBy(MatrixRotationDegree.ONE_ROTATION);
        System.out.println(randomMatrix);

        randomMatrix.resetRotation();
        System.out.println(randomMatrix);
    }
}
