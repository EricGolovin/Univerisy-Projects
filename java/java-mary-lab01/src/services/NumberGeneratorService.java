package services;

import java.util.Random;

public class NumberGeneratorService {
    public static NumberGeneratorService shared = new NumberGeneratorService();

    private final int POSITIVE_MIN_BOUND = 0;
    private final int POSITIVE_MAX_BOUND = 99;

    private final int NEGATIVE_MIN_BOUND = -99;
    private final int NEGATIVE_MAX_BOUND = 99;

    public int newPositiveRandomValue() {
        return new Random().nextInt((POSITIVE_MAX_BOUND + 1) - POSITIVE_MIN_BOUND) + POSITIVE_MIN_BOUND;
    }

    public int newNegativeRandomValue() {
        return new Random().nextInt((NEGATIVE_MAX_BOUND + 1) - NEGATIVE_MIN_BOUND) + NEGATIVE_MIN_BOUND;
    }

    public int newBoundedRandomValue(int min, int max) {
        return new Random().nextInt((max + 1) - min) + min;
    }

    private NumberGeneratorService() { }
}
