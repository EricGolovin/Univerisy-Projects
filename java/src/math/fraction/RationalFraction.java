package math.fraction;

public class RationalFraction {
    public int numerator;
    public int denominator;

    public RationalFraction(int numerator, int denominator) {
        this.numerator = numerator;
        this.denominator = denominator;
    }

    public void add(RationalFraction fraction) {
        if (denominator == fraction.denominator) {
            numerator += fraction.numerator;
        } else {
            numerator = (numerator * fraction.denominator) + (fraction.numerator * denominator);
            denominator *= fraction.denominator;
        }
    }

    @Override
    public String toString() {
        return String.format("%d/%d", numerator, denominator);
    }
}
