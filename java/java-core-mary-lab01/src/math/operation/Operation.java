package math.operation;

import math.fraction.RationalFraction;

import java.util.ArrayList;
import java.util.HashSet;

public abstract class Operation<CollectionType> {
    public CollectionType[] array;
    public ArrayList<CollectionType> arrayList;
    public HashSet<CollectionType> hashSet;

    protected Operation(CollectionType[] array, ArrayList<CollectionType> arrayList, HashSet<CollectionType> hashSet) {
        this.array = array;
        this.arrayList = arrayList;
        this.hashSet = hashSet;
    }

    @Override
    public String toString() {
        if (areCollectionsEqual()) {
            String arrayResult = "Array: \n";
            String arrayListResult = "ArrayList: \n";
            String hashSetResult = "HashSet converted to ArrayList: \n";

            ArrayList<CollectionType> hashSetArray = new ArrayList<CollectionType>(hashSet);
            for (int i = 0; i < array.length; i++) {
                arrayResult += String.format("%s \n", array[i]);
                arrayListResult += String.format("%s \n", arrayList.get(i));
                hashSetResult += String.format("%s \n", hashSetArray.get(i));
            }

            return arrayResult + "\n" + arrayListResult + "\n" + hashSetResult;
        }
        return "ERROR: Size of three collections does not equal";
    }

    protected abstract void generateValues(int count);

    protected Boolean areCollectionsEqual() {
        return array.length == arrayList.size() && array.length == hashSet.size() && arrayList.size() == hashSet.size();
    }
}
