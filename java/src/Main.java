import components.Pair;
import math.operation.FractionOperation;
import math.operation.LineOperation;
import matrix.RandomMatrix;
import matrix.util.MatrixRotationDegree;

import java.util.Scanner;

public class Main {
    public static void main(String[] args) {

        // Lab 1.1
//        int matrixSize;
//        RandomMatrix randomMatrix;
//        Scanner defaultScanner = new Scanner(System.in);
//
//        System.out.println("Enter matrix size: ");
//        matrixSize = defaultScanner.nextInt();
//
//        randomMatrix = new RandomMatrix(matrixSize, true);
//        System.out.println(randomMatrix);
//
//        randomMatrix.rotateBy(MatrixRotationDegree.ONE_ROTATION);
//        System.out.println(randomMatrix);
//
//        randomMatrix.resetRotation();
//        System.out.println(randomMatrix);

        // Lab 1.2.1
//        FractionOperation operation = new FractionOperation(4);
//        System.out.println(operation);
//
//        FractionOperation newOperation = null;
//        try {
//            newOperation = operation.convertCollection();
//        } catch(Exception exception) {
//            System.out.println(exception.getMessage());
//        }
//        if (newOperation != null) {  System.out.println(String.format("Converted \n%s", newOperation)); };

        // Lab 1.2.2
//        LineOperation operation = new LineOperation(5);
//        System.out.println(operation);
//
//        System.out.println(operation.getIntersectingLines());
//        System.out.println(operation.getParallelLines());

        // Lab 1.3
//        System.out.println(duplicatesExistIn(getFirstLetters("Hello from all over the World!")));
//        System.out.println(duplicatesExistIn(getFirstLetters("Hello from all over the horld!")));
    }

    static public Boolean duplicatesExistIn(String text) {
        var newArray = text.toLowerCase().split("");
        for (int i = 0; i < newArray.length; i++) {
            for (int y = i + 1; y < newArray.length; y++) {
                if (newArray[i].equals(newArray[y])) { return true; }
            }
        }
        return false;
    }

    static public String getFirstLetters(String text)
    {
        String firstLetters = "";
        text = text.replaceAll("[.,]", ""); // Replace dots, etc (optional)
        for(String s : text.split(" "))
        {
            firstLetters += s.charAt(0);
        }
        return firstLetters;
    }
}
