package math.operation;

import math.elements.RationalFraction;
import math.operation.error.IncorrectLengthException;
import services.NumberGeneratorService;

import java.util.ArrayList;
import java.util.HashSet;

public class FractionOperation extends AbstractOperation<RationalFraction> {
    private final int MIN_NUMERATOR_VALUE = 1;
    private final int MAX_DENOMINATOR_VALUE = 99;

    public FractionOperation(RationalFraction[] array, ArrayList<RationalFraction> arrayList, HashSet<RationalFraction> hashSet) {
        super(array, arrayList, hashSet);
    }

    public FractionOperation(int numberOfRandomFractions) {
        this(new RationalFraction[numberOfRandomFractions], new ArrayList<RationalFraction>(), new HashSet<RationalFraction>());
        generateValues(numberOfRandomFractions);
    }

    public FractionOperation convertCollections() throws IncorrectLengthException {
        RationalFraction[] newArray;
        ArrayList<RationalFraction> newArrayList = new ArrayList<RationalFraction>();
        HashSet<RationalFraction> newHashSet = new HashSet<RationalFraction>();

        if (areCollectionsEqual()) {
            for (int i = 0; i < arrayList.size(); i++) {
                if (i % 2 == 0 && i + 1 != arrayList.size() && i != 0) {
                    newArrayList.add(arrayList.get(i + 1));
                    newHashSet.add(array[i + 1]);
                }
            }

            newArray = new RationalFraction[newArrayList.size()];
            for (int i = 0; i < newArrayList.size(); i++) {
                newArray[i] = newArrayList.get(i);
            }

            return new FractionOperation(newArray, newArrayList, newHashSet);
        }
        throw new IncorrectLengthException();
    }

    protected void generateValues(int count) {
        for (int i = 0; i < count; i++) {
            int newNumerator = NumberGeneratorService.shared.newBoundedRandomValue(MIN_NUMERATOR_VALUE, MAX_DENOMINATOR_VALUE - 1);
            int newDenominator = NumberGeneratorService.shared.newBoundedRandomValue(newNumerator, MAX_DENOMINATOR_VALUE);
            RationalFraction newFraction = new RationalFraction(newNumerator, newDenominator);
            array[i] = newFraction;
            arrayList.add(newFraction);
            hashSet.add(newFraction);
        }
    }
}
