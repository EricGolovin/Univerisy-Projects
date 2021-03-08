package components;

public class Pair<FirstType, SecondType> {
    public FirstType first;
    public SecondType second;

    public Pair(FirstType firstValue, SecondType secondValue) {
        this.first = firstValue;
        this.second = secondValue;
    }

    @Override
    public String toString() {
        return String.format("(%s, %s)", first, second);
    }
}
