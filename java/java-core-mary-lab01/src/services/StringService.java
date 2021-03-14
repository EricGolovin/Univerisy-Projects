package services;

public class StringService {
    public static StringService shared = new StringService();

    private StringService() { }


    public Boolean duplicatesExistIn(String text) {
        var newArray = text.toLowerCase().split("");
        for (int i = 0; i < newArray.length; i++) {
            for (int y = i + 1; y < newArray.length; y++) {
                if (newArray[i].equals(newArray[y])) { return true; }
            }
        }
        return false;
    }

    public String getFirstLetters(String text)
    {
        String firstLetters = "";
        text = text.replaceAll("[.,]", ""); // Replace dots, etc (optional)
        for(String s : text.split(" "))
        {
            firstLetters = firstLetters + s.charAt(0);
        }
        return firstLetters;
    }
}
