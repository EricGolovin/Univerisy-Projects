import components.Pair;
import math.operation.FractionOperation;
import math.operation.LineOperation;
import matrix.RandomMatrix;
import matrix.util.MatrixRotationDegree;
import services.StringService;

import java.util.Scanner;

public class Main {
    public static void main(String[] args) {

//         Lab 1.1
        System.out.println("Lab 1.1");
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

//         Lab 1.2.1
        System.out.println("Lab 1.2.1");
        FractionOperation fractionOperation = new FractionOperation(4);
        System.out.println(fractionOperation);

        FractionOperation newOperation = null;
        try {
            newOperation = fractionOperation.convertCollection();
        } catch(Exception exception) {
            System.out.println(exception.getMessage());
        }
        if (newOperation != null) {  System.out.println(String.format("Converted \n%s", newOperation)); }

//         Lab 1.2.2
        System.out.println("Lab 1.2.2");
        LineOperation lineOperation = new LineOperation(5);
        System.out.println(lineOperation);

        System.out.println(lineOperation.getIntersectingLines());
        System.out.println(lineOperation.getParallelLines());

//         Lab 1.3
        System.out.println("Lab 1.3");
        System.out.println("Hello from all over the World!");
        System.out.println(StringService.shared.duplicatesExistIn(StringService.shared.getFirstLetters("Hello from all over the World!")));
        System.out.println("Hello from all over the horld!");
        System.out.println(StringService.shared.duplicatesExistIn(StringService.shared.getFirstLetters("Hello from all over the horld!")));
    }
}
