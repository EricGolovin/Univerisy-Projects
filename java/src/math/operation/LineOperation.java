package math.operation;

import components.IntegerPair;
import components.Pair;
import math.fraction.RationalFraction;
import math.plate.Line;
import services.NumberGeneratorService;

import java.util.ArrayList;
import java.util.HashSet;

public class LineOperation extends Operation<Line> {
    private Pair X_BOUNDS = new Pair(-99, 99);
    private Pair Y_BOUNDS = new Pair(-99, 99);

    public LineOperation(Line[] array, ArrayList<Line> arrayList, HashSet<Line> hashSet) {
        super(array, arrayList, hashSet);
    }

    public LineOperation(int numberOfRandomLines) {
        this(new Line[numberOfRandomLines], new ArrayList<Line>(), new HashSet<Line>());
        generateValues(numberOfRandomLines);
    }

    public ArrayList<Pair<Line, Line>> getParallelLines() {
        var resultList = new ArrayList<Pair<Line, Line>>();
        for (int i = 0; i < array.length; i++) {
            for (int y = i + 1; y < array.length; y++) {
                if (Line.linesParallel(array[i], array[y])) {
                    resultList.add(new Pair(array[i], array[y]));
                }
            }
        }
        return resultList;
    }

    public ArrayList<Pair<Line, Line>> getIntersectingLines() {
        var resultList = new ArrayList<Pair<Line, Line>>();
        for (int i = 0; i < array.length; i++) {
            for (int y = i + 1; y < array.length; y++) {
                try {
                    IntegerPair newPair = Line.linesIntersectionPoint(array[i], array[y]);
                    resultList.add(new Pair(array[i], array[y]));
                } catch (Exception exception) {
                    continue;
                }
            }
        }
        return resultList;
    }

    protected void generateValues(int count) {
        for (int i = 0; i < count; i++) {
            Integer newFirstX = NumberGeneratorService.shared.newBoundedRandomValue((int)X_BOUNDS.first, (int)X_BOUNDS.second);
            Integer newFirstY = NumberGeneratorService.shared.newBoundedRandomValue((int)Y_BOUNDS.first, (int)Y_BOUNDS.second);
            Integer newSecondX = NumberGeneratorService.shared.newBoundedRandomValue((int)X_BOUNDS.first, (int)X_BOUNDS.second);
            Integer newSecondY = NumberGeneratorService.shared.newBoundedRandomValue((int)Y_BOUNDS.first, (int)Y_BOUNDS.second);
            Line newLine = new Line(new IntegerPair(newFirstX, newFirstY), new IntegerPair(newSecondX, newSecondY));
            array[i] = newLine;
            arrayList.add(newLine);
            hashSet.add(newLine);
        }
    }
}
