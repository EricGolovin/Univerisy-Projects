package math.calculation;

public abstract class AbstractCalculation {
    protected String result = "";

    public String getResult() {
        setResult();
        return result;
    }

    protected abstract void setResult();
}
