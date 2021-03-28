package math.operation;

import components.IntegerPair;
import components.Pair;
import math.elements.Quadrangle;
import math.elements.util.QuadrangleType;
import math.plate.Line;
import math.plate.Point;
import services.NumberGeneratorService;

import java.util.ArrayList;
import java.util.HashSet;

public class QuadrangleOperation extends AbstractOperation<Quadrangle> {
    private final Pair X_BOUNDS = new Pair(-99, 99);
    private final Pair Y_BOUNDS = new Pair(-99, 99);

    public QuadrangleOperation(int numberOfRandomQuadrangle) {
        this(new Quadrangle[numberOfRandomQuadrangle], new ArrayList<Quadrangle>(), new HashSet<Quadrangle>());
        generateValues(numberOfRandomQuadrangle);
    }

    public QuadrangleOperation(Quadrangle[] array, ArrayList<Quadrangle> arrayList, HashSet<Quadrangle> hashSet) {
        super(array, arrayList, hashSet);
    }

    public Quadrangle getQuadrangleWithTheLowestArea() {
        Quadrangle result = null;
        for (Quadrangle quadrangle : arrayList) {
            if (result == null) {
                result = quadrangle;
                continue;
            }
            if (result.getArea() > quadrangle.getArea()) {
                result = quadrangle;
            }
        }
        return result;
    }

    protected void generateValues(int count) {
        for (int i = 0; i < count; i++) {
            Integer newUpperLeftPointX = NumberGeneratorService.shared.newBoundedRandomValue((int)X_BOUNDS.first, (int)X_BOUNDS.second);
            Integer newUpperLeftPointY = NumberGeneratorService.shared.newBoundedRandomValue((int)Y_BOUNDS.first, (int)Y_BOUNDS.second);
            Point newUpperLeftPoint = new Point(new Pair(Double.valueOf(newUpperLeftPointX), Double.valueOf(newUpperLeftPointY)));

            Integer newUpperRightPointX = NumberGeneratorService.shared.newBoundedRandomValue((int)X_BOUNDS.first, (int)X_BOUNDS.second);
            Integer newUpperRightPointY = NumberGeneratorService.shared.newBoundedRandomValue((int)Y_BOUNDS.first, (int)Y_BOUNDS.second);
            Point newUpperRightPoint = new Point(new Pair(Double.valueOf(newUpperRightPointX), Double.valueOf(newUpperRightPointY)));

            Integer newLowerLeftPointX = NumberGeneratorService.shared.newBoundedRandomValue((int)X_BOUNDS.first, (int)X_BOUNDS.second);
            Integer newLowerLeftPointY = NumberGeneratorService.shared.newBoundedRandomValue((int)Y_BOUNDS.first, (int)Y_BOUNDS.second);
            Point newLowerLeftPoint = new Point(new Pair(Double.valueOf(newLowerLeftPointX), Double.valueOf(newLowerLeftPointY)));

            Integer newLowerRightPointX = NumberGeneratorService.shared.newBoundedRandomValue((int)X_BOUNDS.first, (int)X_BOUNDS.second);
            Integer newLowerRightPointY = NumberGeneratorService.shared.newBoundedRandomValue((int)Y_BOUNDS.first, (int)Y_BOUNDS.second);
            Point newLowerRightPoint = new Point(new Pair(Double.valueOf(newLowerRightPointX), Double.valueOf(newLowerRightPointY)));

            Quadrangle newQuadrangle = new Quadrangle(newUpperLeftPoint, newUpperRightPoint, newLowerLeftPoint, newLowerRightPoint);
            array[i] = newQuadrangle;
            arrayList.add(newQuadrangle);
            hashSet.add(newQuadrangle);
        }
    }


}
