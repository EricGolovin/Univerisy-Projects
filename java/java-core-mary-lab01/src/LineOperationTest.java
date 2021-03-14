import math.operation.FractionOperation;
import math.operation.LineOperation;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;

class LineOperationTest {
    private static int numberOfRandomLinesConst = 6;

    @Test
    public void generateMatrix() {
        LineOperation newOperation = new LineOperation(numberOfRandomLinesConst);

        assertEquals(numberOfRandomLinesConst, newOperation.array.length);
        assertEquals(numberOfRandomLinesConst, newOperation.arrayList.size());
        assertEquals(numberOfRandomLinesConst, newOperation.hashSet.size());
    }
}