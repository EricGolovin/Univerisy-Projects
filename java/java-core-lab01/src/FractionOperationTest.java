import math.operation.FractionOperation;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;

class FractionOperationTest {
    private int numberOfRandomFractionsConst = 6;
    private int convertedFractionsCountConst = numberOfRandomFractionsConst / 3;

    @Test
    public void testRandomCreation() {
        FractionOperation newOperation = new FractionOperation(numberOfRandomFractionsConst);

        assertEquals(numberOfRandomFractionsConst, newOperation.array.length);
        assertEquals(numberOfRandomFractionsConst, newOperation.arrayList.size());
        assertEquals(numberOfRandomFractionsConst, newOperation.hashSet.size());
    }

    @Test
    public void testConversion() {
        FractionOperation newOperation = new FractionOperation(numberOfRandomFractionsConst);

        try {
            FractionOperation newConvertedOperation = newOperation.convertCollections();
            assertEquals(convertedFractionsCountConst, newConvertedOperation.array.length);
            assertEquals(convertedFractionsCountConst, newConvertedOperation.arrayList.size());
            assertEquals(convertedFractionsCountConst, newConvertedOperation.hashSet.size());
        } catch (Exception exception) {
            System.out.println(exception.getMessage());
        }
    }
}