package matrix;

import services.NumberGeneratorService;

public class RandomMatrix extends Matrix {
    public RandomMatrix(int size, Boolean isPositive) {
        super(size);
        if (isPositive) {
            fillUpWithPositiveValues();
        } else {
            fillUpWithNegativeValues();
        }
    }

    public RandomMatrix(int size, int minBound, int maxBound) {
        super(size);
        fillUpWithBoundValues(minBound, maxBound);
    }

    private void fillUpWithBoundValues(int minBound, int maxBound) {
        for (int i = 0; i < elementsGrid.length; i++) {
            for (int y = 0; y < elementsGrid[i].length; y++) {
                elementsGrid[i][y] = NumberGeneratorService.shared.newBoundedRandomValue(minBound, maxBound);
            }
        }
    }

    private void fillUpWithPositiveValues() {
        for (int i = 0; i < elementsGrid.length; i++) {
            for (int y = 0; y < elementsGrid[i].length; y++) {
                elementsGrid[i][y] = NumberGeneratorService.shared.newPositiveRandomValue();
            }
        }
    }

    private void fillUpWithNegativeValues() {
        for (int i = 0; i < elementsGrid.length; i++) {
            for (int y = 0; y < elementsGrid[i].length; y++) {
                elementsGrid[i][y] = NumberGeneratorService.shared.newNegativeRandomValue();
            }
        }
    }
}
