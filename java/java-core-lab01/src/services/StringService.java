package services;

public class StringService {
    public static StringService shared = new StringService();

    private StringService() { }

    public String getWordsStartingFrom(Character letter, String text) {
        String resultWords = "";
        text = text.replaceAll("[.,]", ""); // Replace dots, etc (optional)
        for(String word : text.split(" "))
        {
            resultWords = resultWords + word;
        }
        return resultWords;
    }
}
