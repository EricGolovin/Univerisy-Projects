package math.calculation;

import matrix.AbstractMatrix;

import java.util.ArrayList;

public class MatrixCalculation extends AbstractCalculation {
    private AbstractMatrix matrixForCalculations;
    private int averageNumLength = -1;

    public MatrixCalculation(AbstractMatrix matrixForCalculations) {
        this.matrixForCalculations = matrixForCalculations;
        setAverageLength();
    }

    public ArrayList<Integer> getNumberLowerAverageLength() {
        ArrayList<Integer> resultList = new ArrayList<Integer>();
        for (int[] row : matrixForCalculations.getElementsGrid()) {
            for (int element : row) {
                if (String.valueOf(element).length() < averageNumLength) {
                    resultList.add(element);
                }
            }
        }
        return resultList;
    }

    public ArrayList<Integer> getNumberBelowAverageLength() {
        ArrayList<Integer> resultList = new ArrayList<Integer>();
        for (int[] row : matrixForCalculations.getElementsGrid()) {
            for (int element : row) {
                if (String.valueOf(element).length() > averageNumLength) {
                    resultList.add(element);
                }
            }
        }
        return resultList;
    }

    protected void setResult() {
        result = "";
        result += String.format("- Average = %d -", averageNumLength);
        result += "\n";
        result += getStringResultFrom("Lower Average", getNumberLowerAverageLength());
        result += "\n";
        result += getStringResultFrom("Below Average", getNumberBelowAverageLength());
    }

    private void setAverageLength() {
        double numberOfNums = 0;
        double numberOfChars = 0;
        for (int[] row : matrixForCalculations.getElementsGrid()) {
            for (int element : row) {
                numberOfNums += 1;
                numberOfChars += String.valueOf(element).length();
            }
        }
        averageNumLength = (int) Math.round(numberOfChars / numberOfNums);
    }

    private String getStringResultFrom(String resultTitle, ArrayList<Integer> list) {
        String resultString = String.format("%s:\n", resultTitle);
        for (Integer element : list) {
            resultString += String.format("%d \n", element);
        }
        return resultString;
    }
}
